using System;
using HamiUnityObserver.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HamiUnityObserver.Facade.Events
{
    internal class EventNotifier : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            SceneManager.sceneLoaded += (arg1, arg2) =>
            {
                Mechanism.Ins.Fire($"{EventNames.__ON_SCENE_LOAD}{arg1.name}");
                Mechanism.Ins.Fire($"{EventNames.__ON_EVERY_SCENE_LOAD}");
                new GameObject("Destruction Notifier").AddComponent<EventNotifier>();
            };

            SceneManager.sceneUnloaded += arg0 =>
            {
                Mechanism.Ins.Fire($"{EventNames.__ON_SCNE_UNLOAD}{arg0.name}");
            };
        }


        private void OnDestroy()
        {
            Mechanism.Ins.Fire(EventNames.__ON_DESTROY);
        }

        private void OnApplicationQuit()
        {
            Mechanism.Ins.Fire(EventNames.__ON_QUIT);
            Mechanism.Ins.Fire(EventNames.__ON_PAUSE_AND_QUIT);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                Mechanism.Ins.Fire(EventNames.__ON_PAUSE_AND_QUIT);
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            
        }
    }
}