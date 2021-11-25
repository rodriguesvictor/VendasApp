using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasApp
{
    static class Conn
    {
        private const string servidor = "localhost";
        private const string bancoDados = "vendas";
        private const string usuario = "root";
        private const string senha = "1069";

        static public string strConn = $"server ={servidor}; User Id = {usuario}; database={bancoDados}; password={senha}; convert zero datetime=True;";

        /*convert zero datetime=True*/
    }
}
