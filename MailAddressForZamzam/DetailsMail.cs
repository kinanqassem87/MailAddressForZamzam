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
    public partial class DetailsMail : Form
    {
        public DetailsMail(string x)
        {
            InitializeComponent();

            //SqlConnection con = new SqlConnection("Server= kinan-PC\\kinan_server; Database= MailZamzam; Integrated Security=True;"); 
            SqlConnection con = new SqlConnection(" Data Source=10.10.10.100\\s2008;Initial Catalog=MailZamzam;User ID=sa;Password=zamzam@2008");
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            con.Open();
            da = new SqlDataAdapter("select m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال' from MailDetails where m_id='" + x + "'", con);
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
    }
}
