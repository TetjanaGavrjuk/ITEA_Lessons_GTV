using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson4
{
    public partial class MainForm : Form
    {
        delegate void DlgNmProc(int id);

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока!");
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
