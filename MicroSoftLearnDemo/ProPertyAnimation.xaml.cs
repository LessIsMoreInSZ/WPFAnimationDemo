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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicroSoftLearnDemo
{
    /// <summary>
    /// ProPertyAnimation.xaml 的交互逻辑
    /// </summary>
    public partial class ProPertyAnimation : Page
    {
        //故事板动画（Storyboard animations）
        //定义：
        //故事板动画是WPF中最常用的动画类型，它们是通过Storyboard类实现的。
        //故事板可以包含多个动画，这些动画可以同时针对多个属性进行。
        //使用范围：
        //故事板动画可以应用于任何依赖属性，不仅仅限于控件本地属性。
        //它们可以独立于控件存在，可以在资源字典中定义，并在多个地方重复使用。
        //控制：
        //故事板动画可以通过BeginStoryboard、StopStoryboard、PauseStoryboard和ResumeStoryboard等动作来控制。
        //可以通过事件触发器（EventTrigger）或代码背后（Code-Behind）来启动和停止动画。
        //复杂度：
        //故事板动画可以创建复杂的动画序列，包括动画的并行、顺序和组合。
        //命名空间：
        //使用故事板时，通常需要在资源字典中定义动画，并可能需要处理NameScope。
        //本地动画（Local animations）
        //定义：
        //本地动画通常指的是控件自带的动画属性，如Button的Click动画或ToolTip的弹出动画。
        //它们通常是通过控件的属性直接设置的，而不是通过Storyboard。
        //使用范围：
        //本地动画通常只限于控件自己的属性，例如Visibility、Opacity等。
        //它们通常是为了实现控件特定的行为而设计的。
        //控制：
        //本地动画的控制通常是通过控件的属性或事件来实现的。
        //它们可能没有故事板动画那样灵活的控制选项。
        //复杂度：
        //本地动画通常比较简单，只涉及单个控件的单个或几个属性。
        //命名空间：
        //本地动画不需要处理NameScope，因为它们是控件的一部分。

        ScaleTransform myScaleTransform;
        public ProPertyAnimation()
        {
            InitializeComponent();
            //LocalAnimationExample();
            AnimationClockExample();
        }

        public void LocalAnimationExample()
        {

            WindowTitle = "Local Animation Example";
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // Create and set the Button.
            Button aButton = new Button();
            aButton.Content = "A Button";

            // Animate the Button's Width.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 75;
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Apply the animation to the button's Width property.
            aButton.BeginAnimation(Button.WidthProperty, myDoubleAnimation);

            // Create and animate a Brush to set the button's Background.
            SolidColorBrush myBrush = new SolidColorBrush();
            myBrush.Color = Colors.Blue;

            ColorAnimation myColorAnimation = new ColorAnimation();
            myColorAnimation.From = Colors.Blue;
            myColorAnimation.To = Colors.Red;
            myColorAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(7000));
            myColorAnimation.AutoReverse = true;
            myColorAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Apply the animation to the brush's Color property.
            myBrush.BeginAnimation(SolidColorBrush.ColorProperty, myColorAnimation);
            aButton.Background = myBrush;

            // Add the Button to the panel.
            myStackPanel.Children.Add(aButton);
            this.Content = myStackPanel;
        }


        public void AnimationClockExample()
        {

            this.WindowTitle = "Opacity Animation Example";
            this.Background = Brushes.White;
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // Create a button that with a ScaleTransform.
            // The ScaleTransform will animate when the
            // button is clicked.
            Button myButton = new Button();
            myButton.Margin = new Thickness(50);
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.Content = "Click Me";
            myScaleTransform = new ScaleTransform(1, 1);
            myButton.RenderTransform = myScaleTransform;

            // Associate an event handler with the
            // button's Click event.
            myButton.Click += new RoutedEventHandler(myButton_Clicked);

            myStackPanel.Children.Add(myButton);
            this.Content = myStackPanel;
        }

        // Create and apply and animation when the button is clicked.
        private void myButton_Clicked(object sender, RoutedEventArgs e)
        {

            // Create a DoubleAnimation to animate the
            // ScaleTransform.
            DoubleAnimation myAnimation =
                new DoubleAnimation(
                    1, // "From" value
                    5, // "To" value
                    new Duration(TimeSpan.FromSeconds(5))
                );
            myAnimation.AutoReverse = true;

            // Create a clock the for the animation.
            AnimationClock myClock = myAnimation.CreateClock();

            // Associate the clock the ScaleX and
            // ScaleY properties of the button's
            // ScaleTransform.
            myScaleTransform.ApplyAnimationClock(
                ScaleTransform.ScaleXProperty, myClock);
            myScaleTransform.ApplyAnimationClock(
                ScaleTransform.ScaleYProperty, myClock);
        }
    }
}
