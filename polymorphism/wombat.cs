public abstract class Creature
{
  private int _health;
  protected abstract int DamageAmount(int value);

  public void TakeDamage(int value)
  {
    _health -= DamageAmount(value);

    if (_health <= 0)
      Console.WriteLine("Я умер");
  }
}

public class Wombat : Creature
{
  private readonly int _armor;

  public Wombat(int armor) =>
    _armor = armor;

  protected override int DamageAmount(int value) =>
    value - _armor;
}

public class Human : Creature
{
  private readonly int _agility;

  public Human(int agility) =>
    _agility = agility;

  protected override int DamageAmount(int value) => 
    value / _agility;
}