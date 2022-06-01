using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class BattleViewManager : SingletonMonoBehaviour<BattleViewManager>
{
    [SerializeField]
    [Header("表示するパネル")]
    GameObject _panel;

    [SerializeField]
    [Header("表示するボタン")]
    Button _button;

    List<Button> _buttons = new List<Button>();

    public void SetPanel(bool flag)
    {
        _panel.SetActive(flag);
    }

    void ButtonSetting(int needButtonNum)
    {
        if (ButtonSearch() != needButtonNum)
        {
            if (ButtonSearch() < needButtonNum)
            {
                if (_buttons.Count < needButtonNum)
                {
                    ButtonGenerate(needButtonNum - _buttons.Count);
                    return;
                }
                else
                {
                    NotHideButton(needButtonNum);
                }
            }
            else
            {
                HideButton(ButtonSearch() - needButtonNum);
            }
        }
    }

    public void SetButtonToSelectSkill(IReadOnlyList<SkillData> skills)
    {
        ButtonSetting(skills.Count);
        for (int i = 0; i < ButtonSearch(); i++)
        {
            var x = i;
            _buttons[i].GetComponentInChildren<Text>().text = skills[i].ToString();
            _buttons[i].onClick.AddListener(() =>
            {
                SetButtonToTargetDecision(x);
                
            });
        }
    }

void SetButtonToTargetDecision(int num)
{
    ButtonSetting(BattleManager.Instance.Enemies.Length);
    for (int i = 0; i < BattleManager.Instance.Enemies.Length; i++)
    {
        _buttons[i].onClick.AddListener(BattleManager.Instance.SelectedAction);
    }
}

int ButtonSearch()
{
    return _buttons.Where(x => x.gameObject.activeInHierarchy).Count();
}

void ButtonTextChenge(Button button, string str)
{
    button.GetComponentInChildren<Text>().text = str;
}

void ButtonGenerate(int num)//Buttonが足りなくなったら生成する
{
    for (int i = 0; i < num; i++)
    {
        var button = Instantiate(_button, _panel.transform);
        button.transform.position = _panel.transform.position;
        _buttons.Add(button);
    }
}

void NotHideButton(int num)//表示されているButtonが足りないが、生成する必要がないとき
{
    for (int i = 0; i < num; i++)
    {
        _buttons[i].gameObject.SetActive(true);
    }
}

void HideButton(int num)//Buttonが余ったら隠す　引数は隠したいButtonの数
{
    for (int i = 0; i < num; i++)
    {
        _buttons[_buttons.Count - i].gameObject.SetActive(false);//後ろから隠していく
    }
}
}
