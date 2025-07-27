using UnityEngine;
using Random = UnityEngine.Random;

public class Road : MonoBehaviour
{
    [Header("金币")]
    public GameObject coinPrefab;
    [Header("障碍物")]
    public GameObject barrierPrefab;
    [Header("道具")]
    public GameObject propPrefab;
    
    private void Start()
    {
        // 在每段路上随机产生20-50个物品
        int goodsCount = Random.Range(20, 50);
        for (int i = 0; i < goodsCount; i++)
        {
            int height = Random.Range(2, 5);
            float x = transform.position.x;
            Instantiate(coinPrefab, new Vector3(Random.Range(x - 25, x + 25), 0.55f * height, -2f),
                Quaternion.Euler(90f, 180f, 0f));
        }

        // 在每段路上随机产生5-10个障碍物
        int barrierCount = Random.Range(5, 10);
        for (int i = 0; i < barrierCount; i++)
        {
            float x = transform.position.x;
            Instantiate(barrierPrefab, new Vector3(Random.Range(x - 15, x + 25), 0.5f, -2f),
                Quaternion.Euler(90, 180, 0));
        }
        
        // 在每段路上随机产生2个障碍物
        for (int i = 0; i < 2; i++)
        {
            int height = Random.Range(2, 4);
            float x = transform.position.x;
            Instantiate(propPrefab, new Vector3(Random.Range(x - 5, x + 25), 0.6f * height, -2f),
                Quaternion.Euler(90, 180, 0));
        }
    }

    // 离开摄像机视野时立即销毁
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
