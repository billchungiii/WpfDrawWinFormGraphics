using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfDrawWinFormGraphics
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isNeedChange;

        public bool IsNeedChange
        {
            get { return _isNeedChange; }
            set
            {
                if (_isNeedChange != value)
                {
                    _isNeedChange = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsNeedChange)));
                    if (_isNeedChange)
                    {

                        using (var myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green))
                        {
                            using (var formGraphics = WinPanel.CreateGraphics())
                            {
                                formGraphics.Clear(System.Drawing.Color.White);
                                formGraphics.FillEllipse(myBrush, new System.Drawing.Rectangle(0, 0, 50, 50));
                            }
                        }
                    }
                    else
                    {
                        using (var myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.BlueViolet))
                        {
                            using (var formGraphics = WinPanel.CreateGraphics())
                            {
                                formGraphics.Clear(System.Drawing.Color.White);
                                formGraphics.FillEllipse(myBrush, new System.Drawing.Rectangle(0, 0, 200, 300));
                            }
                        }
                    }

                }
            }
        }

        public System.Windows.Forms.Panel WinPanel
        {
            get; set;
        }

        private ICommand _command;
        public ICommand Command
        {
            get
            {
                _command = _command ?? new RelayCommand((x) => IsNeedChange = !IsNeedChange);
                return _command;
            }
        }


    }
}
