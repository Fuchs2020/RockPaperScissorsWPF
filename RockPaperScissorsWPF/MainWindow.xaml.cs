// Author   :   Gabrielle Fuchs
// Date     :   2020-14-09
// Chapter 4 Exercise 8 RockPaperScissors

//Create a Resource folder in the project
//Add rock.png, paper.png, scissors.png to the folder using
//project properties. Resources Images add existing file.
//set the build aaction for each file to "Resource"


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RockPaperScissorsWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomNumberGen = new Random();

        enum Selection {ROCK, PAPER, SCISSORS };

        Selection humanChoice, computerChoice;

        int humanScore, computerScore, tieScore;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmName_Loaded(object sender, RoutedEventArgs e)
        {
            humanScore = 0;
            computerScore = 0;
            tieScore = 0;

            lblHunameChose.Content = " ";
            lblComputerChose.Content = " ";
            lblResult.Content = " ";

            imgHumanChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blank.png"));
            imgComputerChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blank.png"));

        }

        private void brnRock_Click(object sender, RoutedEventArgs e)
        {
            humanChoice = Selection.ROCK;
            imgHumanChoice.Source =  new BitmapImage(new Uri(@"pack://application:,,,/Resources/rock.png"));
            DoComparisons();
        }

        private void btnPaper_Click(object sender, RoutedEventArgs e)
        {
            humanChoice = Selection.PAPER;
            imgHumanChoice.Source  = new BitmapImage(new Uri(@"pack://application:,,,/Resources/paper.png"));
            DoComparisons();
        }

        private void btnScissors_Click(object sender, RoutedEventArgs e)
        {
            humanChoice = Selection.SCISSORS;
            imgHumanChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/scissors.png"));
            DoComparisons();

        }

        private void DoComparisons()
        {
            computerChoice = (Selection)randomNumberGen.Next(0, 3);

            lblHunameChose.Content = "You chose " + Convert.ToString((Selection)humanChoice);
            lblComputerChose.Content = "Computer chose " + Convert.ToString((Selection)computerChoice);

            switch (computerChoice)
            {
                case Selection.ROCK:
                    imgComputerChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/rock.png"));
                    break;
                case Selection.PAPER:
                    imgComputerChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/paper.png"));
                    break;
                case Selection.SCISSORS:
                    imgComputerChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/scissors.png"));
                    break;
                default:
                    imgComputerChoice.Source = new BitmapImage(new Uri(@"pack://application:,,,/Resources/blank.png"));
                    break;
            }

            //selections that result in a tie
            if (humanChoice == computerChoice)
                    {
                        lblResult.Foreground = Brushes.Black;
                        lblResult.Content = "Tie";
                        tieScore++;
                    }
            else
                    {
                        //selections that result in human winning
                        if ((humanChoice == Selection.ROCK && computerChoice == Selection.SCISSORS) ||
                            (humanChoice == Selection.PAPER && computerChoice == Selection.ROCK) ||
                            (humanChoice == Selection.SCISSORS && computerChoice == Selection.PAPER))
                        {
                            lblResult.Foreground = Brushes.DarkGreen;
                            lblResult.Content = "You win!";
                            humanScore++;
                        }
                        else //the computer won
                        {
                            lblResult.Foreground = Brushes.Maroon;
                            lblResult.Content = "Computer wins =(";
                            computerScore++;
                        }
                    }

                    txtHumanScore.Text = Convert.ToString(humanScore);
                    txtComputerScore.Text = Convert.ToString(computerScore);
                    txtTieScore.Text = Convert.ToString(tieScore);
            }//end of DoCOmparrison
            
        
    }
}
