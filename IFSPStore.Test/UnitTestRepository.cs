using IFSPStore.Domain.Entities;
using IFSPSTore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using static IFSPStore.Domain.Entities.Venda;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestRepository
    { 


        public class MyDbContext : DbContext
        {
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Cidade> Cidade { get; set; }
            public DbSet<Grupo> Grupo { get; set; }
            public DbSet<Produto> Produto { get; set; }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<Venda> Venda { get; set; }
            public DbSet<VendaItem> VendaItem { get; set; }

            public MyDbContext()
            {
                //Força a criação do banco de dados;
                Database.EnsureCreated();
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "";
                var strCon = $"Server={server};Port={port};" + $"Database={database}; Uid={username};Pwd={password}";

                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }
        }


        #region Test Usuario
        [TestMethod]
        public void TestUsuario()
        {
            using (var context = new MyDbContext()){
                var usuario = new Usuario("Jadir", "12345", "Jadir123", "jadirjunior8@gmail.com", 
                    DateTime.UtcNow.ToLocalTime(), DateTime.UtcNow.ToLocalTime(), true);

                context.Usuario.Add(usuario);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuario)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(usuario));
                    }
                }
            }
        }
        #endregion
        

        #region Teste Cidade
        [TestMethod]
        public void TestCidade()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade("Araçatuba", "SP");

                context.Cidade.Add(cidade);
                context.SaveChanges();
            };
            
        }

        [TestMethod]
        public void TestSelectCidade()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidade)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(cidade));
                    }
                }
            };
        }
        #endregion

        #region Test Grupo
        [TestMethod]
        public void TestGrupo()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo("Yakissoba");

                context.Grupo.Add(grupo);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectGrupo()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupo)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(grupo));
                    }
                }
            }
        }
        #endregion


        #region Test Cliente
        [TestMethod]
        public void TestCliente()
        {
            using (var context = new MyDbContext())
            {

                var cidade = context.Cidade.First(c => c.id == 1);
                var cliente = new Cliente("Roger", "Rua de Abreu", "528416157", "Jardim Europa", cidade);

                context.Cliente.Add(cliente);
                context.SaveChanges();

            };
        }

        [TestMethod]
        public void TestSelectCliente()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Cliente)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(cliente));
                    }
                }
            }
        }
        #endregion


        #region Test Produto
        [TestMethod]
        public void TestProduto()
        {
            using (var context = new MyDbContext())
            {
                var grupo = context.Grupo.First(c => c.id == 1);
                var produto = new Produto("Panela", 100, 50, DateTime.UtcNow.ToLocalTime(), 5, grupo);

                context.Produto.Add(produto);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectProduto()
        {
            using (var context = new MyDbContext()) 
            { 
                foreach (var produto in context.Produto)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(produto));
                    }
                }
            }
        }
        #endregion

        #region Test Venda
        [TestMethod]
        public void TestVenda()
        {
            using (var context = new MyDbContext())
            {

                var usuario = context.Usuario.First(uu => uu.id == 1);

                var produto = context.Produto.First(p => p.id == 1);

                var vendaItem = new VendaItem(5, 20, 100, produto);

                var cliente = context.Cliente.First(c => c.id == 1);

                var venda = new Venda(DateTime.UtcNow.ToLocalTime(), 200, usuario, cliente, new List<VendaItem>()
                {
                    vendaItem
                });

                context.Venda.Add(venda);
                context.VendaItem.Add(vendaItem);
                context.SaveChanges();
            };
        }

        [TestMethod]
        public void TestSelectVenda()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.Venda)
                {
                    {
                        Console.WriteLine(JsonSerializer.Serialize(venda));
                    }
                }
            }
        }
        #endregion

    }


}