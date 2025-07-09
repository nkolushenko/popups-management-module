namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public interface IPopupPresenter
    {
        View View { get; }

        void Open<TShowParams>(TShowParams showParams) where TShowParams : class, IShowParams;
        void Close();
    }
}