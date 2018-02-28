using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace MailAddressForZamzam
{
    public partial class Form1 : Form

    {
        //public static string con = " Data Source=10.10.10.100\\s2008;Initial Catalog=MailZamzam;User ID=sa;Password=zamzam@2008";
        // OleDbConnection con = new OleDbConnection( @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\acctest.accdb;Persist Security Info=False;");
       // SqlConnection con = new SqlConnection("Server= kinan-pc\\kinan_server; Database= MailZamzam; Integrated Security=True;");
        SqlConnection con = new SqlConnection(" Data Source=10.10.10.100\\s2008;Initial Catalog=MailZamzam;User ID=sa;Password=zamzam@2008");
        //OleDbCommand cmd;
        SqlCommand cmd;
        SqlDataAdapter da;
        
        public Form1()
        {
            InitializeComponent();

            display();
   
        }
        private  void display()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                //m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال'
                da = new SqlDataAdapter("select m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال' from MailDetails", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("نأكد من اتصالاك بالخادم");
            }
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAddress ad = new AddAddress();
            ad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                da = new SqlDataAdapter("select m_id as 'رقم المعرف',m_company as 'مديرية البريد',m_desk_name as 'اسم المكتب',m_address as 'العنوان',m_phone as 'رقم الهاتف',m_emp_name as 'اسم القائم بالخدمة',m_emp_phone as 'رقم الموبايل',m_fax_number as 'رقم فاكس الخدمة',m_manger_name as 'المدير المشرف',m_speed_call as 'رقم الاتصال' from MailDetails where (m_company+m_desk_name+m_address+m_emp_name+m_manger_name) like '%" + txtSearch.Text + "%' ", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("نأكد من اتصالاك بالخادم");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateAddress ud = new UpdateAddress(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ud.ShowDialog();
            }
            catch (Exception ex)
            {
                return;
            }
           
        }

        private void btmDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure IF You Want To Delete This Item ?", "Warnning", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("delete from MailDetails where m_id ='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Done");
                    display();
                }
                catch(Exception ex)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DetailsMail dm = new DetailsMail(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                dm.ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("الرجاء تحديد عنوان ");
            }
        }
    }
}
