using System;
using System.Collections.Generic;
using System.Numerics;

public enum Suit { Hearts, Diamonds, Clubs, Spades }
public enum Rank { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace }

// 카드 한 장을 표현하는 클래스
public class Card
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit s, Rank r)
    {
        Suit = s;
        Rank = r;
    }

    public int GetValue()
    {
        if ((int)Rank <= 10)
        {
            return (int)Rank;
        }
        else if ((int)Rank <= 13)
        {
            return 10;
        }
        else
        {
            return 11;
        }
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}

// 덱을 표현하는 클래스
public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();

        foreach (Suit s in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank r in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(s, r));
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        Random rand = new Random();

        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(i, cards.Count);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}

// 패를 표현하는 클래스
public class Hand
{
    private List<Card> cards;

    public Hand()
    {
        cards = new List<Card>();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetTotalValue()
    {
        int total = 0;
        int aceCount = 0;

        foreach (Card card in cards)
        {
            if (card.Rank == Rank.Ace)
            {
                aceCount++;
            }
            total += card.GetValue();
        }

        while (total > 21 && aceCount > 0)
        {
            total -= 10;
            aceCount--;
        }

        return total;
    }
}

// 플레이어를 표현하는 클래스
public class Player
{
    public Hand Hand { get; private set; }

    public Player()
    {
        Hand = new Hand();
    }

    public Card DrawCardFromDeck(Deck deck)
    {
        Card drawnCard = deck.DrawCard();
        Hand.AddCard(drawnCard);
        return drawnCard;
    }
}

// 여기부터는 학습자가 작성
// 딜러 클래스를 작성하고, 딜러의 행동 로직을 구현하세요.
public class Dealer : Player
{
    public int minValue = 17;
    public bool draw = true;
    // 코드를 여기에 작성하세요    
}

// 블랙잭 게임을 구현하세요. 
public class Blackjack
{
    // 코드를 여기에 작성하세요    
    public void startDraw(Player player, Dealer dealer, Deck deck)
    {
        
        Console.WriteLine($"플레이어의 카드는 {player.DrawCardFromDeck(deck)} , {player.DrawCardFromDeck(deck)}입니다.");
        dealer.DrawCardFromDeck(deck);        
        dealer.DrawCardFromDeck(deck);
    }
}



class Program
{
    static void Main(string[] args)
    {
        bool drawCard = true;
        bool gamecheck = true;
        Deck deck = new Deck();
        Blackjack black = new Blackjack();
        Player player = new Player();
        Dealer dealer = new Dealer();
        black.startDraw(player, dealer, deck);
        Console.WriteLine($"Player의 카드 합은 {player.Hand.GetTotalValue()}입니다.");
        Console.WriteLine($"Dealer의 카드 합은 {dealer.Hand.GetTotalValue()}입니다.");
        // 블랙잭 게임을 실행하세요
        while (gamecheck)
        {            
            
            Console.WriteLine("더 뽑으시겠습니까?  y/n");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    Console.WriteLine($"뽑으신 카드는 {player.DrawCardFromDeck(deck).ToString()}입니다. 총합은 {player.Hand.GetTotalValue()}입니다.");                    
                    break;
                case ConsoleKey.N:
                    drawCard = false;
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
            if (dealer.Hand.GetTotalValue() <= dealer.minValue)
            {
                Console.WriteLine("딜러의 차례입니다.");
                dealer.DrawCardFromDeck(deck);
                Console.WriteLine($"딜러의 총합은 {dealer.Hand.GetTotalValue()}");
                if (dealer.Hand.GetTotalValue() > dealer.minValue)
                    dealer.draw = false;
            }
            else
                dealer.draw = false;
           
            if (drawCard == false && dealer.draw==false)
            {
                gamecheck = false;
                if (player.Hand.GetTotalValue() <= 21 && dealer.Hand.GetTotalValue() <= 21)
                {
                    if (dealer.Hand.GetTotalValue() > player.Hand.GetTotalValue())
                    {
                        Console.WriteLine("딜러의 승리입니다.");
                    }
                    else if (dealer.Hand.GetTotalValue() < player.Hand.GetTotalValue())
                        Console.WriteLine("플레이어의 승리입니다.");
                    else
                        Console.WriteLine("무승부입니다.");
                }
                else if (player.Hand.GetTotalValue() > 21 && dealer.Hand.GetTotalValue() <= 21)
                    Console.WriteLine("21점이 넘었습니다. 딜러의 승리입니다.");

                else if (dealer.Hand.GetTotalValue() > 21 && player.Hand.GetTotalValue() <= 21)
                    Console.WriteLine("딜러의 총합이 21이 넘었습니다. 플레이어의 승리입니다.");
                else
                    Console.WriteLine("무승부입니다.");                
            }   
        }
    }
}