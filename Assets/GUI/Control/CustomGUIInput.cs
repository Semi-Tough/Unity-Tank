using UnityEngine;
using UnityEngine.Events;

public class CustomGUIInput : CustomGUIControl
{
    public event UnityAction<string> ChangeText;

    private string lastText;

    protected override void StyleOnDraw()
    {
        Content.text = GUI.TextField(CustomGUITransform.RectPos, Content.text, Style);
        if (Content.text != lastText)
        {
            ChangeText?.Invoke(Content.text);
            lastText = Content.text;
        }
    }

    protected override void StyleOffDraw()
    {
        Content.text = GUI.TextField(CustomGUITransform.RectPos, Content.text);
        if (Content.text != lastText)
        {
            ChangeText?.Invoke(Content.text);
            lastText = Content.text;
        }
    }
}