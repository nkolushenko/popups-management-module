using PopupsManagement.Runtime.Features.InitializePopupFeature.UI;
using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;

namespace popups_management.Runtime.Features.InitializePopupFeature.Systems
{
    public class DebugExampleSystem
    {
        private readonly IPopupManager _popupManager;
        private InitializePopupShowParams _popupShowParams;

        public DebugExampleSystem(IPopupManager popupManager)
        {
            _popupManager = popupManager;
        }

        public void Initialize()
        {
            _popupShowParams = new InitializePopupShowParams();
            _popupShowParams.OnShow += InitializePopupShow;

            ShowPopup();
        }

        private void ShowPopup()
        {
            _popupManager.OpenPopup<InitializePopupModel, InitializePopupView, InitializePopupPresenter, InitializePopupShowParams>(
                _popupShowParams);
        }

        private void InitializePopupShow()
        {
            Debug.LogWarning("Initializing popup showed(message only for debug)");
        }

        public void Dispose()
        {
            _popupShowParams.OnShow -= InitializePopupShow;
        }
    }
}