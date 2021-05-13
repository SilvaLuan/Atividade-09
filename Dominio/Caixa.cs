namespace ClubeDaLeitura.Dominio
{
    class Caixa : DominioBase
    {
        public string cor;
        public string etiqueta;
        public int numero;
       
        public Caixa(int id, string cor, string etiqueta, int numero)
        {
            this.id = id;
            this.cor = cor;
            this.etiqueta = etiqueta;
            this.numero = numero;
        }
        public bool Validar(string cor)
        {
            if (string.IsNullOrEmpty(cor) && cor != "azul")
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
