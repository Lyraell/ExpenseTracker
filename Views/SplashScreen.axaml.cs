using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using ExpenseTracker.Views;

namespace ExpenseTracker.Views;

public partial class SplashScreen : Window
{
    public SplashScreen()
    {
        InitializeComponent();
        ShowMainWindowAfterDelay();
    }

    private async void ShowMainWindowAfterDelay()
    {
        await Task.Delay(1000); //wait 1 sec
        Close(); 

        var mainWindow = new MainWindow();
        mainWindow.Show();
       
    }

}