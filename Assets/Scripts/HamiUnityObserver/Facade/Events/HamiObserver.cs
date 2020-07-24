using HamiUnityObserver.Core;
using HamiUnityObserver.Facade.Events;

namespace HamiUnityObserver.Facade
{
    public partial class HamiObserver
    {
        public static void OnSceneLoad(SceneName sceneName, Subscriber action, byte priority = 0, bool isStatic = false)
        {
            Mechanism.Ins.Listen($"{EventNames.__ON_SCENE_LOAD}{sceneName}", action, priority, isStatic, false);
        }

        public static void OnSceneUnload(SceneName sceneName, Subscriber action, byte priority = 0,
            bool isStatic = false)
        {
            Mechanism.Ins.Listen($"{EventNames.__ON_SCNE_UNLOAD}{sceneName}", action, priority, isStatic, false);
        }

        public static void OnAllSceneLoad(Subscriber action, byte priority = 0)
        {
            Mechanism.Ins.Listen(EventNames.__ON_EVERY_SCENE_LOAD, action, priority, true, false);
        }

        public static void OnDestroy(Subscriber action, byte priority = 0, bool isStatic = false)
        {
            Mechanism.Ins.Listen(EventNames.__ON_DESTROY, action, priority, isStatic, false);
        }

        public static void OnQuit(Subscriber action, byte priority = 0, bool isStatic = false)
        {
            Mechanism.Ins.Listen(EventNames.__ON_QUIT, action, priority, isStatic, false);
        }

        public static void OnPauseAndDestroy(Subscriber action, byte priority = 0, bool isStatic = false)
        {
            Mechanism.Ins.Listen(EventNames.__ON_PAUSE_AND_QUIT, action, priority, isStatic, false);
        }
    }
}