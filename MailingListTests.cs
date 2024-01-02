public class MailingListTests
{
    public object CollectionAssert { get; private set; }

    public void GetTop3PopularSections_ReturnsCorrectResult()
    {
        // Arrange
        var mailingList = new MailingList();
        mailingList.AddSection("News");
        mailingList.AddSection("Sports");
        mailingList.AddSection("News");
        mailingList.AddSection("Technology");
        mailingList.AddSection("Sports");
        mailingList.AddSection("Entertainment");

        // Act
        var result = mailingList.GetTop3PopularSections();

        // Assert
        CollectionAssert.AreEqual(new List<string> { "News", "Sports", "Technology" }, result);
    }
}
