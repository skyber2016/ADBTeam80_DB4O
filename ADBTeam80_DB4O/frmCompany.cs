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
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.txtName.Text == "")
                {
                    throw new Exception("Tên không hợp lệ!");
                }
                if(this.txtHouseNumber.Text == "")
                {
                    throw new Exception("Số nhà không hợp lệ!");
                }
                if(this.txtStreet.Text == "")
                {
                    throw new Exception("Địa chỉ không hợp lệ!");
                }
                if(this.txtCity.Text == "")
                {
                    throw new Exception("Thành phố không hợp lệ!");
                }
                var company = new Company
                {
                    CompanyID = Guid.NewGuid(),
                    CompanyName = this.txtName.Text,
                    HouseNumber = this.txtHouseNumber.Text,
                    Street = this.txtStreet.Text,
                    City = this.txtCity.Text
                };
                DatabaseService.Instance.Companies.Add(company);
                MessageBox.Show("Thêm công ty thành công!");
                this.txtName.Text = "";
                this.txtHouseNumber.Text = "";
                this.txtStreet.Text = "";
                this.txtCity.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
