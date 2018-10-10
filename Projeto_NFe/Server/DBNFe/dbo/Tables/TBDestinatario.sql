CREATE TABLE [dbo].[TBDestinatario]
(
	[Id_Destinatario] INT NOT NULL PRIMARY KEY IDENTITY,
	[Nome] VARCHAR(40)  NULL  ,
	[RazaoSocial] VARCHAR(40)  NULL  ,
	[Cnpj] VARCHAR(40)  NULL  ,
	[Cpf] VARCHAR(40)   NULL  ,
	[InscricaoEstadual] VARCHAR(40)  NULL  ,
	[Logradouro] VARCHAR(40)  NOT NULL  ,
	[Numero] INTEGER  NOT NULL  ,
	[Bairro] VARCHAR(40)  NOT NULL  ,
	[Estado] VARCHAR(40)  NOT NULL  ,
	[Municipio] VARCHAR(40)  NOT NULL  ,
	[Pais] VARCHAR(40)  NOT NULL
)
