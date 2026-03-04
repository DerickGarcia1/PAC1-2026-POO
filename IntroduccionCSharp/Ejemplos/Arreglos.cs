using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroduccionCSharp.Ejemplos
{
    public class Arreglos
    {
        public int[] Numbers { get; set; }
        public int CurrentPosition { get; set; }
        public Arreglos(int tamano)
        {
            Numbers = new int[tamano];
            CurrentPosition = 0;
        }

        public bool AddValue(int number)
        {
            if (CurrentPosition < Numbers.Length)
            {

            Numbers[CurrentPosition] = number;
            CurrentPosition++;
            return true;

            }

            else
            {

             return false;   

            }
        }

        public void Print()
        {
            if (CurrentPosition == 0)
            {
                Console.WriteLine("El arreglo esta vacio. ");
                return;
            }

            for (int i = 0; i < CurrentPosition; i++)
            {
                Console.WriteLine(i + " - " + Numbers[i]);
            }
        }
    }
}