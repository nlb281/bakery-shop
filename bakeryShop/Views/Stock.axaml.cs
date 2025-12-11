using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using bakeryShop.Models;
using bakeryShop.ViewModels;

namespace bakeryShop.Views;

public partial class Stock : Window
{
    StockViewModel vm =  new StockViewModel();
    public Stock()
    {
        InitializeComponent();
        DataContext = vm;
        StaticFields.oldWindow = this;
    }
    
    public void OpenSalesManagementWindow(object sender, RoutedEventArgs e)
    {
        vm.OpenSalesManagementWindow(sender, e);
    }
}