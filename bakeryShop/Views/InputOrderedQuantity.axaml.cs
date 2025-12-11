using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using bakeryShop.Models;
using bakeryShop.ViewModels;

namespace bakeryShop.Views;

public partial class InputOrderedQuantity : Window
{
    private InputOrderedQuantityViewModel vm = new InputOrderedQuantityViewModel();
    public InputOrderedQuantity()
    {
        InitializeComponent();
        DataContext = vm;
        StaticFields.oldWindow = this;
    }
    
    public void ConfirmOrder(object sender, RoutedEventArgs e)
    {
        vm.ConfirmOrder(sender, e);
    }
}