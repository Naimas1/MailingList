public class DataUpdater
{
    private string connectionString;

    public DataUpdater(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void UpdateCustomer(int customerId, string newFirstName, string newLastName, string newEmail)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateCustomerQuery = $@"
                UPDATE Customers
                SET FirstName = '{newFirstName}', LastName = '{newLastName}', Email = '{newEmail}'
                WHERE CustomerId = {customerId}";

            ExecuteQuery(connection, updateCustomerQuery);
        }
    }

    public void UpdateCountry(int countryId, string newCountryName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateCountryQuery = $@"
                UPDATE Countries
                SET CountryName = '{newCountryName}'
                WHERE CountryId = {countryId}";

            ExecuteQuery(connection, updateCountryQuery);
        }
    }

    public void UpdateCity(int cityId, string newCityName, int newCountryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateCityQuery = $@"
                UPDATE Cities
                SET CityName = '{newCityName}', CountryId = {newCountryId}
                WHERE CityId = {cityId}";

            ExecuteQuery(connection, updateCityQuery);
        }
    }

    public void UpdateCategory(int categoryId, string newCategoryName)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateCategoryQuery = $@"
                UPDATE Categories
                SET CategoryName = '{newCategoryName}'
                WHERE CategoryId = {categoryId}";

            ExecuteQuery(connection, updateCategoryQuery);
        }
    }

    public void UpdateSpecialOffer(int offerId, string newProductName, int newCategoryId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string updateSpecialOfferQuery = $@"
                UPDATE SpecialOffers
                SET ProductName = '{newProductName}', CategoryId = {newCategoryId}
                WHERE OfferId = {offerId}";

            ExecuteQuery(connection, updateSpecialOfferQuery);
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
