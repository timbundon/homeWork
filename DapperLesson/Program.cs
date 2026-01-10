using System;
using DapperLesson.Bank;
using DapperLesson.Repositories;

namespace DapperLesson;

class Program {
    public static string Input(string placeHolder) {
        Console.Write(placeHolder);
        var choice = Console.ReadLine();
        return choice;
    }
    public static void Main() {
        using var clientRepo = new ClientRepository();
        using var bankRepo = new BankRepository();
        while (true) {
            int choice = int.Parse(Input("1 = Добавить Клиента\n2 = Удалить Клиента\n3 = Достать Человека По Айди\n4 = Обновить Данные\n5 = Сделать Перевод\nВведите Действие: "));
            if (choice == 1) {
                var line = Input("Введите Данные (Имя;Фамилия): ").Split(";");
                Client client = new Client(){Name = line[0], Surname = line[1], Amount = 0};
                clientRepo.Create(client);
            } else if (choice == 2) {
                var id = int.Parse(Input("Введите Айди: "));
                clientRepo.Delete(id);
            } else if (choice == 3) {
                var id = int.Parse(Input("Введите Айди: "));
                var client = clientRepo.GetById(id);
                Console.WriteLine($"[{client.Id}] {client.Name} {client.Surname}");
            } else if (choice == 4) {
                var data = Input("Введите Данные (Айди;Поле;Значение): ").Split(";");
                clientRepo.Update(int.Parse(data[0]), data[1], data[2]);
            } else if (choice == 5) {
                var data = Input("Введите Данные (Айди Отправтеля;Айди Получателся;Сумма Перевода): ").Split(";");
                var sender = clientRepo.GetById(int.Parse(data[0]));
                var reciver = clientRepo.GetById(int.Parse(data[1]));
                var amount = double.Parse(data[2]);
                if (sender.Amount < amount) {
                    Console.WriteLine("Мало Деняг");
                    continue;
                }
                bankRepo.Transfer(sender.Id, reciver.Id, amount);
            } else if (choice == 6) {
                
            }
        }
    }
}