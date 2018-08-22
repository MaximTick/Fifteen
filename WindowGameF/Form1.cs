using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoardF;

namespace WindowGameF
{
    public partial class FormName15 : Form
    {
        const int size = 4;
        Game game;
        public FormName15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void b00_Click(object sender, EventArgs e)
        {
            if (game.Solved())
                return;
            Button button = (Button)sender; //b00
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PressAt(x, y);
            ShowButtons();

            if (game.Solved())
                labelMoves.Text = "Game finished in " + game.moves + " moves";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            game.Start (1000 + DateTime.Now.DayOfYear);
            ShowButtons();
        }

        void HideButtons() //скрытие кнопок
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(0, x, y);
        }
        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    ShowDigitAt(game.GetDigitAt(x, y), x, y);
            labelMoves.Text = game.moves.ToString() + " moves";
        }

        void ShowDigitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y];
            button.Text = digit.ToString();
            button.Visible = digit > 0;
        }
    }
}
