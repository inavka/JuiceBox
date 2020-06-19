using System;
using System.Collections;
using System.Collections.Generic;

namespace JuiceBoxProgramm
{ 
    class JuiceBox : IEnumerable, ICountable 
    {
        //Alle Saefte werden in einem Feld gespeichert
        private Juice [] data;

        public JuiceBox() { }

        /// <summary>
        /// Konstruktor um ein Box bestimmter Groesse anzulegen
        /// </summary>
        /// <param name="n">Groesse des Boxes</param>
        public JuiceBox(int n = 0)
        {
            data = new Juice[n];
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="n">Index des Elements im Feld</param>
        /// <returns></returns>
        public Juice this[int n]
        {
            get
            {
                return data[n];
            }
            set
            {
                data[n] = value;
            }
        }
        /// <summary>
        /// Sortiert die Liste absteigend
        /// </summary>
        public void Sort()
        {
            Array.Sort(data);
            Array.Reverse(data);
        }
        /// <summary>
        /// IEnumerator ist fuer foreach-Schleife in Song() 
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i<data.Length; i++)
            {
                yield return data[i];
            }
        }
        /// <summary>
        /// Implementierung von ICountable-Interface
        /// </summary>
        /// <returns></returns>
        public int GetCount() => data.Length;
    }
}