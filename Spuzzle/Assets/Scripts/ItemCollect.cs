using UnityEngine;

public class ItemCollect : MonoBehaviour
{


    public int Item = 0;



     void Update()
     {
        if(Item == 4)
        {
            
        }
     }
    private void OnTriggerEnter(Collider other)
    {
        
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
}
