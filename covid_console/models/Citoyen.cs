using System;
using System.Collections.Generic;

public class Citoyen
{
    private string cin;
    private string nom;
    private string prenom;
    private int age;
    private string address;
    private int n_tele;
    private string etat_couleur;
    private DateTime date_naissance;
    private DateTime? date_deces;

    public Citoyen(){
    }

    public Citoyen(string cin, string nom, string prenom, int age, string address, int n_tele, DateTime date_naissance,string etat_couleur)
    {
        this.cin = cin;
        this.nom = nom;
        this.prenom = prenom;
        this.age = age;
        this.address = address;
        this.n_tele = n_tele;
        this.date_naissance = date_naissance;
        this.etat_couleur = etat_couleur;
    }
    public Citoyen(string cin, string nom, string prenom, int age, string address, int n_tele, DateTime date_naissance,DateTime date_deces)
    {
        this.cin = cin;
        this.nom = nom;
        this.prenom = prenom;
        this.age = age;
        this.address = address;
        this.n_tele = n_tele;
        this.date_naissance = date_naissance;
        this.date_deces = date_deces;
    }

    public string Cin { get => cin; set => cin = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prenom { get => prenom; set => prenom = value; }
    public int Age { get => age; set => age = value; }
    public string Address { get => address; set => address = value; }
    public int N_tele { get => n_tele; set => n_tele = value; }
    public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
    public DateTime? Date_deces { get => date_deces; set => date_deces = value; }
    public string Etat_couleur { get => etat_couleur; set => etat_couleur = value; }
}
