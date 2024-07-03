 // using System;
 // using System.Diagnostics;
 //
 // [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = false)]
 //  [Conditional("UNITY_EDITOR")]
 //  public class ButtonAttribute : Attribute
 //  {
 //    /// <summary>
 //    /// <para>Whether to display the button method's parameters (if any) as values in the inspector. True by default.</para>
 //    /// <para>If this is set to false, the button method will instead be invoked through an ActionResolver or ValueResolver (based on whether it returns a value), giving access to contextual named parameter values like "InspectorProperty property" that can be passed to the button method.</para>
 //    /// </summary>
 //    public bool DisplayParameters = true;
 //    /// <summary>
 //    /// Whether the containing object or scene (if there is one) should be marked dirty when the button is clicked. True by default. Note that if this is false, undo for any changes caused by the button click is also disabled, as registering undo events also causes dirtying.
 //    /// </summary>
 //    public bool DirtyOnClick = true;
 //    /// <summary>Use this to override the label on the button.</summary>
 //    public string Name;
 //    /// <summary>The style in which to draw the button.</summary>
 //    public ButtonStyle Style;
 //    /// <summary>
 //    /// If the button contains parameters, you can disable the foldout it creates by setting this to true.
 //    /// </summary>
 //    public bool Expanded;
 //    /// <summary>The icon to be displayed inside the button.</summary>
 //    public SdfIconType Icon;
 //    private int buttonHeight;
 //    private bool drawResult;
 //    private bool drawResultIsSet;
 //    private bool stretch;
 //    private IconAlignment buttonIconAlignment;
 //    private float buttonAlignment;
 //
 //    /// <summary>
 //    /// Gets the height of the button. If it's zero or below then use default.
 //    /// </summary>
 //    public int ButtonHeight
 //    {
 //      get
 //      {
 //        return this.buttonHeight;
 //      }
 //      set
 //      {
 //        this.buttonHeight = value;
 //        this.HasDefinedButtonHeight = true;
 //      }
 //    }
 //
 //    /// <summary>
 //    /// The alignment of the icon that is displayed inside the button.
 //    /// </summary>
 //    public IconAlignment IconAlignment
 //    {
 //      get
 //      {
 //        return this.buttonIconAlignment;
 //      }
 //      set
 //      {
 //        this.buttonIconAlignment = value;
 //        this.HasDefinedButtonIconAlignment = true;
 //      }
 //    }
 //
 //    /// <summary>
 //    /// The alignment of the button represented by a range from 0 to 1 where 0 is the left edge of the available space and 1 is the right edge.
 //    /// ButtonAlignment only has an effect when Stretch is set to false.
 //    /// </summary>
 //    public float ButtonAlignment
 //    {
 //      get
 //      {
 //        return this.buttonAlignment;
 //      }
 //      set
 //      {
 //        this.buttonAlignment = value;
 //        this.HasDefinedButtonAlignment = true;
 //      }
 //    }
 //
 //    /// <summary>
 //    /// Whether the button should stretch to fill all of the available space. Default value is true.
 //    /// </summary>
 //    public bool Stretch
 //    {
 //      get
 //      {
 //        return this.stretch;
 //      }
 //      set
 //      {
 //        this.stretch = value;
 //        this.HasDefinedStretch = true;
 //      }
 //    }
 //
 //    /// <summary>
 //    /// If the button has a return type, set this to false to not draw the result. Default value is true.
 //    /// </summary>
 //    public bool DrawResult
 //    {
 //      set
 //      {
 //        this.drawResult = value;
 //        this.drawResultIsSet = true;
 //      }
 //      get
 //      {
 //        return this.drawResult;
 //      }
 //    }
 //
 //    public bool DrawResultIsSet
 //    {
 //      get
 //      {
 //        return this.drawResultIsSet;
 //      }
 //    }
 //
 //    public bool HasDefinedButtonHeight { get; private set; }
 //
 //    public bool HasDefinedIcon
 //    {
 //      get
 //      {
 //        return (uint) this.Icon > 0U;
 //      }
 //    }
 //
 //    public bool HasDefinedButtonIconAlignment { get; private set; }
 //
 //    public bool HasDefinedButtonAlignment { get; private set; }
 //
 //    public bool HasDefinedStretch { get; private set; }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    public ButtonAttribute()
 //    {
 //      this.Name = (string) null;
 //    }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    /// <param name="size">The size of the button.</param>
 //    public ButtonAttribute(ButtonSizes size)
 //    {
 //      this.Name = (string) null;
 //      this.ButtonHeight = (int) size;
 //    }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    /// <param name="buttonSize">The size of the button.</param>
 //    public ButtonAttribute(int buttonSize)
 //    {
 //      this.ButtonHeight = buttonSize;
 //      this.Name = (string) null;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    public ButtonAttribute(string name)
 //    {
 //      this.Name = name;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    /// <param name="buttonSize">Size of the button.</param>
 //    public ButtonAttribute(string name, ButtonSizes buttonSize)
 //    {
 //      this.Name = name;
 //      this.ButtonHeight = (int) buttonSize;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    /// <param name="buttonSize">Size of the button in pixels.</param>
 //    public ButtonAttribute(string name, int buttonSize)
 //    {
 //      this.Name = name;
 //      this.ButtonHeight = buttonSize;
 //    }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(ButtonStyle parameterBtnStyle)
 //    {
 //      this.Name = (string) null;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    /// <param name="buttonSize">The size of the button.</param>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(int buttonSize, ButtonStyle parameterBtnStyle)
 //    {
 //      this.ButtonHeight = buttonSize;
 //      this.Name = (string) null;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>
 //    /// Creates a button in the inspector named after the method.
 //    /// </summary>
 //    /// <param name="size">The size of the button.</param>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(ButtonSizes size, ButtonStyle parameterBtnStyle)
 //    {
 //      this.ButtonHeight = (int) size;
 //      this.Name = (string) null;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(string name, ButtonStyle parameterBtnStyle)
 //    {
 //      this.Name = name;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    /// <param name="buttonSize">Size of the button.</param>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(string name, ButtonSizes buttonSize, ButtonStyle parameterBtnStyle)
 //    {
 //      this.Name = name;
 //      this.ButtonHeight = (int) buttonSize;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom name.</summary>
 //    /// <param name="name">Custom name for the button.</param>
 //    /// <param name="buttonSize">Size of the button in pixels.</param>
 //    /// <param name="parameterBtnStyle">Button style for methods with parameters.</param>
 //    public ButtonAttribute(string name, int buttonSize, ButtonStyle parameterBtnStyle)
 //    {
 //      this.Name = name;
 //      this.ButtonHeight = buttonSize;
 //      this.Style = parameterBtnStyle;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom icon.</summary>
 //    /// <param name="icon">The icon to be displayed inside the button.</param>
 //    /// <param name="iconAlignment">The alignment of the icon that is displayed inside the button.</param>
 //    public ButtonAttribute(SdfIconType icon, IconAlignment iconAlignment)
 //    {
 //      this.Icon = icon;
 //      this.IconAlignment = iconAlignment;
 //      this.Name = (string) null;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom icon.</summary>
 //    /// <param name="icon">The icon to be displayed inside the button.</param>
 //    public ButtonAttribute(SdfIconType icon)
 //    {
 //      this.Icon = icon;
 //      this.Name = (string) null;
 //    }
 //
 //    /// <summary>Creates a button in the inspector with a custom icon.</summary>
 //    /// <param name="icon">The icon to be displayed inside the button.</param>
 //    /// <param name="name">Custom name for the button.</param>
 //    public ButtonAttribute(SdfIconType icon, string name)
 //    {
 //      this.Name = name;
 //      this.Icon = icon;
 //    }
 //  }