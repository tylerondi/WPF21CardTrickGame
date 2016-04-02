using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _21CardTrick.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        private CardViewModel secretCard;
        public CardViewModel SecretCard
        {
            get
            {
                return secretCard;
            }
            set
            {
                secretCard = value;
                //The OnPropertyChanged MUST contain the name of the public variable we created. I strongly recommend lower case for private,
                //and upper case for public.
                OnPropertyChanged("SecretCard");
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public PlayerViewModel()
        {
            secretCard = new CardViewModel();
        }
        /// <summary>
        /// placeholder for indicateColumn method in player class
        /// </summary>
        public string IndicateColumn()
        {
            return "Please click the column button that your card is in.";
        }
        /// <summary>
        /// placeholder for pickCard method in player class
        /// </summary>
        public string PickCard()
        {
            return "Please click on a card to \"Pick\" it.";
        }
    }
}
