using Microsoft.Data.SqlClient;

string connectionString =
    "Server=(localdb)\\MSSQLLocalDB;Database=Volleyball;Integrated Security=True;";

using (SqlConnection connection = new SqlConnection(connectionString))
{

    connection.Open();
    //using (SqlCommand command =
    //    new SqlCommand("INSERT INTO Persons (FirstName, LastName) VALUES(@FirstName, @LastName)", connection))
    //{
    //    command.Parameters.AddWithValue("@FirstName", "John");
    //    command.Parameters.AddWithValue("@LastName", "Doe");
    //    int rowsAffected = command.ExecuteNonQuery();
    //    Console.WriteLine($"{rowsAffected} rows affected.");
    //}


    using (SqlCommand command =
        new SqlCommand("SELECT Id, FirstName, LastName FROM Persons", connection))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"" +
                    $"Id: {reader.GetInt32(0)}, " +
                    $"FirstName: {reader.GetString(1)}, " +
                    $"LastName: {reader.GetString(2)}");
            }
        }
    }

    //using (SqlCommand command = 
    //    new SqlCommand("UPDATE Persons SET FirstName =@FirstName WHERE Id = @Id", connection))
    //{
    //command.Parameters.AddWithValue("@Id", 6);
    //    command.Parameters.AddWithValue("@FirstName", "UpdatedFirstName");
    //    int rowsAffected = command.ExecuteNonQuery();
    //    Console.WriteLine($"{rowsAffected} rows affected.");
    //}

    try
    {
        //int a = 0;
        //int b = 5 / a;
        using (SqlCommand command = new SqlCommand("DELETE FROM Person WHERE Id = @Id", connection))
        {
            command.Parameters.AddWithValue("@Id", 6);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} rows affected.");
        }
    }
    catch (SqlException ex)
    {
        Console.WriteLine("An error occurred while connecting to the database or executing the command: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("An unexpected error occurred: " + ex.Message);
    }




}

