create table [dbo].[Agencies] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) not null,
    [Logo] [nvarchar](50) not null,
    primary key ([Id])
);
create table [dbo].[AspNetUsers] (
    [Id] [nvarchar](128) not null,
    [Email] [nvarchar](256) null,
    [EmailConfirmed] [bit] not null,
    [PasswordHash] [nvarchar](max) null,
    [SecurityStamp] [nvarchar](max) null,
    [PhoneNumber] [nvarchar](max) null,
    [PhoneNumberConfirmed] [bit] not null,
    [TwoFactorEnabled] [bit] not null,
    [LockoutEndDateUtc] [datetime] null,
    [LockoutEnabled] [bit] not null,
    [AccessFailedCount] [int] not null,
    [UserName] [nvarchar](256) not null,
    primary key ([Id])
);
create table [dbo].[Arrangements] (
    [Id] [int] not null identity,
    [AgencyId] [int] not null,
    [DestinationId] [int] not null,
    [Description] [nvarchar](max) not null,
    [ArrangementTypeId] [int] not null,
    [StayDays] [int] not null,
    [StayNights] [int] not null,
    [Price] [int] not null,
    primary key ([Id])
);
create table [dbo].[ArrangementServices] (
    [Id] [int] not null identity,
    [ArrangementId] [int] not null,
    [ServiceId] [int] not null,
    primary key ([Id])
);
create table [dbo].[ArrangementTransportationTypes] (
    [Id] [int] not null identity,
    [ArrangementId] [int] not null,
    [TransportationTypeId] [int] not null,
    primary key ([Id])
);
create table [dbo].[ArrangementTypes] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) not null,
    primary key ([Id])
);
create table [dbo].[Destinations] (
    [Id] [int] not null identity,
    [Place] [nvarchar](50) not null,
    [Country] [nvarchar](50) not null,
    [Picture] [nvarchar](50) not null,
    primary key ([Id])
);
create table [dbo].[AspNetRoles] (
    [Id] [nvarchar](128) not null,
    [Name] [nvarchar](256) not null,
    primary key ([Id])
);
create table [dbo].[AspNetUserClaims] (
    [Id] [int] not null identity,
    [UserId] [nvarchar](128) not null,
    [ClaimType] [nvarchar](max) null,
    [ClaimValue] [nvarchar](max) null,
    primary key ([Id])
);
create table [dbo].[AspNetUserLogins] (
    [LoginProvider] [nvarchar](128) not null,
    [ProviderKey] [nvarchar](128) not null,
    [UserId] [nvarchar](128) not null,
    primary key ([LoginProvider], [ProviderKey], [UserId])
);
create table [dbo].[AspNetUserRoles] (
    [UserId] [nvarchar](128) not null,
    [RoleId] [nvarchar](128) not null,
    primary key ([UserId], [RoleId])
);
create table [dbo].[Services] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) not null,
    primary key ([Id])
);
create table [dbo].[TransportationTypes] (
    [Id] [int] not null identity,
    [Name] [nvarchar](50) not null,
    primary key ([Id])
);
alter table [dbo].[AspNetUserClaims] add constraint [ApplicationUser_Claims] foreign key ([UserId]) references [dbo].[AspNetUsers]([Id]) on delete cascade;
alter table [dbo].[AspNetUserLogins] add constraint [ApplicationUser_Logins] foreign key ([UserId]) references [dbo].[AspNetUsers]([Id]) on delete cascade;
alter table [dbo].[AspNetUserRoles] add constraint [ApplicationUser_Roles] foreign key ([UserId]) references [dbo].[AspNetUsers]([Id]) on delete cascade;
alter table [dbo].[Arrangements] add constraint [Arrangement_Agency] foreign key ([AgencyId]) references [dbo].[Agencies]([Id]) on delete cascade;
alter table [dbo].[Arrangements] add constraint [Arrangement_ArrangementType] foreign key ([ArrangementTypeId]) references [dbo].[ArrangementTypes]([Id]) on delete cascade;
alter table [dbo].[Arrangements] add constraint [Arrangement_Destination] foreign key ([DestinationId]) references [dbo].[Destinations]([Id]) on delete cascade;
alter table [dbo].[ArrangementServices] add constraint [ArrangementService_Arrangement] foreign key ([ArrangementId]) references [dbo].[Arrangements]([Id]) on delete cascade;
alter table [dbo].[ArrangementServices] add constraint [ArrangementService_Service] foreign key ([ServiceId]) references [dbo].[Services]([Id]) on delete cascade;
alter table [dbo].[ArrangementTransportationTypes] add constraint [ArrangementTransportationType_Arrangement] foreign key ([ArrangementId]) references [dbo].[Arrangements]([Id]) on delete cascade;
alter table [dbo].[ArrangementTransportationTypes] add constraint [ArrangementTransportationType_TransportationType] foreign key ([TransportationTypeId]) references [dbo].[TransportationTypes]([Id]) on delete cascade;
alter table [dbo].[AspNetUserRoles] add constraint [IdentityRole_Users] foreign key ([RoleId]) references [dbo].[AspNetRoles]([Id]) on delete cascade;
