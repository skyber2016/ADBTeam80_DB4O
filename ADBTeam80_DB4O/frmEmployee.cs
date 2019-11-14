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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.cmbCompany.DataSource = DatabaseService.Instance.GetCompanies;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.cmbCompany.SelectedValue == null)
                {
                    throw new Exception("Chưa chọn công ty!");
                }
                var salary = Convert.ToDouble(this.txtSalary.Text);
                
                if (string.IsNullOrWhiteSpace(this.txtFullName.Text) || this.txtFullName.Text == "")
                {
                    throw new Exception("Tên không hợp lệ!");
                }
                if (salary < 300)
                {
                    throw new Exception("Lương nhân viên phải từ 300USD trở lên");
                }
                
                var employee = new Employee
                {
                    FullName = this.txtFullName.Text,
                    ID = Guid.NewGuid(),
                    Salary = salary,
                    Manager = null,
                    Skill = this.txtSkill.Text,
                    HomeBase = (Company)this.cmbCompany.SelectedValue
                };
                DatabaseService.Instance.Insert(employee);
                MessageBox.Show("Thêm nhân viên thành công!");
                this.txtFullName.Text = "";
                this.txtSalary.Text = "0";
                this.txtFullName.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
