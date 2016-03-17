using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exile.Annotations;

namespace Exile
{
    public class Tickets
    {

        public class SPLG : INotifyPropertyChanged
        {
            public bool Changed { get; set; }

            private int _id, _rtc, _system, _order, _rating;
            private string _ticket, _reference, _node, _pudo, _pdf;
            private bool _hold;
            private DateTime _dateDropoff, _dateCreated;
            private ObservableCollection<Part> _parts;
            private ObservableCollection<int> _wikis;
            private Person _owner, _ags;
            

            public SPLG()
            {

            }

            public int Id
            {
                get { return _id; }
                set
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }

            public int System
            {
                get { return _system; }
                set
                {
                    _system = value;
                    OnPropertyChanged(nameof(System));
                }
            }

            public string Ticket
            {
                get { return _ticket; }
                set
                {
                    _ticket = value; 
                    OnPropertyChanged(nameof(Ticket));
                }
            }

            public int Order
            {
                get { return _order; }
                set
                {
                    _order = value;
                    OnPropertyChanged(nameof(Order));
                }
            }

            public string Reference
            {
                get { return _reference; }
                set
                {
                    _reference = value;
                    OnPropertyChanged(nameof(Reference));
                }
            }

            public string Node
            {
                get { return _node; }
                set
                {
                    _node = value;
                    OnPropertyChanged(nameof(Node));
                }
            }

            public string Pudo
            {
                get { return _pudo; }
                set
                {
                    _pudo = value;
                    OnPropertyChanged(nameof(Pudo));
                }
            }

            public Person Ags
            {
                get { return _ags; }
                set
                {
                    _ags = value;
                    OnPropertyChanged(nameof(Ags));
                }
            }

            public DateTime DateDropOff
            {
                get { return _dateDropoff;}
                set
                {
                    _dateDropoff = value;
                    OnPropertyChanged(nameof(DateDropOff));
                }
            }

            public ObservableCollection<Part> Parts
            {
                get { return _parts;}
                set
                {
                    _parts = value;
                    OnPropertyChanged(nameof(Parts));
                }
            }

            public int RTC
            {
                get { return _rtc; }
                set
                {
                    _rtc = value;
                    OnPropertyChanged(nameof(RTC));
                }
            }

            public string PDF
            {
                get { return _pdf; }
                set
                {
                    _pdf = value;
                    OnPropertyChanged(nameof(PDF));
                }
            }

            public ObservableCollection<int> WikiIds
            {
                get { return _wikis;}
                set
                {
                    _wikis = value;
                    OnPropertyChanged(nameof(WikiIds));
                }
            }

            public bool Hold
            {
                get { return _hold; }
                set
                {
                    _hold = value;
                    OnPropertyChanged(nameof(Hold));
                }
            }

            public Person Owner
            {
                get { return _owner;}
                set
                {
                    _owner = value;
                    OnPropertyChanged(nameof(Owner));
                }
            }

            public DateTime DateTimeCreated
            {
                get { return _dateCreated;}
                set
                {
                    _dateCreated = value;
                    OnPropertyChanged(nameof(DateTimeCreated));
                }
            }

            public int Rating
            {
                get { return _rating; }
                set
                {
                    _rating = value;
                    OnPropertyChanged(nameof(Rating));
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                Changed = true;
            }
        }
    }
}
