using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21CardTrick.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// the card view model
        /// </summary>
        private CardViewModel cardVM = new CardViewModel();
        /// <summary>
        /// public reference to the card view model that controls how cardVM is updated
        /// </summary>
        public CardViewModel CardVM
        {
            get
            {
                return cardVM;
            }
            set
            {
                cardVM = value;
                OnPropertyChanged("CardVM");
            }
        }
        /// <summary>
        /// the dealer view model
        /// </summary>
        private DealerViewModel dealerVM = new DealerViewModel();
        /// <summary>
        /// public reference to the dealer view model that controls how dealerVM is updated
        /// </summary>
        public DealerViewModel DealerVM
        {
            get
            {
                return dealerVM;
            }
            set
            {
                dealerVM = value;
                OnPropertyChanged("DealerVM");
            }
        }
        /// <summary>
        /// the player view model
        /// </summary>
        private PlayerViewModel playerVM = new PlayerViewModel();
        /// <summary>
        /// public reference to the player view model that controls how playerVM is updated
        /// </summary>
        public PlayerViewModel PlayerVM
        {
            get
            {
                return playerVM;
            }
            set
            {
                playerVM = value;
                OnPropertyChanged("PlayerVM");
            }
        }
        /// <summary>
        /// the deck view model
        /// </summary>
        private DeckViewModel deckVM = new DeckViewModel();
        /// <summary>
        /// public reference to the deck view model that controls how deckVM is updated
        /// </summary>
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
    }
}
