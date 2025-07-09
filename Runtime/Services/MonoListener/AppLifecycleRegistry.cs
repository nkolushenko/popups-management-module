using System.Collections.Generic;

namespace PopupsManagement.Runtime.Services.MonoListener
{
    public static class AppLifecycleRegistry<T> where T : struct
    {
        private static readonly List<ILifecycleListener<T>> _handlers = new();
        private static bool _hasSubscribers;

        public static bool HasSubscribers => _hasSubscribers;

        public static void Subscribe(ILifecycleListener<T> listener)
        {
            if (listener == null || _handlers.Contains(listener))
            {
                return;
            }

            _handlers.Add(listener);
            _hasSubscribers = true;
        }

        public static void Unsubscribe(ILifecycleListener<T> listener)
        {
            if (_handlers.Remove(listener) && _handlers.Count == 0)
            {
                _hasSubscribers = false;
            }
        }

        public static void Raise(in T data)
        {
            if (!HasSubscribers)
            {
                return;
            }

            for (int i = 0; i < _handlers.Count; i++)
            {
                _handlers[i]?.OnEvent(in data);
            }
        }

        public static void Clear()
        {
            _handlers.Clear();
            _hasSubscribers = false;
        }
    }
}