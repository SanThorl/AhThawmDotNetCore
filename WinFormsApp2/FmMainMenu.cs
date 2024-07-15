using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class FmMainMenu : Form
    {
        public FmMainMenu()
        {
            InitializeComponent();
        }

        private void newBlogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blog blog = new Blog();
            blog.ShowDialog();
            //blog.Show();
        }
    }
}
