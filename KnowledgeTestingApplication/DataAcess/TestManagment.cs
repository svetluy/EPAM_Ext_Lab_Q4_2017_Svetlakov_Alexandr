using DataAcess.DomainModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess
{
    public static class TestManagment
    {
        private static readonly string GetAnswerOptionsDbCommand = "select AnswerOptionID, AnswerOptions from dbo.Questions where questionId = {0} and testId = {1}";
        private static readonly string GetUserChoiceDbCommand = "select UserChoice from dbo.Questions where questionId = {0} and testId = {1}";
        private static readonly string GetRightAnswersDbCommand = "select RightAnswers from dbo.Questions where questionId = {0} and testId = {1}";
        private static readonly string GetQuestionTextDbCommand = "select QuestionText from dbo.Questions where questionId = {0} and testId = {1}";
        private static readonly string GetQuestionListDbCommand = "select distinct QuestionID from dbo.Questions where testid = {0}";
        private static readonly string GetTestDbCommand = "select testname, testtime from dbo.Test where testid = {0}";
        private static readonly string GetTestsForPageDbCommand = "select top({1}) testid from dbo.Test where testid not in (select top(({0}-1)*{1}) testid from dbo.Test)";
        private static readonly string IsCheckboxedDbCommand = "select Checkboxed from dbo.Questions where questionId = {0} and testId = {1}";
        private static readonly string SetUserChoiceDbCommand = "update [TestingAppDB].[dbo].[Questions]  SET [UserChoice] = '{0}' where TestID = {1} and QuestionID = {2} and AnswerOptionID = {3}";
        private static readonly string ClearUserChoiceDBCommand = "update [TestingAppDB].[dbo].[Questions]  SET [UserChoice] = null where TestID = {0}";
        private static readonly string GetUserDbCommand = "select [ID],[Email],[Password],[Name] from [TestingAppDB].[dbo].[User] where Email = '{0}'";
        private static readonly string GetUserRolesDbCommand = "select [RoleID] from [TestingAppDB].[dbo].[UserRole] where UserID = {0}";
        private static readonly string CreateUserDbCommand = "insert into [TestingAppDB].[dbo].[User]([Email],[Password],[Name]) values ('{0}','{1}','{2}')";
        private static readonly string SetUserRoleDbCommand = "insert into [TestingAppDB].[dbo].[UserRole]([UserID],[RoleID]) values ({0},{1})";
        private static readonly string GetUsersListDbCommand = "SELECT [Email] FROM[TestingAppDB].[dbo].[User]";
        private static readonly string DeleteUserDbCommand = "delete FROM [TestingAppDB].[dbo].[User] where ID = {0}";

        private static DbConnection CreateConnection()
        {
            var connectionStringItem = ConfigurationManager.ConnectionStrings["TestingAppDBConnection"];
            var connectionString = connectionStringItem.ConnectionString;
            var providerName = connectionStringItem.ProviderName;
            var factory = DbProviderFactories.GetFactory(providerName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public static bool ClearUserChoice(int testId)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                connection.Open();
                command.CommandText = string.Format(ClearUserChoiceDBCommand, testId);
                command.ExecuteNonQuery();
                return true;
            }
        }
        private static string GetQuestionText(int questionId, int testId)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetQuestionTextDbCommand, questionId, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                string qText = string.Empty;
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    return Convert.ToString(values[0]);
                }
                return qText;
            }
        }
        private static Dictionary<int, string> GetAnswerOptions(int questionId, int testId)
        {
            var optionsList = new Dictionary<int, string>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetAnswerOptionsDbCommand, questionId, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    var value = Convert.ToString(values[1]);
                    if (value != string.Empty)
                    {
                        optionsList.Add(Convert.ToInt32(values[0]), value);
                    }
                    
                }
            }
            return optionsList;
        }
        private static bool IsCheckboxed(int questionId, int testId)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(IsCheckboxedDbCommand, questionId, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                bool checkboxed = false;
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    return Convert.ToBoolean(values[0]);
                }
                return checkboxed;
            }
        }
        public static List<string> GetUserChoice(int questionId, int testId)
        {
            var userChoiceList = new List<string>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText =string.Format(GetUserChoiceDbCommand, questionId, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    var value = Convert.ToString(values[0]);
                    if (value != string.Empty)
                    {
                        userChoiceList.Add(value);
                    }
                   
                }
            }
            return userChoiceList;
        }
        public static List<string> GetRightAnswers(int questionId, int testId)
        {
            var rightAnswersList = new List<string>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetRightAnswersDbCommand, questionId, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    var value = Convert.ToString(values[0]);
                    if (value != string.Empty)
                    {
                        rightAnswersList.Add(value);
                    }
                }
            }
            return rightAnswersList;
        }
        public static List<int> GetQuestionList(int testId)
        {
            var questionList = new List<int>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetQuestionListDbCommand, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    questionList.Add(Convert.ToInt32(values[0]));
                }
            }
            return questionList;
        }
        public static Test GetTest(int testId)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetTestDbCommand, testId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                int? testTime = null;
                string testName = string.Empty;
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    testName = Convert.ToString(values[0]);
                    testTime = values[1] as int?;
                }
                var test = new Test
                {
                    TestName = testName,
                    TestId = testId,
                    TestTime = testTime
                };
                return test;
            }
        }
        public static bool SetUserChoice(int testId, int questionId, string[] userChoice)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                connection.Open();
                for (int i = 0; i < userChoice.Length; i++)
                {
                    if (userChoice[i] != null)
                    {
                        command.CommandText = string.Format(SetUserChoiceDbCommand, userChoice[i], testId, questionId, i + 1);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
        }
        public static Question GetQuestion(int testId, int questionId)
        {
            return new Question
            {
                QuestionId = questionId,
                TestId = testId,
                QuestionText = GetQuestionText(questionId, testId),
                AnswerOptions = GetAnswerOptions(questionId, testId),
                UserChoice = GetUserChoice(questionId, testId),
                RightAnswer = GetRightAnswers(questionId, testId),
                Checkboxed = IsCheckboxed(questionId, testId)
            };
        }
        public static List<string> GetUsersList()
        {
            var usersList = new List<string>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = GetUsersListDbCommand;
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    usersList.Add(Convert.ToString(values[0]));
                }
            }
            return usersList;
        }
        public static User GetUser(string login)
        {
            var user = new User();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetUserDbCommand, login);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                var values = new object[reader.FieldCount];
                while (reader.Read())
                {
                    reader.GetValues(values);
                    user.Id = int.Parse(Convert.ToString(values[0]));
                    user.Email = Convert.ToString(values[1]);
                    user.Password = Convert.ToString(values[2]);
                    user.Name = Convert.ToString(values[3]);
                }
                if (Convert.ToString(values[0]) == string.Empty)
                {
                    return null;
                }
            }
            user.Role = GetUserRoles(user.Id);
            return user;
        }
        public static bool CreateUser(User user)
        {
            int userId;
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                connection.Open();
                user.Password = user.Password;
                command.CommandText = string.Format(CreateUserDbCommand, user.Email, user.Password, user.Name);
                command.ExecuteNonQuery();
                command.CommandText = string.Format("select [ID] from [TestingAppDB].[dbo].[User] where Email = '{0}'", user.Email);
                userId = Convert.ToInt32(command.ExecuteScalar());
            }
            return true;
        }

        public static void SetUserRole(int userId, Role role)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                connection.Open();

                command.CommandText = string.Format(SetUserRoleDbCommand, userId, (int)role);
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteUser(int userId)
        {
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                connection.Open();

                command.CommandText = string.Format(DeleteUserDbCommand, userId);
                command.ExecuteNonQuery();
            }
        }
        public static List<Role> GetUserRoles(int userId)
        {
            var roles = new List<Role>();
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetUserRolesDbCommand, userId);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    roles.Add((Role)Convert.ToInt32(values[0]));
                }
            }
            return roles;
        }
        public static List<Test> GetTestsForPage(int pageNum = 1, int testsOnPage = 4)
        {
            using (var connection = CreateConnection())
            {
                var testIds = new List<int>();
                var tests = new List<Test>();
                var command = connection.CreateCommand();
                command.CommandText = string.Format(GetTestsForPageDbCommand, pageNum, testsOnPage);
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    testIds.Add(Convert.ToInt32(values[0]));
                }
                foreach (var testId in testIds)
                {
                    tests.Add(new Test
                    {
                        TestName = GetTest(testId).TestName,
                        TestId = testId
                    });
                }
                return tests;
            }
        }
        public static int GetTestsCount()
        {
            int testsCount = 0;
            using (var connection = CreateConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "select count(*) from dbo.Test";
                connection.Open();
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    testsCount = Convert.ToInt32(values[0]);
                }
            }
            return testsCount;
        }
    }
}
