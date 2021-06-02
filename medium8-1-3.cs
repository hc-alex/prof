public class Bag
{
  public List<IItem> Items { get; }
  private readonly int _maxWidth;
    
  public Bag(List<IItem> items, int maxWidth)
  {
    Items = items;
    _maxWidth = maxWidth;
  }

  public void AddItem(string name, int count)
  {
    int currentWidth = Items.Sum(item => item.Count);
    var targetItem = (IIncreasableItem) Items.FirstOrDefault(item => item.Name == name);

    if (targetItem == null)
      throw new InvalidOperationException();

    if (currentWidth + count > _maxWidth)
      throw new InvalidOperationException();

    targetItem.IncreaseCount(count);
  }
}

public interface IItem
{
  string Name { get; }
  int Count { get; }
}

public interface IIncreasableItem : IItem
{
  void IncreaseCount(int value);
}


public class Item: IIncreasableItem
{
  public string Name { get; }

  public Item(string name) => 
    Name = name;

  public int Count { get; private set; }

  public void IncreaseCount(int value) => 
    Count += value;
}