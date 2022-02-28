using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Vagas
    {
        private string placa;
        private string modelo;
        private string status;
        private DateTime horarioEntrada;
        private DateTime horarioSaida;
        private Label lblVaga;
        private int id;
        private decimal valorPagar;
        public static List<Label> labels = new List<Label>();
        private static decimal valorHora = 12M;

        public Vagas(int id, Label lblVaga)
        {
            this.id = id;
            this.lblVaga = lblVaga;
            this.status = "null";
        }

        
        internal static void LimpaVaga(int id)
        {
            Inicial.vagas[id].SetPlaca("null");
            Inicial.vagas[id].SetModelo("null");
            Inicial.vagas[id].SetStatus("null");
            Inicial.vagas[id].SetHorarioSaida(DateTime.Now);
        }

        internal static decimal CalculaTempo(int id)
        {
            DateTime entrada = Inicial.vagas[id].horarioEntrada;
            DateTime saida = Inicial.vagas[id].horarioSaida;

            var res = new TimeSpan((saida - entrada).Ticks);
            int horas = 0;
            decimal valorPagar;
            if (res.TotalSeconds<60)
            {
                valorPagar = 6;
            }
            else if (res.TotalMinutes<1)
            {
                valorPagar = 12;
            }
            else
            {
                horas = (int)res.TotalMinutes;
                valorPagar = (horas+1) * valorHora;
            }
            double min = (res.TotalSeconds - ((int)horas) * 60);

            string result = String.Format("{0,-35} {1:0} : {2:0.00}", "Tempo de permanência:", horas, 
                                                (res.TotalSeconds-((int)horas)*60));
            MessageBox.Show(result);
            MessageBox.Show(String.Format("Valor a pagar: {0:0.00}", valorPagar));

            return valorPagar;
        }

        public void SetPlaca(string placa)
        {
            this.placa = placa;
        }

        public static void SetValorPagar(int id, decimal valorPagar)
        {
            Inicial.vagas[id].valorPagar = valorPagar;
        }

        public static decimal GetValorPagar(int id)
        {
            return Inicial.vagas[id].valorPagar;
        }

        public void SetModelo(string modelo)
        {
            this.modelo = modelo;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public string GetStatus()
        {
            return this.status;
        }
        
        public int GetNumVaga()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetHorarioEntrada(DateTime horarioEntrada)
        {
            this.horarioEntrada = horarioEntrada;
        }

        public void SetHorarioSaida(DateTime horarioSaida)
        {
            this.horarioSaida = horarioSaida;
        }

        public static void CriarVagas(int quantidadeVagas)
        {

            for (int i = 0; i < quantidadeVagas; i++)
            {
                Vagas vaga = new Vagas(i, labels[i]);
                Inicial.vagas.Add(vaga);
            }
        }

        public static void SetVaga(string placa, string modelo, int id)
        {
            Inicial.vagas[id].SetPlaca(placa);
            Inicial.vagas[id].SetModelo(modelo);
            Inicial.vagas[id].SetStatus("ocupado");
            Inicial.vagas[id].SetHorarioEntrada(DateTime.Now);
        }
    }
}
