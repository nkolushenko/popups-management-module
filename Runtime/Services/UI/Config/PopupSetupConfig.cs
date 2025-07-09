using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;

namespace PopupsManagement.Runtime.Features.BPopupFeature.Configs
{
    [CreateAssetMenu(fileName = "UI", menuName = "ScriptableObjects/PopupSetupConfig", order = 1)]
    public class PopupSetupConfig : ScriptableObject
    {
        [SerializeField] private PopupSetup popupSetup;
        
        public PopupSetup SetupData => popupSetup;
    }
}