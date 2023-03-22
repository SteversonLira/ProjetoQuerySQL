using Projeto_QuerySQL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Projeto_QuerySQL
{
    public partial class frmExecultar : Form
    {
        private DataSet ds;
        private SqlDataAdapter da;
        private Task task;

        public frmExecultar()
        {
            ds = new DataSet();
            InitializeComponent();
        }

        private void btIncluir_Click(object sender, EventArgs e)
        {
            
            string texto = txtParametro.Text;
            if(texto != "@" && texto != "")
                if(!listBoxParametros.Items.Contains(texto))
                    listBoxParametros.Items.Add(texto);
                    txtParametro.Text = "@";
                    txtParametro.Focus();
        }

        private void frmExecultar_Load(object sender, EventArgs e)
        {
            txtParametro.Text = "@";
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (listBoxParametros.SelectedItem != null)
                listBoxParametros.Items.Remove(listBoxParametros.SelectedItem);
        }

        private void btExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtComandoSQL.Text != "")
                {
                    listView1.Clear();
                    ds.Reset();
                    PreencherDataSet();
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                else
                {
                    MessageBox.Show("Insira a instrução SQL!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtComandoSQL.Focus();
                }
            }
            catch (Exception)
            {
                listView1.Clear();
                ds.Reset();
                throw;
            }
        }
        private void PreencherDataSet()
        {
            try
            {
                this.da = new SqlDataAdapter(txtComandoSQL.Text, Conexao.ConexaoBancoDados());

                if(listBoxParametros.Items.Count > 0)
                {
                    int totalParametros = listBoxParametros.Items.Count;
                    for (int i = 0; i < listBoxParametros.Items.Count; i++)
                    {
                        if(listBoxParametros.Items[i].ToString() == "@Bairro")
                        {
                            da.SelectCommand.Parameters.Add(new SqlParameter(listBoxParametros.Items[i].ToString(), "%SAO%"));
                        }
                        else
                        {
                            da.SelectCommand.Parameters.Add(new SqlParameter(listBoxParametros.Items[i].ToString(), "1"));
                        }
                        

                    }
                }
                
                da.Fill(this.ds);
                Preenchimento();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na instrução do SQL: \n" + ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Preenchimento()
        {
            try
            {
                this.listView1.Columns.Clear();
                this.listView1.Items.Clear();

                foreach (DataColumn c in ds.Tables[0].Columns)
                {
                    // Inclui nome nas colunas como colunas ListView
                    ColumnHeader h = new ColumnHeader();
                    h.Text = c.ColumnName;
                    h.Width = Convert.ToInt32(100);
                    this.listView1.Columns.Add(h);
                }

                DataTable dt = ds.Tables[0];
                string[] str = new string[this.ds.Tables[0].Columns.Count + 1];

                int TotalRegistro = dt.Rows.Count;
                int contador = 1;

                foreach (DataRow rr in dt.Rows)
                {
                    for (int col = 0; col <= this.ds.Tables[0].Columns.Count - 1; col++)
                    {
                        str[col] = rr[col].ToString().Trim();
                    }
                    ListViewItem ii = new ListViewItem(str);
                    this.listView1.Items.Add(ii);

                    contador++;
                }
            }
            catch (Exception ex)
            {

                this.listView1.Clear();
                MessageBox.Show("Erro no preenchimento: \n" + ex.Message, ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream stream = File.OpenWrite(@"C:\Users\TID-STEVERSON\Desktop\Projetos C#\Projeto QuerySQL\sql-server 32x32.ico"))
            {
                Bitmap bitmap = (Bitmap)Image.FromFile(@"C:\Users\TID-STEVERSON\Desktop\Projetos C#\Projeto QuerySQL\sql-server 32x32.png");
                Icon.FromHandle(bitmap.GetHicon()).Save(stream);
            }
        }
    }
}
