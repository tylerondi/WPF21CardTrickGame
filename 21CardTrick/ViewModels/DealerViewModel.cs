using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Media;

namespace _21CardTrick.ViewModels
{
    public class DealerViewModel : ViewModelBase
    {
        private String gameMessage;
        public String GameMessage
        {
            get
            {
                return gameMessage;
            }
            set
            {
                gameMessage = value;
                OnPropertyChanged("GameMessage");
            }
        }

        private String messageVisible;
        public String MessageVisible
        {
            get
            {
                return messageVisible;
            }
            set
            {
                messageVisible = value;
                OnPropertyChanged("MessageVisible");
            }
        }
        
        private String[] dealtCards;
        public String[] DealtCards
        {
            get
            {
                return dealtCards;
            }
            set
            {
                dealtCards = value;
                OnPropertyChanged("DealtCards");
            }
        }

        /// <summary>
        /// Used to keep track of whether the game board needs to be visible or hidden
        /// </summary>
        private string gameBoardVisible;
        public string GameBoardVisible
        {
            get
            {
                return gameBoardVisible;
            }
            set
            {
                gameBoardVisible = value;
                OnPropertyChanged("GameBoardVisible");
            }
        }

        /// <summary>
        /// Used to keep track of whether it is time to display the winning card or not
        /// </summary>
        private string displaySecretCard;
        public string DisplaySecretCard
        {
            get
            {
                return displaySecretCard;
            }
            set
            {
                displaySecretCard = value;
                OnPropertyChanged("DisplaySecretCard");
            }
        }
        /// <summary>
        /// This dealNumber variable keeps track of which deal we are on (1-3)
        /// </summary>
        private int dealNumber;
        public int DealNumber
        {
            get
            {
                return dealNumber;
            }
            set
            {
                dealNumber = value;
                OnPropertyChanged("DealNumber");
            }
        }
        /// <summary>
        /// This secretCardPic variable is the string for the found secret card's picture
        /// </summary>
        private string secretCardPic;
        public string SecretCardPic
        {
            get
            {
                return secretCardPic;
            }
            set
            {
                secretCardPic = value;
                OnPropertyChanged("SecretCardPic");
            }
        }
        /// <summary>
        /// A deck object that the dealer can use
        /// </summary>
        private DeckViewModel deckVM;
        public DeckViewModel DeckVM
        {
            get
            {
                return deckVM;
            }
            set
            {
                deckVM = value;
                OnPropertyChanged("DeckVM");
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public DealerViewModel()
        {
            dealNumber = 0;
            DeckVM = new DeckViewModel();
            dealtCards = new String[21];
            GameMessage = "Welcome to Wildcat 21!\n\nChoose a card in your head and click the column that it's in.";
        }
        /// <summary>
        /// Deal method
        /// </summary>
        public String[] Deal()
        {
            this.GameBoardVisible = "Visible";
            this.DisplaySecretCard = "Hidden";
            this.MessageVisible = "Visible";
            dealNumber++;
            String[] gameCards = new String[21];
            CardViewModel[] random21Cards = deckVM.Random21();
            for (int i = 0; i < 21; i++)
            {
                gameCards[i] = random21Cards[i].Picture;
            }
            DealtCards = gameCards;
            return gameCards;
        }
        /// <summary>
        /// Overloaded Deal method with last column picked argument
        /// </summary>
        public String[] Deal(int col)
        {
            GameMessage = "Click on the column your card is in.";
            String[] gameCards = dealtCards;
            String[] pickUpCards = new String[21];
            dealNumber++;
            // Pick up cards
            switch (col)
            {
                case 1:
                    // Card is in 1st column
                    // "Pick up" 2nd column first
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i] = gameCards[(i * 3) + 1];
                    }
                    // "Pick up" 1st column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 7] = gameCards[i * 3];
                    }
                    // "Pick up" 3rd column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 14] = gameCards[(i * 3) + 2];
                    }
                    break;
                case 2:
                    // Card is in 2nd column
                    // "Pick up" 1st column first
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i] = gameCards[i * 3];
                    }
                    // "Pick up" 2nd column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 7] = gameCards[(i * 3) + 1];
                    }
                    // "Pick up" 3rd column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 14] = gameCards[(i * 3) + 2];
                    }
                    break;
                case 3:
                    // Card is in 3rd column
                    // "Pick up" 2nd column first
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i] = gameCards[(i * 3) + 1];
                    }
                    // "Pick up" 3rd column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 7] = gameCards[(i * 3) + 2];
                    }
                    // "Pick up" 1st column next
                    for (int i = 0; i < 7; i++)
                    {
                        pickUpCards[i + 14] = gameCards[i * 3];
                    }
                    break;
                default:
                    // Invalid selection
                    break;
            }
            if (dealNumber == 4)
            {
                              
                this.SecretCardPic= pickUpCards[10].ToString();
                
                RevealCard();
                //Re-enable the below line of code if you want to shut down the application after we reveal the secret card.
                //Application.Current.Shutdown();
            }
            DealtCards = pickUpCards;
            return pickUpCards;
        }
        /// <summary>
        /// Reveal card method
        /// </summary>
        public String RevealCard()
        {
            if (dealNumber == 4)
            {
                //Hides the game board so we can simulate the winning card
                this.GameBoardVisible = "Hidden";
                //Displays the winning card on the screen.
                this.DisplaySecretCard = "Visible";
                this.MessageVisible = "Visible";
                
                GameMessage = "Was this your card?";
                SoundPlayer player = new SoundPlayer("TaDa.wav");
                player.Play();
                
                return SecretCardPic;
            }
            else
            {
                return "You didn't deal enough to know...";
            }
        }
    }
}