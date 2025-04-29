using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace LazyLayout
{
    public class DPIHelper
    {
        public static float ScreenSize_Android()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                return ScreenSize_Other();
            }

            using (AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"), metricsClass = new AndroidJavaClass("android.util.DisplayMetrics"))
            {
                using (
                     AndroidJavaObject metricsInstance = new AndroidJavaObject("android.util.DisplayMetrics"),
                     activityInstance = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity"),
                     windowManagerInstance = activityInstance.Call<AndroidJavaObject>("getWindowManager"),
                     displayInstance = windowManagerInstance.Call<AndroidJavaObject>("getDefaultDisplay")
                 )
                {
                    displayInstance.Call("getMetrics", metricsInstance);

                    int width = metricsInstance.Get<int>("widthPixels"); ;
                    int height = metricsInstance.Get<int>("heightPixels"); ;
                    int dens = metricsInstance.Get<int>("densityDpi");

                    double wi = (double)width / (double)dens;
                    double hi = (double)height / (double)dens;
                    double x = System.Math.Pow(wi, 2);
                    double y = System.Math.Pow(hi, 2);
                    double screenInches = System.Math.Sqrt(x + y);

                    return System.Convert.ToSingle(screenInches);
                }
            }

        }

        public static float ScreenSize_Other()
        {
            //Debug.LogWarning("--LazyLayout-- NO ANDROID PLATFORM => RETURNING SCRREN.DPI SOLUTION");
            float dp = Mathf.Sqrt((Screen.width * Screen.width) + (Screen.height * Screen.height));
            float deviceSizeInInches = dp / Screen.dpi;
            return deviceSizeInInches;
        }
    }

    [ExecuteInEditMode]
    public class LazyLayoutHelper : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField]
        public string ll_GUID;

        void Awake()
        {
           // DuplicateChecker.ll_HelperList.Add(GetComponent<LazyLayoutHelper>());                     
        }
    }

    public class Unlikes
    {
        public static bool Unlike_RectTransforms(RectTransform _a, RectTransHelper _b)
        {
            if (_a.GetSiblingIndex() != _b.silbingIndex)
            { return true; }

            if (_a.position != _b.position)
            { return true; }

            else if (_a.localPosition != _b.localPosition)
            { return true; }

            else if (_a.rotation != _b.rotation)
            { return true; }

            else if (_a.localRotation != _b.localRotation)
            { return true; }

            else if (_a.eulerAngles != _b.eulerAngles)
            { return true; }

            else if (_a.localEulerAngles != _b.localEulerAngles)
            { return true; }

            else if (_a.localScale != _b.localScale)
            { return true; }

            else if (_a.anchoredPosition != _b.anchoredPosition)
            { return true; }

            else if (_a.anchoredPosition3D != _b.anchoredPosition3D)
            { return true; }

            else if (_a.anchorMax != _b.anchorMax)
            { return true; }

            else if (_a.anchorMin != _b.anchorMin)
            { return true; }

            else if (_a.offsetMax != _b.offsetMax)
            { return true; }

            else if (_a.offsetMin != _b.offsetMin)
            { return true; }

            else if (_a.pivot != _b.pivot)
            { return true; }

            //else if (_a.rect_b.rect)
            //{ return true; }

            else if (_a.sizeDelta != _b.sizeDelta)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Images(Image _a, ImageHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.sprite != _b.sprite)
            { return true; }

            if (_a.color != _b.color)
            { return true; }

            if (_a.material != _b.material)
            { return true; }

            if (_a.type != _b.type)
            { return true; }

            if (_a.fillCenter != _b.fillCenter)
            { return true; }


            else
            { return false; }
        }

        public static bool Unlike_Texts(Text _a, TextHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.text != _b.text)
            { return true; }

            if (_a.font != _b.font)
            { return true; }

            if (_a.fontStyle != _b.fontStyle)
            { return true; }

            if (_a.fontSize != _b.fontSize)
            { return true; }

            if (_a.lineSpacing != _b.lineSpacing)
            { return true; }

            if (_a.alignment != _b.alignment)
            { return true; }

            if (_a.horizontalOverflow != _b.horizontalOverflow)
            { return true; }

            if (_a.verticalOverflow != _b.verticalOverflow)
            { return true; }

            if (_a.color != _b.color)
            { return true; }

            if (_a.resizeTextForBestFit != _b.resizeTextForBestFit)
            { return true; }

            if (_a.supportRichText != _b.supportRichText)
            { return true; }

            if (_a.defaultMaterial != _b.defaultMaterial)
            { return true; }


            else
            { return false; }
        }

        public static bool Unlike_Buttons(Button _a, ButtonHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.onClick != _b.onClick)
            { return true; }

            if (_a.interactable != _b.interactable)
            { return true; }

            if (_a.transition != _b.transition)
            { return true; }

            if (_a.targetGraphic != _b.targetGraphic)
            { return true; }

            if (_a.colors.colorMultiplier != _b.colorMultiplier)
            { return true; }

            if (_a.colors.disabledColor != _b.disabledColor)
            { return true; }

            if (_a.colors.fadeDuration != _b.fadeDuration)
            { return true; }

            if (_a.colors.highlightedColor != _b.highlightedColor)
            { return true; }

            if (_a.colors.normalColor != _b.normalColor)
            { return true; }

            if (_a.colors.pressedColor != _b.pressedColor)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Toggles(Toggle _a, ToggleHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.interactable != _b.interactable)
            { return true; }

            if (_a.transition != _b.transition)
            { return true; }

            if (_a.isOn != _b.isOn)
            { return true; }

            if (_a.toggleTransition != _b.toggleTransition)
            { return true; }

            if (_a.graphic != _b.graphic)
            { return true; }

            if (_a.group != _b.group)
            { return true; }

            if (_a.onValueChanged != _b.onValueChanged)
            { return true; }

            if (_a.colors.colorMultiplier != _b.colorMultiplier)
            { return true; }

            if (_a.colors.disabledColor != _b.disabledColor)
            { return true; }

            if (_a.colors.fadeDuration != _b.fadeDuration)
            { return true; }

            if (_a.colors.highlightedColor != _b.highlightedColor)
            { return true; }

            if (_a.colors.normalColor != _b.normalColor)
            { return true; }

            if (_a.colors.pressedColor != _b.pressedColor)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_RawImages(RawImage _a, RawImageHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.texture != _b.texture)
            { return true; }

            if (_a.color != _b.color)
            { return true; }

            if (_a.material != _b.material)
            { return true; }

            if (_a.uvRect != _b.uvRect)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Sliders(Slider _a, SliderHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.interactable != _b.interactable)
            { return true; }

            if (_a.wholeNumbers != _b.wholeNumbers)
            { return true; }

            if (_a.transition != _b.transition)
            { return true; }

            if (_a.colors.colorMultiplier != _b.colorMultiplier)
            { return true; }

            if (_a.colors.disabledColor != _b.disabledColor)
            { return true; }

            if (_a.colors.fadeDuration != _b.fadeDuration)
            { return true; }

            if (_a.colors.highlightedColor != _b.highlightedColor)
            { return true; }

            if (_a.colors.normalColor != _b.normalColor)
            { return true; }

            if (_a.colors.pressedColor != _b.pressedColor)
            { return true; }

            if (_a.minValue != _b.minValue)
            { return true; }

            if (_a.maxValue != _b.maxValue)
            { return true; }

            if (_a.value != _b.value)
            { return true; }

            if (_a.targetGraphic != _b.targetGraphic)
            { return true; }

            if (_a.fillRect != _b.fillRect)
            { return true; }

            if (_a.handleRect != _b.handleRect)
            { return true; }

            if (_a.direction != _b.direction)
            { return true; }

            if (_a.onValueChanged != _b.onValueChanged)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Scrollbars(Scrollbar _a, ScrollbarHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.interactable != _b.interactable)
            { return true; }

            if (_a.transition != _b.transition)
            { return true; }

            if (_a.colors.colorMultiplier != _b.colorMultiplier)
            { return true; }

            if (_a.colors.disabledColor != _b.disabledColor)
            { return true; }

            if (_a.colors.fadeDuration != _b.fadeDuration)
            { return true; }

            if (_a.colors.highlightedColor != _b.highlightedColor)
            { return true; }

            if (_a.colors.normalColor != _b.normalColor)
            { return true; }

            if (_a.colors.pressedColor != _b.pressedColor)
            { return true; }

            if (_a.value != _b.value)
            { return true; }

            if (_a.size != _b.size)
            { return true; }

            if (_a.numberOfSteps != _b.numberOfSteps)
            { return true; }

            if (_a.targetGraphic != _b.targetGraphic)
            { return true; }

            if (_a.handleRect != _b.handleRect)
            { return true; }

            if (_a.direction != _b.direction)
            { return true; }

            if (_a.onValueChanged != _b.onValueChanged)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_InputFields(InputField _a, InputFieldHelper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.interactable != _b.interactable)
            { return true; }

            if (_a.transition != _b.transition)
            { return true; }

            if (_a.targetGraphic != _b.targetGraphic)
            { return true; }

            if (_a.colors.colorMultiplier != _b.colorMultiplier)
            { return true; }

            if (_a.colors.disabledColor != _b.disabledColor)
            { return true; }

            if (_a.colors.fadeDuration != _b.fadeDuration)
            { return true; }

            if (_a.colors.highlightedColor != _b.highlightedColor)
            { return true; }

            if (_a.colors.normalColor != _b.normalColor)
            { return true; }

            if (_a.colors.pressedColor != _b.pressedColor)
            { return true; }

            if (_a.textComponent != _b.textComponent)
            { return true; }

            if (_a.text != _b.text)
            { return true; }

            if (_a.characterLimit != _b.characterLimit)
            { return true; }

            if (_a.contentType != _b.contentType)
            { return true; }

            if (_a.lineType != _b.lineType)
            { return true; }

            if (_a.placeholder != _b.placeholder)
            { return true; }

            if (_a.caretBlinkRate != _b.caretBlinkRate)
            { return true; }

            if (_a.selectionColor != _b.selectionColor)
            { return true; }

            if (_a.shouldHideMobileInput != _b.shouldHideMobileInput)
            { return true; }

            if (_a.onValueChange != _b.onValueChange)
            { return true; }

            if (_a.onValidateInput != _b.onValidateInput)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_VerticalLayoutGroups(VerticalLayoutGroup _a, VerticalLayoutG_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.padding.left != _b.padding_left)
            { return true; }

            if (_a.padding.right != _b.padding_right)
            { return true; }

            if (_a.padding.top != _b.padding_top)
            { return true; }

            if (_a.padding.bottom != _b.padding_bottom)
            { return true; }

            if (_a.spacing != _b.spacing)
            { return true; }

            if (_a.childForceExpandHeight != _b.childForceExpand_Height)
            { return true; }

            if (_a.childForceExpandWidth != _b.childForceExpand_Width)
            { return true; }

            if (_a.childAlignment != _b.childAlignment)
            { return true; }


            else
            { return false; }
        }

        public static bool Unlike_HorizontalLayoutGroups(HorizontalLayoutGroup _a, HorizontalLayoutG_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.padding.left != _b.padding_left)
            { return true; }

            if (_a.padding.right != _b.padding_right)
            { return true; }

            if (_a.padding.top != _b.padding_top)
            { return true; }

            if (_a.padding.bottom != _b.padding_bottom)
            { return true; }

            if (_a.spacing != _b.spacing)
            { return true; }

            if (_a.childForceExpandHeight != _b.childForceExpand_Height)
            { return true; }

            if (_a.childForceExpandWidth != _b.childForceExpand_Width)
            { return true; }

            if (_a.childAlignment != _b.childAlignment)
            { return true; }


            else
            { return false; }
        }

        public static bool Unlike_LayoutElements(LayoutElement _a, LayoutElement_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.ignoreLayout != _b.ignoreLayout)
            { return true; }

            if (_a.minWidth != _b.minWidth)
            { return true; }

            if (_a.minHeight != _b.minHeight)
            { return true; }

            if (_a.preferredWidth != _b.preferredWidth)
            { return true; }

            if (_a.preferredHeight != _b.preferredHeight)
            { return true; }

            if (_a.flexibleWidth != _b.flexibleWidth)
            { return true; }

            if (_a.flexibleHeight != _b.flexibleHeight)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_ContentSizeFitter(ContentSizeFitter _a, ContentSizeFitter_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.horizontalFit != _b.horizontalFit)
            { return true; }

            if (_a.verticalFit != _b.verticalFit)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_AspectRatioFitter(AspectRatioFitter _a, AspectRatioFitter_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.aspectMode != _b.aspectMode)
            { return true; }

            if (_a.aspectRatio != _b.aspectRatio)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_GridLayoutGroups(GridLayoutGroup _a, GridLayoutG_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.padding.left != _b.padding_left)
            { return true; }

            if (_a.padding.right != _b.padding_right)
            { return true; }

            if (_a.padding.top != _b.padding_top)
            { return true; }

            if (_a.padding.bottom != _b.padding_bottom)
            { return true; }

            if (_a.spacing != _b.spacing)
            { return true; }

            if (_a.cellSize != _b.cellSize)
            { return true; }

            if (_a.startAxis != _b.startAxis)
            { return true; }

            if (_a.startCorner != _b.startCorner)
            { return true; }

            if (_a.childAlignment != _b.childAlignment)
            { return true; }

            if (_a.constraint != _b.constraint)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Shadows(Shadow _a, Shadow_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.effectColor != _b.effectColor)
            { return true; }

            if (_a.effectDistance != _b.effectDistance)
            { return true; }

            if (_a.useGraphicAlpha != _b.useGraphicAlpha)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_Outlines(Outline _a, Outline_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.effectColor != _b.effectColor)
            { return true; }

            if (_a.effectDistance != _b.effectDistance)
            { return true; }

            if (_a.useGraphicAlpha != _b.useGraphicAlpha)
            { return true; }

            else
            { return false; }
        }

        public static bool Unlike_ScrollRects(ScrollRect _a, ScrollRect_Helper _b)
        {
            if (_a.enabled != _b.enabled)
            { return true; }

            if (_a.content != _b.content)
            { return true; }

            if (_a.horizontal != _b.horizontal)
            { return true; }

            if (_a.vertical != _b.vertical)
            { return true; }

            if (_a.inertia != _b.inertia)
            { return true; }

            if (_a.movementType != _b.movementType)
            { return true; }

            if (_a.elasticity != _b.elasticity)
            { return true; }

            if (_a.decelerationRate != _b.decelerationRate)
            { return true; }

            if (_a.scrollSensitivity != _b.scrollSensitivity)
            { return true; }

            if (_a.horizontalScrollbar != _b.horizontalScrollbar)
            { return true; }

            if (_a.verticalScrollbar != _b.verticalScrollbar)
            { return true; }

            if (_a.onValueChanged != _b.onValueChanged)
            { return true; }

            else
            { return false; }
        }

    }

    public class Applies
    {
        public static void ApplyValues_RectTransform(RectTransform _a, RectTransHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.SetSiblingIndex(_b.silbingIndex);
            _a.pivot = _b.pivot;
            _a.anchorMax = _b.anchorMax;
            _a.anchorMin = _b.anchorMin;
            _a.anchoredPosition = _b.anchoredPosition;
            _a.anchoredPosition3D = _b.anchoredPosition3D;
            _a.position = _b.position;
            _a.localPosition = _b.localPosition;
            _a.eulerAngles = _b.eulerAngles;
            _a.localEulerAngles = _b.localEulerAngles;
            _a.localScale = _b.localScale;
            _a.offsetMax = _b.offsetMax;
            _a.offsetMin = _b.offsetMin;
            _a.sizeDelta = _b.sizeDelta;
            _a.rotation = _b.rotation;
            _a.localRotation = _b.localRotation;
            //_a.rect                 = _b.rect;
            //_a.rect.center          = _b.rect.center;
            //_a.rect.height          = _b.rect.height;
            //_a.rect.max             = _b.rect.max;
            //_a.rect.min             = _b.rect.min;
            //_a.rect.position        = _b.rect.position;
            //_a.rect.size            = _b.rect.size;
            //_a.rect.width           = _b.rect.width;
            //_a.rect.x               = _b.rect.x;
            //_a.rect.xMax            = _b.rect.xMax;
            //_a.rect.xMin            = _b.rect.xMin;
            //_a.rect.y               = _b.rect.y;
            //_a.rect.yMax            = _b.rect.yMax;
            //_a.rect.yMin            = _b.rect.yMin;

        }

        public static void ApplyValues_Image(Image _a, ImageHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.sprite = _b.sprite;
            //_a.overrideSprite = _b.overrideSprite;
            _a.color = _b.color;
            _a.material = _b.material;
            _a.type = _b.type;
            _a.fillCenter = _b.fillCenter;

        }

        public static void ApplyValues_Text(Text _a, TextHelper _b, bool _switchTextContent)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            if (_switchTextContent)
            {
                _a.text = _b.text;
            }
            _a.font = _b.font;
            _a.fontStyle = _b.fontStyle;
            _a.fontSize = _b.fontSize; //READ ONLY
            _a.lineSpacing = _b.lineSpacing;
            _a.alignment = _b.alignment;
            _a.horizontalOverflow = _b.horizontalOverflow;
            _a.verticalOverflow = _b.verticalOverflow;
            _a.color = _b.color;
            _a.resizeTextForBestFit = _b.resizeTextForBestFit;
            _a.supportRichText = _b.supportRichText;
            //_a.defaultMaterial      = _b.defaultMaterial; READ ONLY 
        }

        public static void ApplyValues_Button(Button _a, ButtonHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.onClick = _b.onClick;
            _a.interactable = _b.interactable;
            _a.transition = _b.transition;
            _a.targetGraphic = _b.targetGraphic;

            ColorBlock cb = _a.colors;
            cb.colorMultiplier = _b.colorMultiplier;
            cb.disabledColor = _b.disabledColor;
            cb.fadeDuration = _b.fadeDuration;
            cb.highlightedColor = _b.highlightedColor;
            cb.normalColor = _b.normalColor;
            cb.pressedColor = _b.pressedColor;

            _a.colors = cb;
        }

        public static void ApplyValues_Toggle(Toggle _a, ToggleHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.interactable = _b.interactable;
            _a.transition = _b.transition;
            _a.isOn = _b.isOn;
            _a.toggleTransition = _b.toggleTransition;
            _a.graphic = _b.graphic;
            _a.group = _b.group;
            _a.onValueChanged = _b.onValueChanged;

            ColorBlock cb = _a.colors;
            cb.colorMultiplier = _b.colorMultiplier;
            cb.disabledColor = _b.disabledColor;
            cb.fadeDuration = _b.fadeDuration;
            cb.highlightedColor = _b.highlightedColor;
            cb.normalColor = _b.normalColor;
            cb.pressedColor = _b.pressedColor;

            _a.colors = cb;
        }

        public static void ApplyValues_RawImage(RawImage _a, RawImageHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.texture = _b.texture;
            _a.color = _b.color;
            _a.material = _b.material;
            _a.uvRect = _b.uvRect;
        }

        public static void ApplyValues_Slider(Slider _a, SliderHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.interactable = _b.interactable;
            _a.wholeNumbers = _b.wholeNumbers;
            _a.transition = _b.transition;

            ColorBlock cb = _a.colors;
            cb.colorMultiplier = _b.colorMultiplier;
            cb.disabledColor = _b.disabledColor;
            cb.fadeDuration = _b.fadeDuration;
            cb.highlightedColor = _b.highlightedColor;
            cb.normalColor = _b.normalColor;
            cb.pressedColor = _b.pressedColor;

            _a.colors = cb;

            _a.minValue = _b.minValue;
            _a.maxValue = _b.maxValue;
            _a.value = _b.value;

            _a.targetGraphic = _b.targetGraphic;
            //_as.navigation = _b.navigation;

            _a.fillRect = _b.fillRect;
            _a.handleRect = _b.handleRect;
            _a.direction = _b.direction;
            _a.onValueChanged = _b.onValueChanged;
        }

        public static void ApplyValues_Scrollbar(Scrollbar _a, ScrollbarHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.interactable = _b.interactable;
            _a.transition = _b.transition;

            ColorBlock cb = _a.colors;
            cb.colorMultiplier = _b.colorMultiplier;
            cb.disabledColor = _b.disabledColor;
            cb.fadeDuration = _b.fadeDuration;
            cb.highlightedColor = _b.highlightedColor;
            cb.normalColor = _b.normalColor;
            cb.pressedColor = _b.pressedColor;

            _a.colors = cb;

            _a.value = _b.value;
            _a.size = _b.size;
            _a.numberOfSteps = _b.numberOfSteps;

            _a.targetGraphic = _b.targetGraphic;
            //_as.navigation = _b.navigation;

            _a.handleRect = _b.handleRect;
            _a.direction = _b.direction;
            _a.onValueChanged = _b.onValueChanged;
        }

        public static void ApplyValues_InputField(InputField _a, InputFieldHelper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.interactable = _b.interactable;
            _a.transition = _b.transition;
            _a.targetGraphic = _b.targetGraphic;

            ColorBlock cb = _a.colors;
            cb.colorMultiplier = _b.colorMultiplier;
            cb.disabledColor = _b.disabledColor;
            cb.fadeDuration = _b.fadeDuration;
            cb.highlightedColor = _b.highlightedColor;
            cb.normalColor = _b.normalColor;
            cb.pressedColor = _b.pressedColor;

            _a.colors = cb;

            _a.textComponent = _b.textComponent;
            _a.text = _b.text;
            _a.characterLimit = _b.characterLimit;
            _a.contentType = _b.contentType;
            _a.lineType = _b.lineType;
            _a.placeholder = _b.placeholder;
            _a.caretBlinkRate = _b.caretBlinkRate;
            _a.selectionColor = _b.selectionColor;
            _a.shouldHideMobileInput = _b.shouldHideMobileInput;
            _a.onValueChange = _b.onValueChange;
            _a.onValidateInput = _b.onValidateInput;
        }

        public static void ApplyValues_VerticalLayoutGroup(VerticalLayoutGroup _a, VerticalLayoutG_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.padding.left = _b.padding_left;
            _a.padding.right = _b.padding_right;
            _a.padding.top = _b.padding_top;
            _a.padding.bottom = _b.padding_bottom;
            _a.spacing = _b.spacing;

            _a.childForceExpandWidth = _b.childForceExpand_Width;
            _a.childForceExpandHeight = _b.childForceExpand_Height;

            _a.childAlignment = _b.childAlignment;

        }

        public static void ApplyValues_HorizontalLayoutGroup(HorizontalLayoutGroup _a, HorizontalLayoutG_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.padding.left = _b.padding_left;
            _a.padding.right = _b.padding_right;
            _a.padding.top = _b.padding_top;
            _a.padding.bottom = _b.padding_bottom;
            _a.spacing = _b.spacing;

            _a.childForceExpandWidth = _b.childForceExpand_Width;
            _a.childForceExpandHeight = _b.childForceExpand_Height;

            _a.childAlignment = _b.childAlignment;
        }

        public static void ApplyValues_LayoutElement(LayoutElement _a, LayoutElement_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.ignoreLayout = _b.ignoreLayout;

            _a.minWidth = _b.minWidth;
            _a.minHeight = _b.minHeight;
            _a.preferredWidth = _b.preferredWidth;
            _a.preferredHeight = _b.preferredHeight;
            _a.flexibleWidth = _b.flexibleWidth;
            _a.flexibleHeight = _b.flexibleHeight;

        }

        public static void ApplyValues_ContentSizeFitter(ContentSizeFitter _a, ContentSizeFitter_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.horizontalFit = _b.horizontalFit;
            _a.verticalFit = _b.verticalFit;
        }

        public static void ApplyValues_AspectRatioFitter(AspectRatioFitter _a, AspectRatioFitter_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;
            _a.aspectMode = _b.aspectMode;
            _a.aspectRatio = _b.aspectRatio;
        }

        public static void ApplyValues_GridLayoutGroup(GridLayoutGroup _a, GridLayoutG_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;

            _a.padding.left = _b.padding_left;
            _a.padding.right = _b.padding_right;
            _a.padding.top = _b.padding_top;
            _a.padding.bottom = _b.padding_bottom;

            _a.cellSize = _b.cellSize;
            _a.spacing = _b.spacing;
            _a.startAxis = _b.startAxis;
            _a.startCorner = _b.startCorner;
            _a.constraint = _b.constraint;
            _a.childAlignment = _b.childAlignment;
        }

        public static void ApplyValues_Shadow(Shadow _a, Shadow_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;

            _a.effectColor = _b.effectColor;
            _a.effectDistance = _b.effectDistance;
            _a.useGraphicAlpha = _b.useGraphicAlpha;

        }

        public static void ApplyValues_Outline(Outline _a, Outline_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;

            _a.effectColor = _b.effectColor;
            _a.effectDistance = _b.effectDistance;
            _a.useGraphicAlpha = _b.useGraphicAlpha;

        }

        public static void ApplyValues_ScrollRect(ScrollRect _a, ScrollRect_Helper _b)
        {
#if UNITY_EDITOR
            Undo.RecordObject(_a, "change current Layout");
#endif
            _a.enabled = _b.enabled;

            _a.content = _b.content;
            _a.horizontal = _b.horizontal;
            _a.vertical = _b.vertical;
            _a.inertia = _b.inertia;
            _a.movementType = _b.movementType;
            _a.elasticity = _b.elasticity;
            _a.decelerationRate = _b.decelerationRate;
            _a.scrollSensitivity = _b.scrollSensitivity;
            _a.horizontalScrollbar = _b.horizontalScrollbar;
            _a.verticalScrollbar = _b.verticalScrollbar;
            _a.onValueChanged = _b.onValueChanged;
        }
    }

    public class Trigger
    {
        public RectTransform[] rectTransformsInScene;
        public LL_Layout ll;

        RectTransform GetCorrectRectTransformViaHelper(string _GUIDtoSearchFor)
        {
            if (string.IsNullOrEmpty(_GUIDtoSearchFor))
            {
                Debug.LogError("--LAZYLAYOUT ERROR-- NO GUID GIVEN @ TRIGGER-LAYOUT -");
                return null;
            }

            if (rectTransformsInScene == null)
            {
                Debug.LogError("--LAZYLAYOUT ERROR-- NO RECT-TRANSFORMS IN SCENE @ TRIGGER-LAYOUT -");
                return null;
            }

            int count = rectTransformsInScene.Length;

            if (count <= 0)
            {
                Debug.LogError("--LAZYLAYOUT ERROR-- RECT-TRANSFORM COUNT IN SCENE IS ZERO @ TRIGGER-LAYOUT -");
                return null;
            }

            for (int i = 0; i < count; i++)
            {
                if (rectTransformsInScene[i].GetComponent<LazyLayoutHelper>() == null)
                {
                    if (rectTransformsInScene[i].name.Contains("Input Caret"))
                    {
                        return rectTransformsInScene[i];
                    }

                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform because it has no LazyLayout_Helper Component. This happens mostly if an object gets created at runtime. GO-Name is: " + rectTransformsInScene[i].gameObject.name + " - ");
                    return null;

                }

                if (rectTransformsInScene[i].GetComponent<LazyLayoutHelper>().ll_GUID == _GUIDtoSearchFor)
                {
                    return rectTransformsInScene[i];
                }
            }

            Debug.LogError("--LAZYLAYOUT ERROR-- Could not find object for instanceID -" + _GUIDtoSearchFor + "-");
            return null;
        }

        public void TriggerLayout(bool _switchTextContent)
        {
            int count = rectTransformsInScene.Length;

            //CHECK GO-ACTIVE-STATE
            CheckGOActive(ll, count);

            TriggerRectTransforms(ll, count);
            TriggerImages(ll, count);
            TriggerTexts(ll, count, _switchTextContent);
            TriggerButtons(ll, count);
            TriggerToggles(ll, count);
            TriggerRawImages(ll, count);
            TriggerSliders(ll, count);
            TriggerScrollbars(ll, count);
            TriggerInputFields(ll, count);
            TriggerVerticalLayoutGroups(ll, count);
            TriggerHorizontalLayoutGroups(ll, count);
            TriggerLayoutElements(ll, count);
            TriggerContentSizeFitter(ll, count);
            TriggerAspectRatioFitter(ll, count);
            TriggerGridLayoutGroups(ll, count);
            TriggerShadows(ll, count);
            TriggerOutlines(ll, count);
            TriggerScrollRects(ll, count);


            if (ll.capableOf_Custom)
            {
                Debug.Log("--LazyLayout-- Loaded Layout: " + ll.layoutName + " - Layout Type: CUSTOM");
            }
            else if (ll.capableOf_Other)
            {
                Debug.Log("--LazyLayout-- Loaded Layout: " + ll.layoutName + " - Layout Type: OTHER");
            }
            else
            {
                Debug.Log("--LazyLayout-- Loaded Layout: " + ll.layoutName);
            }
        }

        void CheckGOActive(LazyLayout.LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);

                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }

                if (_ll.savedRectTransformsInScene[i].GOisActive)
                {
                    rt.gameObject.SetActive(true);
                }
                else
                {
                    rt.gameObject.SetActive(false);
                }


            }
        }

        public void TriggerRectTransforms(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Applies.ApplyValues_RectTransform(rt, _ll.savedRectTransformsInScene[i].rectTransHelper);
            }
        }

        public void TriggerImages(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Image[] imageComponents = rt.GetComponents<Image>();

                for (int j = 0; j < imageComponents.Length; j++)
                {
                    Applies.ApplyValues_Image(imageComponents[j], _ll.savedRectTransformsInScene[i].imageComponentsHelper[j]);
                }
            }
        }

        public void TriggerTexts(LL_Layout _ll, int count, bool _switchTextContent)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Text[] textComponents = rt.GetComponents<Text>();

                for (int j = 0; j < textComponents.Length; j++)
                {
                    Applies.ApplyValues_Text(textComponents[j], _ll.savedRectTransformsInScene[i].textComponentsHelper[j], _switchTextContent);
                }
            }
        }

        public void TriggerButtons(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Button[] buttonComponents = rt.GetComponents<Button>();

                for (int j = 0; j < buttonComponents.Length; j++)
                {
                    Applies.ApplyValues_Button(buttonComponents[j], _ll.savedRectTransformsInScene[i].buttonComponentsHelper[j]);
                }
            }
        }

        public void TriggerToggles(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Toggle[] toggleComponents = rt.GetComponents<Toggle>();

                for (int j = 0; j < toggleComponents.Length; j++)
                {
                    Applies.ApplyValues_Toggle(toggleComponents[j], _ll.savedRectTransformsInScene[i].toggleComponentsHelper[j]);
                }
            }
        }

        public void TriggerRawImages(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                RawImage[] rawImageComponents = rt.GetComponents<RawImage>();

                for (int j = 0; j < rawImageComponents.Length; j++)
                {
                    Applies.ApplyValues_RawImage(rawImageComponents[j], _ll.savedRectTransformsInScene[i].rawImageComponentsHelper[j]);
                }
            }
        }

        public void TriggerSliders(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Slider[] sliderComponents = rt.GetComponents<Slider>();

                for (int j = 0; j < sliderComponents.Length; j++)
                {
                    Applies.ApplyValues_Slider(sliderComponents[j], _ll.savedRectTransformsInScene[i].sliderComponentsHelper[j]);
                }
            }
        }

        public void TriggerScrollbars(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Scrollbar[] scrollbarComponents = rt.GetComponents<Scrollbar>();

                for (int j = 0; j < scrollbarComponents.Length; j++)
                {
                    Applies.ApplyValues_Scrollbar(scrollbarComponents[j], _ll.savedRectTransformsInScene[i].scrollbarComponentsHelper[j]);
                }
            }
        }

        public void TriggerInputFields(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                InputField[] inputFieldComponents = rt.GetComponents<InputField>();

                for (int j = 0; j < inputFieldComponents.Length; j++)
                {
                    Applies.ApplyValues_InputField(inputFieldComponents[j], _ll.savedRectTransformsInScene[i].inputFieldComponentsHelper[j]);
                }
            }
        }

        public void TriggerVerticalLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                VerticalLayoutGroup[] verticalLayoutGroupComponents = rt.GetComponents<VerticalLayoutGroup>();

                for (int j = 0; j < verticalLayoutGroupComponents.Length; j++)
                {
                    Applies.ApplyValues_VerticalLayoutGroup(verticalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].verticalLayoutGroupComponentsHelper[j]);
                }
            }
        }

        public void TriggerHorizontalLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                HorizontalLayoutGroup[] horizontalLayoutGroupComponents = rt.GetComponents<HorizontalLayoutGroup>();

                for (int j = 0; j < horizontalLayoutGroupComponents.Length; j++)
                {
                    Applies.ApplyValues_HorizontalLayoutGroup(horizontalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].horizontalLayoutGroupComponentsHelper[j]);
                }
            }
        }

        public void TriggerLayoutElements(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                LayoutElement[] layoutElementComponents = rt.GetComponents<LayoutElement>();

                for (int j = 0; j < layoutElementComponents.Length; j++)
                {
                    Applies.ApplyValues_LayoutElement(layoutElementComponents[j], _ll.savedRectTransformsInScene[i].layoutElementComponentsHelper[j]);
                }
            }
        }

        public void TriggerContentSizeFitter(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                ContentSizeFitter[] contentSizeFitterComponents = rt.GetComponents<ContentSizeFitter>();

                for (int j = 0; j < contentSizeFitterComponents.Length; j++)
                {
                    Applies.ApplyValues_ContentSizeFitter(contentSizeFitterComponents[j], _ll.savedRectTransformsInScene[i].contentSizeFitterHelper[j]);
                }
            }
        }

        public void TriggerAspectRatioFitter(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                AspectRatioFitter[] apectRatioComponents = rt.GetComponents<AspectRatioFitter>();

                for (int j = 0; j < apectRatioComponents.Length; j++)
                {
                    Applies.ApplyValues_AspectRatioFitter(apectRatioComponents[j], _ll.savedRectTransformsInScene[i].aspectRatioFitterHelper[j]);
                }
            }
        }

        public void TriggerGridLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                GridLayoutGroup[] gridLayoutGroupComponents = rt.GetComponents<GridLayoutGroup>();

                for (int j = 0; j < gridLayoutGroupComponents.Length; j++)
                {
                    Applies.ApplyValues_GridLayoutGroup(gridLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].gridLayoutGroupHelperList[j]);
                }
            }
        }

        public void TriggerShadows(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Shadow[] shadowComponents = rt.GetComponents<Shadow>();

                for (int j = 0; j < shadowComponents.Length; j++)
                {
                    Applies.ApplyValues_Shadow(shadowComponents[j], _ll.savedRectTransformsInScene[i].shadowComponentsHelperList[j]);
                }
            }
        }

        public void TriggerOutlines(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                Outline[] outlineComponents = rt.GetComponents<Outline>();

                for (int j = 0; j < outlineComponents.Length; j++)
                {
                    Applies.ApplyValues_Outline(outlineComponents[j], _ll.savedRectTransformsInScene[i].outlineComponentsHelperList[j]);
                }
            }
        }

        public void TriggerScrollRects(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrectRectTransformViaHelper(_ll.savedRectTransformsInScene[i].ll_GUID);
                if (rt == null)
                {
                    Debug.LogWarning("--LazyLayout - Warning- Skipped a rectTransform. Maybe this one was created during runtime? -");
                    return;
                }
                if (rt.name.Contains("Input Caret"))
                {
                    return;
                }
                ScrollRect[] scrollRectComponents = rt.GetComponents<ScrollRect>();

                for (int j = 0; j < scrollRectComponents.Length; j++)
                {
                    Applies.ApplyValues_ScrollRect(scrollRectComponents[j], _ll.savedRectTransformsInScene[i].scrollRectComponentsHelperList[j]);
                }
            }
        }
    }

    public class LayoutApplier
    {
        public LL_Layout ll;
        public RectTransform[] rectTransformsInScene;



        RectTransform GetCorrentRectTransform(string _GUIDtoSearchFor)
        {
            if (rectTransformsInScene != null)
            {
                int count = rectTransformsInScene.Length;
                for (int i = 0; i < count; i++)
                {
                    if (rectTransformsInScene[i].GetComponent<LazyLayoutHelper>().ll_GUID == _GUIDtoSearchFor)
                    {
                        return rectTransformsInScene[i];
                    }
                }

                Debug.LogError("--LAZYLAYOUT ERROR-- Could not find object for instanceID -" + _GUIDtoSearchFor + "-");
                return null;
            }

            Debug.LogError("--LAZYLAYOUT ERROR-- ERROR WHILE APPLYING LAYOUT => NO RECTTRANSFORMS FOUND");
            return null;
        }


        public void ApplyLayout(bool _switchTextContent)
        {
            int count = ll.savedRectTransformsInScene.Count;

            //CHECK GO-ACTIVE-STATE
            CheckGOActive(ll, count);

            //CHECK ALL RECT-TRANSFORMS
            CheckRectTransforms(ll, count);

            //CHECK COMPONENTS
            CheckImages(ll, count);
            CheckTexts(ll, count, _switchTextContent);
            CheckButtons(ll, count);
            CheckToggles(ll, count);
            CheckRawImages(ll, count);
            CheckSliders(ll, count);
            CheckScrollbars(ll, count);
            CheckInputFields(ll, count);
            CheckVerticalLayoutGroups(ll, count);
            CheckHorizontalLayoutGroups(ll, count);
            CheckLayoutElements(ll, count);
            CheckContentSizeFitters(ll, count);
            CheckAspectRatioFitters(ll, count);
            CheckGridLayoutGroups(ll, count);
            CheckShadows(ll, count);
            CheckOutlines(ll, count);
            CheckScrollRects(ll, count);
        }



        public void CheckGOActive(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);

                if (_ll.savedRectTransformsInScene[i].GOisActive)
                {
                    //CacheDumpChanges("GO ACTIVE STATE -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                    rt.gameObject.SetActive(true);
                }
                else
                {
                    //CacheDumpChanges("GO ACTIVE STATE -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                    rt.gameObject.SetActive(false);
                }
            }
        }

        public void CheckRectTransforms(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);

                if (Unlikes.Unlike_RectTransforms(rt, _ll.savedRectTransformsInScene[i].rectTransHelper))
                {
                    //CacheDumpChanges("RectTransform -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                    Applies.ApplyValues_RectTransform(rt, _ll.savedRectTransformsInScene[i].rectTransHelper);
                }
            }
        }

        public void CheckImages(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Image[] imageComponents = rt.GetComponents<Image>();

                if (imageComponents.Length > 0)
                {
                    for (int j = 0; j < imageComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Images(imageComponents[j], _ll.savedRectTransformsInScene[i].imageComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Image @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Image(imageComponents[j], _ll.savedRectTransformsInScene[i].imageComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckTexts(LL_Layout _ll, int count, bool _switchTextContent)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Text[] textComponents = rt.GetComponents<Text>();

                if (textComponents.Length > 0)
                {
                    for (int j = 0; j < textComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Texts(textComponents[j], _ll.savedRectTransformsInScene[i].textComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Text @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Text(textComponents[j], _ll.savedRectTransformsInScene[i].textComponentsHelper[j], _switchTextContent);
                        }
                    }
                }
            }
        }

        public void CheckButtons(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Button[] buttonComponents = rt.GetComponents<Button>();

                if (buttonComponents.Length > 0)
                {
                    for (int j = 0; j < buttonComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Buttons(buttonComponents[j], _ll.savedRectTransformsInScene[i].buttonComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Button @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Button(buttonComponents[j], _ll.savedRectTransformsInScene[i].buttonComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckToggles(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Toggle[] toggleComponents = rt.GetComponents<Toggle>();

                if (toggleComponents.Length > 0)
                {
                    for (int j = 0; j < toggleComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Toggles(toggleComponents[j], _ll.savedRectTransformsInScene[i].toggleComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Toggle @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Toggle(toggleComponents[j], _ll.savedRectTransformsInScene[i].toggleComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckRawImages(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                RawImage[] rawImageComponents = rt.GetComponents<RawImage>();

                if (rawImageComponents.Length > 0)
                {
                    for (int j = 0; j < rawImageComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_RawImages(rawImageComponents[j], _ll.savedRectTransformsInScene[i].rawImageComponentsHelper[j]))
                        {
                            //CacheDumpChanges("RawImage @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_RawImage(rawImageComponents[j], _ll.savedRectTransformsInScene[i].rawImageComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckSliders(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Slider[] sliderComponents = rt.GetComponents<Slider>();

                if (sliderComponents.Length > 0)
                {
                    for (int j = 0; j < sliderComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Sliders(sliderComponents[j], _ll.savedRectTransformsInScene[i].sliderComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Slider @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Slider(sliderComponents[j], _ll.savedRectTransformsInScene[i].sliderComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckScrollbars(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Scrollbar[] scrollbarComponents = rt.GetComponents<Scrollbar>();

                if (scrollbarComponents.Length > 0)
                {
                    for (int j = 0; j < scrollbarComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Scrollbars(scrollbarComponents[j], _ll.savedRectTransformsInScene[i].scrollbarComponentsHelper[j]))
                        {
                            //CacheDumpChanges("Scrollbar @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Scrollbar(scrollbarComponents[j], _ll.savedRectTransformsInScene[i].scrollbarComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckInputFields(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                InputField[] inputFieldComponents = rt.GetComponents<InputField>();

                if (inputFieldComponents.Length > 0)
                {
                    for (int j = 0; j < inputFieldComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_InputFields(inputFieldComponents[j], _ll.savedRectTransformsInScene[i].inputFieldComponentsHelper[j]))
                        {
                            //CacheDumpChanges("InputField @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_InputField(inputFieldComponents[j], _ll.savedRectTransformsInScene[i].inputFieldComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckVerticalLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                VerticalLayoutGroup[] verticalLayoutGroupComponents = rt.GetComponents<VerticalLayoutGroup>();

                if (verticalLayoutGroupComponents.Length > 0)
                {
                    for (int j = 0; j < verticalLayoutGroupComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_VerticalLayoutGroups(verticalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].verticalLayoutGroupComponentsHelper[j]))
                        {
                            //CacheDumpChanges("VerticalLayoutGroup @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_VerticalLayoutGroup(verticalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].verticalLayoutGroupComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckHorizontalLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                HorizontalLayoutGroup[] horizontalLayoutGroupComponents = rt.GetComponents<HorizontalLayoutGroup>();

                if (horizontalLayoutGroupComponents.Length > 0)
                {
                    for (int j = 0; j < horizontalLayoutGroupComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_HorizontalLayoutGroups(horizontalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].horizontalLayoutGroupComponentsHelper[j]))
                        {
                            //CacheDumpChanges("HorizontalLayoutGroup @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_HorizontalLayoutGroup(horizontalLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].horizontalLayoutGroupComponentsHelper[j]);
                        }
                    }
                }

            }
        }

        public void CheckLayoutElements(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                LayoutElement[] layoutElementComponents = rt.GetComponents<LayoutElement>();

                if (layoutElementComponents.Length > 0)
                {
                    for (int j = 0; j < layoutElementComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_LayoutElements(layoutElementComponents[j], _ll.savedRectTransformsInScene[i].layoutElementComponentsHelper[j]))
                        {
                            //CacheDumpChanges("LayoutElement @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_LayoutElement(layoutElementComponents[j], _ll.savedRectTransformsInScene[i].layoutElementComponentsHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckContentSizeFitters(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                ContentSizeFitter[] contentSizeFitterComponents = rt.GetComponents<ContentSizeFitter>();

                if (contentSizeFitterComponents.Length > 0)
                {
                    for (int j = 0; j < contentSizeFitterComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_ContentSizeFitter(contentSizeFitterComponents[j], _ll.savedRectTransformsInScene[i].contentSizeFitterHelper[j]))
                        {
                            //CacheDumpChanges("ContentSizeFitter @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_ContentSizeFitter(contentSizeFitterComponents[j], _ll.savedRectTransformsInScene[i].contentSizeFitterHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckAspectRatioFitters(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                AspectRatioFitter[] apectRatioComponents = rt.GetComponents<AspectRatioFitter>();

                if (apectRatioComponents.Length > 0)
                {
                    for (int j = 0; j < apectRatioComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_AspectRatioFitter(apectRatioComponents[j], _ll.savedRectTransformsInScene[i].aspectRatioFitterHelper[j]))
                        {
                            //CacheDumpChanges("AspectRatioFitter @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_AspectRatioFitter(apectRatioComponents[j], _ll.savedRectTransformsInScene[i].aspectRatioFitterHelper[j]);
                        }
                    }
                }
            }
        }

        public void CheckGridLayoutGroups(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                GridLayoutGroup[] gridLayoutGroupComponents = rt.GetComponents<GridLayoutGroup>();

                if (gridLayoutGroupComponents.Length > 0)
                {
                    for (int j = 0; j < gridLayoutGroupComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_GridLayoutGroups(gridLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].gridLayoutGroupHelperList[j]))
                        {
                            //CacheDumpChanges("GridLayout @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_GridLayoutGroup(gridLayoutGroupComponents[j], _ll.savedRectTransformsInScene[i].gridLayoutGroupHelperList[j]);
                        }
                    }
                }
            }
        }

        public void CheckShadows(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Shadow[] shadowComponents = rt.GetComponents<Shadow>();

                if (shadowComponents.Length > 0)
                {
                    for (int j = 0; j < shadowComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Shadows(shadowComponents[j], _ll.savedRectTransformsInScene[i].shadowComponentsHelperList[j]))
                        {
                            //CacheDumpChanges("Shadow @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Shadow(shadowComponents[j], _ll.savedRectTransformsInScene[i].shadowComponentsHelperList[j]);
                        }
                    }
                }
            }
        }

        public void CheckOutlines(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                Outline[] outlineComponents = rt.GetComponents<Outline>();

                if (outlineComponents.Length > 0)
                {
                    for (int j = 0; j < outlineComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_Outlines(outlineComponents[j], _ll.savedRectTransformsInScene[i].outlineComponentsHelperList[j]))
                        {
                            //CacheDumpChanges("Outline @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_Outline(outlineComponents[j], _ll.savedRectTransformsInScene[i].outlineComponentsHelperList[j]);
                        }
                    }
                }
            }
        }

        public void CheckScrollRects(LL_Layout _ll, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RectTransform rt = GetCorrentRectTransform(_ll.savedRectTransformsInScene[i].ll_GUID);
                ScrollRect[] scrollRectComponents = rt.GetComponents<ScrollRect>();

                if (scrollRectComponents.Length > 0)
                {
                    for (int j = 0; j < scrollRectComponents.Length; j++)
                    {
                        if (Unlikes.Unlike_ScrollRects(scrollRectComponents[j], _ll.savedRectTransformsInScene[i].scrollRectComponentsHelperList[j]))
                        {
                            //CacheDumpChanges("ScrollRect @ -" + _ll.savedRectTransformsInScene[i].name + "- is different. Changing! \n");
                            Applies.ApplyValues_ScrollRect(scrollRectComponents[j], _ll.savedRectTransformsInScene[i].scrollRectComponentsHelperList[j]);
                        }
                    }
                }
            }
        }

    }

    //[InitializeOnLoad]
    [ExecuteInEditMode]
    public class DuplicateChecker : MonoBehaviour
    {
        //public static List<LazyLayoutHelper> ll_HelperList = new List<LazyLayoutHelper>();
        //
        //static DuplicateChecker()
        //{
        //    WaitForDuplicateEnd();
        //    EditorApplication.update += WaitForDuplicateEnd;
        //}
        //
        //
        //static void CheckForDuplicates()
        //{
        //    RectTransform[] rectTransformsInScene = FindObjectOfType<Canvas>().gameObject.GetComponentsInChildren<RectTransform>(true);
        //    Debug.Log("rectTransformsInScene: " + rectTransformsInScene.Length);
        //    Debug.Log("ll_HelperList.Count 1 : " + ll_HelperList.Count);
        //    Debug.Log("LazyLayoutHelper ID: " + ll_HelperList[0].ll_GUID);
        //    for (int i = 0; i < ll_HelperList.Count; i++)
        //    {
        //        for (int j = 0; j < rectTransformsInScene.Length; j++)
        //        {
        //            if (ll_HelperList[i].ll_GUID == rectTransformsInScene[j].GetComponent<LazyLayoutHelper>().ll_GUID)
        //            {
        //                Debug.Log("ll_HelperList.Count 2: " + ll_HelperList.Count);
        //                Debug.Log("LazyLayoutHelper: " + ll_HelperList[i]);
        //                Debug.Log("rectTransformsInScene[j].GetComponent<LazyLayoutHelper>().ll_GUID: " + rectTransformsInScene[j].GetComponent<LazyLayoutHelper>().ll_GUID);
        //                Debug.Log("--LazyLayout - Recognized duplicate object => Deleting helper in order to keep layoutList intact");
        //                DestroyImmediate(ll_HelperList[i].GetComponent<LazyLayoutHelper>());
        //            }
        //        }
        //    }
        //
        //    //ll_HelperList.Clear();
        //}
        //
        //static void WaitForDuplicateEnd()
        //{
        //    int duplicateCount = ll_HelperList.Count;
        //    if (duplicateCount == 0)
        //    {
        //        return;
        //    }
        //    Debug.Log("Starting routine");
        //    if(ll_HelperList.Count != duplicateCount)
        //    {
        //        return;
        //    }
        //    else
        //    {
        //        Debug.Log("starting duplcheck");
        //        CheckForDuplicates();
        //    }
        //}


    }
    

}