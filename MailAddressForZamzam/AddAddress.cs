using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MailAddressForZamzam
{
    public partial class AddAddress : Form
    
    {
        //SqlConnection con = new SqlConnection("Server= kinan-PC\\kinan_server; Database= MailZamzam; Integrated Security=True;");
        SqlConnection con = new SqlConnection(" Data Source=10.10.10.100\\s2008;Initial Catalog=MailZamzam;User ID=sa;Password=zamzam@2008");
        SqlCommand cmd;
        public AddAddress()
        {
            
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are You Sure ?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    if (txtm_company.Text.Equals("") || txtm_desk_name.Text.Equals(""))
                    {
                        MessageBox.Show("الرجاء ملئ الحقول الأساسية ");
                        return;

                    }
                    else
                    {
                        cmd = new SqlCommand("insert into MailDetails (m_company,m_desk_name,m_address,m_phone,m_emp_name,m_emp_phone,m_fax_number,m_manger_name,m_speed_call)values('" + txtm_company.Text + "','" + txtm_desk_name.Text + "','" + txtm_address.Text + "','" + txtm_phone.Text + "','" + txtm_emp_name.Text + "','" + txtm_emp_phone.Text + "','" + txtm_fax_number.Text + "','" + txtm_manger_name.Text + "','" + txtm_speed_call.Text + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Success");
                        this.Close();

                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
