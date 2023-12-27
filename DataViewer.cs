public class DataViewer
{
    private string connectionString;

    public DataViewer(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<string> GetCitiesByCountry(string countryName)
    {
        List<string> cities = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string getCitiesQuery = $@"
                SELECT CityName
                FROM Cities
                INNER JOIN Countries ON Cities.CountryId = Countries.CountryId
                WHERE Countries.CountryName = '{countryName}'";

            using (SqlCommand command = new SqlCommand(getCitiesQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cities.Add(reader["CityName"].ToString());
                    }
                }
            }
        }

        return cities;
    }

    public List<string> GetCategoriesByCustomer(int customerId)
    {
        List<string> categories = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string getCategoriesQuery = $@"
                SELECT DISTINCT Categories.CategoryName
                FROM Categories
                INNER JOIN SpecialOffers ON Categories.CategoryId = SpecialOffers.CategoryId
                INNER JOIN Purchases ON SpecialOffers.OfferId = Purchases.OfferId
                INNER JOIN Customers ON Purchases.CustomerId = Customers.CustomerId
                WHERE Customers.CustomerId = {customerId}";

            using (SqlCommand command = new SqlCommand(getCategoriesQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader["CategoryName"].ToString());
                    }
                }
            }
        }

        return categories;
    }

    public List<string> GetSpecialOffersByCategory(string categoryName)
    {
        List<string> specialOffers = new List<string>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string getSpecialOffersQuery = $@"
                SELECT ProductName
                FROM SpecialOffers
                WHERE CategoryId IN (SELECT CategoryId FROM Categories WHERE CategoryName = '{categoryName}')";

            using (SqlCommand command = new SqlCommand(getSpecialOffersQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        specialOffers.Add(reader["ProductName"].ToString());
                    }
                }
            }
        }

        return specialOffers;
    }
}
