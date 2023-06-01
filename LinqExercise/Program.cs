﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine("Sum of numbers");
            Console.WriteLine();
            Console.WriteLine(numbers.Sum());
            Console.WriteLine();

            //TODO: Print the Average of numbers

            Console.WriteLine("Average of numbers");
            Console.WriteLine();
            Console.WriteLine(numbers.Average());
            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console

            Console.WriteLine("Numbers in ascending order");
            Console.WriteLine();
            numbers.OrderBy(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in descending order and print to the console

            Console.WriteLine("Numbers in descending order");
            Console.WriteLine();
            numbers.OrderByDescending(x => x).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Print to the console only the numbers greater than 6

            Console.WriteLine("Numbers greater than 6");
            Console.WriteLine();
            numbers.Where(x => x > 6).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            Console.WriteLine("Four ordered numbers");
            Console.WriteLine();
            var orderedNums = numbers.OrderBy(x => x);
            foreach (var number in orderedNums.Take(4))
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            Console.WriteLine("Index 4 changed to my age and numbers ordered in descending order");
            Console.WriteLine();
            numbers[4] = 22;
            var descendingNums = numbers.OrderByDescending(x => x);
            foreach (var number in descendingNums)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            Console.WriteLine("Employees with 'C' or 'S' first name");
            Console.WriteLine();
            var CSFirstNames = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S')).OrderBy(person => person.FirstName);
            foreach (var employee in CSFirstNames)
            {
                Console.WriteLine(employee.FullName);
            }
            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            Console.WriteLine("Employees over 26");
            Console.WriteLine();
            var employeesOver26 = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);
            foreach (var employee in employeesOver26)
            {
                Console.WriteLine($"{employee.FullName} || Age: {employee.Age}");
            }
            Console.WriteLine();

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            Console.WriteLine("Sum and average of employee's YOE");
            Console.WriteLine();
            var employeesYoe = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);
            Console.WriteLine($"Total Years of Experience: {employeesYoe.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Years of Experience: {employeesYoe.Average(x => x.YearsOfExperience)}");
            Console.WriteLine();

            //TODO: Add an employee to the end of the list without using employees.Add()

            var addEmployee = employees.Append(new Employee("Angel", "Acuna", 22, 3)).ToList();

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
