using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public abstract class View : MonoBehaviour
    {
        public PopupLifecycleMode LifecycleMode { get; private set; }

        public void SetLifecycleMode(PopupLifecycleMode lifecycleMode)
        {
            LifecycleMode = lifecycleMode;
        }

        public abstract void Open();
        public abstract void Close();
    }
}