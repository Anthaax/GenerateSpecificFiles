using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace sandbox
{
    public class GenerateSQLInsert
    {
        readonly string _folderPath;
        readonly string _tableName = "MarketingActionEmailMapping";
        public GenerateSQLInsert(string folderPath)
        {
            _folderPath = folderPath;
        }
        public void GenerateSQLInsertFromFolder(string generateFileName)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in Directory.GetFiles(_folderPath))
            {
                builder.AppendLine(CreateSQlInsertForFile(item));
            }
            File.WriteAllText($"{_folderPath}/{generateFileName}.sql", builder.ToString());
        }
        private string CreateSQlInsertForFile(string filePath)
        {
            StringBuilder builder = new StringBuilder();
            var splitContent = File.ReadLines(filePath).SplitList(1000);
            foreach (var item in splitContent)
            {
                builder.AppendLine(MultipleInsertCreation(item, ';'));
            }
            return builder.ToString();
        }
        private string MultipleInsertCreation(List<string> contentToInsert, char splitChar = char.MinValue)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Insert into {_tableName}");
            builder.AppendLine($"Values");
            for (int i = 0; i < contentToInsert.Count; i++)
            {
                string values = contentToInsert[i].Remove(contentToInsert[i].LastIndexOf(splitChar)).Replace(splitChar, ',');
                if(i != contentToInsert.Count - 1)
                {
                    builder.AppendLine($"({values},GetDate(),GetDate()),");
                }
                else
                {
                    builder.AppendLine($"({values},GetDate(),GetDate());");
                }
            }
            return builder.ToString();
        }
    }
}
