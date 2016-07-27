using UnityEngine;
using System.Collections;

public class characterShow : MonoBehaviour 
{	
	public void OnPress(bool isPress)         //点击脚本绑定模型时调用此函数
    {
        if(isPress == false)
        StartMenuController._instance.OnCharacterClick(transform.parent.gameObject);
    }
}
