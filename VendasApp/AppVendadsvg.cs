using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendasApp
{
    public partial class AppVendadsvg : Form
    {

        DataTable dt = new DataTable();
        public AppVendadsvg()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
           
            dt = Venda.GetVendas();
            dgvVendas.DataSource = dt;
            ConfigurarGradeVendas();
           
        }

        private void ConfigurarGradeVendas()
        {
            dgvVendas.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            dgvVendas.DefaultCellStyle.Font = new Font("Arial", 9);
            dgvVendas.RowHeadersWidth = 25; ;

            dgvVendas.Columns["id"].HeaderText = "ID";
            dgvVendas.Columns["id"].Visible = false;

            dgvVendas.Columns["descricao"].HeaderText = "Descrição do produto";
            dgvVendas.Columns["descricao"].Width = 450;
            dgvVendas.Columns["descricao"].DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);

            dgvVendas.Columns["unitariocompra"].HeaderText = "Valor de Compra";
            dgvVendas.Columns["unitariocompra"].Width = 100;
            dgvVendas.Columns["unitariocompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVendas.Columns["unitariocompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendas.Columns["unitariocompra"].DefaultCellStyle.Format = "N2";


            dgvVendas.Columns["unitariovenda"].HeaderText = "Valor de Venda";
            dgvVendas.Columns["unitariovenda"].Width = 100;
            dgvVendas.Columns["unitariovenda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvVendas.Columns["unitariovenda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvVendas.Columns["unitariovenda"].DefaultCellStyle.Format = "N2";

            dgvVendas.Columns["estoque_minimo"].HeaderText = "Quantidade";
            dgvVendas.Columns["estoque_minimo"].Width = 100;

            dgvVendas.Columns["data_criacao"].HeaderText = "Data de Registro";
            dgvVendas.Columns["data_criacao"].Width = 150;

        
            dgvVendas.Sort(dgvVendas.Columns["data_criacao"], ListSortDirection.Descending);

        }

         private void BtnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
                ["Id"].Value);
            var descricao = Convert.ToString(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
               ["Descricao"].Value);

            using (var frm = new FrmVendasCadastro(id, descricao))
            {
                frm.ShowDialog();
                dgvVendas.DataSource = Venda.GetVendas();
                Venda.GetDescricao(descricao);
                ConfigurarGradeVendas();

            }
        }

         private void btnAdicionar_Click(object sender, EventArgs e) 
        {
            var descricao = Convert.ToString(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
               ["Descricao"].Value);
            using (var frm = new FrmVendasCadastro(0, descricao))
            {
                frm.ShowDialog();
               dgvVendas.DataSource = Venda.GetVendas();
                Venda.GetDescricao(descricao);

                ConfigurarGradeVendas();

            }
        }

         private void dgvVendas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         private void btnBuscar_Click(object sender, EventArgs e)
        {
            dt = Venda.GetVendas(txtProcurar.Text);
            dgvVendas.DataSource = dt;
            ConfigurarGradeVendas();

        }

         private void btnExcluir_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
                ["Id"].Value);
            var descricao = Convert.ToString(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
               ["Descricao"].Value);

            using (var frm = new FrmVendasCadastro(id, descricao,  true))
            {
                frm.ShowDialog();
                dgvVendas.DataSource = Venda.GetVendas();
                Venda.GetDescricao(descricao);
                ConfigurarGradeVendas();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
