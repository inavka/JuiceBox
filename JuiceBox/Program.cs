using System;
using System.Collections;
using System.Collections.Generic;

namespace JuiceBox
{
    interface IDrinkable { }
    interface ICountable { int GetCount(); }

    class Song<T, Typ> where T : IEnumerable, ICountable where Typ : IDrinkable
    {
    
        public void Sing()
        {

        }
    }
    class NoMoreBottlesException : Exception
    {
       
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            JuiceBox box = new JuiceBox(4);
            box[0] = new Juice("orange", 1.30);
            box[1] = new Juice("apple", 1.10);
            box[2] = new Juice("peach", 1.40);
            box[3] = new Juice("banana", 1.20);
            box.Sort();

            Console.ReadLine();
            //Song<JuiceBox, Juice> song = new Song<JuiceBox, Juice>(box);
            //song.Sing();
        }
    }
}
