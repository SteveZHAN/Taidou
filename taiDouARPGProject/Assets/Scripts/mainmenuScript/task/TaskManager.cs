using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour 
{
    public static TaskManager _instance;

    public TextAsset taskinfoText;
    private ArrayList taskList=new ArrayList();

    private Task currentTask;

    private PlayerAutoMove playerAutoMove;
    private PlayerAutoMove PlayerAutoMove
    {
        get
        {
            if (playerAutoMove == null)
                playerAutoMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutoMove>();
            return playerAutoMove;
        }
    }

    void Awake()
    {
        _instance = this;
        InitTask();
    }

    void Start()
    {
        
    }

    /// <summary>
    /// 初始化任务信息
    /// </summary>
    public void InitTask()
    {
        string[] taskinfoArray = taskinfoText.ToString().Split('\n');
        foreach (string str in taskinfoArray)
        {
            string[] proArray = str.Split('|');
            Task task = new Task();
            task.Id = int.Parse(proArray[0]);
            switch(proArray[1])
            {
                case "Main":
                    task.TaskType = TaskType.Main;
                    break;
                case "Reward":
                    task.TaskType = TaskType.Reward;
                    break;
                case "Daily":
                    task.TaskType = TaskType.Daily;
                    break;
            }
            task.Name = proArray[2];
            task.Icon = proArray[3];
            task.Des = proArray[4];
            task.Coin = int.Parse(proArray[5]);
            task.Diamond = int.Parse(proArray[6]);
            task.TalkNpc = proArray[7];
            task.IdNpc = int.Parse(proArray[8]);
            task.IdTranscript = int.Parse(proArray[9]);

            taskList.Add(task);
        }
    }

    public ArrayList GetTaskList()
    {
        return taskList;
    }

    //执行某个任务
    public void OnExcuteTask(Task task)
    {
        currentTask = task;

        if (task.TaskProgress == TaskProgress.NoStart)      //未开始，导航到NPC那里接受任务
        {
            PlayerAutoMove.SetDestination(NPCManager._instance.GetNpcById(task.IdNpc).transform.position);
        }
        else if (task.TaskProgress == TaskProgress.Accept)      //已接受的状态，导航到副本那里
        {
            PlayerAutoMove.SetDestination(NPCManager._instance.transcriptGo.transform.position);
        }
    }

    public void OnAcceptTask()      //接受任务
    {
        currentTask.TaskProgress = TaskProgress.Accept;

        //寻路到副本入口
        PlayerAutoMove.SetDestination(NPCManager._instance.transcriptGo.transform.position);
    }

    public void OnArriveDestination()       //到达目的地（NPC、副本入口）时调用的函数
    {
        //到达npc所在的位置时执行
        if (currentTask.TaskProgress == TaskProgress.NoStart)       
        {
            NPCDialogUI._instance.Show(currentTask.TalkNpc);
        }
        //到达副本入口的位置
        //todo
    }
}
