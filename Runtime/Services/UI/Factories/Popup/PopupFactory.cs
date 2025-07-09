using UnityEngine;
using VContainer;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class PopupFactory : IPopupFactory
    {
        private readonly IPopupViewFactory _popupViewFactory;
        private readonly IObjectResolver _resolver;

        public PopupFactory(IObjectResolver resolver, IPopupViewFactory popupViewFactory)
        {
            _resolver = resolver;
            _popupViewFactory = popupViewFactory;
        }

        public TPresenter CreatePopup<TModel, TView, TPresenter, TShowParams>(PopupSetup popupSetup, Transform parent = null)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TPresenter : BasePresenter<TView, TModel>
            where TShowParams : class, IShowParams
        {
            var presenter = _resolver.Resolve<TPresenter>();
            var model = _resolver.Resolve<TModel>();

            presenter.SetModel(model);

            var view = _popupViewFactory.Create<TView>(popupSetup, parent);
            presenter.SetView(view);
            view.SetPresenter(presenter);
            return presenter;
        }

        public void ReleaseView<TPopupView>(TPopupView view) where TPopupView : View
        {
            _popupViewFactory.Release(view);
        }
    }
}