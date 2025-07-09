using System;
using PopupsManagement.Runtime.Services.UI.MVP;

namespace PopupsManagement.Runtime.Features.InitializePopupFeature.UI
{
    public class InitializePopupShowParams : IShowParams
    {
        public event Action OnShow;

        public void InvokeShow()
        {
            OnShow?.Invoke();
        }
    }
}