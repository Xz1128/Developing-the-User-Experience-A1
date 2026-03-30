using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    // 拖拽赋值：当前控制页和菜单页
    public GameObject controlPage;
    public GameObject menuPage;

    // 显示菜单页，隐藏控制页
    public void ShowMenu()
    {
        controlPage.SetActive(false);
        menuPage.SetActive(true);
    }

    // 从菜单页返回控制页
    public void ShowControlPage()
    {
        menuPage.SetActive(false);
        controlPage.SetActive(true);
    }
}