using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ReactiveUI;
using bakeryShop.Models;
using bakeryShop.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace bakeryShop.ViewModels;

public class SalesManagementViewModel : ViewModelBase
{
    private List<Product> products;
    
    
    public SalesManagementViewModel()
    {
        // Загружаем продукты
        Products = StaticFields.context.Products.ToList();
    }

    public List<Product> Products
    {
        get => products;
        set => this.RaiseAndSetIfChanged(ref products, value);
    }

    public void GoBack(object sender, RoutedEventArgs e)
    {
        StaticFields.window = StaticFields.oldWindow;
        (new Stock()).Show();
        StaticFields.window.Close();
    }

    public void CreateOrder(object sender, RoutedEventArgs e)
    {
        Button btn = sender as Button;
        Product product = btn.DataContext as Product;
        StaticFields.productInfo = product;
        StaticFields.window = StaticFields.oldWindow;
        
        (new InputOrderedQuantity()).Show();
        StaticFields.window.Close();
    }
    
}