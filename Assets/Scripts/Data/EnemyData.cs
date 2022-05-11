using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "EnemyData", menuName = "CreateEnemyData")]
public class EnemyData : ScriptableObject
{
    public string Name => _name;
    public int HP => _hp;
    public int MP => _mp;
    public int MaxHP => _maxHp;
    public int MaxMP => _maxMp;
    public int Power => _power;
    public int DefensePower => _defensePower;
    public int Speed => _speed;

    [SerializeField]
    [Header("Enemyの名前")]
    string _name;

    [SerializeField]
    [Header("EnemyのHP")]
    int _hp;

    [SerializeField]
    [Header("EnemyのMP")]
    int _mp;

    [SerializeField]
    [Header("Enemyの攻撃力")]
    int _power;

    [SerializeField]
    [Header("Enemyの防御力")]
    int _defensePower;

    [SerializeField]
    [Header("Enemyの素早さ")]
    int _speed;

    [SerializeField]
    [Header("Enemyの最大HP")]
    int _maxHp;

    [SerializeField]
    [Header("Enemyの最大MP")]
    int _maxMp;
}
