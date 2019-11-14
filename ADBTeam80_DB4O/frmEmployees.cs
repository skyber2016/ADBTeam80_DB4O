using ADBTeam80_DB4O.Services;
using MidTerm2019;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADBTeam80_DB4O
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }
        public IEnumerable<object> Source { get; set; }
        private void frmEmployees_Load(object sender, EventArgs e)
        {
            //this.dgv.AutoGenerateColumns = false;
            this.dgv.DataSource = this.Source
                .ToList()
                ;
        }
    }
}
