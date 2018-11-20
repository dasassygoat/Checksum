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
            while (args.Length < 1)
            {
                Console.Write("File path ==> ");
                var inputPath = Console.ReadLine();
                if (inputPath.Trim() != "")
                {
                    args = new string[] { inputPath.Trim() };
                }
            }
            var file = new FileInfo(args[0]);
            var format = "X2";
            var sha256 = new SHA256Managed();
            EncodeFile<SHA256>(sha256, file, format);
        }

        /// <summary>
        /// Generic function to actually do the encoding of the file with the specified hash algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="encryptionType"></param>
        /// <param name="file"></param>
        /// <param name="fmt"></param>
        private static void EncodeFile<T>(T encryptionType, FileInfo file, string fmt = "") where T : HashAlgorithm
        {
            try
            {
                using (T encodedFile = encryptionType)
                {
                    using (FileStream fStream = file.Open(FileMode.Open))
                    {
                        fStream.Position = 0;
                        var hash = encodedFile.ComputeHash(fStream);

                        System.Console.WriteLine(getGashString(hash, fmt));
                    }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File was unable to be used for hashing.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured during operaion. Please see following exception for more information.");
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Convert each element of the hash byte array into a string using the option fmt string parameter 
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="fmt"></param>
        /// <returns></returns>
        private static string getGashString(byte[] hash, string fmt)
        {
            StringBuilder outVal = new StringBuilder();
            foreach (var b in hash)
            {
                outVal.Append(b.ToString(fmt));
            }

            return outVal.ToString();
        }
    }
}