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
        }
        if (other.gameObject.CompareTag ("Wire"))
        {
            Destroy(other.gameObject);
            itemIcon.wireCollected= true;
        }
        if (other.gameObject.CompareTag ("metal"))
        {
            Destroy(other.gameObject);
            itemIcon.metalCollected = true;
        }
        if (other.gameObject.CompareTag ("battery")) 
        {
            Destroy(other.gameObject);
            itemIcon.batteryCollected = true;
        }
        if (other.gameObject.CompareTag ("duck"))
        {
            Destroy(other.gameObject);
            itemIcon.tapeCollected = true;
        }
       
    }

    private void Start()
    {
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }
}
