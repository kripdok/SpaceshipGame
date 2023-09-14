using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ItemSpawner/New ItemSpawner")]
public class ItemSpawner : ScriptableObject
{
    private const float MaxPrecent = 100;

    [SerializeField] private List<Item> _items;

    public Item GetItem()
    {
        int index = Random.Range(0, _items.Count);
        Item item = _items[index];
        
        float precent = Random.Range(0, MaxPrecent);

        if(precent <= item.PercentSpawn)
        {
            return item;
        }

        return null;
    }
}