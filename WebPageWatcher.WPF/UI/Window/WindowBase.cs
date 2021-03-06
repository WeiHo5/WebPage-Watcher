﻿using MaterialDesignExtensions.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Globalization;

namespace WebPageWatcher.UI
{
    public class WindowBase : MaterialWindow, INotifyPropertyChanged
    {
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteObject([In] IntPtr hObject);
        public WindowBase()
        {
            DataContext = this;
            if (icon == null)
            {
                icon = ImageSourceFromBitmap(Properties.Resources.app_png);
            }
            TitleBarIcon = icon;
            SetResourceReference(BackgroundProperty, "MaterialDesignPaper");
            SetResourceReference(TextElement.ForegroundProperty, "MaterialDesignBody");
        }
        private static ImageSource icon;

        public event PropertyChangedEventHandler PropertyChanged;

        public static ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();

            return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

        }
        public bool IsClosed { get; private set; }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsClosed = true;
        }

        public void BringToFront()
        {
            if (!IsVisible)
            {
                Show();
            }

            if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }

            Activate();
            Topmost = true;  // important
            Topmost = false; // important
            Focus();
        }

    }

}
