using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using bakeryShop.Models;
using bakeryShop.Views;
using ReactiveUI;

namespace bakeryShop.ViewModels;

public class StockViewModel : ViewModelBase
{
    private List<Product> products = new List<Product>();
    private List<Sale> receipts = new List<Sale>();
    public StockViewModel()
    {
        Products = StaticFields.context.Products.ToList();
    }

    public List<Product> Products
    {
        get => products;
        set => this.RaiseAndSetIfChanged(ref products, value);
    }

    public List<Sale> Receipts
    {
        get => receipts;
        set => this.RaiseAndSetIfChanged(ref receipts, value);
    }

    public void OpenSalesManagementWindow(object sender, RoutedEventArgs e)
    {
        StaticFields.window = StaticFields.oldWindow;
        
        (new SalesManagement()).Show();
        StaticFields.window.Close();
        
    }
}