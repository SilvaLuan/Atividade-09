using System;
using ClubeDaLeitura.Controle;

namespace ClubeDaLeitura.Tela
{
    class TelaCaixa : TelaBase
    {
        ControleCaixa controleCaixa;
        public TelaCaixa(ControleCaixa controleCaixa)
        {
            this.controleCaixa = controleCaixa;
        }

        string tituloTela = "Caixa";
        public void Cadastar()
        {
            ConfigurarTela(tituloTela, "Inserindo nova caixa\n"); 

            string cor, etiqueta;
            int numero;
            EntradaDeValoresCaixa(out cor, out etiqueta, out numero);

            if (controleCaixa.Registrar(GeradorId.GerarIdCaixa(), cor, etiqueta, numero)) 
            {
                ApresentarMensagem("Inserido com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falha ao inserir!", TipoMensagem.Erro);
                Cadastar();
            }
            Console.ReadLine();
        }

        public static void EntradaDeValoresCaixa(out string cor, out string etiqueta, out int numero)
        {
            Console.Write("Digite o cor do caixa: ");
            cor = Console.ReadLine();

            Console.Write("Digite etiqueta do caixa: ");
            etiqueta = Console.ReadLine();

            Console.Write("Digite numero do caixa: ");
            numero = Convert.ToInt32 (Console.ReadLine());
        }

        public void Editar()
        {
            ConfigurarTela(tituloTela, "\nEditando caixa"); 

            Visualizar();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (controleCaixa.Editar(id))
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
            ConfigurarTela(tituloTela, "\nExcluindo caixa");

            Visualizar();

            Console.Write("Digite o id da caixa: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (controleCaixa.Excluir(id))
            {
                ApresentarMensagem("Excluido com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falha ao excluir!", TipoMensagem.Erro);
                Excluir();
            }
        }

        public void Visualizar()
        {
            if (controleCaixa.caixas.Count == 0)
            {
                ApresentarMensagem("Nenehuma caixa encontrada!", TipoMensagem.Alerta);
            }
            foreach (var caixa in controleCaixa.caixas)
            {
                Console.WriteLine("id: " + caixa.id.ToString() + " cor: " + caixa.cor + " Etiqueta: " + caixa.etiqueta + " Número:" + caixa.numero.ToString());
            }
            Console.ReadLine();
        }
    }
}
