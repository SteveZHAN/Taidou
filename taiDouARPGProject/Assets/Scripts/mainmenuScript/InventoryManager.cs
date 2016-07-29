using UnityEngine;
using System.Collections;
using System.Collections.Generic;       //为使用字典Dictionary而要加载的库

public class InventoryManager : MonoBehaviour 
{
    public TextAsset listInfo;      //在unity中将对应的txt文件赋值，以进行txt文件内容的读取

    private Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();        //创建一个字典，以int类型的ID作为字典的Key,Inventory作为值
    private Dictionary<int, InventoryItem> inventoryItemDict = new Dictionary<int, InventoryItem>();    //创建一个字典，以int类型的ID作为字典的Key,InventoryItem作为值

    void Awake()
    {
        ReadInventoryInfo();            //物品信息初始化
        ReadInventoryItemInfo();        //背包信息初始化
        
    }

    void ReadInventoryInfo()        //为了读取txt文件设置调用的函数
    {
        string str = listInfo.ToString();        //ToString()就可以将txt文本里面的字符串内容读取出来
        string[] itemStrArray = str.Split('\n');         //对于获取到txt文本后的字符串，按照'\n'字符分割并存入一个字符串数组中。实现按txt行分割
        foreach(string itemStr in itemStrArray)
        {
            //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 
            string[] proArray = itemStr.Split('|');     //对于txt中每一行的字符串按'|'字符串进行分割
            Inventory inventory = new Inventory();
            inventory.ID = int.Parse(proArray[0]);      //整型类型的ID，使用int.Parse()将字符串proArray[0]转换为int类型，再进行赋值
            inventory.Name = proArray[1];
            inventory.ICON = proArray[2];
            switch(proArray[3])         //对物品类型进行判断后对应类型赋值
            {
                case "Equip":
                    inventory.InventoryTYPE = InventoryType.Equip;
                    break;
                case "Daug":
                    inventory.InventoryTYPE = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryTYPE = InventoryType.Box;
                    break;
            }
            if(inventory.InventoryTYPE==InventoryType.Equip)        //首先物品类型得是Equip，才属于装备，才有必要进行装备类型的判断
            {
                switch(proArray[4])              //对装备类型进行判断后对应类型赋值
                {
                    case "Helm":
                        inventory.EquipTYPE=EquipType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipTYPE = EquipType.Cloth;
                        break;
                    case "Weapon":
                        inventory.EquipTYPE = EquipType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipTYPE = EquipType.Shoes;
                        break;
                    case "Necklace":
                        inventory.EquipTYPE = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipTYPE = EquipType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipTYPE = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipTYPE = EquipType.Wing;
                        break;
                }
            }
            //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 
            inventory.Price = int.Parse(proArray[5]);       //整型类型的Price，使用int.Parse()将字符串proArray[5]转换为int类型，再进行赋值
            if (inventory.InventoryTYPE == InventoryType.Equip)        //星级 品质 伤害 生命 战斗力 都要求物品类型得是Equip
            {
                inventory.StarLevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.HP = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            if (inventory.InventoryTYPE == InventoryType.Drug)     //作用类型要求物品类型是Drug才行
            {
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            inventory.Des = proArray[13];


            inventoryDict.Add(inventory.ID, inventory);     //每循环一遍，将其添加进字典，Key为ID，值为Inventory类型的inventory
        }
    }

    //完成角色背包信息的初始化，获得拥有的物品
    void ReadInventoryItemInfo()
    {
        //todo 需要链接服务器，取得当前角色拥有的物品信息

        //随机生成主角拥有的物品
        for(int i=0;i<20;i++)
        {
            int id = Random.Range(1001, 1020);
            Inventory I = null;
            inventoryDict.TryGetValue(id, out I);       //根据字典取值。TryGetValue(,)中第一个参数指字典的Key，取Key对应的value存储于第二个参数指

            //关于it.Count即数量，对于Drug的数量可以放在一个格子，然后count进行+1；而对于Equip，由于其等级不同，因此需放在单独的格子里。因此对于it.Count要进行判断
            if (I.InventoryTYPE == InventoryType.Equip)
            {
                InventoryItem it = new InventoryItem();
                it.Inventory = I;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                inventoryItemDict.Add(id, it);      //每循环一遍，将其添加进字典，Key为ID，值为InventoryItem类型的inventoryItem
            }
            else
            {
                //先判断背包里面是否已经存在
                InventoryItem it = null;
                bool isExit = inventoryItemDict.TryGetValue(id, out it);  //根据字典取值,返回一个bool值
                if(isExit)          //bool返回值为true，说明已存在，计数器+1即可
                {
                    it.Count++;
                }
                else                //bool返回值为false，说明不存在，生成一个
                {
                    it = new InventoryItem();
                    it.Inventory = I;   
                    it.Count = 1;
                    inventoryItemDict.Add(id, it);      //每循环一遍，将其添加进字典，Key为ID，值为InventoryItem类型的inventoryItem
                }
            }

            

        }
    }
}
