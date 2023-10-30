using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica10._2.Entities
{
    internal class Banco
    {
        string[] movimiento = new string[] { "Pago de Servicio", "Depósito", "Retiro", "Compra de tiempo-aire", "Consulta de saldo" };
        public Queue<Cliente> Clientes = new Queue<Cliente>();

        public Cliente AgregarALaCola(string nombre, string movimiento, int turno)
        {
            if(!ColaLlena())
            {
                Cliente nuevo = new Cliente(nombre, movimiento, turno);
                Clientes.Enqueue(nuevo); //Debe mandar mensaje con los datos del cliente agregado.
                return nuevo;
            } 
            else //Como si esta llena, solo manda cual es el último en la lista.
            {
                Cliente ultimoCliente = Clientes.Peek();
                return ultimoCliente;
            }
        }
        bool ColaLlena()
        {
            if(Clientes.Count < 6)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Cliente AtenderEnVentanilla()
        {
            if (ColaVacia() == false)
            {
                Cliente Borrado = Clientes.Dequeue();
                Borrado.TiempoQueEspero = CalcularTiempoEspera(Borrado);

                return Borrado;
            }
            else
            {
                return null; //No hace nada, manda mensaje de que no hay clietes en la cola para borrar
            }            
        }
        bool ColaVacia()
        {
            if (Clientes.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        TimeSpan CalcularTiempoEspera(Cliente borrado) //Calcula cuanto tiempo esperó una persona en la fila
        {
            TimeSpan Espera;
            if (borrado != null)
            {
                Espera = DateTime.Now - borrado.Llegada;
            }
            else
            {
                Espera = DateTime.Now - DateTime.Now;
            }
            return Espera;
        }
    }
}
