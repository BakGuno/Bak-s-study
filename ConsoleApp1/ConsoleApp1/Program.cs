using System.Globalization;
using static System.Formats.Asn1.AsnWriter;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character();
        }

        class Character
        {
            public int level { get; private set; }
            public string name { get; private set; }
            public string job { get; private set; }
            public float attackPower { get; private set; }
            public float defensePower { get; private set; }
            public float health { get; private set; }
            public float hasgold { get; private set; }
            public List<Item> item = new List<Item>();
            public List<int> equipItemCodes = new List<int>();
            public Item equipArmor { get; private set; }
            public Item equipWeapon { get; private set; }
            public int exp { get; private set; }

            public Character()
            {
                attackPower = 10;
                defensePower = 5;
                health = 100;
                hasgold = 15000;
                exp = 0;
                level = 1;
                setName();
                setJob();
            }

            public void levelup()
            {
                level++;
                attackPower = 10 + ((level - 1) * 0.5f);
                defensePower = 5 + ((level - 1) * 1);
                exp = 0;
            }

            public void expup()
            {
                exp++;
            }

            public void setGold(float price)
            {
                hasgold += price;
            }

            public void setName()
            {
                Console.Write("먼저 이름을 정해주세요.");
                string nameinput = Console.ReadLine();
                name = nameinput;

            }
            public void setHealth(float healthchange)
            {
                health += healthchange;
                if (health < 0)
                    health = 0;
                else if (health > 100)
                    health = 100;
            }
            public void setJob()
            {
                Console.WriteLine("직업을 선택해주세요.");
                Console.WriteLine("1. 전사 : 최종 방어력이 더 높습니다.");
                Console.WriteLine("2. 궁수 : 최종 공격력이 더 높습니다.");
                string jobinput = Console.ReadLine();
                int jobchoice = 0;
                bool check = int.TryParse(jobinput, out jobchoice);
                switch (check)
                {
                    case true:
                        switch (jobchoice)
                        {
                            case 1:
                                job = "전사";
                                break;
                            case 2:
                                job = "궁수";
                                break;
                            default:
                                Console.WriteLine("잘못된 선택입니다.");
                                Console.ReadLine();
                                setJob();
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("숫자를 입력해주세요.");
                        Console.ReadLine();
                        setJob();
                        break;
                }
            }
            public void EquipArmor(Item item)
            {
                equipArmor = item;
            }

            public void resetArmor()
            {
                equipArmor = null;
            }

            public void EquipWeapon(Item item)
            {
                equipWeapon = item;
            }

            public void resetWeapon()
            {
                equipWeapon = null;
            }

        }

        [Serializable]
        class SerializableDataField
        {
            public int level;
            public string name;
            public string job;
            public float attackPower;
            public float defensePower;
            public float health;
            public float hasgold;
            public List<Item> item = new List<Item>();
            public List<int> equipItemCodes = new List<int>();
            public Item equipArmor;
            public Item equipWeapon;
            public int exp;
        }

        static void SaveData(Character character)
        {
            string path = @"C:\LocalSave\save.txt";
            SerializableDataField savedata = new SerializableDataField();
            savedata.level = character.level;
            JObject configData = new JObject();
            configData.Add("level", savedata.level);
            File.WriteAllText(path, configData.ToString());

        }
        static void LoadData(Character character)
        {

        }

    }
}


}
