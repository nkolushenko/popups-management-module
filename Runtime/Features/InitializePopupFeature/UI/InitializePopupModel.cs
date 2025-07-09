using PopupsManagement.Runtime.Services.UI.MVP;

namespace PopupsManagement.Runtime.Features.InitializePopupFeature.UI
{
    public class InitializePopupModel : BasePopupModel
    {
        private InitializePopupShowParams _initializePopupShow;

        public void SetShowParams(InitializePopupShowParams initializePopupShow)
        {
            _initializePopupShow = initializePopupShow;
        }

        public void Show()
        {
            _initializePopupShow?.InvokeShow();
        }

        public void ClearShowParams()
        {
            _initializePopupShow = null;
        }
    }
}