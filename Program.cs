using System;
using System.Data;
using System.Data.SqlClient;

public class MailingList
{
    private string connectionString;

    public MailingList(string connectionString)
    {
        this.connectionString = connectionString;
        InitializeDatabase();
    }
    class Program
    {
        static void Main()
        {
            string connectionString = "YourConnectionStringHere"; // Замініть на власний рядок підключення до бази даних

            MailingList mailingList = new MailingList(connectionString);
            DataUpdater dataUpdater = new DataUpdater(connectionString);

            // Приклад викликів функцій для вставки інформації
            mailingList.InsertCustomer("John", "Doe", "john.doe@example.com");

            // Приклад викликів функцій для оновлення інформації
            dataUpdater.UpdateCustomer(1, "John", "Doe", "new.email@example.com");
        }
    }
    class Program1
    {
        static void Main()
        {
            string connectionString = "YourConnectionStringHere"; // Замініть на власний рядок підключення до бази даних

            MailingList mailingList = new MailingList(connectionString);
            DataUpdater dataUpdater = new DataUpdater(connectionString);
            DataDeleter dataDeleter = new DataDeleter(connectionString);

            // Приклад викликів функцій для вставки і оновлення інформації
            mailingList.InsertCustomer("John", "Doe", "john.doe@example.com");
            dataUpdater.UpdateCustomer(1, "John", "Doe", "new.email@example.com");

            // Приклад викликів функцій для видалення інформації
            dataDeleter.DeleteCustomer(1);
        }
    }
    class Program2
    {
        static void Main()
        {
            string connectionString = "YourConnectionStringHere"; // Замініть на власний рядок підключення до бази даних

            DataViewer dataViewer = new DataViewer(connectionString);

            // Приклад викликів функцій для відображення списків
            List<string> citiesInCountry = dataViewer.GetCitiesInCountry("United States");
            List<string> categoriesOfCustomer = dataViewer.GetCategoriesOfCustomer(1);
            List<string> specialOffersInCategory = dataViewer.GetSpecialOffersInCategory("Electronics");

            // Виведення результатів
            Console.WriteLine("Cities in United States:");
            foreach (var city in citiesInCountry)
            {
                Console.WriteLine(city);
            }

            Console.WriteLine("\nCategories of Customer 1:");
            foreach (var category in categoriesOfCustomer)
            {
                Console.WriteLine(category);
            }

            Console.WriteLine("\nSpecial Offers in Electronics:");
            foreach (var specialOffer in specialOffersInCategory)
            {
                Console.WriteLine(specialOffer);
            }
        }
    }

    private void InitializeDatabase()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Логіка створення таблиць та інші необхідні дії ініціалізації бази даних
            string createTablesQuery = @"
                CREATE TABLE Customers (
                    CustomerId INT PRIMARY KEY IDENTITY(1,1),
                    FirstName NVARCHAR(50),
                    LastName NVARCHAR(50),
                    Email NVARCHAR(255) NOT NULL UNIQUE
                );

                CREATE TABLE Countries (
                    CountryId INT PRIMARY KEY IDENTITY(1,1),
                    CountryName NVARCHAR(50) NOT NULL UNIQUE
                );

                CREATE TABLE Cities (
                    CityId INT PRIMARY KEY IDENTITY(1,1),
                    CityName NVARCHAR(50) NOT NULL,
                    CountryId INT FOREIGN KEY REFERENCES Countries(CountryId)
                );

                CREATE TABLE Categories (
                    CategoryId INT PRIMARY KEY IDENTITY(1,1),
                    CategoryName NVARCHAR(50) NOT NULL UNIQUE
                );

                CREATE TABLE SpecialOffers (
                    OfferId INT PRIMARY KEY IDENTITY(1,1),
                    ProductName NVARCHAR(50) NOT NULL,
                    CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId)
                );";


            ExecuteQuery(connection, createTablesQuery);
        }
    }

    public void InsertCustomer(string firstName, string lastName, string email)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertCustomerQuery = $@"
                INSERT INTO Customers (FirstName, LastName, Email)
                VALUES ('{firstName}', '{lastName}', '{email}')";

            ExecuteQuery(connection, insertCustomerQuery);
        }
    }

    public void InsertCountry(string countryName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertCountryQuery = $@"
                INSERT INTO Countries (CountryName)
                VALUES ('{countryName}')";

            ExecuteQuery(connection, insertCountryQuery);
        }
    }

    public void InsertCity(string cityName, int countryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertCityQuery = $@"
                INSERT INTO Cities (CityName, CountryId)
                VALUES ('{cityName}', {countryId})";

            ExecuteQuery(connection, insertCityQuery);
        }
    }

    public void InsertCategory(string categoryName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertCategoryQuery = $@"
                INSERT INTO Categories (CategoryName)
                VALUES ('{categoryName}')";

            ExecuteQuery(connection, insertCategoryQuery);
        }
    }

    public void InsertSpecialOffer(string productName, int categoryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string insertSpecialOfferQuery = $@"
                INSERT INTO SpecialOffers (ProductName, CategoryId)
                VALUES ('{productName}', {categoryId})";

            ExecuteQuery(connection, insertSpecialOfferQuery);
        }
    }

    private void ExecuteQuery(SqlConnection connection, string query)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}

class Program
{
    static void Main()
    {
        string connectionString = "YourConnectionStringHere"; // Замініть на власний рядок підключення до бази даних

        MailingList mailingList = new MailingList(connectionString);

        // Приклад викликів функцій для вставки інформації
        mailingList.InsertCustomer("John", "Doe", "john.doe@example.com");
        mailingList.InsertCountry("United States");
        mailingList.InsertCity("New York", 1);
        mailingList.InsertCategory("Electronics");
        mailingList.InsertSpecialOffer("Smartphone", 1);
    }
}
