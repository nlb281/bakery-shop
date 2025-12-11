using System.Linq;
using bakeryShop.Models;
using bakeryShop.Views;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace bakeryShop.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private string login, password;

    public string Login
    {
        get => login;
        set => login = value;
    }

    public string Password
    {
        get => password;
        set => password = value;
    }

    public void LogIn()
    {
        StaticFields.employee = StaticFields.context.Employees.Include(x => x.Role)
            .FirstOrDefault(x => x.Login == Login && x.Password == Password);

        if (StaticFields.employee == null)
        {
            MessageBoxManager.GetMessageBoxStandard("Information", "Invalid login or password", ButtonEnum.Ok)
                .ShowWindowAsync();
        }
        else
        {
            StaticFields.window = StaticFields.oldWindow;
            (new Stock()).Show();
            StaticFields.window.Close();
        }
    }
}