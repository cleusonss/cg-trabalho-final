using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    //funcao click para mudar a cena
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
