using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace sandbox
{
    public class GenerateEmail
    {
        readonly private Random _rdm;
        public GenerateEmail()
        {
            _rdm = new Random();
        }
        public void CreateFileWithEmails(int firstPow, int lastpow)
        {
            for (int i = firstPow; i <= lastpow; i++)
            {
                File.WriteAllText($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/TestMam/testMAM{(int)Math.Pow(10, i)}.csv",
                    GenarateMultipleEmails((int)Math.Pow(10, i)));

            }
        }
        private string GenarateMultipleEmails(int length)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.AppendLine($"{GenerateOneEmail(15)}{length};");
            }
            return stringBuilder.ToString();
        }
        private string GenerateOneEmail(int length)
        {
            return $"{GenerateRandomString(length)}@{GenerateRandomString(length)}.{GenerateRandomString(5)};";
        }
        private string GenerateRandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_rdm.Next(s.Length)]).ToArray());
        }
    }
}
