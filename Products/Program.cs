using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "Server=localhost;Database=Tienda;Uid=root;Pwd=root;";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Crear Producto");
            Console.WriteLine("2. Leer Productos");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.WriteLine("5. Salir");

            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    CrearProducto();
                    break;
                case "2":
                    LeerProductos();
                    break;
                case "3":
                    ActualizarProducto();
                    break;
                case "4":
                    EliminarProducto();
                    break;
                case "5":
                    return;
            }
        }
    }

    static void CrearProducto()
    {
        Console.WriteLine("Ingrese el nombre del producto:");
        var nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el precio del producto:");
        var precio = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Ingrese la fecha del producto (YYYY-MM-DD):");
        var fecha = Console.ReadLine();

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO Productos (Nombre, Precio, Fecha) VALUES (@nombre, @precio, @fecha)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@fecha", fecha);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Producto creado con éxito.");
    }

    static void LeerProductos()
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Productos";
            using (var command = new MySqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    Console.WriteLine("ID\tNombre\t\tPrecio\t\tFecha");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ID_Producto"]}\t{reader["Nombre"]}\t\t{reader["Precio"]}\t\t{reader["Fecha"]}");
                    }
                }
            }
        }
    }

    static void ActualizarProducto()
    {
        Console.WriteLine("Ingrese el ID del producto a actualizar:");
        var id = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el nuevo nombre:");
        var nombre = Console.ReadLine();

        Console.WriteLine("Ingrese el nuevo precio:");
        var precio = Convert.ToDecimal(Console.ReadLine());

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE Productos SET Nombre = @nombre, Precio = @precio WHERE ID_Producto = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Producto actualizado con éxito.");
    }

    static void EliminarProducto()
    {
        Console.WriteLine("Ingrese el ID del producto a eliminar:");
        var id = Convert.ToInt32(Console.ReadLine());

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM Productos WHERE ID_Producto = @id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        Console.WriteLine("Producto eliminado con éxito.");
    }
}