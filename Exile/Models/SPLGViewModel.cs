using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace Exile.Models
{
    class SPLGViewModel
    {

        public ObservableCollection<Part> PartList { get; set; }
        public Tickets.SPLG CurrentTicket { get; set; }
        public ObservableCollection<Person> _persons { get; set; }
        public ObservableCollection<Location.Storage> LocationCollection { get; set; } 

        public SPLGViewModel()
        {
            PartList = new ObservableCollection<Part>();
            _persons = new ObservableCollection<Person>();
            PartList.Add(new Part
            {
                Id = 0
            });
            _persons.Add(new Person
            {
                Id = 1,
                Name = "Beau Palmer-Brame",
                Ags = "D717586",
                Email = "bcpalm@au1.ibm.com",
                Mobile = "0413372256"
            });

            _persons.Add(new Person
            {
                Id = 2,
                Name = "Colby J Jansen",
                Ags = "D711337",
                Email = "cljansen@au1.ibm.com",
                Mobile = "041111111"
            });

            PartList.Insert(PartList.Count - 1, new Part
            {
                Id = PartList.Count,
                SpareSerial = "spareSerial",
                SpareMPN = "spareMPN",
                FaultSerial = "faultSerial",
                FaultMPN = "faultMPN",
                Connote = "CONNOTE",
                Line = "0040",
            });
            PartList.Insert(PartList.Count - 1, new Part
            {
                Id = PartList.Count,
                SpareSerial = "1",
                SpareMPN = "2",
                FaultSerial = "3",
                FaultMPN = "4"
            });
            CurrentTicket = new Tickets.SPLG
            {
                Id = 1,
                System = 1,
                Ticket = "TAS00000213133",
                Order = 1271219,
                Reference = "INC0000188821",
                Node = "BRAA",
                Pudo = "MKBR",
                Ags = _persons[0],
                DateDropOff = new DateTime(2016, 01, 23),
                Parts = PartList,
                RTC = 101922,
                PDF = "1271219.pdf",
                WikiIds = new ObservableCollection<int>
                {
                    1, 2,3
                },
                Rating = 3,
                Owner = new Person()
            };

            LocationCollection = new ObservableCollection<Location.Storage>();
            LocationCollection.Add(new Location.Storage
            {
                Plant = "FC01",
                Sloc = "C001",
                Description = "PUDO - ESPK",
                Node = "ESPK",
                Restricted = false,
                Inbound = true
            });

        }
    }

    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var rating = (int)value;
            return rating >= int.Parse(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(parameter.ToString());
        }
    }
}
