CREATE DATABASE IFSPStore;
DROP DATABASE IFSPSTore;

CREATE TABLE IF NOT EXISTS Usuario (
  id INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(100) NULL,
  Senha VARCHAR(45) NULL,
  Login VARCHAR(45) NULL,
  Email VARCHAR(45) NULL,
  DataCadastro TIMESTAMP NULL,
  DataLogin TIMESTAMP NULL,
  Ativo BINARY NULL,
  PRIMARY KEY (id)
  );
  

  
CREATE TABLE IF NOT EXISTS Cidade (
  id INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(100) NULL,
  Estado VARCHAR(2) NULL,
  PRIMARY KEY (id)
  );

CREATE TABLE IF NOT EXISTS Cliente (
  id INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(100) NULL,
  Endereco VARCHAR(100) NULL,
  Documento VARCHAR(45) NULL,
  Bairro VARCHAR(45) NULL,
  idCidade INT NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_Cliente_Cidade
    FOREIGN KEY (idCidade)
    REFERENCES IFSPStoreDB.Cidade (id)
);


CREATE TABLE IF NOT EXISTS Venda (
  id INT NOT NULL AUTO_INCREMENT,
  Data TIMESTAMP NULL,
  ValorTotal DECIMAL(10,2) NULL,
  idUsuario INT NOT NULL,
  idCliente INT NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_Venda_Usuario
    FOREIGN KEY (idUsuario)
    REFERENCES IFSPStoreDB.Usuario (id),
  CONSTRAINT fk_Venda_Cliente
    FOREIGN KEY (idCliente)
    REFERENCES IFSPStoreDB.Cliente (id)
);

CREATE TABLE IF NOT EXISTS Grupo (
  id INT NOT NULL AUTO_INCREMENT,
  Nome VARCHAR(45) NULL,
  PRIMARY KEY (id)
);


CREATE TABLE IF NOT EXISTS Produto (
  id INT NOT NULL,
  Nome VARCHAR(100) NULL,
  Preco DECIMAL(10,2) NULL,
  Quantidade INT NULL,
  DataCompra DATE NULL,
  UnidadeVenda VARCHAR(10) NULL,
  idGrupo INT NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_Produto_Grupo
    FOREIGN KEY (idGrupo)
    REFERENCES IFSPStoreDB.Grupo (id)
);

CREATE TABLE IF NOT EXISTS VendaItem (
  id INT NOT NULL AUTO_INCREMENT,
  Quantidade INT NULL,
  ValorUnitario DECIMAL(10,2) NULL,
  ValorTotal DECIMAL(10,2) NULL,
  idProduto INT NOT NULL,
  idVenda INT NOT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_VendaItem_Produto1
    FOREIGN KEY (idProduto)
    REFERENCES IFSPStoreDB.Produto (id),
  CONSTRAINT fk_VendaItem_Venda1
    FOREIGN KEY (idVenda)
    REFERENCES IFSPStoreDB.Venda (id)
);