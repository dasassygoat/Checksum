using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Checksum
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new FileInfo(args[0]);
            using (var encodedFile = new SHA256Managed())
            {
                using (FileStream fStream = file.Open(FileMode.Open))
                {
                    fStream.Position = 0;
                    var hash = encodedFile.ComputeHash(fStream);

                    System.Console.WriteLine(getGashString(hash));
                }
            }

                
            //Console.ReadKey();
        }

        private static string getGashString(byte[] hash)
        {
            StringBuilder outVal = new StringBuilder();
            foreach(var b in hash)
            {
                outVal.Append(b.ToString("X2"));
            }

            return outVal.ToString();
        }
    }
}


//for (int i = 0; i<array.Length; i++)
//        {
//            Console.Write($"{array[i]:X2}");
//            if ((i % 4) == 3) Console.Write(" ");
//        }
//        Console.WriteLine();