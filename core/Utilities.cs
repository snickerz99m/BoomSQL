using System;
using System.Windows.Forms;

namespace BoomSQL.Core
{
    public static class Utilities
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }
    }
}