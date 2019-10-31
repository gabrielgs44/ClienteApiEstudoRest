using ClienteApi.Models.Exceptions;

namespace ClienteApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        protected Cliente(int id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public static Cliente Criar(int id, string nome, string login, string senha)
        {
            var cliente = new Cliente(id, nome, login, senha);
            cliente.Validar();
            return cliente;
        }

        private void Validar()
        {
            if (Nome == null)
            {
                throw new AtributoInvalidoException("Nome não pode ser nulo!");
            }

            if (Login == null)
            {
                throw new AtributoInvalidoException("Login não pode ser nulo!");
            }

            if (Senha == null || Senha.Length <= 3)
            {
                throw new AtributoInvalidoException("Senha inválida");
            }
        }
    }
}
