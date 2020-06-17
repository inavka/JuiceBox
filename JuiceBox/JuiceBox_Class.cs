using System;
using System.Collections;
using System.Collections.Generic;

namespace JuiceBox
{ 
    class JuiceBox : IEnumerable, ICountable
    {
       

        Juice first = null, last = null;

        int count = 0;
        public JuiceBox() { }
        public JuiceBox(int n = 0)
        {
            for (int i = 0; i < n; i++)
            {
                Add();
            }
        }

        public void Add()
        {
            Juice newItem = new Juice();   // 1. Neues Element anlegen
            count++;
            if (first == null)                            // 2. Leere Liste?
                first = last = newItem;
            else
            {
                last.next = newItem;               // 3. Neues Element am Ende anfügen
                last = last.next;
            }
        }

        private Juice NthElem(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Boxindex außerhalb des gültigen Bereichs");
            Juice item = first;
            while (index > 0)
            {
                item = item.next;
                index--;
            }
            return item;
        }


        public Juice this[int n]
        {
            get
            {
                return NthElem(n);
            }
            set
            {
                Juice nthBox = NthElem(n);
                nthBox.name = value.name;
                nthBox.preis = value.preis;
            }
        }
        public void Sort()
        {

            if (first == null)
                throw new ArgumentNullException("Die JuiceBox ist leer");

            
            for (Juice tmp = first; tmp != null; tmp = tmp.next)
            {
                if (tmp.CompareTo(first) < 0)
                {
                    tmp.next = first;
                    first = tmp;
                }

                //else
                //{
                //    for (Juice biggerPrice = first.next; biggerPrice != null; biggerPrice = biggerPrice.next)
                //    {
                //        if (biggerPrice.CompareTo(tmp) < 0)
                //        {
                //            biggerPrice.next = tmp.next;
                //            tmp.next = biggerPrice;
                //        }
                //    }
                //}
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (Juice tmp = first; tmp != null; tmp = tmp.next)
            {
                yield return tmp;
            }

        }

        public int GetCount() => count;
    }
}