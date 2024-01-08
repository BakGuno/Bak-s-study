#define Test

using System.Xml.Linq;
using System.Runtime.Serialization;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.IO;
using System.Net.Http.Headers;


public enum Job{ 전사, 궁수 }
public enum itemType { 무기, 갑옷 }
public enum DungeonDiff { 쉬움, 보통, 어려운}

namespace homework1
{
    class Item
    {        
        public string name { get; }
        public itemType Type { get; }
        public Job Job { get; }        
        public int attackPower { get; }
        public int defensePower { get;}
        public int price { get; }
        public string explain { get; }
        public int itemcode { get; }        

        public Item(string Name, itemType type, Job job, int Atk,int Def,int Price,string Explain,int itemCode)
        {
            name = Name;
            Type = type;
            Job = job;
            attackPower = Atk;
            defensePower = Def;
            price = Price;
            explain = Explain;
            itemcode = itemCode;
        }
        
    }
    
    class Character
    {
        public int level { get; private set; }
        public string name { get; private set; }
        public Job job { get; private set; }
        public float attackPower { get; private set; }
        public float defensePower { get; private set; }
        public float health { get; private set; }
        public float hasgold { get; private set; }                
        public Item equipArmor { get; private set; }
        public Item equipWeapon { get; private set; }
        public int exp { get; private set; }

        public Character() //로드할 때 빈 틀만 생성하기 위한 생성자
        {

        }

        public Character(int Level,float Atk, float Def, float Health, float gold)
        {
            attackPower = Atk;
            defensePower = Def;
            health = Health;
            hasgold = gold;
            exp = 0;
            level = 1;           
        }

        public void levelup()
        {
            level++;
            attackPower += (level - 1) * 0.5f;
            defensePower += (level - 1) * 1;
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
                            job = Job.전사;
                            break;
                        case 2:
                            job = Job.궁수;
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
        public void loadJob(int Job)
        {
            switch (Job)
            {
                case 0:
                    job = global::Job.전사;
                    break;
                case 1:
                    job = global::Job.궁수;
                    break;
            }
                
            
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

    internal class Program
    {
        static Character _player;
        static List<Item> _playeritems;
        static List<Item> _shoplist;
        static bool isloaded =false;

        static void Main(string[] args)
        {
            PrintStartLogo();
            doLoad(); 
            
        }

        [Conditional("Test")]
        static void doLoad() //첫번째 플레이때는 넘어가야되니까, save가 없을때만 동작하도록 해보자. 굳
        {
            if (File.Exists(@"F:\Sparta\Github\Bak-s\homework1\LocalSave\save.txt"))
            {
                Console.Clear();
                Console.WriteLine("로드 하시겠습니까?");
                Console.WriteLine();
                Console.WriteLine("1. 네");
                Console.WriteLine("2. 아니오");
                Console.WriteLine(">>");
                Console.WriteLine();
                switch (CheckValidInput(1, 2))
                {
                    case 1:
                        isloaded = true;
                        GameDataSetting();
                        StartMenu();
                        break;
                    case 2:
                        GameDataSetting();
                        StartMenu();
                        break;
                }
            }
            else
                GameDataSetting();
                StartMenu();
            
        }

        static void StartMenu()
        {
            /// 구성
            /// 0. 화면 정리
            /// 1. 선택 멘트를 줌
            /// 2. 선택 결과값을 검증함
            /// 3. 선택 결과에 따라 메뉴로 보내줌
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();            
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            Console.WriteLine();


            //유저들이 착할때만 가능 
            switch (CheckValidInput(1, 5))
            {
                case 1:
                    playerInfo();
                    break;
                case 2:
                    viewInventory();
                    break;
                case 3:
                    shop();
                    break;
                case 4:
                    enterDungeon();
                    break;
                case 5:
                    getRest();
                    break;
            }
        }

        private static void ShowHighlithtesText(string Text)//글자색깔바꾸기
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Text);
            Console.ResetColor();
        }

        private static void PrintTextWithHighlighst(string s1, string s2, string s3 = "") //사이에 있는 텍스트 색깔 바꾸기
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        private static int CheckValidInput(int min, int max)
        {
            /// 설명
            /// 아래 두 가기 상황은 비정상 -> 재입력 수행
            /// (1) 숫자가 아닌 입력을 받은 경우
            /// (2) 숫자가 최소값 - 최대값의 범위를 넘는 경우
            int keyinput; // tryparse
            bool result; // while
            do //일단 한번 실행을 보장
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                result = int.TryParse(Console.ReadLine(), out keyinput);
            }
            while (result == false || CheckValid(keyinput, min, max) == false);

            // while 탈출 했다는 것은 제대로 입력을 받았다는 것
            return keyinput;
        }

        private static bool CheckValid(int keyinput, int min, int max)
        {
            if (min <= keyinput && keyinput <= max) return true;
            return false;
        }

        private static void PrintStartLogo()
        {
            //ASCII ART GENERATED BY https://textkool.com/en/ascii-art-generator?hl=default&vl=default&font=Red%20Phoenix&text=Enter%20the%0ADungeon
            Console.WriteLine("===============================================================================");
            Console.WriteLine("    //   / /                                                             ");
            Console.WriteLine("   //____      __    __  ___  ___      __       __  ___ / __      ___    ");
            Console.WriteLine("  / ____    //   ) )  / /   //___) ) //  ) )     / /   //   ) ) //___) ) ");
            Console.WriteLine(" //        //   / /  / /   //       //          / /   //   / / //        ");
            Console.WriteLine("//____/ / //   / /  / /   ((____   //          / /   //   / / ((____     ");
            Console.WriteLine();
            Console.WriteLine("    //    ) )                                                            ");
            Console.WriteLine("   //    / /            __      ___      ___      ___       __           ");
            Console.WriteLine("  //    / / //   / / //   ) ) //   ) ) //___) ) //   ) ) //   ) )        ");
            Console.WriteLine(" //    / / //   / / //   / / ((___/ / //       //   / / //   / /         ");
            Console.WriteLine("//____/ / ((___( ( //   / /   //__   ((____   ((___/ / //   / /                       ");
            Console.WriteLine("===============================================================================");
            Console.WriteLine("                            PRESS ANYKEY TO START                              ");
            Console.WriteLine("===============================================================================");
            Console.ReadKey();
        }


        private static void GameDataSetting()
        {
            Console.Clear();
            List<Item> shoplist = LoadItemData();                      

            _shoplist = shoplist.OrderBy(p => p.Job).ToList();

            if (isloaded == false)
            {
                _player = new Character(1, 10, 5, 100, 1500);
                _playeritems = new List<Item>();
                _player.setName();
                _player.setJob();
            }
            else
            {
                _player = new Character();
                _playeritems = new List<Item>();
                _player = LoadData(_player, _playeritems);
            }
        }
      
        static void playerInfo()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("상태 보기");
            Console.WriteLine("■■■■■■■■");
            PrintTextWithHighlighst("Lv. ", _player.level.ToString("00"));//ToString에 00을 넣으면 0이 삭제되지 않음
            Console.WriteLine();
            Console.WriteLine($"{_player.name} ({_player.job})");
            int bonusatk = (_player.equipWeapon ==null) ? 0 : _player.equipWeapon.attackPower;
            int bonusdef = (_player.equipArmor == null) ? 0 : _player.equipArmor.defensePower;
            PrintTextWithHighlighst("공격력 : ", (_player.attackPower + bonusatk).ToString(), bonusatk > 0 ? string.Format(" (+{0})", bonusatk) : "");
            PrintTextWithHighlighst("방어력 : ", (_player.defensePower + bonusdef).ToString(), bonusdef > 0 ? string.Format(" (+{0})", bonusdef) : "");
            PrintTextWithHighlighst("체력 : ", _player.health.ToString());
            Console.WriteLine($"소지금 : {_player.hasgold}");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            
            switch (CheckValidInput(0,0))
            {
                default:
                    StartMenu();
                    break;
            }
        }

        static void viewInventory()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("아이템 목록");
            Console.WriteLine("■■■■■■■■");
            Item isweapon = (_player.equipWeapon == null) ? null : _player.equipWeapon;
            Item isarmor = (_player.equipArmor == null) ? null : _player.equipArmor;
            for (int i = 0; i < _playeritems.Count; i++)
            {
                if (_playeritems[i].Type == itemType.무기)
                {
                    Console.WriteLine($"- {i + 1} {(isweapon == null ? "" : ((isweapon.itemcode == _playeritems[i].itemcode) ? "[E]" : "") )} {_playeritems[i].name}     | 공격력 +{_playeritems[i].attackPower}    | {_playeritems[i].explain}");
                }
               
                else if (_playeritems[i].Type == itemType.갑옷)
                {
                    Console.WriteLine($"- {i + 1} {(isarmor == null ? "" : ((isarmor.itemcode == _playeritems[i].itemcode) ? "[E]" : ""))} {_playeritems[i].name}     | 방어력 +{_playeritems[i].defensePower}    | {_playeritems[i].explain}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");           
            switch (CheckValidInput(0,1))
            {
               
                case 0:
                StartMenu();
                    break;
                case 1:
                    equipManagement();
                    break;
            }
        }

        static void equipManagement()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("장착 관리");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            
            Item isweapon = (_player.equipWeapon == null) ? null : _player.equipWeapon;
            Item isarmor = (_player.equipArmor == null) ? null : _player.equipArmor;
            for (int i = 0; i < _playeritems.Count; i++)
            {
                if (_playeritems[i].Type == itemType.무기)
                {
                    Console.WriteLine($"- {i + 1} {(isweapon == null ? "" : ((isweapon.itemcode == _playeritems[i].itemcode) ? "[E]" : ""))} {_playeritems[i].name}     | 공격력 +{_playeritems[i].attackPower}    | {_playeritems[i].explain}");
                }

                else if (_playeritems[i].Type == itemType.갑옷)
                {
                    Console.WriteLine($"- {i + 1} {(isarmor == null ? "" : ((isarmor.itemcode == _playeritems[i].itemcode) ? "[E]" : ""))} {_playeritems[i].name}     | 방어력 +{_playeritems[i].defensePower}    | {_playeritems[i].explain}");
                }
            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.WriteLine("0. 나가기");
            Console.Write(">> ");
            int choice = CheckValidInput(0, _playeritems.Count);
            switch (choice)
            {
                case 0:
                    viewInventory();
                    break;
                case int:
                    if (_playeritems.Count == 0)
                    {
                        Console.WriteLine("잘못된 선택입니다.");
                        viewInventory();
                    }                        
                    else if ((choice) <= _playeritems.Count && _playeritems.Count != 0)
                    {
                        if (_playeritems[choice - 1].Job == _player.job && _playeritems[choice - 1].Type == itemType.무기)
                        {
                            if (_player.equipWeapon != null && _player.equipWeapon.itemcode == _playeritems[choice - 1].itemcode)
                                _player.resetWeapon();
                            else                             
                                _player.EquipWeapon(_playeritems[choice - 1]);
                        }
                        else if (_playeritems[choice - 1].Job == _player.job && _playeritems[choice - 1].Type == itemType.갑옷)
                        {
                            if (_player.equipArmor != null && _player.equipArmor.itemcode == _playeritems[choice - 1].itemcode)
                                _player.resetArmor();
                            else 
                                _player.EquipArmor(_playeritems[choice - 1]);
                        }
                        else
                        {
                            Console.WriteLine("직업에 맞는 장비만 착용할 수 있습니다. ");
                            Console.ReadLine();
                            equipManagement();
                        }
                    }
                    else if (choice > _playeritems.Count)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadLine();
                        equipManagement();
                    }
                    equipManagement();
                    break;                
            } 
        }

        static void shop()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("상점");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.hasgold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");            
            int j = 1;
            foreach (Item i in _shoplist)
            {                
                if (i.Type == itemType.갑옷)
                    Console.WriteLine($"- {j++} [{i.Job}] {i.name}     | 방어력 +{i.defensePower}    | {i.explain}   | {(_playeritems.IndexOf(i) == -1 ? $"{i.price}" : "구매 완료")} ");
                if (i.Type == itemType.무기)
                    Console.WriteLine($"- {j++} [{i.Job}] {i.name}     | 공격력 +{i.defensePower}    | {i.explain}   | {(_playeritems.IndexOf(i) == -1 ? $"{i.price}" : "구매 완료")} ");
            }
            j = 1;
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
                            StartMenu();
                            break;
                        case 1:
                            buyItem();
                            break;
                        case 2:
                            sellItem();
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            shop();
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    shop();
                    break;
            }
        }

        static void buyItem()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("상점 - 아이템 구매");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("직업에 맞는 장비만 구입할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.hasgold}G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            int j = 1;
            foreach (Item i in _shoplist)
            {
                
                if (i.Type == itemType.갑옷)
                    Console.WriteLine($"- {j++} [{i.Job}] {i.name}     | 방어력 +{i.defensePower}    | {i.explain}   | {(_playeritems.IndexOf(i) == -1 ? $"{i.price}" : "구매 완료")} ");
                if (i.Type == itemType.무기)
                    Console.WriteLine($"- {j++} [{i.Job}] {i.name}     | 공격력 +{i.attackPower}    | {i.explain}   | {(_playeritems.IndexOf(i) == -1 ? $"{i.price}" : "구매 완료")} ");
            }
            j = 1;
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");            
            int choice = CheckValidInput(0,_shoplist.Count);
            switch (choice)
            {
                case 0:
                    Console.WriteLine("가게로 돌아갑니다.");
                    Console.ReadLine();
                    shop();
                    break;                        
                case int:
                    if (_player.job == _shoplist[choice - 1].Job)
                    {
                        if (_player.hasgold >= _shoplist[choice - 1].price && _playeritems.IndexOf(_shoplist[choice - 1]) == -1)
                        {
                            _playeritems.Add(_shoplist[choice - 1]);
                            _player.setGold(-_shoplist[choice - 1].price);
                            Console.WriteLine("구매를 완료했습니다.");
                            Console.ReadLine();
                        }
                        else if (_player.hasgold >= _shoplist[choice - 1].price && _playeritems.IndexOf(_shoplist[choice - 1]) != -1)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                            Console.ReadLine();
                        }
                        else if (_player.hasgold < _shoplist[choice - 1].price)
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
                    buyItem();
                    break;               
            }
                   
        }

        static void sellItem()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("상점 - 아이템 판매");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine("보유하고 계신 아이템을 판매할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{_player.hasgold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");            
            foreach (Item i in _playeritems)
            {
                int j = 1;
                if (i.Type == itemType.무기)
                {
                    Console.WriteLine($"- {j++} {(_player.equipWeapon ==  i ? "[E]" : "")} {i.name}    | 공격력 +{i.attackPower}    | {i.explain}    | {(int)(i.price * 85 / 100)}G");
                }
                if (i.Type == itemType.갑옷)
                    Console.WriteLine($"- {j++} {(_player.equipArmor == i ? "[E]" : "")} {i.name}    | 방어력 +{i.defensePower}    | {i.explain}    | {(int)(i.price * 85 / 100)}G");
            } 

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int sell = 0;  

            switch (sell)
            {
                case 0:
                    shop();
                    break;
                case int:
                    if (sell <= _playeritems.Count)
                    {
                        _player.setGold(_playeritems[sell - 1].price * 85 / 100);
                        if (_player.equipWeapon == _playeritems[sell - 1])
                            _player.resetWeapon();
                        else if (_player.equipArmor == _playeritems[sell - 1])
                            _player.resetArmor();
                        _playeritems.RemoveAt(sell - 1);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadLine();
                        sellItem();
                    }
                    sellItem();
                    break;
            }
                  
        }

        static void enterDungeon()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("던전 입장");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();            
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 쉬운 던전    | 방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전    | 방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전    | 방어력 17 이상 권장");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            
            float defense;
            int needDefense = 0;
            float offense;
            Random random = new Random();
            string[] proba = new string[100];
            for (int i = 0; i < 60; i++)
                proba[i] = "win";
            for (int i = 60; i < 100; i++)
                proba[i] = "lose";
            proba.OrderBy(x => random.Next()).ToArray();

            offense = (_player.equipWeapon == null) ? _player.attackPower : _player.attackPower + _player.equipWeapon.attackPower;
            defense = (_player.equipArmor == null) ? _player.defensePower : _player.defensePower + _player.equipArmor.defensePower;
            DungeonDiff diff = DungeonDiff.쉬움;
            switch (CheckValidInput(0,3))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    needDefense = 5;
                    diff = DungeonDiff.쉬움;
                    break;
                case 2:
                    needDefense = 11;
                    diff = DungeonDiff.보통;
                    break;
                case 3:
                    needDefense = 17;
                    diff = DungeonDiff.어려운;
                    break;
            }
                    
            float healthchange = new Random().Next(20, 35);
            float addGold = 0;
            float reinforce = 0;
            if (defense < needDefense)
            {
                if (proba[random.Next(0, 100)] == "win")
                {
                   _player.expup();
                    dungeonClear(diff, defense, offense, healthchange);
                }
                else
                    dungeonFail(healthchange);
            }
            else
            {
                reinforce = defense - needDefense;
                addGold = new Random().Next((int)offense, (int)offense * 2);
                _player.expup();
                dungeonClear(diff, defense, addGold, healthchange - reinforce);
            }

        }

        static void dungeonClear(DungeonDiff diff, float defense, float addgold, float healthchange)
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!");
            Console.WriteLine("■■■■■■■■");
            string Diff = "";
            int defaultGold = 0;
            float finalHealth = _player.health - healthchange;
            switch (diff)
            {
                case DungeonDiff.쉬움:
                    Diff = "쉬운";
                    defaultGold = 1000;
                    break;
                case DungeonDiff.보통:
                    Diff = "일반";
                    defaultGold = 1700;
                    break;
                case DungeonDiff.어려운:
                    Diff = "어려운";
                    defaultGold = 2500;
                    break;
            }
            Console.WriteLine($"{Diff} 던전을 클리어 하셨습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            if (finalHealth < 0)
                finalHealth = 0;
            Console.WriteLine($"체력 {_player.health} -> {finalHealth}");
            Console.WriteLine($"Gold {_player.hasgold} -> {_player.hasgold + defaultGold + (int)(defaultGold * addgold / 100)}");
            switch (_player.level)
            {
                case 1:
                    if (_player.exp == 1)
                    {
                        Console.WriteLine("축하합니다. Lv.2가 되었습니다!");
                        _player.levelup();
                    }
                    break;
                case 2:
                    if (_player.exp == 2)
                    {
                        Console.WriteLine("축하합니다. Lv.3가 되었습니다!");
                        _player.levelup();
                    }
                    break;
                case 3:
                    if (_player.exp == 3)
                    {
                        Console.WriteLine("축하합니다. Lv.4가 되었습니다!");
                        _player.levelup();
                    }
                    break;
                case 4:
                    if (_player.exp == 4)
                    {
                        Console.WriteLine("축하합니다. Lv.5가 되었습니다!");
                        _player.levelup();
                    }
                    break;

            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            
            switch (CheckValidInput(0,0))
            {
                case 0:
                    _player.setHealth(-healthchange);
                    _player.setGold(defaultGold + (int)(defaultGold * addgold / 100));
                    StartMenu();
                    break;                
            }
                  
        }

        static void dungeonFail(float healthchange)
        {
            Console.Clear();
            Console.WriteLine("던전 실패");
            Console.WriteLine("아쉽게도 던전 공략을 실패하셨습니다.");
            Console.WriteLine();
            float finalHealth = _player.health - healthchange / 2;
            if (finalHealth < 0)
                finalHealth = 0;
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {_player.health} -> {finalHealth}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");

            switch (CheckValidInput(0, 0))
            {
                case 0:
                    _player.setHealth(-(healthchange / 2));
                    StartMenu();
                    break;
            }   
        }

        static void getRest()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■");
            ShowHighlithtesText("여관");
            Console.WriteLine("■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {_player.hasgold} G");
            Console.WriteLine($"현재 체력 : {_player.health}");
            Console.WriteLine();
            Console.WriteLine("1. 휴식하기 & 저장하기");            
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");           
            
            switch (CheckValidInput(0,1))
            {
                case 0:
                    StartMenu();
                    break;
                case 1:
                    _player.setGold(-500);
                    _player.setHealth(100);
                    SaveData(_player,_playeritems);
                    Console.WriteLine("체력이 완전히 회복되었습니다. ");
                    Console.ReadLine();
                    getRest();
                    break;                
            }
                
        }


        static void SaveData(Character character, List<Item> items)
        {            
            string pathchar = CreateCharJson();
            string pathitem = CreateCharItemJson();

            int length = items.Count;
            string[] itembox = new string[length];

            //File.WriteAllText(@"F:\Sparta\Github\Bak-s\homework1\LocalSave\shoplist.txt", JsonConvert.SerializeObject(_shoplist));

            JObject configData = new JObject(
                new JProperty("Level", $"{character.level}"),
                new JProperty("Name", $"{character.name}"),
                new JProperty("Job", $"{(int)character.job}"),
                new JProperty("AttackPower", character.attackPower),
                new JProperty("DefensePower", character.defensePower),
                new JProperty("Health", character.health),
                new JProperty("Hasgold", character.hasgold),                
                new JProperty("Exp", character.exp),
                new JProperty("Length", length)
                );



            //for (int i = 0; i < length; i++)
            //{
            //    itembox[i] = $"Item{i}";
            //    configData.Add(itembox[i], items[i].itemcode);
            //}
            if (character.equipArmor != null)
            {
                configData.Add("equipArmor", character.equipArmor.itemcode);
                configData.Add("isequipArmor?", "yes");
            }
            else if (character.equipArmor == null)
                configData.Add("isequipArmor?", "no");
            if (character.equipWeapon != null)
            {
                configData.Add("equipWeapon", character.equipWeapon.itemcode);
                configData.Add("isequipWeapon?", "yes");
            }
            else if (character.equipWeapon == null)
                configData.Add("isequipWeapon?", "no");

            string saveItems = JsonConvert.SerializeObject(items);
            File.WriteAllText(pathchar, configData.ToString());
            File.WriteAllText(pathitem, saveItems);
        }

        static Character LoadData(Character character,List<Item> items)
        {
            string path = @"F:\Sparta\Github\Bak-s\homework1\LocalSave\save.txt";
            string pathitems = @"F:\Sparta\Github\Bak-s\homework1\LocalSave\saveCharItem.txt";
            using (StreamReader file = File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {

                    JObject json = (JObject)JToken.ReadFrom(reader);
                    character.loadLevel((int)json["Level"]);
                    character.loadName(json["Name"].ToString());
                    //ob job = Newtonsoft.Json.JsonConvert.DeserializeObject<Job>("Job");
                    character.loadJob((int)json["Job"]);
                    character.loadAP((float)json["AttackPower"]);
                    character.loadDP((float)json["DefensePower"]);
                    character.loadHealth((float)json["Health"]);
                    character.loadHasgold((float)json["Hasgold"]);

                    var obj = File.ReadAllText(pathitems);
                    var jsonString = JsonConvert.DeserializeObject<List<Item>>(obj);
                    _playeritems = jsonString;

                    //int length = (int)json["Length"];
                    //int[] itemlist = new int[length];
                    //List<Item> realitem = new List<Item>();
                    //for (int i = 0; i < length; i++)
                    //{
                    //    itemlist[i] = (int)json[$"Item{i}"];
                    //    for (int j = 0; j < _shoplist.Count; j++)
                    //    {
                    //        if (itemlist[i] == _shoplist[j].itemcode)
                    //        {
                    //            realitem.Add(_shoplist[j]);
                    //        }
                    //    }
                    //}
                    //_playeritems = realitem;
                    for (int i = 0; i < _playeritems.Count; i++)
                    {
                        if (json["isequipArmor?"].ToString() == "yes")
                        {
                            if ((_playeritems[i].itemcode == (int)json["equipArmor"]))
                                character.loadEA(_playeritems[i]);
                        }

                        if (json["isequipWeapon?"].ToString() == "yes")
                        {
                            if ((_playeritems[i].itemcode == (int)json["equipWeapon"]))
                                character.loadEW(_playeritems[i]);
                        }
                    }
                    character.loadEXP((int)json["Exp"]);
                }
            }
            
            Console.WriteLine("불러오기에 성공했습니다.");
            Console.ReadLine();
            StartMenu();
            return character;
        }

        private static List<Item> LoadItemData()
        {
            string path2 = @"F:\Sparta\Github\Bak-s\homework1\LocalSave\shoplist.txt";
            var obj = File.ReadAllText(path2);
            var jsonString = JsonConvert.DeserializeObject<List<Item>>(obj);
            return jsonString;
        }

        private static string CreateCharJson()
        {
            string path = @"F:\Sparta\Github\Bak-s\homework1\LocalSave\save.txt";

            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                   Console.WriteLine("파일 생성 성공");
                }
            }          

            return path;
        }

        private static string CreateCharItemJson()
        {
            string path = @"F:\Sparta\Github\Bak-s\homework1\LocalSave\saveCharItem.txt";

            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                    Console.WriteLine("파일 생성 성공");
                }
            }
            
            return path;
        }
    }
}