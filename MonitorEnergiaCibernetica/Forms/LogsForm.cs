using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorEnergiaCibernetica.Services;

namespace MonitorEnergiaCibernetica.Forms
{
    public partial class LogsForm : Form
    {
        private ListBox listLogs;

        public LogsForm()
        {
            this.Text = "Logs do Sistema";
            this.Width = 600;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;

            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            listLogs = new ListBox
            {
                Top = 20,
                Left = 20,
                Width = 540,
                Height = 300,
                Font = new System.Drawing.Font("Consolas", 10)
            };

            this.Controls.Add(listLogs);
            this.Load += LogsForm_Load;
        }

        private void LogsForm_Load(object sender, EventArgs e)
        {
            var linhas = LogService.LerLogs();
            listLogs.Items.Clear();
            listLogs.Items.AddRange(linhas);
        }
    }
}
