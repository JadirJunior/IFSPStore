using IFSPStore.Domain.Entities;
using IFSPSTore.Domain.Entities;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using static IFSPStore.Domain.Entities.Venda;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestDomain
    {
        [TestMethod]
        public void TestCidade()
        {

            var cida = new Cidade("Aracatuba", "SP");
            var user = new Usuario("José Cenci", "SENHA#HARD", "ZECNC", "ZECNC@GMAIL.com", DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true);
            var cli = new Cliente("Cliente jeferson", "Jeff Landia", "530000", "Portal da Perola II", cida);

            var grupo = new Grupo("Grupo bao");
            //var produto = new Produto("Panela", 100, 1, DateTime.UtcNow.ToLocalTime(), 1, grupo);

            var produto = new Produto();
            produto.Nome = "Panela";
            produto.Preco = 100;
            produto.Quantidade = 5;
            produto.UnidadeVenda = 1;
            produto.DataCompra = DateTime.UtcNow.ToLocalTime();
            produto.Grupo = grupo;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(cida, options));
            Assert.AreEqual(cida.Nome, "Aracatuba");



        }

        [TestMethod]
        public void TestUser()
        {

            var cida = new Cidade("Aracatuba", "SP");
            var user = new Usuario("Jose Cenci", "SENHA#HARD", "ZECNC", "ZECNC@GMAIL.com", DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(user, options));

        }

        [TestMethod]
        public void TestCliente()
        {

            var cida = new Cidade("Aracatuba", "SP");
            var cli = new Cliente("Cliente jeferson", "Jeff Landia", "530000", "Portal da Perola II", cida);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };


            Console.WriteLine(JsonSerializer.Serialize(cli, options));

        }

        [TestMethod]
        public void TestGrupo()
        {
            var grupo = new Grupo("Grupo bao");

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(grupo, options));

        }

        [TestMethod]
        public void TestProduto()
        {
            var grupo = new Grupo("Grupo bao");
            //var produto = new Produto("Panela", 100, 1, DateTime.UtcNow.ToLocalTime(), 1, grupo);

            var produto = new Produto();
            produto.Nome = "Panela";
            produto.Preco = 100;
            produto.Quantidade = 5;
            produto.UnidadeVenda = 1;
            produto.DataCompra = DateTime.UtcNow.ToLocalTime();
            produto.Grupo = grupo;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(produto, options));
        }

        [TestMethod]
        public void TestVenda()
        {
            var user = new Usuario("Jose Cenci", "SENHA#HARD", "ZECNC", "ZECNC@GMAIL.com", DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true);
            var cida = new Cidade("Aracatuba", "SP");
            var cli = new Cliente("Cliente jeferson", "Jeff Landia", "530000", "Portal da Perola II", cida);

            var grupo = new Grupo("Grupo bao");
            //var produto = new Produto("Panela", 100, 1, DateTime.UtcNow.ToLocalTime(), 1, grupo);

            var produto = new Produto();
            produto.Nome = "Panela";
            produto.Preco = 100;
            produto.Quantidade = 5;
            produto.UnidadeVenda = 1;
            produto.DataCompra = DateTime.UtcNow.ToLocalTime();
            produto.Grupo = grupo;

            List<VendaItem> vendaItens = new List<VendaItem>();

            var venda = new Venda(DateTime.UtcNow.ToLocalTime(), 100, user, cli, vendaItens);
            
            var vendaItem = new VendaItem(1, 10, 100, produto);


            if(vendaItens != null)
                vendaItens.Add(vendaItem);

            var options = new JsonSerializerOptions { WriteIndented = true, ReferenceHandler = ReferenceHandler.IgnoreCycles };

            Console.WriteLine(JsonSerializer.Serialize(venda, options));
            //Console.WriteLine(JsonSerializer.Serialize(vendaItem, options));

    
        }
    }
}