using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorEnergiaCibernetica.Forms
{
    public partial class LoginForm : Form
    {
        private TextBox txtUsuario;
        private TextBox txtSenha;
        private Button btnEntrar;
        private Label lblErro;

        public LoginForm()
        {
            this.Text = "Login";
            this.Width = 350;
            this.Height = 250;
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            Label lblUsuario = new Label { Text = "Usuário:", Top = 20, Left = 20, Width = 80 };
            txtUsuario = new TextBox { Top = 40, Left = 20, Width = 280 };

            Label lblSenha = new Label { Text = "Senha:", Top = 80, Left = 20, Width = 80 };
            txtSenha = new TextBox { Top = 100, Left = 20, Width = 280, UseSystemPasswordChar = true };

            btnEntrar = new Button { Text = "Entrar", Top = 150, Left = 20, Width = 100 };
            btnEntrar.Click += BtnEntrar_Click;

            lblErro = new Label { Text = "", Top = 180, Left = 20, ForeColor = System.Drawing.Color.Red, AutoSize = true };

            this.Controls.AddRange(new Control[]
            {
                lblUsuario, txtUsuario,
                lblSenha, txtSenha,
                btnEntrar, lblErro
            });
        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string senha = txtSenha.Text;

            if (usuario == "admin" && senha == "admin")
            {
                this.Hide();
                new MainForm().ShowDialog();
                this.Close();
            }
            else
            {
                lblErro.Text = "Usuário ou senha inválidos.";
            }
        }
    }
}
