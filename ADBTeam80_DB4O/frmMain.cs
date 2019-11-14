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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new frmCompany();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            var form = new frmEmployee();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new frmEmployees();
            form.Source = DatabaseService.Instance.Get<Employee>()
                .Select(x => {
                    return new
                    {
                        x.FullName,
                        x.Skill,
                        x.Salary,
                        Company = x.HomeBase?.CompanyName
                    };
                });
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var company = new List<Company>();
            var companyHaveEmployees = new List<Company>();
            this.Hide();
            var form = new frmEmployees();
            form.Text = "Danh sách các công ty có số lượng viên > 2 và có tổng lương(Salary) phải trả một tháng lớn hơn 1000USD";
            var employee = DatabaseService.Instance.Get<Employee>();
            employee.ToList().ForEach(item =>
            {
                if(!company.Any(x=>x.CompanyID == item.HomeBase?.CompanyID))
                {
                    company.Add(item.HomeBase);
                }
                else
                {
                    if (!companyHaveEmployees.Any(x => x.CompanyID == item.HomeBase?.CompanyID) && item.Salary > 1000)
                    {
                        companyHaveEmployees.Add(item.HomeBase);
                    }
                }
            });
            form.Source = companyHaveEmployees.Select(x=> new {
                x.CompanyName,
                x.HouseNumber,
                x.Street,
                x.City
            });
            form.ShowDialog();
            this.Show();
        }
    }
}
