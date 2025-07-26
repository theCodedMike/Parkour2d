using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Road : MonoBehaviour {

	//在道路上显示的金币、障碍物
	public GameObject[] mObjects=new GameObject[3];


	void Start () 
	{

		//在每段路段上随机产生20到50个物品
		int mCount=Random.Range(20,50);

		for(int i=0;i<mCount;i++)
		{
			//随机生成金币的高度			
			int height = Random.Range (2, 5);
			Instantiate(mObjects[0],new Vector3(Random.Range(this.transform.position.x-25,this.transform.position.x+25),0.55f*height,-2F),
						Quaternion.Euler(new Vector3(90F,180F,0F)));
		}
		//在每段路段上随机产生5到10个障碍物
		mCount=Random.Range(5,10);
		for(int i=0;i<mCount;i++)
		{
			Instantiate(mObjects[1],new Vector3(Random.Range(this.transform.position.x-15,this.transform.position.x+25),0.5F,-2F),
						Quaternion.Euler(new Vector3(90F,180F,0F)));
		}
		for (int i = 0; i < 2; i++) 
		{
			int height = Random.Range (2, 4);
			Instantiate(mObjects[2],new Vector3(Random.Range(this.transform.position.x-5,this.transform.position.x + 25), 0.6f*height, -2F),
						Quaternion.Euler (new Vector3 (90F, 180F, 0F)));
		}
	}

	//当离开摄像机视野时立即销毁
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
