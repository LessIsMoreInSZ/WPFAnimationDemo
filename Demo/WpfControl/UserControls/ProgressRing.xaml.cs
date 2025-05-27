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
    /// ProgressRing.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressRing : UserControl
    {
        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double), typeof(ProgressRing),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set => SetValue(ProgressProperty, value);
        }

        public ProgressRing()
        {
            Resources.Add("ProgressToDashArrayConverter", new ProgressToDashArrayConverter());

            InitializeComponent();
        }
    }

    // 值转换器
    public class ProgressToDashArrayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Length < 2 ||
                !(values[0] is double progress) ||
                !(values[1] is double actualWidth))
                return DependencyProperty.UnsetValue;

            progress = Math.Max(0, Math.Min(100, progress));
            var circumference = Math.PI * (actualWidth - 10); // 周长 = π*(直径)
            var dashLength = (progress / 1000) * circumference;

            return new DoubleCollection { dashLength, circumference };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
