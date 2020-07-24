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
                new GameObject("Destruction Notifier").AddComponent<EventNotifier>();
            };
        }


        private void OnDestroy()
        {
            Mechanism.Ins.Fire(EventNames.__ON_DESTROY);
        }

        private void OnApplicationQuit()
        {
            Mechanism.Ins.Fire(EventNames.__ON_QUIT);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Mechanism.Ins.Fire(EventNames.__ON_PAUSE_AND_QUIT); 
                
            }
        }
    }
}