using HamiUnityObserver.Core;

namespace HamiUnityObserver.Facade
{
    public partial class HamiObserver
    {
        public static void Custom(string type,
            Subscriber action,
            byte priority = 0,
            bool isStatic = false,
            bool onlyOnce = false)
        {
            Mechanism.Ins.Listen(type, action, priority, isStatic, onlyOnce);
        }

        public static bool Fire(string type, string param)
        {
            return Mechanism.Ins.Fire(type, param);
        }

        public static bool NetListen(string routerName, Subscriber handler, bool isSuccess, byte priority = 0,
            bool isStatic = false,
            bool isOnlyForOnce = false)
        {
            return Mechanism.Ins.Listen(
                isSuccess ? "Success_" + routerName : "Failure_" + routerName,
                handler,
                priority,
                isStatic,
                isOnlyForOnce
            );
        }

        public static bool NetFire(string routerName, bool isSuccess, string jsonParam = "")
        {
            return Mechanism.Ins.Fire(
                isSuccess ? "Success_" + routerName : "Failure_" + routerName,
                jsonParam
            );
        }
    }
}