// See https://aka.ms/new-console-template for more information


Console.Write("Geef je naam op: ");
string naam = Console.ReadLine();

Console.Write("Geef telefoonnummer op (GSM) : ");
string telNummer = Console.ReadLine(); 

Console.Write("Geef je postcode op: ");
string postcode = Console.ReadLine();

// EERSTE TEKEN
string eersteTekenVanNaam = naam.Substring(0, 1);
string eersteLetterPaswoord = eersteTekenVanNaam.ToUpper();

// TWEEDE TEKEN
string tweedeTekenVanNaam = naam.Substring(1, 1);
string tweedeLetterPaswoord = tweedeTekenVanNaam.ToLower();

//ZONENUMMER
string deelVanTelnummer = telNummer.Substring(1, 3);

//POSTCODE
string eersteCijferVanPostcode = postcode.Substring(0, 1);
double machtverheffingPC = Math.Pow(Convert.ToInt32(eersteCijferVanPostcode), 2);

//GEGENEREERD PASWOORD
Console.WriteLine(tweedeLetterPaswoord + eersteLetterPaswoord + deelVanTelnummer + machtverheffingPC);

