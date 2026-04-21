using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Scriptable Objects/AttackData")]
public class AttackData : ScriptableObject
{
    [Header("ID")]
    public string attackName;

    [Header("Core Stats")]
    public float damage;
    public float staminaCost;

    [Header("Timing")]
    public float windupTime;
    public float activeTime;
    public float recoveryTime;

    [Header("Combo")]
    public bool isComboFinisher;
    public float comboWindowBonus;

    [Header("Movement")]
    public bool locksMovement;
    public bool allowMovementDuringRecovery;
    public bool allowDashCancel;

    [Header("Effects")]
    public float stunValue;
    public float knockbackForce;
}
