using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickSala
{
    public class Usuario
    {

        private int _id;
        private string _nome;
        private string _cpf;
        private string _telefone;
        private string _sala;
        private string _horarioentrada;
        private string _horariosaida;
        private string _senha;
        private string _cep;
        private string _rua;
        private string _Bairro;
        private string _Numero_casa;

        public Usuario(int id,
                        string nome,
                        string cpf,
                        string telefone,
                        string sala,
                        string horarioentrada,
                        string horariosaida,
                        string senha)
        {
            _id = id;
            _nome = nome;
            _cpf = cpf;
            _telefone = telefone;
            _sala = sala;
            _horarioentrada = horarioentrada;
            _horariosaida = horariosaida;
            _senha = senha;
        }
        public Usuario(string Rua, string Bairro, string Numero, string cep)
        {
            _cep = cep;
            _rua = Rua;
            _Bairro = Bairro;
            _Numero_casa = Numero;

        }
        public Usuario(int id,string Rua, string Bairro, string Numero, string cep)
        {
            Id = id;
            _cep = cep;
            _rua = Rua;
            _Bairro = Bairro;
            _Numero_casa = Numero;

        }

        public Usuario(string nome, string CPF, string telefone, string horarioentrada, string horariosaida, string sala, string senha)
        {
            Nome = nome;
            Cpf = CPF;
            Telefone = telefone;
            Horarioentrada = horarioentrada;
            Horariosaida = horariosaida;
            Sala = sala;
            Senha = senha;
        }
        public Usuario(string CPF, string senha)
        {
            Cpf = CPF;
            Senha = senha;

        }

        public int Id
        {
            set { _id = value; }
            get { return _id; }

        }
        public string Nome
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO NOME");



                _nome = value;
            }
            get { return _nome; }

        }
        public string Cpf
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO CPF");

                _cpf = value;
            }
            get { return _cpf; }

        }
        public string Telefone
        {
            set { _telefone = value; }
            get { return _telefone; }

        }
        public string Sala
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO SALA");

                _sala = value;
            }
            get { return _sala; }

        }
        
        public string Horarioentrada
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO HORARIO DE ENTRADA");

                _horarioentrada = value;
            }
            get { return _horarioentrada; }

        }
        public string Horariosaida
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO HORARIO DE SAIDA");

                _horariosaida = value;
            }
            get { return _horariosaida; }

        }
        public string Senha
        {
            set { _senha = value; }
            get { return _senha; }

        }
        public string rua
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO rua ");

                _rua = value;
            }
            get { return _rua; }

        }
        public string Bairro
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Bairro ");

                _Bairro = value;
            }
            get { return _Bairro; }

        }
        public string Numero
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO Numero da casa ");

                _Numero_casa = value;
            }
            get { return _Numero_casa; }

        }
        public string cep
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("PREENCHA O CAMPO CEP ");

                _cep = value;
            }
            get { return _cep; }

        }


    }
}
