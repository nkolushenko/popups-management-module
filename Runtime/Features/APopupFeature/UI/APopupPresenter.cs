using PopupsManagement.Runtime.Services.UI.MVP;

namespace PopupsManagement.Runtime.Features.APopupFeature.UI
{
    public class APopupPresenter : BasePresenter<APopupView, APopupModel>
    {
        private readonly IPopupManager _popupManager;

        public APopupPresenter(IPopupManager popupManager)
        {
            _popupManager = popupManager;
        }

        public void OnBWindowOpenClick()
        {
            _popupManager.OpenPopup<BPopupModel, BPopupView, BPopupPresenter, IShowParams>(null);
        }

        public void OnCloseButtonClick()
        {
            _popupManager.CloseTop();
        }
    }
}