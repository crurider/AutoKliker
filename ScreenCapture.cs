using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AutoKliker {
    internal class ScreenCapture {
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

        // Screenshot celog ekrana
        public static Bitmap CaptureFullScreen() {
            var bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            var result = new Bitmap(bounds.Width, bounds.Height);
            using (var graphics = Graphics.FromImage(result)) {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return result;
        }

        // Screenshot ekrana
        public static Bitmap CaptureWindow(IntPtr handle) {
            var rect = new Rect();
            GetWindowRect(handle, ref rect);
            var bounds = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            if (bounds.Size.IsEmpty) {
                return new Bitmap(20, 20);
            }

            var result = new Bitmap(bounds.Width, bounds.Height);
            using (var graphics = Graphics.FromImage(result)) {
                graphics.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
            }
            return result;
        }
    }
}
