public class DataDeleter
{
    private string connectionString;

    public DataDeleter(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void DeleteCustomer(int customerId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteCustomerQuery = $@"
                DELETE FROM Customers
                WHERE CustomerId = {customerId}";

            ExecuteQuery(connection, deleteCustomerQuery);
        }
    }

    public void DeleteCountry(int countryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteCountryQuery = $@"
                DELETE FROM Countries
                WHERE CountryId = {countryId}";

            ExecuteQuery(connection, deleteCountryQuery);
        }
    }

    public void DeleteCity(int cityId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteCityQuery = $@"
                DELETE FROM Cities
                WHERE CityId = {cityId}";

            ExecuteQuery(connection, deleteCityQuery);
        }
    }

    public void DeleteCategory(int categoryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteCategoryQuery = $@"
                DELETE FROM Categories
                WHERE CategoryId = {categoryId}";

            ExecuteQuery(connection, deleteCategoryQuery);
        }
    }

    public void DeleteSpecialOffer(int offerId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string deleteSpecialOfferQuery = $@"
                DELETE FROM SpecialOffers
                WHERE OfferId = {offerId}";

            ExecuteQuery(connection, deleteSpecialOfferQuery);
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
