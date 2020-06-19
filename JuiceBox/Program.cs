using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace JuiceBoxProgramm
{
    interface IDrinkable { }
    interface ICountable { int GetCount(); }

    class Song<T, Typ> where T : IEnumerable, ICountable where Typ : IDrinkable
    {
        private T box;

        public Song(T box)
        {
            this.box = box;
        }
        /// <summary>
        /// Funktion, die das Lied generiert
        /// </summary>
        public void Sing()
        {
            try
            {
                //count bekommt die Länge des Feldes
                int count = box.GetCount();
                //Prueft ob Feld leer ist
                if (count == 0)
                    throw new NullReferenceException();
                
                //fuer jeden Juice in JuiceBox wird aufgerufen
                foreach (Typ item in box)
                {
                    //Fallunterscheidung fuer verschiedene Anzahl der Flaschen
                    if (count > 2)
                    {
                        Console.WriteLine($"{count} bottles Juice on the wall, {count} bottles of Juice.");
                        Console.WriteLine($"Take {item} down and pass it around, {--count} bottles of Juice on the wall.");

                    }
                    if (count == 2)
                    {
                        Console.WriteLine($"{count} bottles Juice on the wall, {count} bottles of Juice.");
                        Console.WriteLine($"Take {item} down and pass it around, {--count} bottle of Juice on the wall.");
                    }
                    if (count == 1)
                    {
                        Console.WriteLine($"{count} bottle Juice on the wall, {count} bottle of Juice.");
                        Console.WriteLine($"Take {item} down and pass it around, {--count} bottles of Juice on the wall.");
                    }
                    if (count == 0) //Die Wand ist leer
                        throw new NoMoreBottlesException();
                }
            }
            catch (NoMoreBottlesException) //wird aufgefangen, wenn es keine Flaschen mehr gibt
            {
                Console.WriteLine("No more bottles of Juice on the wall, no more bottles of Juice.");
            }
            catch (NullReferenceException) //wird aufgefangen, wenn es keine Flaschen von Anfang an gab
            {
                Console.WriteLine("The wall is empty");
            }
            catch (Exception) //fuer alle andere moegliche Fehler
            {
                Console.WriteLine("Ein Fehler");
            }
        }
    }
    /// <summary>
    /// Eigene Fehlerklasse
    /// </summary>
    class NoMoreBottlesException : Exception
    {
       public NoMoreBottlesException() { }
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

            Song<JuiceBox, Juice> song = new Song<JuiceBox, Juice>(box);
            song.Sing();

            Console.ReadLine();
        }
    }
}
