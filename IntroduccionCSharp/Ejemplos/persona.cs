using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroduccionCSharp.Ejemplos
{
    public class Persona
    {
       public string Nombre { get; set; }
       public string Apellidos { get; set; }
       public string Genero { get; set; }
       public int Edad { get; set; }
    //metodo constructor
    /*
        1. Se llama igual que la clase
        2. No retorna datos
        3. Se utiliza para inicializar valores de propiedades de la clase
        4. Se ejecuta cuando se construye el objeto
        5. No se puede llamar por medio de la sintanxisd de punto
    */
       public Persona(string nombres, string apellidos, string genero, int edad)
        {
            Nombre = nombres;
            Apellidos = apellidos;
            Genero = apellidos;
            Edad = edad;
        }
                
     }
        }