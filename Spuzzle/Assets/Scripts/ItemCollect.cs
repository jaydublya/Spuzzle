using UnityEngine;

public class ItemCollect : MonoBehaviour
{


    public int Item = 0;
    private ItemIcons itemIcon;


     void Update()
     {
        if(Item == 4)
        {
            
        }
     }
    private void OnTriggerEnter(Collider other)

    {
       if (other.gameObject.CompareTag ("duck"))
        {
            Destroy(other.gameObject);
           
        }
        if(other.CompareTag("Collectible"))
        {
            Debug.Log(Item);
            Destroy(other.gameObject);
            AddItem();
        }
        void AddItem()
        {
            Item++;
        }
    }

    private void Start()
    {
        itemIcon = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }
}
