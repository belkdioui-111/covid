using System;

public class Consultation
{
    private int id;
	private string synthese;
	private DateTime date_consultation;
	private string etat_couleur;
    private string cin_citoyen;

    public Consultation()
    {
    }

    public Consultation(string synthese, DateTime date_consultation, string etat_couleur, string cin_citoyen)
    {
        this.synthese = synthese;
        this.date_consultation = date_consultation;
        this.etat_couleur = etat_couleur;
        this.cin_citoyen = cin_citoyen;
    }

    public Consultation(int id, string synthese, DateTime date_consultation, string etat_couleur, string cin_citoyen)
    {
        this.id = id;
        this.synthese = synthese;
        this.date_consultation = date_consultation;
        this.etat_couleur = etat_couleur;
        this.cin_citoyen = cin_citoyen;
    }

    public string Synthese { get => synthese; set => synthese = value; }
    public DateTime Date_consultation { get => date_consultation; set => date_consultation = value; }
    public string Etat_couleur { get => etat_couleur; set => etat_couleur = value; }
    public string Cin_citoyen { get => cin_citoyen; set => cin_citoyen = value; }
    public int Id { get => id; set => id = value; }
}
