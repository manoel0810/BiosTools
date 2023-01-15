using BiosTools.Analizer;
using System;

namespace BiosTools
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Analize(Generic.GetArgsVector(Generic.RemoveDuplicateSpaces(args.ToString())));
            while (true)
                Analize(Generic.GetArgsVector(Generic.RemoveDuplicateSpaces(Console.ReadLine())));
        }

        private static void Analize(string[] Args)
        {
            if (Args.Length > 0)
            {
                switch (Args[0])
                {
                    case "btool":
                        Btool.Interpreter(Args);
                        break;
                }
            }
            else
                return;
        }
    }
}
