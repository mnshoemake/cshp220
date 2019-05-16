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
using System.Drawing;


namespace Homework5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int turnCounter = 0;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            ClearBoard();
            EnableButtons();
            turnCounter = 0;
        }

        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button thisButton = (Button)sender;
            string thisTag = thisButton.Tag.ToString();


            if (thisButton.Content == null || thisButton.Content.ToString() == "")
            {
                if (turnCounter % 2 != 0)
                {
                    thisButton.Content = "O";
                    turnCounter++;
                    uxTurn.Text = "X's Turn";
                }
                else
                {
                    thisButton.Content = "X";
                    turnCounter++;
                    uxTurn.Text = "O's Turn";
                }
                IsGameOver();
            }
               

            //Calculate Win State

        }

        private bool IsGameOver()
        {
            List<Button> gridButtons = uxGrid.Children.Cast<Button>().ToList<Button>();
            //var gridButtons = uxGrid.Children.Cast<Button>();
            //List<string> xButtons = new List<string>();

            //foreach (Button x in gridButtons)
            //{
            //    if (x.Content != null && x.Content.ToString() == "X")
            //    {
            //        xButtons.Add(x.Tag.ToString());
            //    }
            //}

            var xButtons = from x in gridButtons
                           where x.Content != null && x.Content.ToString() == "X"
                           select x.Tag.ToString();

            var oButtons = from o in gridButtons
                           where o.Content != null && o.Content.ToString() == "O"
                           select o.Tag.ToString();

            //var xButtons = gridButtons.Where(x.Tag.ToString() => x.Content.ToString() == "X");
            //var oButtons = gridButtons.Where(o.Tag.ToString() => o.Content.ToString() == "O");

            if ((xButtons.Contains<string>("0,0") && xButtons.Contains<string>("0,1") && xButtons.Contains<string>("0,2"))
                ||
                (xButtons.Contains<string>("1,0") && xButtons.Contains<string>("1,1") && xButtons.Contains<string>("1,2"))
                ||
                (xButtons.Contains<string>("2,0") && xButtons.Contains<string>("2,1") && xButtons.Contains<string>("2,2"))
                ||
                (xButtons.Contains<string>("0,0") && xButtons.Contains<string>("1,0") && xButtons.Contains<string>("2,0"))
                ||
                (xButtons.Contains<string>("0,1") && xButtons.Contains<string>("1,1") && xButtons.Contains<string>("2,1"))
                ||
                (xButtons.Contains<string>("0,2") && xButtons.Contains<string>("1,2") && xButtons.Contains<string>("2,2"))
                ||
                (xButtons.Contains<string>("0,0") && xButtons.Contains<string>("1,1") && xButtons.Contains<string>("2,2"))
                ||
                (xButtons.Contains<string>("0,2") && xButtons.Contains<string>("1,1") && xButtons.Contains<string>("2,0"))
                )
            {
                uxTurn.Text = "X wins!";
                DisableButtons();
                return true;
            }

            else if ((oButtons.Contains<string>("0,0") && oButtons.Contains<string>("0,1") && oButtons.Contains<string>("0,2"))
                ||
                (oButtons.Contains<string>("1,0") && oButtons.Contains<string>("1,1") && oButtons.Contains<string>("1,2"))
                ||
                (oButtons.Contains<string>("2,0") && oButtons.Contains<string>("2,1") && oButtons.Contains<string>("2,2"))
                ||
                (oButtons.Contains<string>("0,0") && oButtons.Contains<string>("1,0") && oButtons.Contains<string>("2,0"))
                ||
                (oButtons.Contains<string>("0,1") && oButtons.Contains<string>("1,1") && oButtons.Contains<string>("2,1"))
                ||
                (oButtons.Contains<string>("0,2") && oButtons.Contains<string>("1,2") && oButtons.Contains<string>("2,2"))
                ||
                (oButtons.Contains<string>("0,0") && oButtons.Contains<string>("1,1") && oButtons.Contains<string>("2,2"))
                ||
                (oButtons.Contains<string>("0,2") && oButtons.Contains<string>("1,1") && oButtons.Contains<string>("2,0"))
                )
            {
                uxTurn.Text = "O wins!";
                DisableButtons();
                return true;
            }

            else { return false; }
        }

        private void ClearBoard()
        {
            var gridChildren = uxGrid.Children;
            foreach (var child in gridChildren)
            {
                var buttonChild = (Button)child;
                buttonChild.Content = "";
            }
        }

        private void DisableButtons()
        {
            List<Button> gridButtons = uxGrid.Children.Cast<Button>().ToList<Button>();
            foreach (Button button in gridButtons)
            {
                button.IsEnabled = false;
            }
        }

        private void EnableButtons()
        {
            List<Button> gridButtons = uxGrid.Children.Cast<Button>().ToList<Button>();
            foreach (Button button in gridButtons)
            {
                button.IsEnabled = true;
            }
        }


    }
}
