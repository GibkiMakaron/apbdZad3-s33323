namespace s33323;

public abstract class Uzytkownik
{
    protected int id;
    protected string imie;
    protected string nazwisko;
    protected string typ;
}

public class Student : Uzytkownik
{
    public Student(int id, string imie, string nazwisko)
    {
        this.id = id;
        this.imie = imie;
        this.nazwisko = nazwisko;
        typ = "student";
    }
}

public class Pracownik : Uzytkownik
{
    public Pracownik(int id, string imie, string nazwisko)
    {
        this.id = id;
        this.imie = imie;
        this.nazwisko = nazwisko;
        typ = "pracownik";
    }
}