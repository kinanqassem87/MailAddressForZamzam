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
    public partial class UpdateAddress : Form
    {
        //SqlConnection con = new SqlConnection("Server= kinan-PC\\kinan_server; Database= MailZamzam; Integrated Security=True;");
        SqlConnection con = new SqlConnection(" Data Source=10.10.10.100\\s2008;Initial Catalog=MailZamzam;User ID=sa;Password=zamzam@2008");
        //OleDbCommand cmd;
        SqlCommand cmd;
        SqlDataAdapter da;
        
        public UpdateAddress(string x)
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            con.Open();
            //m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال'
            da = new SqlDataAdapter("select m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال' from MailDetails where m_id='"+x+"'", con);
            da.Fill(dt);
            txtm_id.Text = dt.Rows[0].ItemArray[0].ToString();
            txtm_company.Text = dt.Rows[0].ItemArray[1].ToString();
            txtm_desk_name.Text = dt.Rows[0].ItemArray[2].ToString();
            txtm_address.Text = dt.Rows[0].ItemArray[3].ToString();
            txtm_phone.Text = dt.Rows[0].ItemArray[4].ToString();
            txtm_emp_name.Text = dt.Rows[0].ItemArray[5].ToString();
            txtm_emp_phone.Text = dt.Rows[0].ItemArray[6].ToString();
            txtm_fax_number.Text = dt.Rows[0].ItemArray[7].ToString();
            txtm_manger_name.Text = dt.Rows[0].ItemArray[8].ToString();
            txtm_speed_call.Text = dt.Rows[0].ItemArray[9].ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are You Sure ?", "Warnning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    if (txtm_company.Text.Equals("") || txtm_desk_name.Text.Equals(""))
                    {
                        MessageBox.Show("الرجاء تعبئة الحقول الاساسية");
                        return;
                    }
                    else
                    {
                        con.Open();
                        cmd = new SqlCommand("update MailDetails set m_company='" + txtm_company.Text + "',m_desk_name='" + txtm_desk_name.Text + "',m_address='" + txtm_address.Text + "',m_phone='" + txtm_phone.Text + "',m_emp_name='" + txtm_emp_name.Text + "',m_emp_phone='" + txtm_emp_phone.Text + "',m_fax_number='" + txtm_fax_number.Text + "',m_manger_name='" + txtm_manger_name.Text + "',m_speed_call='" + txtm_speed_call.Text + "' where m_id='" + txtm_id.Text + "'  ", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Update Done");
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
