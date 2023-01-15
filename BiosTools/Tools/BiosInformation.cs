using System;
using System.Linq;
using System.Management;

namespace BiosTools.Tools
{
    public class BiosInformation
    {

        public ManagementObjectSearcher GetBiosInformation()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
            return searcher;
        }

        public void DisplayBiosInfo(ManagementObjectSearcher searcher)
        {
            foreach (ManagementObject wmi in searcher.Get().Cast<ManagementObject>())
            {
                Console.WriteLine("\n-------------------- BIOS Information --------------------");
                Console.WriteLine("Manufacturer: {0}", wmi.GetPropertyValue("Manufacturer"));
                Console.WriteLine("SerialNumber: {0}", wmi.GetPropertyValue("SerialNumber"));
                Console.WriteLine("Version: {0}", wmi.GetPropertyValue("Version"));
                string _DATE = wmi.GetPropertyValue("ReleaseDate").ToString();
                string DATE = $"{_DATE.Substring(6, 2)}/{_DATE.Substring(4, 2)}/{_DATE.Substring(0, 4)}";

                Console.WriteLine("ReleaseDate: {0}\n-------------------- BIOS Information --------------------", DATE);
            }
        }
    }
}
