using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.IO;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Nodes;
using System.Text.Json;
//이리저리 참조하다보니 뭐가 필요없는지 모르겠음.


namespace homework1
{
    internal class Program
    {
        class Item
        {
            public string type { get; private set; }
            public string name { get; private set; }
            public string jobconfine { get; private set; }
            public int attackPower { get; private set; }
            public int defensePower { get; private set; }
            public int price { get; private set; }
            public string explain { get; private set; }
            public int itemcode { get; private set; }
            public List<Item> shoplist = new List<Item>();            

            public static List<Item> itemsetting(List<Item> shoplist) //배열로 바꾸는게 더 좋을거 같긴한데 손댈게 너무 많음
            {
                
                //갑옷
                Item trainingArmor = new Item(); //밖에서 자식 클래스로 만들어주고싶은데 어떻게할지 모르겠음. +그렇게 하는거 아닌거같음
                trainingArmor.name = "수련자 갑옷";
                trainingArmor.type = "Armor";
                trainingArmor.jobconfine = "전사";
                trainingArmor.defensePower = 5;
                trainingArmor.explain = "수련에 도움을 주는 갑옷입니다. ";
                trainingArmor.price = 1000;
                trainingArmor.itemcode = 1001;
                shoplist.Add(trainingArmor);
                Item leatherArmor = new Item();
                leatherArmor.name = "가죽 갑옷";
                leatherArmor.type = "Armor";
                leatherArmor.jobconfine = "궁수";
                leatherArmor.defensePower = 3;
                leatherArmor.explain = "잘 가공된 가죽 갑옷입니다. ";
                leatherArmor.price = 1000;
                leatherArmor.itemcode = 1002;
                shoplist.Add(leatherArmor);
                Item metalArmor = new Item();
                metalArmor.name = "무쇠갑옷";
                metalArmor.type = "Armor";
                metalArmor.jobconfine = "전사";
                metalArmor.defensePower = 9;
                metalArmor.explain = "무쇠로 만들어져 튼튼한 갑옷입니다. ";
                metalArmor.price = 2000;
                metalArmor.itemcode = 1003;
                shoplist.Add(metalArmor);
                Item chainMail = new Item();
                chainMail.name = "체인메일";
                chainMail.type = "Armor";
                chainMail.jobconfine = "궁수";
                chainMail.defensePower = 7;
                chainMail.explain = "가볍고 유연하며 튼튼한 갑옷입니다. ";
                chainMail.price = 2000;
                chainMail.itemcode = 1004;
                shoplist.Add(chainMail);
                Item spartanArmor = new Item();
                spartanArmor.name = "스파르타의 갑옷";
                spartanArmor.type = "Armor";
                spartanArmor.jobconfine = "전사";
                spartanArmor.defensePower = 15;
                spartanArmor.explain = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ";
                spartanArmor.price = 3500;
                spartanArmor.itemcode = 1005;
                shoplist.Add(spartanArmor);
                Item bulletProof = new Item();
                bulletProof.name = "방탄복";
                bulletProof.type = "Armor";
                bulletProof.jobconfine = "궁수";
                bulletProof.defensePower = 13;
                bulletProof.explain = "이게 뭘까요? 묻지 마십시오. ";
                bulletProof.price = 3500;
                bulletProof.itemcode = 1006;
                shoplist.Add(bulletProof);

                //무기
                Item oldSword = new Item();
                oldSword.name = "낡은 검";
                oldSword.type = "Weapon";
                oldSword.jobconfine = "전사";
                oldSword.attackPower = 2;
                oldSword.explain = "쉽게 볼 수 있는 낡은 검 입니다. ";
                oldSword.price = 600;
                oldSword.itemcode = 2001;
                shoplist.Add(oldSword);
                Item shoddyBow = new Item();
                shoddyBow.name = "조약한 활";
                shoddyBow.type = "Weapon";
                shoddyBow.jobconfine = "궁수";
                shoddyBow.attackPower = 4;
                shoddyBow.explain = "금방이라도 부서질 것 같은 활입니다. ";
                shoddyBow.price = 600;
                shoddyBow.itemcode = 2002;
                shoplist.Add(shoddyBow);
                Item bronzeAxe = new Item();
                bronzeAxe.name = "청동 도끼";
                bronzeAxe.type = "Weapon";
                bronzeAxe.jobconfine = "전사";
                bronzeAxe.attackPower = 5;
                bronzeAxe.explain = "어디선가 사용됐던거 같은 도끼입니다. ";
                bronzeAxe.price = 1500;
                bronzeAxe.itemcode = 2003;
                shoplist.Add(bronzeAxe);
                Item crossBow = new Item();
                crossBow.name = "석궁";
                crossBow.type = "Weapon";
                crossBow.jobconfine = "궁수";
                crossBow.attackPower = 7;
                crossBow.explain = "기계식 활입니다. ";
                crossBow.price = 1500;
                crossBow.itemcode = 2004;
                shoplist.Add(crossBow);
                Item spartanSpear = new Item();
                spartanSpear.name = "스파르타의 창";
                spartanSpear.type = "Weapon";
                spartanSpear.jobconfine = "전사";
                spartanSpear.attackPower = 7;
                spartanSpear.explain = "스파르타의 전사들이 사용했다는 전설의 창입니다. ";
                spartanSpear.price = 3000;
                spartanSpear.itemcode = 2005;
                shoplist.Add(spartanSpear);
                Item rifle = new Item();
                rifle.name = "총";
                rifle.type = "Weapon";
                rifle.jobconfine = "궁수";
                rifle.attackPower = 9;
                rifle.explain = "빵야빵야. ";
                rifle.price = 3000;
                rifle.itemcode = 2006;
                shoplist.Add(rifle);
                return shoplist;
            }
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

            //로드할 때 초기화해주는 부분
            public void loadLevel(int value)
            {
                level = value;
            }
            public void loadName(string value)
            {
                name = value;
            }
            public void loadJob(string value)
            {
                job = value;
            }
            public void loadAP(float value)
            {
                attackPower = value;
            }
            public void loadDP(float value)
            {
                defensePower = value;
            }
            public void loadHealth(float value)
            {
                health = value;
            }
            public void loadHasgold(float value)
            {
                hasgold = value;
            }
            public void loadEA(Item value)
            {
                equipArmor = value;
            }
            public void loadEW(Item value)
            {
                equipWeapon = value;
            }
            public void loadEXP(int value)
            {
                exp = value;
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Character character = new Character();
            Console.WriteLine($"당신의 이름은 {character.name}입니다.");
            Console.WriteLine($"당신의 직업은 {character.job}입니다.");
            Console.WriteLine();
            //SaveData(character);
            Console.WriteLine("진행하려면 아무 버튼이나 누르세요.");
            Console.ReadLine();
            askDo(character);

        }

        static void askDo(Character character)
        {
            Console.Clear();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int doing = 0;
            bool check = int.TryParse(input, out doing);
            switch (check)
            {
                case true:
                    switch (doing)
                    {
                        case 1:
                            playerInfo(character);
                            break;
                        case 2:
                            viewInventory(character);
                            break;
                        case 3:
                            shop(character);
                            break;
                        case 4:
                            if (character.health <= 0)
                            {
                                Console.WriteLine("체력이 적어 입장할 수 없습니다.");
                                Console.ReadLine();
                                askDo(character);
                            }
                            else
                                enterDungeon(character);
                            break;
                        case 5:
                            getRest(character);
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadLine();
                            askDo(character);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("숫자를 입력해주세요. ");
                    Console.ReadLine();
                    askDo(character);
                    break;
            }

        }

        static void playerInfo(Character character)
        {
            Console.Clear();
            Console.WriteLine($"레벨 : {character.level}");
            Console.WriteLine($"{character.name} ({character.job})");
            if (character.equipWeapon == null)
            {
                Console.WriteLine($"공격력 : {character.attackPower}");
            }
            else if (character.equipWeapon != null)
                Console.WriteLine($"공격력 : {character.attackPower + character.equipWeapon.attackPower} (+{character.equipWeapon.attackPower})");
            if (character.equipArmor == null)
                Console.WriteLine($"방어력 : {character.defensePower}");
            else if (character.equipArmor != null)
                Console.WriteLine($"방어력 : {character.defensePower + character.equipArmor.defensePower} (+{character.equipArmor.defensePower})");
            Console.WriteLine($"체 력 : {character.health}");
            Console.WriteLine($"소지금 : {character.hasgold}");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            string quit = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(quit, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            askDo(character);
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            break;
                    }
                    Console.WriteLine("숫자를 입력해주세요.");
                    playerInfo(character);
                    Console.ReadLine();
                    break;
            }
        }

        static void viewInventory(Character character)
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.item.Count; i++)
            {
                if (character.equipWeapon == null && character.item[i].type == "Weapon")
                {
                    Console.WriteLine($"- {i + 1} {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                }
                else if (character.equipWeapon != null && character.item[i].type == "Weapon")
                {
                    if (character.equipWeapon.itemcode == character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} [E] {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                    else if (character.equipWeapon.itemcode != character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                }

                if (character.equipArmor == null && character.item[i].type == "Armor")
                {
                    Console.WriteLine($"- {i + 1} {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                }
                else if (character.equipArmor != null && character.item[i].type == "Armor")
                {
                    if (character.equipArmor.itemcode == character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} [E] {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                    else if (character.equipArmor.itemcode != character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1}  {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                }


            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            string quit = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(quit, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            askDo(character);
                            break;
                        case 1:
                            equipManagement(character);
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            viewInventory(character);
                            break;

                    }
                    break;
                default:
                    Console.WriteLine("숫자를 입력해주세요.");
                    viewInventory(character);
                    break;
            }
        }

        static void equipManagement(Character character)
        {
            Console.Clear();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.item.Count; i++)
            {
                if (character.equipWeapon == null && character.item[i].type == "Weapon")
                {
                    Console.WriteLine($"- {i + 1} {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                }
                else if (character.equipWeapon != null && character.item[i].type == "Weapon")
                {
                    if (character.equipWeapon.itemcode == character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} [E] {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                    else if (character.equipWeapon.itemcode != character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} {character.item[i].name}     | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}");
                }

                if (character.equipArmor == null && character.item[i].type == "Armor")
                {
                    Console.WriteLine($"- {i + 1} {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                }
                else if (character.equipArmor != null && character.item[i].type == "Armor")
                {
                    if (character.equipArmor.itemcode == character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1} [E] {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                    else if (character.equipArmor.itemcode != character.item[i].itemcode)
                        Console.WriteLine($"- {i + 1}  {character.item[i].name}     | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}");
                }


            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            string quit = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(quit, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            viewInventory(character);
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            if (character.item.Count == 0)
                                equipManagement(character);
                            if ((choice) <= character.item.Count && character.item.Count != 0)
                            {
                                if (character.item[choice - 1].jobconfine == character.job)
                                {
                                    if (character.item[choice - 1].type == "Weapon" && character.equipWeapon == null)
                                    {
                                        character.EquipWeapon(character.item[choice - 1]);
                                    }
                                    else if (character.item[choice - 1].type == "Weapon" && character.equipWeapon != null && character.equipWeapon.itemcode == character.item[choice - 1].itemcode)
                                        character.resetWeapon();
                                    else if (character.item[choice - 1].type == "Weapon" && character.equipWeapon != null && character.equipWeapon.itemcode != character.item[choice - 1].itemcode)
                                        character.EquipWeapon(character.item[choice - 1]);

                                    if (character.item[choice - 1].type == "Armor" && character.equipArmor == null)
                                    {
                                        character.EquipArmor(character.item[choice - 1]);
                                    }
                                    else if (character.item[choice - 1].type == "Armor" && character.equipArmor != null && character.equipArmor.itemcode == character.item[choice - 1].itemcode)
                                        character.resetArmor();
                                    else if (character.item[choice - 1].type == "Armor" && character.equipArmor != null && character.equipArmor.itemcode != character.item[choice - 1].itemcode)
                                        character.EquipArmor(character.item[choice - 1]);
                                }
                                else if (character.item[choice - 1] != null && character.item[choice - 1].jobconfine != character.job)
                                {
                                    Console.WriteLine("직업에 맞는 장비만 착용할 수 있습니다. ");
                                    Console.ReadLine();
                                    equipManagement(character);
                                }
                            }
                            else if (choice > character.item.Count)
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadLine();
                                equipManagement(character);
                            }
                            equipManagement(character);
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다..");
                            viewInventory(character);
                            break;

                    }
                    break;
                default:
                    Console.WriteLine("숫자를 입력해주세요.");
                    equipManagement(character);
                    break;
            }
        }

        static void shop(Character character)
        {
            Console.Clear();
            Item list = new Item();
            if (character.item.Count != 0)
                Console.WriteLine($"{character.item[0].name}");
            List<Item> shoplist = Item.itemsetting(list.shoplist);
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.hasgold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shoplist.Count; i++)
            {
                List<int> itemcodes = new List<int>();
                for (int j = 0; j < character.item.Count; j++)
                {
                    itemcodes.Add(character.item[j].itemcode);
                }
                if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
                if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine(">> ");
            string input = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(input, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            askDo(character);
                            break;
                        case 1:
                            buyItem(character);
                            break;
                        case 2:
                            sellItem(character);
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            shop(character);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    shop(character);
                    break;
            }
        }

        static void buyItem(Character character)
        {
            Console.Clear();
            Item list = new Item();
            List<Item> shoplist = Item.itemsetting(list.shoplist);
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("직업에 맞는 장비만 구입할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.hasgold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            List<int> itemcodes = new List<int>();
            for (int j = 0; j < character.item.Count; j++)
            {
                itemcodes.Add(character.item[j].itemcode);
            }
            for (int i = 0; i < shoplist.Count; i++)
            {
                if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
                if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} [{shoplist[i].jobconfine}] {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(input, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("가게로 돌아갑니다.");
                            Console.ReadLine();
                            shop(character);
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            if (character.job == shoplist[choice - 1].jobconfine)
                            {
                                if (character.hasgold >= shoplist[choice - 1].price && itemcodes.IndexOf(shoplist[choice - 1].itemcode) == -1)
                                {
                                    character.item.Add(shoplist[choice - 1]);
                                    character.setGold(-shoplist[choice - 1].price);
                                    Console.WriteLine("구매를 완료했습니다.");
                                    Console.ReadLine();
                                }
                                else if (character.hasgold >= shoplist[choice - 1].price && itemcodes.IndexOf(shoplist[choice - 1].itemcode) != -1)
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                    Console.ReadLine();
                                }
                                else if (character.hasgold < shoplist[choice - 1].price)
                                {
                                    Console.WriteLine("Gold 가 부족합니다.");
                                    Console.ReadLine();
                                }
                            }
                            else
                            {
                                Console.WriteLine("사용 가능한 직업이 아닙니다.");
                                Console.ReadLine();
                            }
                            buyItem(character);
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            buyItem(character);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("숫자를 입력해주세요.");
                    buyItem(character);
                    break;

            }
        }

        static void sellItem(Character character)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{character.hasgold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < character.item.Count; i++)
            {
                if (character.item[i].type == "Weapon" && character.item[i] != character.equipWeapon)
                    Console.WriteLine($"- {i + 1} {character.item[i].name}    | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}    | {(int)(character.item[i].price * 85 / 100)}G");
                else if ((character.item[i].type == "Weapon" && character.item[i] == character.equipWeapon))
                    Console.WriteLine($"- {i + 1} [E] {character.item[i].name}    | 공격력 +{character.item[i].attackPower}    | {character.item[i].explain}    | {(int)(character.item[i].price * 85 / 100)}G");
                else if (character.item[i].type == "Armor" && character.item[i] != character.equipArmor)
                    Console.WriteLine($"- {i + 1} {character.item[i].name}    | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}    | {(int)(character.item[i].price * 85 / 100)}G");
                else if (character.item[i].type == "Armor" && character.item[i] == character.equipArmor)
                    Console.WriteLine($"- {i + 1} [E] {character.item[i].name}    | 방어력 +{character.item[i].defensePower}    | {character.item[i].explain}    | {(int)(character.item[i].price * 85 / 100)}G");

            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int sell = 0;
            bool check = int.TryParse(input, out sell);
            switch (check)
            {
                case true:
                    switch (sell)
                    {
                        case 0:
                            shop(character);
                            break;
                        case int:
                            if (sell <= character.item.Count)
                            {
                                character.setGold(character.item[sell - 1].price * 85 / 100);
                                if (character.equipWeapon == character.item[sell - 1])
                                    character.resetWeapon();
                                else if (character.equipArmor == character.item[sell - 1])
                                    character.resetArmor();
                                character.item.RemoveAt(sell - 1);
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                                Console.ReadLine();
                                sellItem(character);
                            }
                            sellItem(character);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    sellItem(character);
                    break;
            }

        }

        static void enterDungeon(Character character)
        {
            Console.Clear();
            Console.WriteLine("던전 입장");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 쉬운 던전    | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전    | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int dungeon = 0;
            bool check = int.TryParse(input, out dungeon);
            float defense;
            int needDefense = 0;
            float offense;
            Random random = new Random();
            string[] proba = new string[100];
            for (int i = 0; i < 60; i++)
                proba[i] = "win";
            for (int i = 60; i < 100; i++)
                proba[i] = "lose";
            Console.ReadLine();
            proba.OrderBy(x => random.Next()).ToArray();

            if (character.equipArmor != null)
                defense = character.defensePower + character.equipArmor.defensePower;
            else
                defense = character.defensePower;

            if (character.equipWeapon != null)
                offense = character.attackPower + character.equipWeapon.attackPower;
            else offense = character.attackPower;
            switch (check)
            {
                case true:

                    switch (dungeon)
                    {
                        case 0:
                            askDo(character);
                            break;
                        case 1:
                            needDefense = 5;
                            break;
                        case 2:
                            needDefense = 11;
                            break;
                        case 3:
                            needDefense = 17;
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다. ");
                    Console.ReadLine();
                    enterDungeon(character);
                    break;
            }
            float healthchange = new Random().Next(20, 35);
            float addGold = 0;
            float reinforce = 0;
            if (defense < needDefense)
            {
                if (proba[random.Next(0, 100)] == "win")
                {
                    character.expup();
                    dungeonClear(character, dungeon, defense, offense, healthchange);
                }
                else
                    dungeonFail(character, healthchange);
            }
            else
            {
                reinforce = defense - needDefense;
                addGold = new Random().Next((int)offense, (int)offense * 2);
                character.expup();
                dungeonClear(character, dungeon, defense, addGold, healthchange - reinforce);
            }

        }

        static void dungeonClear(Character character, int diff, float defense, float addgold, float healthchange)
        {
            Console.Clear();
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            string Diff = "";
            int defaultGold = 0;
            float finalHealth = character.health - healthchange;
            switch (diff)
            {
                case 1:
                    Diff = "쉬운";
                    defaultGold = 1000;
                    break;
                case 2:
                    Diff = "일반";
                    defaultGold = 1700;
                    break;
                case 3:
                    Diff = "어려운";
                    defaultGold = 2500;
                    break;
            }
            Console.WriteLine($"{Diff} 던전을 클리어 하셨습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            if (finalHealth < 0)
                finalHealth = 0;
            Console.WriteLine($"체력 {character.health} -> {finalHealth}");
            Console.WriteLine($"Gold {character.hasgold} -> {character.hasgold + defaultGold + (int)(defaultGold * addgold / 100)}");
            switch (character.level)
            {
                case 1:
                    if (character.exp == 1)
                    {
                        Console.WriteLine("축하합니다. Lv.2가 되었습니다!");
                        character.levelup();
                    }
                    break;
                case 2:
                    if (character.exp == 2)
                    {
                        Console.WriteLine("축하합니다. Lv.3가 되었습니다!");
                        character.levelup();
                    }
                    break;
                case 3:
                    if (character.exp == 3)
                    {
                        Console.WriteLine("축하합니다. Lv.4가 되었습니다!");
                        character.levelup();
                    }
                    break;
                case 4:
                    if (character.exp == 4)
                    {
                        Console.WriteLine("축하합니다. Lv.5가 되었습니다!");
                        character.levelup();
                    }
                    break;

            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(input, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            character.setHealth(-healthchange);
                            character.setGold(defaultGold + (int)(defaultGold * addgold / 100));
                            askDo(character);
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadLine();
                            dungeonClear(character, diff, defense, addgold, healthchange);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    dungeonClear(character, diff, defense, addgold, healthchange);
                    break;
            }
        }

        static void dungeonFail(Character character, float healthchange)
        {
            Console.Clear();
            Console.WriteLine("던전 실패");
            Console.WriteLine("아쉽게도 던전 공략을 실패하셨습니다.");
            Console.WriteLine();
            float finalHealth = character.health - healthchange / 2;
            if (finalHealth < 0)
                finalHealth = 0;
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {character.health} -> {finalHealth}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            string input = Console.ReadLine();
            int todo = 0;
            bool check = int.TryParse(input, out todo);
            switch (check)
            {
                case true:
                    switch (todo)
                    {
                        case 0:
                            character.setHealth(-(healthchange / 2));
                            askDo(character);
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.ReadLine();
                            dungeonFail(character, healthchange);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ReadLine();
                    dungeonFail(character, healthchange);
                    break;
            }

        }

        static void getRest(Character character)
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {character.hasgold} G");
            Console.WriteLine($"현재 체력 : {character.health}");
            Console.WriteLine();
            Console.WriteLine("1. 휴식하기 & 저장하기");
            Console.WriteLine("2. 불러오기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(input, out choice);
            switch (check)
            {
                case true:
                    switch (choice)
                    {
                        case 0:
                            askDo(character);
                            break;
                        case 1:                            
                            character.setGold(-500);
                            character.setHealth(100);
                            SaveData(character);
                            Console.WriteLine("체력이 완전히 회복되었습니다. ");
                            Console.ReadLine();
                            getRest(character);
                            break;
                        case 2:
                            LoadData(character);
                            break;
                    }
                    break;
                default:
                    getRest(character);
                    break;
            }
        }

        static void SaveData(Character character)
        {
            string path = @"C:\LocalSave\save.txt";            
            int length = character.item.Count;
            string[] itembox = new string[length];

           
            JObject configData = new JObject(
                new JProperty("Level", $"{character.level}"),
                new JProperty("Name", $"{character.name}"),
                new JProperty("Job", $"{character.job}"),
                new JProperty("AttackPower", character.attackPower),
                new JProperty("DefensePower", character.defensePower),
                new JProperty("Health", character.health),
                new JProperty("Hasgold", character.hasgold),                
                //new JProperty("EquipArmor", character.equipArmor.itemcode),  //여기서 오류남
                //new JProperty("EquipWeapon", character.equipWeapon.itemcode),
                new JProperty("Exp", character.exp),
                new JProperty("Length", length)
                );
            for (int i = 0; i < length; i++)
            {
                itembox[i] = $"Item{i}";
                configData.Add(itembox[i], character.item[i].itemcode);
            }
            if (character.equipArmor != null)
                configData.Add("equipArmor", character.equipArmor.itemcode);
            if (character.equipWeapon != null)
                configData.Add("equipWeapon", character.equipWeapon.itemcode);


            File.WriteAllText(path, configData.ToString());
        }

        static void LoadData(Character character)
        {            
            string path = @"C:\LocalSave\save.txt";
            using (StreamReader file = File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    Item list = new Item();                    
                    List<Item> shoplist = Item.itemsetting(list.shoplist);                    
                    JObject json = (JObject)JToken.ReadFrom(reader);
                    character.loadLevel((int)json["Level"]);
                    character.loadName(json["Name"].ToString());
                    character.loadJob(json["Job"].ToString());
                    character.loadAP((float)json["AttackPower"]);
                    character.loadDP((float)json["DefensePower"]);
                    character.loadHealth((float)json["Health"]);
                    character.loadHasgold((float)json["Hasgold"]);
                    int length = (int)json["Length"];
                    int[] itemlist = new int[length];
                    List<Item> realitem = new List<Item>();
                    for (int i =0; i < length; i++)
                    {                        
                        itemlist[i] = (int)json[$"Item{i}"];
                        for (int j=0; j< list.shoplist.Count; j++)
                        {
                            if (itemlist[i] == list.shoplist[j].itemcode)
                            {
                                realitem.Add(list.shoplist[j]);
                            }
                        }                        
                    }
                    character.item = realitem;                    
                    for (int i =0; i < realitem.Count; i++)
                    {
                        if (character.item[i].itemcode == (int)json["equipArmor"])
                            character.loadEA(character.item[i]);
                        else if (character.item[i].itemcode == ((int)json["equipWeapon"]))
                            character.loadEW(character.item[i]);
                    }                                        
                    character.loadEXP((int)json["Exp"]);                    
                }
            }
            Console.WriteLine("불러오기에 성공했습니다.");
            Console.ReadLine();
            getRest(character);            
        }
    }
}