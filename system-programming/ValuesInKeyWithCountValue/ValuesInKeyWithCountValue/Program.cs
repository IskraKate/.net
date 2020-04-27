using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace ValuesInKeyWithCountValue
{
    class Program
    {
        public const string KeyName = @"Software\Kate Iskra\MyPerfectApp";

        static void Main(string[] args)
        {
            SaveList(new List<string>()
            {
            @"C:\Users\katei\test1.txt",
            @"C:\Users\katei\test2.txt",
            @"C:\Users\katei\test3.txt",
            @"C:\Users\katei\test4.txt",
            @"C:\Users\katei\test5.txt"
            });

            var list = GetList();

            foreach (var item in list)
                Console.WriteLine(item);
        }


        static void SaveList(List<string> list)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyName))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        key.SetValue($"Item{i + 1}", list[i]);
                    }
                    key.SetValue("Count", list.Count, RegistryValueKind.DWord);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static List<string> GetList()
        {
            var list = new List<string>();

            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(KeyName))
            {
                int count = (int)key.GetValue("Count", RegistryValueKind.DWord);

                for (int i = 0; i < count; i++)
                    list.Add(key.GetValue($"Item{i + 1}").ToString());
            }
            return list;
        }
    }
}
