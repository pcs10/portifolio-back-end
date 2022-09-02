using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashSenha
{

    public class Hash
    {
      /*  private static RSACryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        byte[] salt = new byte[16];
        rngCsp.GetBytes(salt);

            Console.WriteLine("Informe a senha");
            var senha = Console.ReadLine();

        var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, 1000);

        byte[] hash = pbkdf2.GetBytes(20);
        byte[] hashBytes = new byte[36];

        Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashSenha = Convert.ToBase64String(hashBytes);

        Console.WriteLine($"\nHash da senha gerado : {hashSenha}");

            Console.ReadKey();
      */
    }
}
