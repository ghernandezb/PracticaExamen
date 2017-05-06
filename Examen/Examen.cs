using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Examen
    {
        //Nombre
        public string Nombre {get; private set; } //Propiedad siempre para get y set

        //Nota minima para aprobar
        public int NotaMinima { get; private set; }

        //Fecha
        public DateTime Fecha { get; private set; }

        //Instrucciones
        public List<string> Instrucciones { get; private set; } // List<tipo> Array dinamico

        public List<Pregunta> Preguntas { get; private set; } // List<tipo> Array dinamico

        public Examen(string nombre, int notaMinima) //todos los parametros empiezan con minuscula
        {
            Fecha = DateTime.Now;
            Instrucciones = new List<string>();
            Preguntas = new List<Pregunta>();
            Nombre = nombre;
            NotaMinima = notaMinima;
        }

        public float Calificar()
        {
            float puntosPorPregunta = 100/Preguntas.Count; //Variables dentro de funciones empieza en minuscula
            float resultado = 0;

            for (int i = 0; i<Preguntas.Count; i++)
            {
                if (Preguntas[i].Validar())
                {
                    resultado += puntosPorPregunta;
                }
            }
            return resultado;
        }

    }
}
