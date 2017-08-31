using System.ComponentModel;

namespace ProtractorBuilder.Protractor.Common
{
    public enum ActionSequence
    {
        [Description("Click")]
        Click,

        [Description("Double Click")]
        DoubleClick,

        [Description("Drag and Drop")]
        DragAndDrop,

        [Description("Key Down")]
        KeyDown,

        [Description("Key Up")]
        KeyUp,

        [Description("Mouse Down")]
        MouseDown,

        [Description("Mouse Move")]
        MouseMove,

        [Description("Mouse Up")]
        MouseUp,

        [Description("Send Keys")]
        SendKeys
    }
}
