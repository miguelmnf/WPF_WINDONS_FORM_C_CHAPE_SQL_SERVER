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
    public partial class Form1 : Form
    {

        SqlConnection com = new SqlConnection("Data Source=VISIVEL-PC\\SQLSERVER2012;Initial Catalog=mnf;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();
            p.codigoo = textBox1.Text;
            p.data = textBox2.Text;
           // Item i = new Item();
            p.codigo = textBox3.Text;
            p.descricao= textBox4.Text;
            p.valor = textBox7.Text;

            /*
            ListViewItem item1 = new ListViewItem(textBox1.Text, 0);
            ListViewItem item2 = new ListViewItem(textBox2.Text, 1);
            ListViewItem item3 = new ListViewItem(textBox3.Text, 2);
            ListViewItem item4 = new ListViewItem(textBox4.Text, 3);
            ListViewItem item5 = new ListViewItem(textBox7.Text, 4);
           // item1.SubItems.Add(textBox1.Text);
            
           // listView1.Columns.Add("codigo",-2,HorizontalAlignment.Left);
            listView1.Items.AddRange(new ListViewItem[] { item1 });
            listView1.Items.AddRange(new ListViewItem[] { item2 });
            listView1.Items.AddRange(new ListViewItem[] { item3 });
            listView1.Items.AddRange(new ListViewItem[] { item4 });
            listView1.Items.AddRange(new ListViewItem[] { item5 });

            */
            //dataGridView1.Rows.Add(textBox1.Text);
            com.Open();
            comando.CommandText = "INSERT INTO pedidos(data,total)VALUES ('" + textBox2.Text + "','" + textBox8.Text + "')";
            comando.ExecuteNonQuery();
            com.Close();
            button14.PerformClick();

            listBox1.Items.Add("-----------------------");
            listBox1.Items.Add("data   " + textBox2.Text );
            listBox1.Items.Add("-----------------------");
            listBox1.Items.Add("total R$   " + textBox8.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
           // listView1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double preco;
            double qua;
            double geral;
            preco = Convert.ToDouble(textBox5.Text);
            qua = Convert.ToDouble(textBox6.Text);
            
            geral = preco * qua;

            textBox7.Text = geral.ToString();

            double total;

            geral = Convert.ToDouble(textBox7.Text);
            total = Convert.ToDouble(textBox8.Text);

            total = total+geral;

            textBox8.Text = total.ToString();

            label15.Text = total.ToString();

            string.Format("{0:n}", label15.Text);

            listBox1.Items.Add("descricao  " + textBox4.Text + "   valor R$ " + textBox5.Text + " quant " + textBox6.Text);
            listBox1.Items.Add(" ");
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FCliente cli = new FCliente();
            cli.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FItem i = new FItem();
            i.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
         
            int  cod;
            cod = Convert.ToInt32(textBox3.Text);
            com.Open();
            comando.CommandText = "select * from itens where  iditem="+cod;
            dr = comando.ExecuteReader();
            if(dr.HasRows){
                while(dr.Read()){
                    //comando.Parameters.Add(new SqlParameter());
                    ////.Parameters["@descricao"].Value = textBox6.Text;
                    //itensDataGridView.Add(dr [0].ToString());
                   // itensDataGridView.Add(dr[1].ToString());

                   // textBox6.Text(dr[1].ToString());
                      textBox4.Text = dr[1].ToString();
                      textBox5.Text = dr[2].ToString();

                    //listView1.Items.Add(dr[0].ToString());
                   // listView1.Items.Add(dr[1].ToString());
                }
            
            }
            com.Close();
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comando.Connection = com;
            //this.StartPosition = FormStartPosition.CenterScreen;
            button14.PerformClick();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
           textBox2.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Text = (DateTime.Now.ToString("dd/MM/yyyy"));
        }

        private void button14_Click(object sender, EventArgs e)
        {
            com.Open();
            comando.CommandText = "select * from pedidos";
            DataTable cli = new DataTable();
            cli.Load(dr = comando.ExecuteReader());

            dataGridView1.DataSource = cli;
            com.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "update pedidos set data = '" + textBox2.Text + "',total = '" + textBox8.Text + "' where  idpedido=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "delete  from pedidos where  idpedido=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
