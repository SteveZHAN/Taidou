using UnityEngine;
using System.Collections;

public class TaskUI : MonoBehaviour 
{
    public static TaskUI _instance;

    private UIGrid taskListGrid;
    public GameObject taskItemPrefab;
    private TweenPosition tween;
    private UIButton closeButton;
	void Awake ()
	{
        _instance = this;

        taskListGrid = transform.Find("Scroll View/Grid").GetComponent<UIGrid>();
        tween = this.GetComponent<TweenPosition>();
        closeButton = transform.Find("CloseButton").GetComponent<UIButton>();


        EventDelegate ed = new EventDelegate(this, "OnClose");
        closeButton.onClick.Add(ed);
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

    public void Show()
    {
        tween.PlayForward();
    }

    public void Hide()
    {
        tween.PlayReverse();
    }

    void OnClose()
    {
        Hide();
    }
}
