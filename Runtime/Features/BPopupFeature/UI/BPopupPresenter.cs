using PopupsManagement.Runtime.Services.UI.MVP;

namespace PopupsManagement.Runtime.Features.APopupFeature.UI
{
    public class BPopupPresenter : BasePresenter<BPopupView, BPopupModel>
    {
        private readonly IPopupManager _popupManager;

        public BPopupPresenter(IPopupManager popupManager)
        {
            _popupManager = popupManager;
        }
        
        public void OnCloseButtonClick()
        {
            _popupManager.CloseTop();
        }
    }
}