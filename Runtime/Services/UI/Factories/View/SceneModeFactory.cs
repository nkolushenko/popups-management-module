using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class SceneModeFactory : IFactory
    {
        public TPopupView Create<TPopupView>(PopupSetup setup, Transform parent = null) where TPopupView : View
        {
            TPopupView view = Object.FindObjectOfType(typeof(TPopupView), true) as TPopupView;
            return view;
        }

        public void Release<TPopupView>(TPopupView view) where TPopupView : View
        {
        }
    }
}