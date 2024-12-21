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

namespace WpfControl.UserControls
{
    /// <summary>
    /// CoolingPie.xaml 的交互逻辑
    /// </summary>
    public partial class CoolingPie : UserControl
    {

        public int CenterX
        {
            get { return (int)GetValue(CenterXProperty); }
            set { SetValue(CenterXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterXProperty =
            DependencyProperty.Register("CenterX", typeof(int), typeof(CoolingPie), new PropertyMetadata(0));


        public int CenterY
        {
            get { return (int)GetValue(CenterYProperty); }
            set { SetValue(CenterYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CenterYProperty =
            DependencyProperty.Register("CenterY", typeof(int), typeof(CoolingPie), new PropertyMetadata(0));


        public CoolingPie()
        {
            InitializeComponent();
        }
    }
}
