namespace s33323;

public abstract class Sprzet
{
    protected static int id;
    protected int faktId;
    protected string typ = "brak";
    protected string nazwa = "";
    protected bool dostepny = true;
    
    public int getId() => this.faktId;
    public string getTyp() => this.typ;
    public string getNazwa() => this.nazwa;
    public bool getDostepny() => this.dostepny;
    public void setDostepny(bool dostepny) => this.dostepny = dostepny;
}

public class Laptop : Sprzet
{
    private int cale;
    private string rozdzielczosc;

    public Laptop(string nazwa, int cale, string rozdzielczosc)
    {
        faktId = id++;
        typ = "laptop";
        this.nazwa = nazwa;
        this.cale =  cale;
        this.rozdzielczosc =  rozdzielczosc;
    }
    
    public int getCale()  => this.cale;
    public string getRozdzielczosc() => this.rozdzielczosc;
}

public class Aparat : Sprzet
{
    private string obiektyw;
    private string matryca;

    public Aparat(string nazwa, string obiektyw, string matryca)
    {
        faktId = id++;
        typ = "aparat";
        this.nazwa = nazwa;
        this.obiektyw =  obiektyw;
        this.matryca =  matryca;
    }
    
    public string getObiektyw() => this.obiektyw;
    public string getMatryca() => this.matryca;
}

public class Sluchawki : Sprzet
{
    private int opor;
    private bool ANC;

    public Sluchawki(string nazwa, int opor, bool ANC)
    {
        faktId = id++;
        typ = "sluchawki";
        this.nazwa = nazwa;
        this.opor = opor;
        this.ANC = ANC;
    }
    
    public int getOpor() => this.opor;
    public bool getANC() => this.ANC;
}