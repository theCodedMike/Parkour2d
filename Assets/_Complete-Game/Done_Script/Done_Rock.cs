using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_Rock : MonoBehaviour {

	//当离开摄像机视野时立即销毁
	void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
