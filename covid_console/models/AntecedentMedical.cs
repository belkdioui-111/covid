using System;

public class AntecedentMedical
{
    private int id;
    private string nom_maladie;
    private string medecin_traitant;
    private string lieu;
    private DateTime date;
    private string etat;
    private Citoyen citoyen;

    public AntecedentMedical(){

    }

    public AntecedentMedical(int id, string nom_maladie, string medecin_traitant, string lieu, DateTime date, string etat, Citoyen citoyen)
    {
        this.id = id;
        this.nom_maladie = nom_maladie;
        this.medecin_traitant = medecin_traitant;
        this.lieu = lieu;
        this.date = date;
        this.etat = etat;
        this.citoyen = citoyen;
    }

    public int Id { get => id; set => id = value; }
    public string Nom_maladie { get => nom_maladie; set => nom_maladie = value; }
    public string Medecin_traitent { get => medecin_traitant; set => medecin_traitant = value; }
    public string Lieu { get => lieu; set => lieu = value; }
    public DateTime Date { get => date; set => date = value; }
    public string Etat { get => etat; set => etat = value; }
    public Citoyen Citoyen { get => citoyen; set => citoyen = value; }
}