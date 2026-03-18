namespace s33323;

public abstract class Sprzet
{
    protected static int id = 0;
    protected string typ = "brak";
}

public class Laptop : Sprzet
{
    private int cale;
    private string rozdzielczosc;

    public Laptop(int cale, string rozdzielczosc)
    {
        id = id++;
        typ = "laptop";
        this.cale =  cale;
        this.rozdzielczosc =  rozdzielczosc;
    }
}

public class Aparat : Sprzet
{
    private string obiektyw;
    private string matryca;

    public Aparat(string obiektyw, string matryca)
    {
        id = id++;
        typ = "aparat";
        this.obiektyw =  obiektyw;
        this.matryca =  matryca;
    }
}

public class Sluchawki : Sprzet
{
    private int opor;
    private bool ANC;

    public Sluchawki(int opor, bool ANC)
    {
        id = id++;
        typ = "sluchawki";
        this.opor = opor;
        this.ANC = ANC;
    }
}