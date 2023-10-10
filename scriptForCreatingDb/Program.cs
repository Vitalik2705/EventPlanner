using Npgsql;
using System;
using System.Data.SqlClient;


namespace UsingAdoNet
{
    class Program
    {
        private static string connString = "Host=localhost;Port=5432;Username=postgres;Password=vitalik;Database=EventPlanner";
        private static readonly Random random = new Random();
        static void Main(string[] args)
        {
            //InsertGenderData();
            //InsertPersonData(30); 
            //InsertEvents();
            //InsertIngredients();
            //InsertRecipes();
            //InsertRecipeIngredients();
            //InsertEventRecipe();
        }

        // EventRecipe DATA
        static void InsertEventRecipe()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < 30; i++)
            {
                int eventId = GenerateRandomId();
                int recipeId = GenerateRandomId();

                using (var cmd = new NpgsqlCommand("INSERT INTO EventRecipe (Event_Id, Recipe_Id) VALUES (@eventId, @recipeId)", conn))
                {
                    cmd.Parameters.AddWithValue("eventId", eventId);
                    cmd.Parameters.AddWithValue("recipeId", recipeId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Inserted Event Recipe: Event ID: {eventId}, Recipe ID: {recipeId}");
            }
        }

        // RecipeIngredient DATA
        static void InsertRecipeIngredients()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < 30; i++)
            {
                int amountOfIngredient = GenerateRandomAmountOfIngredient();
                int ingredientId = GenerateRandomId();
                int recipeId = GenerateRandomId();

                using (var cmd = new NpgsqlCommand("INSERT INTO RecipeIngredients (Amount_Of_Ingredient, Ingredient_Id, Recipe_Id) VALUES (@amountOfIngredient, @ingredientId, @recipeId)", conn))
                {
                    cmd.Parameters.AddWithValue("amountOfIngredient", amountOfIngredient);
                    cmd.Parameters.AddWithValue("ingredientId", ingredientId);
                    cmd.Parameters.AddWithValue("recipeId", recipeId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Inserted Recipe Ingredient: Amount: {amountOfIngredient}, Ingredient ID: {ingredientId}, Recipe ID: {recipeId}");
            }
        }

        static int GenerateRandomAmountOfIngredient()
        {
            return new Random().Next(1, 10);
        }

        // Recipe DATA
        static void InsertRecipes()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < 30; i++)
            {
                string recipeName = GenerateRandomRecipeName();
                int calory = GenerateRandomCalory();
                int cookingTime = GenerateRandomCookingTime();

                using (var cmd = new NpgsqlCommand("INSERT INTO Recipe (Name, Calory, Cooking_Time) VALUES (@recipeName, @calory, @cookingTime)", conn))
                {
                    cmd.Parameters.AddWithValue("recipeName", recipeName);
                    cmd.Parameters.AddWithValue("calory", calory);
                    cmd.Parameters.AddWithValue("cookingTime", cookingTime);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Inserted recipe: {recipeName}, Calory: {calory}, Cooking Time: {cookingTime}");
            }
        }

        static string GenerateRandomRecipeName()
        {
            string[] recipeNames = { "Spaghetti", "Chicken", "Chocolate", "Caesar", "Hamburger", "Sushi", "Pasta" };
            return recipeNames[new Random().Next(recipeNames.Length)];
        }

        static int GenerateRandomCalory()
        {
            return new Random().Next(100, 1000);
        }

        static int GenerateRandomCookingTime()
        {
            return new Random().Next(10, 120);
        }

        // Ingredient DATA
        static void InsertIngredients()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < 30; i++)
            {
                string ingredientName = GenerateRandomIngredientName();

                using (var cmd = new NpgsqlCommand("INSERT INTO Ingredient (Name) VALUES (@ingredientName)", conn))
                {
                    cmd.Parameters.AddWithValue("ingredientName", ingredientName);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Inserted ingredient: {ingredientName}");
            }
        }

        static string GenerateRandomIngredientName()
        {
            string[] ingredientNames = { "Salt", "Sugar", "Flour", "Milk", "Eggs", "Butter", "Chocolate", "Tomatoes", "Onions", "Garlic" };
            return ingredientNames[new Random().Next(ingredientNames.Length)];
        }

        // Event DATA
        static void InsertEvents()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < 30; i++)
            {
                string eventName = GenerateRandomEventName();
                int personId = GenerateRandomId();

                using (var cmd = new NpgsqlCommand("INSERT INTO Event (Name, Person_Id) VALUES (@eventName, @personId)", conn))
                {
                    cmd.Parameters.AddWithValue("eventName", eventName);
                    cmd.Parameters.AddWithValue("personId", personId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine($"Inserted event: {eventName}, PersonId: {personId}");
            }
        }

        static string GenerateRandomEventName()
        {
            string[] eventNames = { "Birthday Party", "Wedding", "Conference", "Music Festival", "Corporate Event" };
            return eventNames[new Random().Next(eventNames.Length)];
        }

        static int GenerateRandomId()
        {
            return new Random().Next(1, 31);
        }

        // Person DATA
        static void InsertPersonData(int rowCount)
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            for (int i = 0; i < rowCount; i++)
            {
                string name = GenerateRandomName();
                string surname = GenerateRandomSurname();
                string email = GenerateRandomEmail(name, surname);
                string password = GenerateRandomPassword();
                string phoneNumber = GenerateRandomPhoneNumber();
                int genderId = GenerateRandomGenderId();

                InsertPerson(conn, name, surname, email, password, phoneNumber, genderId);
            }

            Console.WriteLine($"{rowCount} rows inserted into 'Person' table successfully.");
        }

        static void InsertPerson(NpgsqlConnection conn, string name, string surname, string email, string password, string phoneNumber, int genderId)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO Person (Name, Surname, Email, Password, Phone_Number, Gender_Id) VALUES (@name, @surname, @email, @password, @phoneNumber, @genderId)", conn))
            {
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("surname", surname);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("password", password);
                cmd.Parameters.AddWithValue("phoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("genderId", genderId);
                cmd.ExecuteNonQuery();
            }
        }

        public static string GenerateRandomName()
        {
            string[] names = { "John", "Alice", "Bob", "Emily", "David", "Olivia" };
            return names[random.Next(names.Length)];
        }

        public static string GenerateRandomSurname()
        {
            string[] surnames = { "Smith", "Johnson", "Brown", "Davis", "Wilson", "Lee" };
            return surnames[random.Next(surnames.Length)];
        }

        public static string GenerateRandomEmail(string name, string surname)
        {
            string[] domains = { "example.com", "test.com", "sample.net" };
            string randomDomain = domains[random.Next(domains.Length)];
            return $"{name}.{surname}@{randomDomain}".ToLower();
        }

        public static string GenerateRandomPassword()
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] password = new char[8];

            for (int i = 0; i < password.Length; i++)
            {
                password[i] = allowedChars[random.Next(allowedChars.Length)];
            }

            return new string(password);
        }

        public static string GenerateRandomPhoneNumber()
        {
            string phoneNumber = "+1";
            for (int i = 0; i < 10; i++)
            {
                phoneNumber += random.Next(10);
            }

            return phoneNumber;
        }

        //Gender DATA
        public static int GenerateRandomGenderId()
        {
            return random.Next(1, 3);
        }

        static void InsertGenderData()
        {
            using var conn = new NpgsqlConnection(connString);
            conn.Open();

            InsertGender(conn, "Male");
            InsertGender(conn, "Female");

            Console.WriteLine("Gender data inserted into 'Gender' table successfully.");
        }

        static void InsertGender(NpgsqlConnection conn, string gender)
        {
            using (var cmd = new NpgsqlCommand("INSERT INTO Gender (Name) VALUES (@p)", conn))
            {
                cmd.Parameters.AddWithValue("p", gender);
                cmd.ExecuteNonQuery();
            }
        }

        
        static void CreateDataBase()
        {
            using var conn = new NpgsqlConnection(connString);

            var query = @"CREATE TABLE IF NOT EXISTS Gender
                          (
                            Id SERIAL PRIMARY KEY,
                            Name VARCHAR(10) NOT NULL
                          );
                          CREATE TABLE IF NOT EXISTS Person
                          (
                            Id SERIAL PRIMARY KEY,
                            Name VARCHAR(20) NOT NULL,
                            Surname VARCHAR(20) NOT NULL,
                            Email VARCHAR(30) NOT NULL,
                            Password VARCHAR(20) NOT NULL,
                            Phone_Number VARCHAR (15),                                             
                            Gender_Id INT NOT NULL,
                                FOREIGN KEY (Gender_Id) REFERENCES Gender(Id)
                          );
                          CREATE TABLE IF NOT EXISTS Event
                          (
                            Id SERIAL PRIMARY KEY,
                            Name VARCHAR(20) NOT NULL,
                            Person_Id INT NOT NULL,
                                FOREIGN KEY (Person_Id) REFERENCES Person(Id)
                          );
                          CREATE TABLE IF NOT EXISTS Ingredient
                          (
                            Id SERIAL PRIMARY KEY,
                            Name VARCHAR(10) NOT NULL
                          );
                          CREATE TABLE IF NOT EXISTS Recipe
                          (
                            Id SERIAL PRIMARY KEY,
                            Name VARCHAR(10) NOT NULL,
                            Calory INT NOT NULL,
                            Cooking_Time INT NOT NULL
                          );
                          CREATE TABLE IF NOT EXISTS RecipeIngredients
                          (
                            Id SERIAL PRIMARY KEY,
                            Amount_Of_Ingredient INT NOT NULL,
                            Ingredient_Id INT NOT NULL,
                                FOREIGN KEY (Ingredient_Id) REFERENCES Ingredient(Id),
                            Recipe_Id INT NOT NULL,
                                FOREIGN KEY (Recipe_Id) REFERENCES Recipe(Id)
                          );
                          CREATE TABLE IF NOT EXISTS EventRecipe
                          (
                            Id SERIAL PRIMARY KEY,
                            Event_Id INT NOT NULL,
                                FOREIGN KEY (Event_Id) REFERENCES Event(Id),
                            Recipe_Id INT NOT NULL,
                                FOREIGN KEY (Recipe_Id) REFERENCES Recipe(Id)
                          );";

            using var cmd = new NpgsqlCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Successfully");
            }

            finally
            {
                conn.Close();
                Console.ReadKey();
            }
        }
    }
}
