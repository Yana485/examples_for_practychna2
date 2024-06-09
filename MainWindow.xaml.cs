using System;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace examples
{
    public partial class MainWindow : Window
    {
        private RotateTransform3D myYRotate;
        private AxisAngleRotation3D myYAxis;
        private RotateTransform3D myZRotate;
        private AxisAngleRotation3D myZAxis;
        private Transform3DGroup myTransform1;

        private RotateTransform3D myYRotate2;
        private AxisAngleRotation3D myYAxis2;
        private RotateTransform3D myZRotate2;
        private AxisAngleRotation3D myZAxis2;
        private Transform3DGroup myTransform2;

        private DispatcherTimer MyTimer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize transformations for the first object
            myYRotate = new RotateTransform3D();
            myYAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            myYRotate.Rotation = myYAxis;

            myZRotate = new RotateTransform3D();
            myZAxis = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, 1), Angle = 0 };
            myZRotate.Rotation = myZAxis;

            myTransform1 = new Transform3DGroup();
            myTransform1.Children.Add(myYRotate);
            myTransform1.Children.Add(myZRotate);
            MyModel.Transform = myTransform1;

            // Initialize transformations for the second object
            myYRotate2 = new RotateTransform3D();
            myYAxis2 = new AxisAngleRotation3D { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            myYRotate2.Rotation = myYAxis2;

            myZRotate2 = new RotateTransform3D();
            myZAxis2 = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, 1), Angle = 0 };
            myZRotate2.Rotation = myZAxis2;

            myTransform2 = new Transform3DGroup();
            myTransform2.Children.Add(myYRotate2);
            myTransform2.Children.Add(myZRotate2);
            MyModel2.Transform = myTransform2;

            // Prepare the timer
            MyTimer = new DispatcherTimer();
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 100 milliseconds
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            myYAxis.Angle += 1;
            myYAxis.Angle += 1;
            myZAxis.Angle += 1;
            myYAxis2.Angle -= 2;
            myZAxis2.Angle -= 2;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Start();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Stop();
        }
    }
}
