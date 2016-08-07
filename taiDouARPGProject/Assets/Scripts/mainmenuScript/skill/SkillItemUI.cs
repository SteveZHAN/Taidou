using UnityEngine;
using System.Collections;

public class SkillItemUI : MonoBehaviour 
{
    public PosType posType;
    private Skill skill;
    private UISprite sprite;
    private UIButton button;
    private UISprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = this.GetComponent<UISprite>();
            }
            return sprite;
        }
    }
    private UIButton Button
    {
        get
        {
            if (button == null)
            {
                button = this.GetComponent<UIButton>();
            }
            return button;
        }
    }

    void Start()
    {
        UpdateShow();
    }
	void UpdateShow()
	{
        skill = SkillManager._instance.GetSkillByPosition(posType);     //得到对应位置的技能信息

        Sprite.spriteName = skill.Icon;
        Button.normalSprite = skill.Icon;       
	}

    void OnClick()      //点击技能图标是调用的函数，NGUI自带的OnClick(bool isPress)函数
    {
        transform.parent.parent.SendMessage("OnSkillClick", skill);     
    }
}
