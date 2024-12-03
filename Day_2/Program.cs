using System;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using System.Xml.Xsl;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // filepath
            // Part 1
            string filePath = "D:\\Coding_Rider\\AdventOfCode\\Day_2\\input.txt";
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }
          
            int safeReports = 0;
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] numbers = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    List<int> reports = new List<int>();
                    for (int i = 0; i < numbers.Count(); i++)
                    {
                        reports.Add(int.Parse(numbers[i]));
                    }
                    
                    if (IsSafeReport(reports))
                    {
                        safeReports += 1;
                    }
                    else
                    {
                        // Part 2
                        for (int i = 0; i < reports.Count(); i++)
                        {
                            List<int> modified = new List<int>(reports);
                            modified.RemoveAt(i);

                            if (IsSafeReport(modified))
                            {
                                safeReports += 1;
                                break;
                            }
                        }
                    }
                    
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            Console.WriteLine(safeReports);   
            
        }
        
        
        public static bool IsSafeReport(List<int> reports)
        {
            bool flagForIncreasing = true;
            bool flagForDecrease = true;

            for (int i = 0; i < reports.Count()-1; i++)
            {
                if (reports[i] - reports[i + 1] == 0)
                {
                    return false;
                }

                if (Math.Abs(reports[i] - reports[i + 1]) < 1 || Math.Abs(reports[i] - reports[i + 1]) > 3)
                {
                    return false;
                }

                if (reports[i] > reports[i + 1])
                {
                    flagForIncreasing = false;
                }
                else if (reports[i] < reports[i + 1])
                {
                    flagForDecrease = false;
                }

                if (!flagForDecrease && !flagForIncreasing)
                {
                    return false;
                }
                        
            }

            return true;

        }
    }
    
    
 
}