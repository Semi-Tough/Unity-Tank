using System.Collections.Generic;
using UnityEngine;

public class TopLabel
{
    public readonly CustomGUILabel LabelName;
    public readonly CustomGUILabel LabelScore;
    public readonly CustomGUILabel LabelTime;

    public TopLabel()
    {
    }

    public TopLabel(CustomGUILabel labelName, CustomGUILabel labelScore, CustomGUILabel labelTime)
    {
        LabelName = labelName;
        LabelScore = labelScore;
        LabelTime = labelTime;
    }
}

public class TopPanel : PanelRoot
{
    public CustomGUIButton BtnClose;

    private readonly List<TopLabel> topLabels = new List<TopLabel>(3);


    private void OnEnable()
    {
        BtnClose.ClickEvent += CloseBtn;
    }

    #region ButtonEvent

    private void CloseBtn()
    {
        HidePanel();
        StartSystem.Instance.StartPanel.ShowPanel();
    }

    #endregion

    private void OnDisable()
    {
        BtnClose.ClickEvent -= CloseBtn;
    }

    public override void ShowPanel()
    {
        base.ShowPanel();
        UpdateTopListData();
    }

    private void UpdateTopListData()
    {
        if (topLabels.Count == 0)
        {
            Transform top = transform.Find("TopPlayer");
            for (int i = 0; i < top.childCount; i++)
            {
                topLabels.Add(new TopLabel(
                    top.GetChild(i).Find("LabelName").GetComponent<CustomGUILabel>(),
                    top.GetChild(i).Find("LabelScore").GetComponent<CustomGUILabel>(),
                    top.GetChild(i).Find("LabelTime").GetComponent<CustomGUILabel>()));
            }
        }

        TopListData topListData = ResourceService.Instance.LoadTopListData();
        for (int i = 0; i < topListData.List.Count; i++)
        {
            topLabels[i].LabelName.Content.text = topListData.List[i].Name;
            topLabels[i].LabelScore.Content.text = topListData.List[i].Score.ToString();
            topLabels[i].LabelTime.Content.text = topListData.List[i].Time;
        }
    }
}