using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__ч3
{
    using System;

    public class BCipher : ICipher
    {
        public string Encode(string input)
        {
            char[] encodedChars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        encodedChars[i] = (char)('Z' - (c - 'A'));
                    }
                    else
                    {
                        encodedChars[i] = (char)('z' - (c - 'a'));
                    }
                }
                else
                {
                    encodedChars[i] = c;
                }
            }

            return new string(encodedChars);
        }

        public string Decode(string input)
        {
            char[] decodedChars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLetter(c))
                {
                    if (char.IsUpper(c))
                    {
                        decodedChars[i] = (char)('A' + ('Z' - c));
                    }
                    else
                    {
                        decodedChars[i] = (char)('a' + ('z' - c));
                    }
                }
                else
                {
                    decodedChars[i] = c;
                }
            }
            return new string(decodedChars);
        }
    }

}
