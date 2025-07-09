using System;
using System.Collections.Generic;
using UnityEngine;

namespace PopupsManagement.Runtime.Services.Configuration
{
    public class ResourcesConfigurationsProvider : IConfigurationsProvider
    {
        private const string DefaultResourcesPath = "Configurations";

        private readonly Dictionary<Type, ScriptableObject> _configurations = new();

        public bool TryGetConfiguration<TConfig, TType>(out TConfig value) where TConfig : ScriptableObject
        {
            var key = typeof(TType);

            if (_configurations.TryGetValue(key, out var configuration))
            {
                value = (TConfig)configuration;
                return true;
            }

            value = Resources.Load<TConfig>($"{DefaultResourcesPath}/{key.Name}");

            if (value == null)
            {
                return false;
            }

            _configurations.Add(key, value);
            return true;
        }

        public bool TryGetConfiguration<T>(out T value) where T : ScriptableObject
        {
            var key = typeof(T);

            if (_configurations.TryGetValue(key, out var configuration))
            {
                value = (T)configuration;
                return true;
            }

            value = Resources.Load<T>($"{DefaultResourcesPath}/{key.Name}");
            if (value == null)
            {
                return false;
            }

            _configurations.Add(key, value);
            return true;
        }
    }
}