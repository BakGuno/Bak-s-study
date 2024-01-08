//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp2
//{
//    public class Character
//    {
//        public string Name { get; }

//        public string Job { get; }

//        public int Level { get; }

//        public int Atk { get; }

//        public int Def { get; }

//        public int Hp { get; }

//        public int Gold { get; }

//        public Character(string name, string job, int level, int atk, int def, int hp, int gold) //생성자 : 생성할 때 이런 인스턴스 발생했으면 좋겠다.
//        {
//            Name = name;
//            Job = job;
//            Level = level;
//            Atk = atk;
//            Def = def;
//            Hp = hp;
//            Gold = gold;
//        }
//    }

//    public class Item
//    {
//        public string Name { get; }

//        public string Description { get; }

//        public int Type { get; }

//        public int Atk { get; }

//        public int Def { get; }

//        public int Hp { get; }

//        public bool IsEquipped { get; set; }

//        public static int ItemCnt = 0; //클래스에 공유되는 변수인 스태틱변수를 추가해주면 얘는 아이템이라는 클래스에 귀속된다. 스태틱 : 게임에 전반적으로 공유되는 변수


//        public Item(string name, string description, int type, int atk, int def, int hp, bool isEquipped = false)
//        {
//            Name = name;
//            Description = description;
//            Type = type;
//            Atk = atk;
//            Def = def;
//            Hp = hp;
//            IsEquipped = isEquipped;
//        }

//        public void PrintItemStatDescription(bool withNumber = false, int idx = 0) //프로그램에서 들어가서 퍼블릭
//        {
//            Console.Write("-");
//            if (withNumber)
//            {
//                Console.ForegroundColor = ConsoleColor.DarkMagenta;
//                Console.Write("{0} ", idx);
//                Console.ResetColor();
//            }
//            if (IsEquipped)
//            {
//                Console.Write("[");
//                Console.ForegroundColor = ConsoleColor.Cyan;
//                Console.Write("E");
//                Console.ResetColor();
//                Console.Write("]");
//                Console.WriteLine(PadRightForMixedText(Name, 9));
//            }
//            else Console.Write(PadRightForMixedText(Name, 12));
//            Console.Write(" | ");

//            //삼항연산자 ?앞에가 조건 [ 조건? 조건이 참이라면 : 조건이 거짓이라면]
//            if (Atk != 0) Console.Write($"Atk {(Atk >= 0 ? "+" : "")} {Atk}");
//            if (Def != 0) Console.Write($"Atk {(Def >= 0 ? "+" : "")} {Def}");
//            if (Hp != 0) Console.Write($"Atk {(Hp >= 0 ? "+" : "")} {Hp}");

//            Console.Write(" | ");

//            Console.WriteLine(Description);
//        }

//        public static int GetPrintableLength(string str)
//        {
//            int length = 0;
//            foreach (char c in str)
//            {
//                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
//                {
//                    length += 2; //한글과 같은 넓은 문제에 대해 길이를 2로 취급
//                }
//                else
//                {
//                    length += 1; //나머지 문자에 대해 길이를 1로 취급
//                }
//            }
//            return length;
//        }

//        public static string PadRightForMixedText(string str, int totalLength)
//        {
//            int currentLength = GetPrintableLength(str);
//            int padding = totalLength - currentLength;
//            return str.PadRight(str.Length + padding);
//        }


//    }

//    internal class repactoring
//    {
//        static Character _player;
//        static Item[] _items;

//        static void Main(string[] args)
//        {
//            ///구성
//            ///0. 데이터 초기화
//            ///1. 스타팅 로고를 보여줌 (게임 처음 킬때만 보여줌)
//            ///2. 선택 화면을 보여줌 (기본 구현 사항 - 상태/인벤토리)
//            ///3. 상태화면을 구현함 (필요 구현 요소 : 캐릭터, 아이템)
//            ///4. 인벤토리 화면 구현함
//            ///4-1. 장비장착 화면 구현
//            ///5. 선택 화면 확장
//            GameDataSetting();
//            //Character mycharcter = new Character(); //new라는 키워드를 통해 새로운 캐릭터를 메모리에 할당해라.
//            PrintStartLogo();
//            StartMenu();
//        }
//        static void StartMenu()
//        {
//            /// 구성
//            /// 0. 화면 정리
//            /// 1. 선택 멘트를 줌
//            /// 2. 선택 결과값을 검증함
//            /// 3. 선택 결과에 따라 메뉴로 보내줌
//            Console.Clear();
//            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
//            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
//            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
//            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
//            Console.WriteLine();
//            Console.WriteLine("1. 상태 보기");
//            Console.WriteLine("2. 인벤토리");
//            Console.WriteLine();

//            //유저들이 착할때만 가능 
//            switch (CheckValidInput(1, 2))
//            {
//                case 1:
//                    StatusMenu();
//                    break;
//                case 2:
//                    InventoryMenu();
//                    break;
//            }
//        }

//        private static void InventoryMenu()
//        {
//            Console.Clear();

//            ShowHighlithtesText("■ 인벤토리 ■");
//            Console.WriteLine("보유 중인 아에팀을 관리할 수 있습니다.");
//            Console.WriteLine();
//            Console.WriteLine("[아이템 목록]");

//            for (int i = 0; i < Item.ItemCnt; i++)
//            {
//                _items[i].PrintItemStatDescription();
//            }
//            Console.WriteLine();
//            Console.WriteLine("0. 나가기");
//            Console.WriteLine("1. 장착관리");
//            Console.WriteLine();
//            switch (CheckValidInput(0, 1))
//            {
//                case 0:
//                    StartMenu();
//                    break;
//                case 1:
//                    EquipMenu();
//                    break;
//            }
//        }

//        private static void EquipMenu()
//        {
//            Console.Clear();
//            ShowHighlithtesText("■ 인벤토리 - 장착 관리 ■");
//            Console.WriteLine("보유중인 아이템을 관리할 수 있습니다.");
//            Console.WriteLine();
//            Console.WriteLine("[아이템 목록]");
//            for (int i = 0; i < Item.ItemCnt; i++)
//            {
//                _items[i].PrintItemStatDescription(true, i + 1);
//            }
//            Console.WriteLine();
//            Console.WriteLine("0. 나가기");

//            int keyinput = CheckValidInput(0, Item.ItemCnt);

//            switch (keyinput)
//            {
//                case 0:
//                    InventoryMenu();
//                    break;
//                default:
//                    ToggleEquipStatus(keyinput - 1); //유저가 입력하는건 1,2,3 : 실제 배열은 0,1,2
//                    EquipMenu();
//                    break;
//            }
//        }

//        private static void ToggleEquipStatus(int idx)
//        {
//            _items[idx].IsEquipped = !_items[idx].IsEquipped; //이렇게 해주면 지금 상태의 반대로 됨 (bool형)
//        }

//        private static void StatusMenu()
//        {
//            Console.Clear();

//            ShowHighlithtesText("■ 상태 보기 ■");
//            Console.WriteLine("캐릭터의 정보가 표기됩니다.");

//            PrintTextWithHighlighst("Lv. ", _player.Level.ToString("00"));//ToString에 00을 넣으면 0이 삭제되지 않음
//            Console.WriteLine();
//            Console.WriteLine($"{_player.Name} ( {_player.Job} )");

//            int bonusAtk = getSumBonusAtk();
//            int bonusDef = getSumBonusDef();
//            int bonusHp = getSumBonusHp();
//            PrintTextWithHighlighst("공격력 : ", (_player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format(" (+{0})", bonusAtk) : "");
//            PrintTextWithHighlighst("방어력 : ", (_player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format(" (+{0})", bonusDef) : "");
//            PrintTextWithHighlighst("체력 : ", (_player.Hp + bonusHp).ToString(), bonusHp > 0 ? string.Format(" (+{0})", bonusHp) : "");
//            PrintTextWithHighlighst("골드 : ", _player.Gold.ToString());
//            Console.WriteLine();
//            Console.WriteLine("0. 뒤로가기");
//            Console.WriteLine();
//            switch (CheckValidInput(0, 0))
//            {
//                case 0:
//                    StartMenu();
//                    break;
//            }
//        }

//        private static int getSumBonusAtk()
//        {
//            int sum = 0;
//            for (int i = 0; i < Item.ItemCnt; i++)
//            {
//                if (_items[i].IsEquipped) sum += _items[i].Atk;
//            }
//            return sum;
//        }

//        private static int getSumBonusDef()
//        {
//            int sum = 0;
//            for (int i = 0; i < Item.ItemCnt; i++)
//            {
//                if (_items[i].IsEquipped) sum += _items[i].Def;
//            }
//            return sum;
//        }

//        private static int getSumBonusHp()
//        {
//            int sum = 0;
//            for (int i = 0; i < Item.ItemCnt; i++)
//            {
//                if (_items[i].IsEquipped) sum += _items[i].Hp;
//            }
//            return sum;
//        }

//        private static void ShowHighlithtesText(string Text)//글자색깔바꾸기
//        {
//            Console.ForegroundColor = ConsoleColor.Magenta;
//            Console.WriteLine(Text);
//            Console.ResetColor();
//        }

//        private static void PrintTextWithHighlighst(string s1, string s2, string s3 = "") //사이에 있는 텍스트 색깔 바꾸기
//        {
//            Console.Write(s1);
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.Write(s2);
//            Console.ResetColor();
//            Console.WriteLine(s3);
//        }

//        private static int CheckValidInput(int min, int max)
//        {
//            /// 설명
//            /// 아래 두 가기 상황은 비정상 -> 재입력 수행
//            /// (1) 숫자가 아닌 입력을 받은 경우
//            /// (2) 숫자가 최소값 - 최대값의 범위를 넘는 경우
//            int keyinput; // tryparse
//            bool result; // while
//            do //일단 한번 실행을 보장
//            {
//                Console.WriteLine("원하시는 행동을 입력해주세요.");
//                result = int.TryParse(Console.ReadLine(), out keyinput);
//            }
//            while (result == false || CheckValid(keyinput, min, max) == false);

//            // while 탈출 했다는 것은 제대로 입력을 받았다는 것
//            return keyinput;
//        }

//        private static bool CheckValid(int keyinput, int min, int max)
//        {
//            if (min <= keyinput && keyinput <= max) return true;
//            return false;
//        }

//        private static void PrintStartLogo()
//        {
//            //ASCII ART GENERATED BY https://textkool.com/en/ascii-art-generator?hl=default&vl=default&font=Red%20Phoenix&text=Enter%20the%0ADungeon
//            Console.WriteLine("===============================================================================");
//            Console.WriteLine("    //   / /                                                             ");
//            Console.WriteLine("   //____      __    __  ___  ___      __       __  ___ / __      ___    ");
//            Console.WriteLine("  / ____    //   ) )  / /   //___) ) //  ) )     / /   //   ) ) //___) ) ");
//            Console.WriteLine(" //        //   / /  / /   //       //          / /   //   / / //        ");
//            Console.WriteLine("//____/ / //   / /  / /   ((____   //          / /   //   / / ((____     ");
//            Console.WriteLine();
//            Console.WriteLine("    //    ) )                                                            ");
//            Console.WriteLine("   //    / /            __      ___      ___      ___       __           ");
//            Console.WriteLine("  //    / / //   / / //   ) ) //   ) ) //___) ) //   ) ) //   ) )        ");
//            Console.WriteLine(" //    / / //   / / //   / / ((___/ / //       //   / / //   / /         ");
//            Console.WriteLine("//____/ / ((___( ( //   / /   //__   ((____   ((___/ / //   / /                       ");
//            Console.WriteLine("===============================================================================");
//            Console.WriteLine("                            PRESS ANYKEY TO START                              ");
//            Console.WriteLine("===============================================================================");
//            Console.ReadKey();
//        }


//        private static void GameDataSetting()
//        {
//            _player = new Character("chad", "전사", 1, 10, 5, 100, 1500);
//            _items = new Item[10];
//            AddItem(new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 0, 5, 0));
//            AddItem(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검입니다.", 1, 2, 0, 0));
//        }

//        static void AddItem(Item item) //bool을 반환값으로 해서 아이템 추가에 성공하면 true, 실패하면 false를 반환해주는것도가능
//        {
//            if (Item.ItemCnt == 10) return;
//            _items[Item.ItemCnt] = item; //0개 -> 0번 인덱스 / 1개 -> 1번인덱스
//            Item.ItemCnt++;
//        }
//    }
//}
