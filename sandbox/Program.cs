using System;
using System.Linq;
using System.Text;
using System.IO;

namespace sandbox
{
    class Program
    {
        static Random _rdm = new Random();
        static void Main(string[] args)
        {
            GenerateEmail generateEmail = new GenerateEmail();
            generateEmail.CreateFileWithEmails(4, 6);
            GenerateSQLInsert generateSQLInsert = new GenerateSQLInsert($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/TestMam/");
            generateSQLInsert.GenerateSQLInsertFromFolder("autogenerate");
        }
        
    }
}




