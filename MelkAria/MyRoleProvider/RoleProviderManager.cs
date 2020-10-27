using MelkAria.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MelkAria.MyRoleProvider
{
     public class RoleProviderManager : RoleProvider
    {
        DataBaseContext db = new DataBaseContext();

        public override bool IsUserInRole(string username, string roleName)
        {
            return db.Users.Include("role").Any(p => p.userNamee == username && p.role.RoleNameEn== roleName);
        }
        public override string[] GetRolesForUser(string username)
        {
            var role = db.Users.Include("role").Where(p => p.userNamee == username).Select(p => new { p.role.RoleNameEn });
            return new[] { role.FirstOrDefault().RoleNameEn };
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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