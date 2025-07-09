using System;
using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class PopupViewFactory : IPopupViewFactory
    {
        private readonly IFactory _poolFactory = new PoolModeFactory();
        private readonly IFactory _instantiateModeFactory = new InstantiateModeFactory();
        private readonly IFactory _sceneModeFactory = new SceneModeFactory();

        public TPopupView Create<TPopupView>(PopupSetup setup, Transform parent = null) where TPopupView : View
        {
            TPopupView view;

            switch (setup.lifecycleMode)
            {
                case PopupLifecycleMode.Pool:
                    view = _poolFactory.Create<TPopupView>(setup, parent);
                    break;

                case PopupLifecycleMode.Instantiate:
                    view = _instantiateModeFactory.Create<TPopupView>(setup, parent);
                    break;

                case PopupLifecycleMode.Scene:
                    view = _sceneModeFactory.Create<TPopupView>(setup, parent);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            view.SetLifecycleMode(setup.lifecycleMode);

            return view;
        }

        public void Release<TPopupView>(TPopupView view) where TPopupView : View
        {
            var mode = view.LifecycleMode;
            switch (mode)
            {
                case PopupLifecycleMode.Pool:
                    _poolFactory.Release(view);
                    break;

                case PopupLifecycleMode.Instantiate:
                    _instantiateModeFactory.Release(view);
                    break;

                case PopupLifecycleMode.Scene:
                    _sceneModeFactory.Release(view);
                    break;
            }
        }
    }
}