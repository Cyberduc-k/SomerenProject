USE [pdb1920nl15]

DROP DATABASE [pdb1920nl15]

CREATE DATABASE [pdb1920nl15]

USE [pdb1920nl15]

CREATE TABLE [dbo].[Activiteiten] (
    [ActiviteitID]   INT        NOT NULL PRIMARY KEY,
    [Activiteitnaam] NVARCHAR (50) NOT NULL,
    [Dag]            NVARCHAR (50) NOT NULL,
    [Tijdstip]       TIME   NOT NULL
);

CREATE TABLE [dbo].[Kamer] (
    [KamerID]        INT NOT NULL PRIMARY KEY,
    [AantalPersonen] INT NOT NULL,
);

CREATE TABLE [dbo].[Drankje] (
    [DrankID]       INT           NOT NULL PRIMARY KEY,
    [Naam]          NVARCHAR (50) NOT NULL,
    [Prijs]         INT           NOT NULL,
    [Alcholistisch] BIT           NOT NULL
);

CREATE TABLE [dbo].[Docenten] (
    [DocentID]   INT           NOT NULL PRIMARY KEY,
    [Voornaam]   NVARCHAR (50) NOT NULL,
    [Achternaam] NVARCHAR (50) NOT NULL,
	[KamerID]    INT		   NOT NULL FOREIGN KEY REFERENCES Kamer(KamerID)
);

CREATE TABLE [dbo].[Studenten] (
    [StudentID]     INT           NOT NULL PRIMARY KEY,
    [Voornaam]      NVARCHAR (50) NOT NULL,
    [Achternaam]    NVARCHAR (50) NOT NULL,
    [GeboorteDatum] DATE          NOT NULL,
	[KamerID]		INT			  NOT NULL FOREIGN KEY REFERENCES Kamer(KamerID)
);

CREATE TABLE [dbo].[Kassa] (
    [KassaID]  INT NOT NULL PRIMARY KEY,
    [Omzet]    INT NOT NULL,
    [Vouchers] INT NOT NULL,
	[DocentID] INT NOT NULL FOREIGN KEY REFERENCES Docenten(DocentID)
);

CREATE TABLE [dbo].[Voorraad] (
    [DrankID] INT NOT NULL FOREIGN KEY REFERENCES Drankje(DrankID),
	[KassaID] INT NOT NULL FOREIGN KEY REFERENCES Kassa(KassaID),
    [Aantal]  INT NOT NULL,
	PRIMARY KEY(DrankID, KassaID)
);

CREATE TABLE [dbo].[Begeleid] (
    [ActiviteitID] INT NOT NULL FOREIGN KEY REFERENCES Activiteiten(ActiviteitID),
    [DocentID]     INT NOT NULL FOREIGN KEY REFERENCES Docenten(DocentID),
	PRIMARY KEY(ActiviteitID, DocentID)
);

CREATE TABLE [dbo].[NeemtDeel] (
    [ActiviteitID] INT NOT NULL FOREIGN KEY REFERENCES Activiteiten(ActiviteitID),
	[StudentID]    INT NOT NULL FOREIGN KEY REFERENCES Studenten(StudentID),
    PRIMARY KEY(ActiviteitID, StudentID)
);

CREATE TABLE [dbo].[Bestellingen] (
    [BestellingID] INT NOT NULL	PRIMARY KEY,
    [Aantal]       INT NOT NULL,
	[StudentID]	   INT NOT NULL FOREIGN KEY REFERENCES Studenten(StudentID),
	[KassaID]	   INT NOT NULL FOREIGN KEY REFERENCES Kassa(KassaID),
	[DrankID]	   INT NOT NULL	FOREIGN KEY REFERENCES Drankje(DrankID)
);

CREATE TABLE [dbo].[Begeleider] (
	[DocentId] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES Docenten(DocentId),
);