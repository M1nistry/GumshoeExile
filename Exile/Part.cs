using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Exile
{
    public class Part : INotifyPropertyChanged
    {
        private int _id;
        private string _spareSerial, _spareMPN, _faultSerial, _faultMPN, _connote, _line;

        public int Id {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string SpareSerial
        {
            get
            {
                return _spareSerial;
            }
            set
            {
                _spareSerial = value;
                OnPropertyChanged("SpareSerial");
            }
        }

        public string SpareMPN
        {
            get
            {
                return _spareMPN;                
            }
            set
            {
                _spareMPN = value;
                OnPropertyChanged("SpareMPN");
            }
        }

        public string FaultSerial
        {
            get
            {
                return _faultSerial;
            }
            set
            {
                _faultSerial = value;
                OnPropertyChanged("FaultSerial");
            }
        }

        public string FaultMPN
        {
            get
            {
                return _faultMPN;
            }
            set
            {
                _faultMPN = value;
                OnPropertyChanged("FaultMPN");
            }
        }

        public string Connote
        {
            get { return _connote;}
            set
            {
                _connote = value;
                OnPropertyChanged("Connote");
            }
        }

        public string Line
        {
            get
            {
                return _line;
            }
            set
            {
                _line = value;
                OnPropertyChanged("Line");
            }
        }

        public string Header => Id <= 0 ? "+" : $"Part {Id}";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
