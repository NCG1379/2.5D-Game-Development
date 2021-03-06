using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private PlayerController player;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        if(player == null)
        {
            Debug.LogError("player:: is NULL");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.LivesManager();
        }
    }

}
