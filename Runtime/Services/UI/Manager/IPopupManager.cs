namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public interface IPopupManager
    {
        void Initialize();

        void OpenPopup<TModel, TView, TPresenter, TShowParams>(TShowParams showParams)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>;

        void OpenPopupWithCustomSetup<TModel, TView, TPresenter, TShowParams>(PopupSetup popupSetup, TShowParams showParams)
            where TModel : BasePopupModel
            where TView : BasePopupView<TPresenter>
            where TShowParams : class, IShowParams
            where TPresenter : BasePresenter<TView, TModel>;

        void Close<TPresenter>() where TPresenter : IPopupPresenter;
        void CloseTop();

        void CloseAll();
        void CloseAllExceptFirst();
    }
}