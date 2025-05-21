using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__ч3
{
    public interface ICipher
    {
        string Encode(string input); 
        string Decode(string input);
    }
}
