using System;
using System.Data.SqlClient;

namespace ProductInventoryDbConnect
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string constr = "server=PRIYANKAREDDY;database=ProductInventoryDb;trusted_connection=true;";

        static void Main(string[] args)
        {
            try
            {
                con = new SqlConnection(constr);
                Console.WriteLine("Choose the operation 1.display 2.add 3.delete 4.update");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        {
                            cmd = new SqlCommand
                            {
                                Connection = con,
                                CommandText = "SELECT * FROM Product"
                            };
                            con.Open();
                            reader = cmd.ExecuteReader();

                            Console.WriteLine("Product ID\tProduct Name\tProduct Price\tProduct Quantity\tMfDate\t\tExpDate");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader["ProductId"]}\t\t{reader["ProductName"]}\t\t{reader["Price"]}\t\t{reader["Quantity"]}\t\t{reader["MfDate"]}\t\t{reader["ExpDate"]}");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Product Id");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Price");
                            double price = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Product Quantity");
                            int qty = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Manufacturing Date");
                            DateTime mfdate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Expiry Date");
                            DateTime expdate = DateTime.Parse(Console.ReadLine());

                            cmd = new SqlCommand("INSERT INTO Products VALUES (@Id, @Name, @Price, @Quantity,@MfDate, @ExpDate)", con);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@Name", name);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@Quantity", qty);
                            cmd.Parameters.AddWithValue("@MfDate", mfdate);
                            cmd.Parameters.AddWithValue("@ExpDate", expdate);
                            con.Open();
                            int rowsInserted = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{rowsInserted} row(s) inserted.");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Product Id to be deleted");
                            int id = int.Parse(Console.ReadLine());
                            cmd = new SqlCommand("DELETE FROM Products WHERE ProductId = @Id", con);
                            cmd.Parameters.AddWithValue("@Id", id);
                            con.Open();
                            int rowsDeleted = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{rowsDeleted} row(s) deleted.");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Id to be updated");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new Name");
                            string newname = Console.ReadLine();
                            Console.WriteLine("Enter new Price");
                            double newprice = double.Parse(Console.ReadLine());
                            Console.WriteLine("Enter new Quantity");
                            int newqty = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Manufacturing Date");
                            DateTime newmfdate = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter New Expiry Date");
                            DateTime newexpdate = DateTime.Parse(Console.ReadLine());

                            cmd = new SqlCommand("UPDATE Products SET ProductName=@NewName, Price=@NewPrice,Quantity=@NewQuantity, MfDate=@NewMfDate, ExpDate=@NewExpDate WHERE ProductId=@Id", con);
                            cmd.Parameters.AddWithValue("@Id", id);
                            cmd.Parameters.AddWithValue("@NewName", newname);
                            cmd.Parameters.AddWithValue("@NewPrice", newprice);
                            cmd.Parameters.AddWithValue("@NewQuantity", newqty);
                            cmd.Parameters.AddWithValue("@NewMfDate", newmfdate);
                            cmd.Parameters.AddWithValue("@NewExpDate", newexpdate);

                            con.Open();
                            int rowsUpdated = cmd.ExecuteNonQuery();
                            Console.WriteLine($"{rowsUpdated} row(s) updated.");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
