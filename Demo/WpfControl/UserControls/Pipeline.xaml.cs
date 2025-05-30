using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Pipeline.xaml 的交互逻辑
    /// </summary>
    public partial class Pipeline : UserControl
    {

        /// <summary>
        /// 流水方向
        /// </summary>
        public WaterDirection Direction
        {
            get { return (WaterDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Direction.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(WaterDirection), typeof(Pipeline), new PropertyMetadata(default(WaterDirection),new PropertyChangedCallback(OnDirectionChanged)));

        private static void OnDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WaterDirection value =(WaterDirection) e.NewValue;
            string strStateName = string.Empty;
            if (value == WaterDirection.WE)
                strStateName = "WEFlowState";
            else if (value == WaterDirection.EW)
                strStateName = "EWFlowState";
            else
                strStateName = "NoFlowState";
            VisualStateManager.GoToState(d as Pipeline, strStateName, false);
        }


        /// <summary>
        /// 颜色
        /// </summary>
        public Brush LiquidColor
        {
            get { return (Brush)GetValue(LiquidColorProperty); }
            set { SetValue(LiquidColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LiquidColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LiquidColorProperty =
            DependencyProperty.Register("LiquidColor", typeof(Brush), typeof(Pipeline), new PropertyMetadata(Brushes.Orange));




        public int CapRadius
        {
            get { return (int)GetValue(CapRadiusProperty); }
            set { SetValue(CapRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CapRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CapRadiusProperty =
            DependencyProperty.Register("CapRadius", typeof(int), typeof(Pipeline), new PropertyMetadata(0));



        public Pipeline()
        {
            InitializeComponent();
        }
    }
}
