using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// https://learn.microsoft.com/zh-cn/dotnet/desktop/wpf/graphics-multimedia/animation-overview?view=netframeworkdesktop-4.8
        /// </summary>
        private Storyboard myStoryboard;
        public MainWindow()
        {
            InitializeComponent();


            //StackPanel myPanel = new StackPanel();
            //myPanel.Margin = new Thickness(10);

            //Rectangle myRectangle = new Rectangle();
            //myRectangle.Name = "myRectangle";
            //this.RegisterName(myRectangle.Name, myRectangle);
            //myRectangle.Width = 100;
            //myRectangle.Height = 100;
            //myRectangle.Fill = Brushes.Blue;

            //DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            //myDoubleAnimation.From = 1.0;
            //myDoubleAnimation.To = 0.0;
            //myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            //myDoubleAnimation.AutoReverse = true;
            //myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            //myStoryboard = new Storyboard();
            //myStoryboard.Children.Add(myDoubleAnimation);
            //Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            //Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            //// Use the Loaded event to start the Storyboard.
            //myRectangle.Loaded += new RoutedEventHandler(myRectangleLoaded);
            //myPanel.Children.Add(myRectangle);
            //this.Content = myPanel;
        }

        private void myRectangleLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }
    }
}