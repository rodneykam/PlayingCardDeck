using System;
using System.Collections.Generic;

namespace PlayingCardDeck
{public class Card
    {
        public enum enRank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
        public enum enSuit { Spades, Diamonds, Clubs, Hearts };

        private enRank m_rank { get; set; }
        private enSuit m_suit { get; set; }

        public Card(int iSuit, int iRank)
        {
            m_rank = (enRank)iRank;
            m_suit = (enSuit)iSuit;
        }

        public override string ToString()
        {
            string cardText = m_rank.ToString("f") + " of " + m_suit.ToString("f");
            return cardText;
        }
    }

    public class CardDeck
    {
        private List<Card> m_deck = new List<Card>();

        public CardDeck()
        {
            // 
            // Initialize Cards In Deck
            //
            for (int iSuit = 0; iSuit < 4; iSuit++)
            {
                for (int iRank = 0; iRank < 13; iRank++)
                {
                    var Card = new Card(iSuit, iRank);
                    m_deck.Add(Card);
                }
            }
        }

        private void RippleTheDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < 5000; i++)
            {
                int i1 = rand.Next(0, 51);
                int i2 = rand.Next(0, 51);
                var tempCard = m_deck[i1];
                m_deck[i1] = m_deck[i2];
                m_deck[i2] = tempCard;
            }
        }

        private void CutTheDeck()
        {
            Random rand = new Random();
            var newDeck = new List<Card>();

            int ways = 4;

            int cut = rand.Next(52/ways-6, 52/ways+6);

            int pos = 0;
            for (int i = 0; i < ways+1; i++)
            {
                for (; (pos < cut) && (pos < 52); pos++)
                {
                    newDeck.Add(m_deck[pos]);
                }
                cut += pos;
            }

            m_deck = newDeck;
        }

        public void Shuffle()
        {
            RippleTheDeck();
            RippleTheDeck();
            CutTheDeck();
            RippleTheDeck();
            RippleTheDeck();
            CutTheDeck();
            RippleTheDeck();
            RippleTheDeck();
            CutTheDeck();
        }

        public List<Card> GetDeck()
        {
            return m_deck;
        }
    }
}
