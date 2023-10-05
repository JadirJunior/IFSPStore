using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{

    public class Produto : BaseEntity<int>
    {
        public String Nome { get; set; }
        public double Preco{ get; set; }
        public int Quantidade{ get; set; }
        public DateTime DataCompra{ get; set; }
        public int UnidadeVenda { get; set; }
        public Grupo Grupo { get; set;}

        public Produto(String nome, double preco, int qtd, DateTime dtComp, int unidVend, Grupo grupo)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = qtd;
            DataCompra = dtComp;
            UnidadeVenda= unidVend;
            Grupo = grupo;

        }

        public Produto() { }
    }
}
