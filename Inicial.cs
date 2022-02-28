using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Inicial : Form
    {
        public static int quantidadeVagas = 10;
        internal static List<Vagas> vagas = new List<Vagas>();

        public Inicial()
        {
            InitializeComponent();
            Vagas.CriarVagas(quantidadeVagas);


        }

        private void BtnEntrada_Click(object sender, EventArgs e)
        {
            Entrada entrada = new Entrada();
            entrada.Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnSaida_Click(object sender, EventArgs e)
        {
            Saida saida = new Saida();
            saida.Show();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                if(vagas[i].GetStatus() != "null")
                {
                    Vagas.labels[i].ForeColor = Color.Red;
                }
                else if (vagas[i].GetNumVaga()==0 || vagas[i].GetNumVaga()==1)
                {
                    Vagas.labels[i].ForeColor = Color.Blue;
                }
                else
                {
                    Vagas.labels[i].ForeColor = Color.Green;
                }
            }
        }

        public static int GetNumVagas(int i)
        {
            return vagas[i].GetNumVaga();
        }
        public static string GetStatus(int i)
        {
            return vagas[i].GetStatus();
        }

    }
}
