using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFNavigationDemo
{
    /// <summary>
    /// Interaction logic for PageA.xaml
    /// </summary>
    public partial class PageA : Page
    {
        DispatcherTimer timer;
        TimeSpan timeSpan;

        public PageA()
        {
            InitializeComponent();
            SetUp();
        }
        private void SetUp()
        {
            Counter();
            PlayerName.Text = MainWindow.player.Name;
        }

        private void Counter()
        {
            //DispatchTimer example by kmatyaszek (https://stackoverflow.com/users/1410998/kmatyaszek)
            timeSpan = TimeSpan.FromSeconds(5);

            timer = new DispatcherTimer(
                new TimeSpan(0, 0, 1),
                DispatcherPriority.Normal,
                delegate
                {
                    if (timeSpan == TimeSpan.Zero)
                    {
                        timer.Stop();
                        this.NavigationService.Navigate(new Uri("PageB.xaml", UriKind.Relative));
                    }
                    timeSpan = timeSpan.Add(TimeSpan.FromSeconds(-1));
                },
                Application.Current.Dispatcher);

            timer.Start();
        }
    }
}
