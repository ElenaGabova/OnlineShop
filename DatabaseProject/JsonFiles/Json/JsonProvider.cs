using Database.Constants;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Database.Models
{
    public static class JsonProvider
    {
        /// <summary>
        /// Deserialize <T> type, return T type 
        /// </summary>
        /// <typeparam name="T">type to deserizlize</typeparam>
        /// <param name="fileName">json file name</param>
        /// <returns></returns>
        /// <exception cref="Exception">Json deserialize error message</exception>
        public static T Deserialize<T>(string fileName)
        {
            fileName = DatabaseConstants.JsonFilePath + fileName;
            string jsonData = FileProvider.ReadDataFromFile(fileName);

            try
            {
                return JsonSerializer.Deserialize<T>(jsonData);
            }
            catch
            {
                throw new Exception(string.Format("Не удалось преобразовать файл '{0}' из формата json.&quot;", fileName));
            }
        }

        /// <summary>
        /// Serialize data to json file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tObject">Object for serialize</param>
        /// <param name="fileName">json file name</param>
        /// <exception cref="Exception"></exception>
        public static void Serialize<T>(T tObject, string fileName)
        {
            string jsonData = string.Empty;
            fileName = DatabaseConstants.JsonFilePath + fileName;
       
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true,
            };

            jsonData = JsonSerializer.Serialize<T>(tObject, options);
            try
            {
                FileProvider.WriteDataToFile(fileName, jsonData);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
