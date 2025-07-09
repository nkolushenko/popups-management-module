using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public interface IPopupFactory
    {
        public TPresenter CreatePopup<TModel, TView, TPresenter, TShowParams>(PopupSetup popupSetup, Transform parent = null)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TPresenter : BasePresenter<TView, TModel>
            where TShowParams : class, IShowParams;

        void ReleaseView<TPopupView>(TPopupView view) where TPopupView : View;
    }
}