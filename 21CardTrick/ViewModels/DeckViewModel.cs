using _21CardTrick.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _21CardTrick.ViewModels
{
    public class DeckViewModel : ViewModelBase
    {
        private Stack<CardViewModel> cardDeck;



        /// <summary>
        /// Contains all the cards in default order (Hearts, Diamonds, Spades, then Clubs).
        /// This data structure is used for the shuffle function.  This structure should not
        /// be used as the actual usable "Deck"
        /// </summary>
        private ObservableCollection<CardViewModel> unusableCards;

        /// <summary>
        /// Used observable collection to easily store the 21 cards and read them through the UI
        /// </summary>
        private ObservableCollection<CardViewModel> card21Deck = new ObservableCollection<CardViewModel>();
        /// <summary>
        /// Public access to the observable collection of cardviewmodels Card21Deck
        /// </summary>
        public ObservableCollection<CardViewModel> Card21Deck
        {
            get
            {
                return card21Deck;
            }

            set
            {
                card21Deck = value;
                OnPropertyChanged("Card21Deck");
            }
        }

        /// <summary>
        /// Constructor for deck view model. Uses a for loop to add items to the observable collection. It then shuffles the deck,
        /// displays it in the output window, and sets an array called random21 equal to the Random21 method that we called below
        /// so we now have access to the random 21 cards
        /// </summary>
        public DeckViewModel()
        {
            for (int i = 0; i < 13; i++)
            {
                Card21Deck.Add(new CardViewModel((FaceEnums)i, SuitesEnum.Hearts));
                Card21Deck.Add(new CardViewModel((FaceEnums)i, SuitesEnum.Diamonds));
                Card21Deck.Add(new CardViewModel((FaceEnums)i, SuitesEnum.Spades));
                Card21Deck.Add(new CardViewModel((FaceEnums)i, SuitesEnum.Clubs));
            }
            this.Shuffle(7);
            this.DEBUG_printDeck();
            CardViewModel[] random21 = this.Random21();
        }


        /// <summary>
        /// Shuffles the cards x amount of times
        /// </summary>
        public void Shuffle(int times)
        {
            // define a randomizer
            Random rand = new Random();
            for (int i = 0; i < times; i++)
            {
                // Copy the default deck
                List<CardViewModel> temp = this.Card21Deck.ToList();
                foreach (CardViewModel cvm in temp)
                {

                    this.Card21Deck.Move(temp.IndexOf(cvm), rand.Next(0, temp.Count()));
                }
            }
        }

        /// <summary>
        /// Shows the current output of cards in the output window for easy readability
        /// </summary>
        public void DEBUG_printDeck()
        {
            int index = 0;
            foreach (CardViewModel cvm in this.Card21Deck)
            {
                System.Console.WriteLine(string.Format("[{0}] {1} of {2}", index++, cvm.Face, cvm.Suite));
            }
        }

        /// <summary>
        /// Pulls the 21 cards we want. able to set a variable equal to this to store all 21 cards in a collection
        /// </summary>
        public CardViewModel[] Random21()
        {
            return this.Card21Deck.ToList().GetRange(0, 21).ToArray();
        }
    }
}
