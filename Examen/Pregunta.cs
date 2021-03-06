﻿using System;
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

        public int OpcionCorrecta { get; private set; }

        public string[] Opciones
        {
            get
            {
                return _opciones.Clone() as string[];
            }
        }

        private string[] _opciones;

        public Pregunta(string texto, int opcionCorrecta, string[] opciones)//Constructor se llama igual a la clase
        {
            Texto = texto;
            _opciones = opciones;
            if(opcionCorrecta >= 0 && opcionCorrecta < _opciones.Count())
            {
                OpcionCorrecta = opcionCorrecta;
            } else
            {
                throw new Exception("Opcion correcta no se encuentra en opciones.");
            }
        } 

        public bool Validar()
        {
            return OpcioneSeleccionada == OpcionCorrecta;
        }

    }
}
