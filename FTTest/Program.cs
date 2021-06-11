using System;
using System.IO;
using System.Linq;
using FTTest.Data;
using FTTest.Services;
using Microsoft.EntityFrameworkCore;

namespace FTTest
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Для генерации отчета нажмите Enter Для выхода нажмите Esc");
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    while ((consoleKey != ConsoleKey.Escape) && consoleKey != ConsoleKey.Enter)
                    {
                        consoleKey = Console.ReadKey().Key;
                    }

                    if (consoleKey == ConsoleKey.Escape)
                        Environment.Exit(0);

                    IzdelDbContext db = new IzdelDbContext();
                    var reportData = new Reporter()
                        .Generate(db.Izdel.Include(i => i.Components).ToList());
                    var reportExcel = new ExcelGenerator()
                        .Generate(reportData);
                    File.WriteAllBytes("Отчёт.xlsx", reportExcel);
                    Console.WriteLine("Отчет сгенерирован");
                }
                catch (Exception E)
                {
                    Console.WriteLine(E.Message);
                    Console.WriteLine("Для продолжения нажмите Enter Для выхода нажмите Esc");
                    ConsoleKey consoleKey = Console.ReadKey().Key;
                    while ((consoleKey != ConsoleKey.Escape) && consoleKey != ConsoleKey.Enter)
                    {
                        consoleKey = Console.ReadKey().Key;
                    }

                    if (consoleKey == ConsoleKey.Escape)
                        Environment.Exit(0);
                }
            } while (true);
        }
    }
}