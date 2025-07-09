using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class InstantiateModeFactory : IFactory
    {
        public TPopupView Create<TPopupView>(PopupSetup setup, Transform parent = null) where TPopupView : View
        {
            var prefab = Resources.Load<TPopupView>(setup.windowPath);
            var view = Object.Instantiate(prefab, parent).GetComponent<TPopupView>();
            view.transform.localScale = Vector3.one;
            view.transform.SetAsLastSibling();
            return view;
        }

        public void Release<TPopupView>(TPopupView view) where TPopupView : View
        {
            Object.Destroy(view.gameObject);
        }
    }
}