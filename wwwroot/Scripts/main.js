function show(data) {
    var jsonobjs = data;
    for (var y = 0; y < jsonobjs.length; y++) {

        var $tr = $("<tr></tr>");
        $tr.appendTo($("#personTable"));
        var item = jsonobjs[y];
        console.log(item);
        var $td1 = $("<td></td>").text(item.Name);
        var $td2 = $("<td></td>").attr("align", "center").text(item.Amount);
        var $td3 = $("<td></td>").attr("align", "center");
        var $herf = $("<a></a>").attr("href", "javascript:ExcuteNativeJs('CallPhone','" + item.Phone + "')").text(item.Phone);
        $herf.appendTo($td3);
        $td1.appendTo($tr);
        $td2.appendTo($tr);
        $td3.appendTo($tr);
    }
}

function ExcuteNativeJs(fnName, options) {
    var ua = navigator.userAgent;
    if (ua.match(/iPhone|iPod/i) != null) {
        document.location = 'DingDingIos://'+fnName+'/'+options;
    } else if (ua.match(/Android/i) != null) {
        contact.Call(fnName, options)
    } else if (ua.match(/iPad/i) != null) {
         document.location = 'IOS://'+fnName+''+options;
    }

}