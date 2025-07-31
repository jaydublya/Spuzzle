using UnityEngine;
using static ItemIcons;

public class ItemCollect : MonoBehaviour
{


    private ItemIcons itemIcon;


     void Update()
     {
 
     }
    private void OnTriggerEnter(Collider other)

    {
        if (other.gameObject.CompareTag ("cog"))
        {
            Destroy(other.gameObject);
            itemIcon.cogCollected = true;
            itemIcon.ItemGained(ItemType.Cog);
        }

        else if (other.gameObject.CompareTag ("Battery")) 
        {
            Destroy(other.gameObject);
            itemIcon.batteryCollected = true;
            itemIcon.ItemGained(ItemType.Battery);
        }
         else if (other.gameObject.CompareTag ("duck"))
        {
            Destroy(other.gameObject);
            itemIcon.tapeCollected = true;
            itemIcon.ItemGained(ItemType.Tape);
        }
        else if (other.gameObject.CompareTag("metal"))
        {
            Destroy(other.gameObject);
            itemIcon.metalCollected = true;
            itemIcon.ItemGained(ItemType.Metal);
        }
        else if (other.gameObject.CompareTag("wires"))
        {
            Destroy(other.gameObject);
            itemIcon.wireCollected = true;
            itemIcon.ItemGained(ItemType.Wire);
        }

    }

    private void Start()
    {
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }
}
