using UnityEngine;

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
            itemIcon.cogCollected= true;
            itemIcon.ItemGained();
        }
        if (other.gameObject.CompareTag ("wires"))
        {
            Destroy(other.gameObject);
            itemIcon.wireCollected= true;
            itemIcon.ItemGained();
        }
        if (other.gameObject.CompareTag ("metal"))
        {
            Destroy(other.gameObject);
            itemIcon.metalCollected = true;
            itemIcon.ItemGained();
        }
        if (other.gameObject.CompareTag ("Battery")) 
        {
            Destroy(other.gameObject);
            itemIcon.batteryCollected = true;
            itemIcon.ItemGained();
        }
        if (other.gameObject.CompareTag ("duck"))
        {
            Destroy(other.gameObject);
            itemIcon.tapeCollected = true;
            itemIcon.ItemGained();
        }
    }

    private void Start()
    {
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }
}
