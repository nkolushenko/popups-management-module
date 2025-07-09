using System;
using popups_management.Runtime.Features.InitializePopupFeature.Systems;
using PopupsManagement.Runtime.Services.UI.MVP;
using VContainer.Unity;

namespace PopupsManagement.Runtime.Features.Installer
{
    public class Bootstrapper : IInitializable, IDisposable
    {
        private readonly IPopupManager _popupManager;
        private readonly DebugExampleSystem _debugExampleSystem;

        public Bootstrapper(IPopupManager popupManager, DebugExampleSystem debugExampleSystem)
        {
            _popupManager = popupManager;
            _debugExampleSystem = debugExampleSystem;
        }

        public void Initialize()
        {
            _popupManager.Initialize();
            _debugExampleSystem.Initialize();
        }

        public void Dispose()
        {
            _debugExampleSystem.Dispose();
        }
    }
}