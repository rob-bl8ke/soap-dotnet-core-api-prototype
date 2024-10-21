using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoapApi
{
    public class MySoapService : IMySoapService
    {
        public string HelloWorld(string name)
        {
            return $"Hello, {name}!";
        }
    }
}