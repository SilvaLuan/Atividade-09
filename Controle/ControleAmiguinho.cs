using System.Collections.Generic;
using ClubeDaLeitura.Dominio;
using ClubeDaLeitura.Tela;

namespace ClubeDaLeitura.Controle
{
    public class ControleAmiguinho
    {      
        public List<Amiguinho> amiguinhos = new List<Amiguinho>();
       
        public bool Registrar(int id,string nome, string responsavel, string telefone, string onde)
        {
            Amiguinho amiguinho= new Amiguinho(id, nome, responsavel, telefone, onde);

            if (amiguinho.Validar(nome)) 
            {              
                amiguinhos.Add(amiguinho); 
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
            foreach (var amigo in amiguinhos)
            {
                if (id == amigo.id)
                {
                    string nome, responsavel, telefone, onde;
                    TelaAmiguinho.EntradaDeValores(out nome, out responsavel, out telefone, out onde);
                    amigo.nome = nome;
                    amigo.responsavel = responsavel;
                    amigo.telefone = telefone;
                    amigo.onde = onde;
                    achou = true;
                }
            }
            return achou;                   
        }
        
        public bool Excluir(int id)
        {
            bool achou = false;
            foreach (var amigo in amiguinhos) 
            {
                if (id == amigo.id) 
                {
                    amiguinhos.Remove(amigo);
                    achou = true;
                    break;               
                }
            }
            return achou;

        }
        
    }
}
