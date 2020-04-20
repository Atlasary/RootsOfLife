using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionGame : MonoBehaviour {

    public GameObject ui;

    public SceneFader sceneFader;

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

}
