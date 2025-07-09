using System.Collections.Generic;
using UnityEngine;

namespace PopupsManagement.Runtime.Services.UI.MVP
{
    public static class ViewPool<TView> where TView : MonoBehaviour
    {
        private static readonly Dictionary<string, TView> Pool = new();

        public static TView Get(string path, Transform parent)
        {
            if (Pool.TryGetValue(path, out var instance))
            {
                instance.gameObject.SetActive(true);
                instance.transform.SetParent(parent, false);
                return instance;
            }

            var prefab = Resources.Load<TView>(path);
            var created = Object.Instantiate(prefab, parent);
            Pool[path] = created;
            return created;
        }

        public static void Release(TView view)
        {
            view.gameObject.SetActive(false);
        }

        public static void Clear()
        {
            Pool.Clear();
        }
    }
}