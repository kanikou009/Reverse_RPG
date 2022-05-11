using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "PlayerData" , menuName = "CreatePlayerData")]
public class PlayerData : ScriptableObject
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
    [Header("Playerの名前")]
    string _name;

    [SerializeField]
    [Header("PlayerのHP")]
    int _hp;

    [SerializeField]
    [Header("PlayerのMP")]
    int _mp;

    [SerializeField]
    [Header("Playerの攻撃力")]
    int _power;

    [SerializeField]
    [Header("Playerの防御力")]
    int _defensePower;

    [SerializeField]
    [Header("Playerの素早さ")]
    int _speed;

    [SerializeField]
    [Header("Playerの最大HP")]
    int _maxHp;

    [SerializeField]
    [Header("Playerの最大MP")]
    int _maxMp;
}
