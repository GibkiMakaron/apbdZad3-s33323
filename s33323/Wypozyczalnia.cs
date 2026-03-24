using System.Text;

namespace s33323;

public class Wypozyczalnia
{
    private List<Uzytkownik> uzytkownicy = new();
    private List<Sprzet> sprzety = new();
    private List<Wypozyczenie> wypozyczenia = new();
    
    public void DodajUzytkownika(Uzytkownik u) => uzytkownicy.Add(u);
    
    public void DodajSprzet(Sprzet s) => sprzety.Add(s);
    
    public void WyswietlSprzet(bool tylkoDostepne = false)
    {
        var lista = tylkoDostepne ? sprzety.Where(s => s.getDostepny()) : sprzety;
        Console.WriteLine("\n--- Lista Sprzętu ---");
        foreach (var s in lista)
        {
            Console.WriteLine($"ID: {s.getId()} | {s.getTyp()} - {s.getNazwa()} | Dostępny: {(s.getDostepny() ? "Tak" : "Nie")}");
        }
    }
    
    public void Wypozycz(int uzytkownikId, int sprzetId)
    {
        var uzytkownik = uzytkownicy.FirstOrDefault(u => u.getId() == uzytkownikId);
        var sprzet = sprzety.FirstOrDefault(s => s.getId() == sprzetId);

        if (uzytkownik != null && sprzet != null && sprzet.getDostepny())
        {
            wypozyczenia.Add(new Wypozyczenie(uzytkownik, sprzet));
            sprzet.setDostepny(false);
            Console.WriteLine("Wypożyczono pomyślnie!");
        }
        else Console.WriteLine("Błąd: Nie znaleziono osoby/sprzętu lub sprzęt jest zajęty.");
    }
    
    public void Zwroc(int sprzetId)
    {
        var w = wypozyczenia.FirstOrDefault(x => x.getSprzet().getId() == sprzetId && x.getDataZwrotu() == null);
        if (w != null)
        {
            w.ZakonczWypozyczenie();
            w.getSprzet().setDostepny(true);
            
            double kara = w.ObliczKare();
            if (kara > 0) Console.WriteLine($"Sprzęt zwrócony. Naliczono karę: {kara} PLN.");
            else Console.WriteLine("Sprzęt zwrócony w terminie.");
        }
        else Console.WriteLine("Nie znaleziono aktywnego wypożyczenia dla tego sprzętu.");
    }

    public void ZmienDostepnosc(int sprzetId, bool status)
    {
        var s = sprzety.FirstOrDefault(x => x.getId() == sprzetId);
        if (s != null) s.setDostepny(status);
    }
    
    public void WyswietlWypozyczeniaUzytkownika(int uId)
    {
        var aktywne = wypozyczenia.Where(w => w.getOsoba().getId() == uId && w.getDataZwrotu() == null);
        foreach (var w in aktywne) Console.WriteLine($"- {w.getSprzet().getNazwa()} (Termin: {w.getTerminZwrotu()})");
    }
    
    public void WyswietlPrzeterminowane()
    {
        var dzis = DateOnly.FromDateTime(DateTime.Now);
        var poTerminie = wypozyczenia.Where(w => w.getDataZwrotu() == null && w.getTerminZwrotu() < dzis);
        foreach (var w in poTerminie) 
            Console.WriteLine($"Użytkownik: {w.getOsoba().getNazwisko()}, Sprzęt: {w.getSprzet().getNazwa()}, Termin minął: {w.getTerminZwrotu()}");
    }
    
    public void GenerujRaport()
    {
        Console.WriteLine("\n=== RAPORT STANU WYPOŻYCZALNI ===");
        Console.WriteLine($"Liczba sprzętu: {sprzety.Count}");
        Console.WriteLine($"Sprzęt wypożyczony: {sprzety.Count(s => !s.getDostepny())}");
        Console.WriteLine($"Liczba użytkowników: {uzytkownicy.Count}");
        Console.WriteLine($"Aktywne wypożyczenia: {wypozyczenia.Count(w => w.getDataZwrotu() == null)}");
    }
    
    public List<Uzytkownik> GetUzytkownicy() => uzytkownicy;
}