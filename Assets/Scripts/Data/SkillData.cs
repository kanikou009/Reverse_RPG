using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "CreateSkillData")]
public class SkillData : ScriptableObject
{
    public Type SkillType => _type;
    public string SkillName => _skillName;
    public string SkillInformation => _information;
    public int Damage => _damage;
    public bool IsWhole => _isWhole;

    [SerializeField]
    [Header("Skillの種類")]
    Type _type;

    [SerializeField]
    [Header("技の名前")]
    string _skillName;

    [SerializeField]
    [Header("技の情報")]
    string _information;

    [SerializeField]
    [Header("技のダメージ量")]
    int _damage;

    [SerializeField]
    [Header("全体かどうか判定するフラグ")]
    bool _isWhole;


    public enum Type
    {
        NomalAttack,//通常攻撃
        MagicAttack,//魔法攻撃
        HeelMagic,//回復
        CureAbnormalConditionMagic,//状態異常回復
        PoisonMagic,//毒
        RunAway//逃げる
    }
}
