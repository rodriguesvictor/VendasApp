using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasApp
{
    class Venda
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Unitariocompra { get; set; }

        public decimal Unitariovenda { get; set; }

        public int Estoque_minimo { get; set; }

        public char Ativo { get; set; }

        public DateTime Data_criacao { get; set; }

       /* public DateTime Data_alteracao { get; set; }*/

        public void GetVenda(int id) {
            var sql = "SELECT * FROM vendas WHERE id=" + id;

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    this.Id = Convert.ToInt32(dr["id"]);
                                    this.Descricao = dr["descricao"].ToString();
                                    this.Unitariocompra = Convert.ToDecimal(dr["unitariocompra"]);
                                    this.Unitariovenda = Convert.ToDecimal(dr["unitariovenda"]);
                                    this.Estoque_minimo = Convert.ToInt32(dr["estoque_minimo"]);
                                    this.Ativo = Convert.ToChar(dr["ativo"]);                                   

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                    }
        }

        public void SalvarVenda()
        {
            var sql = "";

            if (this.Id == 0)
                sql = "INSERT INTO vendas (descricao, unitariocompra, unitariovenda, estoque_minimo, ativo) VALUES (@descricao, @unitariocompra, @unitariovenda, @estoque_minimo, @ativo)";
            else
             
                sql = "UPDATE vendas SET descricao=@descricao, unitariocompra=@unitariocompra, unitariovenda=@unitariovenda, estoque_minimo=@estoque_minimo, ativo=@ativo, data_criacao=CURRENT_TIMESTAMP WHERE id=" + this.Id;

            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@descricao", this.Descricao);
                        cmd.Parameters.AddWithValue("@unitariocompra", this.Unitariocompra);
                        cmd.Parameters.AddWithValue("@unitariovenda", this.Unitariovenda);
                        cmd.Parameters.AddWithValue("@estoque_minimo", this.Estoque_minimo);
                        cmd.Parameters.AddWithValue("@ativo", this.Ativo);
                        cmd.Parameters.AddWithValue("@data_criacao", this.Data_criacao);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        internal static void GetDescricao()
        {
            throw new NotImplementedException();
        }

        public static DataTable GetVendas(string procurar = "")
        {
            var dt = new DataTable();

            var sql = "SELECT id, descricao, unitariocompra, unitariovenda, estoque_minimo, data_criacao FROM vendas.vendas ";

            if (procurar != "")
                sql += "WHERE descricao LIKE '%" + procurar + "%'";
           
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var da = new MySqlDataAdapter(sql, cn))
                    {

                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }

        public void Excluir() {
            var sql = "DELETE FROM vendas WHERE id=" + this.Id;
            try
            {
                using (var cn = new MySqlConnection(Conn.strConn))
                {
                    cn.Open();
                    using (var cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
