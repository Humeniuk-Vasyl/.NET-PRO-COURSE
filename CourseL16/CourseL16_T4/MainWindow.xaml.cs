using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace CourseL16_T4
{
    public partial class MainWindow : Window
    {
        public MainWindow() =>
            InitializeComponent();

        // StopWatch використовується для збереження та виводу результату про поточний час таймера
        //DispatcherTimer використовується для підписки на подію Tick
        //(з методом T1_Tick, що власне виводить час в TimeBox) та з інтервалом в 1 мілісекунду
        Stopwatch s1;
        DispatcherTimer t1;
        private void MainWindow1_Initialized(object sender, EventArgs e)
        {
            s1 = new();
            t1 = new()
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            t1.Tick += T1_Tick;
            t1.Start();
        }
        private void T1_Tick(object sender, EventArgs e) =>
            TimeBox.Text = ((double)s1.ElapsedMilliseconds / 1000).ToString();
        // для більш-менш адекватного представлення секунд
        private void StartBtn_Click(object sender, RoutedEventArgs e) => s1.Start();

        private void StopBtn_Click(object sender, RoutedEventArgs e) => s1.Stop();

        private void ResetBtn_Click(object sender, RoutedEventArgs e) => s1.Reset();

        private void MainWindow1_Unloaded(object sender, RoutedEventArgs e) => t1.Tick -= T1_Tick;
    }
}
