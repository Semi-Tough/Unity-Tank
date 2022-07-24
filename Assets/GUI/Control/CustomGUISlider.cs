using System;
using UnityEngine;
using UnityEngine.Events;

public enum ESliderType
{
    Horizontal,
    Vertical
}

public class CustomGUISlider : CustomGUIControl
{
    public ESliderType SliderTypeType;

    public float MinValue;
    public float MaxValue = 1;
    public float Value;
    public GUIStyle ThumbStyle;
    public event UnityAction<float> ChangeValue;
    private float lastValue;

    protected override void StyleOnDraw()
    {
        switch (SliderTypeType)
        {
            case ESliderType.Horizontal:
                Value = GUI.HorizontalSlider(CustomGUITransform.RectPos, Value, MinValue, MaxValue, Style, ThumbStyle);

                break;
            case ESliderType.Vertical:
                Value = GUI.VerticalSlider(CustomGUITransform.RectPos, Value, MinValue, MaxValue, Style, ThumbStyle);
                break;
        }

        if (Math.Abs(Value - lastValue) > 0.1f)
        {
            ChangeValue?.Invoke(Value);
            lastValue = Value;
        }
    }

    protected override void StyleOffDraw()
    {
        switch (SliderTypeType)
        {
            case ESliderType.Horizontal:
                Value = GUI.HorizontalSlider(CustomGUITransform.RectPos, Value, MinValue, MaxValue);

                break;
            case ESliderType.Vertical:
                Value = GUI.VerticalSlider(CustomGUITransform.RectPos, Value, MinValue, MaxValue);
                break;
        }

        if (Math.Abs(Value - lastValue) > 0.1f)
        {
            ChangeValue?.Invoke(Value);
            lastValue = Value;
        }
    }
}