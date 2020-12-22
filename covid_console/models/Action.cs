using System;

public class Action
{
	private int id;
	private string decision;
	private DateTime prochain_cons;
    private string description;
	private Consultation consultation;

    public Action(){
    }

    public Action(int id, string decision, DateTime prochain_cons, string description, Consultation consultation)
    {
        this.id = id;
        this.decision = decision;
        this.prochain_cons = prochain_cons;
        this.description = description;
        this.consultation = consultation;
    }

    public int Id { get => id; set => id = value; }
    public string Decision { get => decision; set => decision = value; }
    public DateTime Prochain_cons { get => prochain_cons; set => prochain_cons = value; }
    public string Description { get => description; set => description = value; }
    public Consultation Consultation { get => consultation; set => consultation = value; }
}
