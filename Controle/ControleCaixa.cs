using ClubeDaLeitura.Dominio;
using ClubeDaLeitura.Tela;
using System.Collections.Generic;

namespace ClubeDaLeitura.Controle
{
    class ControleCaixa
    {
        public List<Caixa> caixas = new List<Caixa>();

        public bool Registrar(int id , string  cor,  string etiqueta, int numero)
        {
            Caixa caixa = new Caixa(id, cor, etiqueta, numero);
            if (caixa.Validar(cor))
            {
                caixas.Add(caixa);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool Editar(int id)
        {
            bool achou = false;
            foreach (var caixa in caixas)
            {
                if (id == caixa.id)
                {
                    string cor, etiqueta;
                    int numero;
                    TelaCaixa.EntradaDeValoresCaixa(out cor, out etiqueta, out numero);
                    
                    achou = true;
                }
            }
            return achou;
        }

        public bool Excluir(int id)
        {
            bool achou = false;
            foreach (var caixa in caixas)
            {
                if (id == caixa.id)
                {
                    caixas.Remove(caixa);
                    achou = true;
                    break;
                }
            }
            return achou;

        }
        public Caixa SelecionarPorId(int id)
        {       
            Caixa caixa1 = null;
            foreach (var caixa in caixas)
            {
                if (id == caixa.id)
                {                
                    caixa1 = caixa;
                }
            }
            return caixa1;
        }
    }
}
