using System;
using System.Web.Security;

namespace KnowledgeTestingApplication.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            var user = DataAcess.TestManagment.GetUser(username);
            if (user != null && user.Role != null)
            {
                // получаем роль
                roles = new string[user.Role.Count];
                for (int i = 0; i < roles.Length; i++)
                {
                    roles[i] = user.Role[i].ToString();
                }
            }
            return roles;
            
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            var user = DataAcess.TestManagment.GetUser(username);

            if (user != null && user.Role != null)
            {
                foreach (var role in user.Role)
                {
                    if (role.ToString() == roleName)
                    {
                        return true;
                    }
                    
                    return false;
                }
            }

            return false;

        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}