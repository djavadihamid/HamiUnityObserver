using System;
using HamiUnityObserver.Core;

namespace HamiUnityObserver.Facade
{
    public partial class HamiObserver
    {
        public static void Listen(string         type,
                                  Action<string> action,
                                  byte           delay = 0,
                                  bool           isStatic = false,
                                  bool           onlyOnce = false)
        {
            Mechanism.Ins.Listen(type, action, delay, isStatic, onlyOnce);
        }

        public static bool Fire(string type, string param = "")
        {
            return Mechanism.Ins.Fire(type, param);
        }

        public static bool NetListen(string routerName, Action<string> handler, bool isSuccess, byte delay = 0,
                                     bool   isStatic      = false,
                                     bool   isOnlyForOnce = false)
        {
            return Mechanism.Ins.Listen(
                                        isSuccess ? "Success_" + routerName : "Failure_" + routerName,
                                        handler,
                                        delay,
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

        public static bool Neglect(string type, Action<string> handler)
        {
            return Mechanism.Ins.Neglect(type, handler);
        }
        
        public static bool Neglect(string type)
        {
            return Mechanism.Ins.Neglect(type);
        }
    }
}