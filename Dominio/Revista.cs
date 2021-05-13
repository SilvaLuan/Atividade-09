using System;

namespace ClubeDaLeitura.Dominio
{
    class Revista : DominioBase
    {  
    public string tipo;
    public int edicao;
    public Caixa caixa;
    public DateTime ano;

        public Revista(int id, string tipo, int edicao, Caixa caixa, DateTime ano)
        {
            this.tipo = tipo;
            this.edicao = edicao;
            this.caixa = caixa;
            this.ano = ano;
        }

        public bool Validar(string tipo)
        {
            if (string.IsNullOrEmpty(tipo))
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
