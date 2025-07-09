using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace PopupsManagement.Runtime.Features.APopupFeature.UI
{
    public class BPopupView : BasePopupView<BPopupPresenter>
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button aWindowOpenButton;

        public override void Open()
        {
            base.Open();

            closeButton.onClick.AddListener(Presenter.OnCloseButtonClick);
            aWindowOpenButton.onClick.AddListener(Presenter.OnAWindowOpenClick);
        }

        public override void Close()
        {
            base.Close();

            closeButton.onClick.RemoveListener(Presenter.OnCloseButtonClick);
            aWindowOpenButton.onClick.RemoveListener(Presenter.OnAWindowOpenClick);
        }
    }
}