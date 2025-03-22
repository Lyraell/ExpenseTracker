using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.ViewModels
{
    public partial class AddExpenseViewModel : ObservableObject
    {
        [ObservableProperty]
        private decimal amount;

        [ObservableProperty]
        private ObservableCollection<string> expenseTypes = new() { "Food", "Transport", "Entertainment", "Other", "Bills" };

        [ObservableProperty]
        private string selectedExpenseType;

        [ObservableProperty]
        private DateTime expenseDate = DateTime.Now;

        public ICommand SaveExpenseCommand { get; }

        public AddExpenseViewModel()
        {
            SaveExpenseCommand = new RelayCommand(SaveExpense);
        }

        private void SaveExpense()
        {
            if (Amount <= 0 || string.IsNullOrEmpty(SelectedExpenseType))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            Expense expense = new()
            {
                Amount = Amount,
                Type = SelectedExpenseType,
                Date = ExpenseDate
            };

            DatabaseService.AddExpense(expense);
            MessageBox.Show("Expense saved successfully!");
        }
    }
}
