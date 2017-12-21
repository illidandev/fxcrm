function ClickInModal(cssModalPopUp, cssBtnToClick)
{
	var fin = document.querySelector(cssModalPopUp);
	var btnToClick = fin.querySelector(cssBtnToClick);
	btnToClick.click();
}
ClickInModal("[ms_positioning=GridLayout]","#btnClose");