using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text coins;
    [SerializeField]
    private Text lives;

    public void UpdateCoinsText(int coin)
    {
        coins.text = "Coins: " + coin;
    }

    public void UpdateLivesText(int live)
    {
        lives.text = "Lives: " + live;
    }

}
