$$.string.address = {
    "zh-cn": {
        b: "输入中文/拼音或↑↓选择.",
        i: "输入",
        j: "或↑↓选择.",
        k: "中文/拼音",
        e: "请输入至少两个字母或一个汉字.",
        h: "",
        o: "按拼音排序",
        s: "对不起, 找不到: ",
        l: "结果共",
        p: "项,←→翻页",
        a: ",共"
    },
    "zh-tw": {
        b: "輸入中文/拼音或↑↓選擇.",
        i: "輸入",
        j: "或↑↓選擇.",
        k: "中文/拼音",
        e: "請輸入至少兩個字母或一個漢字.",
        h: "",
        o: "按拼音排序",
        s: "對不起, 找不到: ",
        l: "結果共",
        p: "項,←→翻頁",
        a: ",共"
    },
    "en": {
        b: "↑↓键选择，或输入中文/英文显示更多港口",
        i: "输入",
        j: "或↑↓选择.",
        k: "中文/拼音",
        e: "请输入至少两个字母或一个汉字.",
        h: "",
        o: "按拼音排序。若不想选取以下列表中港口，请直接按Tab键",
        s: "对不起, 港口列表内找不到您输入的港口 ",
        l: "结果共",
        p: "项,←→翻页",
        a: ",共"
    }
} [$$.status.version];
$$.module.address.sourceMap = {
    //"hotel": ["http://scriptres.ctrip.com/hoteladdress/HotelCityAddress{$charset}.aspx", "utf-8"],
    //"hotelAll": ["http://scriptres.ctrip.com/hoteladdress/HotelCityAddress{$charset}.aspx", "utf-8"]
};
$loadCss("http://www.100allin.com/css/control_address_tuna_071206.css");
function sortFunc(c, b) {
    var e = c.match(/^[^\|]+/),
    f = b.match(/^[^\|]+/);
    return e > f ? 1 : (e == f ? 0 : -1)
} (function c_address() {
    var G = $c("div");
    with(G.style) {
        width = "0px";
        height = "0px"
    }
    G.innerHTML = "<div id=\"tuna_address\" style=\"display:none;position:absolute;z-index:120;overflow:hidden;\"><div id=\"address_warp\"><div id=\"address_message\">&nbsp;<\/div><div id=\"address_list\"><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><a class=\"a1\" href=\"###\"><span>&nbsp;<\/span>&nbsp;<\/a><\/div><div class=\"address_pagebreak\" id=\"address_p\"><a id=\"address_arrowl\" href=\"javascript:;\" name=\"p\">&lt;-<\/a><a id=\"address_p1\" href=\"javascript:;\" name=\"1\" class=\"address_current\">1<\/a><a id=\"address_p2\" href=\"javascript:;\" name=\"2\">2<\/a><a id=\"address_p3\" href=\"javascript:;\" name=\"3\">3<\/a><a id=\"address_p4\" href=\"javascript:;\" name=\"4\">4<\/a><a id=\"address_p5\" href=\"javascript:;\" name=\"5\">5<\/a><a id=\"address_arrowr\" href=\"javascript:;\" name=\"n\">-&gt;<\/a><\/div><\/div><\/div>";
    $("jsContainer").appendChild(G);
    var i = $("tuna_address");
    $$.module.address.source["default"] = "@@";
    var L = $("address_warp"),
    u = $('address_message'),
    A = $('address_list'),
    v = [$('address_p'), $('address_p1'), $('address_p2'), $('address_p3'), $('address_p4'), $('address_p5')],
    B = $('address_arrowl'),
    C = $('address_arrowr'),
    h = A.getElementsByTagName("a"),
    R = [];
    for (var D = 0; D < h.length; D++) R[D] = h[D].cloneNode(true);
    function M() {
        function Q(d) {
            var n = 0,
            r, s = d.$getWin();
            var a = d.module.address = {};
            var S, w, g = null,
            t, p = [];
            d.setAttribute("autoComplete", "off");
            $r("beforeunload",
            function() {
                d.setAttribute("autoComplete", "on")
            });
            a.focusNext = d.getAttribute("mod_address_focusNext");
            a.focusNext = /^(1|true)$/i.test(a.focusNext || "");
            a.reference = d.getAttribute("mod_address_reference");
            var m = d.getAttribute("mod_address_cookie");
            if (m) {
                m = s.$(m);
                if (!m) {
                    var H = s.$c("input");
                    with(H) {
                        type = "hidden";
                        id = name = m
                    }
                    m = H;
                    d.parentNode.insertBefore(m, d)
                }
            }
            if (a.reference) a.reference = s.$(a.reference) || s.$(a.reference, true);
            var x = d.getAttribute("mod_address_suggest");
            var I = d.getAttribute("mod_address_cookieSuggest");
            a.suggest = [];
            if (I) {
                a.suggest = I.match(/[^@]+@/gi);
                if (x) a.suggest._0(x.match(/[^@]+@/gi))
            } else if (x) a.suggest = x.match(/[^@]+@/gi);
            if (a.suggest.length > 12) a.suggest = a.suggest.slice(0, 12);
            a.source = d.getAttribute("mod_address_source") || "default";
            if (!$$.module.address.source[a.source]) {
                $$.module.address.source[a.source] = "@@";
                if ($$.module.address.sourceMap[a.source]) $loadJs($$.module.address.sourceMap[a.source][0].replace(/\{\$charset\}/gi, $$.status.charset), ($$.module.address.sourceMap[a.source][1] || "").replace(/\{\$charset\}/gi, $$.status.charset) || $$.status.charset);
                else $loadJs("http://www.100allin.com/js/" + a.source + "_" + $$.status.charset + ".js", $$.status.charset)
            }
            a.auto = d.getAttribute("mod_address_auto");
            a.auto = a.auto && a.auto.match(/^(false|0)$/i) ? false: true;
            a.redraw = function() {
                if (w) F()
            };
            a.hook = {}; (d.getAttribute("mod_address_hook") || "").replace(/(on)?([^;:]+):([^;]+)/gi,
            function(c, b, e, f) {
                a.hook[e.toLowerCase()] = s[f]
            });
            function N() {
                if (n) {
                    n = 0;
                    return
                }
                r = false;
                A.style.display = u.style.display = v[0].style.display = "none";
                function e(b) {
                    h[b].onmousedown = function(c) {
                        z(b);
                        $stopEvent(c);
                        if (h[b].outerHTML) h[b].outerHTML = h[b].outerHTML + ' ';
                        d.blur()
                    }
                }
                i.onmousedown = function() {
                    n = 1
                };
                for (var f = 0; f < h.length; f++) new e(f);
                B.onmousedown = C.onmousedown = y;
                for (var f = 1; f < v.length; f++) v[f].onmousedown = y;
                t = null;
                if (g !== null) h[g].className = "address_selected";
                if (a.hook["focus"]) a.hook["focus"](d);
                setTimeout(F, 0);
                w = setInterval(F, 150)
            }
            function y(c) {
                n = 1;
                if (c) $stopEvent(c);
                switch (this) {
                case B:
                    k.m_get(k.page - 1);
                    break;
                case C:
                    k.m_get(k.page + 1);
                    break;
                default:
                    k.m_get(parseInt(this.firstChild.nodeValue))
                }
            }
            var k = new
            function() {
                var o;
                this.page = 1;
                this.pagelist;
                this.maxpage = 1;
                this.m_get = function(c) {
                    if (!o || !c || c < 1 || c > this.maxpage) return null;
                    this.page = c;
                    this.pagelist = o.slice((c - 1) * 12, Math.min(c * 12, o.length));
                    for (var b = 0; b < h.length; b++) {
                        if (b < this.pagelist.length) {
                            h[b].style.display = "block";
                            var e = this.pagelist[b].replace(/@/g, "").split("|");
                            h[b].lastChild.nodeValue = e[1];
                            h[b].firstChild.firstChild.nodeValue = e[0];
                            p[b] = e
                        } else {
                            h[b].style.display = "none";
                            p[b] = null
                        }
                    }
                    if (g !== null) {
                        if (g >= this.pagelist.length) {
                            h[g].className = "";
                            g = this.pagelist.length - 1;
                            h[g].className = "address_selected"
                        }
                    } else {
                        g = 0;
                        h[0].className = "address_selected"
                    }
                    l.call(this);
                    A.style.display = u.style.display = "";
                    if (!r) {
                        i.style.display = "";
                        var f = d.$getPos();
                        if (i.offsetWidth + f[0] > ___.offsetWidth) i.$setPos(d, "tr", "br");
                        else i.$setPos(d);
                        i.$setIframe();
                        r = true
                    }
                    E.call(this)
                };
                this.m_set = function(c) {
                    o = c;
                    this.maxpage = Math.ceil(c.length / 12);
                    this.page = 1;
                    this.m_get(1)
                };
                function l() {
                    var c = this.maxpage < 6 || this.page < 3 ? 1 : this.page > this.maxpage - 2 ? this.maxpage - 4 : this.page - 2;
                    var b = Math.min(c + 4, this.maxpage);
                    var e;
                    B.style.display = this.page == 1 ? "none": "";
                    C.style.display = this.page == this.maxpage ? "none": "";
                    for (var f = c; f < c + 5; f++) {
                        e = v[f - c + 1];
                        if (f <= b) {
                            e.firstChild.nodeValue = f;
                            e.className = f == this.page ? "address_current": "";
                            e.style.display = ""
                        } else e.style.display = "none"
                    }
                    v[0].style.display = this.maxpage > 1 ? "block": "none"
                }
            };
            function E() {
                with(i.style) {
                    width = L.offsetWidth + "px";
                    height = L.offsetHeight + "px"
                }
                i.$setIframe()
            }
            function J() {
                if (a.suggest.length == 0) {
                    i.style.display = "none";
                    if (g !== null) {
                        h[g].className = "";
                        g = null
                    }
                    return
                }
                k.m_set(a.suggest);
                u.lastChild.nodeValue = $$.status.version.match(/^zh-/) ? $$.string.address.i + (d.module.notice ? d.module.notice.tip: $$.string.address.k) + $$.string.address.j: $$.string.address.b
            }
            function F() {
                var b = d.value.trim();
                if (b === t) return;
                t = b;
                b = b.replace(/([\(\)\\\[\]\.\+\?\*\|\^\$])/gi, "\\$1").replace(/@|\|/gi, "");
                if (!b) {
                    J();
                    E();
                    return
                }
                i.style.display = "";
                var e = $$.module.address.source[a.source];
                var f = new RegExp("@([^@]*\\|)?" + b + "[^@]*", "gi");
                var o = new RegExp("@[^@]*" + b + "[^@]*", "gi");
                var l = [],
                j = [];
                e = e.replace(f,
                function(c) {
                    l.push(c);
                    return ""
                });
                if (l) l.sort(sortFunc);
                e = e.replace(o,
                function(c) {
                    j.push(c);
                    return ""
                });
                if (j) j.sort(sortFunc);
                if (l && j) arr = l.concat(j);
                else arr = l || j;
                if (!arr || !arr.length) {
                    u.lastChild.nodeValue = a.auto ? ($$.string.address.s + ($$.status.version == "en" ? "": d.value)) : ($$.string.address.h + d.value + ", " + $$.string.address.o);
                    if (!a.auto) {
                        i.style.display = "none";
                        if (g !== null) {
                            h[g].className = "";
                            g = null
                        }
                    }
                    if (A.style.display == "none") J();
                    E()
                } else {
                    u.lastChild.nodeValue = $$.string.address.h + d.value + ", " + $$.string.address.o;
                    k.m_set(arr)
                }
            }
            function O(c) {
                var b = c ? c.keyCode: event.charCode;
                var e = "|" + b + "|";
                if (g == null) {
                    if ("|13|".indexOf(e) != -1) {
                        $stopEvent(c, 1);
                        if (a.focusNext) setTimeout(function() {
                            d.$focusNext()
                        },
                        1)
                    }
                    return true
                }
                if ("|13|".indexOf(e) != -1) {
                    $stopEvent(c, 1);
                    z(g);
                    d.blur()
                }
                if ("|33|37|109|188|219|".indexOf(e) != -1) {
                    y.call(B);
                    $stopEvent(c, 1)
                }
                if ("|34|39|61|190|221|".indexOf(e) != -1) {
                    y.call(C);
                    $stopEvent(c, 1)
                }
                if ("|38|40|".indexOf(e) != -1) {
                    h[g].className = "";
                    g += k.pagelist.length - 39 + b;
                    g %= k.pagelist.length;
                    h[g].className = "address_selected";
                    $stopEvent(c, 1)
                }
            }
            function z(c, b) {
                n = 2;
                d.value = p[c][0] || p[c][0];  //原为d.value = p[c][1] || p[c][0];
                if (a.reference) a.reference.value = p[c][2];
                if (m) m.value = p.join("|");
                if (a.hook["change"]) a.hook["change"](d);
                if (b !== false && a.focusNext) setTimeout(function() {
                    d.$focusNext()
                },
                1)
            }
            function P() {
                if (n == 1) {
                    setTimeout(function() {
                        d.focus()
                    },
                    1);
                    return
                }
                clearInterval(w);
                w = null;
                i.$clearIframe();
                i.style.display = "none";
                //if (g !== null) {
                //    if (d.value && n != 2 && a.auto) z(g, false);
                //    h[g].className = "";
                //    g = null
                //}
                n = 0;
                i.onmousedown = null
            }
            a.check = function() {
                var b = d.value.trim();
                if (d.isNull && d.isNull()) b = "";
                if (b === t) return;
                var e;
                t = b;
                b = b.replace(/([\(\)\\\[\]\.\+\?\*\|\^\$])/gi, "\\$1").replace(/@|\|/gi, "");
                if (b) {
                    var f = $$.module.address.source[a.source];
                    var o = new RegExp("@([^@]*\\|)?" + b + "[^@]*", "gi");
                    var l = new RegExp("@[^@]*" + b + "[^@]*", "gi");
                    var j = [],
                    q = [];
                    f = f.replace(o,
                    function(c) {
                        j.push(c);
                        return ""
                    });
                    if (j) j.sort(sortFunc);
                    f = f.replace(l,
                    function(c) {
                        q.push(c);
                        return ""
                    });
                    if (q) q.sort(sortFunc);
                    if (j && q) e = j.concat(q);
                    else e = j || q;
                    if (e && e.length) {
                        r = true;
                        k.m_set(e);
                        r = false;
                        z(0, false);
                        n = 0
                    }
                }
                if (d.module.notice) d.module.notice.check();
                return !! e
            };
            d.$r("onfocus", N);
            d.blur();
            d.$r("onblur", P);
            d.$r("onkeydown", O);
            if (a.hook["load"]) a.hook["load"](d)
        }
        var K;
        while ((K = $$.module.address.list.shift()) != null) new Q(K)
    }
    $init(M);
    M()
})();