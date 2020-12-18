using System;

namespace Task
{
    class Program
    {
        public static void Main(string[] args)
        {
            Object[] objects = { new Object(5, 5), new Object(10, 10), new Object(15, 15) };

            while (true)
            {
                for (int i = 0; i < objects.Length; i++)
                {
                    if (i < objects.Length - 1)
                    {
                        for (int j = i; j < objects.Length - 1; j++) 
                            ObjectKiller.TryKillObjectsWithEqualXY(objects[j], objects[j + 1]);
                    }

                    objects[i].RandomiseXY();
                    Writer.TryWriteAliveObjectPosition(objects[i], i);
                }
            }
        }
    }

    public class Object
    {
        public Object(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public bool IsAlive { get; private set; } = true; 

        public void RandomiseXY()
        {
            Random random = new Random();
            
            X += random.Next(-1, 1);
            Y += random.Next(-1, 1);

            if (X < 0) X = 0;
            if (Y < 0) Y = 0;
        }

        public void Die() => 
            IsAlive = false;
    }

    public static class ObjectKiller
    {
        public static void TryKillObjectsWithEqualXY(Object obj1, Object obj2)
        {
            if (!AreObjectsXYEqual(obj1, obj2)) 
                return;

            obj1.Die();
            obj2.Die();
        }

        private static bool AreObjectsXYEqual(Object obj1, Object obj2) => 
            obj1.X == obj2.X && obj1.Y == obj2.Y;
    }

    public static class Writer
    {
        public static void TryWriteAliveObjectPosition(Object obj, int position)
        {
            if(!obj.IsAlive)
                return;
            
            Console.SetCursorPosition(obj.X, obj.Y);
            Console.Write(position);
        }
    }
}