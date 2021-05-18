  class Program
  {
    private static void Main
    {
      int id = 1;

      HealthStorage healthStorage = new HealthStorage();
      PlayerConfig playerConfig = new PlayerConfig(id, healthStorage);
      Player player = new Player(playerConfig.Health, playerConfig.Armor, id);
      player.HealthChanged += healthStorage.OnHealthChanged;
    }
  }
  
  class Player
  {
    private float _health;
    private float _armor;
    private int _id;

    public float Health => _health;

    public event Action<int, float> HealthChanged;

    public Player(float health, float armor, int id)
    {
      _health = health;
      _armor = armor;
      _id = id;
    }

    public void ApplyDamage(float damage)
    {
      float healthDelta = damage - _armor;
      _health -= healthDelta;
      _armor /= 2;
      
      Console.WriteLine($"Вы получили урона - {healthDelta}");

      HealthChanged?.Invoke(_id, _health);
    }
  }

  class PlayerConfig
  {
    private const float HealthByDefault = 10;

    public float Health { get; }
    public float Armor { get; }

    public PlayerConfig(int id, HealthStorage healthStorage)
    {
      Health = healthStorage.TryGet(id, out var health) ? health : HealthByDefault;
      Armor = 4;
    }
  }

  class HealthStorage
  {
    public void OnHealthChanged(int id, float value) =>
      Set(id, value);

    public bool TryGet(int id, out float value)
    {
      value = 0;
      var filename = Filename(id);

      if (!File.Exists(filename))
        return false;

      var data = File.ReadAllText(filename);
      value = float.Parse(data);
      return true;
    }

    private void Set(int id, float health) =>
      File.WriteAllText(Filename(id), health.ToString());

    private string Filename(int id) =>
      $"user_{id}.data";
  }
