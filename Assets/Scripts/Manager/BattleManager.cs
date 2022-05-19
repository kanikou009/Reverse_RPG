using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    [SerializeField]
    [Header("表示するパネル")]
    GameObject _panel;

    [SerializeField]
    [Header("表示するボタン")]
    Button _button;

    [SerializeField]
    [Header("Playerのタグ")]
    string _playerTag;

    [SerializeField]
    [Header("Enemyのタグ")]
    string _enemyTag;

    List<Button> _buttons;
    PlayerBase _player;

    private void Start()
    {
        BattleStart();
    }

    void BattleStart()
    {
        if(GameObject.FindWithTag(_playerTag).TryGetComponent(out PlayerBase playerBase))
        {
            //playerBase.SelectAction();
            _player = playerBase;
        }
    }

    void ActionStart()
    {
        //CompareSpeed(_player, GetEnemies()).ForEach(x =>
        //{
        //    if (x.TryGetComponent(out IDoAction id))
        //    {
        //        id.DoAction();
        //    }
        //});
        foreach (var x in CompareSpeed(_player, GetEnemies()))
        {
            if (x.TryGetComponent(out IDoAction id))
            {
                id.DoAction();
            }
        }
    }

    IEnumerable<GameObject> CompareSpeed(PlayerBase player, IReadOnlyCollection<GameObject> enemies)
    {
        Dictionary<GameObject, int> gos = new Dictionary<GameObject, int>();
        gos.Add(player.gameObject, player.Speed);
        foreach (var enemy in enemies)
        {
            if(enemy.TryGetComponent(out EnemyBase e))
            {
                gos.Add(enemy, e.Speed);
            }
        }
        gos.OrderByDescending(x => x.Value);
        return gos.Keys.ToList();
    }

    List<GameObject> GetEnemies()
    {
        return GameObject.FindGameObjectsWithTag(_enemyTag).ToList();
    }

    void ButtonGenerate(int num)//Buttonが足りなくなったら生成する
    {
        for (int i = 0; i < num; i++)
        {
            var button = Instantiate(_button);
            button.transform.position = _panel.transform.position;
            _buttons.Add(button);
        }
    }

    void NotHideButton()//表示されているButtonが足りないが、生成する必要がないとき
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            _buttons[i].gameObject.SetActive(true);
        }
    }

    void HideButton(int num)//Buttonが余ったら隠す　引数は隠したいButtonの数
    {
        for(int i = 0; i < num; i++)
        {
            _buttons[_buttons.Count - i].gameObject.SetActive(false);//後ろから隠していく
        }
    }
}
