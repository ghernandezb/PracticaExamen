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
            bool valido = false;
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

            //*****************************IMPRESION PREGUNTAS************************

            for (int i = 0; i < examen.Preguntas.Count; i++)
            {
                Console.WriteLine(examen.Preguntas[i].Texto);
                for (int j = 0; j < examen.Preguntas[i].Opciones.Count(); j++)
                {
                    Console.WriteLine((j + 1) + ". " + examen.Preguntas[i].Opciones[j]);
                }

                //**********************INICIO VERIFICACION DE CARACTERES********************3
                valido = false;

                while (!valido)
                {
                    string respuestaTemp = Console.ReadLine();

                    int opcion = 0;
                    valido = string.IsNullOrEmpty(respuestaTemp) || (int.TryParse(respuestaTemp, out opcion) && (VerificarNumIngresado(opcion, 1, examen.Preguntas[i].Opciones.Length)));

                    if (!valido)
                    {
                        Console.WriteLine("Respuesta incorrecta, '" + respuestaTemp + "' no es una respuesta dentro del rango, por favor ingrese un numero del 1 al " + examen.Preguntas[i].Opciones.Length + ".");
                    }
                    else
                    {
                        int z = opcion;
                        examen.Preguntas[i].OpcioneSeleccionada = (z-1);
                    }
                }                

                Console.WriteLine("");
            }

            //*******************************IMPRESION CALIFICACION**************************

            float final = examen.Calificar();

            Console.WriteLine("");
            Console.WriteLine("__________________________________________");
            Console.WriteLine("");

            if (final >= examen.NotaMinima)
            {
                Console.WriteLine("Felicidades! Su calificacion es de " + final + " puntos.");
            }
            else
            {
                Console.WriteLine("Desafortunadamente, su calificacion es de " + final + " puntos. Debera repetir el examen.");
            }

            //***************************SEGUNDA PARTE EXAMEN***************************

            Console.WriteLine("");
            Console.WriteLine("Que desea hacer?");
            Console.WriteLine("1. Revisar Respuestas");
            Console.WriteLine("2. Salir del programa");
            Console.WriteLine("");

            valido = false;

            while (!valido)
            {
                string respuestaSegundaParte = Console.ReadLine();

                int opcion = 0;
                valido = int.TryParse(respuestaSegundaParte, out opcion) && VerificarNumIngresado(opcion, 1, 2);

                if (!valido)
                {
                    Console.WriteLine("Opcion invalida, '" + respuestaSegundaParte + "' no es una opcion, por favor ingrese un numero del 1 al 2.");
                }
                else
                {
                    if (opcion == 1)
                    {
                        //********* IMPRESION PREGUNTAS Y RESPUESTAS SELECCIONADAS******
                        for (int i = 0; i < examen.Preguntas.Count; i++)
                        {
                            if (examen.Preguntas[i].OpcioneSeleccionada == -1)
                            {
                                Console.WriteLine(examen.Preguntas[i].Texto + "  [N/A]");
                            }else
                            {
                                Console.WriteLine(examen.Preguntas[i].Texto);
                            }

                            for (int j = 0; j < examen.Preguntas[i].Opciones.Count(); j++)
                            {
                                if (j == examen.Preguntas[i].OpcionCorrecta)
                                {
                                    Console.WriteLine((j + 1) + ". " + examen.Preguntas[i].Opciones[j] + " [" + Convert.ToChar(0x2713) + "]");
                                }else if(examen.Preguntas[i].OpcionCorrecta != examen.Preguntas[i].OpcioneSeleccionada && j == examen.Preguntas[i].OpcioneSeleccionada)
                                {
                                    Console.WriteLine((j + 1) + ". " + examen.Preguntas[i].Opciones[j] + " [X]");
                                }
                                else
                                {
                                    Console.WriteLine((j + 1) + ". " + examen.Preguntas[i].Opciones[j]);
                                }
                            }
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Presione cualquier tecla para finalizar.");
                        Console.ReadLine();
                    }
                }
            }
        }

        //**************************INICIALIZAR EXAMEN******************************

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
            examen.Instrucciones.Add("3. Si desconoce una respuesta presione ENTER para continuar, esta pregunta quedara sin respuesta.");
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

        //***********************FUNCIONES DE VERIFICACION******************************
        static bool VerificarNumIngresado(int datoIngresado, int numeroCompararA, int numCompararB)
        {
            return (datoIngresado >= numeroCompararA) && (datoIngresado <= numCompararB);
        }
    }

}
