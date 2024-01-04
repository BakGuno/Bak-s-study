using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    internal class MakeRpg
    {
        static void Main(string[] args)
        {
            Stage stage = new Stage();
            Warrior warrior = new Warrior();

            while (true)
            {
                Monster mob = stage.Start();
                Console.WriteLine("플레이어 | 체력 : {0}, 공격력 : {1}", warrior.Health, warrior.Attack);
                Console.WriteLine();
                Console.WriteLine("{0} | 체력 : {1}, 공격력 : {2}", mob.Name,mob.Health,mob.Attack);
                Console.WriteLine();
                Console.WriteLine("계속 진행하시려면 아무 키나 누르세요") ;
                Console.WriteLine();
                Console.ReadKey(true);

                while (!warrior.IsDead && !mob.IsDead)
                {
                    stage.Battle(warrior, mob);
                    Thread.Sleep(1000);
                }

                if (warrior.IsDead)
                {
                    Console.WriteLine("플레이어는 죽고 말았습니다. {0}에게 말이죠.", mob.Name);
                    break;
                }

                stage.ChooseItem(warrior);
                Thread.Sleep(1000);
                Console.Clear();
            }
                
        }
    }

    interface ICharacter
    {
        string Name { get; set; }
        int Health { get; set; }
        int Attack { get; set; }
        bool IsDead { get; set; }
        void TakeDamage(int damage);        
    }

    interface IItem
    {
        string Name { get; set; }
        void use(Warrior warrior);
    }

    public class HealthPotion : IItem
    {
        public string Name { get; set; }

        public HealthPotion()
        {
            Name = "회복 물약";
        }

        public void use(Warrior warrior)
        {
            warrior.Health += 50;
            Console.WriteLine("회복 물약을 사용하셨습니다. (+50)");
        }
    }


    public class StrengthPotion : IItem
    {
        public string Name { get; set; }

        public StrengthPotion()
        {
            Name = "공격력 물약";
        }

        public void use(Warrior warrior)
        {
            warrior.Attack += 5;
            Console.WriteLine("공격력 물약을 사용하셨습니다. (+5)");
        }

    }

    public class Warrior : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }

        public Warrior()
        {
            Name = "플레이어";
            Health = 100;
            Attack = 20;
            IsDead = false;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                IsDead = true;
            }
        }
    }

    public class Monster : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public bool IsDead { get; set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                IsDead = true;
            }
        }
    }

    public class Goblin : Monster
    {
        public Goblin()
        {
            Name = "고블린";
            Health = 30;
            Attack = 5;
            IsDead = false;
        }
    }

    public class Dragon : Monster
    {
        public Dragon()
        {
            Name = "드래곤";
            Health = 200;
            Attack = 30;
            IsDead = false;
        }
    }


    public class Stage
    {                
        HealthPotion healthPotion = new HealthPotion();
        StrengthPotion strengthPotion = new StrengthPotion();        
        
        public int turn { get; private set; }
        public int stagecount { get; private set; }

        public Monster Start()
        {            
            stagecount++;
            Console.WriteLine("스테이지 {0} 시작", stagecount);
            Console.WriteLine();
            return SpawnMonster(stagecount); //몬스터를 반환
        }


        public Monster SpawnMonster(int stagecount) //스테이지카운트를 파라미터로 받고, 몬스터를 반환함.
        {            
            if (stagecount % 10 ==0) //10턴마다 드래곤(보스) 등장
            {
                Dragon dragon = new Dragon();
                Console.WriteLine("드래곤이 나타났다.");
                Console.WriteLine();
                return dragon;
            }
            else
            {
                Goblin goblin = new Goblin();
                Console.WriteLine("고블린이 나타났다.");
                Console.WriteLine();
                return goblin;
            }       
        }


        public void Battle(Warrior warrior,Monster monster) //전투 메서드
        {
            turn++; 
            if (turn %2 != 0)
            {
                Console.WriteLine("플레이어의 차례!");
                Console.WriteLine("플레이어가 {0}을 {1}의 데미지로 공격했다!",monster.Name,warrior.Attack);
                monster.TakeDamage(warrior.Attack);
                Console.WriteLine("{0}의 남은 체력 : {1}", monster.Name, monster.Health);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("{0}의 차례!",monster.Name);
                Console.WriteLine("{0}가 플레이어를 {1}의 데미지로 공격했다!", monster.Name, monster.Attack);
                warrior.TakeDamage(monster.Attack);
                Console.WriteLine("플레이어의 남은 체력 : {0}", warrior.Health);
                Console.WriteLine();
            }
        }


        public void ChooseItem(Warrior warrior) //전투에서 승리하면 나오는 메서드
        {
            turn = 0; //턴 초기화
            bool check = true; //1번 or 2번만 고르게하기

            while (check)
            {
                Console.WriteLine("전투에서 승리하셨습니다!");
                Console.WriteLine("보상을 선택해주세요. ");
                Console.WriteLine("1. 회복물약 (+50)   2. 공격력 물약 (+5) ");
                Console.WriteLine();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.NumPad1:
                        healthPotion.use(warrior);
                        check = false;
                        break;

                    case ConsoleKey.NumPad2:
                        strengthPotion.use(warrior);
                        check = false;
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }
            }
        }
    }
}
