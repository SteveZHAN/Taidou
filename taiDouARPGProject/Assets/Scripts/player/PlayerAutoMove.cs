using UnityEngine;
using System.Collections;

public class PlayerAutoMove : MonoBehaviour 
{
    private NavMeshAgent agent;
    public float minDistance = 3;       //寻路剩余的最小距离
    //public Transform target;        //目标位置坐标
	void Start ()
	{
        agent = this.GetComponent<NavMeshAgent>();
	}

	void Update ()
	{
        if (agent.enabled)
        {
            if (agent.remainingDistance<minDistance && agent.remainingDistance!=0)      //remainingDistance表示寻路的剩余距离，小于规定的值就执行代码块
            {
                agent.Stop();       //停止导航寻路
                agent.enabled=false;
                TaskManager._instance.OnArriveDestination();
            }
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (Mathf.Abs(h) > 0.05f || Mathf.Abs(v) > 0.05f)
        {
            StopAuto();     //如果在寻路过程中按下移动控制键，那么就停止寻路
        }

        //test
        /*
        if (Input.GetMouseButtonDown(0))
        {
            SetDestination(target.position);
        }
        */
	}

    public void SetDestination(Vector3 targetPos)            //设置一个目标，朝着此目标移动
    {
        agent.enabled = true;
        agent.SetDestination(targetPos);
    }

    public void StopAuto()          //停止自动寻路的函数
    {
        if (agent.enabled)
        {
            agent.Stop();       //停止导航寻路
            agent.enabled = false;
        }
    }
}
