CREATE TABLE [dbo].[TBImpostoProdutoVendido]
(
	[Id_ImpostoProdutoVendido] INT NOT NULL PRIMARY KEY IDENTITY,
	[ValorIpi] DECIMAL(18, 2)  NOT NULL  ,
	[ValorIcms] DECIMAL(18, 2)  NOT NULL  ,
	[AliquotaIpi] DECIMAL(18, 2)   NOT NULL  ,
	[AliquotaIcms] DECIMAL(18, 2)   NOT NULL    ,
)
