using UnityEngine;

public class CustomGUITexture : CustomGUIControl
{
    public ScaleMode ScaleMode = ScaleMode.ScaleToFit;

    protected override void StyleOnDraw()
    {
        GUI.DrawTexture(CustomGUITransform.RectPos, Content.image, ScaleMode);
    }

    protected override void StyleOffDraw()
    {
        GUI.DrawTexture(CustomGUITransform.RectPos, Content.image, ScaleMode);
    }
}