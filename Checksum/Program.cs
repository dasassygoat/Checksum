using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ChecksumEncoder;

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
            ChecksumEncoder.Encoder.EncodeFile<SHA256>(sha256, file, format);
        }
    }
}