using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    [Header("Light Combo")]
    public AttackData[] lightCombo;

    [Header("Heavy Combo")]
    public AttackData[] heavyCombo;

    [Header("Special Attacks")]
    public AttackData chargedAttack;
    public AttackData jumpAttack;

    [Header("Combo Rules")]
    public float comboBuffer = 0.25f;

    [Header("Global Weapon Modifiers")]
    public float damageMultiplier = 1f;
    public float staminaMultiplier = 1f;

    [Header("Movement Defaults")]
    public bool allowMovementDuringAttacks = true;
    public bool allowDashCancel = false;
    public bool locksMovementDuringHeavy = false;
}
