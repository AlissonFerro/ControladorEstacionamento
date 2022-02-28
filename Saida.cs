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
    public partial class Saida : Form
    {
        public Saida()
        {
            InitializeComponent();

            for (int i = 0; i < Inicial.quantidadeVagas; i++)
            {
                if (Inicial.GetStatus(i) == "ocupado")
                {
                    comboBox1.Items.Add((Inicial.GetNumVagas(i) + 1).ToString());
                }

            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            int id = (Convert.ToInt32(comboBox1.SelectedItem) - 1);
            Vagas.LimpaVaga(id);
            Vagas.SetValorPagar(id,Vagas.CalculaTempo(id));

            Vagas.GetValorPagar(id);

            this.Close();

        }
    }
}
