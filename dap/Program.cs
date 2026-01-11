using System;
using dap.Database;
using Dapper;
using Npgsql;

namespace dap;

class Program {
    public static void Main() {
        using (var conn = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=1234; Database=test")) {
            Console.WriteLine("---1---");
            var clients = conn.Query(
                "SELECT * FROM customer;"
            );
            foreach (var client in clients) {
                Console.WriteLine($"{client.id} {client.full_name} {client.birthday} {client.gender} {client.email} {client.countryId} {client.city} {client.categoryId}");
            }
            Console.WriteLine("---2---");
            var emails = conn.Query(
                "SELECT email FROM customer;"
            );
            foreach (var email in emails) {
                Console.WriteLine(email.email);
            }
            Console.WriteLine("---3---");
            var categories = conn.Query(
                "SELECT * FROM category;"
            );
            foreach (var cat in categories) {
                Console.WriteLine($"{cat.id} {cat.name}");
            }
            Console.WriteLine("---4---");
            var offers = conn.Query(
                "SELECT * FROM offers;"
            );
            foreach (var off in offers) {
                Console.WriteLine($"{off.id} {off.startdat} {off.enddate} {off.countryid}");
            }
            Console.WriteLine("---5---");
            var cities = conn.Query(
                "SELECT DISTINCT city FROM customer;"
            );
            foreach (var city in cities) {
                Console.WriteLine($"{city.city}");
            }
            Console.WriteLine("---6---");
            var countries = conn.Query(
                "SELECT * FROM country;"
            );
            foreach (var cpuntry in countries) {
                Console.WriteLine($"{cpuntry.id} {cpuntry.name}");
            }
            Console.WriteLine("---7---");
            var customers = conn.Query(
                "SELECT * FROM customer WHERE city = 'Берлин';"
            );
            foreach (var cus in customers) {
                Console.WriteLine($"{cus.id} {cus.full_name} {cus.birthday} {cus.gender} {cus.email} {cus.countryid} {cus.city} {cus.categoryid}");
            }
            Console.WriteLine("---8---");
            var custs = conn.Query(
                "SELECT * FROM customer WHERE countryId = 1;"
            );
            foreach (var cus in custs) {
                Console.WriteLine($"{cus.id} {cus.full_name} {cus.birthday} {cus.gender} {cus.email} {cus.countryid} {cus.city} {cus.categoryid}");
            }
            Console.WriteLine("---9---");
            var offs = conn.Query(
                "SELECT * FROM offers WHERE countryId = 1;"
            );
            foreach (var off in offs) {
                Console.WriteLine($"{off.id} {off.startdate} {off.enddate} {off.countryid}");
            }
        }
    }
}