CREATE TABLE [dbo].[TBImpostoNotaFiscal] (
    [Id_ImpostoNotaFiscal] INT             IDENTITY (1, 1) NOT NULL,
    [ValorIpiNota]         DECIMAL (18, 2) NOT NULL,
    [ValorIcmsNota]        DECIMAL (18, 2) NOT NULL,
    [ValorFrete]           DECIMAL (18, 2) NOT NULL,
    [ValorTotalProduto]    DECIMAL (18, 2) NOT NULL,
    [ValorTotalNota]       DECIMAL (18, 2) NOT NULL,
    [NotaFiscal_Id]        INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_ImpostoNotaFiscal] ASC),
    CONSTRAINT [FK_TBImpostoNotaFiscal_To_TBNotaFiscal] FOREIGN KEY ([NotaFiscal_Id]) REFERENCES [dbo].[TBNotaFiscal] ([Id_NotaFiscal])
);



