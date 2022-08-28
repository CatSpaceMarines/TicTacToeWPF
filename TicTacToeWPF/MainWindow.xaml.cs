using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeWPF
{
	public partial class MainWindow : Window
	{
		protected int turns;
		protected List<int> noughtsIndexs = new List<int>();
		protected List<int> crossesIndexs = new List<int>();
		protected char[] board = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

		public MainWindow()
		{
			InitializeComponent();
		}

		protected void Tile_Click(object sender, RoutedEventArgs e)
		{
			int tag = Convert.ToInt32(((Button)sender).Tag);
			((Button)sender).Content = Turn(ref turns);
			switch (tag)
			{
				case 1: LeftUp.IsEnabled = false;
					break;
				case 2: Up.IsEnabled = false;
					break;
				case 3: RightUp.IsEnabled = false;
					break;
				case 4: Left.IsEnabled = false;
					break;
				case 5: Center.IsEnabled = false;
					break;
				case 6: Right.IsEnabled = false;
					break;
				case 7: LeftDown.IsEnabled = false;
					break;
				case 8: Down.IsEnabled = false;
					break;
				case 9: RightDown.IsEnabled = false;
					break;

			}
			if (turns % 2 != 0)
			{
				noughtsIndexs.Add(tag - 1);
				if (CheckVictory(noughtsIndexs, board))
				{
					Text.Text = $"Победили нолики!!!";
					LeftUp.IsEnabled = false; Up.IsEnabled = false; RightUp.IsEnabled = false;
					Left.IsEnabled = false; Center.IsEnabled = false; Right.IsEnabled = false;
					LeftDown.IsEnabled = false; Down.IsEnabled = false; RightDown.IsEnabled = false;
				}
			}
			else
			{
				crossesIndexs.Add(tag - 1);
				if (CheckVictory(crossesIndexs, board))
				{
					Text.Text = $"Победили крестики!!!";
					LeftUp.IsEnabled = false; Up.IsEnabled = false; RightUp.IsEnabled = false;
					Left.IsEnabled = false; Center.IsEnabled = false; Right.IsEnabled = false;
					LeftDown.IsEnabled = false; Down.IsEnabled = false; RightDown.IsEnabled = false;
				}
			}
			turns++;
		}
		protected char Turn(ref int turns)
		{
			if (turns % 2 != 0)
				return 'O';
			else
				return 'X';
		}

		protected static bool CheckVictory(List<int> indexes, char[] board)
		{
			if ((indexes.Contains(0) && indexes.Contains(1) && indexes.Contains(2)) ||
				(indexes.Contains(3) && indexes.Contains(4) && indexes.Contains(5)) ||
				(indexes.Contains(6) && indexes.Contains(7) && indexes.Contains(8)) ||
				(indexes.Contains(0) && indexes.Contains(3) && indexes.Contains(6)) ||
				(indexes.Contains(1) && indexes.Contains(4) && indexes.Contains(7)) ||
				(indexes.Contains(2) && indexes.Contains(5) && indexes.Contains(8)) ||
				(indexes.Contains(0) && indexes.Contains(4) && indexes.Contains(8)) ||
				(indexes.Contains(2) && indexes.Contains(4) && indexes.Contains(6)))
			{
				return true;
			}
			else return false;
		}
	}
}
