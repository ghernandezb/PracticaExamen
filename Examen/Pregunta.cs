using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen
{
    class Pregunta
    {
        public string Texto { get; private set; }

        public int OpcioneSeleccionada { get; set; }

        public string[] Opciones
        {
            get
            {
                return _opciones.Clone() as string[];
            }
        }

        private int _opcionCorrecta; //Guion bajo cuando es variable privada

        private string[] _opciones;

        public Pregunta(string texto, int opcionCorrecta, string[] opciones)//Constructor se llama igual a la clase
        {
            Texto = texto;
            _opciones = opciones;
            if(opcionCorrecta >= 0 && opcionCorrecta < _opciones.Count())
            {
                _opcionCorrecta = opcionCorrecta;
            } else
            {
                throw new Exception("Opcion correcta no se encuentra en opciones.");
            }
        } 

        public bool Validar()
        {
            return OpcioneSeleccionada == _opcionCorrecta;
        }

    }
}
