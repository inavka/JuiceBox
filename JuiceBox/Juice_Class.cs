using System;
using System.Collections;
using System.Collections.Generic;

namespace JuiceBoxProgramm
{
    public class Juice : IComparable<Juice>, IDrinkable
    {
        public string name { get; private set; }
        public double preis { get; private set; }
        /// <summary>
        /// Es wird fuer den Aufruf in Song() genutzt
        /// </summary>
        /// <returns></returns>
        public override string  ToString ()
        {
            return name;
        }
        public Juice(string name, double preis)
        {
            this.name = name;
            this.preis = preis;
        }
        /// <summary>
        /// Implementierung von IComparable-Interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(Juice obj)
        {
            return preis.CompareTo(obj.preis);
        }
    }
}