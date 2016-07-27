using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{
//姓名
//头像
//等级
//战斗力
//经验数
//钻石数
//金币数
//体力数
//历练数

    public static PlayerInfo _instance;

    #region property
    private string _name;
    private string _headPortrait;
    private int _level = 1;
    private int _power = 1;
    private int _exp = 1;
    private int _diamond;
    private int _coin;
    private int _energy;
    private int _toughen;
    #endregion

    private float energyTimer = 0;
    private float toughenTimer = 0;

    #region get set method
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }
    public string HeadPortrait
    {
        get
        {
            return _headPortrait;
        }
        set
        {
            _headPortrait = value;
        }
    }
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
        }
    }
    public int Exp
    {
        get
        {
            return _exp;
        }
        set
        {
            _exp = value;
        }
    }
    public int Diamond
    {
        get
        {
            return _diamond;
        }
        set
        {
            _diamond = value;
        }
    }
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
    public int Energy
    {
        get
        {
            return _energy;
        }
        set
        {
            _energy = value;
        }
    }
    public int Toughen
    {
        get
        {
            return _toughen;
        }
        set
        {
            _toughen = value;
        }
    }
    #endregion

    #region unity Event
    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        //实现体力的自动增长
        if(this.Energy < 100)
        {
            energyTimer += Time.deltaTime;
            if (energyTimer > 60)
            {
                Energy += 1;
                energyTimer -= 60;
            }
        }
        else
        {
            this.energyTimer = 0;
        }
        //实现历练的自动增长
        if(this.Toughen < 50)
        {
            toughenTimer += Time.deltaTime;
            if(energyTimer > 60)
            {
                Toughen += 1;
                toughenTimer -= 60;
            }
        }
        else
        {
            toughenTimer = 0;
        }
    }
    #endregion

    void Init()
    {
        this.Coin = 9870;
        this.Diamond = 1234;
        this.Energy = 78;
        this.Exp = 123;
        this.HeadPortrait = "头像底板女性";
        this.Level = 12;
        this.name = "STeve";
        this.Power = 1745;
        this.Toughen = 34;
    }
}
