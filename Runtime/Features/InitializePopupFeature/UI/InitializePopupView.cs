using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;
using UnityEngine.UI;

namespace PopupsManagement.Runtime.Features.InitializePopupFeature.UI
{
    public class InitializePopupView : BasePopupView<InitializePopupPresenter>
    {
        [SerializeField] private Button openAPopupButton;
        [SerializeField] private Button closeAllPopupsButton;

        public override void Open()
        {
            base.Open();

            openAPopupButton.onClick.AddListener(Presenter.OnOpenAPopup);
            closeAllPopupsButton.onClick.AddListener(Presenter.OnCloseAllPopups);
        }

        public override void Close()
        {
            base.Close();
            
            openAPopupButton.onClick.RemoveListener(Presenter.OnOpenAPopup);
            closeAllPopupsButton.onClick.RemoveListener(Presenter.OnCloseAllPopups);
        }
    }
}