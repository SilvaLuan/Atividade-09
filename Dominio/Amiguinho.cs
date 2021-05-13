namespace ClubeDaLeitura.Dominio
{
    public class Amiguinho : DominioBase
    {
        public string nome, responsavel, telefone, onde;

        public Amiguinho(int id,string nome, string responsavel, string telefone, string onde)
        {
            this.id = id;
            this.nome = nome;
            this.responsavel = responsavel;
            this.telefone = telefone;
            this.onde = onde;
        }
        public bool Validar(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
