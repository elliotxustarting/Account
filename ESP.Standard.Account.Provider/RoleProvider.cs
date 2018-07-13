using System;
using System.Collections.Generic;
using System.Linq;
using ESP.Standard.Account.Persistence;
using ESP.Standard.Account.Persistence.Entity;
using ESP.Standard.Account.Provider.Interface;
using ESP.Standard.Account.Provider.Model;
using ESP.Standard.Data.PostgreSql;

namespace ESP.Standard.Account.Provider
{
    /// <summary>
    /// Role provider.
    /// </summary>
    public class RoleProvider:IRoleProvider
    {
        private RoleDao _roleDao = new RoleDao();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ESP.Standard.Account.Provider.RoleProvider"/> class.
        /// </summary>
        public RoleProvider()
        {
        }

        public int CreateRole(int tenantId, int operatorId, Role role)
        {
            role.CreatedBy = operatorId;
            role.CreatedTime = DateTime.Now;
            role.UpdatedBy = operatorId;
            role.UpdatedTime = DateTime.Now;
            var entity = role.ToDataObject();
            return _roleDao.CreateRole(tenantId, operatorId, entity);
        }

        public Role GetRole(int tenantId, int operatorId, int id)
        {
            Role role = null;
            var roleDo = _roleDao.GetRole(tenantId, operatorId, id);
            if (role != null)
            {
                role = roleDo.ToBusinessObject();
            }
            return role;
        }

        public IList<Role> Search(int tenantId, int operatorId, PagingObject paging, List<SortedField> sortedFields)
        {
            return _roleDao.GetRoles(tenantId, operatorId, paging, sortedFields).Select(role => role.ToBusinessObject()).ToList();
        }

        public void UpdateRole(int tenantId, int operatorId, Role role)
        {
            role.UpdatedBy = operatorId;
            role.UpdatedTime = DateTime.Now;
            var entity = role.ToDataObject();
            _roleDao.UpdateRole(tenantId, operatorId, entity);
        }
    }
}
