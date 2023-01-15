using BiosTools.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace BiosTools.Analizer
{
    public static class Btool
    {

        private static readonly List<string> ValidTags = new List<string>()
        {
            "btool",
            "--help",
            "--get-information",
            "-b",
            "-o"
        };

        public static void Interpreter(string[] args)
        {
            string[] CheckTags = Generic.InvalidTags(args, ValidTags);
            if (CheckTags.Length > 0)
            {
                Console.WriteLine("Invalid tags for btool: ");
                foreach (string s in CheckTags)
                    Console.WriteLine($"{s} -> isn't defined for this command");

                return;
            }

            switch (args[1])
            {
                case "--help":
                    //TODO: Display help list 
                    break;
                case "--get-information":
                    if (Generic.Contains("-b", args) && Generic.Contains("-o", args) == false)
                    {
                        Console.WriteLine("Syntax error: no -o tag identified");
                        return;
                    }
                    else if (Generic.Contains("-b", args) && Generic.Contains("-o", args))
                    {
                        string PATH = args[Generic.GetIndexOf("-o", args) + 1];
                        //TODO: Verify path; read bios bytes and save in -o [PATH] as a .bin file or .rom
                    }
                    else if (Generic.Contains("-b", args) == false && Generic.Contains("-o", args))
                    {
                        string PATH = args[Generic.GetIndexOf("-o", args) + 1];
                        BiosInformation BIOS = new BiosInformation();

                        using (StreamWriter Writter = new StreamWriter(PATH))
                        {
                            foreach (ManagementObject wmi in BIOS.GetBiosInformation().Get().Cast<ManagementObject>())
                            {
                                Writter.WriteLine("\n-------------------- BIOS Information --------------------");
                                Writter.WriteLine("Manufacturer: {0}", wmi.GetPropertyValue("Manufacturer"));
                                Writter.WriteLine("SerialNumber: {0}", wmi.GetPropertyValue("SerialNumber"));
                                Writter.WriteLine("Version: {0}", wmi.GetPropertyValue("Version"));
                                Writter.WriteLine("ReleaseDate: {0}\n-------------------- BIOS Information --------------------", wmi.GetPropertyValue("ReleaseDate"));
                                Writter.Flush();
                                Writter.Close();
                            }

                            Writter.Close();
                        }

                        BIOS.DisplayBiosInfo(BIOS.GetBiosInformation());
                        return;
                    }
                    else if (Generic.Contains("-b", args) == false && Generic.Contains("-o", args) == false)
                    {
                        BiosInformation BIOS = new BiosInformation();
                        BIOS.DisplayBiosInfo(BIOS.GetBiosInformation());
                        return;
                    }
                    break;
            }
        }
    }
}
