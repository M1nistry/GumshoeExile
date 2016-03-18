namespace Exile
{
    public class Location
    {
        public class Storage
        {
            public int Id { get; set; }
            public string Plant { get; set; }
            public string Sloc { get; set; }
            public string Description { get; set; }
            public string Node { get; set; }
            public bool Restricted { get; set; }
            public bool Inbound { get; set; } 
        }

        public class Kit
        {
            public int Id { get; set; }
            public string Plant { get; set; }
            public string Sloc { get; set; }
            public string Warehouse { get; set; }
            public string Description { get; set; }
            public string Node { get; set; }
        }

        public class Address
        {
            public int Id { get; set; }
            public string Plant { get; set; }
            public string Sloc { get; set; }
            public string Name { get; set; }
            public string Number { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public int PostCode { get; set; }
            public string Pudo { get; set; }
        }

        public class Consumable
        {
            public int Id { get; set; }
            public string MPN { get; set; }
            public string Description { get; set; }
            public bool Serialised { get; set; }
        }
    }
}
