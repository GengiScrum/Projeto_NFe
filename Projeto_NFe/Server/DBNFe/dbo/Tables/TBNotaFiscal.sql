CREATE TABLE [dbo].[TBNotaFiscal] (
    [Id_NotaFiscal]    INT          IDENTITY (1, 1) NOT NULL,
    [Emitente_Id]      INT          NOT NULL,
    [Transportador_Id] INT          NOT NULL,
    [Destinatario_Id]  INT          NOT NULL,
    [NaturezaOperacao] VARCHAR (40) NOT NULL,
    [DataEntrada]      DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_NotaFiscal] ASC),
    CONSTRAINT [FK_TBNotaFiscal_To_TBDestinatario] FOREIGN KEY ([Destinatario_Id]) REFERENCES [dbo].[TBDestinatario] ([Id_Destinatario]),
    CONSTRAINT [FK_TBNotaFiscal_To_TBEmitente] FOREIGN KEY ([Emitente_Id]) REFERENCES [dbo].[TBEmitente] ([Id_Emitente]),
    CONSTRAINT [FK_TBNotaFiscal_To_TBTransportador] FOREIGN KEY ([Transportador_Id]) REFERENCES [dbo].[TBTransportador] ([Id_Transportador])
);





