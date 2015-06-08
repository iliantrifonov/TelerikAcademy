namespace Poker
{
    using System;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private int[] FindFaceFrequency(IHand hand)
        {
            int[] frequency = new int[14];
            for (int count = 0; count < hand.Cards.Count; count++)
            {
                int face = (int)hand.Cards[count].Face;
                frequency[face - 2]++;
            }

            return frequency;
        }

        private int FindMaxFaceFrequency(IHand hand)
        {
            int[] faceFrequency = this.FindFaceFrequency(hand);
            int maxFaceFrequency = 0;
            for (int count = 0; count < faceFrequency.Length; count++)
            {
                if (faceFrequency[count] > maxFaceFrequency)
                {
                    maxFaceFrequency = faceFrequency[count];
                }
            }

            return maxFaceFrequency;
        }

        public bool IsRow(IHand hand)
        {
            bool isRow = true;
            ICard[] orderedHand = ((Hand)hand).OrderHand();
            for (int count = 1; count < orderedHand.Length; count++)
            {
                if ((int)orderedHand[count - 1].Face + 1 != (int)orderedHand[count].Face)
                {
                    isRow = false;
                    break;
                }
            }

            return isRow;
        }

        public bool IsSameSuit(IHand hand)
        {
            bool isSameSuit = true;
            CardSuit firstCardSuit = hand.Cards[0].Suit;
            for (int count = 1; count < hand.Cards.Count; count++)
            {
                CardSuit nextCardSuit = hand.Cards[count].Suit;
                if (firstCardSuit != nextCardSuit)
                {
                    isSameSuit = false;
                    break;
                }
            }

            return isSameSuit;
        }

        public bool IsValidHand(IHand hand)
        {
            bool areDifferentCards = true;
            for (int count = 0; count < hand.Cards.Count - 1; count++)
            {
                ICard currentCard = hand.Cards[count];
                for (int position = count + 1; position < hand.Cards.Count; position++)
                {
                    ICard nextCard = hand.Cards[position];
                    if (currentCard.Face == nextCard.Face && currentCard.Suit == nextCard.Suit)
                    {
                        areDifferentCards = false;
                        break;
                    }
                }
            }

            bool isValidHand = areDifferentCards && (hand.Cards.Count == 5);
            return isValidHand;
        }

        public bool IsFlush(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);
            bool isSameSuit = this.IsSameSuit(hand);
            bool isRow = this.IsRow(hand);

            bool isFlush = isValidHand && isSameSuit && (maxFaceFrequency == 1) && !isRow;
            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);
            bool isSameSuit = this.IsSameSuit(hand);
            bool isRow = this.IsRow(hand);

            bool isStraight = isValidHand && isRow && (maxFaceFrequency == 1) && !isSameSuit;
            return isStraight;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);

            bool isFourOfAKind = isValidHand && (maxFaceFrequency == 4);
            return isFourOfAKind;
        }

        public bool IsStraightFlush(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);
            bool isSameSuit = this.IsSameSuit(hand);
            bool isRow = this.IsRow(hand);

            bool isStraightFlush = isValidHand && (maxFaceFrequency == 1) && isRow && isSameSuit;
            return isStraightFlush;
        }

        public bool IsFullHouse(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int[] faceFrequency = this.FindFaceFrequency(hand);
            bool isThree = false;
            bool isTwo = false;
            for (int count = 0; count < faceFrequency.Length; count++)
            {
                if (faceFrequency[count] == 2)
                {
                    isTwo = true;
                }

                if (faceFrequency[count] == 3)
                {
                    isThree = true;
                }
            }

            bool isFullHouse = isValidHand && isThree && isTwo;
            return isFullHouse;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool isFullHouse = this.IsFullHouse(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);

            bool isThreeOfAKind = isValidHand && !isFullHouse && (maxFaceFrequency == 3);
            return isThreeOfAKind;
        }

        public bool IsTwoPair(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int[] faceFrequency = this.FindFaceFrequency(hand);
            byte pair = 0;
            for (int count = 0; count < faceFrequency.Length; count++)
            {
                if (faceFrequency[count] == 2)
                {
                    pair++;
                }
            }

            bool isTwoPair = isValidHand && (pair == 2);
            return isTwoPair;
        }

        public bool IsOnePair(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            bool isTwoPair = this.IsTwoPair(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);

            bool isOnePair = isValidHand && !isTwoPair && (maxFaceFrequency == 2);
            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            bool isValidHand = this.IsValidHand(hand);
            int maxFaceFrequency = this.FindMaxFaceFrequency(hand);
            bool isSameSuit = this.IsSameSuit(hand);
            bool isRow = this.IsRow(hand);

            bool isHighCard = isValidHand && !isRow && !isSameSuit && (maxFaceFrequency == 1);
            return isHighCard;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException(
                    "One of the hands is invalid! You cannot compare invalid hands.");
            }

            Combination firstHandCombination = this.FindCombination(firstHand);
            Combination secondHandCombination = this.FindCombination(secondHand);
            int result = firstHandCombination.CompareTo(secondHandCombination);
            return result;
        }

        public Combination FindCombination(IHand hand)
        {
            Combination combination = Combination.HighCard;
            if (this.IsOnePair(hand))
            {
                combination = Combination.OnePair;
            }
            else if (this.IsTwoPair(hand))
            {
                combination = Combination.TwoPair;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                combination = Combination.ThreeOfAKind;
            }
            else if (this.IsStraight(hand))
            {
                combination = Combination.Straight;
            }
            else if (this.IsFlush(hand))
            {
                combination = Combination.Flush;
            }
            else if (this.IsFullHouse(hand))
            {
                combination = Combination.FullHouse;
            }
            else if (this.IsFourOfAKind(hand))
            {
                combination = Combination.FourOfAKind;
            }
            else if (this.IsStraightFlush(hand))
            {
                combination = Combination.StraightFlush;
            }

            return combination;
        }
    }
}