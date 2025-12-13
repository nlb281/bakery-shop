using System.Collections.Generic;
using System.Linq;
using Avalonia.Interactivity;
using bakeryShop.Models;
using bakeryShop.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using ReactiveUI;

namespace bakeryShop.ViewModels;

public class AddProductViewModel : ViewModelBase
{
    private List<Product> products;
    private string name, quantity, price;

    public AddProductViewModel()
    {
        Products = StaticFields.context.Products.ToList();
    }

    public List<Product> Products
    {
        get => products;
        set => this.RaiseAndSetIfChanged(ref products, value);
    }

    public string Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }

    public string Quantity
    {
        get => quantity;
        set => this.RaiseAndSetIfChanged(ref quantity, value);
    }

    public string Price
    {
        get => price;
        set => this.RaiseAndSetIfChanged(ref price, value);
    }
    
    public void GoBack(object sender, RoutedEventArgs e)
    {
        StaticFields.window = StaticFields.oldWindow;
        (new Stock()).Show();
        StaticFields.window.Close();
    }

    public async void AddOrEditProduct(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Quantity) ||
            !int.TryParse(Quantity, out int newQuantity) ||
            newQuantity <= 0)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Введите корректное количество (положительное число, не больше доступного)", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new Stock()).Show();
            StaticFields.window.Close();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Price) ||
            !int.TryParse(Price, out int newPrice) ||
            newPrice <= 0)
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Введите корректную стоимость (положительное число)", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new Stock()).Show();
            StaticFields.window.Close();
            return;
        }
        
        if (string.IsNullOrWhiteSpace(Name))
        {
            await MessageBoxManager
                .GetMessageBoxStandard("Ошибка", "Введите корректное название продукта", ButtonEnum.Ok)
                .ShowWindowAsync();
            StaticFields.window = StaticFields.oldWindow;
        
            (new Stock()).Show();
            StaticFields.window.Close();
            return;
        }
    
        var existingProduct = StaticFields.context.Products
            .FirstOrDefault(p => p.Name.ToLower() == Name.ToLower());
        
        if (existingProduct != null)
        {
                existingProduct.Quantity = newQuantity;
                existingProduct.Price = newPrice;
                StaticFields.context.Products.Update(existingProduct);
                StaticFields.context.SaveChanges();
                Products = StaticFields.context.Products.ToList();
                
                await MessageBoxManager.GetMessageBoxStandard("Успех", $"Товар обновлен!", ButtonEnum.Ok).ShowWindowAsync();
        }
        
        if (existingProduct == null)
        {
            var newProduct = new Product
            {
                Name = Name,
                Price = newPrice,    
                Quantity = newQuantity, 
            };
            
            StaticFields.context.Products.Add(newProduct);
            StaticFields.context.SaveChanges();
            Products = StaticFields.context.Products.ToList();
            
            await MessageBoxManager.GetMessageBoxStandard("Успех", $"Товар добавлен!", ButtonEnum.Ok).ShowWindowAsync();
        }

        StaticFields.window = StaticFields.oldWindow;
        
        (new Stock()).Show();
        StaticFields.window.Close();
    }
}