using System;

public class Consultation
{
	private string synthese;
	private DateTime date_consultation;
	private string etat_couleur;
    private Action action;
    private Citoyen citoyen;


  

    public Consultation(string synthese, DateTime date_consultation, string etat_couleur, Action action, Citoyen citoyen)
    {
        this.synthese = synthese;
        this.date_consultation = date_consultation;
        this.etat_couleur = etat_couleur;
        this.action = action;
        this.citoyen = citoyen;

    }

    public string Synthese { get => synthese; set => synthese = value; }
    public DateTime Date_consultation { get => date_consultation; set => date_consultation = value; }
    public string Etat_couleur { get => etat_couleur; set => etat_couleur = value; }
    public Action Action { get => action; set => action = value; }
    public Citoyen Citoyen { get => citoyen; set => citoyen = value; }
  
}
