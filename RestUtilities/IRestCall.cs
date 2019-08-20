using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace RestUtilities
{
    public interface IRestCall
    {
        string DoGet();

        string DoPost(object body);
    }
}
