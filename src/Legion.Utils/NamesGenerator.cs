using System;

namespace Legion.Utils
{
    // ROB_IMIE
    public class NamesGenerator
    {
        private static readonly char[] Vowels = { 'a', 'e', 'i', 'o', 'u', 'i', 'a', 'a', 'e', 'o' };
        private static readonly char[] Consonants = { 'c', 'f', 'h', 'k', 'p', 's', 't', 'p', 'j', 's', 's', 'k', 't', 'p', 't', 'f', 'b', 'd', 'g', 'l', 'm', 'n', 'r', 'w', 'z', 'r', 'r', 'r', 'd', 'z', 'b', 'g' };

        public static string Generate()
        {
            string name = "";

            var dl = GlobalUtils.Rand(2) + 1;
            for (var i = 0; i < dl; i++)
            {
                var vow = Vowels[GlobalUtils.Rand(Vowels.Length - 1)].ToString();
                var con = Consonants[GlobalUtils.Rand(Consonants.Length - 1)].ToString();

                var a = GlobalUtils.Rand(2);
                if (a == 0)
                {
                    name += vow + con;
                }
                else if (a == 1)
                {
                    name += con + vow;
                }
                else
                {
                    name += vow;
                }
            }

            name = Char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }
    }
}