CREATE TABLE [dbo].[People] (
    [Id]            INT          NOT NULL,
    [FirstName]     VARCHAR (50) NOT NULL,
    [Surname]       VARCHAR (50) NOT NULL,
    [SurnamePrefix] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[PhoneNumbers] (
    [Id]     INT          NOT NULL,
    [Person] INT          NOT NULL,
    [Number] VARCHAR (15) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PhoneNumbers_People] FOREIGN KEY ([Person]) REFERENCES [dbo].[People] ([Id])
);

CREATE TABLE [dbo].[EmailAddresses] (
    [Id]      INT          NOT NULL,
    [Person]  INT          NOT NULL,
    [Address] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_EmailAddresses_People] FOREIGN KEY ([Person]) REFERENCES [dbo].[People] ([Id])
)

CREATE TABLE [dbo].[Events] (
    [Id]          INT          NOT NULL,
    [Title]       VARCHAR (50) NOT NULL,
    [Description] TEXT         NULL,
    [DateTime]    DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[IsOrganizer] (
    [Person] INT NOT NULL,
    [Event]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Person] ASC, [Event] ASC),
    CONSTRAINT [FK_IsOrganizer_People] FOREIGN KEY ([Person]) REFERENCES [dbo].[People] ([Id]),
    CONSTRAINT [FK_IsOrganizer_Events] FOREIGN KEY ([Event]) REFERENCES [dbo].[Events] ([Id])
);

CREATE TABLE [dbo].[IsInvitee] (
    [Person] INT NOT NULL,
    [Event]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Person] ASC, [Event] ASC),
    CONSTRAINT [FK_IsInvitee_People] FOREIGN KEY ([Person]) REFERENCES [dbo].[People] ([Id]),
    CONSTRAINT [FK_IsInvitee_Events] FOREIGN KEY ([Event]) REFERENCES [dbo].[Events] ([Id])
);