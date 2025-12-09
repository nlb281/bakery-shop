using Avalonia.Controls;

namespace bakeryShop.Models;

public class StaticFields
{
    public static BakeryShopContext context = new BakeryShopContext();
    public static Employee employee;
    public static Window? oldWindow, window;
}