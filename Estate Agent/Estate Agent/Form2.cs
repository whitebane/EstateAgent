using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Estate_Agent
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-0RV7KDT\SQLEXPRESS;Initial Catalog=Sites;Integrated Security=True");

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Sun Site")
            {
                btnSun.BackColor = Color.LightGray;
                btnMoon.BackColor = Color.Gray;
                btnStar.BackColor = Color.Gray;
                btnEart.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Moon Site")
            {
                btnMoon.BackColor = Color.LightGray;
                btnSun.BackColor = Color.Gray;
                btnStar.BackColor = Color.Gray;
                btnEart.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Earth Site")
            {
                btnEart.BackColor = Color.LightGray;
                btnMoon.BackColor = Color.Gray;
                btnStar.BackColor = Color.Gray;
                btnSun.BackColor = Color.Gray;
            }
            if (comboBox1.Text == "Star Site")
            {
                btnStar.BackColor = Color.LightGray;
                btnMoon.BackColor = Color.Gray;
                btnSun.BackColor = Color.Gray;
                btnEart.BackColor = Color.Gray;
            }

        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";


        }
        private void View()
        {
            listView1.Items.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select*from Site", conn);
            SqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read()) 
            {
                ListViewItem item = new ListViewItem();

                item.Text = rdr["Id"].ToString();
                item.SubItems.Add(rdr["Site"].ToString());
                item.SubItems.Add(rdr["RentSale"].ToString());
                item.SubItems.Add(rdr["Room"].ToString());
                item.SubItems.Add(rdr["Meter"].ToString());
                item.SubItems.Add(rdr["Price"].ToString());
                item.SubItems.Add(rdr["Block"].ToString());
                item.SubItems.Add(rdr["No"].ToString());
                item.SubItems.Add(rdr["Name"].ToString());
                item.SubItems.Add(rdr["Phone"].ToString());
                item.SubItems.Add(rdr["Notes"].ToString());
             

                listView1.Items.Add(item);

            }

            conn.Close();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            View();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into Site (RentSale,Room,Meter,Price,Block,No,Name,Phone,Notes,Site) values('"+comboBox2.Text.ToString()+"', '"+comboBox3.Text.ToString()+"','"+textBox1.Text.ToString()+"','"+textBox2.Text.ToString()+"','"+comboBox4.Text.ToString()+"','"+textBox6.Text.ToString()+"','"+textBox4.Text.ToString()+"','"+textBox5.Text.ToString()+"','"+textBox3.Text.ToString()+"','"+comboBox1.Text.ToString()+"')",conn);
            cmd.ExecuteNonQuery();
            
            MessageBox.Show("Added!");
            Clear();
            conn.Close();
            

            View();
        }
        int id = 0;
        private void btnDlt_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Site where Id=(" + id + ")", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted..");
            Clear();

            conn.Close();

            View();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
            comboBox1.Text = (listView1.SelectedItems[0].SubItems[1].Text);
            comboBox2.Text = (listView1.SelectedItems[0].SubItems[2].Text);
            comboBox3.Text = (listView1.SelectedItems[0].SubItems[3].Text);
            textBox1.Text = (listView1.SelectedItems[0].SubItems[4].Text);
            textBox2.Text = (listView1.SelectedItems[0].SubItems[5].Text);
            comboBox4.Text = (listView1.SelectedItems[0].SubItems[6].Text);
            textBox6.Text = (listView1.SelectedItems[0].SubItems[7].Text);
            textBox4.Text = (listView1.SelectedItems[0].SubItems[8].Text);
            textBox5.Text = (listView1.SelectedItems[0].SubItems[9].Text);
            textBox3.Text = (listView1.SelectedItems[0].SubItems[10].Text);

        }

        private void btnUpdt_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Site set RentSale='" + comboBox2.Text.ToString() + "',Room='" + comboBox3.Text.ToString() + "',Meter='" + textBox1.Text.ToString() + "',Price='" + textBox2.Text.ToString() + "',Block='" + comboBox4.Text.ToString() + "',No='" + textBox6.Text.ToString() + "',Name='" + textBox4.Text.ToString() + "',Phone='" + textBox5.Text.ToString() + "',Notes='" + textBox3.Text.ToString() + "',Site='" + comboBox1.Text.ToString() + "'where Id=" + id+"",conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated");
            Clear();

            conn.Close();
            View();
        }
    }
}
