using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HamiUnityObserver.Core
{
    internal class Mechanism
    {
        private static Mechanism _ins;
        public static Mechanism Ins => _ins ?? (_ins = new Mechanism());
        private List<EventModel> _listeners = new List<EventModel>();
        public List<EventModel> Listeners => _listeners;

        private Mechanism()
        {
            SceneManager.sceneUnloaded += arg0 => { _listeners.RemoveAll(a => !a.IsStatic); };
        }

        internal bool Fire(string type, string param = null)
        {
            if (!_listeners.Any(a => a.Type == type)) return false;

            foreach (var model in _listeners.Where(a => a.Type == type))
            {
                model.Action(param);
                if (model.OnlyOnce) _listeners.Remove(model);
            }

            return true;
        }


        internal bool Listen(
            string type,
            Subscriber action,
            byte priority,
            // bool excludedFromPause,
            bool isStatic,
            bool onlyOnce
        )
        {
            if (_listeners.Any(a => a.Action == action && a.Type == type)) return false;
            _listeners.Add(new EventModel
            {
                Type = type,
                Action = action,
                Priority = priority,
                // ExcludedFromPause = excludedFromPause,
                IsStatic = isStatic,
                OnlyOnce = onlyOnce
            });

            _listeners.Sort((x, y) => y.Priority.CompareTo(x.Priority));

            return true;
        }

        internal bool Neglect(string type, Subscriber handler)
        {
            try
            {
                _listeners.Remove(_listeners.First(h => h.Action == handler && h.Type == type));
            }
            catch (Exception e)
            {
                MonoBehaviour.print(
                    "[HamiUnityObserver][ERROR] Probably, you are trying to remove a method that does not exist in the list.\n\n" +
                    e
                );
                return false;
            }

            return true;
        }
    }
}