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

namespace APP_Farmacia_Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            // Validar los campos
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("El nombre del medicamento no puede estar vacío.");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de medicamento.");
                return;
            }

            if (!int.TryParse(textBox2.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.");
                return;
            }

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Debe seleccionar un distribuidor.");
                return;
            }

            if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Debe seleccionar al menos una sucursal.");
                return;
            }

            // Crear el resumen del pedido
            string distribuidor = radioButton1.Checked ? "Cofarma" : radioButton2.Checked ? "Empsephar" : "Cemefar";
            string direccion = checkBox1.Checked ? "Calle de la Rosa n. 28" : "";
            if (checkBox2.Checked)
            {
                direccion += (checkBox1.Checked ? " y para la situada en " : "") + "Calle Alcazabilla n. 3";
            }

            string resumen = $"Pedido al distribuidor {distribuidor}\n" +
                             $"{cantidad} unidades del {comboBox1.SelectedItem} {textBox1.Text}\n" +
                             $"Para la farmacia situada en {direccion}";

            // Mostrar el resumen
            MessageBox.Show(resumen, "Resumen del pedido");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Borrar todos los campos
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
    }
}
