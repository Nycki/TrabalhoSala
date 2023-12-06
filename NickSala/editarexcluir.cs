using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NickSala
{
    public partial class editarexcluir : Form
    {
        public editarexcluir()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            tabela.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.Nome);
                item.SubItems.Add(usuario.Cpf);
                item.SubItems.Add(usuario.Telefone);
                item.SubItems.Add(usuario.Sala);
                item.SubItems.Add(usuario.Horarioentrada);
                item.SubItems.Add(usuario.Horariosaida);
                item.SubItems.Add(usuario.Senha);

                tabela.Items.Add(item);
            }
        }

        private void EDITAR_Click(object sender, EventArgs e)
        {
            try
            {
                string telefone = textBox4.Text;
                string cpf = maskedTextBox1.Text;
                if (new CPFValidator().IsValid(cpf) && new Validador().ValidarTelefone(telefone))
                {
                    MessageBox.Show("CPF válido!");
                    MessageBox.Show("Telefone válido!");


                    Usuario usuario = new Usuario("nome", "cpf", "telefone", "horarioentrada", "horariosaida", "sala", "senha");
                    usuario.Nome = textBox1.Text;
                    usuario.Cpf = maskedTextBox1.Text;
                    usuario.Telefone = textBox4.Text;
                    usuario.Sala = maskedTextBox2.Text;
                    usuario.Horarioentrada = textBox6.Text;
                    usuario.Horariosaida = textBox7.Text;
                    usuario.Senha = Criptografia.CriptografarSenha(textBox8.Text);
                    usuario.Id = int.Parse(IDbox.Text);


                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    usuarioDAO.UpdateUsuario(usuario);
                    UpdateListView();
                }
                else
                {
                    MessageBox.Show("CPF inválido ou Telefone inválido");

                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void editarexcluir_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(IDbox.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeletUsuario(id);
            UpdateListView();
        }

        private void tabela_DoubleClick(object sender, EventArgs e)
        {
            int index;
            index = tabela.FocusedItem.Index;
            IDbox.Text = tabela.Items[index].SubItems[0].Text;
            textBox1.Text = tabela.Items[index].SubItems[1].Text;
            maskedTextBox1.Text = tabela.Items[index].SubItems[2].Text;
            textBox4.Text = tabela.Items[index].SubItems[3].Text;
            maskedTextBox2.Text = tabela.Items[index].SubItems[4].Text;
            textBox6.Text = tabela.Items[index].SubItems[5].Text;
            textBox7.Text = tabela.Items[index].SubItems[6].Text;
            textBox8.Text = tabela.Items[index].SubItems[7].Text;
        }

        private void tabela_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
