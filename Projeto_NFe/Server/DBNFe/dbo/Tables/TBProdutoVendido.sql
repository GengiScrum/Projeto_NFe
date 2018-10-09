CREATE TABLE [dbo].[TBProdutoVendido] (
    [Id_ProdutoVendido] INT             IDENTITY (1, 1) NOT NULL,
    [Produto_Id]        INT             NOT NULL,
    [NotaFiscal_Id]     INT             NOT NULL,
    [Quantidade]        INT             NOT NULL,
    [ValorTotal]        DECIMAL (18, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_ProdutoVendido] ASC),
    CONSTRAINT [FK_TBProdutoVendido_To_TBNotaFiscal] FOREIGN KEY ([NotaFiscal_Id]) REFERENCES [dbo].[TBNotaFiscal] ([Id_NotaFiscal]),
    CONSTRAINT [FK_TBProdutoVendido_To_TBProduto] FOREIGN KEY ([Produto_Id]) REFERENCES [dbo].[TBProduto] ([Id_Produto])
);




