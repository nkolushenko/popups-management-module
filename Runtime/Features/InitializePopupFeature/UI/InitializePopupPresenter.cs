using PopupsManagement.Runtime.Features.APopupFeature.UI;
using PopupsManagement.Runtime.Services.UI.MVP;

namespace PopupsManagement.Runtime.Features.InitializePopupFeature.UI
{
    public class InitializePopupPresenter : BasePresenter<InitializePopupView, InitializePopupModel>
    {
        private readonly IPopupManager _popupManager;

        public InitializePopupPresenter(IPopupManager popupManager)
        {
            _popupManager = popupManager;
        }

        public override void Open<TShowParams>(TShowParams showParams)
        {
            base.Open(showParams);

            if (showParams is InitializePopupShowParams initializePopupShow)
            {
                PopupModel.SetShowParams(initializePopupShow);
            }

            PopupModel.Show();
        }

        public override void Close()
        {
            base.Close();
            PopupModel.ClearShowParams();
        }

        public void OnOpenAPopup()
        {
            _popupManager.OpenPopup<APopupModel, APopupView, APopupPresenter, IShowParams>(null);
        }

        public void OnCloseAllPopups()
        {
            _popupManager.CloseAllExceptFirst();
        }
    }
}