
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PInvoke;
using System.Windows.Input;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace GeoSynapse.Utils
{
    public static class WinFormsTickle
    {
        public const int AttachParentProcess = -1;

        public static void GeoTickle(int delta)
        {
            var inp = new User32.INPUT
            {
                type = User32.InputType.INPUT_MOUSE,
                Inputs = new User32.INPUT.InputUnion
                {
                    mi = new User32.MOUSEINPUT
                    {
                        dx = delta,
                        dy = delta,
                        mouseData = 0,
                        dwFlags = User32.MOUSEEVENTF.MOUSEEVENTF_MOVE,
                        time = 0,
                        dwExtraInfo_IntPtr = IntPtr.Zero,
                    },
                },
            };

            uint returnValue = User32.SendInput(nInputs: 1, pInputs: new[] { inp, }, cbSize: Marshal.SizeOf<User32.INPUT>());

            if (returnValue != 1)
            {
                int errorCode = Marshal.GetLastWin32Error();

                Debugger.Log(level: 1,
                              category: "Geo",
                              message:
                              $"failed to insert event to input stream; retval={returnValue}, errcode=0x{errorCode:x8}\n");
            }
        }
    }

    public static class WPFTickle
    {
        public static void MoveMousePointer(int x, int y)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(x, y);
        }


        public static void GeoTickle(int delta)
        {
            System.Windows.Point currentPosition = Mouse.GetPosition(null);
            System.Windows.Point newPosition = new System.Windows.Point(currentPosition.X + delta, currentPosition.Y + delta);
            //Mouse.Move(newPosition);
        }
    }
}