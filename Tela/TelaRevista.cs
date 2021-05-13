using System;
using ClubeDaLeitura.Controle;

namespace ClubeDaLeitura.Tela
{
    class TelaRevista : TelaBase
    {
        ControleRevista controleRevista;
        ControleCaixa controleCaixa;
        TelaCaixa telaCaixa;
        public TelaRevista(ControleRevista controleRevista, ControleCaixa controleCaixa, TelaCaixa telaCaixa)
        {
            this.controleRevista = controleRevista;
            this.controleCaixa = controleCaixa;
            this.telaCaixa = telaCaixa;
        }

        string tituloTela = "Revista";
        public void Cadastar()
        {
            ConfigurarTela(tituloTela, "Inserindo nova revista\n"); 

            int idCaixa, edicao;
            string tipo;
            DateTime ano;
            telaCaixa.Visualizar();
            EntradaDeValoresRevista(out idCaixa, out  tipo, out  edicao, out  ano);

            if (controleRevista.Registrar(GeradorId.GerarIdRevista(), controleCaixa.SelecionarPorId(idCaixa), tipo, edicao, ano)) 
            {
                ApresentarMensagem("Inserida com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falha ao inserir!", TipoMensagem.Erro);
                Cadastar();
            }
            Console.ReadLine();
        }

        public static void EntradaDeValoresRevista(out int id, out string tipo, out int edicao, out DateTime ano)
        {
            Console.Write("Digite o id da caixa: ");
            id = Convert.ToInt32( Console.ReadLine());
            
            Console.Write("Digite o tipo da revista: ");
            tipo = Console.ReadLine();

            Console.Write("Digite edição da revista: ");
            edicao = Convert.ToInt32( Console.ReadLine());
            
            Console.Write("Digite ano da revista: ");
            ano = Convert.ToDateTime(Console.ReadLine());
        }

        public void Editar()
        {
            ConfigurarTela(tituloTela, "\nEditando revista"); 

            Visualizar();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (controleRevista.Editar(id))
            {
                ApresentarMensagem("Editado com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falha ao editar!", TipoMensagem.Erro);
                Editar();
            }
        }

        public void Excluir()
        {
            ConfigurarTela(tituloTela, "\nExcluindo revista"); 

            Visualizar();

            Console.Write("Digite o id da revista: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (controleRevista.Excluir(id))
            {
                ApresentarMensagem("Excluida com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falha ao excluir!", TipoMensagem.Erro);
                Excluir();
            }
        }

        public void Visualizar()
        {
            if (controleRevista.revistas.Count == 0)
            {
                ApresentarMensagem("Nenhuma revista encontrada!", TipoMensagem.Alerta);
            }
            foreach (var revista in controleRevista.revistas)
            {
                Console.WriteLine("id: " + revista.id.ToString() + " Etique da caixa: " + revista.caixa.etiqueta + " Tipo da revista: " + revista.tipo + " Edição:" + revista.edicao.ToString() + " Ano: " + revista.ano.ToString());
            }
            Console.ReadLine();
        }

    }
}
