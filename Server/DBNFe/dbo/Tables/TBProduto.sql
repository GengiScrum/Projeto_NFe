CREATE TABLE [dbo].[TBProduto] (
    [Id_Produto]    INT             IDENTITY (1, 1) NOT NULL,
    [Codigo]        VARCHAR (40)    NOT NULL,
    [Descricao]     VARCHAR (40)    NOT NULL,
    [ValorUnitario] DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Produto] ASC)
);


