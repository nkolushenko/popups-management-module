using UnityEngine;

namespace PopupsManagement.Runtime.Services.Configuration
{
    public interface IConfigurationsProvider
    {
        bool TryGetConfiguration<TConfig, TType>(out TConfig value) where TConfig : ScriptableObject;
        bool TryGetConfiguration<T>(out T value) where T : ScriptableObject;
    }
}