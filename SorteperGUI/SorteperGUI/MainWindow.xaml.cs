using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SorteperGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameManager manager;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindows_GameFinished(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e is GameFinishedEventArgs)
                {
                    PairButton.Visibility = Visibility.Hidden;
                    DrawButton.Visibility = Visibility.Hidden;
                    EndButton.Visibility = Visibility.Hidden;
                    PlayerName.Visibility = Visibility.Hidden;
                    ComputerName.Visibility = Visibility.Hidden;
                    player1view.Visibility = Visibility.Hidden;
                    player2view.Visibility = Visibility.Hidden;
                    GameName.Visibility = Visibility.Visible;
                    GameEndedText.Visibility = Visibility.Visible;
                    StartButton.Visibility = Visibility.Visible;
                    AliasString.Visibility = Visibility.Visible;
                    AliasHeader.Visibility = Visibility.Visible;
                    GameEndedText.Text = manager.GameSummary;
                    manager = null;
                }
            });
        }

        private void PairButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = player1view.SelectedItems;
            List<ICard> selected = new List<ICard>();
            foreach (var item in selectedItems)
            {
                selected.Add((ICard)item);
            }
            if (manager.Turn == 0)
            {
                manager.Players[0].MakePair(selected);
            }
        }

        private void MainWindows_PLayerHandChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                if (e is HandEventArgs)
                {
                    player1view.ItemsSource = ((HandEventArgs)e).Hand;
                    player1view.Items.Refresh();
                }
                else if (e is DrawEventArgs)
                {
                    player1view.ItemsSource = ((DrawEventArgs)e).Players[0].Hand;
                    player2view.ItemsSource = ((DrawEventArgs)e).Players[1].Hand;
                    player1view.Items.Refresh();
                    player2view.Items.Refresh();
                }
            });
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = player2view.SelectedItems;
            List<ICard> selected = new List<ICard>();
            foreach (var item in selectedItems)
            {
                selected.Add((ICard)item);
            }
            if (manager.Turn == 0 && !manager.HasDrawn)
            {
                manager.Players[0].DrawCard(selected, manager.Players);
                manager.HasDrawn = true;
            }
        }

        private void EndTurn_Click(object sender, RoutedEventArgs e)
        {
            manager.EndTurn();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            string name = AliasString.Text;
            manager = new GameManager(new Player[] { new Player(new List<ICard>(), name), new ComputerPlayer(new List<ICard>(), "Computer") });
            PlayerName.Text = manager.Players[0].Name;
            ComputerName.Text = manager.Players[1].Name;
            StartScreen();
            manager.Players[0].PlayerHandChanged += MainWindows_PLayerHandChanged;
            manager.Players[0].DrewCards += MainWindows_PLayerHandChanged;
            manager.Players[1].DrewCards += MainWindows_PLayerHandChanged;
            manager.GameFinished += MainWindows_GameFinished;
            player1view.ItemsSource = manager.Players[0].Hand;
            player2view.ItemsSource = manager.Players[1].Hand;
        }

        private void StartScreen()
        {
            GameName.Visibility = Visibility.Hidden;
            StartButton.Visibility = Visibility.Hidden;
            AliasString.Visibility = Visibility.Hidden;
            AliasHeader.Visibility = Visibility.Hidden;
            GameEndedText.Visibility = Visibility.Hidden;
            PlayerName.Visibility = Visibility.Visible;
            ComputerName.Visibility = Visibility.Visible;
            player1view.Visibility = Visibility.Visible;
            player2view.Visibility = Visibility.Visible;
            DrawButton.Visibility = Visibility.Visible;
            PairButton.Visibility = Visibility.Visible;
            EndButton.Visibility = Visibility.Visible;
        }
    }
}
