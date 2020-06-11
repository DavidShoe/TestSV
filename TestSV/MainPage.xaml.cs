using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestSV
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        bool moving = false;
        Windows.Foundation.Point MouseDownLocation;

        private void OnPointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Debug.WriteLine("OnPointerPressed");
            MouseDownLocation = e.GetCurrentPoint(_AlignmentCanvas).Position;

            // No need to capture pointer
            CapturePointer(e.Pointer);

            moving = true;
        }

        private void OnPointerMoved(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if (!moving)
                return;

            Windows.Foundation.Point currentMovePoint = e.GetCurrentPoint(_AlignmentCanvas).Position;

            Windows.Foundation.Point delta;
            delta.X = currentMovePoint.X - MouseDownLocation.X;
            delta.Y = currentMovePoint.Y - MouseDownLocation.Y;

            _ScrollViewerMain.ChangeView(_ScrollViewerMain.HorizontalOffset - delta.X, _ScrollViewerMain.VerticalOffset - delta.Y, null);
        }

        private void OnPointerReleased(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Debug.WriteLine("onpointerreleased");
            moving = false;
        }
    }
}
