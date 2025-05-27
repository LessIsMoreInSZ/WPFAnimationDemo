using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WpfControl.ViewModels
{
    public class ProgressViewModel : INotifyPropertyChanged
    {
        private double _progress;
        public double Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // 模拟进度更新
        public void StartSimulation()
        {
            var timer = new Timer(500);
            timer.Elapsed += (s, e) => Progress = (Progress + 1) % 100;
            timer.Start();
        }
    }
}
