using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лб7_2сем__ч3
{
    using System;

    public class ACipher : ICipher
    {
        public string Encode(string input)
        {
            char[] encodedChars = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLetter(c))
                {
                    encodedChars[i] = (char)(c + 1);
                    if (c == 'Z') encodedChars[i] = 'A';
                    else if (c == 'z') encodedChars[i] = 'a';
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
                    decodedChars[i] = (char)(c - 1);
                    if (c == 'A') decodedChars[i] = 'Z';
                    else if (c == 'a') decodedChars[i] = 'z';
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
