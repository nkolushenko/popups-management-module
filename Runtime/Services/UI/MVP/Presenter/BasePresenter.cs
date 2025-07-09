namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class BasePresenter<TView, TModel> : IPopupPresenter
        where TView : View
        where TModel : BasePopupModel
    {
        protected TView PopupView { get; private set; }
        protected TModel PopupModel { get; private set; }

        public View View => PopupView;

        public void SetModel(TModel popupModel)
        {
            PopupModel = popupModel;
        }

        public void SetView(TView view)
        {
            PopupView = view;
        }

        public virtual void Close()
        {
            PopupView?.Close();
        }

        public virtual void Open<TShowParams>(TShowParams showParams) where TShowParams : class, IShowParams
        {
            PopupView?.Open();
        }
    }
}