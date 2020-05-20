using System;
using Microsoft.Win32;
using System.Diagnostics;

namespace SystemTimeProj
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(System.DateTime.Now);

            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Kate Iskra\TimeApp"))
                {
                    key.SetValue("SystemTimeProj", $"{System.DateTime.Now}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run"))
                {
                    key.SetValue("SystemTimeProj", Process.GetCurrentProcess().MainModule.FileName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
