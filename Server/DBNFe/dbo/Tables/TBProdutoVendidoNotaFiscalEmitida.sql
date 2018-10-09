CREATE TABLE [dbo].[TBProdutoVendidoNotaFiscalEmitida] (
    [Id_ProdutoVendidoNotaFiscalEmitida] INT             IDENTITY (1, 1) NOT NULL,
    [Codigo]                             VARCHAR (40)    NOT NULL,
    [Descricao]                          VARCHAR (40)    NOT NULL,
    [ValorUnitario]                      DECIMAL (18, 2) NOT NULL,
    [Quantidade]                         INT             NOT NULL,
    [NotaFiscalEmitida_Id]               INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_ProdutoVendidoNotaFiscalEmitida] ASC),
    CONSTRAINT [FK_TBProdutoVendidoNotaFiscalEmitida_To_NotaFiscalEmitida] FOREIGN KEY ([NotaFiscalEmitida_Id]) REFERENCES [dbo].[TBNotaFiscalEmitida] ([Id_NotaFiscalEmitida])
);



