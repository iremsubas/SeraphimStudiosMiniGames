using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace LazyLayout
{
    [System.Serializable]
    [SerializeField]
    public class LL_Layout
    {
        public string layoutName;
        public int layoutID;

        public float minDeviceSizeForLayout = 6.5F,
                     customAR_Length, customAR_Height;

        public enum AspectRatio { SixteenNine_Landscape, SixteenNine_Portrait, FourThree_Landscape, FourThree_Portrait, ThreeTwo_Landscape, ThreeTwo_Portrait, Other, Custom };

        public AspectRatio aspectRatioForLayout = AspectRatio.SixteenNine_Landscape;

        public bool capableOf_16_9_Landscape,
                    capableOf_16_9_Portrait,
                    capableOf_4_3_Landscape,
                    capableOf_4_3_Portrait,
                    capableOf_3_2_Landscape,
                    capableOf_3_2_Portrait,
                    capableOf_Other = true,
                    capableOf_Custom,
            
                    excludeTexts;

        public List<RectTransObject> savedRectTransformsInScene = new List<RectTransObject>();


        public void AddnewRectObject(RectTransform _rectTransform, string _ll_GUID)
        {
            RectTransObject rto = new RectTransObject();
            rto.name = _rectTransform.gameObject.name;
            rto.ll_GUID = _ll_GUID;
            rto.GOisActive = _rectTransform.gameObject.activeSelf;

            #region ----- SAVE COMPONENTS -----

            // SAVE THE RECT-TRANSFORM ITSELF
            rto.FillRectTransHelper(_rectTransform);

            // SAVE ALL IMAGES
            Image[] imageComponents = _rectTransform.GetComponents<Image>();
            for (int i = 0; i < imageComponents.Length; i++)
            { rto.FillImageHelperList(imageComponents[i]); }

            // SAVE ALL TEXTS
            Text[] textComponents = _rectTransform.GetComponents<Text>();
            for (int i = 0; i < textComponents.Length; i++)
            { rto.FillTextHelperList(textComponents[i]); }

            // SAVE ALL BUTTONS
            Button[] buttonComponents = _rectTransform.GetComponents<Button>();
            for (int i = 0; i < buttonComponents.Length; i++)
            { rto.FillButtonsHelperList(buttonComponents[i]); }

            // SAVE ALL TOGGLES
            Toggle[] toggleComponents = _rectTransform.GetComponents<Toggle>();
            for (int i = 0; i < toggleComponents.Length; i++)
            { rto.FillTogglesHelperList(toggleComponents[i]); }

            // SAVE ALL RAW-IMAGES
            RawImage[] rawImageComponents = _rectTransform.GetComponents<RawImage>();
            for (int i = 0; i < rawImageComponents.Length; i++)
            { rto.FillRawImageHelperList(rawImageComponents[i]); }

            // SAVE ALL SLIDER
            Slider[] sliderComponents = _rectTransform.GetComponents<Slider>();
            for (int i = 0; i < sliderComponents.Length; i++)
            { rto.FillSliderHelperList(sliderComponents[i]); }

            // SAVE ALL SCROLLBARS
            Scrollbar[] scrollbarComponents = _rectTransform.GetComponents<Scrollbar>();
            for (int i = 0; i < scrollbarComponents.Length; i++)
            { rto.FillScrollbarHelperList(scrollbarComponents[i]); }

            // SAVE ALL INPUT_FIELDS
            InputField[] inputFieldComponents = _rectTransform.GetComponents<InputField>();
            for (int i = 0; i < inputFieldComponents.Length; i++)
            { rto.FillInputFieldHelperList(inputFieldComponents[i]); }

            // SAVE ALL VerticalLayoutGroups
            VerticalLayoutGroup[] verticalLayoutGroupComponents = _rectTransform.GetComponents<VerticalLayoutGroup>();
            for (int i = 0; i < verticalLayoutGroupComponents.Length; i++)
            { rto.FillVerticalLayoutGroupHelperList(verticalLayoutGroupComponents[i]); }

            // SAVE ALL HorizontalLayoutGroups
            HorizontalLayoutGroup[] horizontalLayoutGroupComponents = _rectTransform.GetComponents<HorizontalLayoutGroup>();
            for (int i = 0; i < horizontalLayoutGroupComponents.Length; i++)
            { rto.FillHorizontalLayoutGroupHelperList(horizontalLayoutGroupComponents[i]); }

            // SAVE ALL LayoutElements
            LayoutElement[] layoutElementComponents = _rectTransform.GetComponents<LayoutElement>();
            for (int i = 0; i < layoutElementComponents.Length; i++)
            { rto.FillLayoutElementHelperList(layoutElementComponents[i]); }

            // SAVE ALL ContentSizeFitters
            ContentSizeFitter[] contentSizeFitterComponents = _rectTransform.GetComponents<ContentSizeFitter>();
            for (int i = 0; i < contentSizeFitterComponents.Length; i++)
            { rto.FillContentSizeFitterComponentsHelperList(contentSizeFitterComponents[i]); }

            //SAVE ALL AspectRatioFitter
            AspectRatioFitter[] aspectRatioFitterComponents = _rectTransform.GetComponents<AspectRatioFitter>();
            for (int i = 0; i < aspectRatioFitterComponents.Length; i++)
            { rto.FillAspectRatioFitterComponentsHelperList(aspectRatioFitterComponents[i]); }

            //SAVE ALL GridLayoutGroups
            GridLayoutGroup[] gridLayoutGroupComponents = _rectTransform.GetComponents<GridLayoutGroup>();
            for (int i = 0; i < gridLayoutGroupComponents.Length; i++)
            { rto.FillGridLayoutGroupHelperList(gridLayoutGroupComponents[i]); }

            //SAVE ALL ShadowComponents
            Shadow[] shadowComponents = _rectTransform.GetComponents<Shadow>();
            for (int i = 0; i < shadowComponents.Length; i++)
            { rto.FillShadowComponentsHelperList(shadowComponents[i]); }

            //SAVE ALL OutlineComponents
            Outline[] outlineComponents = _rectTransform.GetComponents<Outline>();
            for (int i = 0; i < outlineComponents.Length; i++)
            { rto.FillOutlineComponentsHelperList(outlineComponents[i]); }

            //SAVE ALL ScrollRectComponents
            ScrollRect[] scrollRectComponents = _rectTransform.GetComponents<ScrollRect>();
            for (int i = 0; i < scrollRectComponents.Length; i++)
            { rto.FillScrollRectComponentsHelperList(scrollRectComponents[i]); }

            #endregion


            savedRectTransformsInScene.Add(rto);
        }



        RectTransObject FindRTOByID(string _givenID)
        {
            int count = savedRectTransformsInScene.Count;
            for (int i = 0; i < count; i++)
            {
                if (savedRectTransformsInScene[i].ll_GUID == _givenID)
                {
                    return savedRectTransformsInScene[i];
                }
            }

            Debug.LogError("--LAZYLAYOUT ERROR-- Could not find correct RTO-Objct while updating layout. Given ID was: " + _givenID);
            return null;

        }





        //------- rect-transform object ---------
        [System.Serializable]
        public class RectTransObject
        {
            public string name;
            public string ll_GUID;
            public bool GOisActive;
            public RectTransHelper rectTransHelper = new RectTransHelper();

            public List<ImageHelper> imageComponentsHelper = new List<ImageHelper>();
            public List<TextHelper> textComponentsHelper = new List<TextHelper>();
            public List<ButtonHelper> buttonComponentsHelper = new List<ButtonHelper>();
            public List<ToggleHelper> toggleComponentsHelper = new List<ToggleHelper>();
            public List<RawImageHelper> rawImageComponentsHelper = new List<RawImageHelper>();
            public List<SliderHelper> sliderComponentsHelper = new List<SliderHelper>();
            public List<ScrollbarHelper> scrollbarComponentsHelper = new List<ScrollbarHelper>();
            public List<InputFieldHelper> inputFieldComponentsHelper = new List<InputFieldHelper>();
            public List<VerticalLayoutG_Helper> verticalLayoutGroupComponentsHelper = new List<VerticalLayoutG_Helper>();
            public List<HorizontalLayoutG_Helper> horizontalLayoutGroupComponentsHelper = new List<HorizontalLayoutG_Helper>();
            public List<LayoutElement_Helper> layoutElementComponentsHelper = new List<LayoutElement_Helper>();
            public List<ContentSizeFitter_Helper> contentSizeFitterHelper = new List<ContentSizeFitter_Helper>();
            public List<AspectRatioFitter_Helper> aspectRatioFitterHelper = new List<AspectRatioFitter_Helper>();
            public List<GridLayoutG_Helper> gridLayoutGroupHelperList = new List<GridLayoutG_Helper>();
            public List<Shadow_Helper> shadowComponentsHelperList = new List<Shadow_Helper>();
            public List<Outline_Helper> outlineComponentsHelperList = new List<Outline_Helper>();
            public List<ScrollRect_Helper> scrollRectComponentsHelperList = new List<ScrollRect_Helper>();

            //public Image[]      imageComponents;
            //public Text[]       textComponents;
            //public Button[]     buttonComponents;
            //public Toggle[]     toggleComponents;
            //public RawImage[]   rawImageComponents;
            //public Slider[]     sliderComponents;
            //public Scrollbar[]  scrollbarComponents;
            //public InputField[] inputfieldComponents;


            public void FillRectTransHelper(RectTransform _rt)
            {
                rectTransHelper.position = _rt.position;
                rectTransHelper.localPosition = _rt.localPosition;
                rectTransHelper.eulerAngles = _rt.eulerAngles;
                rectTransHelper.localEulerAngles = _rt.localEulerAngles;
                rectTransHelper.anchoredPosition = _rt.anchoredPosition;
                rectTransHelper.anchoredPosition3D = _rt.anchoredPosition3D;
                rectTransHelper.localScale = _rt.localScale;
                rectTransHelper.anchorMax = _rt.anchorMax;
                rectTransHelper.anchorMin = _rt.anchorMin;
                rectTransHelper.offsetMax = _rt.offsetMax;
                rectTransHelper.offsetMin = _rt.offsetMin;
                rectTransHelper.pivot = _rt.pivot;
                rectTransHelper.sizeDelta = _rt.sizeDelta;
                rectTransHelper.rotation = _rt.rotation;
                rectTransHelper.localRotation = _rt.localRotation;
                rectTransHelper.rect = _rt.rect;
                rectTransHelper.silbingIndex = _rt.transform.GetSiblingIndex();

                #region read-Only Stuff
                /* READ ONLY
            rth.rect.bottom = _rt.rect.bottom;
            rth.rect.center = _rt.rect.center;
            rth.rect.height = _rt.rect.height;
            rth.rect.left = _rt.rect.left;
            rth.rect.max = _rt.rect.max;
            rth.rect.min = _rt.rect.min;
            rth.rect.position = _rt.rect.position;
            rth.rect.right = _rt.rect.right;
            rth.rect.size = _rt.rect.size;
            rth.rect.top = _rt.rect.top;
            rth.rect.width = _rt.rect.width;
            rth.rect.x = _rt.rect.x;
            rth.rect.xMax = _rt.rect.xMax;
            rth.rect.xMin = _rt.rect.xMin;
            rth.rect.y = _rt.rect.y;
            rth.rect.yMax = _rt.rect.yMax;
            rth.rect.yMin = _rt.rect.yMin;
             * */
                #endregion
            }

            #region ----- SET NEW COMPONENT-HELPERS -----

            public void FillImageHelperList(Image _i)
            {
                ImageHelper ih = new ImageHelper();

                ih.enabled = _i.enabled;
                ih.sprite = _i.sprite;
                ih.overrideSprite = _i.overrideSprite;
                ih.color = _i.color;
                ih.material = _i.material;
                ih.type = _i.type;
                ih.fillCenter = _i.fillCenter;

                imageComponentsHelper.Add(ih);
            }

            public void FillTextHelperList(Text _t)
            {
                TextHelper th = new TextHelper();

                th.enabled = _t.enabled;
                th.text = _t.text;
                th.font = _t.font;
                th.fontStyle = _t.fontStyle;
                th.fontSize = _t.fontSize;
                th.lineSpacing = _t.lineSpacing;
                th.alignment = _t.alignment;
                th.horizontalOverflow = _t.horizontalOverflow;
                th.verticalOverflow = _t.verticalOverflow;
                th.color = _t.color;
                th.resizeTextForBestFit = _t.resizeTextForBestFit;
                th.supportRichText = _t.supportRichText;
                th.defaultMaterial = _t.defaultMaterial;

                textComponentsHelper.Add(th);
            }

            public void FillButtonsHelperList(Button _b)
            {
                ButtonHelper bh = new ButtonHelper();

                bh.enabled = _b.enabled;

                bh.onClick = _b.onClick;
                bh.interactable = _b.interactable;
                bh.transition = _b.transition;

                bh.colorMultiplier = _b.colors.colorMultiplier;
                bh.disabledColor = _b.colors.disabledColor;
                bh.fadeDuration = _b.colors.fadeDuration;
                bh.highlightedColor = _b.colors.highlightedColor;
                bh.normalColor = _b.colors.normalColor;
                bh.pressedColor = _b.colors.pressedColor;

                bh.targetGraphic = _b.targetGraphic;
                //bh.navigation = _b.navigation;

                buttonComponentsHelper.Add(bh);
            }

            public void FillTogglesHelperList(Toggle _t)
            {
                ToggleHelper th = new ToggleHelper();

                th.enabled = _t.enabled;
                th.interactable = _t.interactable;
                th.transition = _t.transition;

                th.colorMultiplier = _t.colors.colorMultiplier;
                th.disabledColor = _t.colors.disabledColor;
                th.fadeDuration = _t.colors.fadeDuration;
                th.highlightedColor = _t.colors.highlightedColor;
                th.normalColor = _t.colors.normalColor;
                th.pressedColor = _t.colors.pressedColor;

                th.graphic = _t.graphic;
                th.navigation = _t.navigation;

                th.isOn = _t.isOn;
                th.toggleTransition = _t.toggleTransition;
                th.group = _t.group;

                toggleComponentsHelper.Add(th);
            }

            public void FillRawImageHelperList(RawImage _ri)
            {
                RawImageHelper rih = new RawImageHelper();

                rih.enabled = _ri.enabled;
                rih.texture = _ri.texture;
                rih.color = _ri.color;
                rih.material = _ri.material;
                rih.uvRect = _ri.uvRect;

                rawImageComponentsHelper.Add(rih);
            }

            public void FillSliderHelperList(Slider _s)
            {
                SliderHelper sh = new SliderHelper();

                sh.enabled = _s.enabled;
                sh.interactable = _s.interactable;
                sh.wholeNumbers = _s.wholeNumbers;
                sh.transition = _s.transition;

                sh.colorMultiplier = _s.colors.colorMultiplier;
                sh.disabledColor = _s.colors.disabledColor;
                sh.fadeDuration = _s.colors.fadeDuration;
                sh.highlightedColor = _s.colors.highlightedColor;
                sh.normalColor = _s.colors.normalColor;
                sh.pressedColor = _s.colors.pressedColor;

                sh.minValue = _s.minValue;
                sh.maxValue = _s.maxValue;
                sh.value = _s.value;

                sh.targetGraphic = _s.targetGraphic;
                //sh.navigation = _b.navigation;

                sh.fillRect = _s.fillRect;
                sh.handleRect = _s.handleRect;
                sh.direction = _s.direction;

                sh.onValueChanged = _s.onValueChanged;

                sliderComponentsHelper.Add(sh);
            }

            public void FillScrollbarHelperList(Scrollbar _sb)
            {
                ScrollbarHelper sbh = new ScrollbarHelper();

                sbh.enabled = _sb.enabled;
                sbh.interactable = _sb.interactable;
                sbh.transition = _sb.transition;

                sbh.colorMultiplier = _sb.colors.colorMultiplier;
                sbh.disabledColor = _sb.colors.disabledColor;
                sbh.fadeDuration = _sb.colors.fadeDuration;
                sbh.highlightedColor = _sb.colors.highlightedColor;
                sbh.normalColor = _sb.colors.normalColor;
                sbh.pressedColor = _sb.colors.pressedColor;

                sbh.value = _sb.value;
                sbh.size = _sb.size;
                sbh.numberOfSteps = _sb.numberOfSteps;

                sbh.targetGraphic = _sb.targetGraphic;
                //sh.navigation = _b.navigation;

                sbh.handleRect = _sb.handleRect;
                sbh.direction = _sb.direction;

                sbh.onValueChanged = _sb.onValueChanged;

                scrollbarComponentsHelper.Add(sbh);
            }

            public void FillInputFieldHelperList(InputField _if)
            {
                InputFieldHelper ifh = new InputFieldHelper();

                ifh.enabled = _if.enabled;
                ifh.interactable = _if.interactable;
                ifh.transition = _if.transition;

                ifh.targetGraphic = _if.targetGraphic;

                ifh.colorMultiplier = _if.colors.colorMultiplier;
                ifh.disabledColor = _if.colors.disabledColor;
                ifh.fadeDuration = _if.colors.fadeDuration;
                ifh.highlightedColor = _if.colors.highlightedColor;
                ifh.normalColor = _if.colors.normalColor;
                ifh.pressedColor = _if.colors.pressedColor;

                ifh.textComponent = _if.textComponent;
                ifh.text = _if.text;
                ifh.characterLimit = _if.characterLimit;
                ifh.contentType = _if.contentType;
                ifh.lineType = _if.lineType;
                ifh.placeholder = _if.placeholder;
                ifh.caretBlinkRate = _if.caretBlinkRate;
                ifh.selectionColor = _if.selectionColor;
                ifh.shouldHideMobileInput = _if.shouldHideMobileInput;
                ifh.onValueChange = _if.onValueChange;
                ifh.onValidateInput = _if.onValidateInput;

                //bh.navigation = _b.navigation;

                inputFieldComponentsHelper.Add(ifh);
            }

            public void FillVerticalLayoutGroupHelperList(VerticalLayoutGroup _vlg)
            {
                VerticalLayoutG_Helper vlgh = new VerticalLayoutG_Helper();
                vlgh.enabled = _vlg.enabled;
                vlgh.padding_left = _vlg.padding.left;
                vlgh.padding_right = _vlg.padding.right;
                vlgh.padding_top = _vlg.padding.top;
                vlgh.padding_bottom = _vlg.padding.bottom;
                vlgh.spacing = _vlg.spacing;

                vlgh.childForceExpand_Width = _vlg.childForceExpandWidth;
                vlgh.childForceExpand_Height = _vlg.childForceExpandHeight;

                vlgh.childAlignment = _vlg.childAlignment;

                verticalLayoutGroupComponentsHelper.Add(vlgh);
            }

            public void FillHorizontalLayoutGroupHelperList(HorizontalLayoutGroup _hlg)
            {
                HorizontalLayoutG_Helper hlgh = new HorizontalLayoutG_Helper();
                hlgh.enabled = _hlg.enabled;
                hlgh.padding_left = _hlg.padding.left;
                hlgh.padding_right = _hlg.padding.right;
                hlgh.padding_top = _hlg.padding.top;
                hlgh.padding_bottom = _hlg.padding.bottom;
                hlgh.spacing = _hlg.spacing;

                hlgh.childForceExpand_Width = _hlg.childForceExpandWidth;
                hlgh.childForceExpand_Height = _hlg.childForceExpandHeight;

                hlgh.childAlignment = _hlg.childAlignment;

                horizontalLayoutGroupComponentsHelper.Add(hlgh);
            }

            public void FillLayoutElementHelperList(LayoutElement _le)
            {
                LayoutElement_Helper leh = new LayoutElement_Helper();

                leh.enabled = _le.enabled;
                leh.ignoreLayout = _le.ignoreLayout;

                leh.minWidth = _le.minWidth;
                leh.minHeight = _le.minHeight;
                leh.preferredWidth = _le.preferredWidth;
                leh.preferredHeight = _le.preferredHeight;
                leh.flexibleWidth = _le.flexibleWidth;
                leh.flexibleHeight = _le.flexibleHeight;

                layoutElementComponentsHelper.Add(leh);
            }

            public void FillContentSizeFitterComponentsHelperList(ContentSizeFitter _csf)
            {
                ContentSizeFitter_Helper csfh = new ContentSizeFitter_Helper();

                csfh.enabled = _csf.enabled;
                csfh.horizontalFit = _csf.horizontalFit;
                csfh.verticalFit = _csf.verticalFit;

                contentSizeFitterHelper.Add(csfh);
            }

            public void FillAspectRatioFitterComponentsHelperList(AspectRatioFitter _arf)
            {
                AspectRatioFitter_Helper arfh = new AspectRatioFitter_Helper();

                arfh.enabled = _arf.enabled;
                arfh.aspectMode = _arf.aspectMode;
                arfh.aspectRatio = _arf.aspectRatio;

                aspectRatioFitterHelper.Add(arfh);
            }

            public void FillGridLayoutGroupHelperList(GridLayoutGroup _glg)
            {
                GridLayoutG_Helper glgh = new GridLayoutG_Helper();

                glgh.enabled = _glg.enabled;

                glgh.padding_left = _glg.padding.left;
                glgh.padding_right = _glg.padding.right;
                glgh.padding_top = _glg.padding.top;
                glgh.padding_bottom = _glg.padding.bottom;

                glgh.cellSize = _glg.cellSize;
                glgh.spacing = _glg.spacing;
                glgh.startAxis = _glg.startAxis;
                glgh.startCorner = _glg.startCorner;
                glgh.constraint = _glg.constraint;
                glgh.childAlignment = _glg.childAlignment;

                gridLayoutGroupHelperList.Add(glgh);
            }

            public void FillShadowComponentsHelperList(Shadow _s)
            {
                Shadow_Helper sh = new Shadow_Helper();

                sh.enabled = _s.enabled;
                sh.effectColor = _s.effectColor;
                sh.effectDistance = _s.effectDistance;
                sh.useGraphicAlpha = _s.useGraphicAlpha;

                shadowComponentsHelperList.Add(sh);
            }

            public void FillOutlineComponentsHelperList(Outline _o)
            {
                Outline_Helper oh = new Outline_Helper();

                oh.enabled = _o.enabled;
                oh.effectColor = _o.effectColor;
                oh.effectDistance = _o.effectDistance;
                oh.useGraphicAlpha = _o.useGraphicAlpha;

                outlineComponentsHelperList.Add(oh);
            }

            public void FillScrollRectComponentsHelperList(ScrollRect _sr)
            {
                ScrollRect_Helper srh = new ScrollRect_Helper();

                srh.enabled = _sr.enabled; ;
                srh.content = _sr.content;
                srh.horizontal = _sr.horizontal;
                srh.vertical = _sr.vertical;
                srh.inertia = _sr.inertia;
                srh.movementType = _sr.movementType;
                srh.elasticity = _sr.elasticity;
                srh.decelerationRate = _sr.decelerationRate;
                srh.scrollSensitivity = _sr.scrollSensitivity;
                srh.horizontalScrollbar = _sr.horizontalScrollbar;
                srh.verticalScrollbar = _sr.verticalScrollbar;
                srh.onValueChanged = _sr.onValueChanged;

                scrollRectComponentsHelperList.Add(srh);
            }


            #endregion
        }

        public static LL_Layout GetLLAtStartup(Canvas canvasInScene, List<LL_Layout> savedLazyLayouts, float _deviceSizeInInches)
        {
            RectTransform[] rectTransformsInScene = canvasInScene.GetComponentsInChildren<RectTransform>(true);
            int count = rectTransformsInScene.Length;
            LL_Layout ll = null;
            LL_Layout.AspectRatio currentAT = GetCurrentAR();

            // PRE-DEFINED ARs
            if (currentAT != AspectRatio.Other)
            {
                for (int i = 0; i < savedLazyLayouts.Count; i++)
                {
                    if (_deviceSizeInInches >= savedLazyLayouts[i].minDeviceSizeForLayout)
                    {
                        if (ll == null)
                        {
                            switch (currentAT)
                            {
                                case LL_Layout.AspectRatio.SixteenNine_Landscape:
                                    if (savedLazyLayouts[i].capableOf_16_9_Landscape)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.SixteenNine_Portrait:
                                    if (savedLazyLayouts[i].capableOf_16_9_Portrait)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.FourThree_Landscape:
                                    if (savedLazyLayouts[i].capableOf_4_3_Landscape)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.FourThree_Portrait:
                                    if (savedLazyLayouts[i].capableOf_4_3_Portrait)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.ThreeTwo_Landscape:
                                    if (savedLazyLayouts[i].capableOf_3_2_Landscape)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.ThreeTwo_Portrait:
                                    if (savedLazyLayouts[i].capableOf_3_2_Portrait)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                case LL_Layout.AspectRatio.Other:
                                    if (savedLazyLayouts[i].capableOf_Other)
                                    {
                                        ll = savedLazyLayouts[i];
                                    }
                                    break;
                                default:
                                    Debug.LogError("--LAZYLAYOUT ERROR-- CONFLICT WITH ASPECT RATIO. CURRENT AR IS: " + Camera.main.aspect);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (savedLazyLayouts.Count > 1)
                        {
                            if (savedLazyLayouts[i].minDeviceSizeForLayout > ll.minDeviceSizeForLayout)
                            {
                                if (currentAT == savedLazyLayouts[i].aspectRatioForLayout)
                                {
                                    switch (currentAT)
                                    {
                                        case LL_Layout.AspectRatio.SixteenNine_Landscape:
                                            if (savedLazyLayouts[i].capableOf_16_9_Landscape)
                                            {
                                                ll = savedLazyLayouts[i];
                                            }
                                            break;
                                        case LL_Layout.AspectRatio.SixteenNine_Portrait:
                                            if (savedLazyLayouts[i].capableOf_16_9_Portrait)
                                            {
                                                ll = savedLazyLayouts[i];
                                            }
                                            break;
                                        case LL_Layout.AspectRatio.FourThree_Landscape:
                                            if (savedLazyLayouts[i].capableOf_4_3_Landscape)
                                            {
                                                ll = savedLazyLayouts[i];
                                            }
                                            break;
                                        case LL_Layout.AspectRatio.FourThree_Portrait:
                                            if (savedLazyLayouts[i].capableOf_4_3_Portrait)
                                            {
                                                ll = savedLazyLayouts[i];
                                            }
                                            break;
                                        case LL_Layout.AspectRatio.Other:
                                            if (savedLazyLayouts[i].capableOf_Other)
                                            {
                                                ll = savedLazyLayouts[i];
                                            }
                                            break;
                                        default:
                                            Debug.LogError("--LAZYLAYOUT ERROR-- CONFLICT WITH ASPECT RATIO. CURRENT AR IS: " + Camera.main.aspect);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // OTHER ARs (including the custom ones)
            else
            {
                // Is there a customAR layout for the current AR?
                for (int i = 0; i < savedLazyLayouts.Count; i++)
                {
                    if (_deviceSizeInInches >= savedLazyLayouts[i].minDeviceSizeForLayout)
                    {
                        // If we do not find a customAR for current AR -> Look for an "other" one
                        if(savedLazyLayouts[i].capableOf_Other)
                        {
                            ll = savedLazyLayouts[i];
                        }

                        // If we find a fitting layout with customAR -> Use this one and return ll
                        if (savedLazyLayouts[i].capableOf_Custom)
                        {
                            float customAR_Lands = savedLazyLayouts[i].customAR_Length / savedLazyLayouts[i].customAR_Height;
                            float customAR_Port = savedLazyLayouts[i].customAR_Height / savedLazyLayouts[i].customAR_Length;

                            float diff_Lands = Mathf.Abs(Camera.main.aspect - customAR_Lands);
                            float diff_Port = Mathf.Abs(Camera.main.aspect - customAR_Lands);

                            if (diff_Lands <= 0.01F || diff_Port <= 0.01F)
                            {
                                ll = savedLazyLayouts[i];
                                break;
                            }
                        }
                    }
                }
            }        

            if (ll == null)
            {
                Debug.LogError("--LAZYLAYOUT ERROR-- CONFLICT WITH ASPECT RATIO - NO APPROPRIATE LAYOUT COULD BE FOUND! CURRENT AR IS: " + Camera.main.aspect);
            }
            return ll;
        }

        public static LL_Layout.AspectRatio GetCurrentAR()
        {
            float ar = Camera.main.aspect;

            if (ar > 1.7F && ar < 1.8F)
            {
                //AR is 16:9_Landscape
                return LL_Layout.AspectRatio.SixteenNine_Landscape;
            }
            else if (ar > 0.555F && ar < 0.565F)
            {
                //AR is 16:9_Portrait
                return LL_Layout.AspectRatio.SixteenNine_Portrait;
            }
            else if (ar > 1.3F && ar < 1.4F)
            {
                //AR is 4:3_Landscape
                return LL_Layout.AspectRatio.FourThree_Landscape;
            }
            else if (ar == 0.75F || ar > 0.74F && ar < 0.76F)
            {
                //AR is 4:3_Portrait
                return LL_Layout.AspectRatio.FourThree_Portrait;
            }
            else if (ar == 1.5F || ar > 1.45F && ar < 1.55F)
            {
                //AR is 3:2_Landscape
                return LL_Layout.AspectRatio.ThreeTwo_Landscape;
            }
            else if (ar > 0.65F && ar < 0.68F)
            {
                //AR is 3:2_Portrait
                return LL_Layout.AspectRatio.ThreeTwo_Portrait;
            }
            else
            {
                //AR is other
                return LL_Layout.AspectRatio.Other; ;
            }
        }
    }
}
