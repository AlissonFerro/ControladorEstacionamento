using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Entrada : Form
    {
        public Entrada()
        {
            InitializeComponent();

            for (int i = 0; i < Inicial.quantidadeVagas; i++)
            {
                if (Inicial.GetStatus(i) == "null")
                {
                    comboBox1.Items.Add((Inicial.GetNumVagas(i)+1).ToString());
                }

            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            
            int idVaga = (Convert.ToInt32(comboBox1.SelectedItem)-1);
            string modelo = txtModelo.Text;
            string placa = txtPlaca.Text;

            //MessageBox.Show(idVaga.ToString());

            Vagas.SetVaga(placa, modelo, idVaga);
            this.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
