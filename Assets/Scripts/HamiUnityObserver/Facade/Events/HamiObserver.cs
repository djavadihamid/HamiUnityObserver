using System;
using HamiUnityObserver.Core;
using HamiUnityObserver.Facade.Events;

namespace HamiUnityObserver.Facade
{
    public partial class HamiObserver
    {
        public static void OnSceneLoad(SceneName sceneName, Action<string> action, byte delay = 0, bool onlyOnce = true)
        {
            Mechanism.Ins.Listen($"{EventNames.__ON_SCENE_LOAD}{sceneName}", action, delay, true, onlyOnce: onlyOnce);
        }

        public static void OnSceneUnload(SceneName sceneName, Action<string> action, byte delay = 0,
                                         bool      onlyOnce = true)
        {
            Mechanism.Ins.Listen($"{EventNames.__ON_SCNE_UNLOAD}{sceneName}", action, delay, true, onlyOnce);
        }

        public static void OnAllSceneLoad(Action<string> action, byte delay = 0)
        {
            Mechanism.Ins.Listen(EventNames.__ON_EVERY_SCENE_LOAD, action, delay, true, false);
        }

        public static void OnDestroy(Action<string> action, byte delay = 0, bool onlyOnce = true)
        {
            Mechanism.Ins.Listen(EventNames.__ON_DESTROY, action, delay, true, onlyOnce: onlyOnce);
        }

        public static void OnQuit(Action<string> action, byte delay = 0, bool onlyOnce = true)
        {
            Mechanism.Ins.Listen(EventNames.__ON_QUIT, action, delay, true, onlyOnce);
        }

        public static void OnPauseAndQuit(Action<string> action, byte delay = 0, bool onlyOnce = false)
        {
            Mechanism.Ins.Listen(EventNames.__ON_PAUSE_AND_QUIT, action, delay, true, onlyOnce);
        }
    }
}