using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Domain.Entities
{

    public class Venda : BaseEntity<int>
    {
        public Venda()
        {
            vendaItems = new List<VendaItem>();
        }

        public Venda(DateTime data, double valt, Usuario usuario, Cliente cli, List<VendaItem> itens)
        {
            vendaItems = new List<VendaItem>();
            Data = data;
            ValorTotal = valt;
            Usuario = usuario;
            Cliente = cli;
            vendaItems = itens;
            
        }

        public DateTime? Data { get; set; }
        public double? ValorTotal { get; set; }
        public Usuario? Usuario { get; set; }
        public Cliente? Cliente { get; set; }
        public List<VendaItem>? vendaItems { get; set; }


        public class VendaItem : BaseEntity<int>
        {
            //public Venda? Venda { get; set; }
            public int? Quantidade { get; set; }
            public double? ValorUnitario { get; set; }
            public double? ValorTotal { get; set; }
            public Produto? Produto { get; set; }


            public VendaItem(int qtd, double vu, double vt, Produto p/*, Venda v*/)
            {
                Quantidade = qtd;
                ValorUnitario = vu;
                ValorTotal = vt;
                Produto = p;
                //Venda = v;
                
            }

            public VendaItem() { }
        }
    }
}

