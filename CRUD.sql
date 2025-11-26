CREATE DATABASE FinanceiroDB;
GO

USE FinanceiroDB;
GO



CREATE TABLE Lancamentos (
    ID INT PRIMARY KEY IDENTITY(1,1),      
    Descricao VARCHAR(255) NOT NULL,      
    Valor DECIMAL(10, 2) NOT NULL,        
    DataLancamento DATE NOT NULL,         
    Tipo VARCHAR(50) NOT NULL         
);