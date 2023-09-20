using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField] private ItemSpawner _itemSpawner;
    public void Spawn()
    {
        Item item = _itemSpawner.TryGetItem();

        if (item != null)
        {
            item = Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
