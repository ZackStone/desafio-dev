--/*
DROP TABLE Transacao;
DROP TABLE TipoTransacao;
DROP TABLE NaturezaTransacao;
GO 
--*/

CREATE TABLE NaturezaTransacao
(
	Id INT NOT NULL PRIMARY KEY,
	Descricao VARCHAR(30) NOT NULL,
	Sinal CHAR(1) NOT NULL
);
GO

/*
DROP TABLE Transacao;
DROP TABLE TipoTransacao;
GO 
--*/

CREATE TABLE TipoTransacao
(
	Id INT NOT NULL PRIMARY KEY,
	Descricao VARCHAR(30) NOT NULL,
	NaturezaTransacaoId INT NOT NULL,

	CONSTRAINT FK_TipoTransacao_NaturezaTransacao FOREIGN KEY (NaturezaTransacaoId) REFERENCES NaturezaTransacao(Id)
);
GO


/*
DROP TABLE Transacao;
GO 
--*/
CREATE TABLE Transacao
(
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	TipoTransacaoId INT NOT NULL,
	Cpf CHAR(11) NOT NULL,
    Cartao CHAR(12) NOT NULL,
    DataHora DATETIME NOT NULL,
	NomeLoja VARCHAR(19) NOT NULL,
	DonoLoja VARCHAR(14) NOT NULL,
    Valor DECIMAL(9,2) NOT NULL,

    CONSTRAINT FK_Transacao_TipoTransacao FOREIGN KEY (TipoTransacaoId) REFERENCES TipoTransacao(Id)
);
GO


INSERT INTO NaturezaTransacao VALUES
(1, 'Entrada', '+'),
(2, 'Saída', '-')
GO

SELECT * FROM NaturezaTransacao 

INSERT INTO TipoTransacao VALUES 
(1, 'Débito', 1),
(2, 'Boleto', 2),
(3, 'Financiamento', 2),
(4, 'Crédito', 1),
(5, 'Recebimento Empréstimo', 1),
(6, 'Vendas', 1),
(7, 'Recebimento TED', 1),
(8, 'Recebimento DOC', 1),
(9, 'Aluguel', 2)
GO

SELECT * FROM TipoTransacao