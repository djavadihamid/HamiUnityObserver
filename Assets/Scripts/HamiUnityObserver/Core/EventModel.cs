namespace HamiUnityObserver.Core
{
    public delegate void Subscriber(string param);

    public class EventModel
    {
        public byte Priority = 0;
        public string Type;
        public Subscriber Action;
        // public bool ExcludedFromPause = false;
        public bool IsStatic = false;
        public bool OnlyOnce = false;
    }
}