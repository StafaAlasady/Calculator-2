// Välkomnande meddelande
// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat
//Fråga användaren om den vill avsluta eller fortsätta
List<double> miniräknarlist = new List<double>();

do
{
    // här skapas en lista där man kan skriva in ett värde inuti parentes för att visa hur många objekt man vill ha
    
    //double ger ord, nummer värde
    double num1 = 0;
    double num2 = 0;
    double resultat = 0;

    //Console writeline skriver ut texten på programmet
    Console.WriteLine("---------");
    Console.WriteLine("Välkommen");
    Console.WriteLine("---------");
    Console.Write("Skriv in nummer 1: ");
    //num1 blir konverterat till siffror i programmet

    num1 = Convert.ToDouble(Console.ReadLine());

    Console.Write("Skriv in nummer 2: ");
    num2 = Convert.ToDouble(Console.ReadLine());

    // console writeline skriver ut en text och med switch casen så converterar den text till siffror med hjälp av double
    Console.WriteLine("Skriv in val: ");
    Console.WriteLine("+ :addera");
    Console.WriteLine("- :subtrahera");
    Console.WriteLine("* :multiplicera");
    Console.WriteLine("/ :dividera");
    Console.Write("Skriv in ett val");



    //i switch satsen defineras en eller flera case satser som sedan avslutas med "break", varje case följer ett värde
    //som direkt kan jämföras med utryck som switch satsen hanterar

    switch (Console.ReadLine())
    {    // varje case är ett alternativ för coden.
        case "+":
            resultat = num1 + num2;
            Console.WriteLine($"Ditt svar: {num1} + {num2} = " + resultat);
            break;
        case "-":
            resultat = num1 - num2;
            Console.WriteLine($"Ditt svar: {num1} - {num2} = " + resultat);
            break;
        case "*":
            resultat = num1 * num2;
            Console.WriteLine($"Ditt svar: {num1} * {num2} = " + resultat);
            break;
        // skapade ett till case för ogiltig inmatchning med ett if statement.
        // ifall man försöker dela med noll så kommer svaret som en nolla och då ska denna texten dyka upp istället.
        case "/":
            if (num2 == 0)
            {
                Console.WriteLine("Ogiltig inmatchning, det går ej att dela med noll");
                continue;
            }
            resultat = num1 / num2;
            Console.WriteLine($"Ditt svar: {num1} / {num2} = " + resultat);
            break;
        case "":
            resultat = num1 * num2;
            Console.WriteLine($"Ditt svar: {num1} * {num2} = " + resultat);
            break;

    }

    //lägger till ett "objekt" i listan
    miniräknarlist.Add(resultat);
    // steam writer skapar ett text dokument i specifierad path eller skriver den in i calculator save path som finns i bin. 
    string readText = File.ReadAllText("CalcResult.txt");
    StreamWriter writer = new StreamWriter("CalcResult.txt", true);
    writer.Write(readText);
    writer.WriteLine($"Ditt svar :" + resultat);
    writer.Close();
    // Filen där dokumentet skapas och dokumentets namn
    readText = File.ReadAllText("CalcResult.txt");


    string[] miniresultat = { $"ditt svar:" + resultat };

    File.WriteAllLines("CalcResult.txt", miniresultat);



    Console.WriteLine("skulle du vilja se dina tidigare resultat? (J = ja, N = nej): ");
    //här använde jag av bokstaven j för att indikera denna "if statementet"
    string IsKeyDown = Console.ReadLine();
    if (IsKeyDown == "J")
    {
        //for each loop är använd här för att loopa miniräknarens logg i coden
        foreach (double a in miniräknarlist)
        { // writeline skriver ut double som blev konverterad till bokstav a
            Console.WriteLine(a);
        }
    }
    else
    {
        //writeline skriver ut på consolen, men write skriver i rad, text bredvid text
        Console.WriteLine("skulle du vilja fortsätta ? (J = ja, N = nej): ");
    }
    //valde en "do while loop" för att loopa hela coden.
    //använde string metoden "to upper" för att man ska kunna klicka in en liten bokstav och ändå funkar koden flr den läser bokstaven som stor.
} while (Console.ReadLine().ToUpper() == "J");

Console.WriteLine("Hej då !");