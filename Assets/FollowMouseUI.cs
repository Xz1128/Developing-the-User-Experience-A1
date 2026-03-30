using UnityEngine;

public class FollowMouseUI : MonoBehaviour
{
    void Start()
    {
        // 隐藏系统默认鼠标光标
        Cursor.visible = false;
    }

    void Update()
    {
        // 让 UI 指针完全跟随鼠标位置
        transform.position = Input.mousePosition;
    }

    void OnDestroy()
    {
        // 场景销毁时恢复系统鼠标光标（避免退出后一直隐藏）
        Cursor.visible = true;
    }
}