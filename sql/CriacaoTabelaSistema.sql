IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Pacientes] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Nascimento] datetime NOT NULL,
    [Idade] integer NOT NULL,
    [Sexo] integer NOT NULL,
    [Cpf] varchar(11) NOT NULL,
    [TitularCpf] varchar(100) NOT NULL,
    [IndicadoPor] varchar(100) NOT NULL,
    [DataCadastro] datetime NOT NULL,
    CONSTRAINT [PK_Pacientes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [PacienteId] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(50) NOT NULL,
    [Complemento] varchar(100) NOT NULL,
    [Cep] varchar(8) NOT NULL,
    [Bairro] varchar(100) NOT NULL,
    [Cidade] varchar(100) NOT NULL,
    [Estado] nvarchar(max) NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_Enderecos_PacienteId] ON [Enderecos] ([PacienteId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200605010225_inicio', N'3.1.4');

GO

