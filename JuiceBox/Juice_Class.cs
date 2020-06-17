using System;
using System.Collections;
using System.Collections.Generic;

namespace JuiceBox
{
    public class Juice : IComparable<Juice>, IDrinkable
    {
        public string name { get; set; }
        public double preis { get; set; }
        public Juice next;
        public Juice()
        {
            name = "neuBox";
        }
        public Juice(string name, double preis)
        {
            this.name = name;
            this.preis = preis;
        }
        public int CompareTo(Juice obj)
        {
            return preis.CompareTo(obj.preis);
        }
    }
}