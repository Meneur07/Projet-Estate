using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateManager.DataAccess
{
    class ConnectionContext
    {
        public static Models.User ConnectedUser { get; set; }
    }
}
