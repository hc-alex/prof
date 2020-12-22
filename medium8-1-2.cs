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
        
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Randomise()
        {
            Random random = new Random();
            
            X += random.Next(-1, 1);
            Y += random.Next(-1, 1);

            if (X < 0) X = 0;
            if (Y < 0) Y = 0;
        }
    }

    public class Object
    {
        public Object(Position position)
        {
            Position = position;
        }
        
        public Position Position { get; }

        public void RandomisePosition() => 
            Position.Randomise();
    }

    public class Renderer
    {
        private readonly Object[] _objects;
        private readonly bool[] _isObjectAlive;
        
        public Renderer(Object[] objects)
        {
            _objects = objects;
            _isObjectAlive = new bool[objects.Length];
        }

        public void Update()
        {
            for (int i = 0; i < _objects.Length; i++)
            {
                if (i < _objects.Length - 1)
                {
                    for (int j = i; j < _objects.Length - 1; j++)
                    {
                        bool isAlive = AreObjectsPositionsEqual(_objects[j], _objects[j + 1]);
                        _isObjectAlive[j] = isAlive;
                        _isObjectAlive[j + 1] = isAlive;
                    }
                }

                _objects[i].RandomisePosition();
                
                if (_isObjectAlive[i]) 
                    DrawObject(_objects[i], i);
            }
        }

        private bool AreObjectsPositionsEqual(Object obj1, Object obj2) => 
            obj1.Position.X == obj2.Position.X && obj1.Position.Y == obj2.Position.Y;

        private void DrawObject(Object obj, int i)
        {
            Console.SetCursorPosition(obj.Position.X, obj.Position.Y);
            Console.Write(i);
        }
    }
}