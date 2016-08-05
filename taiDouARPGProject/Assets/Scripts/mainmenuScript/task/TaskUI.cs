using UnityEngine;
using System.Collections;

public class TaskUI : MonoBehaviour 
{
    private UIGrid taskListGrid;
    public GameObject taskItemPrefab;
	void Awake ()
	{
        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();

	}

    void Start()
    {
        InitTaskList();
    }

    /// <summary>
    /// 初始化任务列表信息
    /// </summary>
	void InitTaskList()
	{
        ArrayList taskList = TaskManager._instance.GetTaskList();

        foreach (Task task in taskList)
        {
            GameObject go = NGUITools.AddChild(taskListGrid.gameObject, taskItemPrefab);    //NGUITools.AddChild()第一个参数是父物体，第二个是子物体，返回该子物体的Gameobject
            taskListGrid.AddChild(go.transform);        //实现Grid对新添加的游戏物体自动排序
            TaskItemUI ti = go.GetComponent<TaskItemUI>();
            ti.SetTask(task);
        }
	}
}
