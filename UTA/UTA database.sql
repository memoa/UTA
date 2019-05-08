CREATE TABLE [dbo].[Agencies] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Logo] NVARCHAR (50) DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_dbo.Agencies] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[ArrangementTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.ArrangementTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Destinations] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Place]   NVARCHAR (50) NOT NULL,
    [Country] NVARCHAR (50) NOT NULL,
    [Picture] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.Destinations] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Services] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.Services] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[TransportationTypes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_dbo.TransportationTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Arrangements] (
    [Id]                   INT            IDENTITY (1, 1) NOT NULL,
    [DestinationId]        INT            DEFAULT ((0)) NOT NULL,
    [Description]          NVARCHAR (MAX) NOT NULL,
    [ArrangementTypeId]    INT            DEFAULT ((0)) NOT NULL,
    [TransportationTypeId] INT            DEFAULT ((0)) NOT NULL,
    [ServiceId]            INT            DEFAULT ((0)) NOT NULL,
    [StayDays]             INT            DEFAULT ((0)) NOT NULL,
    [StayNights]           INT            DEFAULT ((0)) NOT NULL,
    [Price]                INT            DEFAULT ((0)) NOT NULL,
    [AgencyId]             INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.Arrangements] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Arrangements_dbo.Destinations_DestinationId] FOREIGN KEY ([DestinationId]) REFERENCES [dbo].[Destinations] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Arrangements_dbo.ArrangementTypes_ArrangementTypeId] FOREIGN KEY ([ArrangementTypeId]) REFERENCES [dbo].[ArrangementTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Arrangements_dbo.Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [dbo].[Services] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Arrangements_dbo.TransportationTypes_TransportationTypeId] FOREIGN KEY ([TransportationTypeId]) REFERENCES [dbo].[TransportationTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Arrangements_dbo.Agencies_AgencyId] FOREIGN KEY ([AgencyId]) REFERENCES [dbo].[Agencies] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUsers] (
    [Id]                   NVARCHAR (128) NOT NULL,
    [Email]                NVARCHAR (256) NULL,
    [EmailConfirmed]       BIT            NOT NULL,
    [PasswordHash]         NVARCHAR (MAX) NULL,
    [SecurityStamp]        NVARCHAR (MAX) NULL,
    [PhoneNumber]          NVARCHAR (MAX) NULL,
    [PhoneNumberConfirmed] BIT            NOT NULL,
    [TwoFactorEnabled]     BIT            NOT NULL,
    [LockoutEndDateUtc]    DATETIME       NULL,
    [LockoutEnabled]       BIT            NOT NULL,
    [AccessFailedCount]    INT            NOT NULL,
    [UserName]             NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetRoles] (
    [Id]   NVARCHAR (128) NOT NULL,
    [Name] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (128) NOT NULL,
    [ClaimType]  NVARCHAR (MAX) NULL,
    [ClaimValue] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] NVARCHAR (128) NOT NULL,
    [ProviderKey]   NVARCHAR (128) NOT NULL,
    [UserId]        NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED ([LoginProvider] ASC, [ProviderKey] ASC, [UserId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[AspNetUserRoles] (
    [UserId] NVARCHAR (128) NOT NULL,
    [RoleId] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);

SET IDENTITY_INSERT [dbo].[Agencies] ON
INSERT INTO [dbo].[Agencies] ([Id], [Name], [Logo]) VALUES (5, N'Global Turizam', N'logo1.jpg')
INSERT INTO [dbo].[Agencies] ([Id], [Name], [Logo]) VALUES (6, N'Avantura Turisticka Agencija', N'logo2.jpg')
INSERT INTO [dbo].[Agencies] ([Id], [Name], [Logo]) VALUES (7, N'Linea Putovanja', N'logo3.jpg')
INSERT INTO [dbo].[Agencies] ([Id], [Name], [Logo]) VALUES (8, N'Biser Turisticka Agencija', N'logo4.png')
INSERT INTO [dbo].[Agencies] ([Id], [Name], [Logo]) VALUES (9, N'Premium Turizam', N'logo5.jpg')
SET IDENTITY_INSERT [dbo].[Agencies] OFF

SET IDENTITY_INSERT [dbo].[ArrangementTypes] ON
INSERT INTO [dbo].[ArrangementTypes] ([Id], [Name]) VALUES (5, N'Daleka putovanja')
INSERT INTO [dbo].[ArrangementTypes] ([Id], [Name]) VALUES (6, N'Gradovi Evrope')
INSERT INTO [dbo].[ArrangementTypes] ([Id], [Name]) VALUES (7, N'Izleti')
SET IDENTITY_INSERT [dbo].[ArrangementTypes] OFF

SET IDENTITY_INSERT [dbo].[Destinations] ON
INSERT INTO [dbo].[Destinations] ([Id], [Place], [Country], [Picture]) VALUES (5, N'Bali', N'Indonezija', N'best-resorts-bali.jpg')
INSERT INTO [dbo].[Destinations] ([Id], [Place], [Country], [Picture]) VALUES (6, N'Rim', N'Italija', N'rome.jpg')
INSERT INTO [dbo].[Destinations] ([Id], [Place], [Country], [Picture]) VALUES (7, N'Prag', N'Ceska Republika', N'prague.jpg')
INSERT INTO [dbo].[Destinations] ([Id], [Place], [Country], [Picture]) VALUES (8, N'Djavolja Varos', N'Srbija', N'Djavolja_Varos.jpg')
INSERT INTO [dbo].[Destinations] ([Id], [Place], [Country], [Picture]) VALUES (9, N'Havana', N'Kuba', N'havana-main.jpg')
SET IDENTITY_INSERT [dbo].[Destinations] OFF

SET IDENTITY_INSERT [dbo].[Services] ON
INSERT INTO [dbo].[Services] ([Id], [Name]) VALUES (1, N'Polupansion')
SET IDENTITY_INSERT [dbo].[Services] OFF

SET IDENTITY_INSERT [dbo].[TransportationTypes] ON
INSERT INTO [dbo].[TransportationTypes] ([Id], [Name]) VALUES (1, N'Avion')
INSERT INTO [dbo].[TransportationTypes] ([Id], [Name]) VALUES (2, N'Autobus')
SET IDENTITY_INSERT [dbo].[TransportationTypes] OFF

SET IDENTITY_INSERT [dbo].[Arrangements] ON
INSERT INTO [dbo].[Arrangements] ([Id], [DestinationId], [Description], [ArrangementTypeId], [TransportationTypeId], [ServiceId], [StayDays], [StayNights], [Price], [AgencyId]) VALUES (14, 5, N'1.dan  BEOGRAD – DOHA Sastanak putnika na aerodromu u Beogradu u 10:00h. Poletanje za Dohu u 12:00h. Sletaje u 18:h.  Čekanje na vezu.  2.dan  DOHA – DENPASAR BALI Nastavak putovanja  iz Dohe za Denpasar letom  u 02:30h. Sletanje u Denpasar (Bali) 17:30h.   Transfer do hotela. Smeštaj. Noćenje.  3.dan  BALI  Doručak. Slobodan dan za odmor i kupanje (izražen fenomen plime i oseke) i individualne obilaske.  Noćenje.  4.dan   BALI Doručak. Slobodan dan za odmor, kupanje i individualne obilaske. Noćenje.  5.dan  BALI Doručak. U 9:00 polazak na celodnevni izlet – Kintamani tuhra. Vodimo vas u Kintamani, planinsko  selo koje pruža nezaboravan pogled na još uvek aktivan vulkan i jezero Batur. Ovo je najatraktivnija  tura na ostrvu i obuhvata posetu živopisnim selima smeštenim u raskošnom prirodnom ambijentu, sa  kućama građenim u tipičnom balinežanskom stilu. Skoro svako selo je poznato po nekom od umetničkih  zanata, kao što su izrada predmeta od srebra, zlata i plemenitog drveta, po umetničkim galerijama i  dobro očuvanim kulturno-istorijskim spomenicima. Izlet ukjučuje i posetu umetničkom selu Batubulan  gde će se videti tradicionalni balinežanski ples Berong, koji živopisno govori o herojskim delima  iz indijskog epa Mahabharata, posetu selu Mas, koje je poznato po rezbarenju drvenih skulptura, grad  Bangli sa drevnim hinduističkim hramom Kehen (hram vatre), Tegalalang živopisna pirinčana polja i  Ubud, kulturni centar Balija sa brojnim umetničkim galerijama. U 18:00h povratak u hotel.  Večera. Noćenje.  6.- 10.dan  BALI Doručak. Slobodni dani za odmor, kupanje i individualne obilaske. Noćenja.  11.dan  BALI Doručak. Napuštanje soba do 12:00h. Slobodno vreme do transfera na aerodrom. 12.dan  DENPASAR (BALI) – DOHA – BEOGRAD Poletanje za Dohu u 00:35h. Sletanje u 05:10h . Nastavak putovanja za Beograd  u 06:35h. Sletanje u Beograd u 11:00 časova.', 5, 1, 1, 12, 9, 2000, 5)
INSERT INTO [dbo].[Arrangements] ([Id], [DestinationId], [Description], [ArrangementTypeId], [TransportationTypeId], [ServiceId], [StayDays], [StayNights], [Price], [AgencyId]) VALUES (15, 6, N'1. dan  BEOGRAD Polazak oko 16h iz Beograda. Noćna vožnja kroz Hrvatsku i Sloveniju prema Rimu.  2. dan  RIM  Dolazak u Rim u 12h. Panoramsko razgledanje Rima – grada starog 28 vekova.  Smeštaj u hotel. Pešački obilazak Rima: Termini, crkva Sv. Petra u lancima  (statua Mikelanđelovog Mojsija), forum Romanum sa Koloseumom, Trg Venecija sa  Trajanovim forumom, Palata Venecija, Fontana Di Trevi, Španski trg...  Slobodno vreme za šetnju i individualne aktivnosti. Noćenje.  3. dan  RIM – FORUM I KOLOSEUM – BRAĆANO – RIM  Doručak. Nakon doručka obilazak Foruma i Koloseuma. Obilazak uključuje: Koloseum,  najveći rimski amfiteatar; brežuljak Palatino, mesto na kome je, po legendi,  vučica odgajila Romula i Rema, mitske osnivače grada; Forum, centar političkog,  javnog i komercijalnog života, u okviru koga se nalaze ostaci bazilika, tržnica,  sudnica i hramova; Kapitolinski brežuljak, nekadašnji rimski akropolj, simbol  neprikosnovenog autoriteta antičkog Rima, za čiji je današnji izgled zaslužan  Mikelanđelo. Nakon toga u 15h polazak za  Braćano – malog grada u blizini Rima.  Dolazak u Braćano koji se nalazi pored vulkaskog jezera sa izuzetno dobro  očuvanim srednjovekovnim zamkom Orsini – Odeskalki, iz 15. veka, u 14:30h.  Nakon obilaska povratak u Rim u večernjim časovima.  Noćenje.  4. dan  RIM – NAPULJ – POMPEJA – RIM Doručak. U 9:00h polazak za Napulj, najvećeg grad južne Italije i sedište regije  Kampanije. Po dolasku u 11:30h panoramski obilazak Napulja: srednjevekovni zamak  Nuovo, Kraljevska palata, Pasaž Umberta I, trgovačka ulica Toledo... Nakon obilaska  Napulja u 15:30h odlazak do Pompeje..Dolazak u Pompeju u 16h. Grad Pompeja je bio  potpuno uništen u erupciji vulkana Vezuv 79. g.n.e. Građevine su ostale skoro  savršeno sačuvane,  jer je grad bio zatrpan slojem pepela i vulkanske lave oko 1600  godina pre nego što je slučajno otkriven. Budući da je erupcija zatekla sve građane  Pompeje (oko 20.000 stanovnika), do danas su nam ostale vidljive naznake kako se  živelo pre skoro 2000 godina. Nakon obilaska povratak u Rim u 20h. Noćenje.  5. dan  RIM – VATIKAN – DOMICIJANOV STADION – VICUS CAPRARIUS – RIM  zakDoručak. Nakon doručka, napuštanje hotela i obilazak Vatikana – jedne od najmanjih  i najmoćnijih država. Poludnevna poseta crkvi svetog Petra, vatikanskim muzejima i   Sikstinskoj kapeli. Prilikom posete muzejima, obilazi se najznačajniji deo zbirki:  zbirka antičkih statua, sala sa tapiserijama, sala geografskih mapa iz 16. veka, sala  kandelabra, sobe koje je oslikao Rafaelo... Posebno se ističe Sikstinska kapela sa  delima Peruđina, Botičelija i drugih svetski poznatih slikara. Obilazak se završava na  velelepnom trgu ispred crkve Svetog Petra u kojoj se nalazi čuvena „Pieta“, jedino  potpisano delo svestranog renesansnog umetnika Mikelanđela.Sledi obilazak Domicijanovog  stadiona, koji je pod zaštitom UNESCO-a i nalazi se ispod Trga Navona na dubini od 4.5m.  Predstavlja arheološko nalazište prvog i jedinog stadiona izrgrađenog od cigle koji je  poznat u Rimu do danas, a koji je u vreme kada je bio izgrađen mogao da primi 30.000 ljudi  koji su dolazili da gledaju borbe i takmičenja gimnastičara koji su dolazili iz Grčke.  Nakon toga obilazak Vicus Caprarius-a, Vodenog Sveta, koji se nalazi u blizini Fontane  di Trevi i predstavlja podzemno, arheološko nalazište, koje je bilo deo akvadukta.  U 20h polazak za Beograd. Noćna vožnja kroz Sloveniju i Hrvatsku prema Beogradu.  6. dan  BEOGRAD Dolazak u Beograd u 12h.', 6, 2, 1, 6, 3, 250, 6)
INSERT INTO [dbo].[Arrangements] ([Id], [DestinationId], [Description], [ArrangementTypeId], [TransportationTypeId], [ServiceId], [StayDays], [StayNights], [Price], [AgencyId]) VALUES (16, 7, N'1. dan   BEOGRAD - NOVI SAD... Polazak autobusom za Prag u 22:00h iz Beograda. Polazak iz Novog Sada u 23:00h.  Vožnja preko graničnog prelaza Horgoša, pored Budimpešte sa usputnim zadržavanjem  radi graničnih formalnosti i odmora.   2. dan  BRATISLAVA - PRAG Dolazak u Bratislavu oko 8:00h. Po dolasku razgledanje grada šetnjom (obilazak  centralnog dela Bratislave): Hvjezdoslavove namjesti, Narodno pozorište, Hlavni trg,  Rolandova fontana, Gradska većnica, kula Sv.Mihajla, katedrala Sv.Martina… Slobodno  vreme za šetnju romantičnim ulicama starog dela grada na obali Dunav. Posle kraćeg  odmora u 13:00h nastavak vožnje do Praga. Dolazak u Prag u 16:00h. Smeštaj u hotelu.  Kasno popodne zajednički odlazak u centar Praga, upoznavanje šetnjom sa starim delom  grada. Individualni povratak u hotel. Noćenje.   3. dan  PRAG - HRADČANI Doručak, posle doručka polazak na razgledanje grada uz pratnju lokalnog vodiča na  srpskom jeziku. Obilazamo dvorac na Hradčanima sa monumentalnom katedralom Sv.Vida  iz X veka sa kapelom Sv.Venceslava i grobnicom čeških kraljeva, staru Kraljevsku  palatu, baziliku Sv.Đorđa, zatim nastavljamo razgledanje kroz Malu Stranu, prelazimo  Vltavu Karlovim mostom, Staru kulu na mostu, spomenik Karlu IV i Karlovom ulicom  dolazimo u Staromjestske namjesti na Starogradski Trg sa astronomskim satom “Orloj”  i Tinskom crkvom. Nakon razgledanja predviđen je (fakultativno) odlazak na vožnju  brodom po Vltavi (panorama Praga) sa ručkom. Slobodno popodne u centru Praga. Noćenje.    4. dan  PRAG - DREZDEN Doručak, u 8:00h odlazak na celodnevni izlet u Drezden,  grad na istoku Nemačke koji  je zbog svog izuzetnog kulturnog značaja nazvan i Firencom na Elbi. Dolazak u Drezden  u 10:30h. Povratak u Prag u 17:00h. Slobodno vreme za individualne aktivnosti. Noćenje.   5. dan  PRAG - KARLOVE VARI Doručak, zatim u 9:00h odlazak na izlet u Karlove Vari (dolazak u Karlove Vari u 11:00h).  Obilazak i razgledanje Karlovih Vari, najpoznatijeg srednjoevropskog banjskog i turističkog  mesta i jednog od najlepših srednjoevropskih gradova. Obilazmo čuvene banjske lekovite  izvore termalne vode, grand hotel Pupp, crkvu Sv.Marije Magdalene, rusku pravoslavnu crkvu  Sv.Petra i Pavla. Povratak u Prag u 17:00h. Slobodno popodne i veče u centru Praga. Noćenje.   6. dan  PRAG - BRNO - BEOGRAD Rani doručak. Napuštanje hotela i polazak prema Brnu (planirano vreme polaska oko 7h). Po  dolasku oko 9h, obilazak grada: neogotička katedrala Sv. Petra i Pavla, Kapucinski manastir,  Zelni trg sa fontanom Parnas, palata Reduta, Stara gradska većnica, koja čuva Brnjensku aždaju  i zanimljivu legendu. Šetnja do Trga slobode na kome se nalazi čuveni Brnjenski sat. Slobodno  vreme za individualne aktivnosti. U 16h okupljanje i polazak za Srbiju sa usputnim pauzama radi  odmora. Vožnja preko Slovačke, Mađarske sa usputnim pauzama za odmor i prelazak državnih granica.  Dolazak u Novi Sad, Beograd oko ponoći.', 6, 2, 1, 6, 4, 129, 7)
INSERT INTO [dbo].[Arrangements] ([Id], [DestinationId], [Description], [ArrangementTypeId], [TransportationTypeId], [ServiceId], [StayDays], [StayNights], [Price], [AgencyId]) VALUES (17, 8, N'Prvi dan, subota  Polazak iz Beograda u 08:00h. Vožnja autoputem u pravcu Niša. Dolazak u  Niš u 11:00h. Obilazak Niške tvrđave, podignute početkom 18. veka. Šetnja  centrom grada duž reke Nišave i preko mosta do pešačke zone uz obilazak  spomenika Oslobodiocima Niša. Nakon toga sledi obilazak Ćele kule, podignute  posle bitke na Čegru 1809. godine, kada su Turci u nju uzidali 952 lobanje  poginulih srpskih ustanika. Pauza za ručak u jednom od mnogobrojnih etno  restorana u čuvenom Kazandžijskom sokačetu. Put se nastavlja u 15:00 ka  Prolom banji. Dolazak u Prolom banju u 17:00h, smeštaj u hotelu.  Večera i noćenje.  Drugi dan, nedelja  Doručak. Jutarnja šetnja (2,5 km) do crkve Lazarice za koju postoji verovanje  da su se u njoj poslednji put pričestili ratnici srpske vojske iz ovih krajeva  pred odlazak u Kosovski boj. Polazak u 10:00h za Đavolju varoš. Obilazak ovog  prirodnog spomenika neobičnog izgleda, koji se sastoji od zemljanih figura na  čijim vrhovima se nalaze kameni blokovi – kape. Zemljane piramide, ili kako ih  lokalno stanovništvo naziva “kule”, visoke su od 2 do 15m. Nakon obilaska sledi  pauza za ručak na samom lokalitetu. U 14:00h sledi polazak prema Kuršumliji.  Dolazak u 15:00h, poseta Manastiru Sv. Nikole, najstarije zadužbine Stefana  Nemanje koja predstavlja jedan od najstarijih spomenika monumentalne srednjovekovne  arhitekture u Srbiji. Nastavljamo ka manastiru Presvete Bogorodice koji se nalazi  na ušću Kosanice u Toplicu, 800 metara nizvodno od manastira Sv. Nikole.  Stefan Nemanja je ovaj manastir posvetio svojoj ženi Ani koja je jedno vreme njime  upravljala. Polazak za Beograd 17:30h. Dolazak u Beograd u 21:00 večernjim časovima.', 7, 2, 1, 2, 1, 50, 8)
INSERT INTO [dbo].[Arrangements] ([Id], [DestinationId], [Description], [ArrangementTypeId], [TransportationTypeId], [ServiceId], [StayDays], [StayNights], [Price], [AgencyId]) VALUES (18, 9, N'1.dan BEOGRAD –ISTANBUL Sastanak putnika na aerodromu Nikola Tesla u 18.20. Poletanje za Istanbul u 20.20.  Dolazak u 00.10. Čekanje na vezu.  2. dan ISTANBUL – HAVANA-VARADERO Nastavak putovanja za Havanu u 02.25. Dolazak u 08.55. Transfer do Varadera. Smeštaj  u hotelu (na bazi "sve uključeno"). Noćenje.   3. do 9.dan VARADERO Boravak u hotelu na bazi "sve uključeno". Slobodni dani za kupanje, sunčanje i razonodu.  Za vreme boravka u Varaderu organizuju se raznovrsni fakultativni izleti. Noćenja.   10.dan  VARADERO - HAVANA Doručak. Polazak za Havanu u 10:00h. Usput, kratka pauza u restoranu “La Terraza” u Kohimaru,  a potom poseta Hemingvejevom imanju “La Vigia”. Nastavak putovanja i dolazak u Havanu u 15:00h.  Panoramsko razgledanje grada i obilazak tvrđave Moro. Smeštaj u hotelu. Noćenje.   11.dan HAVANA Doručak. Poludnevno razgledanje Havane, obilazak izmedju ostalog uključuje: Treću aveniju,  aveniju Malekon, fabriku ruma Bokoj, četvrt Sero, Univerzitet, hotel Habana Libre, ulicu Prado,  Centralni park, “Floriditu” (bar u kome je Hemingvej pio daikiri), Aveniju Puerto, Hotel Nasional,  itd. Tokom razgledanja odlazak na ručak. Slobodno vreme za samostalno upoznavanje Havane i  individualni povratak u hotel. Noćenje.   12.dan  HAVANA Doručak. Transfer do centra grada, a potom šetnja ulicama stare Havane: Trg Revolucije, Trg sa  Katedralom, Trg oružja i Trg Franje Asiškog. Slobodno vreme i povratak u hotel. Noćenje.   13.dan  HAVANA-ISTANBUL Doručak. Tranfer na aerodrom. Poletanje za Istanbul u 09.35h.   14.dan  ISTANBUL-BEOGRAD Sletanje u Istanbul u 10:10h. Nastavak putovanja za Beograd u 19.45h. Sletanje u 19.25h.', 5, 1, 1, 14, 11, 1930, 9)
SET IDENTITY_INSERT [dbo].[Arrangements] OFF

SET IDENTITY_INSERT [dbo].[AspNetUsers] ON
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'542aadfa-bb35-4d57-8ac2-f6d350412e92', N'admin@uta.com', 0, N'AE19ERA+IGEVhqAaiznbU/oglVeugCMyg0Xk/+XhzGyUfjSPQFtWJbwcCwERqZvY0Q==', N'74b0d40e-0267-43f1-b556-eca0429f33ab', NULL, 0, 0, NULL, 1, 0, N'admin@uta.com')
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF