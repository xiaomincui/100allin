(function() {
    var z = /^\w+:\/\/([^\/]+)/;
    var A = /\.ctrip\.com|\.sh\.ctriptravel\.com/;
    var q = /^([\w-]+\.)?(.+)\.(com|net|org|info|biz|cc|tv|cn|gov\.cn|name|mobi)$/;
    var B = /ctrip\.com\.hk|ctrip\.com\.cn|sh\.ctriptravel\.com/;
    var C = /english\.|\.english\./;
    var r = "Session";
    var D = "2880";
    var s = "SmartLinkCode={si}&SmartLinkKeyWord={ke}&SmartLinkQuary={qu}&SmartLinkHost={ho}&SmartLinkLanguage={la}";
    var t = ['google|google|q=|UTF-8', 'baidu|baidu|wd=;word=;kw=|URLEncode', 'yahoo|yahoo|p=|UTF-8', 'yahoo|yisou|search:|UTF-8', 'yahoo|3721|p=|URLEncode', 'sohu|sogou|query=|URLEncode', 'sohu|sohu|query=|URLEncode', 'sina|sina||', 'sina|iask|k=;_2=;key=|URLEncode', '163|163.com|q=|URLEncode', 'tom|tom.com|word=;w=|URLEncode', 'hao123|hao123.com||', '265|265.com||', '21cn|21cn.com|keyword=|URLEncode', 'qq|qq.com||', 'qq|soso.com|w=|URLEncode', 'online|online.sh||', '9991|9991.com||', 'live|msn|q=|UTF-8', 'yodao|yodao|q=|UTF-8', 'lycos|lycos|query=|UTF-8', 'ask|.ask.com|q=|UTF-8', 'altavista|altavista|q=|UTF-8', 'search|search.com|q=|UTF-8', 'netscape|netscape|query=|UTF-8', 'zhongsou|zhongsou|w=;word=|URLEncode', 'alice|alice.it|qs=|', 'teoma|teoma|q=|UTF-8', 'earthlink|earthlink|q=|UTF-8', 'cnn|cnn|query=|', 'looksmart|looksmart|key=|UTF-8', 'about|about|terms=|', 'excite|excite|qkw=;q_all=|', 'mamma|mamma|query=|UTF-8', 'alltheweb|alltheweb|q=|UTF-8', 'gigablast|gigablast|q=|UTF-8', 'aol|aol|query=|UTF-8'];
    var m = document.referrer;
    var f = m.match(z);
    if (f && !A.test(f = f[1])) {
        var u = document.domain;
        var v = C.test(u) ? 'en': 'zh';
        var E = location.href;
        var g = {};
        var w = [];
        var n;
        if ((g[r] = F()) || (g[r] = G())) {
            g.expires = new Date((new Date()).getTime() + D * 3600000).toGMTString();
            g.path = '/';
            g.domain = u.match(B) || 'ctrip.com';
            for (var x in g) w.push(x + '=' + g[x]);
            document.cookie = w.join('; ')
        }
    }
    function F() {
        if (n = E.match(new RegExp('[/?&]c=([^&]+)'))) return 0;
        var c = '',
        h = '',
        a = '',
        d = '';
        var e, b, j = 0,
        H = t.length;
        while (j < H) {
            b = t[j].split('|');
            if (f.indexOf(b[1]) > -1) {
                c = b[0];
                d = b[3];
                for (var l = 0,
                o = b[2].split(';'), p, y = o.length; l < y; l++) if (p = m.match(new RegExp('[/?&]' + o[l] + '([^&]+)'))) {
                    a = p[1];
                    break
                }
                break
            }
            j++
        }
        if (!c) {
            c = q.test(f) ? f.match(q)[2] : '';
            if (!c) return 0
        } else if (c == 'google' && /gb2312/i.test(m) || d == 'URLEncode') a = '_1.' + a;
        else if (d == 'UTF-8') a = '_0.' + decodeURIComponent(a);
        else a = '_0.' + a;
        a = escape(a);
        e = {
            si: c,
            ke: h,
            qu: a,
            ho: f,
            la: v
        };
        return s.replace(/\{(\w+)\}/g,
        function(k, i) {
            return e[i]
        })
    }
    function G() {
        if (!n) return 0;
        var c = n[1],
        h = '',
        a = '',
        d = '',
        e,
        b;
        if (c.indexOf('A') > -1) {
            b = c.split('A');
            h = b[0];
            a = b[1]
        }
        if (!h) return 0;
        else a = (a == 1) ? '': a;
        a = escape(a);
        e = {
            si: h,
            ke: a,
            qu: d,
            ho: f,
            la: v
        };
        return s.replace(/\{(\w+)\}/g,
        function(k, i) {
            return e[i]
        })
    }
})(); (function() {
    var c = location.search || "";
    function h(k) {
        var i = c.match(new RegExp("[\\?&]" + k + "=([^&]+)", "i"));
        return i ? unescape(i[1]) : null
    };
    var a = [],
    d;
    var e = ["campaign", "adid"];
    for (var b = 0; b < e.length; b++) {
        d = h(e[b]);
        if (d) a.push(e[b] + "=" + escape(d))
    }
    var j = document.domain.match(/ctrip\.com\.hk|ctrip\.com\.cn|sh\.ctriptravel\.com/) || "ctrip.com";
    document.cookie = "traceExt=" + a.join("&") + "; domain=" + j + "; path=/; expires=" + new Date((new Date()).getTime() + 168 * 3600000).toGMTString()
})();