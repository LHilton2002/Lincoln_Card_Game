using System;
using System.Collections.Generic;
using Lincoln_Card_Game.Modals;
namespace Lincoln_Card_Game
{
    class Program
    {
        static List<Card> Deck = new List<Card>();
        static List<Player> Players = new List<Player>();
        static List<int> isPlayerWin = new List<int>();
        static void Main(string[] args)
        {
            #region Initiallization_Process
            InitiallizeDeck();
            ShuffleDeck();
            IntiallizePlayers();
            #endregion

            //Get Player Name
            Console.Write("Welcome to the card game Lincoln \nHere are the values of each card with a different symbol \nJ = 11 , Q = 12 , K = 13, A = 14 \nTo Begin Playing, Please Enter Your Name : ");
            Players[1].Name = Console.ReadLine();

            #region Both Players Select 2 Cards to Play the Turn From their Cards. 
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("===========");
                Console.WriteLine("| Round " + (i + 1) + " |");
                Console.WriteLine("===========");
                Card C1 = GetRandomCardFromBotCards();
                Card C2 = GetRandomCardFromBotCards();
                Card P1, P2;
                Console.WriteLine("\nHere are the cards dealt for " + Players[1].Name + "") ;
                Console.WriteLine("==========================");
                Console.WriteLine("| {0,2} | {1,-8} | {2,6} |","ID","SUIT","NUMBER");
                for (int y = 0; y < Players[1].Cards.Count; y++)
                {
                    Console.WriteLine("| {0,2} | {1,-8} | {2,-6} |", y+1, Players[1].Cards[y].Shape, Players[1].Cards[y].Number);
                }
                Console.WriteLine("==========================");
            PlayerCard1:
                Console.Write("\nChoose Card 1 by Entering ID :");
                //Getting player's choice of card
                if (int.TryParse(Console.ReadLine(),out int index))
                {
                    if (index < 1 || index > Players[1].Cards.Count)
                    {
                        goto PlayerCard1;
                    }
                    P1 = Players[1].Cards[index - 1];
                    Players[1].Cards.RemoveAt(index - 1);
                }
                else
                {
                    goto PlayerCard1;
                }
                Console.WriteLine("\nDear " + Players[1].Name + " Your Cards \n");
                Console.WriteLine("==========================");
                Console.WriteLine("| {0,2} | {1,-8} | {2,6} |", "ID", "SUIT", "NUMBER");
                for (int y = 0; y < Players[1].Cards.Count; y++)
                {
                    Console.WriteLine("| {0,2} | {1,-8} | {2,-6} |", y + 1, Players[1].Cards[y].Shape, Players[1].Cards[y].Number);
                }
                Console.WriteLine("==========================");
            PlayerCard2:
                Console.Write("\nChoose Card 2 by Entering ID :");
                //Taking player's second card
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    if (index < 1 || index > Players[1].Cards.Count)
                    {
                        goto PlayerCard1;
                    }
                    P2 = Players[1].Cards[index - 1];
                    Players[1].Cards.RemoveAt(index - 1);
                }
                else
                {
                    goto PlayerCard1;
                }

                //Show Both Players Turn Played Cards.
                Console.WriteLine("==========================");
                Console.WriteLine("|   Computer Chooses     |");
                Console.WriteLine("==========================");
                Console.WriteLine("|   {0,8} | {1,6}    |", "SUIT", "NUMBER");
                Console.WriteLine("|   {0,8} | {1,-6}    |",C1.Shape, C1.Number);
                Console.WriteLine("|   {0,8} | {1,-6}    |", C2.Shape, C2.Number);
                Console.WriteLine("==========================");
                Console.WriteLine("|     You Choose         |");
                Console.WriteLine("==========================");
                Console.WriteLine("|   {0,8} | {1,6}    |", "SUIT", "NUMBER");
                Console.WriteLine("|   {0,8} | {1,-6}    |", P1.Shape, P1.Number);
                Console.WriteLine("|   {0,8} | {1,-6}    |", P2.Shape, P2.Number);
                Console.WriteLine("==========================");

                //Round Winner Decision
                if ((C1.Score + C2.Score) > (P1.Score + P2.Score))
                {
                    isPlayerWin.Add(-1);
		            Console.WriteLine("Computer Wins Round "+(i+1)+".\n");
                }
                else if ((C1.Score + C2.Score) == (P1.Score + P2.Score))
                {
                    isPlayerWin.Add(0);
                    Console.WriteLine("Round Draw.\n");
                }
                else
                {
                    isPlayerWin.Add(1);
		            Console.WriteLine(Players[1].Name+" Wins Round "+(i+1)+".\n");
                }
            }
            #endregion
            
            //Decision about Game Wining 
            int comCount = 0, yourCount = 0;
            foreach (int item in isPlayerWin)
            {
                if (item==1)
                {
                    yourCount++;
                }
                else if(item==-1)
                {
                    comCount++;
                }
            }
            if(comCount>yourCount)
            {
                Console.WriteLine("Computer Wins The Game.");
                return;
            }
            if (comCount < yourCount)
            {
                Console.WriteLine( Players[1].Name+" Wins The Game.");
                return;
            }
            int c, p;
            while((Deck.Count!=0)||(c = GetRandomCardFromDeck().Score)!=(p=GetRandomCardFromDeck().Score))
            {
                
            }
            if (c > p)
            {
                Console.WriteLine("Computer Win The Game.");
                return;
            }
            if (c < p)
            {
                Console.WriteLine(Players[1].Name + " Win The Game.");
                return;
            }
            Console.WriteLine("Game Draw.");
            return;
        }
        
        //implementing all card values
        static void InitiallizeDeck()
        {
            Deck.Add(new Card() { Number = "2", Shape = "Spades", Score = 2 });
            Deck.Add(new Card() { Number = "3", Shape = "Spades", Score = 3 });
            Deck.Add(new Card() { Number = "4", Shape = "Spades", Score = 4 });
            Deck.Add(new Card() { Number = "5", Shape = "Spades", Score = 5 });
            Deck.Add(new Card() { Number = "6", Shape = "Spades", Score = 6 });
            Deck.Add(new Card() { Number = "7", Shape = "Spades", Score = 7 });
            Deck.Add(new Card() { Number = "8", Shape = "Spades", Score = 8 });
            Deck.Add(new Card() { Number = "9", Shape = "Spades", Score = 9 });
            Deck.Add(new Card() { Number = "10", Shape = "Spades", Score = 10 });
            Deck.Add(new Card() { Number = "J", Shape = "Spades", Score = 11 });
            Deck.Add(new Card() { Number = "Q", Shape = "Spades", Score = 12 });
            Deck.Add(new Card() { Number = "K", Shape = "Spades", Score = 13 });
            Deck.Add(new Card() { Number = "A", Shape = "Spades", Score = 14 });

            Deck.Add(new Card() { Number = "2", Shape = "Diamonds", Score = 2 });
            Deck.Add(new Card() { Number = "3", Shape = "Diamonds", Score = 3 });
            Deck.Add(new Card() { Number = "4", Shape = "Diamonds", Score = 4 });
            Deck.Add(new Card() { Number = "5", Shape = "Diamonds", Score = 5 });
            Deck.Add(new Card() { Number = "6", Shape = "Diamonds", Score = 6 });
            Deck.Add(new Card() { Number = "7", Shape = "Diamonds", Score = 7 });
            Deck.Add(new Card() { Number = "8", Shape = "Diamonds", Score = 8 });
            Deck.Add(new Card() { Number = "9", Shape = "Diamonds", Score = 9 });
            Deck.Add(new Card() { Number = "10", Shape = "Diamonds", Score = 10 });
            Deck.Add(new Card() { Number = "J", Shape = "Diamonds", Score = 11 });
            Deck.Add(new Card() { Number = "Q", Shape = "Diamonds", Score = 12 });
            Deck.Add(new Card() { Number = "K", Shape = "Diamonds", Score = 13 });
            Deck.Add(new Card() { Number = "A", Shape = "Diamonds", Score = 14 });

            Deck.Add(new Card() { Number = "2", Shape = "Hearts", Score = 2 });
            Deck.Add(new Card() { Number = "3", Shape = "Hearts", Score = 3 });
            Deck.Add(new Card() { Number = "4", Shape = "Hearts", Score = 4 });
            Deck.Add(new Card() { Number = "5", Shape = "Hearts", Score = 5 });
            Deck.Add(new Card() { Number = "6", Shape = "Hearts", Score = 6 });
            Deck.Add(new Card() { Number = "7", Shape = "Hearts", Score = 7 });
            Deck.Add(new Card() { Number = "8", Shape = "Hearts", Score = 8 });
            Deck.Add(new Card() { Number = "9", Shape = "Hearts", Score = 9 });
            Deck.Add(new Card() { Number = "10", Shape = "Hearts", Score = 10 });
            Deck.Add(new Card() { Number = "J", Shape = "Hearts", Score = 11 });
            Deck.Add(new Card() { Number = "Q", Shape = "Hearts", Score = 12 });
            Deck.Add(new Card() { Number = "K", Shape = "Hearts", Score = 13 });
            Deck.Add(new Card() { Number = "A", Shape = "Hearts", Score = 14 });

            Deck.Add(new Card() { Number = "2", Shape = "Clubs", Score = 2 });
            Deck.Add(new Card() { Number = "3", Shape = "Clubs", Score = 3 });
            Deck.Add(new Card() { Number = "4", Shape = "Clubs", Score = 4 });
            Deck.Add(new Card() { Number = "5", Shape = "Clubs", Score = 5 });
            Deck.Add(new Card() { Number = "6", Shape = "Clubs", Score = 6 });
            Deck.Add(new Card() { Number = "7", Shape = "Clubs", Score = 7 });
            Deck.Add(new Card() { Number = "8", Shape = "Clubs", Score = 8 });
            Deck.Add(new Card() { Number = "9", Shape = "Clubs", Score = 9 });
            Deck.Add(new Card() { Number = "10", Shape = "Clubs", Score = 10 });
            Deck.Add(new Card() { Number = "J", Shape = "Clubs", Score = 11 });
            Deck.Add(new Card() { Number = "Q", Shape = "Clubs", Score = 12 });
            Deck.Add(new Card() { Number = "K", Shape = "Clubs", Score = 13 });
            Deck.Add(new Card() { Number = "A", Shape = "Clubs", Score = 14 });
        }
        static void IntiallizePlayers()
        {
            Players.Add(new Player() { Name = "Computer", Cards = new List<Card>() });
            Players.Add(new Player() { Name = "Player", Cards = new List<Card>() });
            for (int i = 0; i < 10; i++)
            {
                Players[0].Cards.Add(GetRandomCardFromDeck());
                Players[1].Cards.Add(GetRandomCardFromDeck());
            }
        }

        //shuffle
        static void ShuffleDeck()
        {
            for (int i = 0; i < Deck.Count - 1; i++)
            {
                Card temp = Deck[i];
                int random = new Random().Next(i, Deck.Count);
                Deck[i] = Deck[random];
                Deck[random] = temp;
            }
        }

        //get card
        static Card GetRandomCardFromDeck()
        {
            if (Deck.Count == 0)
                throw new Exception("Deck is Empty.");
            int i = new Random().Next(0, Deck.Count);
            Card card = Deck[i];
            Deck.RemoveAt(i);
            return card;
        }

        //get computer card
        static Card GetRandomCardFromBotCards()
        {
            if (Players[0].Cards.Count == 0)
                throw new Exception("Player Has No Cards left.");
            int i = new Random().Next(0, Players[0].Cards.Count);
            Card card = Players[0].Cards[i];
            Players[0].Cards.RemoveAt(i);
            return card;
        }
    }
}
