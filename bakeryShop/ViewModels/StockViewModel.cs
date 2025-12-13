using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using bakeryShop.Models;
using bakeryShop.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace bakeryShop.ViewModels;

public class StockViewModel : ViewModelBase
{
    private List<Product> products = new List<Product>();
    private List<Sale> sales = new List<Sale>();
    private List<Product> saledProducts = new List<Product>();
    public StockViewModel()
    {
        Products = StaticFields.context.Products.ToList();
        Sales = StaticFields.context.Sales
            .Include(s => s.Product)
            .ToList();
        
        
    }

    public List<Product> Products
    {
        get => products;
        set => this.RaiseAndSetIfChanged(ref products, value);
    }

    public List<Sale> Sales
    {
        get => sales;
        set => this.RaiseAndSetIfChanged(ref sales, value);
    }

    public List<Product> SaledProducts
    {
        get => saledProducts;
        set => this.RaiseAndSetIfChanged(ref saledProducts, value);
    }

    public void OpenSalesManagementWindow(object sender, RoutedEventArgs e)
    {
        StaticFields.window = StaticFields.oldWindow;
        
        (new SalesManagement()).Show();
        StaticFields.window.Close();
        
    }
}