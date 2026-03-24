using s33323;

Wypozyczalnia system = new Wypozyczalnia();
bool dziala = true;

// system.DodajUzytkownika(new Student("Bartosz", "Wróbel"));
// system.DodajUzytkownika(new Student("Jan", "Kowalski"));
// system.DodajUzytkownika(new Pracownik("Myślibrak", "Testowy"));
// system.DodajSprzet(new Laptop("Lenovo", 14, "FullHD"));
// system.DodajSprzet(new Laptop("ThinkPad", 13, "HD"));
// system.DodajSprzet(new Aparat("Nicon", "Szerokokątny",  "FullFrame"));
// system.DodajSprzet(new Sluchawki("HyperX", 38, true));
// system.Wypozycz(0, 2);
// system.Wypozycz(0, 0);
// system.Wypozycz(0, 1);
// system.Wypozycz(2, 1);
// system.Zwroc(2, new DateOnly(2026, 3, 30));
// system.Zwroc(0, new DateOnly(2026, 4, 20));
// system.GenerujRaport();

while (dziala)
{
    Console.WriteLine("\n--- SYSTEM WYPOŻYCZALNI ---");
    Console.WriteLine("1. Dodaj użytkownika | 2. Dodaj sprzęt | 3. Lista sprzętu | 4. Dostępne");
    Console.WriteLine("5. Wypożycz | 6. Zwrot | 7. Wyłącz sprzęt | 8. Wypożyczenia usera");
    Console.WriteLine("9. Przeterminowane | 10. Raport | 11. Wyjdź");
    
    if (!int.TryParse(Console.ReadLine(), out int wybor)) continue;

    switch (wybor)
    {
        case 1:
            Console.Write("Typ (Student/Pracownik): ");
            string t = Console.ReadLine();
            Console.Write("Imię: "); string im = Console.ReadLine();
            Console.Write("Nazwisko: "); string na = Console.ReadLine();
            if (t.ToLower() == "student") system.DodajUzytkownika(new Student(im, na));
            else system.DodajUzytkownika(new Pracownik(im, na));
            break;

        case 2:
            Console.WriteLine("1. Laptop | 2. Aparat | 3. Słuchawki");
            int typS = int.Parse(Console.ReadLine());
            Console.Write("Nazwa: "); string nazwa = Console.ReadLine();
            if (typS == 1) system.DodajSprzet(new Laptop(nazwa, 15, "FullHD"));
            else if (typS == 2) system.DodajSprzet(new Aparat(nazwa, "50mm", "FullFrame"));
            else system.DodajSprzet(new Sluchawki(nazwa, 32, true));
            break;

        case 3: system.WyswietlSprzet(false); break;
        case 4: system.WyswietlSprzet(true); break;

        case 5:
            Console.Write("ID Użytkownika: "); int uId = int.Parse(Console.ReadLine());
            Console.Write("ID Sprzętu: "); int sId = int.Parse(Console.ReadLine());
            system.Wypozycz(uId, sId);
            break;

        case 6:
            Console.Write("ID Sprzętu do zwrotu: "); int zsId = int.Parse(Console.ReadLine());
            system.Zwroc(zsId);
            break;

        case 7:
            Console.Write("ID Sprzętu: "); int nId = int.Parse(Console.ReadLine());
            system.ZmienDostepnosc(nId, false);
            Console.WriteLine("Sprzęt oznaczony jako niedostępny (serwis).");
            break;

        case 8:
            Console.Write("ID Użytkownika: "); int listUId = int.Parse(Console.ReadLine());
            system.WyswietlWypozyczeniaUzytkownika(listUId);
            break;

        case 9: system.WyswietlPrzeterminowane(); break;
        case 10: system.GenerujRaport(); break;
        case 11: dziala = false; break;
    }
}