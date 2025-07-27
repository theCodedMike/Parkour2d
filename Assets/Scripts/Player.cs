using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 2.5f;
    [Header("是否在奔跑")]
    public bool isRunning = true;
    [Header("路段")]
    public GameObject road;
    [Header("收集的金币数")]
    public int coinCount;
    [Header("奔跑的距离")]
    public int length;
    [Header("当前得分")]
    public int grade;
    
    private Transform _camera; // 摄像机
    private Transform _background; // 背景图片
    private int _count; // 路段总数目
    private int _deathCount; // 死亡动画播放次数
    private Animator _animator; // 动画组件


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main!.transform;
        _background = GameObject.Find("Background").transform;
    }

    private void Update()
    {
        if (isRunning)
        {
            Move();
            CreateNewRoad();
            Jump();
            UpdateData();
            
            if(coinCount == 60)
                Win();
        }
        else
            Death();
    }

    // 移动角色、相机、场景
    private void Move()
    {
        float distance = moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * distance);
        _camera.Translate(Vector3.right * distance);
        _background.Translate(Vector3.left * distance);
    }

    // 创建新的路段
    private void CreateNewRoad()
    {
        // 当角色跑完一个路段的的2/3时，创建新的路段
        if (transform.position.x + 30 - (_count - 1) * 50 >= 50f * 2 / 3)
        {
            GameObject roadObj = Instantiate(road, new Vector3(-5f + _count * 50f, 0f, -2f), Quaternion.identity);
            roadObj.transform.localScale = new Vector3(50f, 0.25f, 1f);
            _count += 1;
        }
    }

    // 跳跃
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            while (transform.position.y <= 1)
            {
                Vector3 position = transform.position;
                transform.position = new Vector3(position.x, position.y + 0.02f, position.z);
                _animator.Play("Jump");
            }

            StartCoroutine(nameof(Wait));
        }
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.8f);
        while (transform.position.y > 0.125f)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, position.y - 0.02f, position.z);
        }
    }

    // 更新玩家的游戏数据
    private void UpdateData()
    {
        // 计算奔跑距离
        length = (int)(transform.position.x + 25) * 25;
        // 计算玩家得分
        grade = (int)(length * 0.8 + coinCount * 0.2);
    }
    
    // 玩家胜利
    private void Win()
    {
        moveSpeed = 0;
        _animator.Play("Win");
    }
    
    // 玩家死亡
    private void Death()
    {
        if (_deathCount <= 1)
        {
            _animator.Play("Lose");
            _deathCount += 1;
            //PlayerPrefs.SetInt(PlayerPrefsConstant.PlayerGrade, grade);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 碰到金币
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount += 1;
            if (coinCount is 10 or 30 or 50)
                moveSpeed += 0.5f;
        } 
        // 碰到道具
        else if (other.CompareTag("Coin2"))
        {
            Destroy(other.gameObject);
            moveSpeed = 2.5f;
        }
        // 碰到障碍物
        else if (other.CompareTag("Rock"))
        {
            isRunning = false;
        }
    }
}
