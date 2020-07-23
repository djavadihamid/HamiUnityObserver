using UnityEngine;

namespace Observer
{
    internal class Logger
    {
        private static Logger _ins;
        internal bool _isLogEnabled;
        private string msg;


        public static Logger Ins
        {
            get
            {
                if (_ins == null) _ins = new Logger();
                _ins.msg = "OBSERVER SYSTEM-> ";
                return _ins;
            }
        }

        private void ListenersList()
        {
            msg += "LISTENERS LIST: \n ";

            foreach (var keyValuePair in Mechanism.Ins.Listeners)
            {
                msg += keyValuePair.Key + " : ";
                foreach (var listener in keyValuePair.Value.GetInvocationList())
                    msg += listener.Method.ReflectedType.Name + "." + listener.Method.Name + "\n";

                msg +=
                    "\n\n----------------------------\n----------------------------\n----------------------------\n\n";
            }
        }

        internal void Fire(string type, string param)
        {
            if (!_isLogEnabled) return;

            msg += "FIRE: \n ";
            msg += "Event name: " + type + "\n";
            msg += "params: " + param + "\n\n\n";
//            msg += "Caller:  " + st.GetFrame(2).GetMethod().ReflectedType.Name + "." + st.GetFrame(2).GetMethod().Name + "\n\n\n";

            ListenersList();
            
            MonoBehaviour.print(msg);
        }

        internal void Listen(string type, bool isStatic)
        {
            if (!_isLogEnabled) return;

            msg += "LISTEN: \n ";
            msg += "Event name: " + type + "\n";
            msg += "is static: " + isStatic + "\n";
//            msg += "Caller:  " + st.GetFrame(2).GetMethod().ReflectedType.Name + "." + st.GetFrame(2).GetMethod().Name + "\n\n\n";

            ListenersList();
            
            MonoBehaviour.print(msg);
        }
        
        internal void Neglect(string type, bool isStatic)
        {
            if (!_isLogEnabled) return;

            msg += "Neglect: \n ";
            msg += "Event name: " + type    + "\n";
            msg += "is static: " + isStatic + "\n";
            //            msg += "Caller:  " + st.GetFrame(2).GetMethod().ReflectedType.Name + "." + st.GetFrame(2).GetMethod().Name + "\n\n\n";

            ListenersList();
            
            MonoBehaviour.print(msg);
        }
    }
}