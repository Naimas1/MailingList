public class MailingListStatistics
{
    private Dictionary<string, int> specialOffersCountBySection;
    private List<SpecialOffer> specialOffers;

    public MailingListStatistics()
    {
        specialOffersCountBySection = new Dictionary<string, int>();
        specialOffers = new List<SpecialOffer>();
    }

    public void AddSpecialOffer(string section, SpecialOffer specialOffer)
    {
        if (!specialOffersCountBySection.ContainsKey(section))
        {
            specialOffersCountBySection[section] = 0;
        }

        specialOffersCountBySection[section]++;
        specialOffers.Add(specialOffer);
    }

    public List<string> GetTop3SectionsBySpecialOffersCount()
    {
        // Реалізація логіки отримання Топ-3 розділів розсилки за кількістю акційних товарів
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає список назв розділів
        return specialOffersCountBySection.OrderByDescending(kv => kv.Value).Take(3).Select(kv => kv.Key).ToList();
    }

    public string GetSectionWithMostSpecialOffers()
    {
        // Реалізація логіки отримання розділу розсилки з найбільшою кількістю акційних товарів
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає назву розділу
        return specialOffersCountBySection.OrderByDescending(kv => kv.Value).FirstOrDefault().Key;
    }

    public List<string> GetTop3SectionsByLeastSpecialOffersCount()
    {
        // Реалізація логіки отримання Топ-3 розділів розсилки з найменшою кількістю акційних товарів
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає список назв розділів
        return specialOffersCountBySection.OrderBy(kv => kv.Value).Take(3).Select(kv => kv.Key).ToList();
    }

    public string GetSectionWithLeastSpecialOffers()
    {
        // Реалізація логіки отримання розділу розсилки з найменшою кількістю акційних товарів
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає назву розділу
        return specialOffersCountBySection.OrderBy(kv => kv.Value).FirstOrDefault().Key;
    }
}
