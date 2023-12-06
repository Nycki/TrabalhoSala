using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NickSala
{
    internal class UsuarioDAO
    {
        public List<Usuario> SelectUsuario()
        {
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM SITE";

            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {

                    Usuario objeto = new Usuario(


                    (int)dr["ID"],

                    (string)dr["nome"],

                    (string)dr["CPF"],

                    (string)dr["telefone"],

                    (string)dr["sala"],

                    (string)dr["horarioentrada"],

                    (string)dr["horariosaida"],

                    (string)dr["senha"]


                    ) ;

                    usuarios.Add(objeto);

                }
                dr.Close();

                return usuarios;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }
        public void UpdateUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE SITE SET 
            nome= @nome,
            CPF= @cpf, 
            telefone= @telefone,
            sala= @sala,
            horarioentrada= @horarioentrada, 
            horariosaida= @horariosaida,
            senha= @senha
            WHERE ID=@id";

            sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@sala", usuario.Sala);
            sqlCommand.Parameters.AddWithValue("@horarioentrada", usuario.Horarioentrada);
            sqlCommand.Parameters.AddWithValue("@horariosaida", usuario.Horariosaida);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("EDITADA COM SUCESSO!",
               "AVISO",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }

        public void InsertUsuario(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO SITE VALUES (@nome, @cpf, @telefone, @sala, @horarioentrada, @horariosaida, @senha)";

            sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@cpf", usuario.Cpf);
            sqlCommand.Parameters.AddWithValue("@telefone", usuario.Telefone);
            sqlCommand.Parameters.AddWithValue("@sala", usuario.Sala);
            sqlCommand.Parameters.AddWithValue("@horarioentrada", usuario.Horarioentrada);
            sqlCommand.Parameters.AddWithValue("@horariosaida", usuario.Horariosaida);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.Senha);


            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("ALOCADA COM SUCESSO",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        public void DeletUsuario(int Id)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM SITE WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }
        public void loginUsuario(Usuario usuario)
        {
            // Conexão com o banco de dados
            Connection connect = new Connection();
            SqlConnection connection = connect.ReturnConnection();

            // Consulta SQL para verificar se o usuário existe
            string query = "SELECT ID FROM Site WHERE CPF=@CPF AND Senha=@Senha";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CPF", usuario.Cpf);
            command.Parameters.AddWithValue("@Senha", usuario.Senha);
            int userId = Convert.ToInt32(command.ExecuteScalar());

            if (userId > 0)
            {
                MessageBox.Show("Login feito com sucesso");
                principal principal = new principal(userId);
                principal.Show();
            }
            else
            {
                MessageBox.Show("Erro ao fazer login");
            }

            connect.CloseConnection();

        }
        public List<Usuario> SelectUsuario1()
        {
            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Endereco";
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)dr["id"],
                    (string)dr["Rua"],
                    (string)dr["Bairro"],
                    (string)dr["Numero"],
                    (string)dr["CEP"]
                    );
                    usuarios.Add(objeto);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na leitura dos dados\n"
                    + err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return usuarios;
        }
        public void InsertUsuario1(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO Endereco VALUES(@Rua, @Bairro, @Numero, @CEP)";

            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

        }
        public void editarUsuario1(Usuario usuario)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE Endereco SET
               Rua = @Rua,
               Bairro = @Bairro,
               Numero = @Numero,
               CEP = @CEP
               WHERE Id = @Id";
            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
            sqlCommand.Parameters.AddWithValue("@Id", usuario.Id);


            sqlCommand.ExecuteNonQuery();

        }
        public void excluirUsuario1(int Id)
        {
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM Endereco 
               WHERE Id = @Id";

            sqlCommand.Parameters.AddWithValue("@Id", Id);


            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();

            }


        }


    }
}
