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
    /// Test1.xaml 的交互逻辑
    /// </summary>
    public partial class Test1 : Window
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void StoryboardC_Completed(object sender, EventArgs e)
        {
            Storyboard translationAnimationStoryboard =
    (Storyboard)this.Resources["TranslationAnimationStoryboardResource"];
            translationAnimationStoryboard.Begin(this);
        }
    }
}
