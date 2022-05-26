using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Net.Http;
using ConsumirAPI.Models;
using System.Collections.Generic;

namespace ConsumirAPI
{
    class Program
    {
          
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            int res;
            int Salida;

            do
            {

                Console.WriteLine("Realizar busqueda por: 1. Id, 2. Gender, 3. Status, 4. Todos");
                string Line = Console.ReadLine();
                res = Int32.Parse(Line);

                if (res == 1)
                {
                    await GetID();
                }
                else if (res == 2)
                {
                    await GetGender();
                }
                else if (res == 3)
                {
                    await GetStatus();
                }
                else if (res == 4)
                {
                    string url = "https://gorest.co.in/public/v2/users";
                    var httpResponse = await client.GetAsync(url);
                    List<Models.User> users = new List<Models.User>();

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        users = JsonSerializer.Deserialize<List<Models.User>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    }
                    foreach (var item in users)
                    {
                        Console.WriteLine("<" + item.id + "> - <" + item.name + "> - <"
                            + item.email + "> - <" + item.gender + "> - <" + item.status + ">");
                        Console.WriteLine("");

                    }
                } else
                {
                    Console.WriteLine("Ingreso una Opcion Incorrecta");
                }
                Console.WriteLine("Desea Salir?  1. Si, 2.No");
                string Res = Console.ReadLine();
                 Salida = Int32.Parse(Res);

            }
            while (Salida!=1);
            Console.ReadKey();
        }

        static async Task GetID()
        {
            int id = 0;
            string Line;

            Console.WriteLine("Ingrese el ID a buscar: ");
            Line = Console.ReadLine();
            id = Int32.Parse(Line);

            string url = "https://gorest.co.in/public/v2/users?id=" + id;
            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);
            List<User> users = new List<User>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                users = JsonSerializer.Deserialize<List<Models.User>>(content);

                if (users.Count > 0) {
                    foreach (var item in users)
                    {
                        Console.WriteLine("<" + item.id + "> - <" + item.name + "> - <"
                            + item.email + "> - <" + item.gender + "> - <" + item.status + ">");
                        Console.WriteLine("");

                    }
                } else
                {
                    Console.WriteLine("Usted Ingreso un ID Incorrecto");
                    Console.ReadLine();
                }
                
            } 

            

        }

        static async Task GetGender()
        {
            int response = 0;
            string Line;
            string Gender;

            Console.WriteLine("Ingrese el Genero a buscar: 1. Male, 2. Female");
            Line = Console.ReadLine();
            response = Int32.Parse(Line);

            if (response == 1)
            {
                Gender = "male";
            } else
            {
                Gender = "female";
            }

            string url = "https://gorest.co.in/public/v2/users?gender=" + Gender;
            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);
            List<User> users = new List<User>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                users = JsonSerializer.Deserialize<List<Models.User>>(content);

                if (users.Count > 0)
                {
                    foreach (var item in users)
                    {
                        Console.WriteLine("<" + item.id + "> - <" + item.name + "> - <"
                            + item.email + "> - <" + item.gender + "> - <" + item.status + ">");
                        Console.WriteLine("");

                    }
                }
                else
                {
                    Console.WriteLine("Usted Ingreso un Valor Incorrecto");
                    Console.ReadLine();
                }
            } 

            

        }

        static async Task GetStatus()
        {
            int response = 0;
            string Line;
            string Status;

            Console.WriteLine("Ingrese el Estatus a buscar: 1. active, 2. inactive");
            Line = Console.ReadLine();
            response = Int32.Parse(Line);

            if (response == 1)
            {
                Status = "active";
            }
            else
            {
                Status = "inactive";
            }

            string url = "https://gorest.co.in/public/v2/users?status=" + Status;
            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);
            List<User> users = new List<User>();

            if (httpResponse.IsSuccessStatusCode)
            {
                var content = await httpResponse.Content.ReadAsStringAsync();
                users = JsonSerializer.Deserialize<List<Models.User>>(content);

                if (users.Count > 0)
                {
                    foreach (var item in users)
                    {
                        Console.WriteLine("<" + item.id + "> - <" + item.name + "> - <"
                            + item.email + "> - <" + item.gender + "> - <" + item.status + ">");
                        Console.WriteLine("");

                    }
                }
                else
                {
                    Console.WriteLine("Usted Ingreso un Valor Incorrecto");
                    Console.ReadLine();
                }
            }



        }
    }
}
