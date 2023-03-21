using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoKliker {
    internal class ScreenCapture {
        public static Bitmap result;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [StructLayout(LayoutKind.Sequential)]
        private struct Rect {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowRect(IntPtr hwnd, ref Rect rect);

        // Screenshot aktivnog prozora
        public static Bitmap CaptureActiveWindow() {
            return CaptureWindow(GetForegroundWindow());
        }

        // Screenshot ekrana
        public static Bitmap CaptureWindow(IntPtr handle) {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            if (bounds.Size.IsEmpty) {
                result = new Bitmap(20, 20);
            }
            else {
                result = new Bitmap(bounds.Width, bounds.Height);
            }
            var graphics = Graphics.FromImage(result);
            if (bounds.Size.IsEmpty) {
                graphics.CopyFromScreen(new Point(0, 0), Point.Empty, new Size(0, 0));
            }
            else {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            
            return result;
        }
    }
}
