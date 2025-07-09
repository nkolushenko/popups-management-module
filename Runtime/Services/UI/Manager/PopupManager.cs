using System;
using System.Collections.Generic;
using PopupsManagement.Runtime.Features.BPopupFeature.Configs;
using PopupsManagement.Runtime.Services.Configuration;
using PopupsManagement.Runtime.Services.MonoListener;
using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class PopupManager : IPopupManager, ILifecycleListener<ApplicationQuit>
    {
        private readonly Stack<IPopupPresenter> _popups = new(20);
        private readonly Dictionary<Type, IPopupPresenter> _presenters = new(20);
        private readonly HashSet<Type> _inTransition = new(20);

        private readonly IPopupFactory _popupFactory;
        private readonly IPopupViewFactory _popupViewFactory;
        private readonly IConfigurationsProvider _configurationsProvider;
        private readonly UIRootComponent _uiRootComponent;

        public PopupManager(
            IPopupFactory popupFactory,
            IPopupViewFactory popupViewFactory,
            UIRootComponent uiRootComponent,
            IConfigurationsProvider configurationsProvider)
        {
            _popupFactory = popupFactory;
            _popupViewFactory = popupViewFactory;
            _uiRootComponent = uiRootComponent;
            _configurationsProvider = configurationsProvider;
        }

        public void Initialize()
        {
            AppLifecycleRegistry<ApplicationQuit>.Subscribe(this);
        }

        public void OpenPopup<TModel, TView, TPresenter, TShowParams>(TShowParams showParams)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>
        {
            if (!_configurationsProvider.TryGetConfiguration<PopupSetupConfig, TView>(out var config))
            {
                return;
            }

            OpenPopupInternal<TModel, TView, TPresenter, TShowParams>(config.SetupData, showParams);
        }

        public void OpenPopupWithCustomSetup<TModel, TView, TPresenter, TShowParams>(PopupSetup setup, TShowParams showParams)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>
        {
            OpenPopupInternal<TModel, TView, TPresenter, TShowParams>(setup, showParams);
        }

        private void OpenPopupInternal<TModel, TView, TPresenter, TShowParams>(PopupSetup setup, TShowParams showParams)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>
        {
            var type = typeof(TPresenter);

            if (!TryLock(type))
            {
                return;
            }

            var presenter = CreateOrReusePresenter<TModel, TView, TPresenter, TShowParams>(setup);


            if (presenter == null)
            {
                Debug.LogError($"Could not create presenter of type {type.FullName}");
                return;
            }

            presenter.Open(showParams);
            _popups.Push(presenter);
        }

        private TPresenter CreateOrReusePresenter<TModel, TView, TPresenter, TShowParams>(PopupSetup setup)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>
        {
            var type = typeof(TPresenter);

            if (_presenters.TryGetValue(type, out var existing))
            {
                var view = _popupViewFactory.Create<TView>(setup, _uiRootComponent.UIRoot);
                var typed = (TPresenter)existing;
                typed.SetView(view);
                view.SetPresenter(typed);
                return typed;
            }

            var presenter = _popupFactory.CreatePopup<TModel, TView, TPresenter, TShowParams>(setup, _uiRootComponent.UIRoot);
            _presenters[type] = presenter;
            return presenter;
        }

        public void Close<TPresenter>() where TPresenter : IPopupPresenter
        {
            var type = typeof(TPresenter);
            if (!_presenters.TryGetValue(type, out var presenter))
            {
                return;
            }

            _popups.Pop();
            ReleaseClosedPopup(presenter);
        }

        public void CloseTop()
        {
            if (_popups.Count == 0)
            {
                return;
            }

            var presenter = _popups.Pop();
            ReleaseClosedPopup(presenter);
        }

        private void ReleaseClosedPopup(IPopupPresenter presenter)
        {
            presenter.Close();
            _popupFactory.ReleaseView(presenter.View);
            Unlock(presenter.GetType());
        }

        public void CloseAll()
        {
            CloseAll(0);
        }

        public void CloseAllExceptFirst()
        {
            CloseAll(1);
        }

        private void CloseAll(int maxCount)
        {
            while (_popups.Count > maxCount)
            {
                var presenter = _popups.Pop();
                ReleaseClosedPopup(presenter);
            }
        }

        public void OnEvent(in ApplicationQuit data)
        {
            AppLifecycleRegistry<ApplicationQuit>.Unsubscribe(this);
            CloseAll();
        }

        private bool TryLock(Type presenter) => _inTransition.Add(presenter);
        private void Unlock(Type presenter) => _inTransition.Remove(presenter);
    }
}