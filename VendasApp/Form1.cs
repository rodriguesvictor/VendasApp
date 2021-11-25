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
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        public Form1()
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

            /*dgvVendas.Columns["data_alteracao"].HeaderText = "Data de Alteração";
            dgvVendas.Columns["data_alteracao"].Width = 150;*/
          
            dgvVendas.Sort(dgvVendas.Columns["data_criacao"], ListSortDirection.Descending);

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dgvVendas.Rows[dgvVendas.CurrentCell.RowIndex].Cells
                ["Id"].Value);

            using(var frm = new FrmVendasCadastro(id))
            {
                frm.ShowDialog();
                dgvVendas.DataSource = Venda.GetVendas();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmVendasCadastro(0))
            {
                frm.ShowDialog();
                dgvVendas.DataSource = Venda.GetVendas();
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
            using (var frm = new FrmVendasCadastro(id, true))
            {
                frm.ShowDialog();
                dgvVendas.DataSource = Venda.GetVendas();
                ConfigurarGradeVendas();

            }
        }
    }
}
