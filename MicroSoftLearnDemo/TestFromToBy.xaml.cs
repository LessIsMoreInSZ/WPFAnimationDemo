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
    /// TestFromToBy.xaml 的交互逻辑
    /// </summary>
    public partial class TestFromToBy : Window
    {
        Storyboard myStoryboard;
        StackPanel myPanel;
        public TestFromToBy()
        {
            InitializeComponent();
            myPanel = new StackPanel();
          

            

            
        }

        private void myRectangleLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }

        private void TestFromTo()
        {
            // Demonstrates the From and To properties used together.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());
            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "fromToAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Black;

            // Demonstrates the From and To properties used together.
            // Animates the rectangle's Width property from 50 to 300 over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "fromToAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };

            myRectangle.Loaded += new RoutedEventHandler(myRectangleLoaded);
            myPanel.Children.Add(myRectangle);
            this.Content = myPanel;
        }

        private void TestOnlyTo()
        {
            // Demonstrates the use of the To property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "toAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Gray;

            // Demonstrates the To property used by itself. Animates
            // the Rectangle's Width property from its base value
            // (100) to 300 over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.To = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "toAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };


        }

        private void TestOnlyBy()
        {
            // Demonstrates the use of the By property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "byAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.RoyalBlue;

            // Demonstrates the By property used by itself.
            // Increments the Rectangle's Width property by 300 over 10 seconds.
            // As a result, the Width property is animated from its base value
            // (100) to 400 (100 + 300) over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.By = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
        }

        private void TestFromBy()
        {
            // Demonstrates the use of the From and By properties.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "byAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.BlueViolet;

            // Demonstrates the From and By properties used together.
            // Increments the Rectangle's Width property by 300 over 10 seconds.
            // As a result, the Width property is animated from 50
            // to 350 (50 + 300) over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.By = 300;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "byAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
        }

        private void TestOnlyFrom()
        {
            // Demonstrates the use of the From property.

            // Create a NameScope for this page so that
            // Storyboards can be used.
            NameScope.SetNameScope(this, new NameScope());

            Rectangle myRectangle = new Rectangle();

            // Assign the Rectangle a name so that
            // it can be targeted by a Storyboard.
            this.RegisterName(
                "fromAnimatedRectangle", myRectangle);
            myRectangle.Height = 10;
            myRectangle.Width = 100;
            myRectangle.HorizontalAlignment = HorizontalAlignment.Left;
            myRectangle.Fill = Brushes.Purple;

            // Demonstrates the From property used by itself. Animates the
            // rectangle's Width property from 50 to its base value (100)
            // over 10 seconds.
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 50;
            myDoubleAnimation.Duration =
                new Duration(TimeSpan.FromSeconds(10));

            Storyboard.SetTargetName(myDoubleAnimation, "fromAnimatedRectangle");
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(Rectangle.WidthProperty));
            Storyboard myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);

            // Use an anonymous event handler to begin the animation
            // when the rectangle is clicked.
            myRectangle.MouseLeftButtonDown += delegate (object sender, MouseButtonEventArgs args)
            {
                myStoryboard.Begin(myRectangle);
            };
        }
    }
}
