using PopupsManagement.Runtime.Features.APopupFeature.UI;
using PopupsManagement.Runtime.Features.InitializePopupFeature.Systems;
using PopupsManagement.Runtime.Features.InitializePopupFeature.UI;
using PopupsManagement.Runtime.Services.Configuration;
using PopupsManagement.Runtime.Services.UI.MVP;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PopupsManagement.Runtime.Features.Installer
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] UIRootComponent yourBehaviour;

        protected override void Configure(IContainerBuilder builder)
        {
            BuildServices(builder);

            builder.RegisterComponent(yourBehaviour);
            builder.RegisterEntryPoint<Bootstrapper>();

            BuildBFeaturePopupDependencies(builder);
            BuildAFeaturePopupDependencies(builder);
            BuildInitializePopupFeatureDependencies(builder);
        }

        private void BuildAFeaturePopupDependencies(IContainerBuilder builder)
        {
            builder.Register<APopupModel>(Lifetime.Transient);
            builder.Register<APopupPresenter>(Lifetime.Transient);
        }

        private static void BuildBFeaturePopupDependencies(IContainerBuilder builder)
        {
            builder.Register<BPopupModel>(Lifetime.Transient);
            builder.Register<BPopupPresenter>(Lifetime.Transient);
        }

        private static void BuildInitializePopupFeatureDependencies(IContainerBuilder builder)
        {
            builder.Register<InitializePopupModel>(Lifetime.Transient);
            builder.Register<InitializePopupPresenter>(Lifetime.Transient);
            builder.Register<DebugExampleSystem>(Lifetime.Singleton);
        }

        private static void BuildServices(IContainerBuilder builder)
        {
            builder.Register<PopupFactory>(Lifetime.Singleton).As<IPopupFactory>();
            builder.Register<PopupViewFactory>(Lifetime.Singleton).As<IPopupViewFactory>();
            builder.Register<PopupManager>(Lifetime.Singleton).As<IPopupManager>();
            builder.Register<ResourcesConfigurationsProvider>(Lifetime.Singleton).As<IConfigurationsProvider>();
        }
    }
}