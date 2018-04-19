--DataBase Name TestingAppDB

CREATE TABLE [dbo].[Test] (
    [TestID]   INT            IDENTITY (1, 1) NOT NULL,
    [TestName] NVARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([TestID] ASC)
);

INSERT [TestingAppDB].[dbo].[Test] ([TestName]) VALUES ('����� �������')
INSERT [TestingAppDB].[dbo].[Test] ([TestName]) VALUES ('��������������� ����������')
INSERT [TestingAppDB].[dbo].[Test] ([TestName]) VALUES ('������������ ��� � ������')
INSERT [TestingAppDB].[dbo].[Test] ([TestName]) VALUES ('������� ����������')
INSERT [TestingAppDB].[dbo].[Test] ([TestName]) VALUES ('������������')

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
    [Password] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[UserRole] (
    [ID]     INT IDENTITY (1, 1) NOT NULL,
    [UserID] INT NOT NULL,
    [RoleID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,1,'�������, ������� �������� ����� ��������� ��� ���������� ������������ ������������ ������ �� ����� ��� ����� ������, � ���:',1,'������� �� ������� ����������','������� �� �������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,2,'������� �� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,3,'������� � ����������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,1,4,'��������������� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,2,'�������������, ���������, ������ ������� ������, �������������� �� ������������ ��������, ������� ��������������� ����� �������� ��������, �������� � ��������� ������, ����������:',1,'����������� ����� ������','����� ������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,2,'����� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,3,'����� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,2,4,'����')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,3,'������� ������� �������� ����� ��������� �:',1,'�������� �����������','��������������� ��������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,2,'�������� ������������� �� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,3,'����������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,3,4,'��������������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,4,'����, ����������� ����������� ������� �������� �������� � ������� �������, ����������������� ��� ��� ������� � ���� ������, ������� ��������� � ������ ������, ����������:',1,'SQL','QBE',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,2,'DDL')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,3,'DML')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,4,4,'QBE')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,5,'�����, ������� ������������� ����������� ������ � ��� ������, ����������:',1,'�������������������','��������������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,2,'���������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,3,'�������������� ������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,5,4,'��������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,6,'������ ������ � ������� ������������ ������� ������������ ����� ������� ������ ����',1,'User for Domain','Local System',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,2,'Local System')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,3,'Local User')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,6,4,'User for Domain, Local System, Local User')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,7,'����� ��������� ���������� ����������� ������� ��������:',1,'�������','�������',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,2,'�������','��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,3,'��������','��������� ������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,7,4,'�����������','����������� � ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,5,'��������� ������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,6,'����������� � ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,7,7,'����������� � ����������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,8,'� ��������� ����� ������ ���������:',1,'char','text',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (1,8,2,'varchar','ntext')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,3,'text')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,4,'nvarchar')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (1,8,4,'ntext')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,9,'���� ��������� __________________ ������(-�) ����������� ����������� ������.',1,'12',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (1,10,'��� ������ � SQL �������� � �������������� ������� �����������',1,'INSERT',0)


INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,1,'���� ������� ����������� ����������� ������ �����������, �� ����������:',1,'������ �� ��������� ������','�������� ����������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,2,'��������� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,3,'�������� ����������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,1,4,'"�����" ����������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,2,'�������� ����� ������ ���������� �� ������� ���������� � �������:',1,'��������������','��������������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,2,'���� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,3,'���� ������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,2,4,'���� ���������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,3,'�������� ������������ � ��������� ������� ����� ������������� ������������ ��������� ����������:',1,'���� ������','���� ������������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,2,'�������� ������������� �� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,3,'����������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,3,4,'��������������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,4,'�������� �������� � �������������� ��������� ������� ���������� _________ ��',1,'�������������','���������������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,2,'���������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,3,'����������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,4,4,'��������������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,5,'�� ��������������, � ����� ������ ���� ������ ��������:',1,'�������','���������',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,5,2,'����������','��������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,5,3,'���������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,5,4,'��������� ��������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,6,'�������� ���� �������������� ����������� � ���, ��� ������������ ��������:',1,'��������� � ����������� �������','��������� � ����������� �������',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,2,'��������� ������ �� ����� ����������� ������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,3,'��������� � ����������� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,6,4,'��������� � ����������� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,7,'� CASE-�������� ������� ����������� �������:',1,'VRML','IDEF',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,2,'IEEED')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,3,'IDEF')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,7,4,'UML')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[AnswerOptions],[RightAnswers],[CheckBoxed]) VALUES (2,8,'�� �������������� �� ������� ������ ����� ���������� �� ������� ��:',1,'����������� ��������� ������','����������� ��������� ������',1)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,8,2,'������������� ������','����������� ����')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions],[RightAnswers]) VALUES (2,8,3,'����������� ����','��������� �������� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,8,4,'��������� �������� �������')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[AnswerOptionID],[AnswerOptions]) VALUES (2,8,5,'���������� � ���')
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (2,9,'��� ���������� � ������������� ������� ��� ������ ���� ����������������:',1,'�����',0)
INSERT [TestingAppDB].[dbo].[Questions] ([TestID],[QuestionID],[QuestionText],[AnswerOptionID],[RightAnswers],[CheckBoxed]) VALUES (2,10,'��������� ��������� ���������� ������� � ����� ��, ��������������:',1,'����������',0)