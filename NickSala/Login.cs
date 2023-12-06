using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NickSala
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Cpf.ToString());
                item.SubItems.Add(usuario.Senha);
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("CPF",  "Senha");
            usuario.Cpf = textBox1.Text;
            usuario.Senha = Criptografia.CriptografarSenha(textBox2.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.loginUsuario(usuario);
            UpdateListView();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void Login_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            textBox1.Text = listView1.Items[index].SubItems[0].Text;
            textBox2.Text = listView1.Items[index].SubItems[1].Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            textBox1.Text = listView1.Items[index].SubItems[0].Text;
            textBox2.Text = listView1.Items[index].SubItems[1].Text;
        }
    }
}
