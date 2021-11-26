﻿using System;
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
    public partial class FrmVendasCadastro : Form
    {
        int id;
        bool excluir = false;


        Venda venda = new Venda();

        public FrmVendasCadastro(int id, bool excluir = false)
        {
            InitializeComponent();
            this.id = id;
            this.excluir = excluir;



            if (this.id > 0) {
                venda.GetVenda(this.id);
                lblId.Text = venda.Id.ToString();
                txtDescricao.Text = venda.Descricao;
                txtUnitariocompra.Text = venda.Unitariocompra.ToString("N2");
                txtUnitariovenda.Text = venda.Unitariovenda.ToString("N2");
                txtEstoque_minimo.Text = venda.Estoque_minimo.ToString();


                if (venda.Ativo == 'S')
                    chkAtivo.Checked = true;

            }
            if (this.excluir) {
                TravarControles();
                btnSalvar.Visible = false;
                btnExcluir.Visible = true;
            }


        }

        private void TravarControles()
        {
            txtDescricao.Enabled = false;
            txtUnitariocompra.Enabled = false;
            txtUnitariovenda.Enabled = false;
            txtEstoque_minimo.Enabled = false;
            chkAtivo.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarForm())
            {
                venda.Descricao = txtDescricao.Text;
                venda.Unitariocompra = Convert.ToDecimal("0" + txtUnitariocompra.Text);
                venda.Unitariovenda = Convert.ToDecimal("0" + txtUnitariovenda.Text);
                venda.Estoque_minimo = Convert.ToInt32("0" + txtEstoque_minimo.Text);


                if (chkAtivo.Checked == true)
                    venda.Ativo = 'S';
                else
                    venda.Ativo = 'N';

                venda.SalvarVenda();

            }
        }
        private bool ValidarForm() {
            venda.Descricao = txtDescricao.Text;
            if (txtDescricao.Text == "")
            {
                MessageBox.Show("Digite a Descrição.", Program.sistema);
                txtDescricao.Focus();
                return false;
            }

            else if (txtDescricao.Text.Equals(venda.Descricao))
            {
                MessageBox.Show("Descrição já cadastrada", Program.sistema);
                txtDescricao.Focus();
                this.Close();
                return false;
            }


            else if (Convert.ToDecimal("0" + txtUnitariocompra.Text) == 0)
            {
                MessageBox.Show("Informe o preço de compra.", Program.sistema);
                txtUnitariocompra.Focus();
                return false;
            }
            else if (Convert.ToDecimal("0" + txtUnitariovenda.Text) == 0)
            {
                MessageBox.Show("Informe o preço de Venda.", Program.sistema);
                txtUnitariovenda.Focus();
                return false;
            }
            else
                return true;
        }
    

        private void FrmVendasCadastro_Load(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            venda.Excluir();
            this.Close();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

