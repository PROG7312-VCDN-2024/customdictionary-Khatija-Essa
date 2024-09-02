using System;
using System.Collections.Generic;

public class CustomDictionary<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>> items;

    public CustomDictionary()
    {
        items = new List<KeyValuePair<TKey, TValue>>();
    }

    public void Add(TKey key, TValue value)
    {
        if (ContainsKey(key))
            throw new ArgumentException("An item with the same key has already been added.");
        items.Add(new KeyValuePair<TKey, TValue>(key, value));
    }

    public void Update(TKey key, TValue value)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Key.Equals(key))
            {
                items[i] = new KeyValuePair<TKey, TValue>(key, value);
                return;
            }
        }
        throw new KeyNotFoundException();
    }

    public void Remove(TKey key)
    {
        items.RemoveAll(item => item.Key.Equals(key));
    }

    public TValue Get(TKey key)
    {
        foreach (var item in items)
        {
            if (item.Key.Equals(key))
                return item.Value;
        }
        throw new KeyNotFoundException();
    }

    public bool ContainsKey(TKey key)
    {
        return items.Exists(item => item.Key.Equals(key));
    }

    public IEnumerable<KeyValuePair<TKey, TValue>> GetAllItems()
    {
        return items;
    }
}