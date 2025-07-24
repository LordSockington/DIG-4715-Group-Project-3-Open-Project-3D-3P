using UnityEngine;

[CreateAssetMenu(fileName = "AttackSO", menuName = "Attacks/Normal Attack")]

public class AttackSO : ScriptableObject
{
    public AnimatorOverrideController animtorOV;
    public float damage;
    public string attackName;
}
