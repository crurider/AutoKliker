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
            if (bounds.Width == 0 && bounds.Height == 0) {
                result = new Bitmap(800, 600);
            }
            else {
                result = new Bitmap(bounds.Width, bounds.Height);
            }
            using (var graphics = Graphics.FromImage(result)) {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            return result;
        }
    }
}
