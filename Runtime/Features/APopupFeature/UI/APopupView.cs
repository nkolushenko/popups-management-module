using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace PopupsManagement.Runtime.Features.APopupFeature.UI
{
    public class APopupView : BasePopupView<APopupPresenter>
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button bWindowOpenButton;

        public override void Open()
        {
            base.Open();

            closeButton.onClick.AddListener(Presenter.OnCloseButtonClick);
            bWindowOpenButton.onClick.AddListener(Presenter.OnBWindowOpenClick);
        }

        public override void Close()
        {
            base.Close();

            closeButton.onClick.RemoveListener(Presenter.OnCloseButtonClick);
            bWindowOpenButton.onClick.RemoveListener(Presenter.OnBWindowOpenClick);
        }
    }
}