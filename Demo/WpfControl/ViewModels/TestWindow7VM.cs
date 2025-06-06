using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfControl.ViewModels
{
    public partial class TestWindow7VM : ObservableObject
    {

        private bool isStart;

        [ObservableProperty]
        private string pathSource = @"pack://application:,,,/Assets/关阀.jpg";

        [ObservableProperty]
        private WaterDirection waterDirectionWE;

        [ObservableProperty]
        private WaterDirection waterDirectionSN;

        [RelayCommand]
        private async Task Change()
        {
            isStart = !isStart;
            if (!isStart)
            {
                PathSource = @"pack://application:,,,/Assets/关阀.jpg";
                WaterDirectionWE = WaterDirection.NONE;
                WaterDirectionSN = WaterDirection.NONE;

            }
            else
            {
                PathSource = @"pack://application:,,,/Assets/开阀.jpg";
                WaterDirectionWE = WaterDirection.WE;
                WaterDirectionSN = WaterDirection.SN;
            }
        }
    }
}
