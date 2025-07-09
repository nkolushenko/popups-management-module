using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public interface IPopupViewFactory
    {
        TPopupView Create<TPopupView>(PopupSetup setup, Transform parent = null) where TPopupView : View;
        void Release<TPopupView>(TPopupView view) where TPopupView : View;
    }
}