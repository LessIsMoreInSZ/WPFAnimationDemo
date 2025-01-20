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

namespace WpfControl
{
    /// <summary>
    /// TestWindow6.xaml 的交互逻辑
    /// </summary>
    public partial class TestWindow6 : Window
    {
        private Storyboard openStoryboard;
        private Storyboard closeStoryboard;
        private DoubleAnimation openAnimation;
        private DoubleAnimation closeAnimation;
        public TestWindow6()
        {
            InitializeComponent();
            AddAnimation();

        }

        private void AddAnimation()
        {
            // Open
            openAnimation = new DoubleAnimation();
            openAnimation.From = -90;
            openAnimation.To = 0;
            openAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            openAnimation.FillBehavior = FillBehavior.HoldEnd;
            //openAnimation.AutoReverse = true;
            //openAnimation.RepeatBehavior = RepeatBehavior.Forever;

            openStoryboard = new Storyboard();
            openStoryboard.Children.Add(openAnimation);
            Storyboard.SetTargetName(openAnimation, "RodRT");
            Storyboard.SetTargetProperty(openAnimation, new PropertyPath(TranslateTransform.XProperty));

            // Close 
            closeAnimation = new DoubleAnimation();
            closeAnimation.From = 0;
            closeAnimation.To = -90;
            closeAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            closeAnimation.FillBehavior = FillBehavior.HoldEnd;

            closeStoryboard = new Storyboard();
            closeStoryboard.Children.Add(closeAnimation);
            Storyboard.SetTargetName(closeAnimation, "RodRT");
            Storyboard.SetTargetProperty(closeAnimation, new PropertyPath(TranslateTransform.XProperty));
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            openStoryboard.Begin(this);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            closeStoryboard.Begin(this);
        }

        private void PlaySpecificAnimation(string animationName)
        {
            // 获取Storyboard
            Storyboard myStoryboard = (Storyboard)this.Resources["myStoryboard"];

            // 查找并播放特定的动画
            Timeline specificAnimation = myStoryboard.Children.FirstOrDefault(a => a.Name == animationName);
            if (specificAnimation != null)
            {
                myStoryboard.Begin();
            }
        }
    }
}
