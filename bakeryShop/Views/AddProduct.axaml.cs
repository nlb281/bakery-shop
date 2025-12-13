using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using bakeryShop.Models;
using bakeryShop.ViewModels;

namespace bakeryShop.Views;

public partial class AddProduct : Window
{
    AddProductViewModel vm =  new AddProductViewModel();
    public AddProduct()
    {
        InitializeComponent();
        DataContext = vm;
        StaticFields.oldWindow = this;
    }
    
    public async void AddOrEditProduct(object sender, RoutedEventArgs e)
    {
        vm.AddOrEditProduct(sender, e);
    }
    
    public void GoBack(object sender, RoutedEventArgs e)
    {
        vm.GoBack(sender, e);
    }
}