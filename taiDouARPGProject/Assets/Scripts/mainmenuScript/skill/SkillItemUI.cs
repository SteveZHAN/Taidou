using UnityEngine;
using System.Collections;

public class SkillItemUI : MonoBehaviour 
{
    public PosType posType;
    private Skill skill;
    private UISprite sprite;
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

    void Start()
    {
        UpdateShow();
    }
	void UpdateShow()
	{
        skill = SkillManager._instance.GetSkillByPosition(posType);     //得到对应位置的技能信息

        Sprite.spriteName = skill.Icon;
	}
}
