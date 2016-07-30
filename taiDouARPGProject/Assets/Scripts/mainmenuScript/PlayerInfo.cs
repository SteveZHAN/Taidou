﻿using UnityEngine;
using System.Collections;



public enum InfoType
{
    Name,
    HeadPortrait,
    Level,
    Power,
    Exp,
    Diamond,
    Coin,
    Energy,
    Toughen,
    HP,
    Damage,
    Equip,
    All
}

    
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

    private int _hp;
    private int _damage;
    //private int _helmID = 0;            //装备ID=0表示没有穿上此装备            
    //private int _clothID = 0;
    //private int _weaponID = 0;
    //private int _shoesID = 0;
    //private int _necklaceID = 0;
    //private int _braceletID = 0;
    //private int _ringID = 0;
    //private int _wingID = 0;

    public InventoryItem helmInventoryItem;
    public InventoryItem clothInventoryItem;
    public InventoryItem weaponInventoryItem;
    public InventoryItem shoesInventoryItem;
    public InventoryItem necklaceInventoryItem;
    public InventoryItem braceletInventoryItem;
    public InventoryItem ringInventoryItem;
    public InventoryItem wingInventoryItem;

    #endregion

    public float energyTimer = 0;
    public float toughenTimer = 0;

    public delegate void OnPlayerInfoChangedEvent(InfoType type);
    public event OnPlayerInfoChangedEvent OnPlayerInfoChanged;


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

    public int HP
    {
        get { return _hp; }
        set { _hp = value; }
    }
    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }
    //public int HelmID
    //{
    //    get { return _helmID; }
    //    set { _helmID = value; }
    //}
    //public int ClothID
    //{
    //    get { return _clothID; }
    //    set { _clothID = value; }
    //}
    //public int WeaponID
    //{
    //    get { return _weaponID; }
    //    set { _weaponID = value; }
    //}
    //public int ShoesID
    //{
    //    get { return _shoesID; }
    //    set { _shoesID = value; }
    //}
    //public int NecklaceID
    //{
    //    get { return _necklaceID; }
    //    set { _necklaceID = value; }
    //}
    //public int BraceletID
    //{
    //    get { return _braceletID; }
    //    set { _braceletID = value; }
    //}
    //public int RingID
    //{
    //    get { return _ringID; }
    //    set { _ringID = value; }
    //}
    //public int WingID
    //{
    //    get { return _wingID; }
    //    set { _wingID = value; }
    //}

    #endregion

    #region unity Event
    void Awake() 
    {
        _instance = this;
    }

    void Start()
    {
        Init();
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
                OnPlayerInfoChanged(InfoType.Energy);
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
            if (toughenTimer > 60)
            {
                Toughen += 1;
                toughenTimer -= 60;
                OnPlayerInfoChanged(InfoType.Toughen);
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
        this.Name = "text";
        this.Toughen = 34;

        
        //this.BraceletID = 1001;
        //this.WingID = 1002;
        //this.RingID = 1003;
        //this.ClothID = 1004;
        //this.HelmID = 1005;
        //this.WeaponID = 1006;
        //this.NecklaceID = 1007;
        //this.ShoesID = 1008;

        //InitHPDamagePower();            //装备对生命值、伤害、攻击力的影响的函数初始化

        OnPlayerInfoChanged(InfoType.All);
    }

    public void ChangeName(string newName)
    {
        this.Name = newName;
        OnPlayerInfoChanged(InfoType.Name);
    }

    public void DressOn(InventoryItem it)
    {
        it.IsDressed = true;
        //首先检测有咩有穿上相同类型的装备
        bool isDressed = false;
        InventoryItem inventoryItemDressed = null;
        switch (it.Inventory.EquipTYPE)
        {
            case EquipType.Bracelet:
                if (braceletInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = braceletInventoryItem;
                }
                    braceletInventoryItem = it;
                break;
            case EquipType.Cloth:
                if (clothInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = clothInventoryItem;
                }
                    clothInventoryItem = it;
                break;
            case EquipType.Helm:
                if (helmInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = helmInventoryItem;
                }
                    helmInventoryItem = it;
                break;
            case EquipType.Necklace:
                if (necklaceInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = necklaceInventoryItem;
                }
                    necklaceInventoryItem = it;
                break;
            case EquipType.Ring:
                if (ringInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = ringInventoryItem;
                }
                    ringInventoryItem = it;
                break;
            case EquipType.Shoes:
                if (shoesInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = shoesInventoryItem;
                }
                    shoesInventoryItem = it;
                break;
            case EquipType.Weapon:
                if (weaponInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = weaponInventoryItem;
                }
                    weaponInventoryItem = it;
                break;
            case EquipType.Wing:
                if (wingInventoryItem != null)
                {
                    isDressed = true;
                    inventoryItemDressed = wingInventoryItem;
                }
                    wingInventoryItem = it;
                break;
        }
        //有
        if (isDressed)
        {
            inventoryItemDressed.IsDressed = false;
            InventoryUI._instance.AddInventoryItem(inventoryItemDressed);       //使用InventoryUI中的单例模式，进而实现AddInventoryItem()的调用
        }
        OnPlayerInfoChanged(InfoType.Equip);
        //把已经存在的脱掉 放到背包
        //没有
        //直接穿上
    }

    void InitHPDamagePower()        //初始化是否穿上装备对生命值、伤害、攻击力的影响
    {
        this.HP = this.Level * 100;
        this.Damage = this.Level * 50;
        this.Power = this.HP + this.Damage;

        //对各个装备是否穿上(由对应ID是否为0决定)调用函数进行生命值、伤害、攻击力的增加
        //PutonEquip(BraceletID);
        //PutonEquip(WingID);
        //PutonEquip(RingID);
        //PutonEquip(ClothID);
        //PutonEquip(HelmID);
        //PutonEquip(WeaponID);
        //PutonEquip(NecklaceID);
        //PutonEquip(ShoesID);
    }

    void PutonEquip(int id)             //使用装备对生命值、伤害、攻击力等数值的影响
    {
        if (id == 0)                //如果ID=0，就说明没有穿上装备，没有对生命值、伤害、攻击力有影响，直接return
            return;

        Inventory inventory = null;
        bool isExit = InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);    //使用单例模式，根据字典取值,返回bool判断值

        this.HP += inventory.HP;
        this.Damage += inventory.Damage;
        this.Power += inventory.Power;
    }

    void PutoffEquip(int id)            //卸下装备对生命值、伤害、攻击力等数值的影响
    {
        if (id == 0)                //如果ID=0，就说明没有穿上装备，没有对生命值、伤害、攻击力有影响，直接return
            return;

        Inventory inventory = null;
        InventoryManager._instance.inventoryDict.TryGetValue(id, out inventory);    //使用单例模式，根据字典取值。id指字典的Key，取Key对应的value存储于inventory
        this.HP -= inventory.HP;
        this.Damage -= inventory.Damage;
        this.Power -= inventory.Power;
    }
}
