using CryptSharp;
using System;
using System.Security.Cryptography;

namespace HashSenha
{
    class Program
    {
        public static string CalculaHash(string Senha)
        {
            try
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(Senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }
        public static class Criptografia
        {
            public static string Codifica(string senha)
            {
                return Crypter.MD5.Crypt(senha);
            }

            public static bool Compara(string senha, string hash)
            {
                return Crypter.CheckPassword(senha, hash);
            }
        }
        static void Main(string[] args)
        {
            // string senha = "123456";


            // Calcula a senha com base na string senha e armazena na string senhaCriptografada 
            // Neste caso senha = '123456' retorna string 'E10ADC3949BA59ABBE56E057F20F883E'
            // string senhaCriptografada = CalculaHash(senha);     

            //Console.WriteLine(senhaCriptografada); //esse funfou top

            //-----------------------------------------------------------------------------------------------------

            string senha = "123456";
            string senhaCriptografada;

            senhaCriptografada = Criptografia.Codifica(senha);
            //senha = "123789";

            Console.WriteLine("senha normal -> " + senha);
            Console.WriteLine("senha criptografada -> " + senhaCriptografada);

            if (Criptografia.Compara(senha, senhaCriptografada))
            {
                Console.WriteLine("correto");
            }
            else
            {
                Console.WriteLine("errado");
            }

        }
    }
}
