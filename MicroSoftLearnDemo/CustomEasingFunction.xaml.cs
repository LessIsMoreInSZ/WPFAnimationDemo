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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MicroSoftLearnDemo
{
    /// <summary>
    /// CustomEasingFunction.xaml 的交互逻辑
    /// </summary>
    public partial class CustomEasingFunction : Window
    {
        public CustomEasingFunction()
        {
            InitializeComponent();
        }


    }

    public class CustomSeventhPowerEasingFunction : EasingFunctionBase
    {
        public CustomSeventhPowerEasingFunction()
            : base()
        {
        }

        // Specify your own logic for the easing function by overriding
        // the EaseInCore method. Note that this logic applies to the "EaseIn"
        // mode of interpolation.
        protected override double EaseInCore(double normalizedTime)
        {
            // applies the formula of time to the seventh power.
            return Math.Pow(normalizedTime, 7);
        }

        // Typical implementation of CreateInstanceCore
        protected override Freezable CreateInstanceCore()
        {

            return new CustomSeventhPowerEasingFunction();
        }
    }
}
