CREATE TABLE [dbo].[TBTransportador]
(
	[Id_Transportador] INT NOT NULL PRIMARY KEY IDENTITY,
	[NomeFantasia] VARCHAR(40)  NULL  ,
	[RazaoSocial] VARCHAR(40)  NULL  ,
	[Cnpj] VARCHAR(40)  NULL  ,
	[Cpf] VARCHAR(40)   NULL  ,
	[InscricaoEstadual] VARCHAR(40)  NULL  ,
	[ResponsabilidadeFrete] BIT  NOT NULL  ,
	[Logradouro] VARCHAR(40)  NOT NULL  ,
	[Numero] INTEGER  NOT NULL  ,
	[Bairro] VARCHAR(40)  NOT NULL  ,
	[Estado] VARCHAR(40)  NOT NULL  ,
	[Municipio] VARCHAR(40)  NOT NULL  ,
	[Pais] VARCHAR(40)  NOT NULL
)
