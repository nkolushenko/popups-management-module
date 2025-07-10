using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace PopupsManagement.Runtime.Features.APopupFeature.UI
{
    public class BPopupView : BasePopupView<BPopupPresenter>
    {
        [SerializeField] private Button closeButton;

        public override void Open()
        {
            base.Open();

            closeButton.onClick.AddListener(Presenter.OnCloseButtonClick);
        }

        public override void Close()
        {
            base.Close();

            closeButton.onClick.RemoveListener(Presenter.OnCloseButtonClick);
        }
    }
}