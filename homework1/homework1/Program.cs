using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace homework1
{
    internal class Program
    {
        class Item
        {
            
            public string type { get; set; }
            public string name { get; set; }
            //public string jobconfine { get; private set; }
            public int attackPower { get; set; }
            public int defensePower { get; set; }
            public int price { get; set; }
            public string explain { get; set; }
            public int itemcode;

            public static List<Item> itemsetting() //배열로 바꾸는게 더 좋을거 같긴한데 손댈게 너무 많음
            {
                List<Item> shoplist = new List<Item>();
                //갑옷
                Item trainingArmor = new Item();
                trainingArmor.name = "수련자 갑옷";
                trainingArmor.type = "Armor";
                trainingArmor.defensePower = 5;
                trainingArmor.explain = "수련에 도움을 주는 갑옷입니다. ";
                trainingArmor.price = 1000;
                trainingArmor.itemcode = 1001;
                shoplist.Add(trainingArmor);
                Item metalArmor = new Item();
                metalArmor.name = "무쇠갑옷";
                metalArmor.type = "Armor";
                metalArmor.defensePower = 9;
                metalArmor.explain = "무쇠로 만들어져 튼튼한 갑옷입니다. ";
                metalArmor.price = 2000;
                metalArmor.itemcode = 1002;
                shoplist.Add(metalArmor);
                Item spartanArmor = new Item();
                spartanArmor.name = "스파르타의 갑옷";
                spartanArmor.type = "Armor";
                spartanArmor.defensePower = 15;
                spartanArmor.explain = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다. ";
                spartanArmor.price = 3500;
                spartanArmor.itemcode = 1003;
                shoplist.Add(spartanArmor);
                //무기
                Item oldSword = new Item();
                oldSword.name = "낡은 검";
                oldSword.type = "Weapon";
                oldSword.attackPower = 2;
                oldSword.explain = "쉽게 볼 수 있는 낡은 검 입니다. ";
                oldSword.price = 600;
                oldSword.itemcode = 2001;
                shoplist.Add(oldSword);
                Item bronzeAxe = new Item();
                bronzeAxe.name = "청동 도끼";
                bronzeAxe.type = "Weapon";
                bronzeAxe.attackPower = 5;
                bronzeAxe.explain = "어디선가 사용됐던거 같은 도끼입니다. ";
                bronzeAxe.price = 1500;
                bronzeAxe.itemcode = 2002;
                shoplist.Add(bronzeAxe);
                Item spartanSpear = new Item();
                spartanSpear.name = "스파르타의 창";
                spartanSpear.type = "Weapon";
                spartanSpear.attackPower = 7;
                spartanSpear.explain = "스파르타의 전사들이 사용했다는 전설의 창입니다. ";
                spartanSpear.price = 3000;
                spartanSpear.itemcode = 2003;
                shoplist.Add(spartanSpear);
                return shoplist;
            }
        }
        
        class Character
        {
            public int level { get; private set; }
            public string name { get; private set; }
            public string job { get; private set; }
            public int attackPower { get; private set; }
            public int defensePower { get; private set; }
            public int health { get; private set; }
            public int hasgold { get; private set; }
            public List<Item> item = new List<Item>();
            public List<int> equipItemCodes = new List<int>();
            public Item equipArmor { get; private set; }
            public Item equipWeapon { get; private set; }

            public Character()
            {
                attackPower = 10;
                defensePower = 5;
                health = 100;
                hasgold = 15000;
                setName();
                setJob();                
            }

            public void setGold(int price) 
            {
                hasgold += price;
            }

            public void setName()
            {
                Console.Write("먼저 이름을 정해주세요.");
                string nameinput = Console.ReadLine();
                name = nameinput;
                
            }
            public void setJob()
            {
                Console.WriteLine("직업을 선택해주세요.");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 궁수");
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
                attackPower = 10;                
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
            Console.WriteLine($"{character.name} ({character.job})");
            if (character.equipWeapon ==null) 
            {
                Console.WriteLine($"공격력 : {character.attackPower}");
            }
            else if(character.equipWeapon != null)
                Console.WriteLine($"공격력 : {character.attackPower+character.equipWeapon.attackPower} (+{character.equipWeapon.attackPower})");
            if (character.equipArmor == null)
                Console.WriteLine($"방어력 : {character.defensePower}");
            else if (character.equipArmor != null)
                Console.WriteLine($"방어력 : {character.defensePower+ character.equipArmor.defensePower} (+{character.equipArmor.defensePower})");
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
                        default: Console.WriteLine("올바른 숫자를 입력해주세요.");
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
                    switch(choice)
                    {
                        case 0:
                            askDo(character);
                            break;
                            case 1:
                            equipManagement(character);
                            break;
                        default: Console.WriteLine("올바른 숫자를 입력해주세요.");
                            viewInventory(character);
                            break;

                    }
                    break;
                default: Console.WriteLine("숫자를 입력해주세요.");
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
                if (character.equipWeapon == null && character.item[i].type =="Weapon")
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
                            if (character.item.Count == 0)
                                equipManagement(character);
                            else
                            {
                                if (character.item[choice - 1].type == "Weapon" && character.equipWeapon == null)
                                {
                                    character.EquipWeapon(character.item[choice - 1]);
                                }
                                else if (character.item[choice - 1].type == "Weapon" && character.equipWeapon != null && character.equipWeapon.itemcode == character.item[choice-1].itemcode)
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
            if(character.item.Count !=0)
                Console.WriteLine($"{character.item[0].name}");
            List<Item> shoplist = Item.itemsetting();
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
                for (int j=0; j <character.item.Count; j++)
                {
                    itemcodes.Add(character.item[j].itemcode);
                }
                if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
                if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");                
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
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
                        default: Console.WriteLine("올바른 숫자를 입력해주세요.");
                            shop(character);
                            break;
                    }
                    break;
            }
        }

        static void buyItem(Character character)
        {
            Console.Clear();
            List<Item> shoplist = Item.itemsetting();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
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
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Armor" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
                if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) != -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 공격력 +{shoplist[i].attackPower}    | {shoplist[i].explain}   | 구매 완료");
                else if (shoplist[i].type == "Weapon" && itemcodes.IndexOf(shoplist[i].itemcode) == -1)
                    Console.WriteLine($"- {i + 1} {shoplist[i].name}     | 방어력 +{shoplist[i].defensePower}    | {shoplist[i].explain}   | {shoplist[i].price}G");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string input = Console.ReadLine();
            int choice = 0;
            bool check = int.TryParse(input, out choice);
            switch(check) 
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
                            if (character.hasgold >= shoplist[choice - 1].price && itemcodes.IndexOf(shoplist[choice-1].itemcode) == -1)
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
                            else if (character.hasgold < shoplist[choice-1].price)
                            {
                                Console.WriteLine("Gold 가 부족합니다.");
                                Console.ReadLine();
                            }           
                            buyItem(character);
                            break;
                        default:
                            Console.WriteLine("올바른 숫자를 입력해주세요.");
                            break;
                    }
                    break;
                default: Console.WriteLine("숫자를 입력해주세요.");
                    break;

            }
        }
        
        
    }
}