using System;

public delegate void UserLoggedInHandler(string username);
public class UserLoginManager
{
    public event UserLoggedInHandler UserLoggedIn;

    public void Login(string username)
    {
        Console.WriteLine($"Пользователь {username} вошел в систему.");
        UserLoggedIn?.Invoke(username);
    }
}
public class SecuritySystem
{
    public void OnUserLoggedIn(string username)
    {
        Console.WriteLine($"[SecuritySystem] Проверка доступа для {username}.");
    }
}
public class NotificationService
{
    public void OnUserLoggedIn(string username)
    {
        Console.WriteLine($"[NotificationService] Отправка уведомления о входе {username}.");
    }
}

class Program
{
    static void Main()
    {
        UserLoginManager loginManager = new UserLoginManager();
        SecuritySystem security = new SecuritySystem();
        NotificationService notification = new NotificationService();

        loginManager.UserLoggedIn += security.OnUserLoggedIn;
        loginManager.UserLoggedIn += notification.OnUserLoggedIn;

        loginManager.Login("Иван");
    }
}

