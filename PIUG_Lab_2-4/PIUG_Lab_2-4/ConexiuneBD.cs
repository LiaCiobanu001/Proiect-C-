using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIUG_Lab_2_4
{
   public static class ConexiuneBD
    {
        public static string string_connect = @"Data Source=" + GetDataSources() + ";Initial Catalog=DateBunici;Integrated Security=True";

        private static string GetDataSources()
        {
            string ServerName = Environment.MachineName;
            string data_source = "";
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                RegistryKey instanceKey = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL", false);
                if (instanceKey != null)
                {
                    foreach (var instanceName in instanceKey.GetValueNames())
                    {
                        data_source = data_source + (ServerName + "\\" + instanceName);
                    }
                }
            }
            return data_source;
        }
    }
}
