using System;

public class Action
{

	private string decision;
	private DateTime prochain_cons;
    private string description;
	private int id_consultation;

    public Action(){
    }

    public Action( string decision, DateTime prochain_cons, string description, int id_consultation)
    {
       
        this.decision = decision;
        this.prochain_cons = prochain_cons;
        this.description = description;
        this.id_consultation = id_consultation;
    }

  
    public string Decision { get => decision; set => decision = value; }
    public DateTime Prochain_cons { get => prochain_cons; set => prochain_cons = value; }
    public string Description { get => description; set => description = value; }
    public int Consultation { get => id_consultation; set => id_consultation = value; }
}
