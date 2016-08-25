using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UHFDemo
{
    public class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public Item(string name, int value)
        {
            Name = name;
            Value = value.ToString();
        }

        public Item(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
