using UnityEngine;
using BoardF;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MainScript : MonoBehaviour {

    public Text TextMoves;
    Game game;
    Sound sound;
    const int size = 4;
    void Start ()
    {
        game = new Game(size);
        sound = GetComponent<Sound>();
        HideButtons();
	}

    public void OnStart()
    {
        game.Start(1000 + DateTime.Now.DayOfYear);
        ShowButtons();
        sound.PlayStart();
    }

    public void OnClick()
    {
        if (game.Solved())
            return;
        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));
        if (game.PressAt(x, y) > 0)
            sound.PlayMove();
        ShowButtons();
        if (game.Solved())
        {
            TextMoves.text = "Game is finished " + game.moves + " moves";
            sound.PlaySolved();
        }
         
    }

    void HideButtons() //скрытие кнопок
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(0, x, y);
        TextMoves.text = "Welcome to Game F";
    }
    void ShowButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
        TextMoves.text = game.moves + " moves";
    }
    void ShowDigitAt(int digit, int x, int y)
    {
        string name = x + "" + y;
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        text.text = digit.ToString("X");
        button.GetComponentInChildren<Image>().color = (digit > 0) ? Color.white : Color.clear;//set visible
    }

}
