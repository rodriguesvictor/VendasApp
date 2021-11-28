using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasApp
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada para o aplicativo de Gerencia de vendas.
        /// </summary>
        /// 

        static public string sistema = "Gerencia Vendas";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AppVendadsvg());
        }
    }
}
