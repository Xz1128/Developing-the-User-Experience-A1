using UnityEngine;

/// <summary>
/// 适配Unity普通3D Sphere的太阳移动+闪烁发光脚本
/// 直接挂载到太阳Sphere物体上，仅需给球体添加自发光材质
/// </summary>
public class SunMoveFlicker_Sphere : MonoBehaviour
{
    [Header("📌 垂直移动设置（普通Sphere专用）")]
    [Tooltip("上下浮动速度，建议0.1~0.3，值越小越慢")]
    public float floatSpeed = 0.15f;
    [Tooltip("上下浮动的最大距离，建议1~3，值越小浮动幅度越小")]
    public float floatRange = 2f;

    [Header("✨ 发光闪烁设置")]
    [Tooltip("闪烁频率，建议2~5，值越小闪得越快")]
    public float flickerSpeed = 3f;
    [Tooltip("最小发光强度，建议1~3")]
    public float minEmission = 1.5f;
    [Tooltip("最大发光强度，建议3~6")]
    public float maxEmission = 4f;

    private float _originY; // 记录太阳初始Y轴位置，仅上下浮动
    private Material _sunMat; // 缓存太阳材质，提升性能
    private Color _baseEmissionColor; // 保留材质原始发光色（如你的黄色#F1C40F）

    void Start()
    {
        // 初始化：记录初始位置+获取材质
        _originY = transform.position.y;
        InitSunMaterial();
    }

    void Update()
    {
        if (_sunMat == null) return;
        SunVerticalFloat(); // 执行上下移动
        SunBreathFlicker(); // 执行呼吸式发光
    }

    /// <summary>
    /// 初始化太阳材质（兼容普通Sphere的MeshRenderer）
    /// </summary>
    private void InitSunMaterial()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer == null)
        {
            Debug.LogError("太阳Sphere物体缺少MeshRenderer组件！（普通3D Sphere默认自带，请勿删除）");
            return;
        }
        // 实例化材质，避免修改影响其他共用该材质的物体
        _sunMat = renderer.material;
        // 启用自发光并记录原始颜色
        _sunMat.EnableKeyword("_EMISSION");
        _baseEmissionColor = _sunMat.GetColor("_EmissionColor");
    }

    /// <summary>
    /// 太阳垂直上下平滑浮动（X/Z轴固定，仅动Y轴）
    /// </summary>
    private void SunVerticalFloat()
    {
        float yOffset = Mathf.Sin(Time.time * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, _originY + yOffset, transform.position.z);
    }

    /// <summary>
    /// 呼吸式闪烁发光（仅改变强度，不改变颜色，效果柔和）
    /// </summary>
    private void SunBreathFlicker()
    {
        // 正弦函数实现0~1的平滑循环，映射到发光强度区间
        float intensity = Mathf.Lerp(minEmission, maxEmission, (Mathf.Sin(Time.time * flickerSpeed) + 1) / 2);
        // 重新设置自发光颜色（颜色不变，仅乘强度）
        _sunMat.SetColor("_EmissionColor", _baseEmissionColor * intensity);
    }
}