function IsPopUpVisible(elCssSelector)
{
    var element = document.querySelector(elCssSelector);
	return element.offsetParent
}
IsPopUpVisible("@");




