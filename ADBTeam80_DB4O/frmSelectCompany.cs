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
    public partial class frmSelectCompany : Form
    {
        public frmSelectCompany()
        {
            InitializeComponent();
        }
        private void ChangeData(object sender, EventArgs e)
        {
            var form = new frmEmployees();
            var employee = DatabaseService.Instance.Get<Employee>();
        }
        private void frmSelectCompany_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = DatabaseService.Instance.Companies;
        }
    }
}
