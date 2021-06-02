public class Player
{
    public string Name { get; private set; }
    public int Age { get; private set; }
}

public class Mover
{
    private Direction _direction;
    
    public float Speed { get; private set; }
    
    public void Move()
    {
        //Do move
    }
}

public class Direction
{
    public float X { get; private set; }
    public float Y { get; private set; }
}

public class Attacker
{
    private Weapon _weapon; 
    
    public void Attack()
    {
        //attack
    }
}

public class Weapon
{
    public int Damage { get; private set; }
    public float Cooldown { get; private set; }

    public bool IsReloading()
    {
        throw new NotImplementedException();
    }
}
