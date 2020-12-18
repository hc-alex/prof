public abstract class Creature
{
  protected int Health { get; set; }
  protected abstract void ReduceHealth(int value);

  public void TakeDamage(int damage)
  {
    ReduceHealth(damage);
      
    if(Health <= 0) 
      Console.WriteLine("Я умер");
  }
}

public class Wombat : Creature
{
  private readonly int _armor;

  public Wombat(int armor) => 
    _armor = armor;

  protected override void ReduceHealth(int value) => 
    Health -= value - _armor;
}

public class Human : Creature
{
  private readonly int _agility;

  public Human(int agility) => 
    _agility = agility;

  protected override void ReduceHealth(int value) => 
    Health -= value / _agility;
}