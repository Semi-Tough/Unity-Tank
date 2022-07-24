using UnityEngine;

public class CustomGUILabel : CustomGUIControl
{
    protected override void StyleOnDraw()
    {
        GUI.Label(CustomGUITransform.RectPos, Content,Style);
    }

    protected override void StyleOffDraw()
    {
        GUI.Label(CustomGUITransform.RectPos, Content);
    }
}