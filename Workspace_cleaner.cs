using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Workspace_cleaner
{
    public partial class Workspace_cleaner : Form
    {
        public Workspace_cleaner()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Temporary_files.Checked == true)
            {
                Prize(Temporary_files.Checked);
                //MessageBox.Show("Это работает");
            }
        }

        public static void Prize(bool choice)
        {
            //TODO: Реадизовать del %temp% /s /f /q
            MessageBox.Show("А это?");

        }

    }
}
