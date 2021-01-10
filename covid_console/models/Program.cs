using covid_console.persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace covid_console
{
    class Program
    {
        static Persistence persistence = new Persistence();

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(persistence);
            }
        }

        private static bool MainMenu(Persistence persistence)
        {
            Console.Clear();
            Console.WriteLine("choisir une option:");
            Console.WriteLine("1) Afficher tous les citoyens ");
            Console.WriteLine("2) Rechercher un citoyen");
            Console.WriteLine("3) Ajouter un citoyen");
            Console.WriteLine("4) afficher statistique");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelectionner une option: ");
            Console.BackgroundColor = ConsoleColor.Black;
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    List<Citoyen> citoyens = persistence.getAllCitoyens();
                    Console.WriteLine("######################################################");
                    foreach (Citoyen c in citoyens)
                    {
                        Console.WriteLine("CIN CITOYEN  : " + c.Cin);
                        Console.WriteLine("PRENOM CITOYEN  : " + c.Prenom);
                        Console.WriteLine("NOM CITOYEN  : " + c.Nom);
                        Console.WriteLine("######################################################");
                    }
                    Console.WriteLine("Tapez entrer pour retourner au menu precedant...");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.Enter)
                        keyInfo = Console.ReadKey();
                    return true;
                case "2":   
                    Console.Clear();
                    Console.WriteLine("Entre le cin: ");
                    string cin = Console.ReadLine();
                    Citoyen citoyen = persistence.getCitoyen(cin);
                    if (citoyen!=null)
                    {
                        bool showMenu = true;
                        while (showMenu)
                        {
                            showMenu = CitoyenMenu(persistence, citoyen);
                        }
                    }
                    return true;
                case "3":
                    Citoyen citoyen_ = new Citoyen();
                    Console.WriteLine("Entrer le cin");
                    return true;
                case "4":
                    Console.Clear();
                    double[] stat = persistence.getStat();

                    Console.WriteLine("gueri : " + stat[0]);
                    Console.WriteLine("non confirmee  : " + stat[1]);
                    Console.WriteLine("malade : " + stat[2]);
                    keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.Enter)
                        keyInfo = Console.ReadKey();
                    return true;
                case "5":
                    Console.Clear();
                    return false;
                default:
                    return true;
            }
        }

        private static bool CitoyenMenu(Persistence persistence, Citoyen citoyen)
        {
            Console.Clear();
            Console.WriteLine("choisir une option:");
            Console.WriteLine("1) Afficher dossier medicale ");
            Console.WriteLine("2) Afficher l'historique d'etats");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelectionner une option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    List<AntecedentMedical> ams = persistence.getAllAntecedentMedicalByCitoyen(citoyen.Cin);
                    Console.WriteLine("######################################################");
                    foreach (AntecedentMedical am in ams)
                    {
                        Console.WriteLine("NOM MALADIE  : " + am.Nom_maladie);
                        Console.WriteLine("Medecin traitent  : " + am.Medecin_traitent);
                        Console.WriteLine("Etat de maladie  : " + am.Etat);
                        Console.WriteLine("######################################################");
                    }
                    Console.WriteLine("Tapez entrer pour retourner au menu precedant...");
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.Enter)
                        keyInfo = Console.ReadKey();
                    return true;
                case "2":
                    Console.Clear();
                    List<Consultation> consultations = persistence.getAllConsultationByCitoyen(citoyen.Cin);
                    Console.WriteLine("######################################################");
                    foreach (Consultation c in consultations)
                    {
                        Action action = persistence.getActionByConsultation(c.Id);

                        Console.WriteLine("Date consultation  : " + c.Date_consultation);
                        Console.WriteLine("Synthese  : " + c.Synthese);
                        Console.WriteLine("Decision  : " + action.Decision);
                        Console.WriteLine("Description  : " + action.Description);
                        Console.WriteLine("Prochaine consultation  : " + action.Prochain_cons);
                        Console.WriteLine("######################################################");
                    }
                    Console.WriteLine("Tapez entrer pour retourner au menu precedant...");
                    keyInfo = Console.ReadKey();
                    while (keyInfo.Key != ConsoleKey.Enter)
                        keyInfo = Console.ReadKey();
                    return true;
                case "3":
                    bool showMenu = true;
                    while (showMenu)
                    {
                        showMenu = MainMenu(persistence);
                    }
                    return false;
                default:
                    return true;
            }
        }
    }
}
