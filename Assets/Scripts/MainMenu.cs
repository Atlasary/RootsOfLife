using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string ToLoadLevel = "MainScene";
	public string ToLoadSucces = "MainScene";
	public string ToLoadGlossaire = "MainScene";
	public string ToLoadOption = "MainScene";
    public SceneFader sceneFader;

    public void SelectLevel()
    {
        sceneFader.FadeTo(ToLoadLevel);
    }
	
	public void SelectSucces()
    {
        sceneFader.FadeTo(ToLoadSucces);
    }
	
	public void SelectGlossaire()
    {
        sceneFader.FadeTo(ToLoadGlossaire);
    }
	
	public void SelectOption()
    {
        sceneFader.FadeTo(ToLoadOption);
    }

    public void Quit()
    {
        Debug.Log("Fermeture du jeu");
        Application.Quit();
    }

}
