using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Program
    {
        static void Main(string[] args)
        {
            Examen examen = InicializarElExamen();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Fecha: " + examen.Fecha);
            Console.WriteLine("Nombre del alumno: " + examen.Nombre);
            Console.WriteLine("");

            for (int i = 0; i < examen.Instrucciones.Count; i++)
            {
                Console.WriteLine(examen.Instrucciones[i]);
            }

            Console.WriteLine("");

            //IMPRESION PREGUNTAS
            for (int i = 0; i < examen.Preguntas.Count; i++)
            {
                Console.WriteLine(examen.Preguntas[i].Texto);
                for (int j = 0; j < examen.Preguntas[i].Opciones.Count(); j++)
                {
                    Console.WriteLine((j + 1) + ". " + examen.Preguntas[i].Opciones[j]);
                }

                // INICIO VERIFICACION CARACTERES (1-4)
                bool valido = false;

                while (!valido)
                {
                    string respuestaTemp = Console.ReadLine();

                    valido = (VerificarSiCambiaNum(respuestaTemp)) && (VerificarNumIngresado(respuestaTemp, 1, 4));

                    if (!valido)
                    {
                        Console.WriteLine("Respuesta incorrecta, '" + respuestaTemp + "' no es una respuesta dentro del rango, por favor ingrese un numero del 1 al 4.");
                        //Console.ReadLine();
                    }
                    else
                    {
                        int z = int.Parse(respuestaTemp);
                        examen.Preguntas[i].OpcioneSeleccionada = (z-1);
                    }
                }                

                Console.WriteLine("");
            } // FIN for (int i = 0; i < examen.Preguntas.Count; i++)

            //INICIO CALIFICACION

            float final = examen.Calificar();


            if (final >= examen.NotaMinima)
            {
                Console.WriteLine("");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("");
                Console.WriteLine("Felicidades! Su calificacion es de " + final + " puntos.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("__________________________________________");
                Console.WriteLine("");
                Console.WriteLine("Desafortunadamente, su calificacion es de " + final + " puntos. Debera repetir el examen.");
            }
            Console.WriteLine("");
            Console.WriteLine("Presione Cualquier tecla para finalizar.");
            Console.ReadLine();
        }

        static Examen InicializarElExamen()
        {
            Console.WriteLine("Escriba su nombre:");
            string nombre = Console.ReadLine();
            Examen examen = new Examen(nombre, 70);

            //Crear instrucciones
            examen.Instrucciones.Add("INSTRUCCIONES");
            examen.Instrucciones.Add("");
            examen.Instrucciones.Add("1. Mandese valiente.");
            examen.Instrucciones.Add("2. Lea todas las instrucciones.");
            examen.Instrucciones.Add("3. Si desconoce una respuesta digite cualquiera.");
            examen.Instrucciones.Add("");
            examen.Instrucciones.Add("________________________________________________");
            examen.Instrucciones.Add("");

            //Crear Preguntas
            examen.Preguntas.Add(new Pregunta("Quien es George W. Bush?", 2, new string[] { "Un Tennista", "Un Surfeador", "Un Expresidente", "Un Mago Oscuro" }));
            examen.Preguntas.Add(new Pregunta("Quien es Margaret Tatcher?", 0, new string[] { "Una Ex Primer Ministra", "Una Administradora", "Una Cientifica", "Una Maga Oscura" }));
            examen.Preguntas.Add(new Pregunta("Quien es usted?", 1, new string[] { "George W. Bush", nombre, "Margaret Tatcher", "Un Mago Oscuro" }));
            examen.Preguntas.Add(new Pregunta("Hasta donde se lava la cara un calvo?", 0, new string[] { "Donde desee", "Hasta la nuca", "Hasta arriba de las cejas", "Hasta donde diga el Mago Oscuro" }));
            examen.Preguntas.Add(new Pregunta("Que sucederia si Pinocho dijera: 'Ahora mi nariz crecera'?", 3, new string[] { "El universo implosiona", "Muere un gato", "Este programa se cae", "Solo el Mago Oscuro lo sabe" }));
            return examen;
        }

        bool VerificarSiCambiaNum(string datoIngresado)
        {
            //Esta funcion se encargara de verificar si lo ingresado por
            //el usuario puede transformarse en un numero entero
            return Int32.TryParse(datoIngresado, out int x);
        }

        bool VerificarNumIngresado(string datoIngresado, int numeroCompararA, int numCompararB)
        {
            //Esta funcion se encargara de verificar el numero ingresado por
            //el usuario y la longitud del mismo
            int x = Int32.Parse(datoIngresado);
            return (x >= numeroCompararA) && (x <= numCompararB);
        }
    }

}
