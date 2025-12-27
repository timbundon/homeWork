using System;
using System.Data.Common;
using System.Linq.Expressions;
using System.Xml.Linq;
using ConsoleApp1.Data;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ConsoleApp1;

class Program { 
    public static int userId;
    public static string Input(string placeHolder) {
        Console.WriteLine(placeHolder);
        var choice = Console.ReadLine();
        return choice;
    }
    public static string Input(string placeHolder, Expression<Func<dynamic, bool>> errorCondition, string errorMessage) {
        Console.WriteLine(placeHolder);
        var choice = Console.ReadLine();
        var cond = errorCondition.Compile();
        if (!cond(choice)) {
            Console.WriteLine(errorMessage);
            return Input(placeHolder, errorCondition, errorMessage);
        }
        return choice;
    }
    public static void AddProduct() {
        Console.WriteLine("description (name;price): ");
        var desc = Console.ReadLine().Trim().Split(";");
        Product prod = new Product() {
            Name = desc[0],
            Price = decimal.Parse(desc[1])
        };
        using AppDbContext db = new AppDbContext();
        db.Products.Add(prod);
        db.SaveChanges();
        Console.WriteLine("👍");
        ShowAdminActions();
    }
    public static void ListProduct(int mod) {
        using AppDbContext db = new AppDbContext();
        foreach (Product prod in db.Products.OrderBy(p => p.Id)) {
            Console.WriteLine($"[{prod.Id}]: {prod.Name} - {prod.Price}");
        }
        Console.ReadKey();
        if (mod == 0) {
            ShowAdminActions();
        } else {
            ShowCustomerAction();
        }
    }
    public static void UpdateProduct() {
        Console.WriteLine("Id: ");
        int choice = int.Parse(Console.ReadLine());
        using AppDbContext db = new AppDbContext();
        var prod = db.Products.Find(choice);
        if (prod == null) {
            ShowAdminActions();
            return;
        }
        Console.WriteLine("Property to change (Name, Price): ");
        var prop = Console.ReadLine();
        var val = Console.ReadLine();
        prod[prop] = val;
        db.Products.Update(prod);
        db.SaveChanges();
        ShowAdminActions();
    }
    public static void DeleteProduct() {
        var choice = int.Parse(Console.ReadLine());
        using AppDbContext db = new AppDbContext();
        db.Products.Remove(db.Products.Find(choice));
        db.SaveChanges();
        ShowAdminActions();
    }
    public static void AddAdmin() {
        Console.WriteLine("Enter description (username;password;name;surname;fathername;storeId): ");
        var c = Console.ReadLine().Split(";");
        var admin = new Admin() {
            Username = c[0],
            Password = c[1],
            Name = c[2],
            Surname = c[3],
            FatherName = c[4],
            StoreId = int.Parse(c[5])
        };
        using AppDbContext db = new AppDbContext();
        bool extists = db.Admins.Any(x => x.Username == c[0]);
        if (extists) {
            Console.WriteLine("invalid");
            AddAdmin();
            return;
        }
        db.Admins.Add(admin);
        db.SaveChanges();
        ShowAdminActions();
    }
    public static void AddStore() {
        var choice = Input("Enter Description (Name;Address;AdminId)", x => 1 == 1, "Error").Trim().Split(";");
        var admin = new ConsoleApp1.Models.Store() {
            Name = choice[0],
            Address = choice[1],
            AdminId = int.Parse(choice[2])
        };
        using AppDbContext db = new AppDbContext();
        bool extists = db.Stores.Any(x => x.Name == choice[0]);
        if (extists) {
            Console.WriteLine("invalid");
            AddStore();
            return;
        }
        db.Stores.Add(admin);
        db.SaveChanges();
        ShowAdminActions();
    }
    public static void addProductToStore() {
        var productsIds = new List<int>(){};
        var storesIds = new List<int>(){};
        var p = Input("enter description (ProductId;ProductId;...)").Split(";");
        var s = Input("enter description (StoreId;StoreId;...)").Split(";");
        foreach (var aa in p) {
            productsIds.Add(int.Parse(aa));
        }
        foreach (var aa in s) {
            storesIds.Add(int.Parse(aa));
        }
        using var db = new AppDbContext();
        var sotres = db.Stores.Include(x => x.Products).Where(x => storesIds.Contains(x.Id)).ToList();
        var prods = db.Products.Where(x => productsIds.Contains(x.Id)).ToList();
        foreach (var store in sotres) {
            store.Products.AddRange(prods);
        }
        db.SaveChanges();
        ShowAdminActions();
    }
    public static void addFavorite() {
        var choice = int.Parse(Input("Product Id: "));
        using var db = new AppDbContext();
        var prod = db.Products.FirstOrDefault(x => x.Id == choice);
        if (prod == null) {
            addFavorite();
            return;
        }
        var u = db.Customers.Include(x => x.Products).FirstOrDefault(x => x.Id == userId);
        u.Products.Add(prod);
        db.SaveChanges();
        ShowCustomerAction();
    }
    public static void ShowAdminActions() {
        Console.Clear();
        Console.WriteLine("Enter Action \n1 = Add Product\n2 = Update Product\n3 = List Products\n4 = Delete Product\n5 = Add Admin\n6 = Add Store\n7 = add product to store");
        var choice = int.Parse(Console.ReadLine());
        if (choice == 1) {
            AddProduct();
        } else if (choice == 2) {
            UpdateProduct();
        } else if (choice == 3) {
            ListProduct(0);
        } else if (choice == 4) {
            DeleteProduct();
        } else if (choice == 5) {
            AddAdmin();
        } else if (choice == 6) {
            AddStore();
        } else if (choice == 7) {
            addProductToStore();
        }
    }
    public static void EnterAsAdmin() {
        Console.WriteLine("login: ");
        var username = Console.ReadLine();
        Console.WriteLine("password: ");
        var password = Console.ReadLine();
        using var dbContext = new AppDbContext();
        var foundAdmin = dbContext.Admins.FirstOrDefault(x => x.Username.ToLower() == username.ToLower() && x.Password == password);
        if (foundAdmin == null) {
            Console.WriteLine("Invalid");
            EnterAsAdmin();
            return;
        }
        userId = foundAdmin.Id;
        Console.Clear();
        Console.WriteLine($"Wellcome {foundAdmin.Name} {foundAdmin.Surname}");
        ShowAdminActions();
    }
    public static void buyProduct() {
        Console.WriteLine("ID: ");
        var choice = int.Parse(Console.ReadLine());
        using var db = new AppDbContext();
        var prod = db.Products.FirstOrDefault(x => x.Id == choice);
        var user = db.Customers.FirstOrDefault(x => x.Id == userId);
        if (user.Balance < prod.Price) {
            Console.WriteLine("not enough money");
            Console.ReadKey();
            MainMenu();
            return;
        }
        user.Balance -= prod.Price;
        var ord = new Order() {
            Customer=user,
            Product=prod,
            ProductId=prod.Id,
            CustomerId=user.Id
        };
        db.Orders.Add(ord);
        ShowCustomerAction();
        db.SaveChanges();
    }
    public static void ShowOrder() {
        using var db = new AppDbContext();
        foreach (var ord in db.Orders) {
            Console.WriteLine($"{ord.Id}: {ord.Customer.Name}, {ord.Product.Name} {ord.Product.Price}");
        }
        Console.ReadKey();
        ShowAdminActions();
    }
    public static void ShowCustomerAction() {
        // Console.Clear();
        Console.WriteLine("1: show products\n2: buy product\n3: show orders\n4: add favorites");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1) {
            ListProduct(1);
        } else if (choice == 2) {
            buyProduct();
        } else if (choice == 3) {
            ShowOrder();
        } else if (choice == 4) {
            addFavorite();
        }
    }
    public static void EnterAsCustomer() {
        Console.WriteLine("login: ");
        var username = Console.ReadLine();
        Console.WriteLine("password: ");
        var password = Console.ReadLine();
        using var dbContext = new AppDbContext();
        var foundAdmin = dbContext.Customers.FirstOrDefault(x => x.Username == username && x.Password == password);
        if (foundAdmin == null) {
            Console.WriteLine("Invalid");
            EnterAsCustomer();
            return;
        }
        userId = foundAdmin.Id;
        var choice = int.Parse(Input("Enter Shop Id: ", x => 1 == 1, "Error"));
        var store = dbContext.Stores.FirstOrDefault(x => x.Id == choice);
        if (store == null) {
            EnterAsCustomer();
        }
        Console.WriteLine($"Wellcome {foundAdmin.Name} {foundAdmin.Surname} to {store.Name}");
        var visit = new Visit() {
            CustomerId = foundAdmin.Id,
            StoreId = choice
        };
        ShowCustomerAction();
    }
    public static void signUp() {
        Console.WriteLine("Enter description (username;password;name;surname;fathername): ");
        var c = Console.ReadLine().Split(";");
        var customer = new Customer() {
            Username = c[0],
            Password = c[1],
            Name = c[2],
            Surname = c[3],
            FatherName = c[4]
        };
        using AppDbContext db = new AppDbContext();
        db.Customers.Add(customer);
        db.SaveChanges();
        MainMenu();
    }
    public static void MainMenu() {
        Console.WriteLine("1: sign in as a customer\n2: sign in as an admin\n3: sign up");
        int choice = int.Parse(Console.ReadLine());
        if (choice == 1) {
            EnterAsCustomer();
        } else if (choice == 2) {
            EnterAsAdmin();
        } else if (choice == 3) {
            signUp();
        }
    }
    public static void Main() {
        MainMenu();
    }
}