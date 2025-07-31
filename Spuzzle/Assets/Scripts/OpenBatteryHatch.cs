using UnityEngine;

public class OpenBatteryHatch : MonoBehaviour
{
    private ItemIcons itemIcons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemIcons = GameObject.Find("Collectables").GetComponent<ItemIcons>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((itemIcons.metalVariable == 3) && (itemIcons.wireVariable == 5) && (itemIcons.tapeVariable == 1) && (itemIcons.cogVariable == 1))
        {
            Destroy(gameObject);
        }
    }
}
