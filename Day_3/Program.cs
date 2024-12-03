using System;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml.Xsl;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\Coding_Rider\\AdventOfCode\\Day_3\\input.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }

            long mull = 0;
            bool enabled = true;
            //169021493
            Regex regex = new Regex(@"don't\(\)|mul\(\d{1,3},\d{1,3}\)|do\(\)");
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    int sum = 0;
                    var listOfMatches = regex.Matches(line);
                    for (int i = 0; i < listOfMatches.Count; i++)
                    {
                        if (listOfMatches[i].Value == "don't()")
                        {
                            enabled = false;
                        }
                        else if (listOfMatches[i].Value == "do()")
                        {
                            enabled = true;
                        }
                        else
                        {
                            if (enabled)
                            {
                                string firstNumber = listOfMatches[i].Value.Substring(4, listOfMatches[i].Value.IndexOf(',') - 4);
                                string secondNumber = listOfMatches[i].Value.Substring(listOfMatches[i].Value.IndexOf(',')+1, listOfMatches[i].Value.IndexOf(')') - (listOfMatches[i].Value.IndexOf(',')+1));
                                int multiplication = int.Parse(firstNumber) * int.Parse(secondNumber);
                                mull += multiplication;
                               // sum += multiplication;
                            }
                        }

                    }

                    //Console.WriteLine(sum);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            Console.WriteLine(mull);

        }
    }
}