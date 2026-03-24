namespace s33323;

public abstract class Uzytkownik
{
    protected static int id;
    protected int faktId;
    protected string imie;
    protected string nazwisko;
    protected string typ;
    
    public int getId() => this.faktId;
    public string getImie() => this.imie;
    public string getNazwisko() => this.nazwisko;
    public string getTyp() => this.typ;
}

public class Student : Uzytkownik
{
    public Student(string imie, string nazwisko)
    {
        faktId = id++;
        this.imie = imie;
        this.nazwisko = nazwisko;
        typ = "student";
    }
}

public class Pracownik : Uzytkownik
{
    public Pracownik(string imie, string nazwisko)
    {
        faktId = id++;
        this.imie = imie;
        this.nazwisko = nazwisko;
        typ = "pracownik";
    }
}