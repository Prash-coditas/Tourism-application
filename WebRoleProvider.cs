using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Tourism_1.Models;
using Tourism_1.Services;

namespace Tourism_1
{
    public class WebRoleProvider : RoleProvider
    {
        TourismEntities5 context;
        UserdataAccess userdata;
        RolesdataAccess roledata;
        public WebRoleProvider()
        {
            context = new TourismEntities5();
            userdata = new UserdataAccess();
            roledata = new RolesdataAccess();

        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public override string[] GetRolesForUser(string username)
        {
            var alluserdata = userdata.GetAllUser();

            var result = (from role in roledata.Allroles()
                          join user in alluserdata on role.RoleId equals user.RoleId
                          where user.UserName == username
                          select role.RoleTitle).ToArray();
            return result;



        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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