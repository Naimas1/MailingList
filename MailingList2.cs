public class MailingList2
{
    private List<string> mailingSections;

    public MailingList2()
    {
        mailingSections = new List<string>();
    }

    public void AddSection(string section)
    {
        mailingSections.Add(section);
    }

    public List<string> GetTop3PopularSections()
    {
        // Реалізація логіки отримання Топ-3 найпопулярніших розділів розсилки
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає список назв розділів
        return mailingSections.Take(3).ToList();
    }

    public string GetMostPopularSection()
    {
        // Реалізація логіки отримання найпопулярнішого розділу розсилки
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає назву розділу
        return mailingSections.GroupBy(s => s).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
    }

    public List<string> GetTop3UnpopularSections()
    {
        // Реалізація логіки отримання Топ-3 найнепопулярніших розділів розсилки
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає список назв розділів
        return mailingSections.GroupBy(s => s).OrderBy(g => g.Count()).Take(3).Select(g => g.Key).ToList();
    }

    public string GetMostUnpopularSection()
    {
        // Реалізація логіки отримання найнепопулярнішого розділу розсилки
        // Може використовувати ADO.NET для роботи з базою даних
        // Повертає назву розділу
        return mailingSections.GroupBy(s => s).OrderBy(g => g.Count()).Select(g => g.Key).FirstOrDefault();
    }
}
