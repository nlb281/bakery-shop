using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using bakeryShop.Models;
using bakeryShop.ViewModels;

namespace bakeryShop.Views;

public partial class Auth : Window
{
    AuthViewModel vm =  new AuthViewModel();
    public Auth()
    {
        InitializeComponent();
        DataContext = vm;
        StaticFields.oldWindow = this;
    }
}