using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class BattleManager : SingletonMonoBehaviour<BattleManager>
{
    public GameObject[] Enemies => GetFighters<EnemyBase>();

    PlayerBase _player;

    public event Action OnBattleEnd;

    private void Start()
    {
        BattleStart();
    }

    void BattleStart()
    {
        if(GetFighter<PlayerBase>().TryGetComponent(out PlayerBase playerBase))
        {
            _player = playerBase;
            if(playerBase.TryGetComponent(out ISelectAction ia))
            {
                ia.SelectAction();
            }
        }
    }

    void ActionStart()
    {
        CompareSpeed(_player, GetFighters<EnemyBase>()).ForEach(async x =>
        {
            if (x.TryGetComponent(out IDoAction id))
            {
                await Task.Run( () =>id.DoAction());
            }
        });
        TurnEnd();
    }

    void TurnEnd()
    {
        if(_player.HP <= 0)
        {
            BattleEnd();
        }
        else
        {
            OnBattleEnd?.Invoke();
            OnBattleEnd = null;
            BattleStart();
        }
    }

    void BattleEnd()
    {

    }

    List<GameObject> CompareSpeed(PlayerBase player, IEnumerable<GameObject> enemies)
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

    GameObject GetFighter<T>() where T : MonoBehaviour
    {
        Type t = typeof(T);
        return FindObjectOfType(t) as GameObject;
    }

    GameObject[] GetFighters<T>() where T : MonoBehaviour
    {
        Type t = typeof(T);
        return FindObjectsOfType(t) as GameObject[];
    }

    public void SelectedAction()
    {
        ActionStart();
    }
}
