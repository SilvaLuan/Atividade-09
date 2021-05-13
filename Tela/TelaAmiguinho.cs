using ClubeDaLeitura.Controle;
using System;

namespace ClubeDaLeitura.Tela
{
    class TelaAmiguinho : TelaBase, ICadastravel
    {
        ControleAmiguinho controleAmiguinho;
        public TelaAmiguinho(ControleAmiguinho controleAmiguinho)
        {
            this.controleAmiguinho = controleAmiguinho;
        }

        string tituloTela = "Amiguinho";
        public void Cadastrar()
        {
            ConfigurarTela(tituloTela, "Inserindo novo amiguinho\n"); 

            string nome, responsavel, telefone, onde;
            EntradaDeValores(out nome, out responsavel, out telefone, out onde);

            if (controleAmiguinho.Registrar(GeradorId.GerarIdAmiguinho(), nome, responsavel, telefone, onde)) 
            {
                ApresentarMensagem("Inserido com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falhou!", TipoMensagem.Erro);
                Cadastrar();
            }
            Console.ReadLine();
        }

        public static void EntradaDeValores(out string nome, out string responsavel, out string telefone, out string onde)
        {
            Console.Write("Digite o nome do amigo: ");
            nome = Console.ReadLine();

            Console.Write("Digite nome do responsavel do amigo: ");
            responsavel = Console.ReadLine();

            Console.Write("Digite telefone do amigo: ");
            telefone = Console.ReadLine();

            Console.Write("Digite da onde o amigo é: ");
            onde = Console.ReadLine();
        }

        public void Editar()
        {
            ConfigurarTela(tituloTela, "\nEditando amiguinho"); 

            Visualizar();

            Console.Write("Digite o id do amigo: ");
            int id = Convert.ToInt32( Console.ReadLine());

            if (controleAmiguinho.Editar(id))
            {
                ApresentarMensagem("Editado com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falhou!", TipoMensagem.Erro);
                Editar();
            }                   
        }

        public void Excluir()
        {
            ConfigurarTela(tituloTela, "\nExcluindo amiguinho"); 

            Visualizar();

            Console.Write("Digite o id do amigo: ");
            int id = Convert.ToInt32(Console.ReadLine());

            if (controleAmiguinho.Excluir(id)) 
            {
                ApresentarMensagem("Excluido com sucesso!", TipoMensagem.Sucesso); 
            }
            else
            {
                ApresentarMensagem("Falhou!", TipoMensagem.Erro);
                Excluir();
            }
        }

        public void Visualizar()
        {
            if (controleAmiguinho.amiguinhos.Count == 0)
            {
                ApresentarMensagem("Nada encontrado!", TipoMensagem.Alerta);
            }
            foreach (var amigo in controleAmiguinho.amiguinhos)
            {
                Console.WriteLine("id: "+ amigo.id.ToString() + " Nome: " + amigo.nome + " Responsável: " + amigo.responsavel + " Telefone:" + amigo.telefone + " Da onde é:"+ amigo.onde);
            }
            Console.ReadLine();
        }
        
        
    }
}
