using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.ComponentModel;

namespace FSISSystem.BLL
{
    [DataObject]
    public class GuardianController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Guardian> Guardian_List()
        {
            using (var context = new FSISContext())
            {
                return context.Guardians.ToList();
            }
        }
    }
}
