using System;
using System.Data.SqlClient;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    public static class DatabaseService
    {
        // 🔥 Change "YOUR_SERVER" to your actual SQL Server name!
        private const string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ExpenseTrackerDB;Trusted_Connection=True;";

        public static void AddExpense(Expense expense)
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("INSERT INTO Expenses (Amount, Type, Date) VALUES (@Amount, @Type, @Date)", connection);
            command.Parameters.AddWithValue("@Amount", expense.Amount);
            command.Parameters.AddWithValue("@Type", expense.Type);
            command.Parameters.AddWithValue("@Date", expense.Date);

            command.ExecuteNonQuery();
        }
    }
}
