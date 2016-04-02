using _21CardTrick.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Media;

namespace _21CardTrick
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SoundPlayer player = new SoundPlayer("PokerCardShuffle.wav");
            player.Play();
            getViewModel().DealerVM.Deal();
            HideAllCards();
            LayDownCards(3000);
            GameText.IsReadOnly = true;
        }


        /// <summary>
        /// Method that makes it easy to access view model information
        /// </summary>
        /// <returns></returns>
        private MainWindowViewModel getViewModel()
        {
            return (MainWindowViewModel)this.DataContext;

        }

        private void StartClick(object sender, EventArgs e)
        {
            getViewModel().DealerVM.Deal();
        }

        private async void ClickColumn1(object sender, RoutedEventArgs e)
        {
            PickUpColumn2();
            await Task.Delay(500);
            PickUpColumn1();
            await Task.Delay(500);
            PickUpColumn3();
            await Task.Delay(500);
            MergeColumns();

            getViewModel().DealerVM.Deal(1);
            if (getViewModel().DealerVM.DealNumber < 4)
            {
                LayDownCards(500);
            }

        }

        private async void ClickColumn2(object sender, RoutedEventArgs e)
        {
            PickUpColumn1();
            await Task.Delay(500);
            PickUpColumn2();
            await Task.Delay(500);
            PickUpColumn3();
            await Task.Delay(500);
            MergeColumns();

            getViewModel().DealerVM.Deal(2);
            if (getViewModel().DealerVM.DealNumber < 4)
            {
                LayDownCards(500);
            }
        }

        private async void ClickColumn3(object sender, RoutedEventArgs e)
        {
            PickUpColumn2();
            await Task.Delay(500);
            PickUpColumn3();
            await Task.Delay(500);
            PickUpColumn1();
            await Task.Delay(500);
            MergeColumns();

            getViewModel().DealerVM.Deal(3);
            if (getViewModel().DealerVM.DealNumber < 4)
            {
                LayDownCards(500);
            }
        }

        private async void PickUpColumn1()
        {
            int timeToSlide = 50;

            SoundPlayer player = new SoundPlayer("cardTakeOutPackage1.wav");
            player.Play();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;

            col1Card1.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card1.Visibility = Visibility.Hidden;
            col1Card2.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card2.Visibility = Visibility.Hidden;
            col1Card3.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card3.Visibility = Visibility.Hidden;
            col1Card4.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card4.Visibility = Visibility.Hidden;
            col1Card5.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card5.Visibility = Visibility.Hidden;
            col1Card6.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col1Card6.Visibility = Visibility.Hidden;
            col1Card7.Visibility = Visibility.Hidden;
        }

        private async void PickUpColumn2()
        {
            int timeToSlide = 50;

            SoundPlayer player = new SoundPlayer("cardTakeOutPackage1.wav");
            player.Play();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;

            col2Card1.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card1.Visibility = Visibility.Hidden;
            col2Card2.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card2.Visibility = Visibility.Hidden;
            col2Card3.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card3.Visibility = Visibility.Hidden;
            col2Card4.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card4.Visibility = Visibility.Hidden;
            col2Card5.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card5.Visibility = Visibility.Hidden;
            col2Card6.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col2Card6.Visibility = Visibility.Hidden;
            col2Card7.Visibility = Visibility.Hidden;
        }

        private async void PickUpColumn3()
        {
            int timeToSlide = 50;

            SoundPlayer player = new SoundPlayer("cardTakeOutPackage1.wav");
            player.Play();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;

            col3Card1.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card1.Visibility = Visibility.Hidden;
            col3Card2.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card2.Visibility = Visibility.Hidden;
            col3Card3.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card3.Visibility = Visibility.Hidden;
            col3Card4.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card4.Visibility = Visibility.Hidden;
            col3Card5.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card5.Visibility = Visibility.Hidden;
            col3Card6.BeginAnimation(Canvas.TopProperty, animation);
            await Task.Delay(timeToSlide);
            col3Card6.Visibility = Visibility.Hidden;
            col3Card7.Visibility = Visibility.Hidden;
        }

        private async void LayDownCards(int pause)
        {
            int dealSoundTime = 200;
                      
            await Task.Delay(pause);

            showCard(col1Card1);
            await Task.Delay(dealSoundTime);
            showCard(col2Card1);
            await Task.Delay(dealSoundTime);
            showCard(col3Card1);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card2);
            await Task.Delay(dealSoundTime);
            showCard(col2Card2);
            await Task.Delay(dealSoundTime);
            showCard(col3Card2);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card3);
            await Task.Delay(dealSoundTime);
            showCard(col2Card3);
            await Task.Delay(dealSoundTime);
            showCard(col3Card3);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card4);
            await Task.Delay(dealSoundTime);
            showCard(col2Card4);
            await Task.Delay(dealSoundTime);
            showCard(col3Card4);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card5);
            await Task.Delay(dealSoundTime);
            showCard(col2Card5);
            await Task.Delay(dealSoundTime);
            showCard(col3Card5);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card6);
            await Task.Delay(dealSoundTime);
            showCard(col2Card6);
            await Task.Delay(dealSoundTime);
            showCard(col3Card6);
            await Task.Delay(dealSoundTime + 200);

            showCard(col1Card7);
            await Task.Delay(dealSoundTime);
            showCard(col2Card7);
            await Task.Delay(dealSoundTime);
            showCard(col3Card7);
            await Task.Delay(dealSoundTime + 200);
        }


        private async void GameText_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < 75; i++)
            {
                await Task.Delay(10);
                GameText.Margin = new Thickness(10, i, 0, 154 - i);
            }
        }

        private async void MergeColumns()
        {

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 450;
            animation.To = 200;

            col1Card7.BeginAnimation(Canvas.LeftProperty, animation);
            await Task.Delay(500);
            col3Card7.BeginAnimation(Canvas.RightProperty, animation);
        }

        private void HideAllCards()
        {
            col1Card1.Visibility = Visibility.Hidden;
            col2Card1.Visibility = Visibility.Hidden;
            col3Card1.Visibility = Visibility.Hidden;
            col1Card2.Visibility = Visibility.Hidden;
            col2Card2.Visibility = Visibility.Hidden;
            col3Card2.Visibility = Visibility.Hidden;
            col1Card3.Visibility = Visibility.Hidden;
            col2Card3.Visibility = Visibility.Hidden;
            col3Card3.Visibility = Visibility.Hidden;
            col1Card4.Visibility = Visibility.Hidden;
            col2Card4.Visibility = Visibility.Hidden;
            col3Card4.Visibility = Visibility.Hidden;
            col1Card5.Visibility = Visibility.Hidden;
            col2Card5.Visibility = Visibility.Hidden;
            col3Card5.Visibility = Visibility.Hidden;
            col1Card6.Visibility = Visibility.Hidden;
            col2Card6.Visibility = Visibility.Hidden;
            col3Card6.Visibility = Visibility.Hidden;
            col1Card7.Visibility = Visibility.Hidden;
            col2Card7.Visibility = Visibility.Hidden;
            col3Card7.Visibility = Visibility.Hidden; 
        }
        private void ShowAllCards()
        {
            col1Card1.Visibility = Visibility.Visible;            
            col2Card1.Visibility = Visibility.Visible;           
            col3Card1.Visibility = Visibility.Visible;          
            col1Card2.Visibility = Visibility.Visible;
            col2Card2.Visibility = Visibility.Visible;            
            col3Card2.Visibility = Visibility.Visible;          
            col1Card3.Visibility = Visibility.Visible;
            col2Card3.Visibility = Visibility.Visible;            
            col3Card3.Visibility = Visibility.Visible;           
            col1Card4.Visibility = Visibility.Visible;            
            col2Card4.Visibility = Visibility.Visible;           
            col3Card4.Visibility = Visibility.Visible;            
            col1Card5.Visibility = Visibility.Visible;           
            col2Card5.Visibility = Visibility.Visible;            
            col3Card5.Visibility = Visibility.Visible;            
            col1Card6.Visibility = Visibility.Visible;            
            col2Card6.Visibility = Visibility.Visible;            
            col3Card6.Visibility = Visibility.Visible;          
            col1Card7.Visibility = Visibility.Visible;        
            col2Card7.Visibility = Visibility.Visible;
            col3Card7.Visibility = Visibility.Visible;
        }

        private void showCard(Image c)
        {
            SoundPlayer player = new SoundPlayer("cardSlide5.wav");

            c.Visibility = Visibility.Visible;
            player.Play();
        }

    }
}
