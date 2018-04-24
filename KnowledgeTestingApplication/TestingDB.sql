--DataBase Name TestingAppDB

CREATE TABLE [dbo].[Test] (
    [TestID]   INT            IDENTITY (1, 1) NOT NULL,
    [TestName] NVARCHAR (200) NOT NULL,
    [TestTime] INT            NULL,
    PRIMARY KEY CLUSTERED ([TestID] ASC)
);

INSERT [TestingAppDB].[dbo].[Test] ([TestName],[TestTime]) VALUES ('«Базы данных»', 20)
INSERT [TestingAppDB].[dbo].[Test] ([TestName],[TestTime]) VALUES ('«Информационные технологии»', null)
INSERT [TestingAppDB].[dbo].[Test] ([TestName],[TestTime]) VALUES ('«Организация ЭВМ и систем»', null)
INSERT [TestingAppDB].[dbo].[Test] ([TestName],[TestTime]) VALUES ('«Защита информации»', null)
INSERT [TestingAppDB].[dbo].[Test] ([TestName],[TestTime]) VALUES ('«Информатика»', null) 

CREATE TABLE [dbo].[Questions] (
    [TestID]         INT            NOT NULL,
    [QuestionID]     INT            NOT NULL,
    [QuestionText]   NVARCHAR (MAX) NULL,
    [AnswerOptionID] INT            NOT NULL,
    [AnswerOptions]  NVARCHAR (500) NULL,
    [UserChoice]     NVARCHAR (500) NULL,
    [RightAnswers]   NVARCHAR (500) NULL,
    [Checkboxed]     BIT            NULL,
    CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED ([QuestionID] ASC, [TestID] ASC, [AnswerOptionID] ASC),
    CONSTRAINT [FK_Questions_Test] FOREIGN KEY ([TestID]) REFERENCES [dbo].[Test] ([TestID]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[User] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Email]    NVARCHAR (150) NOT NULL,
    [Password] NVARCHAR (200) NOT NULL,
    [Name]     NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

insert into [TestingAppDB].[dbo].[User]([Email],[Password],[Name]) values ('Admin@admin.ru','AKOuxJQaGg7D3nqjwCFIBuXPoty3FLEjd7fchIyJwNNlCAFTHQsbPOmcdf+Ee89yLA==','John Smith')
insert into [TestingAppDB].[dbo].[User]([Email],[Password],[Name]) values ('User@user.ru','AJqT8vfWgWlytcCrkb0s9ehzlk1vbyjX0AAqo7Tj6eUkWe8hzRJ3AImiW5m5pxtuYA==','Alice Cooper')

CREATE TABLE [dbo].[Role] (
    [ID]   INT           IDENTITY (0, 1) NOT NULL,
    [NAME] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([ID] ASC)
);

insert into [TestingAppDB].[dbo].[Role]([NAME]) values ('User')
insert into [TestingAppDB].[dbo].[Role]([NAME]) values ('Admin')

CREATE TABLE [dbo].[UserRole] (
    [ID]     INT IDENTITY (1, 1) NOT NULL,
    [UserID] INT NOT NULL,
    [RoleID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

insert into [TestingAppDB].[dbo].[UserRole]([UserID],[RoleID]) values (1,0)
insert into [TestingAppDB].[dbo].[UserRole]([UserID],[RoleID]) values (1,1)
insert into [TestingAppDB].[dbo].[UserRole]([UserID],[RoleID]) values (0,1)

INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,1,'Запросы, которые содержат набор критериев для нахождения интересующих пользователя данных из одной или более таблиц, — это:',1,'запросы на выборку дубликатов','запросы на выборку',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,2,'запросы на выборку')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,3,'запросы с обобщением')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,4,'параметрические запросы')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,2,'Поименованная, целостная, единая система данных, организованная по определенным правилам, которые предусматривают общие принципы описания, хранения и обработки данных, называется:',1,'реляционной базой данных','базой данных',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,2,'базой знаний')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,3,'базой данных')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,4,'СУБД')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,3,'Правило запрета обходных путей относится к:',1,'правилам целостности','фундаментальным правилам',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,2,'правилам независимости от данных')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,3,'структурным правилам')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,4,'фундаментальным правилам')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,4,'Язык, позволяющий производить задание образцов значений в шаблоне запроса, предусматривающем тот тип доступа к базе данных, который требуется в данный момент, называется:',1,'SQL','QBE',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,2,'DDL')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,3,'DML')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,4,'QBE')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,5,'Связь, которая подразумевает соотношение целого и его частей, называется:',1,'противопоставлением','партитивностью',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,2,'общностью')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,3,'функциональной взаимосвязью')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,4,'партитивностью')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,6,'Запуск службы с правами операционной системы предполагает права учетной записи типа',1,'User for Domain','Local System',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,2,'Local System')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,3,'Local User')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,4,'User for Domain, Local System, Local User')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,7,'Пятью основными операциями реляционной алгебры являются:',1,'выборка','выборка',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,2,'деления','проекция')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,3,'проекция','декартово произведение')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,4,'пересечения','объединение и разность')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,5,'декартово произведение')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,6,'объединение и разность')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,7,'объединение и соединения')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,8,'К текстовым типам данных относятся:',1,'char','text',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,8,2,'varchar','ntext')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,3,'text')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,4,'nvarchar')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,4,'ntext')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (1,9,'Кодд предложил __________________ правил(-а) определения реляционных систем.',1,'12',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (1,10,'Все строки в SQL вводятся с использованием команды модификации',1,'INSERT',0)


INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,1,'Если условия ограничений целостности данных выполняются, то происходит:',1,'запрос на изменение данных','фиксация транзакции',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,2,'изменение данных')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,3,'фиксация транзакции')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,4,'"откат" транзакции')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,2,'Основная часть данных базируется на внешних источниках в моделях:',1,'стратегических','стратегических',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,2,'ввод команд')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,3,'язык пользователя')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,4,'язык сообщений')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,3,'Действия пользователя в отношении системы путем использования периферийных устройств называются:',1,'ввод данных','язык пользователя',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,2,'правилам независимости от данных')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,3,'структурным правилам')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,4,'фундаментальным правилам')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,4,'Описание ситуаций и характеристики поведения системы используют _________ ЭС',1,'проектирующие','диагностические',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,2,'диагностические')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,3,'интерпретирующие')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,4,'прогнозирующие')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,5,'Из перечисленного, в языке Пролог типы данных включают:',1,'объекты','структуры',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,5,2,'переменные','атомарные значения')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,5,3,'структуры')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,5,4,'атомарные значения')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,6,'Основная идея реплицирования заключается в том, что пользователи работают:',1,'автономно с одинаковыми данными','автономно с одинаковыми данными',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,2,'автономно каждый со своим экземпляром данных')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,3,'автономно с одинаковыми данными')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,4,'совместно с одинаковыми данными')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,7,'В CASE-системах активно применяются нотации:',1,'VRML','IDEF',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,2,'IEEED')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,3,'IDEF')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,4,'UML')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,8,'Из перечисленного по степени охвата задач управления ИТ делятся на:',1,'электронная обработка данных','электронная обработка данных',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,8,2,'представление данных','электронный офис')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,8,3,'электронный офис','поддержка принятия решений')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,8,4,'поддержка принятия решений')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,8,5,'реализация в АИС')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (2,9,'Для применения в экономической области был создан язык программирования:',1,'Кобол',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (2,10,'Адаптивно руководят поведением системы в целом ЭС, осуществляющие:',1,'управление',0)
