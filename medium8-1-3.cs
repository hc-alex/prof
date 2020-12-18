public class Bag
{
  public readonly List<Item> Items;
  private readonly int _maxWidth;

  public Bag(List<Item> items, int maxWidth)
  {
    Items = items;
    _maxWidth = maxWidth;
  }

  public void AddItem(string name, int count)
  {
    int currentWidth = Items.Sum(item => item.Count);
    Item targetItem = Items.FirstOrDefault(item => item.Name == name);

    if (targetItem == null)
      throw new InvalidOperationException();

    if (currentWidth + count > _maxWidth)
      throw new InvalidOperationException();

    targetItem.IncreaseCount(count);
  }
}

public class Item
{
  public readonly string Name;

  public Item(string name) => 
    Name = name;

  public int Count { get; private set; }

  public void IncreaseCount(int value) => 
    Count += value;
}