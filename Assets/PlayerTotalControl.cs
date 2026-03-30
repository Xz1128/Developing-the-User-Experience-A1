using UnityEngine;

/// <summary>
/// 人物全控制脚本：上下左右移动/左右旋转/等比缩放/一键重置
/// 挂载到人物根对象（Player）上，参数在Inspector面板调整
/// </summary>
public class PlayerTotalControl : MonoBehaviour
{
    [Header("移动速度（越大移越快）")]
    public float moveSpeed = 0.3f;  // 灰盒建议0.3-0.5，可自行调

    [Header("旋转速度（度/次，建议10-20）")]
    public float rotateSpeed = 15f;

    [Header("缩放步长（越大变幅越大）")]
    public float scaleStep = 0.1f;

    [Header("缩放限制（防止变形/消失）")]
    public float minScale = 0.5f;   // 最小缩放比例
    public float maxScale = 3f;     // 最大缩放比例

    // 存储人物初始状态（复位用）
    private Vector3 _initPos;
    private Quaternion _initRot;
    private Vector3 _initScale;

    // 游戏启动时记录初始状态
    private void Start()
    {
        _initPos = transform.position;
        _initRot = transform.rotation;
        _initScale = transform.localScale;
    }

    #region 移动控制（上下左右）
    // 上移（Y轴增加）
    public void MoveUp()
    {
        transform.Translate(0, moveSpeed, 0, Space.World);
    }

    // 下移（Y轴减少）
    public void MoveDown()
    {
        transform.Translate(0, -moveSpeed, 0, Space.World);
    }

    // 左移（X轴减少）
    public void MoveLeft()
    {
        transform.Translate(-moveSpeed, 0, 0, Space.World);
    }

    // 右移（X轴增加）
    public void MoveRight()
    {
        transform.Translate(moveSpeed, 0, 0, Space.World);
    }
    #endregion

    #region 旋转控制（左右绕Y轴）
    // 往左旋转（逆时针，绕自身Y轴）
    public void RotateLeft()
    {
        transform.Rotate(0, -rotateSpeed, 0, Space.Self);
    }

    // 往右旋转（顺时针，绕自身Y轴）
    public void RotateRight()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.Self);
    }
    #endregion

    #region 缩放控制（等比）
    // 放大（限制最大值）
    public void ScaleUp()
    {
        if (transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * scaleStep;
        }
    }

    // 缩小（限制最小值）
    public void ScaleDown()
    {
        if (transform.localScale.x > minScale)
        {
            transform.localScale -= Vector3.one * scaleStep;
        }
    }
    #endregion

    #region 重置控制（一键恢复初始状态）
    public void ResetPlayer()
    {
        transform.position = _initPos;
        transform.rotation = _initRot;
        transform.localScale = _initScale;
    }
    #endregion
}