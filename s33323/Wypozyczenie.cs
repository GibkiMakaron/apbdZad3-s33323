namespace s33323;

public class Wypozyczenie
{
    private Object osoba;
    private Object sprzet;
    
    DateOnly dataWypozyczenia;
    DateOnly terminZwrotu;
    DateOnly dataZwrotu;

    Wypozyczenie(object osoba, object sprzet, DateOnly dataZwrotu)
    {
        this.osoba = osoba;
        this.sprzet = sprzet;
        dataWypozyczenia = DateOnly.FromDateTime(DateTime.Now);
        terminZwrotu = DateOnly.FromDateTime(DateTime.Now.AddMonths(1));
        this.dataZwrotu = dataZwrotu;
    }

    public Object getOsoba()
    {
        return osoba;
    }

    public Object getSprzet()
    {
        return sprzet;
    }
}