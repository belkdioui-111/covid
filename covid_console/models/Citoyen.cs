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
    private DateTime date_naissance;
    private DateTime? date_deces;
    private List<AntecedentMedical> dossier_medicale;
    private List<Citoyen> entourage;
    private List<Consultation> consultation;

    public Citoyen(){
    }

    public Citoyen(string cin, string nom, string prenom, int age, string address, int n_tele, DateTime date_naissance)
    {
        this.cin = cin;
        this.nom = nom;
        this.prenom = prenom;
        this.age = age;
        this.address = address;
        this.n_tele = n_tele;
        this.date_naissance = date_naissance;
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

    public Citoyen(string cin, string nom, string prenom, int age, string address, int n_tele, DateTime date_naissance, DateTime date_deces, List<AntecedentMedical> dossier_medicale, List<Consultation> consultation, List<Citoyen> entourage = null)
    {
        this.cin = cin;
        this.nom = nom;
        this.prenom = prenom;
        this.age = age;
        this.address = address;
        this.n_tele = n_tele;
        this.date_naissance = date_naissance;
        this.date_deces = date_deces;
        this.dossier_medicale = dossier_medicale;
        this.entourage = entourage;
        this.consultation = consultation;
    }

    public string Cin { get => cin; set => cin = value; }
    public string Nom { get => nom; set => nom = value; }
    public string Prenom { get => prenom; set => prenom = value; }
    public int Age { get => age; set => age = value; }
    public string Address { get => address; set => address = value; }
    public int N_tele { get => n_tele; set => n_tele = value; }
    public List<AntecedentMedical> Dossier_medicale { get => dossier_medicale; set => dossier_medicale = value; }
    public List<Citoyen> Entourage { get => entourage; set => entourage = value; }
    public List<Consultation> Consultation { get => consultation; set => consultation = value; }
    public DateTime Date_naissance { get => date_naissance; set => date_naissance = value; }
    public DateTime? Date_deces { get => date_deces; set => date_deces = value; }

}
