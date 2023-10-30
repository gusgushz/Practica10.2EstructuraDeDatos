using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica10._2.Entities
{
    internal class Cliente
    {
        public string Nombre {  get; set; }
        public string TipoDeMovimiento { get; set; }
        public int NumTurno { get; set; }
        public DateTime Llegada { get; set; }
        public string Hora { get; set; }
        public TimeSpan TiempoQueEspero { get; set; }
        public Cliente(string nombre, string movimiento, int turno)
        {
            Nombre = nombre;
            TipoDeMovimiento = movimiento;
            NumTurno = turno;
            Llegada = DateTime.Now;
            Hora = Llegada.ToShortTimeString();
        }
    }
}
