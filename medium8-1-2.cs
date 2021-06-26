using System;

namespace Task
{
  class Program
  {
    public static void Main(string[] args)
    {
      Object[] objects =
      {
        new Object(new Position(5, 5)),
        new Object(new Position(10, 10)),
        new Object(new Position(15, 15))
      };

      bool[] isObjectAlive = new bool[objects.Length];

      while (true)
      {
        Update(objects, isObjectAlive);
      }
    }

    private static void Update(Object[] objects, bool[] isObjectAlive)
    {
      for (int i = 0; i < objects.Length; i++)
      {
        if (i < objects.Length - 1)
        {
            Object[] objects = 
            { 
                new Object(new Position(5, 5)), 
                new Object(new Position(10, 10)), 
                new Object(new Position(15, 15)) 
            };
            
            Renderer renderer = new Renderer(objects);

            while (true)
            {
                renderer.Update();
            }
        }
    }

  public class Position
  {
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public static bool operator ==(Position position1, Position position2)
      => position1.X == position2.X && position1.Y == position2.Y;

    public static bool operator !=(Position position1, Position position2)
      => !(position1 == position2);

    public static Position operator +(Position position1, Position position2)
    {
      int x = position1.X + position2.X;
      int y = position1.Y + position2.Y;
      
      if (x < 0) x = 0;
      if (y < 0) y = 0;
      
      return new Position(x, y);
    }
  }

  public class Object
  {
    public Object(Position position)
    {
      Position = position;
    }

    public Position Position { get; private set; }

    public void Move() => 
      Position += RandomPosition();

    private static Position RandomPosition()
    {
      Random random = new Random();
      return new Position(random.Next(-1, 1), random.Next(-1, 1));
    }
  }

  public class Renderer
  {
    public static void DrawAt(Position position, int i)
    {
      Console.SetCursorPosition(position.X, position.Y);
      Console.Write(i);
    }
  }
}