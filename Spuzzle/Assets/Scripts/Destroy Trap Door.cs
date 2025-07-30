using UnityEngine;

public class DestroyTrapDoor : MonoBehaviour
{
    private ItemCollect ItemCollectScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ItemCollectScript = GameObject.Find("Collectible").GetComponent<ItemCollect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemCollectScript.Item == 4 == true)
        {
            
        }
    }
}
