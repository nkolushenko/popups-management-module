namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class BasePopupView<TPresenter> : View where TPresenter : IPopupPresenter
    {
        protected TPresenter Presenter { get; private set; }

        public void SetPresenter(TPresenter presenter)
        {
            Presenter = presenter;
        }

        public override void Open()
        {
            gameObject.SetActive(true);
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}