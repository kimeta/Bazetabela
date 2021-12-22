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


namespace Bazetabela
{
    public partial class Form1 : Form
    {
        public int red = 0;
        DataTable artikli = new DataTable();
        string path = "Data source=DESKTOP-685L8RG\\SQLEXPRESS; Initial catalog=Prodza; integrated security=true";

        private void refresh()
        {
            if (artikli.Rows.Count == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";

                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }

            else
            {
                textBox1.Text = Convert.ToString(artikli.Rows[red]["id"]);
                textBox2.Text = Convert.ToString(artikli.Rows[red]["naziv"]);
                textBox3.Text = Convert.ToString(artikli.Rows[red]["jedinica_mere"]);
                textBox4.Text = Convert.ToString(artikli.Rows[red]["stopapdv"]);
                textBox5.Text = Convert.ToString(artikli.Rows[red]["cena"]);
                button2.Enabled = (red != artikli.Rows.Count - 1);
                button4.Enabled = (red != artikli.Rows.Count - 1);
               button3.Enabled = (red != 0);
               button1.Enabled = (red != 0);
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection veza = new SqlConnection(path);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal order BY id", veza);
            adapter.Fill(artikli);
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            red--;
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            red = artikli.Rows.Count - 1;
            refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            red = 0;
            refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string add = "INSERT INTO Artikal (id, naziv, jedinica_mere,stopapdv,cena) VALUES (" + (artikli.Rows.Count + 1) + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            SqlConnection veza = new SqlConnection(path);
            SqlCommand naredba = new SqlCommand(add, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            red = artikli.Rows.Count - 1;
            refresh();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string del = "DELETE from Artikal where id = " + textBox1.Text;
            SqlConnection veza = new SqlConnection(path);
            SqlCommand naredba = new SqlCommand(del, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            if (red > artikli.Rows.Count - 1)
            {
                red = artikli.Rows.Count - 1;
            }
            refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string chng = "UPDATE Artikal SET id='" + textBox1.Text + "', naziv = '" + textBox2.Text + "', jedinica_mere = '" + textBox3.Text + "', stopapdv = '" + textBox4.Text + "', cena = '" + textBox5 + "')";
            SqlConnection veza = new SqlConnection(path);
            SqlCommand naredba = new SqlCommand(chng, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            refresh();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            red++;
            refresh();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            red--;
            refresh();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            red = artikli.Rows.Count - 1;
            refresh();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            red = 0;
            refresh();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string del = "DELETE from Artikal where id = " + textBox1.Text;
            SqlConnection veza = new SqlConnection(path);
            SqlCommand naredba = new SqlCommand(del, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            if (red > artikli.Rows.Count - 1)
            {
                red = artikli.Rows.Count - 1;
            }
            refresh();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string add = "INSERT INTO Artikal (id, naziv, jedinica_mere,stopapdv,cena) VALUES (" + (artikli.Rows.Count + 1) + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            SqlConnection veza = new SqlConnection(path);
            SqlCommand naredba = new SqlCommand(add, veza);
            veza.Open();
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            red = artikli.Rows.Count - 1;
            refresh();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
            SqlConnection veza = new SqlConnection(path);
          
            veza.Open();
            string chng = "UPDATE Artikal SET id='" + textBox1.Text + "', naziv = '" + textBox2.Text + "', jedinica_mere = '" + textBox3.Text + "', stopapdv = '" + textBox4.Text + "', cena = '" + textBox5 + "')";
            SqlCommand naredba = new SqlCommand(chng, veza);
            naredba.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from Artikal ORDER BY id", veza);
            artikli.Clear();
            adapter.Fill(artikli);
            refresh();
        }
    }
}
