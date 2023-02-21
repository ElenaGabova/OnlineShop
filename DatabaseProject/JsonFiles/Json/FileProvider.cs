
using System;
using System.IO;

namespace Database.Models
{
    internal static class FileProvider
    {
        /// <summary>
        /// Read data from file
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal static string ReadDataFromFile(string fileName)
        {
            if (FileExists(fileName))
                return File.ReadAllText(fileName);

            throw new Exception(string.Format("Файл с названием '{0}' удален, или не существет", fileName));
        }

        /// <summary>
        /// Is file exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static bool FileExists(string fileName)
        {
            return File.Exists(fileName);
        }

        /// <summary>
        /// Write data to file
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal static void WriteDataToFile(string fileName, string data)
        {
            if (FileExists(fileName))
                File.WriteAllText(fileName, data);
           else
                throw new Exception(string.Format("Файл с названием '{0}' удален, или не существет", fileName));
        }
    }
}
