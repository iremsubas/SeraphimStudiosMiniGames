using System;
using UnityEngine;
using UnityEngine.UI;

namespace LazyLayout
{
    [System.Serializable]
    public class RectTransHelper
    {
        public Vector3 position, localPosition,
                        eulerAngles, localEulerAngles,
                        anchoredPosition3D,
                        localScale;

        public Vector2 anchoredPosition,
                        anchorMax, anchorMin,
                        offsetMax, offsetMin,
                        pivot,
                        sizeDelta;

        public Quaternion rotation, localRotation;

        public Rect rect;

        public int silbingIndex;
    }

    [System.Serializable]
    public class ImageHelper
    {
        public Sprite sprite, overrideSprite;
        public Color color;
        public Material material;
        public Image.Type type;
        public bool fillCenter;
        public bool enabled;
    }

    [System.Serializable]
    public class TextHelper
    {
        public string text;

        public Font font;
        public FontStyle fontStyle;

        public float lineSpacing;

        public int fontSize;

        public TextAnchor alignment;
        public HorizontalWrapMode horizontalOverflow;
        public VerticalWrapMode verticalOverflow;
        public Color color;

        public bool resizeTextForBestFit,
                     supportRichText;

        public Material defaultMaterial;
        public bool enabled;
    }

    [System.Serializable]
    public class ButtonHelper
    {
        public Button.ButtonClickedEvent onClick;
        public bool interactable;
        public Selectable.Transition transition;
        public Graphic targetGraphic;

        public float colorMultiplier,
                     fadeDuration;

        public Color disabledColor,
                     highlightedColor,
                     normalColor,
                     pressedColor;

        Navigation navigation;
        public bool enabled;
    }

    [System.Serializable]
    public class ToggleHelper
    {
        public bool interactable;
        public Selectable.Transition transition;
        public Navigation navigation;

        public bool isOn;
        public Toggle.ToggleTransition toggleTransition;
        public Graphic graphic;
        public ToggleGroup group;
        public Toggle.ToggleEvent onValueChanged;

        public float colorMultiplier,
                     fadeDuration;

        public Color disabledColor,
                     highlightedColor,
                     normalColor,
                     pressedColor;
        public bool enabled;
    }

    [System.Serializable]
    public class RawImageHelper
    {
        public Texture texture;
        public Color color;
        public Material material;
        public Rect uvRect;
        public bool enabled;
    }

    [System.Serializable]
    public class SliderHelper
    {
        public bool interactable,
                    wholeNumbers;
        public Selectable.Transition transition;
        public Graphic targetGraphic;

        public float colorMultiplier,
                     fadeDuration,
                     minValue,
                     maxValue,
                     value;

        public Color disabledColor,
                     highlightedColor,
                     normalColor,
                     pressedColor;

        public RectTransform fillRect,
                             handleRect;

        public Slider.Direction direction;

        public Slider.SliderEvent onValueChanged;

        Navigation navigation;
        public bool enabled;
    }

    [System.Serializable]
    public class ScrollbarHelper
    {
        public bool interactable;
        public Selectable.Transition transition;
        public Graphic targetGraphic;

        public float colorMultiplier,
                     fadeDuration,
                     value,
                     size;
        public int numberOfSteps;

        public Color disabledColor,
                     highlightedColor,
                     normalColor,
                     pressedColor;

        public RectTransform handleRect;

        public Scrollbar.Direction direction;

        public Scrollbar.ScrollEvent onValueChanged;

        Navigation navigation;
        public bool enabled;
    }

    [System.Serializable]
    public class InputFieldHelper
    {
        public bool interactable,
                    shouldHideMobileInput;
        public Selectable.Transition transition;
        public Graphic targetGraphic,
                       placeholder;

        public float colorMultiplier,
                     fadeDuration,
                     caretBlinkRate;

        public Color disabledColor,
                     highlightedColor,
                     normalColor,
                     pressedColor;

        Navigation navigation;

        public Text textComponent;
        public string text;
        public int characterLimit;
        public InputField.ContentType contentType;
        public InputField.LineType lineType;

        public Color selectionColor;

        public InputField.OnChangeEvent onValueChange;
        public InputField.OnValidateInput onValidateInput;
        public bool enabled;
    }

    [System.Serializable]
    public class VerticalLayoutG_Helper
    {
        public bool enabled;
        public int padding_left,
                     padding_right,
                     padding_top,
                     padding_bottom;
        public float spacing;

        public bool childForceExpand_Width,
                    childForceExpand_Height;

        public TextAnchor childAlignment;
    }

    [System.Serializable]
    public class HorizontalLayoutG_Helper
    {
        public bool enabled;
        public int padding_left,
                     padding_right,
                     padding_top,
                     padding_bottom;
        public float spacing;

        public bool childForceExpand_Width,
                    childForceExpand_Height;

        public TextAnchor childAlignment;
    }

    [System.Serializable]
    public class LayoutElement_Helper
    {
        public bool enabled;
        public bool ignoreLayout;

        public float minWidth,
                     minHeight,
                     preferredWidth,
                     preferredHeight,
                     flexibleWidth,
                     flexibleHeight;
    }

    [System.Serializable]
    public class ContentSizeFitter_Helper
    {
        public bool enabled;
        public ContentSizeFitter.FitMode horizontalFit, verticalFit;
    }

    [System.Serializable]
    public class AspectRatioFitter_Helper
    {
        public bool enabled;
        public AspectRatioFitter.AspectMode aspectMode;
        public float aspectRatio;
    }

    [System.Serializable]
    public class GridLayoutG_Helper
    {
        public bool enabled;
        public int padding_left,
                     padding_right,
                     padding_top,
                     padding_bottom;

        public Vector2 cellSize, spacing;

        public GridLayoutGroup.Axis startAxis;
        public GridLayoutGroup.Corner startCorner;
        public TextAnchor childAlignment;
        public GridLayoutGroup.Constraint constraint;
    }

    [System.Serializable]
    public class Shadow_Helper
    {
        public bool enabled;

        public Color effectColor;
        public Vector2 effectDistance;
        public bool useGraphicAlpha;
    }

    [System.Serializable]
    public class Outline_Helper
    {
        public bool enabled;

        public Color effectColor;
        public Vector2 effectDistance;
        public bool useGraphicAlpha;
    }

    [System.Serializable]
    public class ScrollRect_Helper
    {
        public bool enabled;

        public RectTransform content;
        public bool horizontal,
                    vertical,
                    inertia;
        public ScrollRect.MovementType movementType;
        public float elasticity,
                     decelerationRate,
                     scrollSensitivity;
        public Scrollbar horizontalScrollbar, verticalScrollbar;
        public ScrollRect.ScrollRectEvent onValueChanged;
    }
    
	

}
