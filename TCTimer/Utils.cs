using System;
using System.Windows.Forms;

namespace TCTimer
{
    public static class Utils
    {
        public static void RunAction(Form caller, Action action)
        {
            if (caller.InvokeRequired)
            {
                caller.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}