using System;
using ClubeDaLeitura.Controle;
using ClubeDaLeitura.Tela;

#region
/*Para cada revista, deverá ser cadastrado: o tipo de coleção, 
 * o número da edição, o ano da revista e a caixa onde está guardada. */
#endregion

#region
/*Cada caixa tem uma cor, uma etiqueta e um número.*/
#endregion

#region
/*Para cada empréstimo cadastram-se: o amiguinho que pegou a revista,
 * qual foi a revista, a data do empréstimo e a data de devolução.*/
#endregion

#region
/*Cada criança só pode pegar uma revista por empréstimo.*/
#endregion

#region
/*O cadastro do amiguinho consiste de: nome, nome do responsável, telefone e de onde é o amigo.*/
#endregion

#region
/*Mensalmente Gustavo verifica os empréstimos realizados no mês e diariamente os empréstimos que estão em aberto.*/
#endregion

namespace ClubeDaLeitura
{   
    //Clube Da Leitura 2021
    class Program
    {
        static void Main(string[] args)
        {
            ControleAmiguinho controleAmiguinho = new ControleAmiguinho();
            ControleCaixa controleCaixa = new ControleCaixa();
            ControleRevista controleRevista = new ControleRevista(controleCaixa);

            TelaCaixa telaCaixa = new TelaCaixa(controleCaixa);
            TelaAmiguinho telaAmiguinho = new TelaAmiguinho(controleAmiguinho);
            TelaRevista telaRevista = new TelaRevista(controleRevista,controleCaixa, telaCaixa);
            
            string opcao = "";
            do
            {
                Console.Clear();
                opcao = TelaPrincipal.ObterOpcao();
                if (opcao == "1")
                {
                    Console.Clear();
                    string opcao2 = telaAmiguinho.ObterOpcaoRegistro();
                    
                    switch (opcao2)
                    {
                        case "1": telaAmiguinho.Cadastrar(); break;
                        case "2": telaAmiguinho.Visualizar(); break;
                        case "3": telaAmiguinho.Editar(); break;
                        case "4": telaAmiguinho.Excluir(); break;
                        case "S": continue;
                        
                    }
                }
                if (opcao == "2")
                {
                    Console.Clear();
                    string opcao2 = telaCaixa.ObterOpcaoRegistro();
                    switch (opcao2)
                    {
                        case "1": telaCaixa.Cadastar(); break;
                        case "2": telaCaixa.Visualizar(); break;
                        case "3": telaCaixa.Editar(); break;
                        case "4": telaCaixa.Excluir(); break;
                        case "S": continue;
                      
                    }                
                }
                if (opcao == "3")
                {
                    Console.Clear();
                    string opcao2 = telaRevista.ObterOpcaoRegistro();
                    switch (opcao2)
                    {
                        case "1": telaRevista.Cadastar(); break;
                        case "2": telaRevista.Visualizar(); break;
                        case "3": telaRevista.Editar(); break;
                        case "4": telaRevista.Excluir(); break;
                        case "S": continue;
                        
                    }
                }
            } while (!opcao.Equals("s", StringComparison.OrdinalIgnoreCase));

        }

    }
}
