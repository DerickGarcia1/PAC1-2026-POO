using System.Runtime.InteropServices;

using IntroduccionCSharp.Ejemplos;

Arreglos arreglo = new Arreglos(1);
bool ArregloCreado = false;
int opc;

do
{
    Console.WriteLine("\n-----Menu-----");
    Console.WriteLine("1. Crear un arreglo ");
    Console.WriteLine("2. Ingresar un valor ppara el arreglo");
    Console.WriteLine("3. Imprimir el arreglo");
    Console.WriteLine("4. Salir");
    Console.WriteLine("Ingrese su seleccion: ");

    opc = int.Parse(Console.ReadLine());

    switch (opc)
    {
        case 1:
        int tamano;
        do
        {

            Console.WriteLine("Ingrese el tamano del arreglo (Un valor positivo rey)");
            tamano = int.Parse(Console.ReadLine());

        } while (tamano <= 0);

        // al ingresar un tamano valido procedo a crear el arreglo
        arreglo = new Arreglos(tamano);
        ArregloCreado = true;
        Console.WriteLine("Arreglo creado exitosamente");
        break;

        case 2:
        if (ArregloCreado == false)
        {
            Console.WriteLine("Primero debe crear el arreglo");
        }
        else
        {
            Console.WriteLine("Ingrese el valor: ");
            int valor = int.Parse(Console.ReadLine());
            arreglo.AddValue(valor);
        }
        break;

        case 3:
        if (ArregloCreado == false)
        {
            Console.WriteLine("Primero debe crear el arreglo");
        }
        else
        {
            arreglo.Print();
        }
        break;

        case 4:
            Console.WriteLine("Abandonando el Programa......");
        break;

        default:
        Console.WriteLine("Opcion no valida");
        break;
    }    
} while (opc != 4);

// TODO: SOLO VALORES POSITIVOS
//menu
//1. crear arreglo
//2. ingresar un valor en el arreglo
//3. imprimir el arreglo
//4. salir
// hacer un do-while



