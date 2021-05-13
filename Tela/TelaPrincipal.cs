using System;

namespace ClubeDaLeitura.Tela
{
    public class TelaPrincipal 
    {
        public static string ObterOpcao()
        {
            Console.WriteLine("Digite 1 para o Cadastro de Amiguinho");
            Console.WriteLine("Digite 2 para o Controle de Caixa");
            Console.WriteLine("Digite 3 para o Controle de Revista");

            Console.WriteLine("Digite S para Sair");

            string opcao = Console.ReadLine();
            return opcao;
        }
    }
}
