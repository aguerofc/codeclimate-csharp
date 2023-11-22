using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace BAS.AuditJournal.Infrastructure.Utils
{
    public static class Helpers
    {
        static readonly byte[] iv = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static readonly byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7 };
       
        public static string GetConnectionString()
        {
            AesManaged aesAlg = new()
            {
                Key = key,
                IV = iv
            };

            MemoryStream memoryStream = new();
            CryptoStream cryptoStream = new(memoryStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Write);


            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                     .AddJsonFile("appsettings.json")
                                                     .Build();

            string constring = configuration.GetConnectionString("DBConnection");

            byte[] InputBytes = Convert.FromBase64String(constring);
            cryptoStream.Write(InputBytes, 0, InputBytes.Length);
            cryptoStream.FlushFinalBlock();

            byte[] Decrypted = memoryStream.ToArray();
            return Encoding.UTF8.GetString(Decrypted, 0, Decrypted.Length);
        }
    }
}
