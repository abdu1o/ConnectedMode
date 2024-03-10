using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ConnectedMode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

            Console.WriteLine("[0] - add new products \n" +
                "[1] - add new types \n" +
                "[2] - add new managers \n" +
                "[3] - add new producers \n" +
                "[4] - update products \n" +
                "[5] - update types \n" +
                "[6] - update managers \n" +
                "[7] - update producers \n" +
                "[8] - delete products \n" +
                "[9] - delete types \n" +
                "[10] - delete managers \n" +
                "[11] - delete producers \n");
                

            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

            DbController controller;

            Dictionary<string, object> newValues = new Dictionary<string, object>();

            switch (choice)
            {

                case 0:

                    newValues.Add("name", "shaurma");
                    newValues.Add("price", 120);

                    controller = new DbController("INSERT INTO Products (name, price) VALUES (@name, @price)");
                    controller.Add(newValues);
                    controller.Print("Products");
                    break;

                case 1:
                    newValues.Add("name", "CLAY");

                    controller = new DbController("INSERT INTO Types (name) VALUES (@name)");
                    controller.Add(newValues);
                    controller.Print("Types");
                    break;

                case 2:
                    newValues.Add("name", "IVAN");

                    controller = new DbController("INSERT INTO Managers (name) VALUES (@name)");
                    controller.Add(newValues);
                    controller.Print("Managers");
                    break;

                case 3:
                    newValues.Add("name", "OLEG");

                    controller = new DbController("INSERT INTO Producers (name) VALUES (@name)");
                    controller.Add(newValues);
                    controller.Print("Producers");
                    break;

                case 4:
                    controller = new DbController("UPDATE Products SET name = @name, price = @price WHERE id = @id");

                    newValues.Add("name", "CLAAAAAy");
                    newValues.Add("price", 1234);

                    controller.Update(newValues, 2);
                    controller.Print("Products");
                    break;

                case 5:
                    controller = new DbController("UPDATE Types SET name = @name WHERE id = @id");

                    newValues.Add("name", "CLAAAAAy");

                    controller.Update(newValues, 1);
                    controller.Print("Types");
                    break;

                case 6:
                    controller = new DbController("UPDATE Managers SET name = @name WHERE id = @id");

                    newValues.Add("name", "CLAAAAAy");

                    controller.Update(newValues, 1);
                    controller.Print("Managers");
                    break;

                case 7:
                    controller = new DbController("UPDATE Producers SET name = @name WHERE id = @id");

                    newValues.Add("name", "CLAAAAAy");

                    controller.Update(newValues, 1);
                    controller.Print("Producers");
                    break;

                case 8:
                    controller = new DbController("DELETE FROM Products WHERE id = @id");
                    controller.Delete(1);
                    controller.Print("Products");
                    break;

                case 9:
                    controller = new DbController("DELETE FROM Types WHERE id = @id");
                    controller.Delete(1);
                    controller.Print("Types");
                    break;

                case 10:
                    controller = new DbController("DELETE FROM Managers WHERE id = @id");
                    controller.Delete(1);
                    controller.Print("Managers");
                    break;

                case 11:
                    controller = new DbController("DELETE FROM Producers WHERE id = @id");
                    controller.Delete(1);
                    controller.Print("Producers");
                    break;

                default:
                    Console.WriteLine("Wrong number");
                    break;

            };
        }
    }
}
