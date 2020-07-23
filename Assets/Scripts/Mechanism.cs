using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Observer
{
    public delegate void Subscriber(string param);

    internal class Mechanism
    {
        private static Mechanism _ins;
        private Dictionary<string, Subscriber> _staticListeners = new Dictionary<string, Subscriber>();
        private Dictionary<string, Subscriber> _listeners = new Dictionary<string, Subscriber>();

        public Dictionary<string, Subscriber> StaticListeners => _staticListeners;
        public Dictionary<string, Subscriber> Listeners => _listeners;

        internal Mechanism()
        {
            SceneManager.sceneUnloaded += arg0 => { _listeners.Clear(); };
        }

        public static Mechanism Ins
        {
            get
            {
                if (_ins == null) _ins = new Mechanism();
                return _ins;
            }
        }

        private bool Fire(ref Dictionary<string, Subscriber> observers, string type, string param)
        {
            if (!observers.ContainsKey(type)) return false;
            observers[type](param);
            return true;
        }

        internal bool Fire(string type, string param)
        {
            bool a = Fire(ref _staticListeners, type, param);
            bool b = Fire(ref _listeners, type, param);
            return a || b;
        }

        private bool Listen(ref Dictionary<string, Subscriber> observers, string type, Subscriber handler)
        {
            if (!observers.ContainsKey(type))
            {
                observers.Add(type, handler);
                return true;
            }

            if (observers[type].GetInvocationList().Contains(handler)) return false;

            observers[type] += handler;
            return true;
        }

        internal bool Listen(string type, Subscriber handler, bool isStatic = false)
        {
            if (isStatic) return Listen(ref _staticListeners, type, handler);
            return Listen(ref _listeners, type, handler);
        }

        private bool Neglect(ref Dictionary<string, Subscriber> observers, string type, Subscriber handler)
        {
            if (!observers[type].GetInvocationList().Contains(handler)) return false;
            observers[type] -= handler;
            return true;
        }

        internal bool Neglect(string type, Subscriber handler, bool isStatic = false)
        {
            if (isStatic) return Neglect(ref _staticListeners, type, handler);
            return Neglect(ref _listeners, type, handler);
        }
    }
}