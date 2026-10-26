using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using TestProject.Models;
using ResturantWebService.ORM.DbContext;

namespace TestProject
{
    internal class Program
    {
      

        private static async Task PrepareCofeeAsync()
        {
            Console.WriteLine("Add water");
            Console.WriteLine("Start boiling some water ");
            await Task.Delay(2500);
            Console.WriteLine("Water is boiling.");
            Console.WriteLine("Add some coffee");
            Console.WriteLine("Add some sugar");
            Console.WriteLine("Add some water");
            Console.WriteLine("Add some water");
            Console.WriteLine("Stir your coffee");
            Console.WriteLine("Coffee drink is ready");
        }

        private static async Task PrepareToastAsync(int count)
        {
            for (int i = 1; i <= count; i++)
                Console.WriteLine("Put bread into the toaster");
                Console.WriteLine("Turn on the toaster");
            Console.WriteLine("Start toasting");
            await Task.Delay(8000);
            Console.WriteLine("Toasts popped out ");
            Console.WriteLine("Spread with a butter");
            Console.WriteLine(" Spread with a jam");
            Console.WriteLine("Toast is ready");
        }

        private static async Task PrepareAggsAsync(int count)
        {
            Console.WriteLine("Heating a pan");
            await Task.Delay(1000);
            Console.WriteLine("Pour oil into the pan.");
            for (int i = 1; i <= count; i++)
                Console.WriteLine("Break the egg into pan");
            Console.WriteLine("Frying eggs") ;
            await Task.Delay(7000);
            Console.WriteLine("Put eggs on a plate");
            Console.WriteLine("Fried eggs are ready");
        }

        static async Task GetBreakFastAsync()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();  
            Console.WriteLine("Start making cofee");
            Task coffee = PrepareCofeeAsync();
            Console.WriteLine("Start making toasts");
            Task toast= PrepareToastAsync(2);
            Console.WriteLine("Start making eggs");
            Task aggs= PrepareAggsAsync(2);
            await Task.WhenAll(coffee, toast, aggs);
            Console.WriteLine("Breakfast is ready");
            stopwatch.Stop();
            Console.WriteLine($"Time taken to prepare breakfast: {stopwatch.ElapsedMilliseconds} ms");
        }
        static async Task Main(string[] args)
        {
            await  GetBreakFastAsync();
        }

        static void Targil1() {
            List<Student> students = new List<Student>();
            students.Add(new ComputerStudent()
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                Subjects = null,
                Grades = null
            });
            students.Add(new SportStudent()
            {
                Id = 2,
                Name = "Jane Smith",
                Email = "Jane.Smith@example.com",
                Password = "password456",
                Subjects = null,
                Grades = null

            });
            static void TestDbContext()
            {
                DBContext dBContext = new DBContext();
                dBContext.OpenConnection();
                dBContext.select("");
                dBContext.CloseConnection();

            }

        }
       

    }
}
