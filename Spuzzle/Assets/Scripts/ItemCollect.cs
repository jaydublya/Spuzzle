using UnityEngine;

public class ItemCollect : MonoBehaviour
{


    private int Item = 0;




    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "Item")
        {
            Item++;
            Debug.Log(Item);
            Destroy(other.gameObject);
        }

    }









}
