using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ValuesListEnumerate
{
    class ValInKey
    {
        public const string KeyName = @"Software\Kate Iskra\AppWithSense\StringValues";

        static void SaveList(List<string> strList)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyName))
                {
                    int counter = 1;
                    foreach (var str in strList)
                        key.SetValue($"Item{counter++}", str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static List<string> GetList()
        {
            List<string> strList = new List<string>();

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(KeyName))
                {
                    foreach (string valueName in key.GetValueNames())
                        strList.Add(key.GetValue(valueName).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return strList;
        }

        static void Main(string[] args)
        {
            List<string> strList = new List<string>();

            strList.Add("small str");
            strList.Add("a big string");
            strList.Add("bigger string");
            strList.Add("the biggest string");

            SaveList(strList);

            strList.Clear();

            strList = GetList();

            foreach (var str in strList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
