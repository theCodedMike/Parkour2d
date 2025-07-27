using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("金币")]
    public Text goldCoin;
    [Header("距离")]
    public Text distance;
    
    
    private Player _player;

    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
    }

    private void Update()
    {
        goldCoin.text = $"金币: {_player.coinCount}";
        distance.text = $"距离: {_player.length}";
    }
}
