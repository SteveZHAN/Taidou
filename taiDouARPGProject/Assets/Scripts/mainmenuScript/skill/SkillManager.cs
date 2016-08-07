using UnityEngine;
using System.Collections;

public class SkillManager : MonoBehaviour 
{
    public static SkillManager _instance;

    public TextAsset skillInfoText;
    private ArrayList skillList = new ArrayList();

    void Awake()
    {
        _instance = this;
    }
    void InitSkill()
    {
        string[] skillArray = skillInfoText.ToString().Split('\n');
        foreach (string str in skillArray)
        {
            string[] proArray = str.Split(',');
            Skill skill = new Skill();
            skill.Id=int.Parse(proArray[0]);
            skill.name=proArray[1];
            skill.Icon = proArray[2];
            switch (proArray[3])
            {
                case "Warrior":
                    skill.PlayerType = PlayerType.Warrior;
                    break;
                case "FemaleAssassin":
                    skill.PlayerType = PlayerType.FemaleAssassin;
                    break;
            }
            switch (proArray[4])
            {
                case "Basic":
                    skill.SkillType = SkillType.Basic;
                    break;
                case "Skill":
                    skill.SkillType = SkillType.Skill;
                    break;
            }
            switch (proArray[5])
            {
                case "Basic":
                    skill.PosType = PosType.Basic;
                    break;
                case "One":
                    skill.PosType = PosType.One;
                    break;
                case "Two":
                    skill.PosType = PosType.Two;
                    break;
                case "Three":
                    skill.PosType = PosType.Three;
                    break;
            }
            skill.ColdTime = int.Parse(proArray[6]);
            skill.Damage = int.Parse(proArray[7]);
            skill.Level = int.Parse(proArray[8]);

            skillList.Add(skill);
        }
    }
}
