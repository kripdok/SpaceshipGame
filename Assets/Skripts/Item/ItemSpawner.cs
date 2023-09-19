using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemSpawner/New ItemSpawner")]
public class ItemSpawner : ScriptableObject
{
    private const float MaxPrecent = 100;

    [SerializeField] private List<Item> _items;

    public Item TryGetItem()
    {
        Item item = GetItem();
        float precentToSpawn = Random.Range(0, MaxPrecent);
        return item.PercentSpawn >= precentToSpawn? item : null;
    }

    private Item GetItem()
    {
        int index = Random.Range(0, _items.Count);
        return _items[index];
    }
}