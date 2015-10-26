var $topWin = window; (function() {
    try {
        while (true) {
            var a = $topWin.parent;
            if (a && a != $topWin && a.$Ctrip) $topWin = a;
            else return
        }
    } catch(e) {}
})();
window.$Ctrip = function(f) {
    this.Variable = function() {
        this._ = f;
        this.__ = f.document;
        this.___ = f.__.documentElement;
        this.$$ = new
        function() {
            with(navigator) {
                with(userAgent) {
                    this.browser = {
                        IE: !!match(/MSIE/),
                        IE6: !!appVersion.match(/MSIE 6\.0/i),
                        Moz: match(/Mozilla/i) && !match(/compatible|WebKit/i),
                        Opera: !!match(/Opera/i),
                        Safari: !!match(/Mac|Safari/i)
                    }
                }
            }
            this.history = {
                load: function() {
                    setTimeout(function() {
                        f.$$.history.load()
                    },
                    200)
                }
            }
        };
        f.__.write("<div id=\"jsContainer\"><div id=\"jsHistoryDiv\" style=\"display:none;\">" + (this.$$.browser.IE ? "": "<iframe id=\"jsHistoryFrame\" name=\"jsHistoryFrame\" onload=\"$$.history.load();\" src=\"about:blank\"><\/iframe>") + "<\/div><textarea id=\"jsSaveStatus\" style=\"display:none;\"><\/textarea><div id=\"tuna_jmpinfo\" style=\"visibility:hidden;position:absolute;z-index:120;overflow:hidden;\"><\/div><div id=\"tuna_alert\" style=\"display:none;position:absolute;z-Index:999;overflow:hidden;\"><\/div><\/div>"); (function() {
            this.status = new
            function() {
                this.domReady = false;
                this.load = false;
                this.busy = 0;
                this.dealt = {};
                this.regEventCount = 0;
                this.regEventHash = {};
                this.charset = (((f.__.charset ? f.__.charset: f.__.characterSet) || "").match(/^(gb2312|big5|utf-8)$/gi) || "gb2312").toString().toLowerCase();
                this.version = {
                    "gb2312": "zh-cn",
                    "big5": "zh-tw",
                    "utf-8": "en"
                } [this.charset];
                var a = $topWin.__.getElementsByTagName("script");
                this.debug = false;
                this.debugEvent = false;
                this.alertDiv = f.__.getElementById("tuna_alert");
                this.container = f.__.getElementById("jsContainer");
                this.saveStatus = f.__.getElementById("jsSaveStatus");
                this.back = false;
                this.pageValue = {
                    data: {}
                };
                this.globalValue = {};
                this.today = new Date().toStdString()
            };
            this.history = {
                isFirefox2: /Firefox\/2\.0\.0\.\d+/.test(navigator.userAgent),
                enabled: false,
                callback: {},
                info: {
                    "#": ["#", "", "", ""]
                },
                current: "#",
                blank: "blank.html",
                div: f.__.getElementById("jsHistoryDiv"),
                frame: f.frames["jsHistoryFrame"],
                iframe: null,
                isReady: false,
                count: 0,
                init: function() {
                    if (f.$$.history.frame) return;
                    this.div.innerHTML = "<iframe id=\"jsHistoryFrame\" name=\"jsHistoryFrame\" src=\"" + this.blank + "\" onload=\"$$.history.load();\"><\/iframe>";
                    this.frame = f.frames["jsHistoryFrame"];
                    this.iframe = $("jsHistoryFrame")
                },
                load: function() {
                    this.isReady = true;
                    f.$r("domReady",
                    function() {
                        var g = 0;
                        setInterval(function() {
                            var a = (f.$$.history.isFirefox2 ? f: f.$$.history.frame).location.hash.replace(/^#/, "") || "#";
                            if (a != f.$$.history.current) {
                                if (g < 1) g++;
                                else {
                                    f.$$.history.current = a;
                                    var c = f.$$.history.info[a];
                                    if (c) {
                                        $t("[history]返回标志:" + c[0] + "/" + a, "green", c.join("\t"));
                                        var d = f.$$.history.callback[c[0]];
                                        if (typeof d == "function") d.apply(c[0], c.slice(1))
                                    }
                                    if ($$.browser.Opera) f.$saveHistory()
                                }
                            } else g = 0
                        },
                        100)
                    });
                    $t("[history]初始化完成", "green");
                    var h = (f.$$.history.isFirefox2 ? f: f.$$.history.frame).location.hash.replace(/^#/, "") || "#";
                    $t("[history]返回标志:" + h, "green");
                    this.load = function() {}
                }
            };
            this.module = {
                iframe: [],
                list: {
                    address: "tuna_address_071206",
                    calendar: "tuna_calendar_071206"
                },
                tab: {},
                selectAll: {},
                checkInput: {},
                address: {
                    source: {}
                },
                calendar: {},
                jmpInfo: {
                    count: 0,
                    page: {},
                    array: {}
                },
                init: []
            };
            this.string = {
                "zh-cn": {
                    weekday: "日一二三四五六",
                    display: "@▲|▼@显示|隐藏@"
                },
                "zh-tw": {
                    weekday: "日一二三四五六",
                    display: "@▲|▼@顯示|隱藏@"
                },
                "en": {
                    weekday: "SMTWTFS",
                    display: "@Show|Hidden@"
                }
            } [this.status.version];
            this.access = {}
        }).apply(this.$$)
    };
    this.window = function() {
        this.$fixE = function(a) {
            a = f.event || a || arguments.callee.caller.arguments[0];
            $(a.$target = a.target ? (a.target.nodeType && a.target.nodeType == 3 ? a.target.parentNode: a.target) : a.srcElement);
            return a
        };
        this.$stopEvent = function(a, c) {
            a = $fixE(a);
            c = c || 0;
            if (c >= 0) a.preventDefault ? a.stopPropagation() : (a.cancelBubble = true);
            if (c != 0) a.preventDefault ? a.preventDefault() : (a.returnValue = false)
        };
        this.$getUid = function() {
            return "uid_" + (new Date()).getTime() + Math.random().toString().substr(2, 5)
        };
        this.$c = this.$createElement = function(a) {
            if (a.constructor == Array) return $(f.__.createTextNode(a.join("\n")));
            else return $(f.__.createElement(a))
        };
        this.$toJson = function(c) {
            if (typeof c == "undefined") return undefined;
            switch (c.constructor) {
            case Object:
                var d = [],
                g;
                for (var h in c) d.push(f.$toJson(h) + ":" + f.$toJson(c[h]));
                return "{" + d.join(",") + "}";
            case Array:
                return "[" + c.map(function(a) {
                    return f.$toJson(a)
                }).join(",") + "]";
            case String:
                return "\"" + c.replace(/([\n\r\\\/\'\"])/g,
                function(a) {
                    return {
                        "\n": "\\n",
                        "\r": "\\r"
                    } [a] || "\\" + a
                }) + "\"";
            case Date:
                return "new Date(" + c.getTime() + ")";
            case Number:
            case Boolean:
            case Function:
            case RegExp:
                return c.toString();
            default:
                return "null"
            }
        };
        this.$fromJson = function(a) {
            var c;
            var d = null;
            try {
                d = eval("(" + a + ")")
            } catch(e) {};
            return d
        };
        this.$pageValue = function() {
            return f.$pageValue.get.apply(f, arguments)
        };
        this.$pageValue.set = function(a, c, d) {
            d = d || f.$$.history.current;
            if (! (d in f.$$.status.pageValue.data)) f.$$.status.pageValue.data[d] = {};
            f.$$.status.pageValue.data[d][a] = c;
            if ($$.browser.Opera) f.$savePageValue()
        };
        this.$pageValue.get = function(a, c) {
            var d = f.$$.status.pageValue.data[c || f.$$.history.current];
            return d && a in d ? d[a] : null
        };
        this.$pageValue.del = function(a, c) {
            var d = f.$$.status.pageValue.data[c || f.$$.history.current];
            if (d) {
                delete d[a];
                if ($$.browser.Opera) f.$savePageValue()
            }
        };
        this.$savePageValue = function() {
            f.$$.status.saveStatus.value = $toJson(f.$$.status.pageValue)
        };
        this.$saveHistory = function() {
            var a = [];
            for (var c in f.$$.history.info) {
                var d = f.$$.history.info[c];
                if (d.constructor == Array && d.length == 4) {
                    var g = [c];
                    for (var h = 0; h < d.length; h++) g.push(escape(d[h] || ""));
                    a.push(escape(g.join("|")))
                }
            }
            f.$$.status.pageValue["historyInfo"] = a.join("|");
            f.$$.status.pageValue["historyCount"] = f.$$.history.count;
            if (f.$$.history.frame) f.$$.status.pageValue["lastHistory"] = f.$$.history.frame.location.href;
            f.$savePageValue()
        };
        this.$globalValue = function() {};
        this.$getQuery = function(a) {
            var c = (location.search || "").match(new RegExp("[\\?&]" + a + "=([^&]+)", "i"));
            return c ? unescape(c[1]) : null
        };
        this.$loadJs = function(a, c, d) {
            var g = arguments.callee;
            var h = g.queue || (g.queue = {});
            c = c || f.$$.status.charset;
            a = a.replace('{$charset}', c);
            if (a in h) {
                if (d) {
                    if (h[a]) h[a].push(d);
                    else d()
                }
                return
            }
            h[a] = d ? [d] : [];
            var i = f.__.createElement("script");
            i.type = "text/javascript";
            i.charset = c;
            i.onload = i.onreadystatechange = function() {
                if (i.readyState && i.readyState != "loaded" && i.readyState != "complete") return;
                i.onreadystatechange = i.onload = null;
                while (h[a].length) h[a].shift()();
                h[a] = null
            };
            i.src = a;
            f.__.getElementsByTagName("head")[0].appendChild(i)
        };
        this.$loadCss = function(a, c) {
            if ($$.browser.IE) f.__.createStyleSheet(a).charset = c || f.$$.status.charset;
            else {
                var d = f.__.createElement("link");
                with(d) {
                    type = "text\/css";
                    rel = "stylesheet";
                    href = a
                }
                f.__.$("head")[0].appendChild(d)
            }
        };
        this.$getCookie = function(a, c) {
            var d = f.__.cookie.match(new RegExp("(?:^|;)\\s*" + encodeURIComponent(a) + "=([^;]+)"));
            if (c === false) return d ? d[1] : null;
            if (d && c) d = d[1].match(new RegExp("(?:^|&)\\s*" + encodeURIComponent(c) + "=([^&]+)"));
            return d ? decodeURIComponent(d[1]) : null
        };
        this.$delCookie = function(a, c) {
            if (c) {
                var d = $getCookie(a, false);
                if (d === null) return;
                d = d.replace(new RegExp("(^|&)\\s*" + encodeURIComponent(c) + "=[^&]+"), "").replace(/^\s*&/, "");
                if (d) {
                    f.__.cookie = encodeURIComponent(a) + "=" + d;
                    return
                }
            }
            var g = new Date();
            g.setTime(g.getTime() - 1);
            f.__.cookie = encodeURIComponent(a) + "=;expires=" + g
        };
        this.$setCookie = function(a, c, d) {
            if (!d) {
                d = c;
                c = null
            }
            if (c) {
                var g = $getCookie(a, false) || "";
                if (g) g = (g + "&").replace(new RegExp("(^|&)\\s*" + encodeURIComponent(c) + "=[^&]+&"), "$1");
                f.__.cookie = encodeURIComponent(a) + "=" + g + encodeURIComponent(c) + "=" + encodeURIComponent(d)
            } else f.__.cookie = encodeURIComponent(a) + "=" + encodeURIComponent(d)
        };
        this.$init = function(a) {
            if (a) $topWin.$$.module.init.push(a);
            else $topWin.$$.module.init.each()
        };
        this.$parserRe = function(d) {
            var g = [];
            var h = /<[^>]+\smod=[\'\"]?([\w|]+)[^>]+/g;
            var i = /\smod_jmpInfo_page=[\'\"]?([^\'\"\s]+)/;
            var j = /id=[\'\"]?([\w\-]+)/i;
            var k = null;
            var m = null;
            var l = null; (d && d.innerHTML ? d: f.__.body).innerHTML.replace(h,
            function(a, c) {
                try {
                    if (c == "jmpInfo") {
                        if (k = a.match(i)) Ctrip.module.jmpInfo(k[1])
                    } else if ((m = a.match(j)) && (l = $(m[1]))) {
                        if (c in Ctrip.module) new Ctrip.module[c](l);
                        else g.push(l)
                    }
                } catch(e) {
                    $t("parserRe函数错误:" + func.toString().slice(0, 50) + "...", "red")
                };
                return ""
            });
            var n = setInterval(function() {
                var a = g.shift();
                if (a) $topWin.$d(a);
                else clearInterval(n)
            },
            50)
        };
        this.$d = this.$dealElement = function(c) { ($(c).getAttribute("mod") || "").replace(/\w+/ig,
            function(a) {
                if ($topWin.$$.module.list[a]) {
                    if (!$topWin.$$.module[a].list) {
                        $topWin.$$.module[a].list = [];
                        $topWin.$loadJs("http:\/\/www.100allin.com\/js\/" + $topWin.$$.module.list[a] + ".js", "utf-8")
                    }
                    $topWin.$$.module[a].list.push(c);
                    $topWin.$init()
                } else if (Ctrip.module[a]) {
                    if (a == 'jmpInfo') Ctrip.module[a](c);
                    else new Ctrip.module[a](c)
                }
                return ''
            })
        };
        this.$i = function(i) {
            var j = f.$$.access[i];
            if (j) return j;
            else {
                j = new
                function() {
                    var g = [],
                    h = [];
                    this.get = function() {
                        var a = j.value;
                        for (var c = 0; c < g.length; c++) {
                            var d = g[c].call(a);
                            if (typeof d != 'undefined') a = d
                        }
                        return a
                    };
                    this.set = function(a) {
                        for (var c = 0; c < h.length; c++) {
                            var d = h[c].call(a);
                            if (typeof d != 'undefined') a = d
                        }
                        return j.value = a
                    };
                    this.regGet = function(a) {
                        if (!a) g = [];
                        else g.push(a);
                        return
                    };
                    this.regSet = function(a) {
                        if (!a) h = [];
                        else h.push(a);
                        return
                    }
                }
            }
            return f.$$.access[i] = j
        };
        this.$fixElement = function(g) {
            function h(a, c, d) {
                if ('attachEvent' in a) a.attachEvent('on' + c, d);
                else a.addEventListener(c, d)
            }
            function i(a) {
                a = a.getElementsByTagName('input');
                for (var c = 0; c < a.length; c++) if (/checkbox|radio/.test(a[c].type)) return a[c];
                return null
            }
            function j(a) {
                if (!a) a = window.event;
                return a.srcElement || a.target
            }
            function k(a) {
                var c = a._0;
                if (c) {
                    a.htmlFor = c.id || (c.id = $getUid());
                    a._0 = null
                }
                var d = a.style;
                d.borderBottom = '#aaa 1px dashed';
                d.paddingBottom = '0px';
                d.color = '#1E1A75'
            }
            function m(a) {
                var c = a.style;
                c.borderBottom = '';
                c.paddingBottom = '';
                c.color = ''
            }
            g = g && g.nodeType ? g: f.__;
            if ($$.browser.IE6) {
                var l = g.getElementsByTagName("label");
                for (var n = 0; n < l.length; n++) {
                    var o = i(l[n]);
                    if (o && /checkbox|radio/.test(o.type))(function(lbl, box) {
                        lbl._0 = box;
                        h(lbl, 'mouseover',
                        function() {
                            k(lbl)
                        });
                        h(lbl, 'mouseout',
                        function() {
                            m(lbl)
                        })
                    })(l[n], o)
                }
            }
            if ($$.browser.IE) {
                var q = g.getElementsByTagName("select");
                for (var n = 0; n < q.length; n++) q[n].onmousewheel = function() {
                    return false
                }
            }
        };
        this.$removeTextNode = function(a) {
            if (!a) return;
            var c = a.firstChild,
            d;
            while (c) {
                d = c.nextSibling;
                if (c.nodeType == 3) a.removeChild(c);
                else $removeTextNode(c);
                c = d
            }
            return a
        };
        this.$ajax = function(d, g, h, i) {
            var j = ["MSXML2.XMLHTTP", "Microsoft.XMLHTTP"],
            k;
            try {
                k = new XMLHttpRequest()
            } catch(e) {
                for (var m = 0; m < j.length; m++) try {
                    k = new ActiveXObject(j[m]);
                    break
                } catch(e) {}
            }
            if (!k) return;
            k.open(g ? "POST": "GET", d || f.location.href, !!h);
            k.setRequestHeader("Content-Type", "application\/x-www-form-urlencoded");
            k.setRequestHeader("If-Modified-Since", new Date(0));
            function l() {
                if (f.$$.history.enabled && i) {
                    f.$$.history.init();
                    var c = "ajaxHistory_" + f.$$.history.count++;
                    f.$$.history.current = c; (function() {
                        if (f.$$.history.isReady) {
                            var a = f.$$.history.info[c] = [i, k.status == 200 ? k.responseText: null, d, g];
                            if (f.$$.history.isFirefox2) f.location.hash = c;
                            else f.$$.history.frame.location.href = f.$$.history.blank + ($$.browser.IE ? "?" + !(f.$$.history.count % 2) : "") + "#" + c;
                            if ($$.browser.Opera) f.$saveHistory();
                            $t("[history]增加历史:" + a[0] + "/" + c, "green", a.slice(1).join("\n"))
                        } else setTimeout(arguments.callee, 50)
                    })()
                }
                return (k.status == 200 ? (/xml/i.test(k.getResponseHeader("content-type")) ? k.responseXML: k.responseText) : null)
            }
            if (h) k.onreadystatechange = function() {
                if (k.readyState == 4) {
                    var n = l();
                    if (h(n) === true) {
                        setTimeout(function() {
                            f.$ajax(d, g, h)
                        },
                        1000)
                    }
                }
            };
            k.send(g || "");
            return h ? k: l()
        };
        function u(a) {
            var c = a.keyCode || a.charCode;
            if ($$.status.debug && c == 192) {
                var d = s();
                if (d && (d = d.frameElement)) d.style.display = d.style.display == "" ? "none": ""
            }
        }
        function s() {
            var a = $topWin.frames["Ctrip_debug"];
            if (a) return a;
            with(a = $topWin.$c("iframe")) {
                frameBorder = 0;
                id = name = "Ctrip_debug";
                with(style) {
                    border = "1px solid red";
                    width = "600px";
                    height = "300px";
                    position = $$.browser.IE6 ? "absolute": "fixed";
                    bottom = right = "10px";
                    background = "white"
                }
            }
            $topWin.$$.status.container.appendChild(a);
            if ($$.browser.IE6) $topWin.$r("scroll",
            function() {
                with($("Ctrip_debug").style) {
                    zoom = 1;
                    zoom = 0
                }
            });
            with((a = s()).document) {
                open();
                write("<style>body{margin:0;padding:0;font-family:Arial;font-size:12px;overflow:scroll;}div{border-bottom:1px solid #CCC;}<\/style><body><\/body>");
                close()
            }
            $topWin.__.$r("keydown", u);
            return a
        }
        this.$t = function(a, c, d) {
            if (!$topWin.$$.status.debug) return;
            if (f != $topWin) return $topWin.$t(a, c);
            var g = s();
            var h = new Date().getTime() % (1E7);
            var i = "<font id=\"msg_" + h + "\"> " + a + "<\/font>";
            var j = g.document.createElement("div");
            if (c) j.style.color = c || "black";
            if (d) j.title = d;
            j.innerHTML = "<font style=\"color:blue;\">" + h + "<\/font> " + i;
            with(g.document.body) {
                if (firstChild) insertBefore(j, firstChild);
                else appendChild(j)
            }
            return a
        };
        this.$alert = function(a, c, d, g, h) {
            a = $(a);
            var i = $("alertInfo"),
            j = $("alertTable"),
            k = 1;
            i.innerHTML = c;
            $topWin.$$.status.alertDiv.style.display = "";
            $topWin.$$.status.alertDiv.$setPos(a, g || "tl", h || "tr");
            $topWin.$$.status.alertDiv.$setIframe();
            a.className += " pubGlobal_checkinfo_input01";
            if (d !== false) a.$setDisplay();
            function m() {
                a.className = a.className.replace("pubGlobal_checkinfo_input01", "");
                $topWin.$$.status.alertDiv.style.display = "none";
                $topWin.$$.status.alertDiv.$clearIframe();
                a.$ur("onblur", m);
                f.__.body.$ur("onmousedown", m);
                a.clearAlert = null;
                f.$alert.element = null
            }
            if (a.disabled) k = 0;
            else setTimeout(function() {
                try {
                    a.focus()
                } catch(e) {
                    k = 0
                }
            },
            0);
            if (k) a.$r("onblur", m);
            else f.__.body.$r("onmousedown", m);
            f.$alert.element = a;
            a.clearAlert = m
        };
        this.checkinfo = this.$alert;
        this.$fix_height = function() {};
        this.c_linklist = {};
        this.c_allyes_text = {};
        this.c_allyes_delay = 1000
    };
    function N(a) {
        return (a.toString().match(/function([^\{]+)/i) || ["", "anonymous"])[1].replace(/\(\)/, "").trim() || "anonymous"
    }
    function w(a) {
        var c = "[" + a.event + "] ";
        c += a.obj.tagName || {
            3 : a.obj.nodeValue,
            9 : "document"
        } [a.obj.nodeType || ""] || "window";
        c += a.obj.id ? "#" + a.obj.id: (a.obj.name ? "@" + a.obj.name: "");
        c += " " + N(a.func);
        return c
    }
    function t(h) {
        return function(a) {
            a = $fixE(a);
            var c = h.module.event[a.type],
            d;
            for (var g = 0; g < c.length; g++) {
                if (c[g].enabled) {
                    try {
                        d = c[g].func.call(h, a);
                        if ($topWin.$$.status.debugEvent) $t(w(c[g]) + " (" + (typeof d == "undefined" ? "无返回值": d.toString().slice(0, 100)) + ")", null, c[g].func);
                        if (d === false) break
                    } catch(a) {
                        $t(w(c[g]) + " (执行错误)", "red", c[g].func)
                    }
                } else {
                    c.splice(g, 1);
                    g--
                }
            }
            return d
        }
    };
    function x(a, c) {
        if (typeof a == "object") return Ctrip.Object.apply(a);
        var d;
        if (c) {
            var g = f.___.innerHTML.match(new RegExp("\\sid=([\\\'\\\"]?)([\\w$]+?[_$]" + a.toReString() + ")\\1"), "g");
            if (g) {
                for (var h = 0; h < g.length; h++) {
                    d = f.$(g[h]);
                    if (d) return d
                }
            }
            return f.$(a)
        } else d = f.__.getElementById(a);
        return d ? $(d) : null
    };
    function v(g) {
        var h = this.getElementsByTagName(g);
        h.$each = function(a) {
            var c;
            if (h.length !== undefined) for (var d = 0; d < h.length && (c = a.call(this, h[d], d)) !== false; d++);
            else a.call(this, h, 0);
            return c === false ? 0 : 1
        };
        for (var i = 0; i < h.length; i++) $(h[i]);
        return h
    };
    function y() {
        return ! this.value.trim()
    };
    function B(a) {
        for (var c = 0; c < this.options.length; c++) {
            if (this.options[c].value == a) {
                this.selectedIndex = c;
                return true
            }
        }
        return false
    };
    function C(a) {
        return typeof this.attributes[a] != "undefined"
    };
    function D(a) {
        var c = $(this.parentNode);
        if (a && c && c.tagName && c.tagName.toLowerCase() != a.toLowerCase()) c = c.$parentNode(a);
        return c && c.tagName ? c: null
    };
    function F() {
        return $(this.firstChild)
    };
    function G() {
        return $(this.lastChild)
    };
    function H() {
        var a = this.childNodes;
        for (var c = 0; c < a.length; c++) $(a[c]);
        return a
    };
    function O() {
        return $(this.nextSibling)
    };
    function I() {
        return $(this.previousSibling)
    };
    function P() {
        if (this.click) this.click();
        else {
            var a = __.createEvent("MouseEvents");
            a.initMouseEvent("click", true, true, f, 0, 0, 0, 0, 0, false, false, false, false, 0, this);
            this.dispatchEvent(a)
        }
    };
    function Q(a) {
        var c = this.currentStyle || f.getComputedStyle(this, null);
        return a ? c[a] : c
    };
    function J() {
        var a, c = (a = this.getAttribute(arguments[0]) || "").split(a.indexOf("") > -1 ? "": "|");
        for (var d = 0; d < Math.max(arguments.length - 1, c.length); d++) c[d] = c[d] || arguments[d + 1] || "";
        return c
    };
    function R(i, j, k, m) {
        m = m || 50;
        if (arguments.length == 3 && typeof k == "number") {
            m = k;
            k = null
        }
        var l = this;
        if (i.constructor != Array) i = [i];
        if (j.constructor != Array) j = [j];
        i.each(function(h) {
            j.each(function(d) {
                h = h.replace(/^(on)?/i, "");
                h = h == "DOMContentLoaded" ? "domready": h.toLowerCase();
                if (h == "domready") l = f;
                var g = {
                    enabled: true,
                    obj: l,
                    event: h,
                    func: d,
                    hash: k,
                    level: m,
                    id: f.$$.status.regEventCount++
                };
                if (h == "domready" && f.$$.status.domReady || h == "load" && (l == f || l == __.body) && f.$$.status.load) d();
                else {
                    if (! (h in l.module.event)) {
                        l.module.event[h] = [];
                        if (l.attachEvent) l.attachEvent("on" + h, t(l));
                        else l.addEventListener(h, t(l), false)
                    }
                    l.module.event[h].push(g);
                    l.module.event[h].sort(function(a, c) {
                        return (a.level - c.level) || (a.id - c.id)
                    })
                }
                if (k) {
                    if (! (k in f.$$.status.regEventHash)) f.$$.status.regEventHash[k] = [];
                    f.$$.status.regEventHash[k].push(g)
                }
            })
        })
    };
    function z(h, i, j) {
        var k = this;
        if (h.constructor != Array) h = [h];
        if (i.constructor != Array) i = [i];
        h.each(function(g) {
            i.each(function(a) {
                g = g.replace(/^(on)?/i, "").toLowerCase();
                g = g == "DOMContentLoaded" ? "domready": g.toLowerCase();
                if (g == "domready") k = f;
                if (g in k.module.event) {
                    var c = k.module.event[g];
                    for (var d = 0; d < c.length; d++) {
                        if (c[d].enabled && c[d].func == a && (!j || c[d].hash == j)) {
                            c[d].enabled = false;
                            break
                        }
                    }
                }
            })
        })
    };
    function K(a) {
        var c = this;
        if (a in f.$$.status.regEventHash) {
            var d = f.$$.status.regEventHash[a],
            g;
            while (g = d.shift()) g.obj.$ur(g.event, g.func, a);
            delete f.$$.status.regEventHash[a]
        }
    };
    function S() {
        var a = this.ownerDocument;
        return a.parentWindow || a.defaultView
    };
    function T(L) {
        function M(m, l) {
            var n = [],
            o = m.match(/^([\.\#]*)([a-zA-Z0-9\-_*]+)(.*)$/i);
            if (!o) return [];
            if (o[1] == "#") {
                var q = f.$(o[2]);
                if (q) n.push(q)
            } else if (o[1] == ".") l.each(function(obj) {
                obj.$("*").$each(function(a) {
                    if (new RegExp("\\b" + o[2] + "\\b").test(a.className)) n.push($(a))
                })
            });
            else for (var u = 0; u < l.length; u++) {
                var q = l[u].$(o[2]);
                if (q) for (var s = 0; s < q.length; s++) n.push(q[s])
            }
            o[3].replace(/\[([^!=]+)(=|!=)([^\]]*)\]/gi,
            function(g, h, i, j) {
                var k = n.slice(0);
                n = [];
                k.each(function(a) {
                    h = {
                        _3: "className",
                        _0: "htmlFor"
                    } ["_" + h] || h;
                    var c = a[h] || a.getAttribute(h);
                    var d;
                    if (h == "className") d = new RegExp("\\b" + j + "\\b").test(c);
                    else d = c == j;
                    if ((i == "=") == d) n.push($(a))
                })
            });
            return n
        }
        var A = [this == f ? f.__.body: this],
        r = [],
        p = [];
        L.replace(/[^\[,]([^\[,]*(\[[^\]]*\])*)+/g,
        function(c) {
            var d = A.slice(0);
            c.replace(/(#|\*)/gi, " $1").replace(/([^\^ ])\.(\w+)/gi, "$1[className=$2]").trim().split(/\s+/g).each(function(a) {
                d = M(a, d)
            });
            r = r.concat(d)
        });
        r.each(function(a) {
            if (!a.__selNodeFlag__) {
                a.__selNodeFlag__ = true;
                p.push(a)
            }
        });
        p.each(function(a) {
            a.__selNodeFlag__ = false
        });
        return p.length == 0 ? null: p
    };
    function U() {
        var g = this,
        h = this,
        i, j = [0, 0],
        k,
        m = {
            "thin": 2,
            "medium": 4,
            "thick": 6
        };
        function l() {
            if (g == h) return;
            function d(a) {
                var c = /^(none|hidden)$/i.test(h.$getStyle("border" + a + "Style")) ? 0 : h.$getStyle("border" + a + "Width");
                return m[c] || parseInt(c, 10) || 0
            }
            j[0] += d("Left");
            j[1] += d("Top")
        }
        do {
            i = $(h).$getWin();
            if (h.tagName.match(/^(iframe|frameset)$/i)) l();
            k = -1;
            do {
                j[0] += h.offsetLeft - h.scrollLeft;
                j[1] += h.offsetTop - ($$.browser.Safari && h == i.document.body ? 0 : h.scrollTop);
                switch (h.$getStyle("position")) {
                case "absolute":
                    l();
                    break;
                case "fixed":
                    k = 1;
                    break
                }
            } while ( h . offsetParent && h != h . offsetParent && ( h = $ ( h . offsetParent )) && h != f.___);
            if ($$.browser.Safari) {
                j[0] += i.__.body.leftMargin || 0;
                j[1] += i.__.body.topMargin || 0
            }
            if (k == 1 || i != $topWin) {
                j[0] += i.___.scrollLeft * k;
                j[1] += i.___.scrollTop * k
            }
        } while ( h = i . frameElement );
        return j
    };
    function V(k, m, l) {
        function n(h, i) {
            function j(a, c, d, g) {
                return d + {
                    "l": 0,
                    "c": c.offsetWidth / 2,
                    "r": c.offsetWidth,
                    "t": 0,
                    "m": c.offsetHeight / 2,
                    "b": c.offsetHeight
                } [a || "l"] * g
            }
            return j(m.match(h), this, j(l.match(h), k, o[i], 1), -1) + "px"
        }
        var o = k.$getPos();
        m = m || "lt";
        l = l || "lb";
        this.style.left = n.call(this, /[lcr]/i, 0);
        this.style.top = n.call(this, /[tmb]/i, 1)
    };
    function W(c) {
        if (c !== true && !$$.browser.IE6) return;
        if (this.module.iframe) g = this.module.iframe;
        else {
            function d() {
                for (var a = 0; a < $topWin.$$.module.iframe.length; a++) {
                    if ($topWin.$$.module.iframe[a].$getStyle("display") == "none") return $topWin.$$.module.iframe[a]
                }
            }
            var g = d();
            if (!g) {
                g = $topWin.$c("iframe");
                with(g.style) {
                    width = height = "0px";
                    background = "#FFF";
                    position = "absolute";
                    display = "none";
                    zIndex = 100
                }
                g.frameBorder = 0;
                g.id = g.name = $getUid();
                $topWin.$$.status.container.appendChild(g);
                $topWin.$$.module.iframe.push(g);
                with($topWin.frames[g.id].document) {
                    open();
                    write('<style>html,body{overflow:hidden}</style>');
                    close()
                }
            }
            this.module.iframe = g
        }
        g.$setPos(this, "tl", "tl");
        with(g.style) {
            width = this.offsetWidth + "px";
            height = this.offsetHeight + "px";
            display = ""
        }
        return g
    };
    function X() {
        var a = this.module.iframe;
        if (a) {
            a.style.display = "none";
            this.module.iframe = null
        }
        return a
    };
    function bd(a, c, d) {
        if (!a) return null;
        c = c || "n";
        var g = new RegExp(({
            1 : "n",
            3 : "t",
            8 : "c"
        } [a.nodeType]) || "o", "i");
        return c.match(g) ? a: d.call(a, c)
    }
    function Y(a) {
        var c = this,
        d = c.firstChild || c.nextSibling;
        if (!d) do {
            c = c.parentNode;
            if (c == f.__.body) return null;
            d = c.nextSibling
        } while (! d );
        return $($abs(d, a, arguments.callee))
    };
    function Z(a) {
        if (this == f.__.body) return null;
        var c = this.previousSibling;
        if (c) {
            while (c.lastChild) c = c.lastChild
        } else c = this.parentNode;
        return $($abs(c, a, arguments.callee))
    };
    function ba() {
        if (!this.form) return;
        try {
            this.blur()
        } catch(e) {};
        var a = this.form.elements,
        c;
        for (var d = 0; d < a.length; d++) {
            if (c) {
                if (!$(a[d]).disabled && a[d].$isDisplay()) try {
                    a[d].focus();
                    return
                } catch(e) {}
            }
            if (a[d] == this) c = true
        }
    };
    function bb() {
        var a = this.$getPos();
        with($topWin.___) {
            scrollLeft = a[0] - 80;
            scrollTop = a[1] - 80
        }
    };
    function bc() {
        var a = this;
        do {
            if (a.tagName == "INPUT" && a.type == "hidden" || a.$getStyle("display") == "none" || a.$getStyle("visibility") == "hidden") return false
        } while (( a = a . $parentNode ()) && a.nodeType == 1);
        return true
    };
    this.Object = function() {
        if (!this || this.nodeType == 3 || this.$) return this;
        if (this.__) this.$ = x;
        else this.$ = v;
        this.module = {};
        this.module.event = {};
        if (this.nodeType == 1) {
            if (this.tagName == "INPUT" && /^(text|hidden)$/i.test(this.type) || this.tagName == "TEXTAREA") this.isNull = y;
            if (/^SELECT$/.test(this.tagName)) this.$setValue = B
        }
        if (!this.hasAttribute) this.hasAttribute = C;
        this.$parentNode = D;
        this.$firstChild = F;
        this.$lastChild = G;
        this.$childNodes = H;
        this.$nSib = this.$nextSibling = O;
        this.$pSib = this.$previousSibling = I;
        this.$click = P;
        this.$getStyle = Q;
        this.$getPara = J;
        this.$r = this.$regEvent = R;
        this.$ur = this.$unregEvent = z;
        this.$urh = this.$unregEventHash = K;
        this.$getWin = S;
        this.$g = this.$selNode = T;
        this.$getPos = U;
        this.$setPos = V;
        this.$setIframe = W;
        this.$clearIframe = X;
        this.$nAbs = Y;
        this.$pAbs = Z;
        this.$focusNext = ba;
        this.$setDisplay = bb;
        this.$isDisplay = bc;
        return this
    };
    this.Array = function() {
        this.each = function(a) {
            for (var c = 0; c < this.length; c++) if ((a ? a(this[c], c) : this[c]()) === false) return false;
            return true
        };
        if ($$.browser.IE) this.map = function(func) {
            var d = [];
            for (var g = 0; g < this.length; g++) d.push(func(this[g]));
            return d
        }
    };
    this.Number = function() {
        this.parseCur = function(a) {
            var c = this.toFixed(a || 2),
            d = /(\d)(\d{3}[,\.])/;
            while (d.test(c)) c = c.replace(d, "$1,$2");
            c = c.replace(/^(-?)\./, "$10.");
            return a === 0 ? c.replace(/\..*$/, "") : c
        }
    };
    this.String = function() {
        this.replaceWith = function(d) {
            return this.replace(/\{\$(\w+)\}/g,
            function(a, c) {
                if (c in d) return d[c];
                else return a
            })
        };
        this.trim = function() {
            return this.replace(/^\s+|\s+$/g, '')
        };
        this.isEmail = function() {
            var a = /^[^@\s]+@[^@\.\s]+(\.[^@\.\s]+)+$/;
            return a.test(this)
        };
        this.isDateTime = function() {
            var a = f.$$.status.version.match(/^zh-/) ? this: this.replace(/^(\d{1,2})-(\d{1,2})-(\d{4})$/, "$3-$1-$2");
            var c = a.match(/^((19|20)\d{2})-(\d{1,2})-(\d{1,2})$/);
            if (!c) return false;
            for (var d = 1; d < 5; d++) c[d] = parseInt(c[d], 10);
            if (c[3] < 1 || c[3] > 12 || c[4] < 1 || c[4] > 31) return false;
            var g = new Date(c[1], c[3] - 1, c[4]);
            return g.getDate() == c[4] ? g: null
        };
        this.toReString = function() {
            return this.replace(/([\.\\\/\+\*\?\[\]\{\}\(\)\^\$\|])/g, "\\$1")
        };
        this.isChinaIDCard = function() {
            var a = this.toLowerCase().match(/./g);
            if (this.match(/^\d{17}[\dx]$/i)) {
                var c = 0,
                d = [7, 9, 10, 5, 8, 4, 2, 1, 6, 3, 7, 9, 10, 5, 8, 4, 2];
                for (var g = 0; g < 17; g++) c += parseInt(a[g], 10) * d[g];
                if ("10x98765432".charAt(c % 11) != a[17]) return false;
                return !! this.replace(/^\d{6}(\d{4})(\d{2})(\d{2}).+$/, "$1-$2-$3").isDateTime()
            }
            if (this.match(/^\d{15}$/)) return !! this.replace(/^\d{6}(\d{2})(\d{2})(\d{2}).+$/, "19$1-$2-$3").isDateTime();
            return false
        };
        this.parseStdDate = function() {
            var c = "January|1@February|2@March|3@April|4@May|5@June|6@July|7@August|8@September|9@October|10@November|11@December|12",
            d = this.replace(/[ \-,\.\/]+/g, "-").replace(/(^|-)0+(?=\d+)/g, "$1").replace(/[a-z]{3,}/i,
            function(a) {
                return (_1 = c.match(new RegExp("(^|@)" + a + "[^\\|]*\\|(\\d+)", "i"))) ? _1[2] : a
            }).replace(/^([^-]{1,2}-[^-]{1,2})-([^-]{4})$/, "$2-$1");
            return d.isDateTime() ? d: null
        };
        this.parseEngDate = function() {
            var a = this.parseStdDate();
            if (!a) return null;
            var c = a.match(/^(\d{4})-(\d{1,2})-(\d{1,2})$/);
            return "Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec".split("|")[parseInt(c[2]) - 1] + "-" + c[3] + "-" + c[1]
        }
    };
    this.Date = function() {
        this.dateValue = function() {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate())
        };
        this.addDate = function(a) {
            return new Date(this.getFullYear(), this.getMonth(), this.getDate() + a)
        };
        this.toStdString = function() {
            return this.getFullYear() + "-" + (this.getMonth() + 1) + "-" + this.getDate()
        };
        this.toEngString = function() {
            return "Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec".split("|")[this.getMonth()] + "-" + this.getDate() + "-" + this.getFullYear()
        }
    };
    this.Boolean = function() {};
    this.Function = function() {};
    this.RegExp = function() {};
    this.module = new
    function() {
        this.linklist = function(a) {
            var c = a.getAttribute('mod_linklist_class');
            if (c === null) c = 'pubSidebar_linkmargin01';
            var d = '<a class="' + c + '" href="{$link}" title="{$text}" target="{$target}">{$text}</a>';
            var g = a.getAttribute('mod_linklist_id');
            if (!g || !(g = window.c_linklist[g]) || g.constructor !== Array) return;
            for (var h = 0; h < g.length; h++) {
                var i = g[h].split('|', 2);
                g[h] = d.replaceWith({
                    text: $s2t(i[0]),
                    link: i[1],
                    target: g[h].target || '_2'
                })
            }
            a.innerHTML = g.join('')
        };
        this.allyes = function(g) {
            var h = n("user") || n("mod_allyes_user");
            if (!h) {
                var i = n('mod_allyes_buttons', window);
                var j = n('mod_allyes_text', window.c_allyes_text);
                if (!i && !j) return
            }
            var k = '<div class="pubGlobal_ad140x60" style="height:{$height}px">{$iframe}<\/div>';
            var m = '<div class="pubGlobal_adtxt140">{$text}<\/div>';
            var l = '<iframe marginheight="0" width="100%" height="100%" marginwidth="0" frameborder="0" scrolling="no" src="http://allyes.ctrip.com/main/adfshow?user={$user}&db=ctrip&border=0&local=yes"><\/iframe>';
            setTimeout(function() {
                if (h) {
                    if (h.indexOf('@') > -1) h = o(h.split('@'));
                    g.innerHTML = l.replace('{$user}', h)
                } else {
                    var a = [];
                    if (i) a = i.map(function(b) {
                        b.button = b.button || ';';
                        return k.replace('{$height}', b.height).replace('{$iframe}', l.replace('{$user}', b.user))
                    });
                    if (j) a.push(m.replace('{$text}', $s2t(j)));
                    g.innerHTML = a.join('')
                }
            },
            window.c_allyes_delay);
            function n(a, c) {
                var d = g.getAttribute(a);
                if (!d) return null;
                if (c) return c[d] || null;
                else return d
            }
            function o(a) {
                var c = /^(SearchFlights\.aspx|SearchHotels\.aspx|query\.asp)$/i;
                var d = location.pathname;
                d = d.slice(d.lastIndexOf('/') + 1);
                return c.test(d) ? a[0] : a[1]
            }
        };
        this.notice = function(a) {
            var c;
            a.module.notice = new
            function() {
                this.enabled = true;
                this.tip = a.getAttribute("mod_notice_tip") || "";
                this.check = function() {
                    if (a.module.notice.enabled) {
                        with(a) {
                            if (isNull()) {
                                style.color = "gray";
                                value = module.notice.tip
                            } else style.color = ""
                        }
                    }
                };
                this.isNull = a.isNull = function() {
                    return a.value.trim() == "" || a.value == a.module.notice.tip
                }
            };
            a.$r("focus",
            function() {
                c = true;
                if (a.module.notice.enabled) {
                    a.style.color = "";
                    if (a.value == a.module.notice.tip) a.value = ""
                }
            },
            10);
            a.$r("blur",
            function() {
                c = false;
                a.module.notice.check()
            },
            90);
            if (a.form) {
                var d = $(a.form);
                d.$r("submit",
                function() {
                    if (a.isNull()) a.value = "";
                    setTimeout(function() {
                        if (!c) a.module.notice.check()
                    },
                    1)
                });
                if (!$$.browser.Opera) f.$r("beforeunload", a.module.notice.check)
            }
            a.module.notice.check()
        };
        this.tab = function(h) {
            var i = f.$g(h.getAttribute("mod_tab_button") || "");
            var j = f.$g(h.getAttribute("mod_tab_panel") || "");
            var k = parseInt(h.getAttribute("mod_tab_select") || 1, 10);
            var m = ((h.getAttribute("mod_tab_event") || "").match(/^mouseover$/i) || "click").toString();
            if (!i || !j) return;
            h.module.tab = new
            function() {
                this.funcListHash = {};
                this.select = function(a) {
                    if (this.funcListHash[a - 1]) this.funcListHash[a - 1]()
                }
            };
            i.each(function(d, g) {
                h.module.tab.funcListHash[g] = function() {
                    i.each(function(a, c) {
                        a.className = a.className.replace(/_(no)?current/g, "_" + (g == c ? "": "no") + "current");
                        if (j[c]) j[c].style.display = (g == c) ? "": "none"
                    })
                };
                d.$r(m, h.module.tab.funcListHash[g])
            });
            h.module.tab.select(k)
        };
        this.display = function(j) {
            var k = j.$getPara("mod_display_panel"),
            m = [];
            k.each(function(a) {
                a = f.$(a) || f.$selNode(a);
                if (a) {
                    if (a.length) a.each(function(a) {
                        m.push(a)
                    });
                    else m.push(a)
                }
            });
            j.$r("click",
            function() { (function(g) {
                    for (var h = 0; h < g.childNodes.length; h++) {
                        with(g.childNodes[h]) {
                            if (nodeType == 3) {
                                var i = new RegExp($$.string.display.match(/[^@]+/g).join("|"), "gi");
                                nodeValue = nodeValue.replace(i,
                                function(a) {
                                    var c = new RegExp("@" + a + "\\|([^@]+)|([^@]+)\\|" + a + "@", "i");
                                    var d = $$.string.display.match(c);
                                    return d[1] || d[2]
                                })
                            } else arguments.callee(g.childNodes[h])
                        }
                    }
                })(j);
                m.each(function(a) {
                    a.style.display = a.$getStyle("display") == "none" ? "": "none"
                })
            })
        };
        this.selectAll = function(d) {
            var g = f.$selNode(d.getAttribute("mod_selectAll_input") || "");
            if (!g) return;
            g.each(function(c) {
                if (c != d) c.$r("onclick",
                function() {
                    d.checked = g.each(function(a) {
                        if (a != d && !a.checked) return false
                    })
                })
            });
            d.$r("click",
            function() {
                g.each(function(a) {
                    a.checked = d.checked
                })
            })
        };
        this.validate = function(a) {
            var c = f.$(a.getAttribute("mod_validate_true") || "");
            var d = f.$(a.getAttribute("mod_validate_false") || "");
            var g = a.getAttribute("mod_validate_function") || "";
            if (!g) return;
            var h = g.match(/^\/(.*?[^\\])\/([gmi]*?)$/);
            var i, j, k;
            g = f[g];
            if (h || g) {
                a.module.validate = new
                function() {
                    this.check = function() {
                        if (a.value || !c && !d) k = !(j = g ? g(a.value, a) : a.value.match(new RegExp(h[1], h[2])));
                        else j = k = false;
                        if (c) c.style.display = j ? "": "none";
                        if (d) d.style.display = k ? "": "none"
                    }
                };
                a.$r("focus",
                function() {
                    i = setInterval(a.module.validate.check, 200)
                });
                a.$r("blur",
                function() {
                    a.module.validate.check();
                    clearInterval(i)
                })
            }
        }
    };
    this.debug = new
    function() {};
    this.Date.apply(f.Date.prototype);
    this.Variable.apply(f);
    this.Number.apply(f.Number.prototype);
    this.String.apply(f.String.prototype);
    this.Array.apply(f.Array.prototype);
    this.Boolean.apply(f.Boolean.prototype);
    this.Function.apply(f.Function.prototype);
    this.RegExp.apply(f.RegExp.prototype);
    this.window.apply(f);
    this.Object.apply(f);
    this.Object.apply(f.__);
    this.Object.apply(f.___);
    this.Object.apply(f.$$.status.alertDiv);
    this.init = new
    function() {
        var g = __.domain;
        if (/\.ctrip(travel)?\.com$/i.test(g)) {
            g = /travel\.com$/i.test(g) ? g.split('.').slice(1).join('.') : 'ctrip.com';
            __.write("<script src=\"http:\/\/www." + g + "\/rp\/uiScript.asp\"><\/script>")
        }
        if (f.$$.status.charset == 'big5') __.write("<script src=\"http:\/\/webresource.ctrip.com\/code\/js\/public\/public_s2t.js\" charset=\"utf-8\"><\/script>");
        else f.$s2t = function(a) {
            return a
        };
        if ($$.browser.IE6) try {
            __.execCommand("BackgroundImageCache", false, true)
        } catch(e) {};
        f.$$.status.debug = /\$debug\$/i.test($topWin.name) || /^(true|1)$/.test($getQuery("debug"));
        f.$$.status.debugEvent = /\$debugEvent\$/i.test($topWin.name) || /^(true|1)$/.test($getQuery("debugEvent"));
        f.$$.status.alertDiv.innerHTML = f.$$.status.version.match(/^zh-/) ? "<table id=\"alertTable\" cellpadding=\"0\" cellspacing=\"0\" style=\"text-align:center;\"><tr><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_tl.gif) left top no-repeat;\"><\/td><td style=\"height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_tm.gif) left top repeat-x;\"><\/td><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_tr.gif) left top no-repeat;\"><\/td><\/tr><tr><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_ml.gif) left top repeat-y;\"><\/td><td id=\"alertInfo\" style=\"margin:0;padding:5px 10px 10px 5px;background:#FFFFE8;\">内容<\/td><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_mr.gif) left top repeat-y;\"><\/td><\/tr><tr><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_bl.gif) left top no-repeat;\"><\/td><td style=\"height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_bm.gif) left top repeat-x;\"><\/td><td style=\"width:10px;height:10px;background:url(http:\/\/pic.ctrip.com\/common\/blk_jmpInfo02_br.gif) left top no-repeat;\"><\/td><\/tr><\/table>": "<table id=\"alertTable\" style=\"font-family:Arial;margin:0;\" cellpadding=\"0\" cellspacing=\"0\"><tr><td style=\"margin:0;padding:0px 2px 2px 0px;background:#E7E7E7;\"><div id=\"alertInfo\" style=\"margin:0px;padding:10px;font-size:12px;text-align:left;background:#FFFFE8;border:1px solid #FFDF47;color:#000;white-space:nowrap;\">内容<\/div><\/td><\/tr><\/table>";
        function h(c) {
            function d() {
                if (f.$$.status.domReady) return;
                var a;
                f.$$.status.domReady = true;
                if ("domready" in f.module.event) {
                    while (a = f.module.event["domready"].shift()) if (a.enabled) try {
                        a.func(c)
                    } catch(c) {
                        $t("domReady函数错误:" + a.func.toString().slice(0, 100) + "...", "red", a.func)
                    }
                }
            }
            if ($$.browser.Safari || $$.browser.Opera) setTimeout(d, 1);
            else d()
        }
        if ($$.browser.Moz) __.addEventListener("DOMContentLoaded", h, false);
        else if ($$.browser.IE) {
            if (!f.frameElement)(function() {
                try {
                    f.___.doScroll("left")
                } catch(e) {
                    setTimeout(arguments.callee, 50);
                    return
                }
                h()
            })()
        } else if ($$.browser.Safari) {
            var i = setInterval(function() {
                if (f.__.readyState == "loaded" || f.__.readyState == "complete") {
                    clearInterval(i);
                    h()
                }
            },
            10)
        }
        function loadPageValue() {
            var a = f.$$.status.saveStatus.value;
            if (a) $$.status.back = true;
            f.$$.status.pageValue = f.$fromJson(a || "{}");
            if (! ("data" in f.$$.status.pageValue)) f.$$.status.pageValue.data = {};
            if (!$$.browser.Opera) f.$r("beforeunload", [f.$saveHistory, f.$savePageValue], 90)
        }
        function loadHistory() { (f.$$.status.pageValue["historyInfo"] || "").split("|").each(function(a) {
                var c = unescape(a).split("|");
                if (c.length == 5) {
                    for (var d = 0; d < c.length; d++) c[d] = unescape(c[d]);
                    f.$$.history.info[c[0]] = c.slice(1);
                    $t("[history]恢复历史:" + c[1] + "/" + c[2], "green", c.slice(2).join("\r"))
                }
            });
            f.$$.history.count = parseInt(f.$$.status.pageValue["historyCount"] || 0, 10) || 0
        }
        f.$r("domReady",
        function() {
            $(f.__.body);
            loadPageValue();
            loadHistory();
            var a = f.$$.status.pageValue["lastHistory"];
            if (a) if ($$.browser.IE || $$.browser.Opera) {
                $r("load",
                function() {
                    setTimeout(function() {
                        f.$$.history.init()
                    },
                    1)
                })
            } else f.$$.history.init()
        },
        10);
        f.$r("domready", [f.$parserRe, f.$fixElement]);
        f.$r("load", [h,
        function() {
            f.$$.status.load = true
        }])
    }
};
var Ctrip = new $Ctrip(window);
this.jmpInfo = (function() {
    var d = "http:\/\/www.100allin.com\/css\/control_jmpinfo_tuna_071206.css";
    var g = "\/webresource\/ui\/jmpinfo_tuna\/";
    var h = "http:\/\/webresource.ctrip.com\/code\/js\/resource\/jmpinfo_tuna\/";
    var i = $("tuna_jmpinfo");
    function j() {
        $loadCss(d);
        _.___.$r("mouseover",
        function(a) {
            var c = $fix(E).$target;
            if (c) k(c)
        })
    }
    i.$("mouseover",
    function() {});
    i.$("mouseout",
    function() {});
    function k(a) {}
    function m(a) {}
    return function(a) {
        if (!$$.module.jmpInfo.count) j();
        $$.module.jmpInfo.count++
    }
})();
Ctrip.module.jmpInfo = (function() {
    var o = '\/webresource\/ui\/jmpinfo_tuna\/';
    var q = 'http:\/\/www.100allin.com\/css\/control_jmpinfo_tuna_071206.css';
    var u = {
        CraftType: 'http:\/\/webresource.ctrip.com\/code\/js\/resource\/jmpinfo_tuna/CraftType_{$charset}.js'
    };
    var s = {
        "align-center": "cbct",
        "align-left": "lblt",
        "corner-left": "rblt",
        "align-right": "rbrt",
        "corner-right": "lbrt",
        "above-align-left": "ltlb",
        "above-align-right": "rtrb"
    };
    var L = '__jpi_';
    var M = 200;
    var A = 400;
    var r = null,
    p = null,
    f = null,
    N = 0,
    w = null,
    t = null,
    x = {},
    v = {},
    y = {},
    B = false;
    window.$r('domReady', C);
    return function(a) {
        C();
        if (a.nodeType == 1) {
            if (!a.id) a.id = L + N++;
            J(a)
        } else {
            K(a)
        }
    };
    function C() {
        if (B) return;
        B = true;
        $loadCss(q);
        r = $("tuna_jmpinfo");
        var a = document.documentElement;
        if (a.attachEvent) a.attachEvent('onmouseover', D);
        else a.addEventListener('mouseover', D, false)
    }
    function D(a) {
        var c = P(a),
        d = null;
        if (!c) return;
        if (c.id && (c.id in x)) {
            if (c != p && c != f) {
                f = c;
                clearTimeout(t);
                t = setTimeout(H, A)
            }
        } else if ((d = c.getAttribute('mod')) == 'jmpInfo') {
            J(c);
            if (c != p && c != f) {
                f = c;
                clearTimeout(t);
                t = setTimeout(H, A)
            }
        } else if (p) {
            if (I(c, p, r)) clearTimeout(w);
            else w = setTimeout(O, M)
        } else if (f) {
            if (!I(c, f)) {
                clearTimeout(t);
                f = null
            }
        }
    }
    function F(a) {
        if (!a.$getPos) $(a);
        var c = a.$getPos();
        return {
            left: c[0],
            top: c[1]
        }
    }
    function G(a, c) {
        var d = a.style;
        if (!c) {
            d.visibility = 'hidden';
            d.left = d.top = '-500px';
            a.$clearIframe()
        } else {
            var d = a.style;
            d.left = c.left + 'px';
            d.top = c.top + 'px';
            d.visibility = 'visible';
            a.$setIframe()
        }
    }
    function H() {
        if (!f) return;
        var a = R(f);
        if (!a) return;
        p = f;
        f = null;
        r.innerHTML = v[a.page];
        for (var c = 1; el = document.getElementById('para' + c); c++) el.innerHTML = a.content[c - 1] || '';
        for (var c = 1; el = document.getElementById('array' + c); c++) el.innerHTML = a.para[c - 1] || '';
        G(r, Q(p, a.position))
    }
    function O() {
        p = null;
        G(r, null)
    }
    function I(a, c, d) {
        while (a && a != c && a != d) a = a.parentNode;
        return !! a
    }
    function P(a) {
        a = a || window.event;
        return a.srcElement || a.target
    }
    function Q(a, c) {
        var d = F(a);
        var g = a.offsetWidth,
        h = a.offsetHeight;
        var i = r.offsetWidth,
        j = r.offsetHeight;
        var k = {
            l: 0,
            c: g >> 1,
            r: g
        };
        var m = {
            t: 0,
            c: h >> 1,
            b: h
        };
        var l = {
            l: 0,
            c: i >> 1,
            r: i
        };
        var n = {
            t: 0,
            c: j >> 1,
            b: j
        };
        d.left += k[c[0]] - l[c[2]];
        d.top += m[c[1]] - n[c[3]];
        return d
    }
    function J(a) {
        var c = z(a, 'mod_jmpInfo_page', 'default_normal.asp');
        var d = K(c);
        var g = z(a, 'mod_jmpInfo_position', '');
        if (!g || !(g in s)) {
            g = 'lblt'.split('');
            var h = F(a);
            if (h.left > 500) g[0] = g[2] = 'r'
        } else {
            g = s[g].split('')
        }
        d.position = g;
        d.content = z(a, 'mod_jmpInfo_content', '').split('|');
        x[a.id] = d
    }
    function R(a) {
        var c = x[a.id];
        if (!v[c.page]) return null;
        if (c.search) c.para = c.search.hash[c.search.key] || [];
        return c
    }
    function z(a, c, d) {
        return a.getAttribute(c) || d || ''
    }
    function K(a) {
        var c = a,
        d = null;
        var g = a.indexOf('?');
        if (g >= 0) {
            c = a.slice(0, g).trim();
            d = T(a.slice(g + 1))
        }
        if (! (c in v)) S(c);
        return {
            page: c,
            search: d
        }
    }
    function S(c) {
        v[c] = false;
        $ajax(o + c, null,
        function(a) {
            if (a) v[c] = a.replace(/\n/g, '').replace(/^[\s\S]*<body.*?>|<\/body>[\s\S]*$/gi, '')
        })
    }
    function T(a) {
        var c = a.indexOf('=');
        if (c == -1) return null;
        var d = a.slice(0, c);
        var g = a.slice(c + 1);
        if (! (d in y)) U(d);
        return {
            hash: y[d],
            key: g
        }
    }
    function U(g) {
        var h = y[g] = {};
        $loadJs(u[g], null,
        function() {
            var a = $$.module.jmpInfo.array[g].slice(1, -1).split('@');
            for (var c = 0; c < a.length; c++) {
                var d = a[c].split('|');
                h[d[0]] = d
            }
        })
    }
})();