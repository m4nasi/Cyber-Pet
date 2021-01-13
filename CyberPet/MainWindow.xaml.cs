using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExperimentCyberPet
{
    class Kitchen
    {
        //setting up the objects of the cards - has different attributes: name, strength, intelligence, powers, agility, Top Trump rating
        //gets and sets values of each attribute
        public string Food { get; set; }

        public Kitchen(string food)
        {
            Food = food;
        }
    }

    class Stats
    {
        //creating a class for my pets so I can create multiple instances of my cards by only having one template
        //setting up the objects of the pets - has different attributes: health, happiness, bordom, hunger, sleep
        //gets and sets values of each attribute
        public int Health { get; set; }
        public int Happiness { get; set; }
        public int Bordom { get; set; }
        public int Hunger { get; set; }
        public int Sleep { get; set; }

        //creates the contructor for the class and creates each variable
        public Stats(int health, int happiness, int bordom, int hunger, int sleep)
        {
            //takes the setted vaule which are setted at the start of the program
            Health = health;
            Happiness = happiness;
            Bordom = bordom;
            Hunger = hunger;
            Sleep = sleep;
        }
        //methods
        /*
        public void Eat()
        {
            Hunger = Hunger - 15;
            Happiness = Happiness + 10;
            Health = (Hunger + Happiness + Bordom + Sleep) / 4;
        }

        public void sleep()
        {
            Sleep = Sleep - 50;
            Hunger = Hunger + 20;
            Happiness = Happiness + 15;
            Health = (Hunger + Happiness + Bordom + Sleep) / 4;
        }
        */
    }

    //initilize the main window of the cyber pet program
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void TimerEat()
        {
            for (Hunger.Value = 100;
                Hunger.Value > 0;)
            {
                await Task.Delay(1);
                Hunger.Value = pet.Hunger;
                if (Hunger.Value <= 10)
                {
                    alive = false;
                }
            }
        }

        private async void TimerHappiness()
        {
            while (Happiness.Value < 100 && Happiness.Value > 0) ;
            {
                await Task.Delay(1);
                Happiness.Value = pet.Happiness;
                if (Happiness.Value <= 10)
                {
                    alive = false;
                }
            }
        }

        private async void TimerSleep()
        {
            for (Sleep.Value = 100;
                Sleep.Value > 0;)
            {
                await Task.Delay(1);
                Sleep.Value = pet.Sleep;
                if (Sleep.Value <= 10)
                {
                    alive = false;
                }
            }
        }

        private async void TimerBordom()
        {
            for (Bordom.Value = 100;
                Bordom.Value > 0;)
            {
                await Task.Delay(1);
                Bordom.Value = pet.Bordom;
                if (Bordom.Value <= 10)
                {
                    alive = false;
                }
            }
        }
        //on this button the timer is started for the progress bars 
        private void ButtonStart_OnClick(object sender,
            RoutedEventArgs e)
        {
            //ButtonStart.Visibility = Visibility.Hidden;
            TimerEat();
            TimerHappiness();
            TimerBordom();
            TimerSleep();
        }

        //creates a new instance of the pets class - starts 
        Stats pet = new Stats(50, 50, 50, 50, 50);
        bool alive = true;

        /*
        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> i)
        {
            //creates an instance of a stopwatch to lower the values of the progress bars 
            var watch = new Stopwatch();
            watch.Start();
            //contines to increase the timer as the progress bars are not equal to zero
            while (alive == true)
            {
                //makes the watch go over a certain time
                TimeSpan time = watch.Elapsed;
                if ((time.TotalMilliseconds < 6000 && time.TotalMilliseconds > 5000) || time.TotalMilliseconds == 5000)
                {
                    //manipulates the initial pet class - decreases every second unless you do an activity
                    pet.Bordom = pet.Bordom - 50;
                    pet.Happiness = pet.Happiness - 5;
                    pet.Hunger = pet.Hunger - 5;
                    pet.Sleep = pet.Sleep - 5;
                    //creates an average of all the stats
                    pet.Health = (pet.Bordom + pet.Happiness + pet.Hunger + pet.Sleep) / 4;

                    //checks if the health is too low - if it is then the program will close
                    if (pet.Health < 5)
                    {
                        //allows to fall out the loop and be pronounced dead
                        alive = false;
                    }

                    else
                    {
                        //refreshes the progress bar to the value of the class
                        Hunger.Value = pet.Hunger;
                        Bordom.Value = pet.Bordom;
                        Health.Value = pet.Health;
                        Sleep.Value = pet.Sleep;
                        Happiness.Value = pet.Happiness;
                    }
                    watch.Restart();
                }
            }
        }
        */
        //tic tac toe logic
        public void CheckWin(object sender, RoutedEventArgs e)
        {
            //checks if a certain box has been clicked and replaces it with a tic tac toe character
            //flag catches if there has been 3 in a row - sees every 3 box rows
            int flag = 0;
            if ((TopXLeft.Content) == (TopXMiddle.Content) && (TopXMiddle.Content) == TopXRight.Content)
            {
                flag = 1;
            }
            else if (CenterXLeft.Content == CenterXMiddle.Content && CenterXMiddle.Content == CenterXRight.Content)
            {
                flag = 1;
            }
            else if (BottomXLeft.Content == BottomXMiddle.Content && BottomXMiddle.Content == BottomXRight.Content)
            {
                flag = 1;
            }
            else if (TopXLeft.Content == CenterXLeft.Content && CenterXLeft.Content == BottomXLeft.Content)
            {
                flag = 1;
            }
            else if (TopXMiddle.Content == CenterXMiddle.Content && CenterXMiddle.Content == BottomXMiddle.Content)
            {
                flag = 1;
            }
            else if (TopXRight.Content == CenterXRight.Content && CenterXRight.Content == BottomXRight.Content)
            {
                flag = 1;
            }
            else if (TopXLeft.Content == CenterXMiddle.Content && CenterXMiddle.Content == BottomXRight.Content)
            {
                flag = 1;
            }
            else if (TopXRight.Content == CenterXMiddle.Content && CenterXMiddle.Content == BottomXLeft.Content)
            {
                flag = 1;
            }
            /*
            else if (TopXLeft.Content != '1' && TopXRight.Content != '2' && arr[3] != '3' && arr[4] != '4' && CenterXMiddle.Content != '5' && CenterXRight.Content != '6' && BottomXLeft.Content != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            */
            else
            {
                flag = 0;
            }
        }

        private void Main(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //int[] SqrNum = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            int player = 1;
            int flag = 0;
            //starts a stopwatch and as the user reacts to the game it increases the stats of their pet
            var watch = new Stopwatch();
            TimeSpan time = watch.Elapsed;
            //increases the stats as the user interacts with the grid
            do
            {
                pet.Bordom = pet.Bordom + 10;
                Bordom.Value = pet.Bordom;
                pet.Health = (pet.Bordom + pet.Happiness + pet.Hunger + pet.Sleep) / 4;
                pet.Happiness = pet.Happiness + 10;
                Happiness.Value = pet.Happiness;
                //flag = CheckWin();
            } while (flag != 1 && flag != -1);
        }

        //changes the value of the boxes to a tic tac toe character
        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            TopXLeft.Content = "X";
        }

        private void ButtonClicked2(object sender, RoutedEventArgs e)
        {
            TopXMiddle.Content = "X";
        }

        private void ButtonClicked3(object sender, RoutedEventArgs e)
        {
            TopXRight.Content = "X";
        }
        private void ButtonClicked4(object sender, RoutedEventArgs e)
        {
            CenterXLeft.Content = "X";
        }
        private void ButtonClicked5(object sender, RoutedEventArgs e)
        {
            CenterXMiddle.Content = "X";
        }
        private void ButtonClicked6(object sender, RoutedEventArgs e)
        {
            CenterXRight.Content = "X";
        }
        private void ButtonClicked7(object sender, RoutedEventArgs e)
        {
            BottomXLeft.Content = "X";
        }
        private void ButtonClicked8(object sender, RoutedEventArgs e)
        {
            BottomXMiddle.Content = "X";
        }
        private void ButtonClicked9(object sender, RoutedEventArgs e)
        {
            BottomXRight.Content = "X";
        }
        //resets the buttons values so the user can play again
        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            TopXLeft.Content = "1";
            TopXMiddle.Content = "2";
            TopXRight.Content = "3";
            CenterXLeft.Content = "4";
            CenterXMiddle.Content = "5";
            CenterXRight.Content = "6";
            BottomXLeft.Content = "7";
            BottomXMiddle.Content = "8";
            BottomXRight.Content = "9";
        }

        //kitchen logic 
        //starts off with 100 coins which they can spend
        int totalCoins = 100;
        List<string> Basket = new List<string>();
        //as the button is pressed the coins are reduced by the item and the allowance is reduced
        private async void kitButtonClicked(object sender, RoutedEventArgs e)
        {
            TopXLeft1.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Apple");
            for(int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked2(object sender, RoutedEventArgs e)
        {
            TopXFirstMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Pizza");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }

        }
        private async void kitButtonClicked3(object sender, RoutedEventArgs e)
        {
            TopXSecondMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Orange");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked4(object sender, RoutedEventArgs e)
        {
            TopXRight1.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Noodles");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked5(object sender, RoutedEventArgs e)
        {
            SecondXLeft.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Cake");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked6(object sender, RoutedEventArgs e)
        {
            SecondXFirstMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Chips");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private async void kitButtonClicked7(object sender, RoutedEventArgs e)
        {
            SecondXSecondMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Toast");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private async void kitButtonClicked8(object sender, RoutedEventArgs e)
        {
            SecondXRight.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Dumplings");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked9(object sender, RoutedEventArgs e)
        {
            ThirdXLeft.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Rice");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked10(object sender, RoutedEventArgs e)
        {
            ThirdXFirstMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Curry");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private async void kitButtonClicked11(object sender, RoutedEventArgs e)
        {
            ThirdXSecondMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Mango");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private async void kitButtonClicked12(object sender, RoutedEventArgs e)
        {
            ThirdXRight1.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Pastry");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private async void kitButtonClicked13(object sender, RoutedEventArgs e)
        {
            LastXLeft.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Avocado");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private async void kitButtonClicked14(object sender, RoutedEventArgs e)
        {
            LastXFirstMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Macoroni");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private void kitButtonClicked15(object sender, RoutedEventArgs e)
        {
            LastXSecondMiddle.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Coffee");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }
        private void kitButtonClicked16(object sender, RoutedEventArgs e)
        {
            LastXRight.Content = "X";
            totalCoins = totalCoins - 10;
            totalCoin.Text = Convert.ToString(totalCoins);
            Kitchen food = new Kitchen("Hot Chocolate");
            for (int i = 0; i < Basket.Count - 1; i++)
            {
                basket_text.Text = Basket[i];
            }
        }

        private void kitRestart_Click(object sender, RoutedEventArgs e)
        {
            if (totalCoins != 0)
            {
                //sends a confirmation to show the user that they have purchased the item
                checkout.Text = "That's gone through!";
            }

        }

        private void ButtonClickedSleep(object sender, RoutedEventArgs e)
        {
            pet.Sleep = pet.Sleep + 5;
        }
    }
}
