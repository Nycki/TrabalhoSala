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
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace NickSala
{
    public partial class principal : Form
    {
        private int userId;
        public principal(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void principal_Load(object sender, EventArgs e)
        {
            monthCalendar1.Hide();
            panel1.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            monthCalendar1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection connect = new Connection();
            SqlConnection connection = connect.ReturnConnection();

            string query = "SELECT * FROM Site WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", userId);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            Document document = new Document();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PdfWriter.GetInstance(document, new FileStream(path + "/Relatorio.pdf", FileMode.Create));
            document.Open();
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    document.Add(new Paragraph(row[column].ToString()));
                }
            }
            document.Close();
            connect.CloseConnection();

            MessageBox.Show("Relatório gerado com sucesso!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            MessageBox.Show("Sala reservada para " + monthCalendar1.SelectionStart.ToShortDateString() + "!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            endereço endereço = new endereço();
            endereço.Show();
        }
    }
}
