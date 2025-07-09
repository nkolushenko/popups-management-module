using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class PoolModeFactory : IFactory
    {
        public TPopupView Create<TPopupView>(PopupSetup setup, Transform parent = null) where TPopupView : View
        {
            TPopupView view = ViewPool<TPopupView>.Get(setup.windowPath, parent);
            view.transform.localScale = Vector3.one;
            view.transform.SetAsLastSibling();
            return view;
        }

        public void Release<TPopupView>(TPopupView view) where TPopupView : View
        {
            ViewPool<TPopupView>.Release(view);
        }
    }
}