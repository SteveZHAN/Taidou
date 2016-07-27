using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour 
{
    public static StartMenuController _instance;    //声明此脚本实例为了方便OnCharacterClick函数的调用

    public TweenScale startPanelTween;              //开始面板的Tween动画
    public TweenScale loginPanelTween;              //登录面板的Tween动画
    public TweenScale registerPanelTween;           //注册面板的Tween动画
    public TweenScale serverPanelTween;             //服务器面板的Tween动画
    public TweenPosition startPanelTweenPos;        //开始菜单移除的Tween动画
    public TweenPosition characterSelectTween;      //角色选择菜单移进的Tween动画
    public TweenPosition characterShowTween;        //角色展示菜单移进的Tween动画

    public UIInput usernameInputLogin;              //登录面板上账号的输入框变量
    public UIInput passwordInputLogin;              //登陆面板上密码的输入框变量
    public UIInput characternameInput;              //角色展示面板上角色名的输入框变量

    public UILabel usernameLabelStart;              //开始面板中用户名的label变量
    public UILabel servernameLabelStart;            //开始面板中服务器的label变量
    public UILabel nameLabelCharacterSelect;        //角色信息的名称的label变量
    public UILabel levelLabelCharacterSelect;       //角色信息的等级的label变量

    public static string username;                  //用户名
    public static string password;                  //密码
    public static serverProperty sp;

    public UIInput usernameInputRegister;           //注册面板上的账号输入框变量
    public UIInput passwordInputRegister;           //注册面板上密码的输入框变量
    public UIInput repasswordInputRegister;         //注册面板上重复密码的输入框变量
    

    public UIGrid serverlistGrid;

    public GameObject serveritemRed;
    public GameObject serveritemGreen;

    private bool haveInitServerlist = false;        //是否初始化服务器列表变量

    public GameObject serverSelectedGo;             //服务器面板中已选择的服务器对象变量

    public GameObject[] characterArray;             //角色模型数组变量
    public GameObject[] characterSelectedArray;     //已选择的角色模型数组变量

    private GameObject characterSelected;           //当前选择的角色

    public Transform characterSelectedParent;       //用于存放选择角色的空的父物体变量


    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        InitServerlist();               //初始化服务器列表
    }
    public void OnUsernameClick()
    {
        //输入账号进行登录
        startPanelTween.PlayForward();                  //启动Start中的Tween Sacle隐藏动画
        StartCoroutine(HidePanel(startPanelTween.gameObject));        //开启协同程序设置start对象为未启用状态
        loginPanelTween.gameObject.SetActive(true);     //将一开始未启用的login进行启用
        loginPanelTween.PlayForward();                  //启动Login中的Tween Sacle显示动画
    }

    public void OnServerClick()
    {
        //选择服务器
        startPanelTween.PlayForward();                  //启动Start中的Tween Sacle隐藏动画
        StartCoroutine(HidePanel(startPanelTween.gameObject));        //开启协同程序设置start对象为未启用状态

        serverPanelTween.gameObject.SetActive(true);
        serverPanelTween.PlayForward();

        //InitServerlist();           //初始化服务器列表
    }

    public void OnEnterGameClick()
    {
        //1.连接服务器，验证用户名和密码
        //todo

        //2.进入角色选择界面
        startPanelTweenPos.PlayForward();           //开始菜单移除的Tween动画
        StartCoroutine(HidePanel(startPanelTweenPos.gameObject));   //开始菜单移除动画后把其对象进行状态隐藏
        characterSelectTween.gameObject.SetActive(true);    //将角色选择菜单对应的对象状态激活
        characterSelectTween.PlayForward();         //角色选择菜单移进的Tween动画
    }

    //隐藏面板
    IEnumerator HidePanel(GameObject go)            //协同
    {
        yield return new WaitForSeconds(0.4f);      //函数运行到这里会被暂时挂起，0.4秒后重新被调用，相当于使用Invoke函数延迟0.4秒
        go.SetActive(false);                        //将某个GameObject设定为未启用状态
    }

    public void OnLoginClick()          //点击登录面板中“登录”按钮的调用函数
    {
        //得到用户名和密码，储存
        username = usernameInputLogin.value;        //获取登录面板中账号输入框的输入值并赋予username
        password = passwordInputLogin.value;        //获取登录面板中密码输入框的输入值并赋予password
        
        //返回开始界面
        loginPanelTween.PlayReverse();              //返回loginPanelTween动画的原来状态，也就是隐藏Login中的Tween Sacle显示动画
        StartCoroutine(HidePanel(loginPanelTween.gameObject));      //开启协同程序设置login对象为未启用状态
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse();              //返回startPanelTween动画的原来状态，也就是显示Start中的Tween Sacle显示动画

        usernameLabelStart.text = username;         //将上面的username的值赋予开始面板中用户名的Label文本
    }

    public void OnRegisterShowClick()           //点击登录面板中“注册”按钮的调用函数
    {
        //隐藏当前面板，显示注册面板
        loginPanelTween.PlayReverse();              //启用login面板的隐藏动画
        StartCoroutine(HidePanel(loginPanelTween.gameObject));        //开启协同程序设置login对象为未启用状态

        registerPanelTween.gameObject.SetActive(true);
        registerPanelTween.PlayForward();             //启动register中的Tween Sacle显示动画
    }

    public void OnLoginCloseClick()         //点击登录面板中“关闭”按钮的调用函数
    {
        //返回开始界面
        loginPanelTween.PlayReverse();              //返回loginPanelTween动画的原来状态，也就是隐藏Login中的Tween Sacle显示动画
        StartCoroutine(HidePanel(loginPanelTween.gameObject));      //开启协同程序设置login对象为未启用状态
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse();              //返回startPanelTween动画的原来状态，也就是显示Start中的Tween Sacle显示动画
    }

    public void OnCancelClick()             //注册面板中“取消”按钮的调用函数
    {
        //隐藏注册面板，显示登录面板
        registerPanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerPanelTween.gameObject));
        
        loginPanelTween.gameObject.SetActive(true);
        loginPanelTween.PlayForward();
    }

    public void OnRegeiterCloseClick()      //注册面板中“关闭”按钮的调用函数
    {
        OnCancelClick();        //与点击注册面板中“取消”按钮一样效果，直接调用OnCancelClick()函数
    }

    public void OnRegisterAndLoginClick()        //注册面板中“注册并登录”按钮的调用函数
    {
        //1.本地校验，连接服务器进行校验
        //todo

        //2.连接失败
        //todo

        //3.连接成功
        //保存用户名和密码
        username = usernameInputRegister.value;
        password = passwordInputRegister.value;
        
        //返回到开始界面
        //隐藏注册面板
        registerPanelTween.PlayReverse();
        StartCoroutine(HidePanel(registerPanelTween.gameObject));

        //显示开始界面
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse();

        usernameLabelStart.text = username;
    }

    public void InitServerlist()
    {
        if (haveInitServerlist)
            return;

        //1.连接服务器，取得游戏服务器列表信息
        //todo

        //2.根据上面的信息，添加服务器列表
        for (int i = 0; i < 20; i++)
        {
            //public string ip = "127.0.0.1:9080";
            //public string name = "1区 马达加斯加";
            //public int count = 100;
            string ip = "127.0.0.1:9080";
            string name = (i + 1) + "区 马达加斯加";
            int count = Random.Range(0, 100);
            GameObject go = null;
            if(count>50)
                //火爆
                go = NGUITools.AddChild(serverlistGrid.gameObject, serveritemRed);       //AddChild()函数第一个参数是父物体，第二个是子物体；返回值是子物体
            else
                //流畅
                go = NGUITools.AddChild(serverlistGrid.gameObject, serveritemGreen);

            serverProperty sp = go.GetComponent<serverProperty>();
            sp.ip = ip;
            sp.name = name;
            sp.count = count;

            serverlistGrid.AddChild(go.transform);      //使用AddChild()函数告知serverlistGrid将go游戏物体进行排序
        } 

        haveInitServerlist = true;
    }

    public void OnServerSelect(GameObject serverGo)
    {
        sp = serverGo.GetComponent<serverProperty>();
        serverSelectedGo.GetComponent<UISprite>().spriteName = serverGo.GetComponent<UISprite>().spriteName;    //更新已选择服务器对象的背景
        serverSelectedGo.transform.Find("Label").GetComponent<UILabel>().text = sp.name;                        //更新已选择服务器对象的Label文字
    }

    public void OnServerPanelClose()
    {
        //隐藏服务器列表
        serverPanelTween.PlayReverse();
        StartCoroutine(HidePanel(serverPanelTween.gameObject));
        
        //显示开始界面
        startPanelTween.gameObject.SetActive(true);
        startPanelTween.PlayReverse();

        //选择服务器后更改开始面板中服务器的名称
        servernameLabelStart.text = sp.name;
    }

    public void OnCharacterClick(GameObject go)         //此函数作用是选择模型后模型会进行放大，需要导入iTween脚本，省略此效果
    {
        //loose
        characterSelected = go;
    }

    public void OnButtonChangeCharacterClick()            //在characterSelect面板中点击“更换角色”调用此函数
    {
        //隐藏自身的面板
        characterSelectTween.PlayReverse();
        //StartCoroutine(HidePanel(characterSelectTween.gameObject));

        //显示展示角色的面板
        characterShowTween.gameObject.SetActive(true);
        characterShowTween.PlayForward();
    }

    public void OnCharacterShowButtonSureClick()        //点击角色展示面板中“确定”按钮调用的函数
    {
        //1.判断姓名输入的是否正确
        //todo

        //2.判断是否选择角色
        //todo

        int index = -1;
        for(int i=0;i<characterArray.Length;i++)
        {
            if(characterSelected == characterArray[i])
            {
                index = i;
                break;
            }
        }
        if (index == -1)
        { return; }

        GameObject.Destroy(characterSelectedParent.GetComponentInChildren<Animation>().gameObject);   //销毁现有的角色
        //创建新选择的角色
        GameObject go = GameObject.Instantiate(characterSelectedArray[index], Vector3.zero, Quaternion.identity)as GameObject;      //由对应索引值的预置体进行clone创建
        go.transform.parent = characterSelectedParent;          //将创建的对象设为characterSelectedParent的子物体
        go.transform.localPosition = Vector3.zero;              //依据父物体characterSelectedParent的坐标信息，设置创建的物体相对于父物体的距离坐标为0
        go.transform.localRotation = Quaternion.identity;       //依据父物体characterSelectedParent的坐标信息，设置创建的物体相对于父物体的旋转坐标为0
        go.transform.localScale = new Vector3(1, 1, 1);         //依据父物体characterSelectedParent的信息，设置创建的物体相对于父物体的缩放为1
        //更新角色的名字和等级
        nameLabelCharacterSelect.text = characternameInput.value;
        levelLabelCharacterSelect.text = "Lv.1";

        OnCharacterShowButtonBackClick();
    }

    public void OnCharacterShowButtonBackClick()         //点击角色展示面板中“返回”按钮调用的函数
    {
        characterShowTween.PlayReverse();
        StartCoroutine(HidePanel(characterShowTween.gameObject));

        characterSelectTween.gameObject.SetActive(true);
        characterSelectTween.PlayForward();
    }
}