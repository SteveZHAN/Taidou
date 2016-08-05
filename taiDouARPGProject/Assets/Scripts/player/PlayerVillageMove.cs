using UnityEngine;
using System.Collections;

public class PlayerVillageMove : MonoBehaviour 
{
    public float velocity = 5;

	void Start ()
	{

	}

	void Update ()
	{
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = GetComponent<Rigidbody>().velocity;
        GetComponent<Rigidbody>().velocity = new Vector3(h * velocity, vel.y, v * velocity);

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)       //按下控制移动的键
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(h, 0, v));      //用四元数的LookRotation方法控制对象朝向
        }
	}
}
