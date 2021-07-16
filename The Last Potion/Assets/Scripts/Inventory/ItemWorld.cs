using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;
    [SerializeField] new private Light2D light;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
        light.color = item.GetColor();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }
}
