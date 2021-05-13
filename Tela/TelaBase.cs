using System;

namespace ClubeDaLeitura.Tela
{
    abstract class TelaBase
    {
        public string ObterOpcaoRegistro()
        {
            Console.WriteLine("Digite 1 para inserir novo registro");
            Console.WriteLine("Digite 2 para visualizar registro");
            Console.WriteLine("Digite 3 para editar um registro");
            Console.WriteLine("Digite 4 para excluir um registro");

            Console.WriteLine("Digite S para sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        protected void ConfigurarTela(string tituloTela,string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(tituloTela); 

            Console.WriteLine(subtitulo); 
        }
        protected void ApresentarMensagem(string mensagem, TipoMensagem tipo)
        {
            switch (tipo)
            {
                case TipoMensagem.Sucesso: Console.ForegroundColor = ConsoleColor.Green; break;
                case TipoMensagem.Erro: Console.ForegroundColor = ConsoleColor.Red; break;
                case TipoMensagem.Alerta: Console.ForegroundColor = ConsoleColor.Yellow; break;
            }
            Console.WriteLine(mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
