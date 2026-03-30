using UnityEngine;

public enum WeaponType
{
    None,   // 无武器
    Sword,  // 剑
    Shield   // 盾牌
}

public class PlayerWeaponManager : MonoBehaviour
{
    [Header("武器赋值")]
    public GameObject swordObj;   // 拖拽剑的模型
    public GameObject shieldObj;  // 拖拽盾牌的模型

    private GameObject currentWeapon; // 记录当前手持的武器

    void Start()
    {
        // 初始化时确保所有武器都隐藏
        SetAllWeaponsInactive();
    }

    // 对外公开的方法，供按钮调用
    public void EquipSword()
    {
        EquipWeapon(WeaponType.Sword);
    }

    public void EquipShield()
    {
        EquipWeapon(WeaponType.Shield);
    }

    // 核心武器切换逻辑
    private void EquipWeapon(WeaponType type)
    {
        // 1. 先隐藏所有武器
        SetAllWeaponsInactive();

        // 2. 根据类型激活对应的武器
        switch (type)
        {
            case WeaponType.Sword:
                if (swordObj != null)
                {
                    swordObj.SetActive(true);
                    currentWeapon = swordObj;
                }
                break;
            case WeaponType.Shield:
                if (shieldObj != null)
                {
                    shieldObj.SetActive(true);
                    currentWeapon = shieldObj;
                }
                break;
            case WeaponType.None:
                currentWeapon = null;
                break;
        }
    }

    // 辅助方法：隐藏所有武器
    private void SetAllWeaponsInactive()
    {
        if (swordObj != null) swordObj.SetActive(false);
        if (shieldObj != null) shieldObj.SetActive(false);
    }
}