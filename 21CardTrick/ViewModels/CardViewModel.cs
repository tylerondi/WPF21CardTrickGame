using _21CardTrick.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _21CardTrick.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        /// <summary>
        /// Private reference to SuitesEnum suite
        /// </summary>
        private SuitesEnum suite;
        /// <summary>
        /// public reference to SuitesEnum suite
        /// </summary>
        public SuitesEnum Suite
        {
            get
            {
                return suite;
            }
            set
            {
                suite = value;
                //The OnPropertyChanged MUST contain the name of the public variable we created. I strongly recommend lower case for private,
                //and upper case for public.
                OnPropertyChanged("Suite");
            }
        }
        /// <summary>
        /// private reference to FaceEnums face
        /// </summary>
        private FaceEnums face;
        /// <summary>
        /// Public reference to FaceEnums Face
        /// </summary>
        public FaceEnums Face
        {
            get
            {
                return face;
            }
            set
            {
                face = value;
                //The OnPropertyChanged MUST contain the name of the public variable we created. I strongly recommend lower case for private,
                //and upper case for public.
                OnPropertyChanged("Face");
            }
        }
        /// <summary>
        /// private reference to picture string
        /// </summary>
        private string picture;
        /// <summary>
        /// public reference to picture string
        /// </summary>
        public string Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
                //The OnPropertyChanged MUST contain the name of the public variable we created. I strongly recommend lower case for private,
                //and upper case for public.
                OnPropertyChanged("Picture");
            }
        }


        //NO ARGS CONSTRUCTOR FOR THE MAINWINDOWVEIWMODEL
        public CardViewModel()
        { }
        /// <summary>
        /// Constructor that takes face and suite value and assigns it to the appropriate picture.
        /// </summary>
        /// <param name="face"></param>
        /// <param name="suite"></param>
        public CardViewModel(FaceEnums face, SuitesEnum suite)
        {
            this.Face = face;
            this.Suite = suite;

           
            //Switch that determines how to assign the enum values to the card we are passing in. This will take the input from the Deck class
            //And assign a file name using {0}, which pulls in c,h,s, or d respectively, and {1}, which pulls in the face value +1 to match
            //the file names

            switch (Suite)
            {
                case SuitesEnum.Clubs:
                    this.Picture = string.Format("Assets/{0}{1}.png", "c", (int)this.Face + 1);
                    break;
                case SuitesEnum.Hearts:
                    this.Picture = string.Format("Assets/{0}{1}.png", "h", (int)this.Face + 1);
                    break;
                case SuitesEnum.Spades:
                    this.Picture = string.Format("Assets/{0}{1}.png", "s", (int)this.Face + 1);
                    break;
                case SuitesEnum.Diamonds:
                    this.Picture = string.Format("Assets/{0}{1}.png", "d", (int)this.Face + 1);
                    break;
            }
        }
    }
}
