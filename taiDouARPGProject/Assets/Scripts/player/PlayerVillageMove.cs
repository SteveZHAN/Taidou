using UnityEngine;
using System.Collections;

public class PlayerVillageMove : MonoBehaviour 
{
    public float velocity = 5;
    private NavMeshAgent agent;

	void Start ()
	{
        agent = this.GetComponent<NavMeshAgent>();
	}

	void Update ()
	{
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 vel = GetComponent<Rigidbody>().velocity;

        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)       //按下控制移动的键
        {
            GetComponent<Rigidbody>().velocity = new Vector3(-h * velocity, vel.y, -v * velocity);
            transform.rotation = Quaternion.LookRotation(new Vector3(-h, 0, -v));      //用四元数的LookRotation方法控制对象朝向
        }
        else
        {
            if (agent.enabled == false)         //没有按钮&没有寻路的情况下执行下面的代码块
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;              //速度归零
            }
        }
        if (agent.enabled)
        {
            transform.rotation = Quaternion.LookRotation(agent.velocity);
        }
	}
}
