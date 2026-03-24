namespace s33323;

public class Wypozyczenie
{
    private Uzytkownik osoba;
    private Sprzet sprzet;
    private DateOnly dataWypozyczenia;
    private DateOnly terminZwrotu;
    private DateOnly? dataZwrotu;

    public Wypozyczenie(Uzytkownik osoba, Sprzet sprzet)
    {
        this.osoba = osoba;
        this.sprzet = sprzet;
        this.dataWypozyczenia = DateOnly.FromDateTime(DateTime.Now);
        this.terminZwrotu = dataWypozyczenia.AddDays(14);
    }

    public void ZakonczWypozyczenie(DateOnly data) => dataZwrotu = data;//dataZwrotu = DateOnly.FromDateTime(DateTime.Now);

    public double ObliczKare()
    {
        if (dataZwrotu == null || dataZwrotu <= terminZwrotu) return 0;
        TimeSpan roznica = dataZwrotu.Value.ToDateTime(TimeOnly.MinValue) - terminZwrotu.ToDateTime(TimeOnly.MinValue);
        return roznica.Days * 5.0; // 5 PLN za każdy dzień zwłoki
    }

    public Uzytkownik getOsoba() => osoba;
    public Sprzet getSprzet() => sprzet;
    public DateOnly getTerminZwrotu() => terminZwrotu;
    public DateOnly? getDataZwrotu() => dataZwrotu;
}