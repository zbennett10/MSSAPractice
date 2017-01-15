using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball.Data.Sql
{
    public interface ISecurity //verifies legitimacy of user information
    {
        Person Authenticate(string username, string password);
    }
}
