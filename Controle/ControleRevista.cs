using System;
using System.Collections.Generic;
using ClubeDaLeitura.Dominio;
using ClubeDaLeitura.Tela;

namespace ClubeDaLeitura.Controle
{
    class ControleRevista
    {
        public List<Revista> revistas = new List<Revista>();
        ControleCaixa controleCaixa;
        public ControleRevista(ControleCaixa controleCaixa){
            this.controleCaixa = controleCaixa;
        }

        public bool Registrar(int id, Caixa caixa, string tipo, int edicao,  DateTime ano)
        {
            Revista revista = new Revista(id, tipo,edicao,caixa,ano);
            if (revista.Validar(tipo))
            {
                revistas.Add(revista);
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
            foreach (var revista in revistas)
            {
                if (id == revista.id)
                {
                    int idCaixa, edicao;
                    string tipo;
                    DateTime ano;
                    TelaRevista.EntradaDeValoresRevista(out idCaixa, out tipo, out edicao, out ano);
                    revista.caixa = controleCaixa.SelecionarPorId(idCaixa);
                    revista.tipo = tipo;
                    revista.edicao = edicao;
                    revista.ano = ano;
                    achou = true;
                }
            }
            return achou;
        }

        public bool Excluir(int id)
        {
            bool achou = false;
            foreach (var revista in revistas)
            {
                if (id == revista.id)
                {
                    revistas.Remove(revista);
                    achou = true;
                    break;
                }
            }
            return achou;

        }
        public Revista SelecionarPorId(int id)
        {
            Revista revista1 = null;
            foreach (var revista in revistas)
            {
                if (id == revista.id)
                {
                    revista1 = revista;
                }
            }
            return revista1;
        }

    }
}
