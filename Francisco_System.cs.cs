using System;

/* 
   Author: Reyna V. Francisco
   Position: Cybersecurity Intelligence
   University: National Teachers College
   Project: Codac Logistics Delivery & Fuel Auditor
   Description: This program tracks a driver's weekly fuel expenses and 
                calculates fuel efficiency ratings over a 5-day work week.
*/

namespace CodacLogistics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== CODAC LOGISTICS FUEL AUDITOR ===\n");

            // --- Task 1: Driver Profile & Distance Validation ---
            Console.Write("Enter Driver's Full Name: ");
            string driverName = Console.ReadLine();

            decimal fuelBudget = 0;
            bool isValidBudget = false;

            // Input validation for fuel budget
            while (!isValidBudget)
            {
                Console.Write("Enter Weekly Fuel Budget: ");
                string budgetInput = Console.ReadLine();

                if (decimal.TryParse(budgetInput, out fuelBudget) && fuelBudget > 0)
                {
                    isValidBudget = true;
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid positive number for budget.");
                }
            }

            double totalDistance = 0;
            bool isDistanceValid = false;

            // Loop ensures distance is between 1.0 and 5000.0
            while (!isDistanceValid)
            {
                Console.Write("Enter Total Distance Traveled (1.0 - 5000.0 km): ");
                string distanceInput = Console.ReadLine();

                if (double.TryParse(distanceInput, out totalDistance))
                {
                    if (totalDistance >= 1.0 && totalDistance <= 5000.0)
                    {
                        isDistanceValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Distance must be between 1.0 and 5000.0 km. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }
            }

            // --- Task 2: Fuel Expense Tracking ---
            decimal[] fuelExpenses = new decimal[5];
            decimal totalFuelSpent = 0;

            Console.WriteLine("\n ....Enter Daily Fuel Expenses.... ");
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                bool isValidExpense = false;

                while (!isValidExpense)
                {
                    Console.Write($"Enter fuel cost for Day {i + 1}: ");
                    string expenseInput = Console.ReadLine();

                    if (decimal.TryParse(expenseInput, out fuelExpenses[i]) && fuelExpenses[i] >= 0)
                    {
                        isValidExpense = true;
                        totalFuelSpent += fuelExpenses[i];
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid non-negative amount.");
                    }
                }
            }

            // --- Task 3: Performance Analysis ---
            decimal averageFuelExpense = totalFuelSpent / 5;
            string efficiencyRating;

            // Efficiency Ratio = Distance / Fuel Spent
            double efficiencyRatio = totalFuelSpent > 0
                ? totalDistance / (double)totalFuelSpent
                : 0;

            if (efficiencyRatio > 15)
                efficiencyRating = "High Efficiency";
            else if (efficiencyRatio >= 10)
                efficiencyRating = "Standard Efficiency";
            else
                efficiencyRating = "Low Efficiency / Maintenance Required";

            bool isUnderBudget = totalFuelSpent <= fuelBudget;
            decimal budgetDifference = fuelBudget - totalFuelSpent;

            // --- Task 4: The Audit Report ---
            Console.WriteLine("\n");
            Console.WriteLine("CODAC LOGISTICS AUDIT REPORT");
            Console.WriteLine("----------------------------");
            Console.WriteLine($"\nDriver Name: {driverName}");
            Console.WriteLine($"Total Distance: {totalDistance:F2} km");
            Console.WriteLine($"Weekly Fuel Budget: ₱{fuelBudget:N2}");

            Console.WriteLine("\n..... 5-Day Expense Breakdown .....");
            for (int i = 0; i < fuelExpenses.Length; i++)
            {
                Console.WriteLine($"  Day {i + 1}: ₱{fuelExpenses[i]:N2}");
            }

            Console.WriteLine("\n..... Performance Summary .....");
            Console.WriteLine($"Total Fuel Spent: ₱{totalFuelSpent:N2}");
            Console.WriteLine($"Average Daily Expense: ₱{averageFuelExpense:N2}");
            Console.WriteLine($"Efficiency Ratio: {efficiencyRatio:F2} km per currency unit");
            Console.WriteLine($"Efficiency Rating: {efficiencyRating}");

            Console.WriteLine("\n.... Budget Analysis .....");
            Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

            if (isUnderBudget)
            {
                Console.WriteLine($"Budget Remaining: ₱{budgetDifference:N2}");
            }
            else
            {
                Console.WriteLine($"Budget Exceeded By: ₱{Math.Abs(budgetDifference):N2}");
            }

            Console.WriteLine("\n___________________________________\n");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}