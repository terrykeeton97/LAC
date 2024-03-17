using System;
using System.Runtime.InteropServices;

namespace LAC.Classes
{
    internal class Imports
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}