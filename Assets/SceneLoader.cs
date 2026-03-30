using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // 延迟时间（单位：秒），可以在Unity里调整
    private float delay = 0.2f;

    // 跳转到 GameScene
    public void ToGame()
    {
        Invoke("LoadGameScene", delay);
    }

    // 跳转到 OtherScene
    public void ToOther()
    {
        Invoke("LoadOtherScene", delay);
    }

    // 跳转到 MenuScene
    public void ToMenu()
    {
        Invoke("LoadMenuScene", delay);
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void LoadOtherScene()
    {
        SceneManager.LoadScene("OtherScene");
    }

    void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}