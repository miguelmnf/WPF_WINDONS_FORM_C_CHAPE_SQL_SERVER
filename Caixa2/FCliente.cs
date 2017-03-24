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

namespace Caixa2
{
    public partial class FCliente : Form
    {
        SqlConnection com = new SqlConnection("Data Source=VISIVEL-PC\\SQLSERVER2012;Initial Catalog=mnf;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;

        public FCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            c.nome = textBox2.Text;
            c.idade= textBox3.Text;
            c.cpf = textBox4.Text;
            c.parceria = textBox5.Text;
            /*
            ListViewItem item1 = new ListViewItem("Codigo:", 0);
            ListViewItem item2 = new ListViewItem(textBox1.Text, 1);
            ListViewItem item3 = new ListViewItem("Nome:", 2);
            ListViewItem item4 = new ListViewItem(textBox2.Text, 3);
            ListViewItem item5 = new ListViewItem("Idade:", 4);
            ListViewItem item6 = new ListViewItem(textBox3.Text, 5);
            ListViewItem item7 = new ListViewItem("Cpf:", 6);
            ListViewItem item8 = new ListViewItem(textBox4.Text, 7);
            ListViewItem item9 = new ListViewItem("Parceria:", 8);
            ListViewItem item10 = new ListViewItem(textBox5.Text, 9);
            // item1.SubItems.Add(textBox1.Text);

            // listView1.Columns.Add("codigo",-2,HorizontalAlignment.Left);
            listView1.Items.AddRange(new ListViewItem[] { item1 });
            listView1.Items.AddRange(new ListViewItem[] { item2 });
            listView1.Items.AddRange(new ListViewItem[] { item3 });
            listView1.Items.AddRange(new ListViewItem[] { item4 });
            listView1.Items.AddRange(new ListViewItem[] { item5 });
            listView1.Items.AddRange(new ListViewItem[] { item6 });
            listView1.Items.AddRange(new ListViewItem[] { item7 });
            listView1.Items.AddRange(new ListViewItem[] { item8 });
            listView1.Items.AddRange(new ListViewItem[] { item9 });
            listView1.Items.AddRange(new ListViewItem[] { item10 });
             */
            com.Open();
            comando.CommandText = "INSERT INTO clientes(nome,idade,cpf,parceria)VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            comando.ExecuteNonQuery();
            com.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void FCliente_Load(object sender, EventArgs e)
        {
            comando.Connection = com;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            com.Open();
            comando.CommandText = "select * from clientes";
            DataTable cli = new DataTable();
            cli.Load(dr = comando.ExecuteReader());

            dataGridView1.DataSource = cli;
            com.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "delete  from clientes where  idcliente=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "update clientes set nome = '" + textBox2.Text + "',idade = '" + textBox3.Text + "',cpf='" + textBox4.Text + "', parceria = '" + textBox5.Text + "' where  idcliente=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString(); 
           

        }
    }
}
