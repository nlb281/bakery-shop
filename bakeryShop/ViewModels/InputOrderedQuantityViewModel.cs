using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Interactivity;
using bakeryShop.Models;
using bakeryShop.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace bakeryShop.ViewModels;

public class InputOrderedQuantityViewModel : ViewModelBase
{
    private List<Product> products;
    private string orderedQuantity;

    public InputOrderedQuantityViewModel()
    {
        // Загружаем продукты
        Products = StaticFields.context.Products.ToList();
    }
    
    public string OrderedQuantity
    {
        get => orderedQuantity;
        set => this.RaiseAndSetIfChanged(ref orderedQuantity, value);
    }

    public List<Product> Products
    {
        get => products;
        set => this.RaiseAndSetIfChanged(ref products, value);
    }

    public async void ConfirmOrder(object sender, RoutedEventArgs e)
    {
        Product product = StaticFields.productInfo;
        Employee employee = StaticFields.employee;
        
        if (product == null)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Продукт не выбран", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new SalesManagement()).Show();
            StaticFields.window.Close();
            return;
        }

        if (employee == null)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Сотрудник не авторизован", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new SalesManagement()).Show();
            StaticFields.window.Close();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(OrderedQuantity) ||
            !int.TryParse(OrderedQuantity, out int ordquantity) ||
            ordquantity <= 0 ||
            ordquantity > product.Quantity)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Введите корректное количество (положительное число, не больше доступного)", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new SalesManagement()).Show();
            StaticFields.window.Close();
            return;
        }

        var existingProduct = StaticFields.context.Products.Find(product.Id);
        if (existingProduct != null)
        {
                existingProduct.Quantity -= ordquantity;
                StaticFields.context.Products.Update(existingProduct);
                StaticFields.context.SaveChanges();
                Products = StaticFields.context.Products.ToList();
        }
                
        var newOrder = new Sale
        {
            Productid = product.Id,
            Employeeid = employee.Id,    
            Quantity = ordquantity, 
            Totalprice = product.Price * ordquantity,
        };
            
        StaticFields.context.Sales.Add(newOrder);
        StaticFields.context.SaveChanges();

        await MessageBoxManager.GetMessageBoxStandard("Успех", $"Заказ оформлен!\n\nПродукт {product.Name} количество - {ordquantity} шт.", ButtonEnum.Ok).ShowWindowAsync();
            
        StaticFields.window = StaticFields.oldWindow;
        
        (new SalesManagement()).Show();
        StaticFields.window.Close();
    }
}