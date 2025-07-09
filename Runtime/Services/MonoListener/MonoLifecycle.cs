using UnityEngine;

namespace PopupsManagement.Runtime.Services.MonoListener
{
    public class MonoLifecycle : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationQuit()
        {
            if (AppLifecycleRegistry<ApplicationQuit>.HasSubscribers)
            {
                AppLifecycleRegistry<ApplicationQuit>.Raise(new ApplicationQuit());
            }
        }
    }
}