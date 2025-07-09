using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public class UIRootComponent : MonoBehaviour
    {
        [SerializeField] Transform uiRoot;

        public Transform UIRoot => uiRoot;
    }
}