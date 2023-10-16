using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO3
{
    class DbRequests
    {
        public void GroupByGender(string connString)
        {
            using var conn = new NpgsqlConnection(connString);

            string query = @"
                SELECT Gender.Name, COUNT(Person.Id) AS TotalCount
                FROM Gender
                LEFT JOIN Person ON Gender.Id = Person.Gender_Id
                GROUP BY Gender.Name;";

            using var cmd = new NpgsqlCommand(query, conn);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string genderName = reader["Name"].ToString();
                int totalCount = Convert.ToInt32(reader["TotalCount"]);
                Console.WriteLine($"{genderName}: {totalCount}");
            }

            conn.Close();
        }

        public void DeleteRecipeIngredients(int id, string connString)
        {
            using var conn = new NpgsqlConnection(connString);

            var query = "DELETE FROM recipeingredients WHERE recipeingredients.id = @Id";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Deleted Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateRecipeIngredient(int id, int newAmount, string connString)
        {
            using var conn = new NpgsqlConnection(connString);

            var query = "UPDATE recipeingredients SET Amount_Of_Ingredient = @NewAmount WHERE id = @Id";

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@NewAmount", newAmount);
            cmd.Parameters.AddWithValue("@Id", id);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Updated Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }

        public void SortAndDisplayTable(string connString, string tableName, string orderByColumn)
        {
            using var conn = new NpgsqlConnection(connString);

            // Складайте запит, вставляючи значення tableName та orderByColumn в рядок SQL
            var query = $"SELECT * FROM {tableName} ORDER BY {orderByColumn} ASC";

            using var cmd = new NpgsqlCommand(query, conn);
            conn.Open();

            using var reader = cmd.ExecuteReader();

            Console.WriteLine($"Sorted by {orderByColumn} ASC:");
            Console.WriteLine("------------------------------");

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i]}\t");
                }
                Console.WriteLine();
            }

            conn.Close();
        }

        public int FindMaxValueInColumn(string connString, string tableName, string columnName)
        {
            using var conn = new NpgsqlConnection(connString);
            int maxValue = 0; // Змінна для зберігання максимального значення

            var query = $"SELECT MAX({columnName}) FROM {tableName}";

            using var cmd = new NpgsqlCommand(query, conn);
            conn.Open();

            // Виконати запит і отримати результат
            var result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                maxValue = Convert.ToInt32(result);
                Console.WriteLine($"Max value of {columnName}:");
                Console.Write($"{maxValue}\t");
            }

            conn.Close();

            return maxValue;
        }

        private static string connString = "Host=localhost;Port=5432;Username=postgres;Password=vitalik;Database=EventPlanner";

        static void Main(string[] args)
        {
            //InsertGenderData();
            //InsertPersonData(30); 
            //InsertEvents();
            //InsertIngredients();
            //InsertRecipes();
            //InsertRecipeIngredients();
            //InsertEventRecipe();
            DbRequests db = new DbRequests();
            db.GroupByGender(connString);
            //db.DeleteRecipeIngredients(2, connString);
            db.UpdateRecipeIngredient(2, 4, connString);
            db.SortAndDisplayTable(connString, "recipeingredients", "Amount_Of_Ingredient");
            db.FindMaxValueInColumn(connString, "recipeingredients", "ingredient_id");
        }
    }
}
