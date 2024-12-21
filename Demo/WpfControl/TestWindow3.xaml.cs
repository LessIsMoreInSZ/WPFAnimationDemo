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
using System.Windows.Shapes;
using WpfControl.UserControls;

namespace WpfControl
{
    /// <summary>
    /// TestWindow3.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow3 : Window
    {
        public TestWindow3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var controls = new Thermometer[8] { t1, t2 , t3, t4 , t5, t6 , t7, t8 };
            for (int i = 0; i < 8; i++) {
                controls[i].Maxmum = 100;
                controls[i].Minmum = -20;
                controls[i].Value = 10*(i+1);
            }
        }
    }
}
