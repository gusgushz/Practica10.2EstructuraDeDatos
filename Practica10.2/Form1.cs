using Practica10._2.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica10._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Banco gus = new Banco();
        private void button1_Click(object sender, EventArgs e)
        {
            int turno = int.Parse(textBox2.Text);

            if(dataGridView1.Rows.Count > 4)
            {
                MessageBox.Show($"La cola se ha llenado.");
            }
            else
            {
                string nombre = textBox1.Text;
                string movimiento = comboBox1.Text;
                turno++;

                Cliente agregado = gus.AgregarALaCola(nombre, movimiento, turno);

                //Crea el renglon
                int n = dataGridView1.Rows.Add();
                
                dataGridView1.Rows[n].Cells[0].Value = agregado.NumTurno;
                dataGridView1.Rows[n].Cells[1].Value = agregado.Nombre;
                dataGridView1.Rows[n].Cells[2].Value = agregado.TipoDeMovimiento;
                dataGridView1.Rows[n].Cells[3].Value = agregado.Hora;
                MessageBox.Show($"Cliente formado en la cola: \n \n No.Turno: {agregado.NumTurno} \n \n Nombre: {agregado.Nombre} \n \n Tipo de movimiento: {agregado.TipoDeMovimiento} \n \n Hora de Llegada: {agregado.Llegada}","SE AGREGA UN CLIENTE AL FINAL DE LA COLA");
            }
            textBox2.Text = turno.ToString();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int turno = int.Parse(textBox2.Text);
            if (turno < 0 || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show($"La cola está vacía.");
            }
            else
            {
                int n = dataGridView1.FirstDisplayedScrollingRowIndex;
                dataGridView1.Rows.RemoveAt(n);
                Cliente borrado = gus.AtenderEnVentanilla();
                MessageBox.Show($"Cliente atendido: {borrado.Nombre} \n \n Tiempo que esperó en la cola: {borrado.TiempoQueEspero}", "TIEMPO DE ESPERA");
            }
            textBox2.Text = turno.ToString();
            textBox1.Clear();
        }
    }
}
