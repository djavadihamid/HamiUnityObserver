namespace Observer
{
    public class ObserverFacade
    {
        public static void EnableLogging(bool isActive) => Logger.Ins._isLogEnabled = isActive;

        public static bool Listen(string type, Subscriber handler, bool isStatic = false)
        {
            Logger.Ins.Listen(type, isStatic);
            return Mechanism.Ins.Listen(type, handler, isStatic);
        }


        public static bool Fire(string type, string param = "")
        {
            Logger.Ins.Fire(type, param);
            return Mechanism.Ins.Fire(type, param);
        }

        public static bool Neglect(string type, Subscriber handler, bool isStatic = false)
        {
            Logger.Ins.Neglect(type,isStatic);
            return Mechanism.Ins.Neglect(type, handler, isStatic);
        }
    }
}