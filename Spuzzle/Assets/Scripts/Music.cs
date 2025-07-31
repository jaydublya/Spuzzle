using UnityEngine;

public class Music : MonoBehaviour
{
    public GameManager gm;
    public GameObject Battery;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Battery"))
        {
            gm.SwitchMusicTrack();
            Destroy(other.gameObject);
        }
    }
}
