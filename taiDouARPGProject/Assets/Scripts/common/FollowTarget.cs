using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour 
{
    public Vector3 offset;      //Camera和主角的坐标偏移量
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = player.position + offset;      //主角位置+偏移量赋予Camera坐标，实现Camera跟随主角
    }
}
