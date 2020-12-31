using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDT.WinApp
{
    public partial class Isolation : Form
    {
        public Isolation()
        {
            InitializeComponent();

            this.Load += OnIsolationLoad; ;
        }

        private void OnIsolationLoad(object sender, EventArgs e)
        {
            
        }
    }
}
