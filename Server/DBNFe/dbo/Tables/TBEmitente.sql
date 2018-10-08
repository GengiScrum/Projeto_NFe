CREATE TABLE [dbo].[TBEmitente] (
    [Id_Emitente]        INT          IDENTITY (1, 1) NOT NULL,
    [NomeFantasia]       VARCHAR (40) NOT NULL,
    [RazaoSocial]        VARCHAR (40) NOT NULL,
    [Cnpj]               VARCHAR (40) NOT NULL,
    [InscricaoEstadual]  VARCHAR (40) NOT NULL,
    [InscricaoMunicipal] VARCHAR (40) NOT NULL,
    [Logradouro]         VARCHAR (40) NOT NULL,
    [Numero]             INT          NOT NULL,
    [Bairro]             VARCHAR (40) NOT NULL,
    [Municipio]          VARCHAR (40) NOT NULL,
    [Estado]             VARCHAR (40) NOT NULL,
    [Pais]               VARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Emitente] ASC)
);


