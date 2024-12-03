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
            // distance
            string filePath = "D:\\Coding_Rider\\AdventOfCode\\Day_1\\input.txt";
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                return;
            }
            List<int> listLeft = new List<int>(); 
            List<int> listRight = new List<int>();
            
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    string[] numbers = line.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                    listLeft.Add(int.Parse(numbers[0]));
                    listRight.Add(int.Parse(numbers[1]));
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            listLeft.Sort();
            listRight.Sort();
            long distance = 0;
            for (int i = 0; i < listLeft.Count; i++)
            {
                int difference = Math.Abs(listLeft[i] - listRight[i]);
                distance += difference;
            }

            Console.WriteLine($"Total distance: {distance}!");
            
            
            // similarity score
            long similarityScore = 0;

            for (int i = 0; i < listLeft.Count; i++)
            {
                int appearancesInListRight = listRight.Where(number => number == listLeft[i]).ToList().Count;
                similarityScore += listLeft[i] * appearancesInListRight;
            }

            Console.WriteLine($"Similarity score: {similarityScore}!");
        }
        
    }
}