using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using bakeryShop.Models;
using bakeryShop.ViewModels;

namespace bakeryShop.Views;

public partial class SalesManagement : Window
{
    SalesManagementViewModel vm = new SalesManagementViewModel();
    public SalesManagement()
    {
        InitializeComponent();
        DataContext = vm;
        StaticFields.oldWindow = this;
    }
    public void GoBack(object sender, RoutedEventArgs e)
    {
        vm.GoBack(sender, e);
    }
    
    public void CreateOrder(object sender, RoutedEventArgs e)
    {
        vm.CreateOrder(sender, e);
    }
}