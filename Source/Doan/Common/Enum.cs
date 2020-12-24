using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doan.Common
{
    enum ActionPagination
    {
        Previus,
        Next,
        Load,
        Create,
        Delete,
        Update,
        Import,
        FindProduct,
        TabSwitch
    }

    enum ActionProduct
    {
        GetAll,
        Reload,
        FilterByCategory,
        FilterByCategoryAndName,
        FilterByName,
        Create,
        Update,
        Delete
    }

    enum ActionCategory
    {
        Update,
        Delete
    }

    enum ActionOrder
    {
        Create,
        Update,
        Delete,
        Reload
    }

    enum RoleId
    {
       SupperAdmin = 1,
       Manager = 2,
       Client = 3
    }
}
