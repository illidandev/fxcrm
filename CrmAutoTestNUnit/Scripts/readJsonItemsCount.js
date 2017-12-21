var xmlHttp = new XMLHttpRequest();
xmlHttp.open("GET","@",false);
xmlHttp.send(null);
var s = JSON.parse(xmlHttp.response);
var t=s["itemsCount"];
return t;



