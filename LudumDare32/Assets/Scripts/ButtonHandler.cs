using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {

	public void exitApplication()
	{
		Application.Quit();
	}

	public void startGame()
	{
		Application.LoadLevel("Game");
	}

	public void goToMenu()
	{
		Application.LoadLevel("Menu");
	}
}
