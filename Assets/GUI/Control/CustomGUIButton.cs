using UnityEngine;
using UnityEngine.Events;

public class CustomGUIButton : CustomGUIControl
{
    public event UnityAction ClickEvent;  
    protected override void StyleOnDraw()
    {
        if (GUI.Button(CustomGUITransform.RectPos, Content, Style))
        {
            ClickEvent?.Invoke();
        }
    }

    protected override void StyleOffDraw()
    {
        if (GUI.Button(CustomGUITransform.RectPos, Content))
        {
            ClickEvent?.Invoke();
        }
    }


}