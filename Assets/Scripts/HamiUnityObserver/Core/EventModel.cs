using System;

namespace HamiUnityObserver.Core
{
    public delegate void Subscriber(string param);

    public class EventModel
    {
        public byte Delay = 0;
        public string Type;
        public Action<string> Action;
        // public bool ExcludedFromPause = false;
        public bool IsStatic = false;
        public bool OnlyOnce = false;
    }
}