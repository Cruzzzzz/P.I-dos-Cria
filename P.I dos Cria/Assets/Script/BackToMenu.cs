using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
 public void BackTomenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
