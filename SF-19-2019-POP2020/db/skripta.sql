CREATE TABLE [dbo].[Adrese] (
    [id]     INT          NOT NULL,
    [broj]   VARCHAR (20) NULL,
    [ulica]  VARCHAR (30) NULL,
    [drzava] VARCHAR (20) NULL,
    [grad]   VARCHAR (20) NULL,
    [active] BIT          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);



CREATE TABLE [dbo].[DomZdravlja] (
    [id]        INT          NOT NULL,
    [naziv]     VARCHAR (30) NULL,
    [adresa_id] INT          NULL,
    [active]    BIT          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([adresa_id]) REFERENCES [dbo].[Adrese] ([id])
);


CREATE TABLE [dbo].[Pacijenti] (
    [Id]        INT          NOT NULL,
    [ime]       VARCHAR (20) NULL,
    [prezime]   VARCHAR (20) NULL,
    [lozinka]   VARCHAR (20) NULL,
    [email]     VARCHAR (20) NULL,
    [jmbg]      VARCHAR (13) NULL,
    [pol]       VARCHAR (20) NULL,
    [aktivan]   BIT          NULL,
    [adresa_id] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([adresa_id]) REFERENCES [dbo].[Adrese] ([id])
);


CREATE TABLE [dbo].[Doktori] (
    [Id]             INT          NOT NULL,
    [ime]            VARCHAR (20) NULL,
    [prezime]        VARCHAR (20) NULL,
    [lozinka]        VARCHAR (20) NULL,
    [email]          VARCHAR (20) NULL,
    [jmbg]           VARCHAR (13) NULL,
    [pol]            VARCHAR (20) NULL,
    [aktivan]        BIT          NULL,
    [adresa_id]      INT          NULL,
    [domZdravlja_id] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([adresa_id]) REFERENCES [dbo].[Adrese] ([id]),
    FOREIGN KEY ([domZdravlja_id]) REFERENCES [dbo].[DomZdravlja] ([id])
);


CREATE TABLE [dbo].[Terapije] (
    [Id]          INT          NOT NULL,
    [opis]        VARCHAR (30) NULL,
    [lekar_id]    INT          NULL,
    [pacijent_id] INT          NULL,
    [aktivan]     BIT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([lekar_id]) REFERENCES [dbo].[Doktori] ([Id]),
    FOREIGN KEY ([pacijent_id]) REFERENCES [dbo].[Pacijenti] ([Id])
);


CREATE TABLE [dbo].[Termini] (
    [id]          INT          NOT NULL,
    [lekar_id]    INT          NULL,
    [datum]       DATETIME     NULL,
    [status]      VARCHAR (20) NULL,
    [pacijent_id] INT          NULL,
    [active]      BIT          NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([lekar_id]) REFERENCES [dbo].[Doktori] ([Id]),
    FOREIGN KEY ([pacijent_id]) REFERENCES [dbo].[Pacijenti] ([Id])
);






