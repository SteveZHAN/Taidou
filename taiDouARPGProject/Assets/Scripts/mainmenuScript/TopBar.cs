using UnityEngine;
using System.Collections;

public class TopBar : MonoBehaviour 
{
    //设置UI右上角的相关组件的各个私有变量
    private UILabel coinLabel;
    private UIButton coinPlusButton;
    private UILabel diamondLabel;
    private UIButton diamondPlusButton;

	void Awake ()
	{
        //利用Find查找给各个私有变量进行赋初值
        coinLabel = transform.Find("CoinBg/Label").GetComponent<UILabel>();
        coinPlusButton = transform.Find("CoinBg/PlusButton").GetComponent<UIButton>();
        diamondLabel = transform.Find("DiamondBg/Label").GetComponent<UILabel>();
        diamondPlusButton = transform.Find("DiamondBg/PlusButton").GetComponent<UIButton>();
	}

	
}
