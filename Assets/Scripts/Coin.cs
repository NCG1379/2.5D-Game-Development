using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerController playerController;

    int _valueCoin = 2;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("playerController:: is NULL");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerController.CoinCollected(_valueCoin);
            Destroy(this.gameObject);
        }
    }
}
