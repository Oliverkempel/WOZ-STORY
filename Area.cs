namespace WOZ_TEST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Area
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Area(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
