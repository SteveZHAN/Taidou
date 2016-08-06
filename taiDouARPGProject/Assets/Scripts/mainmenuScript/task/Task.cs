using UnityEngine;
using System.Collections;

public enum TaskType
{
    Main,       //主线任务
    Reward,     //赏金任务
    Daily       //日常任务
}

public enum TaskProgress
{
    NoStart,
    Accept,
    Complete,
    Reward
}
public class Task 
{
    private int id;
    private TaskType taskType; 
    private string name;
    private string icon;
    private string des;
    private int coin;
    private int diamond;
    private string talkNpc;
    private int idNpc;
    private int idTranscript;
    private TaskProgress taskProgress = TaskProgress.NoStart;

    public delegate void OnTaskChangeEvent();         //定义一个委托
    public event OnTaskChangeEvent OnTaskChange;      //利用定义的委托生成一个事件

    #region Get Set Method
    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public TaskType TaskType
    {
        get { return taskType; }
        set { taskType = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Icon
    {
        get { return icon; }
        set { icon = value; }
    }
    public string Des
    {
        get { return des; }
        set { des = value; }
    }
    public int Coin
    {
        get { return coin; }
        set { coin = value; }
    }
    public int Diamond
    {
        get { return diamond; }
        set { diamond = value; }
    }
    public string TalkNpc
    {
        get { return talkNpc; }
        set { talkNpc = value; }
    }
    public int IdNpc
    {
        get { return idNpc; }
        set { idNpc = value; }
    }
    public int IdTranscript
    {
        get { return idTranscript; }
        set { idTranscript = value; }
    }
    public TaskProgress TaskProgress
    {
        get { return taskProgress; }
        set 
        {
            if (taskProgress != value)      //不等于说明状态发生改变
            {
                taskProgress = value;       //将新的状态值value赋过去
                OnTaskChange();
            }
        }
    }
#endregion

}
