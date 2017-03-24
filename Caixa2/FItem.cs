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
    public partial class FItem : Form
    {

        SqlConnection com = new SqlConnection("Data Source=VISIVEL-PC\\SQLSERVER2012;Initial Catalog=mnf;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;

        public FItem()
        {
            InitializeComponent();
        }


        private void FItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mnfDataSet.itens' table. You can move, or remove it, as needed.
            this.itensTableAdapter.Fill(this.mnfDataSet.itens);
            //  Conexao c = new Conexao();
            // label5.Text = c.connect();
            comando.Connection = com;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item i = new Item();
            i.codigo = textBox1.Text;
            i.descricao = textBox2.Text;
            i.valor = textBox3.Text;

            ListViewItem item1 = new ListViewItem(textBox1.Text, 0);
            ListViewItem item2 = new ListViewItem(textBox2.Text, 1);
            ListViewItem item3 = new ListViewItem(textBox3.Text, 2);
          
            //item1.SubItems.Add(textBox1.Text);
            //igorbnatalense@gmail.com
            //listView1.Columns.Add("codigo",-2,HorizontalAlignment.Left);

            //listView1.Items.AddRange(new ListViewItem[] { item1 });
            //listView1.Items.AddRange(new ListViewItem[] { item2 });
            //listView1.Items.AddRange(new ListViewItem[] { item3 });

            com.Open();
            comando.CommandText = "INSERT INTO itens(descricao,valor)VALUES ('" + textBox2.Text + "','" + textBox3.Text + "')";
            comando.ExecuteNonQuery();
           // dr = comando.ExecuteReader();
            com.Close();
           // carregar();



        }

        private void carregar() {

            com.Open();
            comando.CommandText = "select *from itens";
            dr = comando.ExecuteReader();
            if(dr.HasRows){
                while(dr.Read()){

                    //itensDataGridView.Add(dr [0].ToString());
                   // itensDataGridView.Add(dr[1].ToString());

                    //listView1.Items.Add(dr[0].ToString());
                   // listView1.Items.Add(dr[1].ToString());
                }
            
            }
            com.Close();
        
        }


        private void itensBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itensBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mnfDataSet);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            com.Open();
            comando.CommandText = "select * from itens";
            DataTable itens = new DataTable();
            itens.Load( dr = comando.ExecuteReader());

            dataGridView1.DataSource = itens;
            com.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           // textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
           // textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
          //  textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); 
   

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "update itens set descricao = '" + textBox2.Text + "',valor = '" + textBox3.Text + "'  where  iditem=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
         
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int cod;
            cod = Convert.ToInt32(textBox1.Text);
            com.Open();
            comando.CommandText = "delete  from itens where  iditem=" + cod;
            comando.ExecuteNonQuery();
            com.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
