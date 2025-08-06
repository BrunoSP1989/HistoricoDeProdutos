using HistoricoProdutosAppComCliente;
using System;
using System.Windows.Forms;

namespace HistoricoProdutosApp
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal do aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // <- Verifique se esse nome bate com o nome da sua classe
        }
    }
}
