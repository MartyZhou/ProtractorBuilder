using System.ComponentModel;

namespace ProtractorBuilder.Protractor.Common
{
    public enum ActionSequence
    {
        loadUrl,

        locateElement,

        [Description("Get Parent Element")]
        getDriver,

        [Description("Click")]
        click,

		[Description("Send Keys")]
		sendKeys,

        getTagName,

        getCssValue,

        getAttribute,

        getText,

        getSize,

        getLocation,

        isEnabled,

        isSelected,

        submit,

        clear,

        isDisplayed,

        expect,

        [Description("Double Click")]
        doubleClick,

        [Description("Drag and Drop")]
        dragAndDrop,

        [Description("Key Down")]
        keyDown,

        [Description("Key Up")]
        keyUp,

        [Description("Mouse Down")]
        mouseDown,

        [Description("Mouse Move")]
        mouseMove,

        [Description("Mouse Up")]
        mouseUp
    }
}
