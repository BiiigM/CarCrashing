using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarCrashing2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnStart_Click(object sender, EventArgs e)
        {
            Game game = new Game((int)nrHeight.Value,(int)nrWidth.Value);
            game.Show();
        }
    }
}