using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControl.UserControls
{
    /// <summary>
    /// Thermometer.xaml 的交互逻辑
    /// </summary>
    public partial class Thermometer : UserControl
    {
        public int Minmum
        {
            get { return (int)GetValue(MinmumProperty); }
            set { SetValue(MinmumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minmum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinmumProperty =
            DependencyProperty.Register("Minmum", typeof(int), typeof(Thermometer), new PropertyMetadata(1, new PropertyChangedCallback(OnPropertyValueChanged)));



        public int Maxmum
        {
            get { return (int)GetValue(MaxmumProperty); }
            set { SetValue(MaxmumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Maxmum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxmumProperty =
            DependencyProperty.Register("Maxmum", typeof(int), typeof(Thermometer), new PropertyMetadata(10, new PropertyChangedCallback(OnPropertyValueChanged)));



        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value);}
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(Thermometer), new PropertyMetadata(0.0, new PropertyChangedCallback(OnPropertyValueChanged)));

        /// <summary>
        /// 当属性值发生变化的时候直接更新UI内容
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPropertyValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as Thermometer)?.RefreshComponet();
        }

        private double step = 10;

        public Thermometer()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        /// <summary>
        /// 刷新温度计上面的内容适应定义大小
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void RefreshComponet()
        {
            // 两种方式触发：尺寸变化、区间变化
            var h = this.MainCanvas.ActualHeight;//通过这个判断界面元素是否加载
            if (h == 0) return;
            double w = 75;
            // 类型
            double stepCount = Maxmum - Minmum;// 在这个区间内多少个间隔
            step = h / (Maxmum - Minmum);// 每个间隔距离

            this.MainCanvas.Children.Clear();

            for (int i = 0; i <= stepCount; i++)
            {
                Line line = new Line();
                line.Y1 = i * step;
                line.Y2 = i * step;
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 1;
                this.MainCanvas.Children.Add(line);

                if (i % 10 == 0)
                {
                    line.X1 = 15;
                    line.X2 = w - 15;

                    // 添加文字
                    TextBlock text = new TextBlock
                    {
                        Text = (Maxmum - i).ToString(),
                        Width = 20,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 9,
                        Margin = new Thickness(0, -5, -4, 0)
                    };
                    Canvas.SetLeft(text, w - 15);
                    Canvas.SetTop(text, i * step);
                    this.MainCanvas.Children.Add(text);

                    // 添加文字
                    text = new TextBlock
                    {
                        Text = (Maxmum - i).ToString(),
                        Width = 20,
                        TextAlignment = TextAlignment.Center,
                        FontSize = 9,
                        Margin = new Thickness(-4, -5, 0, 0)
                    };
                    Canvas.SetLeft(text, 0);
                    Canvas.SetTop(text, i * step);
                    this.MainCanvas.Children.Add(text);
                }
                else if (i % 5 == 0)
                {
                    line.X1 = 20;
                    line.X2 = w - 20;
                }
                else
                {
                    line.X1 = 25;
                    line.X2 = w - 25;
                }
            }
            ValueChanged();
        }


        private void ValueChanged() {
            // 限定值的变化范围 
            var value = this.Value;
            if (this.Value < this.Minmum)
                value = this.Minmum;
            if (this.Value > this.Maxmum)
                value = this.Maxmum;

            // 温度值与Border的高度的一个转换
            var newValue = value - this.Minmum;
            newValue *= step;
            newValue += 20;

            // 动画
            DoubleAnimation doubleAnimation = new DoubleAnimation(newValue, TimeSpan.FromMilliseconds(500));
            this.BorValue.BeginAnimation(HeightProperty, doubleAnimation);
        }

    }

}
