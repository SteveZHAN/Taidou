using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCManager : MonoBehaviour 
{
    public static NPCManager _instance;

    public GameObject[] npcArray;
    private Dictionary<int, GameObject> npcDict = new Dictionary<int, GameObject>();
    public GameObject transcriptGo;     //用于存储副本的位置

    void Awake()
    {
        _instance = this;

        Init();
    }

	void Init()             //初始化
	{
        foreach (GameObject go in npcArray)
        {
            int id = int.Parse(go.name.Substring(0, 4));        //go.name.Substring()方法取得是go游戏对象名字的前四个字符
            npcDict.Add(id, go);            //添加入字典中
        }
	}

    public GameObject GetNpcById(int id)            //根据对象名字前面字符的id查找到对象
    {
        GameObject go = null;
        npcDict.TryGetValue(id, out go);        //根据id对npcDict字典使用TryGetValue方法进行查找，查找到的对象存在go中

        return go;
    }

}
