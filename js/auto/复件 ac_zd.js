﻿/*********************************************************
文件名：ac_ad.js
Encode：utf-8
Copuright(c) 2010-2011 徐奕峰
文件编号：Auto_Words_js_6
创建人：徐奕峰
版本：1.0
日期：2010-08-17
修改人：徐奕峰
日期：
描述：主页港口搜索框的自动完成功能（广告版）
      
      
前台：new_auto_div_2010-07-07.aspx
      
备注：
**********************************************************/

var sp = '[{"c":"yangpu", "z":"洋浦"},{"c":"haikou", "z":"海口"},{"c":"Chiwan", "z":"赤湾"},{"c":"Fuzhou", "z":"福州"},{"c":"Huangpu", "z":"黄埔"},{"c":"Jiujiang", "z":"九江"},{"c":"Macau", "z":"澳门"},{"c":"Nansha", "z":"南沙"},{"c":"Shekou", "z":"蛇口"},{"c":"Shidao", "z":"石岛"},{"c":"Wuhu", "z":"芜湖"},{"c":"Xingang", "z":"新港"},{"c":"Yantian", "z":"盐田"},{"c":"Zhangjiagang", "z":"张家港"},{"c":"Zhongshan", "z":"中山"},{"c":"Foshan", "z":"佛山"},{"c":"Jiangmen", "z":"江门"},{"c":"aomen", "z":"澳门"},{"c":"basuo", "z":"八所"},{"c":"beihai", "z":"北海"},{"c":"changle", "z":"长乐"},{"c":"changshu", "z":"常熟"},{"c":"chongqing", "z":"重庆"},{"c":"dalian", "z":"大连"},{"c":"fangcheng", "z":"防城"},{"c":"guangzhou", "z":"广州"},{"c":"hongkong", "z":"香港"},{"c":"jiangyin", "z":"江阴"},{"c":"jieyang", "z":"揭阳"},{"c":"jinzhou", "z":"锦州"},{"c":"lianyungang", "z":"连云港"},{"c":"longkou", "z":"龙口"},{"c":"nanjing", "z":"南京"},{"c":"nantong", "z":"南通"},{"c":"ningbo", "z":"宁波"},{"c":"qingdao", "z":"青岛"},{"c":"qinhuangdao", "z":"秦皇岛"},{"c":"quanzhou", "z":"泉州"},{"c":"rizhao", "z":"日照"},{"c":"sanya", "z":"三亚"},{"c":"shanghai", "z":"上海"},{"c":"shantou", "z":"汕头"},{"c":"shenzhen", "z":"深圳"},{"c":"shishi", "z":"石狮"},{"c":"taiwan", "z":"台湾"},{"c":"taizhou", "z":"台州"},{"c":"tangshan", "z":"唐山"},{"c":"tianjin", "z":"天津"},{"c":"weihai", "z":"威海"},{"c":"wenzhou", "z":"温州"},{"c":"wuhan", "z":"武汉"},{"c":"xiamen", "z":"厦门"},{"c":"yantai", "z":"烟台"},{"c":"yingkou", "z":"营口"},{"c":"zhangzhou", "z":"漳州"},{"c":"zhanjiang", "z":"湛江"},{"c":"zhenjiang", "z":"镇江"},{"c":"zhoushan", "z":"舟山"},{"c":"zhuhai", "z":"珠海"},{}]';

var ep = '[{"c":"hongkong", "z":"香港", "g":"China", "h":"中国"},{"c":"PIPAVAV", "z":"皮帕瓦沃", "g":"India", "h":"印度"},{"c":"BUSHEHR", "z":"达布舍尔", "g":"Iran", "h":"伊朗"},{"c":"CHAHBAHAR", "z":"查赫巴尔", "g":"Iran", "h":"伊朗"},{"c":"ANZALI", "z":"安扎里", "g":"Iran", "h":"伊朗"},{"c":"JULFA", "z":"朱利法", "g":"Iran", "h":"伊朗"},{"c":"BAM", "z":"班伯顿", "g":"Iran", "h":"伊朗"},{"c":"KHOR FAKKAN", "z":"豪尔法坎", "g":"Arab Emirates", "h":"阿联酋"},{"c":"BENGHAZI", "z":"班加西", "g":"Libyan Arab Jamahiriya", "h":"利比亚"},{"c":"AL KHOMS", "z":"欧胡姆斯", "g":"Libyan Arab Jamahiriya", "h":"利比亚"},{"c":"AABENRAA", "z":"奥本罗", "g":"Germany", "h":"德国"},{"c":"AACH", "z":"阿赫", "g":"Germany", "h":"德国"},{"c":"AACHEN", "z":"亚琛", "g":"Denmark", "h":"丹麦"},{"c":"AALBORG", "z":"奥尔堡", "g":"Denmark", "h":"丹麦"},{"c":"AALESUND", "z":"奥勒松", "g":"Norway", "h":"挪威"},{"c":"AARHUS", "z":"奥尔胡斯", "g":"Denmark", "h":"丹麦"},{"c":"ABERDEEN", "z":"阿伯丁郡", "g":"United Kingdom", "h":"英国"},{"c":"ABERDEEN", "z":"阿伯丁", "g":"United States", "h":"美国"},{"c":"ABIDJAN", "z":"阿比让", "g":"Ivory Coast", "h":"科特迪瓦"},{"c":"ABU AL BUKHOOSH", "z":"阿布埃尔霍希", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"ABU DHABI", "z":"阿布扎比", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"ABURATSU", "z":"油津", "g":"Japan", "h":"日本"},{"c":"ACAJUTLA", "z":"阿卡胡特拉", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"ACAPULCO", "z":"阿卡普尔科", "g":"Mexico", "h":"墨西哥"},{"c":"ACCRA", "z":"阿克拉", "g":"Ghana", "h":"加纳"},{"c":"ADABIYA", "z":"阿代比耶", "g":"Egypt", "h":"埃及"},{"c":"ADABIYA", "z":"阿代比耶", "g":"Egypt", "h":"埃及"},{"c":"ADABIYA", "z":"苏伊士/阿达比亚", "g":"Egypt", "h":"埃及"},{"c":"ADELAIDE", "z":"阿德莱德", "g":"Australia", "h":"澳大利亚"},{"c":"ADEN", "z":"亚丁", "g":"Yemen", "h":"也门"},{"c":"AGADIR", "z":"阿加迪尔", "g":"Morocco", "h":"摩洛哥"},{"c":"AGRA", "z":"阿格拉", "g":"India", "h":"印度"},{"c":"AGRIGENTO", "z":"阿格里真托", "g":"Italy", "h":"意大利"},{"c":"AGUASCALIENTES", "z":"阿瓜斯卡连特斯", "g":"Mexico", "h":"墨西哥"},{"c":"AHMEDABAD", "z":"阿哈迈达巴德", "g":"India", "h":"印度"},{"c":"AHUS", "z":"奥胡斯", "g":"Sweden", "h":"瑞典"},{"c":"AHWAZ", "z":"阿瓦士", "g":"Iran", "h":"伊朗"},{"c":"AIN SUKHNA", "z":"艾因苏赫纳", "g":"Egypt", "h":"埃及"},{"c":"AITUTAKI", "z":"艾图塔基", "g":"Cook Islands", "h":"库克群岛"},{"c":"AJMAN", "z":"阿治曼", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"AKITA", "z":"秋田", "g":"Japan", "h":"日本"},{"c":"AKRON", "z":"阿克伦", "g":"United States", "h":"美国"},{"c":"AL AIN", "z":"艾恩", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"ALAJUELA", "z":"阿拉胡埃拉", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"ALBACETE", "z":"阿尔巴塞特", "g":"Spain", "h":"西班牙"},{"c":"ALBUQUERQUE", "z":"阿尔伯克基", "g":"United States", "h":"美国"},{"c":"ALDERSHOT", "z":"奥尔德肖特", "g":"United Kingdom", "h":"英国"},{"c":"ALESSANDRIA", "z":"亚历山德里亚", "g":"Italy", "h":"意大利"},{"c":"ALEXANDRA", "z":"亚历山德拉", "g":"New Zealand", "h":"新西兰"},{"c":"ALEXANDRIA", "z":"亚历山德里亚", "g":"Egypt", "h":"埃及"},{"c":"ALEXANDRIA", "z":"亚历山德里亚", "g":"United States", "h":"美国"},{"c":"ALGECIRAS", "z":"阿尔赫西拉斯", "g":"Spain", "h":"西班牙"},{"c":"ALGIERS", "z":"阿尔及尔", "g":"Albania", "h":"阿尔及利亚"},{"c":"ALICANTE", "z":"阿利坎特", "g":"Spain", "h":"西班牙"},{"c":"ALMERIA", "z":"阿尔梅里亚", "g":"Spain", "h":"西班牙"},{"c":"ALOTAU", "z":"阿洛陶", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"ALTAMIRA", "z":"阿尔塔米拉", "g":"Mexico", "h":"墨西哥"},{"c":"AMATITLAN", "z":"阿马蒂特兰", "g":"Guatemala", "h":"危地马拉"},{"c":"AMATITLAN", "z":"阿马蒂特兰", "g":"Mexico", "h":"墨西哥"},{"c":"AMBARLI", "z":"阿姆巴利", "g":"Turkey", "h":"土耳其"},{"c":"AMBARLI", "z":"阿姆巴利", "g":"Syria", "h":"叙利亚"},{"c":"AMIENS", "z":"亚眠", "g":"France", "h":"法国"},{"c":"AMMAN", "z":"安曼", "g":"Jordan", "h":"约旦"},{"c":"AMMAN", "z":"安曼", "g":"Jordan", "h":"约旦"},{"c":"AMSTERDAM", "z":"阿姆斯特丹", "g":"Netherlands", "h":"荷兰"},{"c":"ANAPOLIS", "z":"阿纳波利斯", "g":"Brazil", "h":"巴西"},{"c":"ANCONA", "z":"安科纳", "g":"Italy", "h":"意大利"},{"c":"ANGERS", "z":"昂热", "g":"France", "h":"法国"},{"c":"ANGOLA", "z":"安哥拉", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"ANGUILLA", "z":"安圭拉", "g":"Anguilla", "h":"安圭拉"},{"c":"ANKARA", "z":"安卡拉", "g":"Turkey", "h":"土耳其"},{"c":"ANNABA", "z":"安纳巴", "g":"Albania", "h":"阿尔及利亚"},{"c":"ANNECY", "z":"阿讷西", "g":"France", "h":"法国"},{"c":"ANSBACH", "z":"安斯巴赫", "g":"Germany", "h":"德国"},{"c":"ANTALYA", "z":"安塔利亚", "g":"Turkey", "h":"土耳其"},{"c":"ANTANANARIVO", "z":"安塔那那利佛", "g":"Madagascar", "h":"马达加斯加"},{"c":"ANTIGUA", "z":"安提瓜", "g":"Antigua and Barbuda", "h":"安提瓜和巴布达"},{"c":"ANTOFAGASTA", "z":"安托法加斯塔", "g":"Chile", "h":"智利"},{"c":"ANTSIRANANA", "z":"安齐拉纳纳", "g":"Madagascar", "h":"马达加斯加"},{"c":"ANTWERP", "z":"安特卫普", "g":"Belgium", "h":"比利时"},{"c":"AOSTA", "z":"奥斯塔", "g":"Italy", "h":"意大利"},{"c":"APAPA", "z":"阿帕帕", "g":"Nigeria", "h":"尼日利亚"},{"c":"APIA", "z":"阿皮亚", "g":"Samoa", "h":"萨摩亚群岛"},{"c":"APODACA", "z":"阿波达卡", "g":"Mexico", "h":"墨西哥"},{"c":"AQABA", "z":"亚喀巴", "g":"Jordan", "h":"约旦"},{"c":"AQABA FREE ZONE", "z":"亚客巴（贸易区）", "g":"Jordan", "h":"约旦"},{"c":"ARAK", "z":"阿拉克", "g":"Iran", "h":"伊朗"},{"c":"AREZZO", "z":"阿雷佐", "g":"Italy", "h":"意大利"},{"c":"ARICA", "z":"阿里卡", "g":"Chile", "h":"智利"},{"c":"ARKHANGELSK", "z":"阿尔汉格尔斯克", "g":"Russia", "h":"俄罗斯"},{"c":"ARUBA", "z":"阿鲁巴", "g":"Netherlands", "h":"荷兰"},{"c":"ASBACH", "z":"阿斯巴赫", "g":"Germany", "h":"德国"},{"c":"ASCOLI PICENO", "z":"阿斯科利皮切诺", "g":"Italy", "h":"意大利"},{"c":"ASHDOD", "z":"阿什杜德", "g":"Israel", "h":"以色列"},{"c":"ASHDOD", "z":"阿什杜德", "g":"Israel", "h":"以色列"},{"c":"ASTAKOS", "z":"阿斯塔科斯", "g":"Greece", "h":"希腊"},{"c":"ASTI", "z":"阿斯蒂", "g":"Italy", "h":"意大利"},{"c":"ASUNCION", "z":"亚松森", "g":"Paraguay", "h":"巴拉圭"},{"c":"ATHENS", "z":"雅典", "g":"Greece", "h":"希腊"},{"c":"ATHENS", "z":"阿森斯", "g":"United States", "h":"美国"},{"c":"ATLANTA", "z":"亚特兰大", "g":"United States", "h":"美国"},{"c":"AUCKLAND", "z":"奥克兰", "g":"New Zealand", "h":"新西兰"},{"c":"AUGSBURG", "z":"奥格斯堡", "g":"Germany", "h":"德国"},{"c":"AURANGABAD", "z":"奥兰加巴德", "g":"India", "h":"印度"},{"c":"AUSTIN", "z":"奥斯汀", "g":"United States", "h":"美国"},{"c":"AVELLINO", "z":"阿韦利诺", "g":"Italy", "h":"意大利"},{"c":"AVILA", "z":"阿维拉", "g":"Spain", "h":"西班牙"},{"c":"BADAJOZ", "z":"巴达霍斯", "g":"Spain", "h":"西班牙"},{"c":"BAHRAIN", "z":"巴林", "g":"Bahrain", "h":"巴林"},{"c":"BALBOA", "z":"巴尔博亚", "g":"Panama", "h":"巴拿马"},{"c":"BALIKPAPAN", "z":"巴里巴板", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BALTIMORE", "z":"巴尔的摩", "g":"United States", "h":"美国"},{"c":"BALTIMORE", "z":"巴尔的摩", "g":"Ireland", "h":"爱尔兰"},{"c":"BANDAR ABBAS", "z":"阿巴斯港", "g":"Iran", "h":"伊朗"},{"c":"BANDUNG", "z":"万隆", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BANGALORE", "z":"班加罗尔", "g":"India", "h":"印度"},{"c":"BANGKOK", "z":"曼谷", "g":"Thailand", "h":"泰国"},{"c":"BANJARMASIN", "z":"马辰", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BANJUL", "z":"班珠尔", "g":"Gambia", "h":"冈比亚"},{"c":"BARBERTON", "z":"巴伯顿", "g":"United States", "h":"美国"},{"c":"BARCELONA", "z":"巴塞罗那", "g":"Spain", "h":"西班牙"},{"c":"BARCELONA", "z":"巴塞罗那", "g":"Venezuela", "h":"委内瑞拉"},{"c":"BARI", "z":"巴里", "g":"Italy", "h":"意大利"},{"c":"BARODA", "z":"巴罗达", "g":"India", "h":"印度"},{"c":"BARRANQUILLA", "z":"巴兰基利亚", "g":"Colombia", "h":"哥伦比亚"},{"c":"BASEL", "z":"巴塞尔", "g":"Stzerland", "h":"瑞士"},{"c":"BASRA", "z":"巴士拉", "g":"Iraq", "h":"伊拉克"},{"c":"BASSE TERRE", "z":"巴斯特尔", "g":"Guadeloupe", "h":"瓜德罗普岛"},{"c":"BATA", "z":"巴塔", "g":"Equatorial Guniea", "h":"赤道几内亚"},{"c":"BATAM", "z":"巴淡", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BATAM ISLAND", "z":"巴淡岛", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BATANGAS", "z":"八打雁", "g":"Philippines", "h":"菲律宾"},{"c":"BATAVIA", "z":"巴特维亚", "g":"United States", "h":"美国"},{"c":"BATUMI", "z":"巴统", "g":"Georga", "h":"格鲁吉亚"},{"c":"BEIRA", "z":"贝拉", "g":"Mozambique", "h":"莫桑比克"},{"c":"BEIRUT", "z":"贝鲁特", "g":"Lebanon", "h":"黎巴嫩"},{"c":"BEJAIA", "z":"贝贾亚", "g":"Albania", "h":"阿尔及利亚"},{"c":"BELEM", "z":"贝伦", "g":"Brazil", "h":"巴西"},{"c":"BELEM", "z":"贝伦", "g":"Portugal", "h":"葡萄牙"},{"c":"BELFAST", "z":"贝尔法斯特", "g":"United Kingdom", "h":"英国"},{"c":"BELGRADE", "z":"贝尔格莱德", "g":"Yugoslava", "h":"塞尔维亚"},{"c":"BELIZE CITY", "z":"伯利兹城", "g":"Belize", "h":"伯利兹"},{"c":"BELL BAY", "z":"贝尔贝", "g":"Australia", "h":"澳大利亚"},{"c":"BELLUNO", "z":"贝卢诺", "g":"Italy", "h":"意大利"},{"c":"BENEVENTO", "z":"贝内文托", "g":"Italy", "h":"意大利"},{"c":"BENOA", "z":"伯诺阿", "g":"Indonesia", "h":"印度尼西亚"},{"c":"BERBERA", "z":"伯贝拉", "g":"Somalia", "h":"索马里"},{"c":"BERGAMO", "z":"贝加莫", "g":"Italy", "h":"意大利"},{"c":"BERGEN", "z":"卑尔根", "g":"Norway", "h":"挪威"},{"c":"BERLIN", "z":"柏林", "g":"United States", "h":"美国"},{"c":"BERLIN", "z":"柏林", "g":"Germany", "h":"德国"},{"c":"BESANCON", "z":"贝桑松", "g":"France", "h":"法国"},{"c":"BIELEFELD", "z":"比勒费尔德", "g":"Germany", "h":"德国"},{"c":"BIELLA", "z":"比耶拉", "g":"Italy", "h":"意大利"},{"c":"BILBAO", "z":"毕尔巴鄂", "g":"Spain", "h":"西班牙"},{"c":"BILLUND", "z":"比隆", "g":"Denmark", "h":"丹麦"},{"c":"BINTULU", "z":"民都鲁", "g":"Malaysia", "h":"马来西亚"},{"c":"BIRMINGHAM", "z":"伯明翰", "g":"United Kingdom", "h":"英国"},{"c":"BIRMINGHAM", "z":"伯明翰", "g":"United States", "h":"美国"},{"c":"BISSAU", "z":"比绍", "g":"Guinea Bissau", "h":"及内比亚绍"},{"c":"BLACKBURN", "z":"布莱克本", "g":"United Kingdom", "h":"英国"},{"c":"BLANTYRE", "z":"布兰太尔", "g":"United Kingdom", "h":"英国"},{"c":"BLANTYRE", "z":"布兰太尔", "g":"Malawi", "h":"马拉维"},{"c":"BLENHEIM", "z":"布伦海姆", "g":"New Zealand", "h":"新西兰"},{"c":"BLENHEIM", "z":"布伦海姆", "g":"Germany", "h":"德国"},{"c":"BLOEMFONTEIN", "z":"布隆方丹", "g":"South Africa", "h":"南非"},{"c":"BLUFF", "z":"布拉夫", "g":"New Zealand", "h":"新西兰"},{"c":"BOBO-DIOULASSO", "z":"博博迪乌拉索", "g":"Burna Faso", "h":"布基纳法索"},{"c":"BOCHUM", "z":"波鸿", "g":"Germany", "h":"德国"},{"c":"BODO", "z":"博多", "g":"Norway", "h":"挪威"},{"c":"BOGOTA", "z":"波哥大", "g":"Colombia", "h":"哥伦比亚"},{"c":"BOLOGNA", "z":"博洛尼亚", "g":"Italy", "h":"意大利"},{"c":"BOLTON", "z":"博尔顿", "g":"United Kingdom", "h":"英国"},{"c":"BOLZANO", "z":"博尔扎诺", "g":"Italy", "h":"意大利"},{"c":"BOMA", "z":"博马", "g":"Congo", "h":"刚果共和国"},{"c":"BONN", "z":"波恩", "g":"Germany", "h":"德国"},{"c":"BORDEAUX", "z":"波尔多", "g":"France", "h":"法国"},{"c":"BORGHOLM", "z":"博里霍尔姆", "g":"Sweden", "h":"瑞典"},{"c":"BOSTON", "z":"波士顿", "g":"United States", "h":"美国"},{"c":"BOSTON", "z":"波士顿", "g":"United Kingdom", "h":"英国"},{"c":"BOTTROP", "z":"博特罗普", "g":"Germany", "h":"德国"},{"c":"BOULDER", "z":"博尔德", "g":"United States", "h":"美国"},{"c":"BRADFORD", "z":"布拉德福德", "g":"United States", "h":"美国"},{"c":"BRADFORD", "z":"布拉德福", "g":"United Kingdom", "h":"英国"},{"c":"BRAUNSCHWEIG", "z":"不伦瑞克", "g":"Germany", "h":"德国"},{"c":"BREGENZ", "z":"布雷根茨", "g":"Austria", "h":"奥地利"},{"c":"BREMEN", "z":"不莱梅", "g":"Germany", "h":"德国"},{"c":"BREMEN", "z":"不莱梅", "g":"United States", "h":"美国"},{"c":"BREMERHAVEN", "z":"不来梅哈芬", "g":"Germany", "h":"德国"},{"c":"BRESCIA", "z":"布雷西亚", "g":"Italy", "h":"意大利"},{"c":"BREST", "z":"布雷斯特", "g":"France", "h":"法国"},{"c":"BREVIK", "z":"布雷维克", "g":"Norway", "h":"挪威"},{"c":"BRIDGETOWN", "z":"布里奇顿", "g":"Barbados", "h":"巴巴多斯"},{"c":"BRINDISI", "z":"布林迪西", "g":"Italy", "h":"意大利"},{"c":"BRISBANE", "z":"布里斯班", "g":"Australia", "h":"澳大利亚"},{"c":"BRISTOL", "z":"布里斯托尔", "g":"United Kingdom", "h":"英国"},{"c":"BRISTOL", "z":"布里斯托尔", "g":"United States", "h":"美国"},{"c":"BRNO", "z":"布尔诺", "g":"Czech", "h":"捷克"},{"c":"BROWNSVILLE", "z":"布朗斯维尔", "g":"United States", "h":"美国"},{"c":"BRUSSELS", "z":"布鲁塞尔", "g":"Belgium", "h":"比利时"},{"c":"BUCHAREST", "z":"布加勒斯特", "g":"Romania", "h":"罗马尼亚"},{"c":"BUDAPEST", "z":"布达佩斯", "g":"Burma", "h":"缅甸"},{"c":"BUDAPEST", "z":"布达佩斯", "g":"Hungary", "h":"匈牙利"},{"c":"BUENAVENTURA", "z":"布埃纳文图拉", "g":"Colombia", "h":"哥伦比亚"},{"c":"BUENOS AIRES", "z":"布宜诺斯艾利斯", "g":"Argentina", "h":"阿根廷"},{"c":"BUFFALO", "z":"布法罗", "g":"United States", "h":"美国"},{"c":"BUKAVU", "z":"布卡武", "g":"Congo", "h":"刚果共和国"},{"c":"BULAWAYO", "z":"布拉瓦约", "g":"Zmbabe", "h":"津巴布韦"},{"c":"BURGAS", "z":"布尔加斯", "g":"Bulgaria", "h":"保加利亚"},{"c":"BURGOS", "z":"布尔戈斯", "g":"Spain", "h":"西班牙"},{"c":"BURLINGAME", "z":"伯灵格姆", "g":"United States", "h":"美国"},{"c":"BURNIE", "z":"伯尼", "g":"Australia", "h":"澳大利亚"},{"c":"BURSA", "z":"布尔萨", "g":"Turkey", "h":"土耳其"},{"c":"BUSAN", "z":"釜山", "g":"South Korea", "h":"韩国"},{"c":"CABINDA", "z":"卡宾达", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"CACERES", "z":"卡塞雷斯", "g":"Spain", "h":"西班牙"},{"c":"CADIZ", "z":"加的斯", "g":"Spain", "h":"西班牙"},{"c":"CADIZ", "z":"加的斯", "g":"Philippines", "h":"菲律宾"},{"c":"CAGAYAN DE ORO", "z":"卡加延德奥罗", "g":"Philippines", "h":"菲律宾"},{"c":"CAGLIARI", "z":"卡利亚里", "g":"Italy", "h":"意大利"},{"c":"CAIRO", "z":"开罗", "g":"United States", "h":"美国"},{"c":"CAIRO", "z":"开罗", "g":"Egypt", "h":"埃及"},{"c":"CAIRO", "z":"开罗", "g":"Egypt", "h":"埃及"},{"c":"CALABAR", "z":"卡拉巴尔", "g":"Nigeria", "h":"尼日利亚"},{"c":"CALAIS", "z":"加来", "g":"France", "h":"法国"},{"c":"CALCUTTA", "z":"加尔格答", "g":"India", "h":"印度"},{"c":"CALGARY", "z":"卡尔加里", "g":"Canada", "h":"加拿大"},{"c":"CALI", "z":"卡利", "g":"Colombia", "h":"哥伦比亚"},{"c":"CALLAO", "z":"卡亚俄", "g":"Peru", "h":"秘鲁"},{"c":"CALTANISSETTA", "z":"卡尔塔尼塞塔", "g":"Italy", "h":"意大利"},{"c":"CAMPOBASSO", "z":"坎波巴索", "g":"Italy", "h":"意大利"},{"c":"CANCUN", "z":"坎昆", "g":"Mexico", "h":"墨西哥"},{"c":"CANOAS", "z":"卡诺阿斯", "g":"Brazil", "h":"巴西"},{"c":"CAPE TOWN", "z":"开普顿", "g":"South Africa", "h":"南非"},{"c":"CARACAS", "z":"加拉加斯", "g":"Venezuela", "h":"委内瑞拉"},{"c":"CARDENAS", "z":"卡德纳斯", "g":"Cuba", "h":"古巴"},{"c":"CARDIFF", "z":"加的夫", "g":"United Kingdom", "h":"英国"},{"c":"CARLISLE", "z":"卡莱尔", "g":"United Kingdom", "h":"英国"},{"c":"CARTAGENA", "z":"卡塔赫纳", "g":"Colombia", "h":"哥伦比亚"},{"c":"CARTAGENA", "z":"卡塔赫纳", "g":"Spain", "h":"西班牙"},{"c":"CARTAGO", "z":"卡塔戈", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"CASABLANCA", "z":"卡萨布兰卡", "g":"Morocco", "h":"摩洛哥"},{"c":"CASERTA", "z":"卡塞塔", "g":"Italy", "h":"意大利"},{"c":"CASTELLO", "z":"卡斯泰洛", "g":"Italy", "h":"意大利"},{"c":"CASTRIES", "z":"卡斯特里港", "g":"Sant Lucia", "h":"圣卢西亚"},{"c":"CATAMARCA", "z":"卡塔马卡", "g":"Argentina", "h":"阿根廷"},{"c":"CATANIA", "z":"卡塔尼亚", "g":"Italy", "h":"意大利"},{"c":"CATANZARO", "z":"卡坦扎罗", "g":"Italy", "h":"意大利"},{"c":"CAXIAS DO SUL", "z":"赛克西亚多索", "g":"Brazil", "h":"巴西"},{"c":"CEBU", "z":"宿务", "g":"Philippines", "h":"菲律宾"},{"c":"CESENA", "z":"切塞纳", "g":"Italy", "h":"意大利"},{"c":"CEUTA", "z":"休达", "g":"Spain", "h":"西班牙"},{"c":"CHARLESTON", "z":"查尔斯顿", "g":"United States", "h":"美国"},{"c":"CHARLESTON", "z":"查尔斯顿", "g":"United Kingdom", "h":"英国"},{"c":"CHARLESTOWN", "z":"查尔斯敦", "g":"United Kingdom", "h":"英国"},{"c":"CHARLESTOWN", "z":"查尔斯敦", "g":"United States", "h":"美国"},{"c":"CHARLOTTE", "z":"夏洛特", "g":"United States", "h":"美国"},{"c":"CHATTANOOGA", "z":"查塔努加", "g":"United States", "h":"美国"},{"c":"CHEMNITZ", "z":"开姆尼斯", "g":"Germany", "h":"德国"},{"c":"CHENNAI", "z":"清奈", "g":"India", "h":"印度"},{"c":"CHIBA", "z":"千叶", "g":"Japan", "h":"日本"},{"c":"CHICAGO", "z":"芝加哥", "g":"United States", "h":"美国"},{"c":"CHIETI", "z":"基耶蒂", "g":"Italy", "h":"意大利"},{"c":"CHIHUAHUA", "z":"奇瓦瓦", "g":"Mexico", "h":"墨西哥"},{"c":"CHIMBOTE", "z":"钦博特", "g":"Peru", "h":"秘鲁"},{"c":"CHINO", "z":"奇诺", "g":"United States", "h":"美国"},{"c":"CHITTAGONG", "z":"吉大港", "g":"Bangladesh", "h":"孟加拉国"},{"c":"CHIWAN", "z":"赤湾", "g":"China", "h":"中国"},{"c":"CHOLOMA", "z":"乔罗马", "g":"Honduras", "h":"洪都拉斯"},{"c":"CHRISTCHURCH", "z":"克赖斯特彻奇", "g":"New Zealand", "h":"新西兰"},{"c":"CINCINNATI", "z":"辛辛那提", "g":"United States", "h":"美国"},{"c":"CITY OF INDUSTRY", "z":"工业市", "g":"United States", "h":"美国"},{"c":"CIUDAD OBREGON", "z":"克夫雷贡城", "g":"Mexico", "h":"墨西哥"},{"c":"CIUDAD REAL", "z":"雷阿尔城", "g":"Spain", "h":"西班牙"},{"c":"CIVITAVECCHIA", "z":"奇维塔韦基亚", "g":"Italy", "h":"意大利"},{"c":"CLERMONT FERRAND", "z":"克莱蒙费朗", "g":"France", "h":"法国"},{"c":"CLEVELAND", "z":"克利夫兰", "g":"United States", "h":"美国"},{"c":"COATZACOALCOS", "z":"夸察夸尔科斯", "g":"Mexico", "h":"墨西哥"},{"c":"COCHABAMBA", "z":"科恰班巴", "g":"Bolivia", "h":"玻利维亚"},{"c":"COCHIN", "z":"科钦", "g":"India", "h":"印度"},{"c":"COCO SOLO", "z":"科科索洛", "g":"Panama", "h":"巴拿马"},{"c":"COIMBATORE", "z":"哥印拜陀", "g":"India", "h":"印度"},{"c":"COLIMA", "z":"科利马", "g":"Mexico", "h":"墨西哥"},{"c":"COLOGNE", "z":"科隆", "g":"Germany", "h":"德国"},{"c":"COLOMBO", "z":"科伦坡", "g":"Sri Lanka", "h":"斯里兰卡"},{"c":"COLON", "z":"科隆", "g":"Panama", "h":"巴拿马"},{"c":"COLON", "z":"科隆", "g":"United States", "h":"美国"},{"c":"COLON FREE ZONE", "z":"科隆自由贸易区", "g":"Panama", "h":"巴拿马"},{"c":"COLUMBIA", "z":"哥伦比亚", "g":"United States", "h":"美国"},{"c":"COLUMBUS", "z":"哥伦布", "g":"United States", "h":"美国"},{"c":"COMO", "z":"科莫", "g":"Colombia", "h":"哥伦比亚"},{"c":"COMO", "z":"科莫", "g":"Italy", "h":"意大利"},{"c":"COMPTON", "z":"康普顿", "g":"United States", "h":"美国"},{"c":"CONAKRY", "z":"科纳克里", "g":"Guinea", "h":"几内亚"},{"c":"CONCEPCION", "z":"康塞普西翁", "g":"Argentina", "h":"阿根廷"},{"c":"CONSTANTA", "z":"康斯坦察市", "g":"Romania", "h":"罗马尼亚"},{"c":"CONSTANZIA", "z":"康斯坦察", "g":"United States", "h":"美国"},{"c":"COPENHAGEN", "z":"哥本哈根", "g":"Denmark", "h":"丹麦"},{"c":"COQUIMBO", "z":"科金博", "g":"Chile", "h":"智利"},{"c":"CORDOBA", "z":"科尔多瓦", "g":"Spain", "h":"西班牙"},{"c":"CORINTO", "z":"科林托", "g":"Nicaragua", "h":"尼加拉瓜"},{"c":"CORK", "z":"科克", "g":"Ireland", "h":"爱尔兰"},{"c":"CORK", "z":"科克", "g":"Ireland", "h":"爱尔兰"},{"c":"CORONA", "z":"科罗纳", "g":"Australia", "h":"澳大利亚"},{"c":"CORONA", "z":"科罗纳", "g":"United States", "h":"美国"},{"c":"CORONEL", "z":"科罗内尔", "g":"Chile", "h":"智利"},{"c":"COSENZA", "z":"科森扎", "g":"Italy", "h":"意大利"},{"c":"COTONOU", "z":"科托努", "g":"Benn", "h":"贝宁"},{"c":"COTTBUS", "z":"科特布斯", "g":"Germany", "h":"德国"},{"c":"COVENTRY", "z":"考文垂", "g":"United States", "h":"美国"},{"c":"COVENTRY", "z":"考文垂", "g":"United Kingdom", "h":"英国"},{"c":"COVINA", "z":"柯汶纳", "g":"United States", "h":"美国"},{"c":"CREMONA", "z":"克雷莫纳", "g":"Italy", "h":"意大利"},{"c":"CRISTOBAL", "z":"克里斯托瓦尔", "g":"Panama", "h":"巴拿马"},{"c":"CRUZ BAY", "z":"克鲁兹湾", "g":"The United States Virgin Islands", "h":"美属维尔京群岛"},{"c":"CUAUTITLAN", "z":"高替特兰", "g":"Mexico", "h":"墨西哥"},{"c":"CUENCA", "z":"昆卡", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"CUERNAVACA", "z":"库埃纳瓦卡", "g":"Mexico", "h":"墨西哥"},{"c":"CULIACAN", "z":"库利亚坎", "g":"Mexico", "h":"墨西哥"},{"c":"CULLMAN", "z":"卡尔曼", "g":"United States", "h":"美国"},{"c":"CUNEO", "z":"库内奥", "g":"Italy", "h":"意大利"},{"c":"CURACAO", "z":"库拉索", "g":"Netherlands", "h":"荷兰"},{"c":"CURACAO", "z":"库拉索岛", "g":"Venezuela", "h":"委内瑞拉"},{"c":"CURITIBA", "z":"库里蒂巴", "g":"Brazil", "h":"巴西"},{"c":"CUXHAVEN", "z":"库克斯港", "g":"Germany", "h":"德国"},{"c":"DA NANG", "z":"岘港", "g":"Vietnam", "h":"越南"},{"c":"DAKAR", "z":"达喀尔", "g":"Senegal", "h":"塞内加尔"},{"c":"DALLAS", "z":"达拉斯", "g":"United States", "h":"美国"},{"c":"DAMAN", "z":"达曼", "g":"India", "h":"印度"},{"c":"DAMIETTA", "z":"达米埃塔", "g":"Egypt", "h":"埃及"},{"c":"DAMIETTA", "z":"达米埃塔", "g":"Egypt", "h":"埃及"},{"c":"DAMMAM", "z":"达曼", "g":"Saudi Arabia", "h":"沙特阿拉伯"},{"c":"DAMMAM", "z":"达曼", "g":"Saudi Arabia", "h":"沙特阿拉伯"},{"c":"DAR ES SALAAM", "z":"达累斯萨拉姆", "g":"Tanzania", "h":"坦桑尼亚"},{"c":"DARMSTADT", "z":"达姆施塔特", "g":"Germany", "h":"德国"},{"c":"DARWIN", "z":"达尔文", "g":"Australia", "h":"澳大利亚"},{"c":"DAVAO", "z":"达沃", "g":"Philippines", "h":"菲律宾"},{"c":"DAYTON", "z":"代顿", "g":"United States", "h":"美国"},{"c":"DELHI", "z":"德里", "g":"India", "h":"印度"},{"c":"DENVER", "z":"丹佛", "g":"United States", "h":"美国"},{"c":"DERBY", "z":"德比", "g":"United States", "h":"美国"},{"c":"DERBY", "z":"德比", "g":"Australia", "h":"澳大利亚"},{"c":"DES MOINES", "z":"得梅因", "g":"United States", "h":"美国"},{"c":"DESSAU", "z":"德绍", "g":"Germany", "h":"德国"},{"c":"DETROIT", "z":"底特律", "g":"United States", "h":"美国"},{"c":"DHAKA", "z":"达卡", "g":"Bangladesh", "h":"孟加拉国"},{"c":"DIJON", "z":"第戎", "g":"France", "h":"法国"},{"c":"DILI", "z":"帝力", "g":"East Tmor", "h":"东帝汶"},{"c":"DILISKELESI", "z":"帝力克里斯", "g":"Turkey", "h":"土耳其"},{"c":"DJIBOUTI", "z":"吉布提", "g":"Djibouti", "h":"吉布提"},{"c":"DOHA", "z":"多哈", "g":"Qatar", "h":"卡塔尔"},{"c":"DOMINICA", "z":"多米尼克", "g":"Dominica", "h":"多米尼克国"},{"c":"DONETSK", "z":"顿涅茨克", "g":"Ukraine", "h":"乌克兰"},{"c":"DORTMUND", "z":"多特蒙德", "g":"Germany", "h":"德国"},{"c":"DOUAI", "z":"杜埃", "g":"France", "h":"法国"},{"c":"DOUALA", "z":"杜阿拉", "g":"Cameroon", "h":"喀麦隆"},{"c":"DOVER", "z":"多佛尔", "g":"United Kingdom", "h":"英国"},{"c":"DOVER", "z":"多佛尔", "g":"United States", "h":"美国"},{"c":"DRAMMEN", "z":"德拉门", "g":"Norway", "h":"挪威"},{"c":"DRESDEN", "z":"德累斯顿", "g":"Germany", "h":"德国"},{"c":"DUBAI", "z":"迪拜", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"DUBI", "z":"迪比", "g":"Cameroon", "h":"喀麦隆"},{"c":"DUBLIN", "z":"都柏林", "g":"Ireland", "h":"爱尔兰"},{"c":"DUBLIN", "z":"都柏林", "g":"United States", "h":"美国"},{"c":"DUBROVNIK", "z":"杜布罗夫尼克", "g":"Croatia", "h":"克罗地亚"},{"c":"DUBROVNIK", "z":"杜布罗夫尼克", "g":"Croatia", "h":"克罗地亚"},{"c":"DUESSELDORF", "z":"杜塞尔多夫", "g":"Germany", "h":"德国"},{"c":"DUISBURG", "z":"杜伊斯堡", "g":"Germany", "h":"德国"},{"c":"DUNDEE", "z":"邓迪", "g":"United Kingdom", "h":"英国"},{"c":"DUNDEE", "z":"邓迪", "g":"United States", "h":"美国"},{"c":"DUNEDIN", "z":"达尼丁", "g":"New Zealand", "h":"新西兰"},{"c":"DUNKERQUE", "z":"敦刻尔克", "g":"France", "h":"法国"},{"c":"DUNKIRK", "z":"敦刻尔克", "g":"France", "h":"法国"},{"c":"DUNKIRK", "z":"敦刻尔克", "g":"United States", "h":"美国"},{"c":"DURBAN", "z":"德班", "g":"South Africa", "h":"南非"},{"c":"DURRES", "z":"都拉斯", "g":"Albania", "h":"阿尔巴尼亚"},{"c":"EAGLE GROVE", "z":"鹰谷镇", "g":"United States", "h":"美国"},{"c":"EAST CAMDEN", "z":"东卡姆登", "g":"United States", "h":"美国"},{"c":"EAST LONDON", "z":"东伦敦", "g":"South Africa", "h":"南非"},{"c":"ECATEPEC", "z":"埃卡提佩", "g":"Mexico", "h":"墨西哥"},{"c":"EDINBURG", "z":"爱丁堡", "g":"United States", "h":"美国"},{"c":"EDINBURGH", "z":"爱丁堡", "g":"United Kingdom", "h":"英国"},{"c":"EDMONTON", "z":"埃德蒙顿", "g":"Canada", "h":"加拿大"},{"c":"EL DEKHEILA", "z":"埃尔迪基勒", "g":"Egypt", "h":"埃及"},{"c":"EL GUAMACHE", "z":"埃尔瓜马切", "g":"Venezuela", "h":"委内瑞拉"},{"c":"EL MONTE", "z":"埃尔蒙特", "g":"United States", "h":"美国"},{"c":"EL PASO", "z":"埃尔帕索", "g":"United States", "h":"美国"},{"c":"ELIZABETH", "z":"伊丽莎白", "g":"United States", "h":"美国"},{"c":"ELIZABETH", "z":"伊丽莎白港", "g":"South Africa", "h":"南非"},{"c":"ELKHART", "z":"埃尔克哈特", "g":"United States", "h":"美国"},{"c":"EMBAKASI", "z":"恩巴卡西", "g":"Kenya", "h":"肯尼亚"},{"c":"ENEZ", "z":"埃内兹", "g":"Turkey", "h":"土耳其"},{"c":"ENNA", "z":"恩纳", "g":"Italy", "h":"意大利"},{"c":"ENSENADA", "z":"恩塞纳达", "g":"Mexico", "h":"墨西哥"},{"c":"ENSENADA", "z":"恩塞纳达", "g":"Argentina", "h":"阿根廷"},{"c":"ESBJERG", "z":"埃斯比约", "g":"Denmark", "h":"丹麦"},{"c":"ESCUINTLA", "z":"埃斯昆特拉", "g":"Guatemala", "h":"危地马拉"},{"c":"ESFAHAN", "z":"伊斯法罕", "g":"Iran", "h":"伊朗"},{"c":"ESMERALDAS", "z":"埃斯梅拉达斯", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"ESSEN", "z":"埃森", "g":"Germany", "h":"德国"},{"c":"EVANSVILLE", "z":"埃文斯维尔", "g":"United States", "h":"美国"},{"c":"FARIDABAD", "z":"费尔达巴德", "g":"India", "h":"印度"},{"c":"FELIXSTOWE", "z":"费力克斯托", "g":"United Kingdom", "h":"英国"},{"c":"FERRARA", "z":"费拉拉", "g":"Italy", "h":"意大利"},{"c":"FLENSBURG", "z":"弗伦斯堡", "g":"Germany", "h":"德国"},{"c":"FLORENCE", "z":"弗洛伦斯", "g":"United States", "h":"美国"},{"c":"FLORENCE", "z":"佛罗伦萨", "g":"Italy", "h":"意大利"},{"c":"FOGGIA", "z":"福贾", "g":"Italy", "h":"意大利"},{"c":"FORLI", "z":"弗利", "g":"Italy", "h":"意大利"},{"c":"FORT DE FRANCE", "z":"法兰西堡", "g":"Martinique", "h":"马提尼克岛"},{"c":"FORT WORTH", "z":"沃思堡", "g":"United States", "h":"美国"},{"c":"FORTALEZA", "z":"福塔莱萨", "g":"Brazil", "h":"巴西"},{"c":"FOS SUR MER", "z":"福斯", "g":"France", "h":"法国"},{"c":"FOWLER", "z":"福勒", "g":"United States", "h":"美国"},{"c":"FOYNES", "z":"福因斯", "g":"Ireland", "h":"爱尔兰"},{"c":"FRANCISTOWN", "z":"弗朗西斯敦", "g":"Botsana", "h":"博茨瓦纳"},{"c":"FRANKFURT", "z":"法兰克福", "g":"Germany", "h":"德国"},{"c":"FRANKFURT/MAIN", "z":"法兰克福机场", "g":"Germany", "h":"德国"},{"c":"FRANKLIN", "z":"富兰克林", "g":"United States", "h":"美国"},{"c":"FRANKLIN", "z":"富兰克林", "g":"Canada", "h":"加拿大"},{"c":"FREDERICIA", "z":"腓特烈西亚", "g":"Denmark", "h":"丹麦"},{"c":"FREDRIKSTAD", "z":"腓特烈斯塔", "g":"Norway", "h":"挪威"},{"c":"FREEPORT", "z":"弗里波特", "g":"Bahamas", "h":"巴哈马"},{"c":"FREEPORT", "z":"弗里波特", "g":"United States", "h":"美国"},{"c":"FREETOWN", "z":"弗里敦", "g":"Sierra Leone", "h":"塞拉利昂"},{"c":"FREIBURG", "z":"弗赖堡", "g":"Germany", "h":"德国"},{"c":"FREMANTLE", "z":"佛里曼特尔", "g":"Australia", "h":"澳大利亚"},{"c":"FREMONT", "z":"弗里蒙特", "g":"United States", "h":"美国"},{"c":"FROSINONE", "z":"弗罗西诺内", "g":"Italy", "h":"意大利"},{"c":"FUJAIRAH", "z":"富查伊拉", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"FUKUOKA", "z":"福冈", "g":"Japan", "h":"日本"},{"c":"FUKUYAMA", "z":"福山", "g":"Japan", "h":"日本"},{"c":"FUNAFUTI", "z":"富纳富提", "g":"Tuvalu", "h":"图瓦卢"},{"c":"FURTH", "z":"富尔特", "g":"Germany", "h":"德国"},{"c":"FUSA", "z":"富萨", "g":"Nigeria", "h":"尼日利亚"},{"c":"GABORONE", "z":"哈博罗内", "g":"Botsana", "h":"博茨瓦纳"},{"c":"GAVLE", "z":"耶夫勒", "g":"Sweden", "h":"瑞典"},{"c":"GDANSK", "z":"格但斯克", "g":"Poland", "h":"波兰"},{"c":"GDYNIA", "z":"格丁尼亚", "g":"Poland", "h":"波兰"},{"c":"GEBZE", "z":"盖布泽", "g":"Turkey", "h":"土耳其"},{"c":"GELSENKIRCHEN", "z":"盖尔森基兴", "g":"Germany", "h":"德国"},{"c":"GEMLIK", "z":"盖姆利克", "g":"Turkey", "h":"土耳其"},{"c":"GENAS", "z":"热纳", "g":"France", "h":"法国"},{"c":"GENEVA", "z":"日内瓦", "g":"Stzerland", "h":"瑞士"},{"c":"GENOVA", "z":"热那亚", "g":"Italy", "h":"意大利"},{"c":"GEORGE TOWN", "z":"乔治镇　", "g":"Australia", "h":"澳大利亚"},{"c":"GEORGETOWN", "z":"乔治敦", "g":"United States", "h":"美国"},{"c":"GEORGETOWN", "z":"乔治敦", "g":"Canada", "h":"加拿大"},{"c":"GEORGETOWN", "z":"乔治敦", "g":"Guyana", "h":"圭亚那"},{"c":"GEORGETOWN", "z":"乔治敦", "g":"Malaysia", "h":"马来西亚"},{"c":"GERA", "z":"格拉", "g":"Germany", "h":"德国"},{"c":"GIJON", "z":"希洪", "g":"Spain", "h":"西班牙"},{"c":"GIOIA TAURO", "z":"焦亚陶罗", "g":"Italy", "h":"意大利"},{"c":"GLADSTONE", "z":"格拉德斯通", "g":"Australia", "h":"澳大利亚"},{"c":"GLADSTONE", "z":"格拉德斯通", "g":"United States", "h":"美国"},{"c":"GLASGOW", "z":"格拉斯哥", "g":"United Kingdom", "h":"英国"},{"c":"GLENVIEW", "z":"格伦维尤", "g":"United States", "h":"美国"},{"c":"GOA", "z":"果阿邦", "g":"India", "h":"印度"},{"c":"GOMA", "z":"戈马", "g":"Congo", "h":"刚果（金）"},{"c":"GORE", "z":"戈尔", "g":"New Zealand", "h":"新西兰"},{"c":"GORIZIA", "z":"戈里齐亚", "g":"Italy", "h":"意大利"},{"c":"GOTHENBURG", "z":"哥德堡", "g":"Sweden", "h":"瑞典"},{"c":"GOTTINGEN", "z":"格丁根", "g":"Germany", "h":"德国"},{"c":"GRANADA", "z":"格拉纳达", "g":"Spain", "h":"西班牙"},{"c":"GRAND BAHAMA", "z":"大巴哈马", "g":"Bahamas", "h":"巴哈马"},{"c":"GRAND CAYMAN", "z":"大开曼", "g":"Cayman Islands", "h":"开曼群岛"},{"c":"GRAND RAPIDS", "z":"大急流域", "g":"United States", "h":"美国"},{"c":"GRANGEMOUTH", "z":"格兰杰默斯", "g":"United Kingdom", "h":"英国"},{"c":"GRAZ", "z":"格拉茨", "g":"Austria", "h":"奥地利"},{"c":"GREENOCK", "z":"格里诺克", "g":"United Kingdom", "h":"英国"},{"c":"GREENSBORO", "z":"格林斯伯勒", "g":"United States", "h":"美国"},{"c":"GREENVILLE", "z":"格林维尔", "g":"Liberia", "h":"利比里亚"},{"c":"GRENADA", "z":"格林纳达岛", "g":"the West Indies", "h":"西印度群岛"},{"c":"GRENADA", "z":"格林纳达", "g":"Grenada", "h":"格林纳达"},{"c":"GRENOBLE", "z":"格勒诺布尔", "g":"France", "h":"法国"},{"c":"GREYMOUTH", "z":"格雷茅斯", "g":"New Zealand", "h":"新西兰"},{"c":"GROSSETO", "z":"格罗塞托", "g":"Italy", "h":"意大利"},{"c":"GUADALAJARA", "z":"瓜达拉哈拉", "g":"Mexico", "h":"墨西哥"},{"c":"GUAIRA", "z":"瓜伊拉", "g":"Venezuela", "h":"委内瑞拉"},{"c":"GUAM", "z":"关岛", "g":"Mariana Islands", "h":"马利亚纳群岛"},{"c":"GUANAJUATO", "z":"瓜纳华托", "g":"Mexico", "h":"墨西哥"},{"c":"GUANTA", "z":"关塔", "g":"Venezuela", "h":"委内瑞拉"},{"c":"GUARANAO BAY", "z":"古阿兰奥湾", "g":"Venezuela", "h":"委内瑞拉"},{"c":"GUATEMALA CITY", "z":"危地马拉市", "g":"Guatemala", "h":"危地马拉"},{"c":"GUAYAQUIL", "z":"瓜亚基尔", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"GURGAON", "z":"古尔冈", "g":"India", "h":"印度"},{"c":"GUSTAVIA", "z":"居斯塔维亚", "g":"Guadeloupe", "h":"瓜德罗普岛"},{"c":"GWALIOR", "z":"瓜廖尔", "g":"India", "h":"印度"},{"c":"GWERU", "z":"格韦鲁", "g":"Zmbabe", "h":"津巴布韦"},{"c":"HACHINOHE", "z":"八户", "g":"Japan", "h":"日本"},{"c":"HAGEN", "z":"哈根", "g":"Germany", "h":"德国"},{"c":"HAIFA", "z":"海法", "g":"Israel", "h":"以色列"},{"c":"HAIPHONG", "z":"海防", "g":"Vietnam", "h":"越南"},{"c":"HAKATA", "z":"伯方", "g":"Japan", "h":"日本"},{"c":"HAKODATE", "z":"涵馆", "g":"Japan", "h":"日本"},{"c":"HALDEN", "z":"哈尔登", "g":"Norway", "h":"挪威"},{"c":"HALDIA", "z":"霍尔迪亚", "g":"India", "h":"印度"},{"c":"HALIFAX", "z":"哈立法克斯", "g":"United States", "h":"美国"},{"c":"HALLE", "z":"哈勒", "g":"Germany", "h":"德国"},{"c":"HALMSTAD", "z":"哈尔姆斯塔德", "g":"Sweden", "h":"瑞典"},{"c":"HAM", "z":"哈姆", "g":"France", "h":"法国"},{"c":"HAMADA", "z":"滨田", "g":"Japan", "h":"日本"},{"c":"HAMADAN", "z":"哈马丹", "g":"Iran", "h":"伊朗"},{"c":"HAMBURG", "z":"汉堡", "g":"Germany", "h":"德国"},{"c":"HAMILTON", "z":"哈密尔顿", "g":"Bermuda Islands", "h":"百慕大群岛"},{"c":"HAMILTON", "z":"哈密尔顿", "g":"Canada", "h":"加拿大"},{"c":"HAMINA", "z":"哈米纳", "g":"Finland", "h":"芬兰"},{"c":"HAMM", "z":"哈姆", "g":"Germany", "h":"德国"},{"c":"HANKO", "z":"汉科", "g":"Finland", "h":"芬兰"},{"c":"HANNOVER", "z":"汉诺威", "g":"Germany", "h":"德国"},{"c":"HANOI", "z":"河内", "g":"Vietnam", "h":"越南"},{"c":"HARARE", "z":"哈拉雷", "g":"Zmbabe", "h":"津巴布韦"},{"c":"HASTINGS", "z":"黑斯廷斯", "g":"United Kingdom", "h":"英国"},{"c":"HAUGESUND", "z":"豪格松", "g":"Norway", "h":"挪威"},{"c":"HAVANA", "z":"哈瓦那", "g":"Cuba", "h":"古巴"},{"c":"HAVRE", "z":"哈佛", "g":"United States", "h":"美国"},{"c":"HAYDARPASA", "z":"海达尔帕夏", "g":"Turkey", "h":"土耳其"},{"c":"HEIDELBERG", "z":"海德堡", "g":"Germany", "h":"德国"},{"c":"HEILBRONN", "z":"海尔布隆", "g":"Germany", "h":"德国"},{"c":"HELSINGBORG", "z":"赫尔辛堡", "g":"Sweden", "h":"瑞典"},{"c":"HELSINKI", "z":"赫尔辛基", "g":"Finland", "h":"芬兰"},{"c":"HENBURY", "z":"亨伯里", "g":"Australia", "h":"澳大利亚"},{"c":"HERAKLION", "z":"伊拉克利翁", "g":"Greece", "h":"希腊"},{"c":"HERAT", "z":"赫拉特", "g":"Afghanistan", "h":"阿富汗"},{"c":"HEREDIA", "z":"埃雷迪亚", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"HERMOSILLO", "z":"埃莫西约", "g":"Mexico", "h":"墨西哥"},{"c":"HERNE", "z":"黑尔讷", "g":"Germany", "h":"德国"},{"c":"HIDALGO", "z":"伊达尔戈", "g":"Mexico", "h":"墨西哥"},{"c":"HILDESHEIM", "z":"希尔德斯海姆", "g":"Germany", "h":"德国"},{"c":"HIMEJI", "z":"姬路", "g":"Japan", "h":"日本"},{"c":"HIROSHIMA", "z":"广岛", "g":"Japan", "h":"日本"},{"c":"HITACHINAKA", "z":"日立那珂", "g":"Japan", "h":"日本"},{"c":"HO CHI MINH CITY", "z":"胡志明市", "g":"Vietnam", "h":"越南"},{"c":"HOBART", "z":"霍巴特", "g":"Australia", "h":"澳大利亚"},{"c":"HODEIDAH", "z":"荷台达", "g":"Yemen", "h":"也门"},{"c":"HONIARA", "z":"霍尼亚拉", "g":"The Solomon Islands", "h":"所罗门群岛"},{"c":"HONOLULU", "z":"檀香山", "g":"United States", "h":"美国"},{"c":"HORSENS", "z":"霍森斯", "g":"Denmark", "h":"丹麦"},{"c":"HOSOSHIMA", "z":"细岛", "g":"Japan", "h":"日本"},{"c":"HOUSTON", "z":"休斯敦", "g":"United States", "h":"美国"},{"c":"HUELVA", "z":"韦尔瓦", "g":"Spain", "h":"西班牙"},{"c":"HUESCA", "z":"韦斯卡", "g":"Spain", "h":"西班牙"},{"c":"HULL", "z":"赫尔", "g":"United Kingdom", "h":"英国"},{"c":"HUNTSVILLE", "z":"汉茨维尔", "g":"United States", "h":"美国"},{"c":"HYDERABAD", "z":"海得拉巴", "g":"India", "h":"印度"},{"c":"HYDERABAD", "z":"海得拉巴", "g":"Pakistan", "h":"巴基斯坦"},{"c":"IBIZA", "z":"伊维萨", "g":"Spain", "h":"西班牙"},{"c":"ILO", "z":"伊洛", "g":"Peru", "h":"秘鲁"},{"c":"ILYICHEVSK", "z":"伊利伊雷夫斯基", "g":"Russia", "h":"俄罗斯"},{"c":"IMABARI", "z":"今治", "g":"Japan", "h":"日本"},{"c":"IMARI", "z":"伊万里", "g":"Japan", "h":"日本"},{"c":"IMBITUBA", "z":"因比图巴", "g":"Brazil", "h":"巴西"},{"c":"IMMINGHAM", "z":"伊明赫姆船坞", "g":"United Kingdom", "h":"英国"},{"c":"IMPERIA", "z":"因佩里亚", "g":"Italy", "h":"意大利"},{"c":"INCHON", "z":"仁川", "g":"South Korea", "h":"韩国"},{"c":"INDIANAPOLIS", "z":"印第安纳波利斯", "g":"United States", "h":"美国"},{"c":"INGOLSTADT", "z":"因戈尔施塔特", "g":"Germany", "h":"德国"},{"c":"INNSBRUCK", "z":"因斯布鲁克", "g":"Austria", "h":"奥地利"},{"c":"INVERCARGILL", "z":"因弗卡吉尔", "g":"New Zealand", "h":"新西兰"},{"c":"IPSWICH", "z":"伊普斯威奇", "g":"United Kingdom", "h":"英国"},{"c":"IQUIQUE", "z":"伊基克", "g":"Chile", "h":"智利"},{"c":"IRUN", "z":"伊伦", "g":"Spain", "h":"西班牙"},{"c":"IRVING", "z":"欧文", "g":"United States", "h":"美国"},{"c":"ISHIKARI", "z":"石狩", "g":"Japan", "h":"日本"},{"c":"ISLAMABAD", "z":"伊斯兰堡", "g":"Pakistan", "h":"巴基斯坦"},{"c":"ISTANBUL", "z":"伊斯坦布尔", "g":"Turkey", "h":"土耳其"},{"c":"ITAJAI", "z":"伊塔加", "g":"Brazil", "h":"巴西"},{"c":"ITAQUI", "z":"伊塔基", "g":"Brazil", "h":"巴西"},{"c":"IWAKUNI", "z":"岩国", "g":"Japan", "h":"日本"},{"c":"IYO", "z":"伊予", "g":"Japan", "h":"日本"},{"c":"IYOMISHIMA", "z":"伊予三岛", "g":"Japan", "h":"日本"},{"c":"IZMIR", "z":"伊兹密尔", "g":"Turkey", "h":"土耳其"},{"c":"IZMIT", "z":"伊兹米特", "g":"Turkey", "h":"土耳其"},{"c":"JACKSONVILLE", "z":"捷克逊维尔", "g":"United States", "h":"美国"},{"c":"JAEN", "z":"哈安", "g":"Spain", "h":"西班牙"},{"c":"JAIPUR", "z":"斋浦尔", "g":"India", "h":"印度"},{"c":"JAKARTA", "z":"雅加达", "g":"Indonesia", "h":"印度尼西亚"},{"c":"JAMBI", "z":"占碑", "g":"Indonesia", "h":"印度尼西亚"},{"c":"JARROW", "z":"贾罗", "g":"United Kingdom", "h":"英国"},{"c":"JAWAHARLAL NEHRU", "z":"贾瓦哈拉尔 尼赫鲁", "g":"India", "h":"印度"},{"c":"JEBEL ALI", "z":"杰贝阿里", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"JEDDAH", "z":"吉达", "g":"Saudi Arabia", "h":"沙特阿拉伯"},{"c":"JENA", "z":"耶拿", "g":"Germany", "h":"德国"},{"c":"JERSEY", "z":"泽西岛", "g":"United Kingdom", "h":"英国"},{"c":"JINJA", "z":"金贾", "g":"Uganda", "h":"乌干达"},{"c":"JODHPUR", "z":"焦特布尔", "g":"India", "h":"印度"},{"c":"JOHANNESBURG", "z":"约翰内斯堡", "g":"South Africa", "h":"南非"},{"c":"JONKOPING", "z":"延雪平", "g":"Sweden", "h":"瑞典"},{"c":"JORDAN", "z":"约旦", "g":"Jordan", "h":"约旦"},{"c":"JORDAN", "z":"约旦", "g":"Jordan", "h":"约旦"},{"c":"JUBAIL", "z":"朱拜勒", "g":"Saudi Arabia", "h":"沙特阿拉伯"},{"c":"KABUL", "z":"喀布尔", "g":"Afghanistan", "h":"阿富汗"},{"c":"KAGOSHIMA", "z":"鹿儿岛", "g":"Japan", "h":"日本"},{"c":"KAISERSLAUTERN", "z":"凯撒斯劳滕", "g":"Germany", "h":"德国"},{"c":"KALININGRAD", "z":"加里宁格勒", "g":"Russia", "h":"俄罗斯"},{"c":"KAMPALA", "z":"坎帕拉", "g":"Uganda", "h":"乌干达"},{"c":"KANAZAWA", "z":"金泽", "g":"Japan", "h":"日本"},{"c":"KANDAHAR", "z":"坎大哈", "g":"Afghanistan", "h":"阿富汗"},{"c":"KANDLA", "z":"坎德拉", "g":"India", "h":"印度"},{"c":"KANPUR", "z":"坎普尔", "g":"India", "h":"印度"},{"c":"KANSAS CITY", "z":"堪萨斯城", "g":"United States", "h":"美国"},{"c":"KAOHSIUNG", "z":"高雄", "g":"Taiwan，China", "h":"中国台湾"},{"c":"KARACHI", "z":"卡拉奇", "g":"Pakistan", "h":"巴基斯坦"},{"c":"KARAMAN", "z":"卡拉曼", "g":"Turkey", "h":"土耳其"},{"c":"KARLSRUHE", "z":"卡尔斯鲁厄", "g":"Germany", "h":"德国"},{"c":"KASSEL", "z":"卡塞尔", "g":"Germany", "h":"德国"},{"c":"KATOWICE", "z":"卡托维兹", "g":"Poland", "h":"波兰"},{"c":"KAUNAS", "z":"考纳斯", "g":"Lithuania", "h":"立陶宛"},{"c":"KAWASAKI", "z":"川崎", "g":"Japan", "h":"日本"},{"c":"KEARNY", "z":"卡尼", "g":"United States", "h":"美国"},{"c":"KEELUNG", "z":"基隆", "g":"Taiwan，China", "h":"中国台湾"},{"c":"KEMI", "z":"凯米", "g":"Finland", "h":"芬兰"},{"c":"KEMPTEN", "z":"肯普滕", "g":"Germany", "h":"德国"},{"c":"KENT", "z":"肯特", "g":"United Kingdom", "h":"英国"},{"c":"KERMAN", "z":"克尔曼", "g":"Iran", "h":"伊朗"},{"c":"KHARKOV", "z":"哈尔科夫", "g":"Ukraine", "h":"乌克兰"},{"c":"KHOMS", "z":"欧胡姆斯", "g":"Libya", "h":"利比亚"},{"c":"KHOR AL FAKKAN", "z":"豪尔费坎", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"KHORRAMABAD", "z":"霍拉马巴德", "g":"Iran", "h":"伊朗"},{"c":"KHORRAMSHAHR", "z":"霍拉姆沙赫尔", "g":"Iran", "h":"伊朗"},{"c":"KIEL", "z":"基尔", "g":"Germany", "h":"德国"},{"c":"KIEV", "z":"基辅", "g":"Ukraine", "h":"乌克兰"},{"c":"KIGALI", "z":"基加利", "g":"Rwanda", "h":"卢旺达"},{"c":"KINGSTON", "z":"金斯顿", "g":"Jamaica", "h":"牙买加"},{"c":"KINGSTOWN", "z":"金斯敦", "g":"Saint Vincent and the Grenadines", "h":"圣文森特和格林纳丁斯"},{"c":"KINSHASA", "z":"金沙萨", "g":"Congo", "h":"刚果（金）"},{"c":"KINSTON", "z":"金斯顿", "g":"United States", "h":"美国"},{"c":"KISH ISLAND", "z":"奎什岛", "g":"Iran", "h":"伊朗"},{"c":"KISUMU", "z":"基苏木", "g":"Kenya", "h":"肯尼亚"},{"c":"KITWE", "z":"基特韦", "g":"Congo", "h":"刚果"},{"c":"KITWE", "z":"基特韦", "g":"Zambia", "h":"赞比亚"},{"c":"KLAGENFURT", "z":"克拉根福", "g":"Austria", "h":"奥地利"},{"c":"KLAIPEDA", "z":"克莱佩达", "g":"Lithuania", "h":"立陶宛"},{"c":"KNOXVILLE", "z":"诺克斯维尔", "g":"United States", "h":"美国"},{"c":"KOBE", "z":"神户", "g":"Japan", "h":"日本"},{"c":"KOBLENZ", "z":"科布伦茨", "g":"Germany", "h":"德国"},{"c":"KOCHI", "z":"高知", "g":"Japan", "h":"日本"},{"c":"KOLDING", "z":"科灵", "g":"Denmark", "h":"丹麦"},{"c":"KOPER", "z":"科佩尔", "g":"Slovenia", "h":"斯洛文尼亚"},{"c":"KOROR", "z":"科罗尔", "g":"Palau", "h":"帕劳"},{"c":"KORSAKOV", "z":"科尔萨科夫", "g":"Russia", "h":"俄罗斯"},{"c":"KOTA", "z":"科塔", "g":"India", "h":"印度"},{"c":"KOTDA", "z":"科特卡", "g":"Finland", "h":"芬兰"},{"c":"KOTKA", "z":"科特卡", "g":"Finland", "h":"芬兰"},{"c":"KRAKOW", "z":"克拉科夫", "g":"Poland", "h":"波兰"},{"c":"KRANJ", "z":"克拉尼", "g":"Slovenia", "h":"斯洛文尼亚"},{"c":"KREFELD", "z":"克雷菲尔德", "g":"Germany", "h":"德国"},{"c":"KRISTIANSAND", "z":"克里斯蒂安桑", "g":"Norway", "h":"挪威"},{"c":"KUALA BELAIT", "z":"白拉奕", "g":"Brunei", "h":"文莱"},{"c":"KUALA LUMPUR", "z":"吉隆坡", "g":"Malaysia", "h":"马来西亚"},{"c":"KUANTAN", "z":"关丹", "g":"Malaysia", "h":"马来西亚"},{"c":"KUCHING", "z":"古晋", "g":"Malaysia", "h":"马来西亚"},{"c":"KUMAMOTO", "z":"熊本市", "g":"Japan", "h":"日本"},{"c":"KUMPORT", "z":"康普特", "g":"Turkey", "h":"土耳其"},{"c":"KUNSAN", "z":"群山", "g":"South Korea", "h":"韩国"},{"c":"KURE", "z":"吴港", "g":"Japan", "h":"日本"},{"c":"KUSHIRO", "z":"钏路", "g":"Japan", "h":"日本"},{"c":"KUWAIT", "z":"科威特", "g":"Kuwait", "h":"科威特"},{"c":"KWANGYANG", "z":"光阳", "g":"South Korea", "h":"韩国"},{"c":"LA CEIBA", "z":"拉塞瓦", "g":"Honduras", "h":"洪都拉斯"},{"c":"LA CORUNA", "z":"拉科鲁尼亚", "g":"Spain", "h":"西班牙"},{"c":"LA GUAIRA", "z":"拉瓜伊拉", "g":"Venezuela", "h":"委内瑞拉"},{"c":"LA LIBERTAD", "z":"拉里伯塔德", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"LA PAZ", "z":"拉巴斯", "g":"Mexico", "h":"墨西哥"},{"c":"LA SPEZIA", "z":"拉斯佩齐亚", "g":"Italy", "h":"意大利"},{"c":"LA UNION", "z":"拉乌尼翁", "g":"Philippines", "h":"菲律宾"},{"c":"LA UNION", "z":"拉乌尼翁", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"LAE", "z":"莱城", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"LAEM CHABANG", "z":"林查班", "g":"Thailand", "h":"泰国"},{"c":"LAGOS", "z":"拉各斯", "g":"Nigeria", "h":"尼日利亚"},{"c":"LAHORE", "z":"拉合尔", "g":"Pakistan", "h":"巴基斯坦"},{"c":"LAKE CITY", "z":"湖城", "g":"United States", "h":"美国"},{"c":"LAREDO", "z":"新拉雷多", "g":"Mexico", "h":"墨西哥"},{"c":"LARNACA", "z":"拉纳卡", "g":"Cyprus", "h":"塞浦路斯"},{"c":"LARVIK", "z":"拉尔维克", "g":"Norway", "h":"挪威"},{"c":"LAS MINAS", "z":"拉斯米纳斯港", "g":"Panama", "h":"巴拿马"},{"c":"LAS PALMAS", "z":"拉斯帕尔马斯", "g":"CanaryIslands", "h":"加纳利群岛"},{"c":"LAS PIEDRAS", "z":"拉斯皮耶德拉斯", "g":"Venezuela", "h":"委内瑞拉"},{"c":"LAS VEGAS", "z":"拉斯韦加斯", "g":"United States", "h":"美国"},{"c":"LAT KRABANG", "z":"来卡邦", "g":"Thailand", "h":"泰国"},{"c":"LATAKIA", "z":"拉塔基亚", "g":"Syria", "h":"叙利亚"},{"c":"LATINA", "z":"拉蒂纳", "g":"Italy", "h":"意大利"},{"c":"LAUNCESTON", "z":"朗塞斯顿", "g":"Australia", "h":"澳大利亚"},{"c":"LAUSANNE", "z":"洛桑", "g":"Stzerland", "h":"瑞士"},{"c":"LAUTOKA", "z":"劳托卡", "g":"Fuji Island", "h":"斐济群岛"},{"c":"LAZARO CARDENAS", "z":"拉萨罗－卡德纳斯", "g":"Mexico", "h":"墨西哥"},{"c":"LE HAVRE", "z":"勒哈弗尔", "g":"France", "h":"法国"},{"c":"LE MANS", "z":"勒芒", "g":"France", "h":"法国"},{"c":"LE VERDON", "z":"勒凡尔登", "g":"France", "h":"法国"},{"c":"LECCE", "z":"莱切", "g":"Italy", "h":"意大利"},{"c":"LECCO", "z":"莱科", "g":"Italy", "h":"意大利"},{"c":"LEEDS", "z":"利兹", "g":"United Kingdom", "h":"英国"},{"c":"LEGHORN", "z":"里窝那", "g":"Italy", "h":"意大利"},{"c":"LEH", "z":"列城", "g":"India", "h":"印度"},{"c":"LEICESTER", "z":"莱斯特", "g":"United Kingdom", "h":"英国"},{"c":"LEIGH", "z":"莱", "g":"United Kingdom", "h":"英国"},{"c":"LEIPZIG", "z":"莱比锡", "g":"Germany", "h":"德国"},{"c":"LEIXOES", "z":"雷克索斯", "g":"Portugal", "h":"葡萄牙"},{"c":"LENS", "z":"郎斯", "g":"Belgium", "h":"比利时"},{"c":"LENS", "z":"郎斯", "g":"France", "h":"法国"},{"c":"LEON", "z":"利昂", "g":"Spain", "h":"西班牙"},{"c":"LERMA", "z":"莱尔马", "g":"Spain", "h":"西班牙"},{"c":"LEVERKUSEN", "z":"莱沃库森", "g":"Germany", "h":"德国"},{"c":"LIANYUNGANG", "z":"连云港", "g":"China", "h":"中国"},{"c":"LIBERIA", "z":"利比里亚", "g":"Liberia", "h":"利比里亚"},{"c":"LIBREVILLE", "z":"利伯维尔", "g":"Gabon", "h":"加蓬"},{"c":"LIEPAJA", "z":"利耶帕亚", "g":"Latvia", "h":"拉脱维亚"},{"c":"LILLE", "z":"里尔", "g":"France", "h":"法国"},{"c":"LILONGWE", "z":"利隆圭", "g":"Malawi", "h":"马拉维"},{"c":"LIMA", "z":"利马", "g":"Peru", "h":"秘鲁"},{"c":"LIMA", "z":"莱马", "g":"United States", "h":"美国"},{"c":"LIMASSOL", "z":"利马索尔", "g":"Cyprus", "h":"塞浦路斯"},{"c":"LIMOGES", "z":"利摩日", "g":"France", "h":"法国"},{"c":"LIMON", "z":"利蒙", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"LINDAU", "z":"林道", "g":"Germany", "h":"德国"},{"c":"LINGEN", "z":"林根", "g":"Germany", "h":"德国"},{"c":"LINKOPING", "z":"林雪平", "g":"Sweden", "h":"瑞典"},{"c":"LINZ", "z":"林茨", "g":"Austria", "h":"奥地利"},{"c":"LIRQUEN", "z":"利尔昆", "g":"Chile", "h":"智利"},{"c":"LISBON", "z":"里斯本", "g":"Portugal", "h":"葡萄牙"},{"c":"LISLE", "z":"莱尔", "g":"United States", "h":"美国"},{"c":"LITTLE ROCK", "z":"小石城", "g":"United States", "h":"美国"},{"c":"LIVERPOOL", "z":"利物浦", "g":"United Kingdom", "h":"英国"},{"c":"LIVINGSTON", "z":"利文斯顿", "g":"United Kingdom", "h":"英国"},{"c":"LIVINGSTON", "z":"利文斯顿", "g":"United States", "h":"美国"},{"c":"LIVINGSTONE", "z":"利文斯通", "g":"Zambia", "h":"赞比亚"},{"c":"LJUBLJANA", "z":"卢布尔雅那", "g":"Slovenia", "h":"斯洛文尼亚"},{"c":"LOBITO", "z":"洛比托", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"LODZ", "z":"罗兹", "g":"Poland", "h":"波兰"},{"c":"LOGRONO", "z":"洛格洛诺", "g":"Spain", "h":"西班牙"},{"c":"LOME", "z":"洛美", "g":"Togo", "h":"多哥"},{"c":"LONDON", "z":"伦敦", "g":"United Kingdom", "h":"英国"},{"c":"LONDONDERRY", "z":"伦敦德里", "g":"United Kingdom", "h":"英国"},{"c":"LONG BEACH", "z":"长滩", "g":"United States", "h":"美国"},{"c":"LONG ISLAND", "z":"长岛", "g":"United States", "h":"美国"},{"c":"LONGONI", "z":"隆戈尼", "g":"Mayotte", "h":"马约特"},{"c":"LORCA", "z":"洛尔卡", "g":"Spain", "h":"西班牙"},{"c":"LOS ANGELES", "z":"洛杉矶", "g":"United States", "h":"美国"},{"c":"LOUISVILLE", "z":"路易维尔", "g":"United States", "h":"美国"},{"c":"LUANDA", "z":"罗安达", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"LUBECK", "z":"卢贝克", "g":"Germany", "h":"德国"},{"c":"LUBUMBASHI", "z":"卢本巴希", "g":"Congo", "h":"刚果（金）"},{"c":"LUCCA", "z":"卢卡", "g":"Italy", "h":"意大利"},{"c":"LUDHIANA", "z":"卢迪亚纳", "g":"India", "h":"印度"},{"c":"LUDWIGSHAFEN", "z":"路德维希港", "g":"Germany", "h":"德国"},{"c":"LUSAKA", "z":"卢萨卡", "g":"Zambia", "h":"赞比亚"},{"c":"LYON", "z":"里昂", "g":"France", "h":"法国"},{"c":"LYTTELTON", "z":"利特尔顿", "g":"New Zealand", "h":"新西兰"},{"c":"MAALOY", "z":"马洛于", "g":"Norway", "h":"挪威"},{"c":"MACAU", "z":"澳门", "g":"China", "h":"中国"},{"c":"MACERATA", "z":"马切拉塔", "g":"Italy", "h":"意大利"},{"c":"MADANG", "z":"马丹", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"MADRID", "z":"马德里", "g":"Spain", "h":"西班牙"},{"c":"MAGDALENA", "z":"马格达莱纳", "g":"Poland", "h":"波兰"},{"c":"MAGDALENA", "z":"马格达莱纳", "g":"United States", "h":"美国"},{"c":"MAGDALENA", "z":"马格达莱纳", "g":"Mexico", "h":"墨西哥"},{"c":"MAGDEBURG", "z":"马格德堡市", "g":"Germany", "h":"德国"},{"c":"MAHE", "z":"马希", "g":"India", "h":"印度"},{"c":"MAINZ", "z":"美因茨", "g":"Germany", "h":"德国"},{"c":"MAIZURU", "z":"舞鹤", "g":"Japan", "h":"日本"},{"c":"MAJURO", "z":"马朱罗", "g":"Marshall Island", "h":"马绍尔群岛"},{"c":"MALABO", "z":"马拉博", "g":"Equatorial Guinea", "h":"赤道几内亚"},{"c":"MALAGA", "z":"马拉加", "g":"Spain", "h":"西班牙"},{"c":"MALE", "z":"马累", "g":"Maldives", "h":"马尔代夫"},{"c":"MALLORCA", "z":"马略卡", "g":"Spain", "h":"西班牙"},{"c":"MALMOE", "z":"马尔默", "g":"Sweden", "h":"瑞典"},{"c":"MALTA", "z":"马耳他", "g":"Malta", "h":"马耳他"},{"c":"MANAGUA", "z":"马那瓜", "g":"Nicaragua", "h":"尼加拉瓜"},{"c":"MANAMA", "z":"麦纳麦", "g":"Bahrain", "h":"巴林"},{"c":"MANAUS", "z":"马瑙斯", "g":"Brazil", "h":"巴西"},{"c":"MANCHESTER", "z":"曼彻斯特", "g":"United Kingdom", "h":"英国"},{"c":"MANGALORE", "z":"门格洛尔", "g":"India", "h":"印度"},{"c":"MANILA", "z":"马尼拉", "g":"Philippines", "h":"菲律宾"},{"c":"MANIZALES", "z":"马尼萨莱斯", "g":"Colombia", "h":"哥伦比亚"},{"c":"MANNHEIM", "z":"曼海姆", "g":"Germany", "h":"德国"},{"c":"MANTA", "z":"曼塔", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"MANTOVA", "z":"曼图亚", "g":"Italy", "h":"意大利"},{"c":"MANTYLUOTO", "z":"曼蒂卢奥托", "g":"Finland", "h":"芬兰"},{"c":"MANZANILLA", "z":"曼萨尼略", "g":"Mexico", "h":"墨西哥"},{"c":"MANZANILLA", "z":"曼萨尼略", "g":"Cuba", "h":"古巴"},{"c":"MANZANILLO", "z":"曼萨尼约角", "g":"Panama", "h":"巴拿马"},{"c":"MANZANILLO", "z":"曼萨尼约", "g":"Mexico", "h":"墨西哥"},{"c":"MAPUTO", "z":"马普托", "g":"Mozambique", "h":"莫桑比克"},{"c":"MARACAIBO", "z":"马拉开波", "g":"Venezuela", "h":"委内瑞拉"},{"c":"MARDAS", "z":"玛达萨", "g":"Turkey", "h":"土耳其"},{"c":"MARIBOR", "z":"马里博尔", "g":"Slovenia", "h":"斯洛文尼亚"},{"c":"MARSAXLOKK", "z":"马尔萨什洛克", "g":"Malta", "h":"马耳他"},{"c":"MARSEILLE", "z":"马赛", "g":"France", "h":"法国"},{"c":"MASERU", "z":"马塞卢", "g":"Lesotho", "h":"莱索托"},{"c":"MASSA", "z":"马萨", "g":"Italy", "h":"意大利"},{"c":"MASSAWA", "z":"马萨瓦", "g":"Ethiopia", "h":"埃塞俄比亚"},{"c":"MATADI", "z":"马塔迪", "g":"Congo", "h":"刚果（金）"},{"c":"MATARANI", "z":"马塔拉尼", "g":"Peru", "h":"秘鲁"},{"c":"MATERA", "z":"马泰拉", "g":"Italy", "h":"意大利"},{"c":"MATSAPHA", "z":"马撒哈", "g":"Swaziland", "h":"斯威士兰"},{"c":"MATSUYAMA", "z":"松山", "g":"Japan", "h":"日本"},{"c":"MAZATLAN", "z":"马萨特兰", "g":"Mexico", "h":"墨西哥"},{"c":"MBABANE", "z":"姆巴巴内", "g":"Swaziland", "h":"斯威士兰"},{"c":"MEDAN", "z":"棉兰", "g":"Indonesia", "h":"印度尼西亚"},{"c":"MEDELLIN", "z":"麦德林", "g":"Colombia", "h":"哥伦比亚"},{"c":"MEJILLONES", "z":"梅希约内斯", "g":"Chile", "h":"智利"},{"c":"MELBOURN", "z":"梅尔本", "g":"United Kingdom", "h":"英国"},{"c":"MELBOURNE", "z":"墨尔本", "g":"Australia", "h":"澳大利亚"},{"c":"MELILLA", "z":"梅利利亚", "g":"Morocco", "h":"摩洛哥"},{"c":"MEMPHIS", "z":"孟菲斯", "g":"United States", "h":"美国"},{"c":"MENDOZA", "z":"门多萨", "g":"Argentina", "h":"阿根廷"},{"c":"MERSIN", "z":"梅尔辛", "g":"Turkey", "h":"土耳其"},{"c":"MESSINA", "z":"墨西拿", "g":"Italy", "h":"意大利"},{"c":"METZ", "z":"梅斯", "g":"France", "h":"法国"},{"c":"MEXICALI", "z":"墨西卡利", "g":"Mexico", "h":"墨西哥"},{"c":"MEXICO", "z":"墨西哥", "g":"Mexico", "h":"墨西哥"},{"c":"MEXICO CITY", "z":"墨西哥城", "g":"Mexico", "h":"墨西哥"},{"c":"MIAMI", "z":"迈阿密", "g":"United States", "h":"美国"},{"c":"MIDDLEBORO", "z":"米德尔伯勒", "g":"United States", "h":"美国"},{"c":"MIDDLESBORO", "z":"米德尔斯伯勒", "g":"United States", "h":"美国"},{"c":"MILAN", "z":"米兰", "g":"Italy", "h":"意大利"},{"c":"MILTON", "z":"米尔顿", "g":"United States", "h":"美国"},{"c":"MILWAUKEE", "z":"蜜尔沃基", "g":"United States", "h":"美国"},{"c":"MINA QABOOS", "z":"米纳卡布斯", "g":"Oman", "h":"阿曼"},{"c":"MINA SULMAN", "z":"米纳萨门", "g":"Bahrain", "h":"巴林"},{"c":"MINAS", "z":"米纳斯", "g":"Cuba", "h":"古巴"},{"c":"MINAS", "z":"米纳斯", "g":"Indonesia", "h":"印度尼西亚"},{"c":"MINAS", "z":"米纳斯", "g":"Uruguay", "h":"乌拉圭"},{"c":"MINATITLAN", "z":"米纳蒂特兰", "g":"Mexico", "h":"墨西哥"},{"c":"MINDELO", "z":"明德卢", "g":"Cape VerdeRepública de Cabo Verde", "h":"佛得角"},{"c":"MINGO", "z":"明戈", "g":"United States", "h":"美国"},{"c":"MINNEAPOLIS", "z":"明尼阿波利斯", "g":"United States", "h":"美国"},{"c":"MIRA", "z":"米拉", "g":"Italy", "h":"意大利"},{"c":"MIRA LOMA", "z":"迈拉·罗马", "g":"United States", "h":"美国"},{"c":"MISURATA", "z":"米苏拉塔区", "g":"Libya", "h":"利比亚"},{"c":"MIZUSHIMA", "z":"水岛", "g":"Japan", "h":"日本"},{"c":"MOBILE", "z":"莫比尔", "g":"United States", "h":"美国"},{"c":"MODENA", "z":"摩德纳", "g":"Italy", "h":"意大利"},{"c":"MOJI", "z":"门司", "g":"Japan", "h":"日本"},{"c":"MOMBASA", "z":"蒙巴萨", "g":"Kenya", "h":"肯尼亚"},{"c":"MONCHENGLADBACH", "z":"门兴格拉德巴赫", "g":"Germany", "h":"德国"},{"c":"MONGLA", "z":"蒙格拉", "g":"Bangladesh", "h":"孟加拉国"},{"c":"MONROVIA", "z":"蒙罗维尔", "g":"Liberia", "h":"利比里亚"},{"c":"MONTEGO BAY", "z":"蒙特歌湾", "g":"Jamaica", "h":"牙买加"},{"c":"MONTEREY", "z":"蒙特雷", "g":"United States", "h":"美国"},{"c":"MONTERREY", "z":"蒙特雷", "g":"Mexico", "h":"墨西哥"},{"c":"MONTEVIDEO", "z":"蒙得维的亚", "g":"Uruguay", "h":"乌拉圭"},{"c":"MONTGOMERY", "z":"蒙哥马利", "g":"United States", "h":"美国"},{"c":"MONTO", "z":"蒙托", "g":"Australia", "h":"澳大利亚"},{"c":"MONTOIR DE BRETAGNE", "z":"蒙托伊尔 德布列塔尼", "g":"France", "h":"法国"},{"c":"MONTPELLIER", "z":"蒙波利埃", "g":"France", "h":"法国"},{"c":"MONTREAL", "z":"蒙特利尔", "g":"Canada", "h":"加拿大"},{"c":"MORADABAD", "z":"莫拉达巴德", "g":"India", "h":"印度"},{"c":"MORELIA", "z":"莫雷利亚", "g":"Mexico", "h":"墨西哥"},{"c":"MORESBY", "z":"莫尔兹比", "g":"United Kingdom", "h":"英国"},{"c":"MORON", "z":"莫龙", "g":"Venezuela", "h":"委内瑞拉"},{"c":"MORONI", "z":"莫罗尼", "g":"Comoros", "h":"科摩罗"},{"c":"MOSCOW", "z":"莫斯科", "g":"Russia", "h":"俄罗斯"},{"c":"MOSTAGANEM", "z":"穆斯塔加奈", "g":"Albania", "h":"阿尔及利亚"},{"c":"MUARA", "z":"麻拉", "g":"Brunei", "h":"文莱"},{"c":"MUKALLA", "z":"木卡拉", "g":"Yemen", "h":"也门"},{"c":"MUKALLA", "z":"木卡拉", "g":"Yemen", "h":"也门"},{"c":"MULHOUSE", "z":"米卢斯", "g":"France", "h":"法国"},{"c":"MULUND", "z":"默伦达", "g":"India", "h":"印度"},{"c":"MUNDRA", "z":"蒙德拉", "g":"India", "h":"印度"},{"c":"MUNICH", "z":"慕尼黑", "g":"Germany", "h":"德国"},{"c":"MUNSTER", "z":"芒斯特", "g":"Ireland", "h":"爱尔兰"},{"c":"MURCIA", "z":"穆尔西亚", "g":"Spain", "h":"西班牙"},{"c":"MURMANSK", "z":"摩尔曼斯克", "g":"Russia", "h":"俄罗斯"},{"c":"MURORAN", "z":"室兰", "g":"Japan", "h":"日本"},{"c":"MUSCAT", "z":"马斯喀特", "g":"Oman", "h":"阿曼"},{"c":"MUTARE", "z":"穆塔雷", "g":"Zmbabe", "h":"津巴布韦"},{"c":"MUTSAMUDU", "z":"木察木杜", "g":"Comoros", "h":"科摩罗"},{"c":"NACALA", "z":"纳卡拉", "g":"Mozambique", "h":"莫桑比克"},{"c":"NACO", "z":"纳科", "g":"Mexico", "h":"墨西哥"},{"c":"NAGANO", "z":"长野", "g":"Japan", "h":"日本"},{"c":"NAGASAKI", "z":"长崎", "g":"Japan", "h":"日本"},{"c":"NAGAYO", "z":"长与町", "g":"Japan", "h":"日本"},{"c":"NAGOYA", "z":"名古屋", "g":"Japan", "h":"日本"},{"c":"NAGPUR", "z":"那格浦尔", "g":"India", "h":"印度"},{"c":"NAHA", "z":"那坝", "g":"Japan", "h":"日本"},{"c":"NAIROBI", "z":"内罗毕", "g":"Kenya", "h":"肯尼亚"},{"c":"NAKANOSEKI", "z":"中关", "g":"Japan", "h":"日本"},{"c":"NAMIBE", "z":"纳米贝", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"NAMPO", "z":"南浦", "g":"North Korea", "h":"朝鲜"},{"c":"NANCY", "z":"南锡", "g":"France", "h":"法国"},{"c":"NANTES", "z":"南特", "g":"France", "h":"法国"},{"c":"NAOETSU", "z":"直江津", "g":"Japan", "h":"日本"},{"c":"NAPIER", "z":"内皮尔", "g":"New Zealand", "h":"新西兰"},{"c":"NAPLES", "z":"那不勒斯", "g":"Italy", "h":"意大利"},{"c":"NASHVILLE", "z":"纳斯维尔", "g":"United States", "h":"美国"},{"c":"NASSAU", "z":"拿骚", "g":"Bahamas", "h":"巴哈马"},{"c":"NAUEN", "z":"瑙恩", "g":"Germany", "h":"德国"},{"c":"NAVEGANTES", "z":"纳维根特斯", "g":"Brazil", "h":"巴西"},{"c":"NAWABSHAH", "z":"讷瓦布沙阿", "g":"Pakistan", "h":"巴基斯坦"},{"c":"NDELE", "z":"恩代莱", "g":"Central Africa", "h":"中非"},{"c":"NDOLA", "z":"恩多拉", "g":"Zambia", "h":"赞比亚"},{"c":"NEAPOLIS", "z":"尼波利斯", "g":"Italy", "h":"意大利"},{"c":"NELSON", "z":"内尔逊", "g":"New Zealand", "h":"新西兰"},{"c":"NEUSS", "z":"诺伊斯", "g":"Germany", "h":"德国"},{"c":"NEW CASTLE", "z":"纽卡斯尔", "g":"Australia", "h":"澳大利亚"},{"c":"NEW CASTLE", "z":"纽卡斯尔", "g":"United States", "h":"美国"},{"c":"NEW DELHI", "z":"新德里", "g":"India", "h":"印度"},{"c":"NEW HYDE PARK", "z":"新海德公园", "g":"United States", "h":"美国"},{"c":"NEW ORLEANS", "z":"新奥尔良", "g":"United States", "h":"美国"},{"c":"NEW PLYMOUTH", "z":"新普利默斯", "g":"New Zealand", "h":"新西兰"},{"c":"NEW YORK", "z":"纽约", "g":"United States", "h":"美国"},{"c":"NEWARK", "z":"纽瓦克", "g":"United States", "h":"美国"},{"c":"NEWCASTLE", "z":"纽卡斯尔", "g":"United Kingdom", "h":"英国"},{"c":"NEWPORT", "z":"纽波特", "g":"United Kingdom", "h":"英国"},{"c":"NEWPORT NEWS", "z":"纽波特纽斯", "g":"United States", "h":"美国"},{"c":"NHAVA SHEVA", "z":"那瓦夏瓦", "g":"India", "h":"印度"},{"c":"NICE", "z":"尼斯", "g":"France", "h":"法国"},{"c":"NICOSIA", "z":"尼科西亚", "g":"Cyprus", "h":"塞浦路斯"},{"c":"NIIGATA", "z":"新鸿", "g":"Japan", "h":"日本"},{"c":"NINGBO", "z":"宁波", "g":"China", "h":"中国"},{"c":"NOGALES", "z":"诺加莱斯", "g":"Mexico", "h":"墨西哥"},{"c":"NOGALES", "z":"诺加利斯", "g":"United States", "h":"美国"},{"c":"NOLA", "z":"诺拉", "g":"Central Africa", "h":"中非"},{"c":"NORFOLK", "z":"诺福克", "g":"United States", "h":"美国"},{"c":"NORRKOPING", "z":"诺尔雪平", "g":"Sweden", "h":"瑞典"},{"c":"NORTHAM", "z":"诺瑟姆", "g":"Australia", "h":"澳大利亚"},{"c":"NORTHAMPTON", "z":"北安普敦", "g":"United Kingdom", "h":"英国"},{"c":"NORTHAMPTON", "z":"北安普敦", "g":"United States", "h":"美国"},{"c":"NOTTINGHAM", "z":"诺丁汉", "g":"United Kingdom", "h":"英国"},{"c":"NOUADHIBOU", "z":"努瓦迪布", "g":"Mauritania", "h":"毛里塔尼亚"},{"c":"NOUAKCHOTT", "z":"努瓦克肖特", "g":"Mauritania", "h":"毛利塔尼亚"},{"c":"NOUMEA", "z":"努美阿", "g":"New Caledonia", "h":"新喀里多尼亚"},{"c":"NOVARA", "z":"诺瓦拉", "g":"Italy", "h":"意大利"},{"c":"NOVO HAMBURGO", "z":"新汉布哥", "g":"Brazil", "h":"巴西"},{"c":"NOVOROSSIYSK", "z":"诺沃西比尔斯克", "g":"Russia", "h":"俄罗斯"},{"c":"NOVOSIBIRSK", "z":"新西伯利亚", "g":"Russia", "h":"俄罗斯"},{"c":"NUKU", "z":"努库", "g":"Tonga", "h":"汤加"},{"c":"NURNBERG", "z":"纽伦堡", "g":"Germany", "h":"德国"},{"c":"NUUK", "z":"努克", "g":"Denmark", "h":"丹麦"},{"c":"OAKLAND", "z":"奥克兰", "g":"United States", "h":"美国"},{"c":"OBERHAUSEN", "z":"奥伯豪森", "g":"Germany", "h":"德国"},{"c":"ODENSE", "z":"欧登塞", "g":"Denmark", "h":"丹麦"},{"c":"ODESSA", "z":"敖德萨", "g":"Ukraine", "h":"乌克兰"},{"c":"OFFENBACH", "z":"奥芬巴赫", "g":"Germany", "h":"德国"},{"c":"OFFENBURG", "z":"奥芬堡", "g":"Germany", "h":"德国"},{"c":"OITA", "z":"大分", "g":"Japan", "h":"日本"},{"c":"OKINAWA", "z":"冲绳", "g":"Japan", "h":"日本"},{"c":"OKLAHOMA CITY", "z":"俄克拉何马城", "g":"United States", "h":"美国"},{"c":"OKOYO", "z":"奥科约", "g":"Congo", "h":"刚果"},{"c":"OLIVIA", "z":"奥利维亚", "g":"United States", "h":"美国"},{"c":"OMAHA", "z":"奥马哈", "g":"United States", "h":"美国"},{"c":"OMISHIMA", "z":"大三岛", "g":"Japan", "h":"日本"},{"c":"ONAHAMA", "z":"小名滨", "g":"Japan", "h":"日本"},{"c":"ONNE", "z":"安里", "g":"Nigeria", "h":"尼日利亚"},{"c":"ONTARIO", "z":"安大略", "g":"Canada", "h":"加拿大"},{"c":"ORAN", "z":"奥兰", "g":"Albania", "h":"阿尔及利亚"},{"c":"ORANGE", "z":"奥兰治", "g":"United States", "h":"美国"},{"c":"ORANJESTAD", "z":"奥腊涅斯塔德", "g":"Antilles", "h":"安的列斯群岛"},{"c":"ORENSE", "z":"奥伦塞", "g":"Spain", "h":"西班牙"},{"c":"ORINO", "z":"托里诺", "g":"Itliy", "h":"意大利"},{"c":"ORISTANO", "z":"奥里斯塔诺", "g":"Italy", "h":"意大利"},{"c":"ORLAND", "z":"奥兰德", "g":"United States", "h":"美国"},{"c":"ORLANDO", "z":"奥兰多", "g":"United States", "h":"美国"},{"c":"ORLEANS", "z":"奥林斯", "g":"Canada", "h":"加拿大"},{"c":"OROBAY", "z":"奥罗湾", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"OSAKA", "z":"大阪", "g":"Japan", "h":"日本"},{"c":"OSLO", "z":"奥斯陆", "g":"Norway", "h":"挪威"},{"c":"OSNABRUCK", "z":"奥斯纳布吕克", "g":"Germany", "h":"德国"},{"c":"OTARU", "z":"小樽", "g":"Japan", "h":"日本"},{"c":"OTTA", "z":"奥塔岛", "g":"CanaryIslands", "h":"加纳利群岛"},{"c":"OTTAWA", "z":"渥太华", "g":"Canada", "h":"加拿大"},{"c":"OUAGADOUGOU", "z":"瓦加杜古", "g":"Burna Faso", "h":"布基纳法索"},{"c":"OVIEDO", "z":"奥维耶多", "g":"Spain", "h":"西班牙"},{"c":"OXFORD", "z":"牛津", "g":"United Kingdom", "h":"英国"},{"c":"PADANG", "z":"巴东", "g":"Indonesia", "h":"印度尼西亚"},{"c":"PADERBORN", "z":"帕德博恩", "g":"Germany", "h":"德国"},{"c":"PADOVA", "z":"帕多瓦", "g":"Italy", "h":"意大利"},{"c":"PAGO PAGO", "z":"帕果帕果", "g":"Samoa", "h":"萨摩亚群岛"},{"c":"PAITA", "z":"派塔", "g":"Peru", "h":"秘鲁"},{"c":"PALEMBANG", "z":"巨港", "g":"Indonesia", "h":"印度尼西亚"},{"c":"PALENCIA", "z":"帕伦西亚", "g":"Guatemala", "h":"危地马拉"},{"c":"PALENCIA", "z":"帕伦西亚", "g":"Spain", "h":"西班牙"},{"c":"PALERMO", "z":"巴勒莫", "g":"Italy", "h":"意大利"},{"c":"PALERMO", "z":"巴勒莫", "g":"United States", "h":"美国"},{"c":"PALERMO", "z":"巴勒莫", "g":"Argentina", "h":"阿根廷"},{"c":"PALMA", "z":"帕尔马", "g":"Spain", "h":"西班牙"},{"c":"PALMA MALLORCA", "z":"帕尔马 马洛卡", "g":"Spain", "h":"西班牙"},{"c":"PALMAR", "z":"帕尔马", "g":"Argentina", "h":"阿根廷"},{"c":"PALMAS", "z":"帕尔马斯", "g":"Colombia", "h":"哥伦比亚"},{"c":"PALMER", "z":"帕默", "g":"Canada", "h":"加拿大"},{"c":"PALMER", "z":"帕默", "g":"United States", "h":"美国"},{"c":"PALMERSTON", "z":"帕默斯顿", "g":"New Zealand", "h":"新西兰"},{"c":"PALMERSTON NORTH", "z":"北帕默斯顿", "g":"New Zealand", "h":"新西兰"},{"c":"PAMPLONA", "z":"潘普洛纳", "g":"Spain", "h":"西班牙"},{"c":"PANAMA CITY", "z":"巴拿马城", "g":"Panama", "h":"巴拿马"},{"c":"PAPEETE", "z":"帕皮提", "g":"Tahiti", "h":"塔希提岛"},{"c":"PARAISO", "z":"帕莱索", "g":"Chile", "h":"智利"},{"c":"PARAMARIBO", "z":"帕拉马里博", "g":"Suriname", "h":"苏里南"},{"c":"PARANA", "z":"巴拉那", "g":"Brazil", "h":"巴西"},{"c":"PARANAGUA", "z":"巴拉那瓜", "g":"Brazil", "h":"巴西"},{"c":"PARANG", "z":"帕兰", "g":"Philippines", "h":"菲律宾"},{"c":"PARGA", "z":"帕尔加", "g":"Chile", "h":"智利"},{"c":"PARIS", "z":"巴黎", "g":"France", "h":"法国"},{"c":"PARMA", "z":"帕尔马", "g":"Italy", "h":"意大利"},{"c":"PASIR GUDANG, JOHOR", "z":"帕西古当，柔佛", "g":"Malaysia", "h":"马来西亚"},{"c":"PATNA", "z":"巴特那", "g":"India", "h":"印度"},{"c":"PATPARGANJ", "z":"帕特帕疆", "g":"India", "h":"印度"},{"c":"PAVIA", "z":"帕维亚", "g":"Italy", "h":"意大利"},{"c":"PECEM", "z":"培森", "g":"Brazil", "h":"巴西"},{"c":"PEMBA", "z":"彭巴", "g":"Mozambique", "h":"莫桑比克"},{"c":"PENANG", "z":"槟城", "g":"Malaysia", "h":"马来西亚"},{"c":"PEREIRA", "z":"佩雷拉", "g":"Colombia", "h":"哥伦比亚"},{"c":"PERTH", "z":"珀斯", "g":"Australia", "h":"澳大利亚"},{"c":"PERTH", "z":"珀斯", "g":"United Kingdom", "h":"英国"},{"c":"PERUGIA", "z":"佩鲁贾", "g":"Italy", "h":"意大利"},{"c":"PESARO", "z":"佩萨罗", "g":"Italy", "h":"意大利"},{"c":"PESCARA", "z":"佩斯卡拉", "g":"Italy", "h":"意大利"},{"c":"PESHAWAR", "z":"白沙瓦", "g":"Pakistan", "h":"巴基斯坦"},{"c":"PETERSBERG", "z":"彼得斯贝格", "g":"Germany", "h":"德国"},{"c":"PETERSBURG", "z":"彼得斯堡", "g":"United States", "h":"美国"},{"c":"PHARR", "z":"法尔", "g":"United States", "h":"美国"},{"c":"PHILADELPHIA", "z":"费城", "g":"United States", "h":"美国"},{"c":"PHILIPPI", "z":"菲利皮", "g":"United States", "h":"美国"},{"c":"PHILIPSBURG", "z":"菲利普斯堡", "g":"Canada", "h":"加拿大"},{"c":"PHILLIPSBURG", "z":"菲利普斯堡", "g":"United States", "h":"美国"},{"c":"PHNOM PENH", "z":"金边", "g":"Cambodia", "h":"柬埔寨"},{"c":"PHOENIX", "z":"费尼克斯", "g":"United States", "h":"美国"},{"c":"PHUOC LONG", "z":"福隆", "g":"Vietnam", "h":"越南"},{"c":"PIACENZA", "z":"皮亚琴察", "g":"Italy", "h":"意大利"},{"c":"PICO RIVERA", "z":"皮科里韦拉", "g":"United States", "h":"美国"},{"c":"PIMPRI", "z":"宾布里", "g":"India", "h":"印度"},{"c":"PIRAEUS", "z":"比雷艾夫斯", "g":"Greece", "h":"希腊"},{"c":"PISA", "z":"比萨", "g":"Italy", "h":"意大利"},{"c":"PISTOIA", "z":"皮斯托亚", "g":"Italy", "h":"意大利"},{"c":"PITHAMPUR", "z":"皮坦普尔", "g":"India", "h":"印度"},{"c":"PITTSBURG", "z":"匹兹堡", "g":"United States", "h":"美国"},{"c":"PITTSBURGH", "z":"匹慈堡", "g":"United States", "h":"美国"},{"c":"PLAINFIELD", "z":"普莱恩菲尔德", "g":"United States", "h":"美国"},{"c":"PLANO", "z":"普莱诺", "g":"United States", "h":"美国"},{"c":"PLOCE", "z":"普洛切", "g":"Montenegro", "h":"黑山共和国"},{"c":"PLYMOUTH", "z":"普列茅斯", "g":"Montserrat", "h":"蒙特塞拉特岛"},{"c":"PODGORICA", "z":"波德戈里察", "g":"Montenegro", "h":"黑山共和国"},{"c":"POINT LISAS", "z":"利萨斯角", "g":"Trinidad and Tobago", "h":"特立尼达和多巴哥"},{"c":"POINT LISAS", "z":"利萨斯角", "g":"Trinidad and Tobago", "h":"特立尼达和多巴哥"},{"c":"POINTE DES GALETS", "z":"加莱角", "g":"la Reunion", "h":"留尼汪岛"},{"c":"POINTE NOIRE", "z":"黑角", "g":"Congo", "h":"刚果"},{"c":"POINTE-A-PITRE", "z":"皮特尔角", "g":"Guadeloupe", "h":"瓜德罗普岛"},{"c":"POITIERS", "z":"普瓦捷", "g":"France", "h":"法国"},{"c":"PONCA CITY", "z":"彭卡市", "g":"United States", "h":"美国"},{"c":"PONTEVEDRA", "z":"蓬特韦德拉", "g":"Philippines", "h":"菲律宾"},{"c":"PONTEVEDRA", "z":"蓬特韦德拉", "g":"Spain", "h":"西班牙"},{"c":"PONTIAN", "z":"笨珍", "g":"Malaysia", "h":"马来西亚"},{"c":"PORDENONE", "z":"波代诺内", "g":"Italy", "h":"意大利"},{"c":"PORT ALMA", "z":"阿尔马港", "g":"Australia", "h":"澳大利亚"},{"c":"PORT AU PRINCE", "z":"太子港", "g":"Haiti", "h":"海地"},{"c":"PORT ELIZABETH", "z":"伊丽莎白港", "g":"South Africa", "h":"南非"},{"c":"PORT EVERGLADES", "z":"埃弗格雷斯港", "g":"United States", "h":"美国"},{"c":"PORT GENTIL", "z":"让蒂尔港", "g":"Gabon", "h":"加蓬"},{"c":"PORT HARCOURT", "z":"哈科特港", "g":"Nigeria", "h":"尼日利亚"},{"c":"PORT KELANG", "z":"巴生港", "g":"Malaysia", "h":"马来西亚"},{"c":"PORT LOUIS", "z":"路易港", "g":"Mauritius", "h":"毛里求斯"},{"c":"PORT MORESBY", "z":"莫尔兹比港", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"PORT OF SPAIN", "z":"西班牙港", "g":"Trinidad and Tobago", "h":"特立尼达和多巴哥"},{"c":"PORT OF SPAIN", "z":"西班牙港", "g":"Trinidad and Tobago", "h":"特立尼达和多巴哥"},{"c":"PORT QASIM", "z":"昆新港", "g":"Pakistan", "h":"巴基斯坦"},{"c":"PORT RASHID", "z":"拉希德港", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"PORT SAID", "z":"塞德港", "g":"Egypt", "h":"埃及"},{"c":"PORT SAID", "z":"塞德港", "g":"Egypt", "h":"埃及"},{"c":"PORT SIDE", "z":"塞得港", "g":"", "h":"埃及"},{"c":"PORT SUDAN", "z":"苏丹港", "g":"Sudan", "h":"苏丹"},{"c":"PORT SUEZ", "z":"苏伊士/阿达比亚", "g":"Egypt", "h":"埃及"},{"c":"PORT VILA", "z":"维拉港", "g":"Vanuatu", "h":"瓦努阿图"},{"c":"PORTBURY", "z":"波尔特布里", "g":"United Kingdom", "h":"英国"},{"c":"PORTLAND", "z":"波特兰", "g":"United States", "h":"美国"},{"c":"PORTO", "z":"波尔图", "g":"Portugal", "h":"葡萄牙"},{"c":"PORTO ALEGRE", "z":"阿雷格里港", "g":"Brazil", "h":"巴西"},{"c":"PORTSMOUTH", "z":"朴次茅斯", "g":"United Kingdom", "h":"英国"},{"c":"POTENZA", "z":"波坦察", "g":"Italy", "h":"意大利"},{"c":"POTOSI", "z":"波托西", "g":"Bolivia", "h":"玻利维亚"},{"c":"POTSDAM", "z":"波茨坦", "g":"Germany", "h":"德国"},{"c":"POZNAN", "z":"波兹南", "g":"Poland", "h":"波兰"},{"c":"POZZALLO", "z":"波扎洛", "g":"Italy", "h":"意大利"},{"c":"PRAGUE", "z":"布拉格", "g":"Czech", "h":"捷克"},{"c":"PRAIA", "z":"普拉亚", "g":"Cape VerdeRepública de Cabo Verde", "h":"佛得角"},{"c":"PRATO", "z":"普拉托", "g":"Italy", "h":"意大利"},{"c":"PRETORIA", "z":"比勒陀利亚", "g":"South Africa", "h":"南非"},{"c":"PRINCE RUPERT", "z":"鲁珀特王子港", "g":"Canada", "h":"加拿大"},{"c":"PROGRESO", "z":"普罗格雷索", "g":"Mexico", "h":"墨西哥"},{"c":"PROGRESSO", "z":"普罗格雷索", "g":"United States", "h":"美国"},{"c":"PROVIDENCE", "z":"普罗维登斯", "g":"United States", "h":"美国"},{"c":"PROVIDENCIALES", "z":"普罗维登西亚莱斯岛", "g":"The Turks and Caicos Islands", "h":"特克斯群岛和凯科斯群岛"},{"c":"PROVO", "z":"普罗沃", "g":"United States", "h":"美国"},{"c":"PUEBLA", "z":"普埃布拉", "g":"Mexico", "h":"墨西哥"},{"c":"PUERTO BARRIOS", "z":"巴里奥斯港", "g":"Guatemala", "h":"危地马拉"},{"c":"PUERTO CABELLO", "z":"卡贝略港", "g":"Venezuela", "h":"委内瑞拉"},{"c":"PUERTO CORTES", "z":"科斯特斯港", "g":"Honduras", "h":"洪都拉斯"},{"c":"PUERTO LIMON", "z":"利蒙港", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"PUERTO MONTT", "z":"蒙特港", "g":"Chile", "h":"智利"},{"c":"PUERTO PLATA", "z":"普拉塔港", "g":"Dominican Republic", "h":"多米尼克共和国"},{"c":"PUERTO QUETZAL", "z":"夸特扎尔港", "g":"Guatemala", "h":"危地马拉"},{"c":"PUERTO RICO", "z":"波多黎各", "g":"the West Indies", "h":"西印度群岛"},{"c":"PUNE", "z":"浦那", "g":"India", "h":"印度"},{"c":"PUNTA ARENAS", "z":"彭塔阿雷纳斯", "g":"Chile", "h":"智利"},{"c":"PUNTARENAS", "z":"彭塔雷纳斯", "g":"Costa Rica", "h":"哥斯达黎加"},{"c":"PUNTO FIJO", "z":"蓬托菲霍", "g":"Venezuela", "h":"委内瑞拉"},{"c":"PUSAN", "z":"釜山", "g":"South Korea", "h":"韩国"},{"c":"PYONGTAEK", "z":"平泽", "g":"South Korea", "h":"韩国"},{"c":"PYONGYANG", "z":"平壤", "g":"North Korea", "h":"朝鲜"},{"c":"QESHM", "z":"格什姆", "g":"Iran", "h":"伊朗"},{"c":"QESHM ISLAND", "z":"格什姆岛", "g":"Iran", "h":"伊朗"},{"c":"QINGDAO", "z":"青岛", "g":"China", "h":"中国"},{"c":"QUEENS", "z":"昆斯", "g":"Fuji Island", "h":"斐济群岛"},{"c":"QUEENSTOWN", "z":"昆斯敦", "g":"Australia", "h":"澳大利亚"},{"c":"QUEENSTOWN", "z":"昆斯敦", "g":"Canada", "h":"加拿大"},{"c":"QUEENSTOWN", "z":"女皇镇", "g":"Singpore", "h":"新加坡"},{"c":"QUEENSTOWN", "z":"昆斯敦", "g":"South Africa", "h":"南非"},{"c":"QUEENSTOWN", "z":"昆斯敦", "g":"United States", "h":"美国"},{"c":"QUELIMANE", "z":"克利马内", "g":"Mozambique", "h":"莫桑比克"},{"c":"QUERETARO", "z":"克雷塔罗", "g":"Mexico", "h":"墨西哥"},{"c":"QUI NHON", "z":"归仁", "g":"Vietnam", "h":"越南"},{"c":"QUITO", "z":"基多", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"RABAUL", "z":"腊包尔港", "g":"Papua New Guinea", "h":"巴布亚新几内亚"},{"c":"RADFORD", "z":"拉德福德", "g":"United States", "h":"美国"},{"c":"RAFSANJAN", "z":"拉夫桑贾", "g":"Iran", "h":"伊朗"},{"c":"RAGUSA", "z":"拉古萨", "g":"Italy", "h":"意大利"},{"c":"RALEIGH", "z":"罗利", "g":"United States", "h":"美国"},{"c":"RANCHO", "z":"兰乔", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"RANCHO CUCAMONGA", "z":"伦秋 库卡蒙加", "g":"United States", "h":"美国"},{"c":"RANDERS", "z":"兰讷斯", "g":"Denmark", "h":"丹麦"},{"c":"RANGOON", "z":"仰光", "g":"Burma", "h":"缅甸"},{"c":"RAROTONGA", "z":"拉罗汤加岛", "g":"Cook Islands", "h":"库克群岛"},{"c":"RAS AL KHAIMAH", "z":"哈伊马角", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"RAUMA", "z":"劳马", "g":"Finland", "h":"芬兰"},{"c":"RAVENNA", "z":"拉佛纳", "g":"Italy", "h":"意大利"},{"c":"RAWALPINDI", "z":"拉瓦尔品第", "g":"Pakistan", "h":"巴基斯坦"},{"c":"RECIFE", "z":"累西腓", "g":"Brazil", "h":"巴西"},{"c":"RECKLINGHAUSEN", "z":"雷克灵豪森", "g":"Germany", "h":"德国"},{"c":"REDWOOD CITY", "z":"雷德伍德城", "g":"United States", "h":"美国"},{"c":"REGEN", "z":"里根", "g":"United States", "h":"美国"},{"c":"REGENSBURG", "z":"雷根斯堡", "g":"Germany", "h":"德国"},{"c":"REGGIO CALABRIA", "z":"雷焦卡拉布里亚", "g":"Italy", "h":"意大利"},{"c":"REGGIO EMILIA", "z":"雷焦艾米利亚", "g":"Italy", "h":"意大利"},{"c":"REGINA", "z":"雷日纳", "g":"Brazil", "h":"巴西"},{"c":"REIMS", "z":"兰斯", "g":"France", "h":"法国"},{"c":"REMSCHEID", "z":"雷姆沙伊德", "g":"Germany", "h":"德国"},{"c":"RENNES", "z":"雷恩", "g":"France", "h":"法国"},{"c":"REYKJAVIK", "z":"雷克雅未克", "g":"Iceland", "h":"冰岛"},{"c":"REYNOSA", "z":"雷诺萨", "g":"Mexico", "h":"墨西哥"},{"c":"RICHARDS BAY", "z":"里查德湾", "g":"South Africa", "h":"南非"},{"c":"RICHMOND", "z":"里士满", "g":"United States", "h":"美国"},{"c":"RIDGETOWN", "z":"里奇敦", "g":"Canada", "h":"加拿大"},{"c":"RIETI", "z":"列蒂", "g":"Italy", "h":"意大利"},{"c":"RIGA", "z":"里加", "g":"Latvia", "h":"拉脱维亚"},{"c":"RIJEKA", "z":"里耶卡", "g":"Croatia", "h":"克罗地亚"},{"c":"RIMINI", "z":"里米尼", "g":"Italy", "h":"意大利"},{"c":"RINCON", "z":"林孔", "g":"Puerto Rico", "h":"波多黎各"},{"c":"RIO DE JANEIRO", "z":"里约热内卢", "g":"Brazil", "h":"巴西"},{"c":"RIO GRANDE", "z":"里奥格兰德", "g":"Brazil", "h":"巴西"},{"c":"RIO HAINA", "z":"里奥海纳", "g":"Dominican Republic", "h":"多米尼克共和国"},{"c":"RIVERA", "z":"里韦拉", "g":"Uruguay", "h":"乌拉圭"},{"c":"RIVERA", "z":"里韦拉", "g":"Argentina", "h":"阿根廷"},{"c":"RIVERS", "z":"里弗斯", "g":"Canada", "h":"加拿大"},{"c":"RIVERSIDE", "z":"里弗赛德", "g":"United States", "h":"美国"},{"c":"RIVERSIDE", "z":"里弗赛德", "g":"Canada", "h":"加拿大"},{"c":"RIYADH", "z":"利雅德", "g":"Saudi Arabia", "h":"沙特阿拉伯"},{"c":"ROAD BAY", "z":"鲁德湾", "g":"Anguilla", "h":"安圭拉"},{"c":"ROCHESTER", "z":"罗彻斯特", "g":"United States", "h":"美国"},{"c":"ROMA", "z":"罗马", "g":"Italy", "h":"意大利"},{"c":"ROME", "z":"罗马", "g":"Italy", "h":"意大利"},{"c":"ROME", "z":"罗马", "g":"United States", "h":"美国"},{"c":"ROSARIO", "z":"罗萨里奥", "g":"Argentina", "h":"阿根廷"},{"c":"ROSEAU", "z":"罗索", "g":"Dominican Republic", "h":"多米尼克共和国"},{"c":"ROSEAU", "z":"罗索", "g":"United States", "h":"美国"},{"c":"ROSTOCK", "z":"罗斯托克", "g":"Germany", "h":"德国"},{"c":"ROTORUA", "z":"罗托鲁阿", "g":"New Zealand", "h":"新西兰"},{"c":"ROTTERDAM", "z":"鹿特丹", "g":"Netherlands", "h":"荷兰"},{"c":"ROUEN", "z":"鲁昂", "g":"France", "h":"法国"},{"c":"SAARBRUCKEN", "z":"萨尔布吕肯", "g":"Germany", "h":"德国"},{"c":"SABADELL", "z":"萨瓦德尔", "g":"Spain", "h":"西班牙"},{"c":"SACRAMENTO", "z":"萨克拉门托", "g":"United States", "h":"美国"},{"c":"SAINT LOUIS", "z":"圣路易斯", "g":"United States", "h":"美国"},{"c":"SAINT PAUL", "z":"圣保罗", "g":"United States", "h":"美国"},{"c":"SAIPAN", "z":"塞班岛", "g":"Mariana Islands", "h":"马里亚纳群岛"},{"c":"SAKAI", "z":"界", "g":"Japan", "h":"日本"},{"c":"SAKAIMINATO", "z":"境港", "g":"Japan", "h":"日本"},{"c":"SAKATA", "z":"酒田", "g":"Japan", "h":"日本"},{"c":"SALALAH", "z":"塞拉莱", "g":"Oman", "h":"阿曼"},{"c":"SALAMANCA", "z":"塞拉曼卡", "g":"Spain", "h":"西班牙"},{"c":"SALAVERRY", "z":"萨拉韦里", "g":"Peru", "h":"秘鲁"},{"c":"SALEM", "z":"塞勒姆", "g":"United States", "h":"美国"},{"c":"SALERNO", "z":"萨莱诺", "g":"Italy", "h":"意大利"},{"c":"SALINA", "z":"萨莱纳", "g":"United States", "h":"美国"},{"c":"SALINA CRUZ", "z":"萨利纳克鲁斯", "g":"Mexico", "h":"墨西哥"},{"c":"SALINAS", "z":"萨利纳斯", "g":"United States", "h":"美国"},{"c":"SALINAS", "z":"萨利纳斯", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"SALINAS", "z":"萨利纳斯", "g":"Brazil", "h":"巴西"},{"c":"SALLA", "z":"萨拉", "g":"Austria", "h":"奥地利"},{"c":"SALLA", "z":"萨拉", "g":"Finland", "h":"芬兰"},{"c":"SALT LAKE CITY", "z":"盐湖城", "g":"United States", "h":"美国"},{"c":"SALTILLO", "z":"萨尔蒂约", "g":"Mexico", "h":"墨西哥"},{"c":"SALVADOR", "z":"萨尔瓦多", "g":"Brazil", "h":"巴西"},{"c":"SALVADOR", "z":"萨尔瓦多", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"SALZBURG", "z":"萨尔茨堡", "g":"Austria", "h":"奥地利"},{"c":"SALZGITTER", "z":"萨尔茨吉特", "g":"Germany", "h":"德国"},{"c":"SAMARA", "z":"萨马拉", "g":"Russia", "h":"俄罗斯"},{"c":"SAMARINDA", "z":"三马林达", "g":"Indonesia", "h":"印度尼西亚"},{"c":"SAMPIT", "z":"桑皮特", "g":"Indonesia", "h":"印度尼西亚"},{"c":"SAN ANTONIO", "z":"圣安东尼奥", "g":"Chile", "h":"智利"},{"c":"SAN DIEGO", "z":"圣迭戈", "g":"United States", "h":"美国"},{"c":"SAN FRANCISCO", "z":"三藩市", "g":"United States", "h":"美国"},{"c":"SAN JOAQUIN", "z":"圣华金", "g":"United States", "h":"美国"},{"c":"SAN JOSE", "z":"圣胡赛", "g":"Guatemala", "h":"危地马拉"},{"c":"SAN JUAN", "z":"圣胡安", "g":"Puerto Rico", "h":"波多黎各"},{"c":"SAN JUAN DEL PUERTO", "z":"圣胡安德尔波多", "g":"Spain", "h":"西班牙"},{"c":"SAN LEANDRO", "z":"圣莱安德罗", "g":"United States", "h":"美国"},{"c":"SAN LORENZO", "z":"圣洛伦索", "g":"Honduras", "h":"洪都拉斯"},{"c":"SAN LUIS", "z":"圣路易斯", "g":"United States", "h":"美国"},{"c":"SAN LUIS POTOSI", "z":"圣路易斯波托西", "g":"Mexico", "h":"墨西哥"},{"c":"SAN PEDRO", "z":"圣佩德罗", "g":"Ivory Coast", "h":"科特迪瓦"},{"c":"SAN PEDRO SULA", "z":"圣佩德罗苏拉", "g":"Honduras", "h":"洪都拉斯"},{"c":"SAN SALVADOR", "z":"圣萨尔瓦多", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"SAN SEBASTIAN", "z":"圣塞瓦斯蒂安", "g":"Spain", "h":"西班牙"},{"c":"SAN VICENTE", "z":"圣维森特", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"SANDE", "z":"桑德", "g":"Germany", "h":"德国"},{"c":"SANDE", "z":"桑讷", "g":"Norway", "h":"挪威"},{"c":"SANDNES", "z":"桑内斯", "g":"Norway", "h":"挪威"},{"c":"SANTA ANA", "z":"圣安娜", "g":"United States", "h":"美国"},{"c":"SANTA ANA", "z":"圣安娜", "g":"El Salvador", "h":"萨尔瓦多"},{"c":"SANTA CRUZ", "z":"圣克鲁斯", "g":"CanaryIslands", "h":"加纳利群岛"},{"c":"SANTA CRUZ DE TENERIFE", "z":"圣克鲁斯-德特内里费", "g":"Spain", "h":"西班牙"},{"c":"SANTA FE", "z":"圣菲", "g":"United States", "h":"美国"},{"c":"SANTA MARTA", "z":"圣马尔塔", "g":"Colombia", "h":"哥伦比亚"},{"c":"SANTANDER", "z":"桑坦德", "g":"Spain", "h":"西班牙"},{"c":"SANTIAGO", "z":"圣地亚哥", "g":"Cape VerdeRepública de Cabo Verde", "h":"佛得角"},{"c":"SANTIAGO DE CUBA", "z":"圣地亚哥", "g":"Cuba", "h":"古巴"},{"c":"SANTO", "z":"圣吐", "g":"Vanuatu", "h":"瓦努阿图"},{"c":"SANTO DOMINGO", "z":"圣多明戈", "g":"Santo Domingo", "h":"多米尼加共和国"},{"c":"CAUCEDO", "z":"考赛多港", "g":"Dominican Republic", "h":"多米尼加共和国"},{"c":"SANTO TOMAS DE CASTILLA", "z":"圣托马斯德卡斯蒂利亚", "g":"Guatemala", "h":"危地马拉"},{"c":"SANTOS", "z":"桑托斯", "g":"Brazil", "h":"巴西"},{"c":"SAO FRANCISCO", "z":"圣弗朗西斯科", "g":"Brazil", "h":"巴西"},{"c":"SAO PAULO", "z":"圣保罗", "g":"Brazil", "h":"巴西"},{"c":"SARAJEVO", "z":"萨拉热窝", "g":"Bosnia and Herzegovina", "h":"波斯尼亚和黑塞哥维纳共和国"},{"c":"SARAKHS", "z":"萨拉赫斯", "g":"Iran", "h":"伊朗"},{"c":"SARPSBORG", "z":"萨尔普斯堡", "g":"Norway", "h":"挪威"},{"c":"SASKATOON", "z":"萨斯卡通", "g":"Canada", "h":"加拿大"},{"c":"SASKATOON, SK", "z":"萨斯卡通", "g":"Canada", "h":"加拿大"},{"c":"SASSARI", "z":"萨萨里", "g":"Italy", "h":"意大利"},{"c":"SAVANNA", "z":"萨瓦纳", "g":"United States", "h":"美国"},{"c":"SAVANNAH", "z":"萨凡纳", "g":"United States", "h":"美国"},{"c":"SAVEH", "z":"萨维赫", "g":"Iran", "h":"伊朗"},{"c":"SAVONA", "z":"萨沃纳", "g":"Italy", "h":"意大利"},{"c":"SCHWERIN", "z":"什未林", "g":"Germany", "h":"德国"},{"c":"SEATTLE", "z":"西雅图", "g":"United States", "h":"美国"},{"c":"SEBASTIAN", "z":"锡巴斯琴", "g":"United States", "h":"美国"},{"c":"SEGOVIA", "z":"塞哥维亚", "g":"Spain", "h":"西班牙"},{"c":"SEMARANG", "z":"三宝垄", "g":"Indonesia", "h":"印度尼西亚"},{"c":"SENBOKU", "z":"森波库", "g":"Japan", "h":"日本"},{"c":"SEOUL", "z":"首尔", "g":"South Korea", "h":"韩国"},{"c":"SEVILLA", "z":"塞维利亚", "g":"Spain", "h":"西班牙"},{"c":"SHANNON", "z":"香农", "g":"Ireland", "h":"爱尔兰"},{"c":"SHARI", "z":"沙里", "g":"Central Africa", "h":"中非"},{"c":"SHARJAH", "z":"沙迦", "g":"United Arab Emirates", "h":"阿联酋"},{"c":"SHEFFIELD", "z":"设菲尔德", "g":"United Kingdom", "h":"英国"},{"c":"SHEFFIELD", "z":"设菲尔德", "g":"United States", "h":"美国"},{"c":"SHENZHEN", "z":"深圳", "g":"China", "h":"中国"},{"c":"SHIBUSHI", "z":"志不志", "g":"Japan", "h":"日本"},{"c":"SHIDO", "z":"志度", "g":"Japan", "h":"日本"},{"c":"SHIMIZU", "z":"清水", "g":"Japan", "h":"日本"},{"c":"SHIMONOSEKI", "z":"下关", "g":"Japan", "h":"日本"},{"c":"SHIRAZ", "z":"设拉子", "g":"Iran", "h":"伊朗"},{"c":"SHREVEPORT", "z":"什里夫波特", "g":"United States", "h":"美国"},{"c":"SHUAIBA", "z":"舒艾拜", "g":"Kuwait", "h":"科威特"},{"c":"SHUNDE", "z":"顺德", "g":"China", "h":"中国"},{"c":"SHUWAIKH", "z":"舒韦赫", "g":"Kuwait", "h":"科威特"},{"c":"SIALKOT", "z":"锡亚尔科特", "g":"Pakistan", "h":"巴基斯坦"},{"c":"SIBU", "z":"诗巫", "g":"Malaysia", "h":"马来西亚"},{"c":"SIENA", "z":"锡耶纳", "g":"Italy", "h":"意大利"},{"c":"SINES", "z":"锡尼什", "g":"Portugal", "h":"葡萄牙"},{"c":"SINGAPORE", "z":"新加坡", "g":"Singpore", "h":"新加坡"},{"c":"SIRACUSA", "z":"锡拉丘兹", "g":"Italy", "h":"意大利"},{"c":"SIRJAN", "z":"锡尓詹", "g":"Iran", "h":"伊朗"},{"c":"SKARA", "z":"斯卡拉", "g":"Sweden", "h":"瑞典"},{"c":"SKARAMANGA", "z":"斯卡拉曼格港", "g":"Greece", "h":"希腊"},{"c":"SKIKDA", "z":"斯克基达", "g":"Albania", "h":"阿尔及利亚"},{"c":"SKOPJE", "z":"斯科普里", "g":"Macedonia", "h":"马其顿共和国"},{"c":"SMARA", "z":"斯马拉", "g":"Western Sahara", "h":"西撒哈拉"},{"c":"SOEDERTAELJE", "z":"阿尔弗斯吉", "g":"Sweden", "h":"瑞典"},{"c":"SOFIA", "z":"索菲亚", "g":"Bulgaria", "h":"保加利亚"},{"c":"SOHAR", "z":"索哈", "g":"OMAN", "h":"阿曼"},{"c":"SOLIN", "z":"索林", "g":"Croatia", "h":"克罗地亚"},{"c":"SOLINGEN", "z":"索林根", "g":"Germany", "h":"德国"},{"c":"SOLOMON", "z":"索罗门", "g":"United States", "h":"美国"},{"c":"SOLWEZI", "z":"索尔韦齐", "g":"Zambia", "h":"赞比亚"},{"c":"SONDRIO", "z":"松德里奥", "g":"Italy", "h":"意大利"},{"c":"SOPHIA", "z":"索菲亚", "g":"Bulgaria", "h":"保加利亚"},{"c":"SORIA", "z":"索里亚", "g":"Spain", "h":"西班牙"},{"c":"SOUSSE", "z":"苏塞", "g":"Tunis", "h":"突尼斯"},{"c":"SOUTH BELOIT", "z":"南比洛伊特", "g":"United States", "h":"美国"},{"c":"SOUTH SHIELDS", "z":"南西尔兹", "g":"United Kingdom", "h":"英国"},{"c":"SOUTHAM", "z":"索瑟姆", "g":"Canada", "h":"加拿大"},{"c":"SOUTHAMPTON", "z":"南安普敦", "g":"United Kingdom", "h":"英国"},{"c":"SOUTHPORT", "z":"绍斯波特", "g":"United Kingdom", "h":"英国"},{"c":"SOYO", "z":"索尤", "g":"The Republic of Angola", "h":"安哥拉"},{"c":"SPLIT", "z":"斯普利特", "g":"Croatia", "h":"克罗地亚"},{"c":"SPRING HILL", "z":"斯普林希尔", "g":"United States", "h":"美国"},{"c":"SPRINGFIELD", "z":"斯普林菲尔德", "g":"United States", "h":"美国"},{"c":"SPRINGS", "z":"斯普林斯", "g":"South Africa", "h":"南非"},{"c":"ST ETIENNE", "z":"圣艾蒂安", "g":"France", "h":"法国"},{"c":"ST JOHN", "z":"圣约翰", "g":"Canada", "h":"加拿大"},{"c":"ST LOUIS", "z":"圣路易斯", "g":"United States", "h":"美国"},{"c":"ST MAARTEN", "z":"圣马丁", "g":"Antilles", "h":"安得列斯群岛"},{"c":"ST PAUL", "z":"圣保罗", "g":"United States", "h":"美国"},{"c":"ST PETER", "z":"圣彼得港", "g":"United Kingdom", "h":"英国"},{"c":"ST PETERSBURG", "z":"圣彼得堡", "g":"Russia", "h":"俄罗斯"},{"c":"ST THOMAS", "z":"圣托马斯", "g":"Virgin Islands", "h":"维尔京群岛"},{"c":"STANS", "z":"施坦斯", "g":"Austria", "h":"奥地利"},{"c":"STAVANGER", "z":"斯塔万格", "g":"Norway", "h":"挪威"},{"c":"STIENS", "z":"斯廷斯", "g":"Netherlands", "h":"荷兰"},{"c":"STOCKHOLM", "z":"斯德哥尔摩", "g":"Sweden", "h":"瑞典"},{"c":"STOCKPORT", "z":"斯托克波特", "g":"United Kingdom", "h":"英国"},{"c":"STOCKPORT", "z":"斯托克波特", "g":"United States", "h":"美国"},{"c":"STRASBOURG", "z":"斯特拉斯堡", "g":"France", "h":"法国"},{"c":"STUTTGART", "z":"斯图加特", "g":"Germany", "h":"德国"},{"c":"SUAPE", "z":"苏瓦佩", "g":"Brazil", "h":"巴西"},{"c":"SUBIC BAY", "z":"苏比克湾", "g":"Philippines", "h":"菲律宾"},{"c":"SUEZ", "z":"苏伊士", "g":"Egypt", "h":"埃及"},{"c":"SUEZ", "z":"苏伊士", "g":"Egypt", "h":"埃及"},{"c":"SUNDERLAND", "z":"森德兰", "g":"United Kingdom", "h":"英国"},{"c":"SURABAYA", "z":"泗水", "g":"Indonesia", "h":"印度尼西亚"},{"c":"SURAT", "z":"苏拉特", "g":"India", "h":"印度"},{"c":"SUVA", "z":"萨瓦", "g":"Fuji Island", "h":"斐济群岛"},{"c":"SUZHOU", "z":"苏州", "g":"China", "h":"中国"},{"c":"SYDNEY", "z":"悉尼", "g":"Australia", "h":"澳大利亚"},{"c":"SYRACUSE", "z":"锡拉丘兹", "g":"United States", "h":"美国"},{"c":"SZCZECIN", "z":"什切青", "g":"Poland", "h":"波兰"},{"c":"TABRIZ", "z":"大不里士", "g":"Iran", "h":"伊朗"},{"c":"TACOMA", "z":"塔科马", "g":"United States", "h":"美国"},{"c":"TAICHUNG", "z":"太昌", "g":"China", "h":"中国"},{"c":"TAIPEI", "z":"台北", "g":"China", "h":"中国"},{"c":"TAKAMATSU", "z":"高松", "g":"Japan", "h":"日本"},{"c":"TAKORADI", "z":"塔利拉迪", "g":"Ghana", "h":"加纳"},{"c":"TALCA", "z":"塔尔卡", "g":"Chile", "h":"智利"},{"c":"TALCAHUANO", "z":"塔尔卡瓦诺", "g":"Chile", "h":"智利"},{"c":"TALLINN", "z":"塔林", "g":"Estonia", "h":"爱沙尼亚"},{"c":"TAMATAVE", "z":"塔马塔夫", "g":"Madagascar", "h":"马达加斯加"},{"c":"TAMPA", "z":"坦帕", "g":"United States", "h":"美国"},{"c":"TAMPICO", "z":"坦皮科", "g":"Mexico", "h":"墨西哥"},{"c":"TANANGER", "z":"塔纳格尔", "g":"Norway", "h":"挪威"},{"c":"TANGA", "z":"坦加", "g":"Tznzania", "h":"坦桑尼亚"},{"c":"TANGER", "z":"丹吉尔", "g":"Morocco", "h":"摩洛哥"},{"c":"TAOYUAN", "z":"桃園市", "g":"Taiwan，China", "h":"中国台湾"},{"c":"TARAKAN", "z":"打拉根", "g":"Indonesia", "h":"印度尼西亚"},{"c":"TARANTO", "z":"塔兰托", "g":"Italy", "h":"意大利"},{"c":"TARAWA", "z":"塔拉瓦", "g":"Kiribati", "h":"基里巴斯"},{"c":"TARRAGONA", "z":"塔拉戈纳", "g":"Spain", "h":"西班牙"},{"c":"TARTOUS", "z":"他图斯", "g":"Syria", "h":"叙利亚"},{"c":"TARTU", "z":"塔尔图", "g":"Estonia", "h":"爱沙尼亚"},{"c":"TASHKENT", "z":"塔什干", "g":"Uzbestan", "h":"乌兹别克斯坦"},{"c":"TAURANGA", "z":"陶朗阿", "g":"New Zealand", "h":"新西兰"},{"c":"TBILISI", "z":"第比利斯", "g":"Georga", "h":"格鲁吉亚"},{"c":"TEESPORT", "z":"提兹港", "g":"United Kingdom", "h":"英国"},{"c":"TEGUCIGALPA", "z":"特古西加尔巴", "g":"Honduras", "h":"洪都拉斯"},{"c":"TEHRAN", "z":"德黑兰", "g":"Iran", "h":"伊朗"},{"c":"TEL AVIV", "z":"特拉维夫", "g":"Israel", "h":"以色列"},{"c":"TEMA", "z":"特马", "g":"Ghana", "h":"加纳"},{"c":"TENERIFE", "z":"特内里费岛", "g":"Spain", "h":"西班牙"},{"c":"TERAMO", "z":"泰拉莫", "g":"Italy", "h":"意大利"},{"c":"TERNI", "z":"特尔尼", "g":"Italy", "h":"意大利"},{"c":"TERUEL", "z":"特鲁埃尔", "g":"Spain", "h":"西班牙"},{"c":"THAME", "z":"泰姆", "g":"United Kingdom", "h":"英国"},{"c":"THAMES", "z":"泰晤士", "g":"United Kingdom", "h":"英国"},{"c":"THAMESPORT", "z":"泰晤士港", "g":"United Kingdom", "h":"英国"},{"c":"THE VALLEY", "z":"谷岛", "g":"Anguilla", "h":"安圭拉"},{"c":"THESSALONIKI", "z":"塞萨洛尼基", "g":"Greece", "h":"希腊"},{"c":"TIANJIN", "z":"天津", "g":"China", "h":"中国"},{"c":"TIJUANA", "z":"蒂华纳", "g":"Mexico", "h":"墨西哥"},{"c":"TILBURY", "z":"蒂尔伯里", "g":"United Kingdom", "h":"英国"},{"c":"TILLE", "z":"蒂耶河", "g":"France", "h":"法国"},{"c":"TIMARU", "z":"蒂马鲁", "g":"New Zealand", "h":"新西兰"},{"c":"TIMISOARA", "z":"蒂米什瓦拉", "g":"Romania", "h":"罗马尼亚"},{"c":"TIRANA", "z":"地拉那", "g":"Albania", "h":"阿尔巴尼亚"},{"c":"TLAQUEPAQUE", "z":"特拉克帕克", "g":"Mexico", "h":"墨西哥"},{"c":"TLAXCALA", "z":"特拉斯卡拉", "g":"Mexico", "h":"墨西哥"},{"c":"TOAMASINA", "z":"图阿以西纳", "g":"Madagascar", "h":"马达加斯加"},{"c":"TOBRUK", "z":"图卜鲁格", "g":"Libya", "h":"利比亚"},{"c":"TOKUSHIMA", "z":"德岛", "g":"Japan", "h":"日本"},{"c":"TOKUYAMA", "z":"德山", "g":"Japan", "h":"日本"},{"c":"TOKYO", "z":"东京", "g":"Japan", "h":"日本"},{"c":"TOLEDO", "z":"托莱多", "g":"United States", "h":"美国"},{"c":"TOLEDO", "z":"托莱多", "g":"Spain", "h":"西班牙"},{"c":"TOLUCA", "z":"托卢卡", "g":"Mexico", "h":"墨西哥"},{"c":"TOMAKOMAI", "z":"占小牧", "g":"Japan", "h":"日本"},{"c":"TORONTO", "z":"多伦多", "g":"Canada", "h":"加拿大"},{"c":"TORTOLA", "z":"托尔托拉岛", "g":"Virgin Islands", "h":"维尔京群岛"},{"c":"TOULOUSE", "z":"图卢兹", "g":"France", "h":"法国"},{"c":"TOWNSVILLE", "z":"汤斯维尔", "g":"Australia", "h":"澳大利亚"},{"c":"TOYAMA", "z":"富山", "g":"Japan", "h":"日本"},{"c":"TOYAMASHINKO", "z":"伏木富山新港", "g":"Japan", "h":"日本"},{"c":"TOYOHASHI", "z":"丰桥", "g":"Japan", "h":"日本"},{"c":"TRABZON", "z":"特拉布宗", "g":"Turkey", "h":"土耳其"},{"c":"TRAPANI", "z":"特拉帕尼", "g":"Italy", "h":"意大利"},{"c":"TRENTO", "z":"特伦托", "g":"Italy", "h":"意大利"},{"c":"TREVISO", "z":"特雷维索", "g":"Italy", "h":"意大利"},{"c":"TRIESTE", "z":"德里亚斯特", "g":"Italy", "h":"意大利"},{"c":"TRINIDAD", "z":"特立尼达", "g":"Cuba", "h":"古巴"},{"c":"TRINIDAD", "z":"特立尼达", "g":"Bolivia", "h":"玻利维亚"},{"c":"TRINIDAD", "z":"特立尼达", "g":"Paraguay", "h":"巴拉圭"},{"c":"TRINIDAD", "z":"特立尼达", "g":"Philippines", "h":"菲律宾"},{"c":"TRINIDAD", "z":"特立尼达", "g":"United States", "h":"美国"},{"c":"TRINIDAD", "z":"特立尼达", "g":"Uruguay", "h":"乌拉圭"},{"c":"TRIPOLI", "z":"的黎波里", "g":"Libya", "h":"利比亚"},{"c":"TRONDHEIM", "z":"特隆赫姆", "g":"Norway", "h":"挪威"},{"c":"TSUDA", "z":"津田", "g":"Japan", "h":"日本"},{"c":"TSURUGA", "z":"敦贺", "g":"Japan", "h":"日本"},{"c":"TUCSON", "z":"图森", "g":"United States", "h":"美国"},{"c":"TUGLAKABAD", "z":"腾格拉卡巴德", "g":"India", "h":"印度"},{"c":"TULSA", "z":"塔尔萨", "g":"United States", "h":"美国"},{"c":"TUMACO", "z":"图马科", "g":"Colombia", "h":"哥伦比亚"},{"c":"TUNIS", "z":"突尼斯", "g":"Tunis", "h":"突尼斯"},{"c":"TUNISI", "z":"突尼斯", "g":"Tunisia", "h":"突尼西亚"},{"c":"TURIN", "z":"都灵", "g":"Italy", "h":"意大利"},{"c":"TURKMANBASHI", "z":"土库曼贝斯", "g":"Turkmenistan", "h":"土库曼斯坦"},{"c":"TUTICORIN", "z":"杜蒂戈林", "g":"India", "h":"印度"},{"c":"UDINE", "z":"乌迪内", "g":"Italy", "h":"意大利"},{"c":"UJUNG PADANG", "z":"乌戎巴东", "g":"Indonesia", "h":"印度尼西亚"},{"c":"ULSAN", "z":"蔚山", "g":"South Korea", "h":"韩国"},{"c":"UMM QASR", "z":"乌姆卡斯尔", "g":"Iraq", "h":"伊拉克"},{"c":"UNION ISLAND", "z":"尤宁群岛", "g":"Grenadines", "h":"格林纳丁斯群岛"},{"c":"USHUAIA", "z":"乌斯怀亚", "g":"Argentina", "h":"阿根廷"},{"c":"USSEL", "z":"于塞勒", "g":"France", "h":"法国"},{"c":"VALENCA", "z":"瓦伦萨", "g":"Italy", "h":"意大利"},{"c":"VALENCIA", "z":"巴伦西亚", "g":"Spain", "h":"西班牙"},{"c":"VALLADOLID", "z":"巴利亚多利德", "g":"Spain", "h":"西班牙"},{"c":"VALLET", "z":"瓦莱", "g":"France", "h":"法国"},{"c":"VALLEY", "z":"瓦利", "g":"United Kingdom", "h":"英国"},{"c":"VALPARAISO", "z":"瓦尔帕莱索", "g":"Chile", "h":"智利"},{"c":"VANCOUVER", "z":"温哥华", "g":"Canada", "h":"加拿大"},{"c":"VARESE", "z":"瓦雷泽", "g":"Italy", "h":"意大利"},{"c":"VARNA", "z":"瓦尔纳", "g":"Bulgaria", "h":"保加利亚"},{"c":"VASTERAS", "z":"维斯特罗斯", "g":"Sweden", "h":"瑞典"},{"c":"VELEN", "z":"费伦", "g":"Germany", "h":"德国"},{"c":"VENICE", "z":"威尼斯", "g":"Italy", "h":"意大利"},{"c":"VERACRUZ", "z":"韦腊克鲁斯", "g":"Mexico", "h":"墨西哥"},{"c":"VERCELLI", "z":"韦尔切利", "g":"Italy", "h":"意大利"},{"c":"VERONA", "z":"维罗纳", "g":"Italy", "h":"意大利"},{"c":"VICENZA", "z":"维琴察", "g":"Italy", "h":"意大利"},{"c":"VICTOR", "z":"维克托", "g":"United States", "h":"美国"},{"c":"VICTORIA", "z":"维多利亚", "g":"Canada", "h":"加拿大"},{"c":"VIENNA", "z":"维也纳", "g":"Austria", "h":"奥地利"},{"c":"VIENNA", "z":"维也纳", "g":"United States", "h":"美国"},{"c":"VIEUX FORT", "z":"维约堡", "g":"Sant Lucia", "h":"圣卢西亚"},{"c":"VIGO", "z":"维哥", "g":"Spain", "h":"西班牙"},{"c":"VILLAHERMOSA", "z":"比亚埃尔莫萨", "g":"Mexico", "h":"墨西哥"},{"c":"VILLANUEVA", "z":"维拉努埃瓦", "g":"Philippines", "h":"菲律宾"},{"c":"VILNIUS", "z":"维尔纽斯", "g":"Lithuania", "h":"立陶宛"},{"c":"VIRGIN GORDA", "z":"维尔京戈尔达岛", "g":"United Kingdom", "h":"英国"},{"c":"VISAKHAPATNAM", "z":"维沙卡帕特南", "g":"India", "h":"印度"},{"c":"VITERBO", "z":"维泰博", "g":"Italy", "h":"意大利"},{"c":"VITORIA", "z":"维多利亚", "g":"Spain", "h":"西班牙"},{"c":"VLADIVOSTOK", "z":"符拉迪沃斯托克", "g":"Russia", "h":"俄罗斯"},{"c":"VOHEMAR", "z":"渥海马尔", "g":"MADAGASCAR", "h":"马达加斯加"},{"c":"VOLOS", "z":"沃洛", "g":"Indonesia", "h":"印度尼西亚"},{"c":"VOSTOCHNIY, PORT", "z":"东方港", "g":"Russia", "h":"俄罗斯"},{"c":"WAKAYAMA", "z":"和歌山", "g":"Japan", "h":"日本"},{"c":"WALLIS", "z":"沃利斯", "g":"United States", "h":"美国"},{"c":"WALVIS BAY", "z":"鲸湾港", "g":"Namibia", "h":"纳米比亚"},{"c":"WANGANUI", "z":"旺加努伊", "g":"New Zealand", "h":"新西兰"},{"c":"WARSAW", "z":"华沙", "g":"Poland", "h":"波兰"},{"c":"WASHINGTON", "z":"华盛顿", "g":"United States", "h":"美国"},{"c":"WATERFORD", "z":"沃特福德", "g":"Ireland", "h":"爱尔兰"},{"c":"WELLINGTON", "z":"惠灵顿", "g":"New Zealand", "h":"新西兰"},{"c":"WENZHOU", "z":"温州", "g":"China", "h":"中国"},{"c":"WESTPORT", "z":"韦斯特皮特", "g":"New Zealand", "h":"新西兰"},{"c":"WESTWEGO", "z":"韦斯特维戈", "g":"United States", "h":"美国"},{"c":"WHANGAREI", "z":"旺阿雷", "g":"New Zealand", "h":"新西兰"},{"c":"WICHITA", "z":"威奇托", "g":"United States", "h":"美国"},{"c":"WICKLOW", "z":"威克洛", "g":"Ireland", "h":"爱尔兰"},{"c":"WIESBADEN", "z":"威斯巴登", "g":"Germany", "h":"德国"},{"c":"WILLEMSTAD", "z":"威廉斯塔德", "g":"Antilles", "h":"安的列斯群岛"},{"c":"WILMINGTON", "z":"威尔明顿", "g":"United States", "h":"美国"},{"c":"WINDHOEK", "z":"温德和克", "g":"Namibia", "h":"纳米比亚"},{"c":"WINDSOR", "z":"温莎", "g":"United Kingdom", "h":"英国"},{"c":"WINDSOR", "z":"温莎", "g":"Canada", "h":"加拿大"},{"c":"WINNIPEG", "z":"温尼伯", "g":"Canada", "h":"加拿大"},{"c":"WINSLOW", "z":"温斯洛", "g":"United Kingdom", "h":"英国"},{"c":"WINSTON", "z":"温斯顿", "g":"United Kingdom", "h":"英国"},{"c":"WOLFSBURG", "z":"沃尔夫斯堡", "g":"Germany", "h":"德国"},{"c":"WORCESTER", "z":"伍斯特", "g":"United Kingdom", "h":"英国"},{"c":"WORCESTER", "z":"伍斯特", "g":"United States", "h":"美国"},{"c":"WORTH", "z":"沃思", "g":"United States", "h":"美国"},{"c":"WROCLAW", "z":"弗罗茨瓦夫", "g":"Poland", "h":"波兰"},{"c":"WUPPERTAL", "z":"伍珀塔尔", "g":"Germany", "h":"德国"},{"c":"WURZBURG", "z":"维尔茨堡", "g":"Germany", "h":"德国"},{"c":"XIAMEN", "z":"厦门", "g":"China", "h":"中国"},{"c":"XINGANG", "z":"新港", "g":"China", "h":"中国"},{"c":"YATSUSHIRO", "z":"八代", "g":"Japan", "h":"日本"},{"c":"YAZD", "z":"亚兹德", "g":"Iran", "h":"伊朗"},{"c":"YEREVAN", "z":"埃里温", "g":"The Republic of Armenia", "h":"亚美尼亚"},{"c":"YOKKAICHI", "z":"四日", "g":"Japan", "h":"日本"},{"c":"YOKOHAMA", "z":"横滨", "g":"Japan", "h":"日本"},{"c":"ZACATECAS", "z":"萨卡特卡斯", "g":"Mexico", "h":"墨西哥"},{"c":"ZAGREB", "z":"萨格勒布", "g":"Croatia", "h":"克罗地亚"},{"c":"ZAMBOANGA", "z":"三宝颜", "g":"Philippines", "h":"菲律宾"},{"c":"ZAMORA", "z":"萨莫拉", "g":"Ecuador", "h":"厄瓜多尔"},{"c":"ZAMORA", "z":"萨莫拉", "g":"Spain", "h":"西班牙"},{"c":"ZAMORA", "z":"萨莫拉", "g":"United States", "h":"美国"},{"c":"ZANZIBAR", "z":"桑给巴尔", "g":"Tznzania", "h":"坦桑尼亚"},{"c":"ZAPOPAN", "z":"萨波潘", "g":"Mexico", "h":"墨西哥"},{"c":"ZARAGOZA", "z":"萨拉戈萨", "g":"Spain", "h":"西班牙"},{"c":"ZARATE", "z":"萨拉特", "g":"Argentina", "h":"阿根廷"},{"c":"ZEEBRUGGE", "z":"泽布吕赫", "g":"Belgium", "h":"比利时"},{"c":"ZHONGSHAN", "z":"中山", "g":"China", "h":"中国"},{"c":"ZHUHAI", "z":"珠海", "g":"China", "h":"中国"},{"c":"ZURICH", "z":"苏黎世", "g":"Stzerland", "h":"瑞士"},{"c":"ZWICKAU", "z":"茨维考", "g":"Germany", "h":"德国"},{}]';

var sb = '[{"c":"ANL", "z":"澳航"},{"c":"APL", "z":"美总"},{"c":"BEN", "z":"边行"},{"c":"BTL", "z":"孟加拉虎航运"},{"c":"CCL", "z":"中通"},{"c":"CCNI", "z":"智利航运"},{"c":"CHS", "z":"京汉"},{"c":"CJF", "z":"中日轮渡"},{"c":"CJS", "z":"长江轮船"},{"c":"CK", "z":"天敬"},{"c":"CLS", "z":"炫海"},{"c":"CMA", "z":"达飞"},{"c":"CNC", "z":"正利"},{"c":"COSCO", "z":"中远"},{"c":"CQMS", "z":"重庆海运"},{"c":"CSAV", "z":"南美轮船"},{"c":"CSCL", "z":"中海"},{"c":"CULINES", "z":"洋浦中诚"},{"c":"DAIN", "z":"大仁轮渡"},{"c":"DBR", "z":"环渤海集运"},{"c":"DEL", "z":"达贸"},{"c":"DJS", "z":"东进商船"},{"c":"DNS", "z":"东南亚"},{"c":"DONGHANG", "z":"香港东航"},{"c":"DOOW", "z":"斗宇"},{"c":"DRAGON", "z":"港龙"},{"c":"DYS", "z":"东映"},{"c":"DYY", "z":"东宇"},{"c":"EAS", "z":"达通"},{"c":"EMC", "z":"长荣"},{"c":"EMI", "z":"阿联酋"},{"c":"EP", "z":"先锋海运"},{"c":"FESCO", "z":"俄远东"},{"c":"FPMC", "z":"台塑海运"},{"c":"FWC", "z":"浩达"},{"c":"GCS", "z":"大新华"},{"c":"GENEQ", "z":"捷尼克"},{"c":"GREAT OCEAN", "z":"大洋航运"},{"c":"GSL", "z":"金星"},{"c":"HAL", "z":"兴亚"},{"c":"HARBOUR", "z":"港业航运"},{"c":"HASCO", "z":"上海海华"},{"c":"HATSU", "z":"英商荣发"},{"c":"HBS", "z":"汉堡"},{"c":"HJS", "z":"韩进"},{"c":"HLC", "z":"赫伯罗特"},{"c":"HMM", "z":"现代"},{"c":"HSL", "z":"韩星"},{"c":"HUB", "z":"德利"},{"c":"IRISL", "z":"伊朗国航"},{"c":"ITL", "z":"意邮"},{"c":"JJS", "z":"锦江"},{"c":"JZS", "z":"吉舟船务"},{"c":"KANWAY", "z":"建华"},{"c":"KKC", "z":"神原汽船"},{"c":"KLINE", "z":"川崎"},{"c":"KMTC", "z":"高丽"},{"c":"KSC", "z":"协和海运"},{"c":"LCK", "z":"连云港中韩轮渡"},{"c":"LFS", "z":"鲁丰"},{"c":"MARI", "z":"玛丽亚那"},{"c":"MARUB", "z":"马鲁巴"},{"c":"MATSON", "z":"美森"},{"c":"MCL", "z":"迈捷箱运"},{"c":"MHMS", "z":"马尾华荣"},{"c":"MISC", "z":"马来西亚"},{"c":"MOL", "z":"商船三井"},{"c":"MSC", "z":"地中海"},{"c":"MSK", "z":"马士基"},{"c":"MSS", "z":"民生"},{"c":"NAC", "z":"古巴亚洲"},{"c":"NANQING", "z":"南青"},{"c":"NBO", "z":"宁波海运"},{"c":"NCL", "z":"北欧亚"},{"c":"NDS", "z":"尼罗河航运"},{"c":"NINGBO OCEAN", "z":"宁波远洋"},{"c":"NOS", "z":"新东船务"},{"c":"NSK", "z":"南西"},{"c":"NSS", "z":"南星"},{"c":"NYK", "z":"日本邮船"},{"c":"ONTO", "z":"安通"},{"c":"OOCL", "z":"东方海外"},{"c":"ORIENT FERRY", "z":"奥林"},{"c":"PANA", "z":"泛亚"},{"c":"PANO", "z":"泛洋"},{"c":"PCS", "z":"泛洲"},{"c":"PIL", "z":"太平"},{"c":"PML", "z":"澳门海运"},{"c":"PUHAI", "z":"浦海航运"},{"c":"QININ", "z":"秦仁"},{"c":"RCL", "z":"宏海箱运"},{"c":"SAFMR", "z":"比利时航运"},{"c":"SAMUDERA", "z":"萨姆达拉"},{"c":"SCI", "z":"印度国航"},{"c":"SDFM", "z":"山东远东"},{"c":"SEN", "z":"德国胜利"},{"c":"SIF", "z":"上海轮渡"},{"c":"SINKO", "z":"长锦"},{"c":"SINO", "z":"中外运"},{"c":"SITC", "z":"新海丰"},{"c":"SMART", "z":"美达"},{"c":"SPMS", "z":"山东海运"},{"c":"SSE", "z":"上海快航"},{"c":"SSF", "z":"下关轮渡"},{"c":"SYMS", "z":"烟台海运"},{"c":"TAL", "z":"印度环亚"},{"c":"TIMS", "z":"天津海运"},{"c":"TIP", "z":"津川"},{"c":"TJF", "z":"津神"},{"c":"TJMS", "z":"天津津海"},{"c":"TMM", "z":"墨西哥航运"},{"c":"TNC", "z":"台湾航业"},{"c":"TOHO", "z":"东航"},{"c":"TSL", "z":"德翔"},{"c":"TSM", "z":"荷兰塔斯曼"},{"c":"TYS", "z":"太荣"},{"c":"UASC", "z":"阿拉伯轮船"},{"c":"USL", "z":"美国轮船"},{"c":"WEIDONG", "z":"威海威东航运"},{"c":"WHL", "z":"万海"},{"c":"WINL", "z":"威兰德"},{"c":"XGLF", "z":"鹭丰"},{"c":"YML", "z":"阳明"},{"c":"YRS", "z":"扬子江"},{"c":"YSF", "z":"黄海轮渡"},{"c":"YTL", "z":"亿通"},{"c":"YZF", "z":"烟台中韩轮渡"},{"c":"ZHONGGU", "z":"中谷新良"},{"c":"ZIM", "z":"以星"},{"c":"Hamburg Sud", "z":"汉堡南美"},{"c":"SAF", "z":"南非轮船"},{}]';

var day = '[{"c":"DAILY", "z":"DAILY"},{"c":"一", "z":"星期一"},{"c":"二", "z":"星期二"},{"c":"三", "z":"星期三"},{"c":"四", "z":"星期四"},{"c":"五", "z":"星期五"},{"c":"六", "z":"星期六"},{"c":"日", "z":"星期日"},{}]';

var asp = '[{"s":"AAT","e":"ALTAY","z":"阿勒泰"},{"s":"ACX","e":"XINGYI","z":"兴义"},{"s":"AEB","e":"BAISE ","z":"百色"},{"s":"AKA","e":"ANKANG","z":"安康"},{"s":"AKU","e":"AKESU","z":"阿克苏"},{"s":"AOG","e":"ANSHAN","z":"鞍山"},{"s":"AQG","e":"ANQING","z":"安庆"},{"s":"AVA","e":"AN SHUN","z":"安顺"},{"s":"AYN","e":"ANYANG","z":"安阳"},{"s":"BAV","e":"BAOTOU","z":"包头"},{"s":"BFU","e":"BANGBU","z":"蚌埠"},{"s":"BHY","e":"BEIHAI","z":"北海"},{"s":"BJS","e":"BEIJING","z":"北京"},{"s":"BPX","e":"CHANGDU","z":"昌都"},{"s":"BSD","e":"BAOSHAN","z":"保山"},{"s":"CAN","e":"GUANGZHOU","z":"广州"},{"s":"CGD","e":"CHANGDE","z":"常德"},{"s":"CGO","e":"ZHENGZHOU","z":"郑州"},{"s":"CGQ","e":"CHANGCHUN","z":"长春"},{"s":"CHG","e":"CHAOYANG","z":"朝阳"},{"s":"CHW","e":"JIUQUAN","z":"酒泉"},{"s":"CIF","e":"CHIFENG","z":"赤峰"},{"s":"CIH","e":"CHANGZHI","z":"长治"},{"s":"CKG","e":"CHONGQING","z":"重庆"},{"s":"CNI","e":"CHANGHAI","z":"长海"},{"s":"CSX","e":"CHANGSHA","z":"长沙"},{"s":"CTU","e":"CHENGDU","z":"成都"},{"s":"CZX","e":"CHANGZHOU","z":"常州"},{"s":"DAT","e":"TAIYUAN","z":"太原"},{"s":"DAX","e":"DAXIAN","z":"达县"},{"s":"DDG","e":"DANDONG","z":"丹东"},{"s":"DIG","e":"DIQING","z":"迪庆"},{"s":"DLC","e":"DALIAN","z":"大连"},{"s":"DLU","e":"DALI","z":"大理"},{"s":"DNH","e":"DUNHUANG","z":"敦煌"},{"s":"DOY","e":"DONGYING","z":"东营"},{"s":"DSN","e":"EERDUOSI","z":"鄂尔多斯"},{"s":"DYG","e":"ZHANGJIAJIE","z":"张家界"},{"s":"ENH","e":"ENSHI","z":"恩施"},{"s":"ENY","e":"YANAN","z":"延安"},{"s":"FOC","e":"FUZHOU","z":"福州"},{"s":"FUD","e":"SUIFENHE","z":"绥芬河"},{"s":"FUG","e":"FUYANG","z":"阜阳"},{"s":"FUO","e":"FOSHAN","z":"佛山"},{"s":"FYN ","e":"FUYUN","z":"富蕴"},{"s":"GHN","e":"GUANGHAN","z":"广汉"},{"s":"GOQ","e":"GOLMUD","z":"格尔木"},{"s":"GYS","e":"GUANGYUAN","z":"广元"},{"s":"HAK","e":"HAIKOU","z":"海口"},{"s":"HEK","e":"HEIHE","z":"黑河"},{"s":"HET","e":"HUHEHAOTE","z":"呼和浩特"},{"s":"HFE","e":"HEFEI","z":"合肥"},{"s":"HGH","e":"HANGZHOU","z":"杭州"},{"s":"HHA","e":"HUANGHUA","z":"黄花"},{"s":"HJJ","e":"ZHIJIANG","z":"芷江"},{"s":"HLD","e":"HAILAER","z":"海拉尔"},{"s":"HLH","e":"WULANHAOTE","z":"乌兰浩特"},{"s":"HMI","e":"HAMI ","z":"哈密"},{"s":"HNY","e":"HENGYANG","z":"衡阳"},{"s":"HRB","e":"HARBIN","z":"哈尔滨"},{"s":"HSN","e":"ZHOUSHAN","z":"舟山"},{"s":"HTN","e":"HETIAN","z":"和田"},{"s":"HUZ","e":"HUIZHOU","z":"惠州"},{"s":"HYN","e":"HUANGYAN","z":"黃岩"},{"s":"HZG","e":"HANZHONG","z":"汉中"},{"s":"HZH","e":"LIPING","z":"黎平"},{"s":"INC","e":"YINCHUAN","z":"银川"},{"s":"IQM","e":"QIEMO","z":"且末"},{"s":"IQN","e":"QINGYANG","z":"庆阳"},{"s":"JDZ","e":"JINGDEZHEN","z":"景德镇"},{"s":"JGN","e":"JIAYUGUAN","z":"嘉裕关"},{"s":"JGS","e":"JINGGANGSHAN","z":"井冈山"},{"s":"JHG","e":"JINGHONG","z":"景洪"},{"s":"JIL","e":"JILIN","z":"吉林"},{"s":"JIU","e":"JIUJIANG","z":"九江"},{"s":"JJN","e":"JINJIANG","z":"晋江"},{"s":"JMU","e":"JIAMUSI","z":"佳木斯"},{"s":"JNG","e":"JINING","z":"济宁"},{"s":"JNZ","e":"JINZHOU","z":"锦州"},{"s":"JUZ","e":"QUZHOU","z":"衢州"},{"s":"JZH","e":"JIUZHAIGOU","z":"九寨沟"},{"s":"KCA","e":"KUQA","z":"库车"},{"s":"KHG","e":"KASHI","z":"喀什"},{"s":"KHN","e":"NANCHANG","z":"南昌"},{"s":"KMG","e":"KUNMING","z":"昆明"},{"s":"KNC","e":"JIAN","z":"吉安"},{"s":"KOW","e":"GANZHOU","z":"赣州"},{"s":"KRL","e":"KORLA","z":"库尔勒"},{"s":"KRY","e":"KARAMAY","z":"克拉玛依"},{"s":"KWE","e":"GUIYANG","z":"贵阳"},{"s":"KWL","e":"GUILIN","z":"桂林"},{"s":"LCX","e":"LONGYAN","z":"龙岩"},{"s":"LHW","e":"LANZHOU","z":"兰州"},{"s":"LIA","e":"LIANGPING","z":"梁平"},{"s":"LJG","e":"LIJIANG","z":"丽江"},{"s":"LLF","e":"YONGZHOU","z":"永州"},{"s":"LNJ","e":"LINCANG","z":"临沧"},{"s":"LUM","e":"MANGSHI","z":"芒市"},{"s":"LUZ","e":"LUSHAN","z":"庐山"},{"s":"LXA","e":"LASA","z":"拉萨"},{"s":"LYA","e":"LUOYANG","z":"洛阳"},{"s":"LYG","e":"LIANYUNGANG","z":"连云港"},{"s":"LYI","e":"LINYI","z":"临沂"},{"s":"LZD","e":"LANZHOU","z":"兰州"},{"s":"LZH","e":"LIUZHOU","z":"柳州"},{"s":"LZO","e":"LUZHOU","z":"泸州"},{"s":"LZY","e":"LINZHI ","z":"林芝"},{"s":"MDG","e":"MUDANJIANG","z":"牡丹江"},{"s":"MIG","e":"MIAN YANG","z":"绵阳"},{"s":"MXZ","e":"MEIXIAN","z":"梅县"},{"s":"NAO","e":"NANCHONG","z":"南充"},{"s":"NAY","e":"BEIJING","z":"北京"},{"s":"NDG","e":"QIQIHAER","z":"齐齐哈尔"},{"s":"NGB","e":"NINGBO","z":"宁波"},{"s":"NKG","e":"NANJING","z":"南京"},{"s":"NNG","e":"NANING","z":"南宁"},{"s":"NNY","e":"NANYANG","z":"南阳"},{"s":"NTG","e":"NANTONG","z":"南通"},{"s":"NZH","e":"MANZHOULI","z":"满洲里"},{"s":"PEK","e":"BEIJING","z":"北京"},{"s":"PNJ","e":"PENGLAI","z":"蓬莱"},{"s":"PVG","e":"SHANGHAI","z":"上海"},{"s":"PZI","e":"PANZHIHUA","z":"攀枝花"},{"s":"RUG","e":"RUGAO","z":"如皋 "},{"s":"SHA","e":"SHANGHAI","z":"上海"},{"s":"SHE","e":"SHENYANG","z":"沈阳"},{"s":"SHF","e":"SHANHAIGUAN","z":"山海关"},{"s":"SHP","e":"QINHUANGDAO","z":"秦皇岛"},{"s":"SHS","e":"JINGZHOU","z":"荆州"},{"s":"SIA","e":"XIAN","z":"西安"},{"s":"SJW","e":"SHIJIAZHUANG","z":"石家庄"},{"s":"SWA","e":"SHANTOU","z":"汕头"},{"s":"SYM","e":"SIMAO","z":"普洱"},{"s":"SYM","e":"SIMAO","z":"思茅"},{"s":"SYX","e":"SANYA","z":"三亚"},{"s":"SZX","e":"SHENZHEN","z":"深圳"},{"s":"TAO","e":"QINGDAO","z":"青岛"},{"s":"TCG","e":"TACHENG","z":"塔城"},{"s":"TEN","e":"TONGREN","z":"铜仁"},{"s":"TGO","e":"TONGLIAO","z":"通辽"},{"s":"TNA","e":"JINAN","z":"济南"},{"s":"TNH","e":"TONGHUA","z":"通化"},{"s":"TSN","e":"TIANJIN","z":"天津"},{"s":"TXN","e":"HUANGSHAN ","z":"黄山"},{"s":"TYN","e":"TAIYUAN","z":"太原"},{"s":"URC","e":"WULUMUQI","z":"乌鲁木齐"},{"s":"UYN","e":"YULIN","z":"榆林"},{"s":"WEF","e":"WEIFANG","z":"潍坊"},{"s":"WEH","e":"WEIHAI","z":"威海"},{"s":"WNH","e":"WENSHAN","z":"文山"},{"s":"WNZ","e":"WENZHOU","z":"温州"},{"s":"WUA","e":"WUHAI","z":"乌海"},{"s":"WUH","e":"WUHAN","z":"武汉"},{"s":"WUS","e":"WUYISHAN","z":"武夷山"},{"s":"WUX","e":"WUXI","z":"无锡"},{"s":"WUZ","e":"WUZHOU","z":"梧州"},{"s":"WXN","e":"WANXIAN","z":"万县"},{"s":"XEN","e":"XINGCHENG","z":"兴城 "},{"s":"XFN","e":"XIANGFAN","z":"襄樊"},{"s":"XIC","e":"XICHANG","z":"西昌"},{"s":"XIL","e":"XILINHAOTE","z":"锡林浩特"},{"s":"XIN ","e":"XINGNING","z":"兴宁"},{"s":"XIY","e":"XIAN","z":"西安"},{"s":"XMN","e":"XIAMEN","z":"厦门"},{"s":"XNN","e":"XINING","z":"西宁"},{"s":"XNT","e":"XINGTAI","z":"邢台"},{"s":"XUZ","e":"XUZHOU","z":"徐州"},{"s":"YBP","e":"YIBIN","z":"宜宾"},{"s":"YCU","e":"YUNCHENG","z":"运城"},{"s":"YIH","e":"YICHANG","z":"宜昌"},{"s":"YIN","e":"YINING","z":"伊宁"},{"s":"YIW","e":"YIWU","z":"义乌"},{"s":"YLN","e":"YILAN","z":"依兰"},{"s":"YNJ","e":"YANJI","z":"延吉"},{"s":"YNT","e":"YANTAI","z":"烟台"},{"s":"YNZ","e":"YANCHENG","z":"盐城"},{"s":"YUA","e":"YUANMOU","z":"元谋"},{"s":"ZAT","e":"ZHAOTONG","z":"昭通"},{"s":"ZGC","e":"LANZHOU","z":"兰州"},{"s":"ZHA","e":"ZHANJIANG","z":"湛江"},{"s":"ZUH","e":"ZHUHAI","z":"珠海"},{"s":"ZYI","e":"ZUNYI","z":"遵义"},{}]';

var ac = {
    ist: false,
    t1: "start_port",
    t11: "起运港",
    t2: "end_port",
    t22: "目的港",
    t3: "ship_com",
    t33: "船公司",
    t4: "day_begin",
    t5: "air_port",
    t55: "目的地",
    t6: "air_start",
    t66: "起运地",
    li: "loading.gif",
    w1: 300,
    w2: 250,
    w3: 40,
    url: "PostBack/Port.aspx",
    ci: -1
};
/*
d 文本框
i 弹出层
h 表单form
k keycode
s 文本框内容 textbox.value
t sou_type
z 文本框坐标
w 弹出层宽度
tx 数据数组
tp 临时暂存
ia 键盘操作用暂存数组
q,j 循环用数
*/
var _d, _i, _h, _k = 0, s, t, _z, _w = 0, r, tx = [], tp = [], e = [], ia = [], cn = "", ch = "", en = "", cou = "", q = 0, j = 0, vc = 0, zv = 0, zt = 0;
function auto_init(e, o) {
    if (typeof arguments[2] === "boolean") { ac.ist = true; } else { ac.ist = false; }
    if (ac.ist === true)
        if (isw(o) === o.value.Trim()) { o.value = ""; o.style.color = "black" }
    tx = [], tp = [], ia = [];
    _d = o;
    cdd();
    _h = document.forms[0];
    _h.onsubmit = ns;
    _d.onblur = rns;
    if (document.addEventListener) {
        _d.addEventListener("keydown", okdh, true);
        _d.addEventListener("keyup", okuh, true);
    } else {
        _d.attachEvent("onkeydown", okdh);
        _d.attachEvent("onkeyup", okuh);
    }
    _d.onclick = okuh;
    _i.onmouseover = om;
    _i.onmouseout = ot;
}
function isw(o) {
    t = o.getAttribute("sou_type");
    var wt = "";
    switch (t) {
        case ac.t1:
            wt = ac.t11;
            break;
        case ac.t2:
            wt = ac.t22;
            break;
        case ac.t3:
            wt = ac.t33;
            break;
        case ac.t4:
            wt = ac.t44;
            break;
        case ac.t6:
            wt = ac.t66;
            break;
        case ac.t5:
            wt = ac.t55;
            break;
        default:
            break;
    }

    return wt;
}
function om() {
    _d.onblur = function() { return false; }
}
function ot() {
    _d.onblur = rns;
}
function cdd() {
    if (document.getElementById("autodiv") !== null) { _i = document.getElementById("autodiv"); return; };
    _i = document.createElement("DIV");
    _i.id = "autodiv";
    _i.style.position = "absolute";
    _i.style.zIndex = "5";
    _i.style.overflow = "auto";
    _i.className = "autodiv";
    _i.style.border = "1px solid #000000";
    _i.style.visibility = "hidden";
    document.getElementById("messages").appendChild(_i);
}
function ns() {
    return false;
}
function rs() {
    return true;
}
function okdh(event) {
    _k = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
    if (_k == 13)
        if (ac.ci !== -1) {
        si();
        return false;
    }
    return;
}
function okuh(evt) {
    _s = _d.value.Trim();
    if (_s.length < 1) return;
    t = _d.getAttribute("sou_type");
    _z = gp(_d);
    _i.style.left = _z.x + "px";
    _i.style.top = (_z.y + _d.offsetHeight) + "px";
    if (t === ac.t1 || t === ac.t2 || t === ac.t5 || t === ac.t6)
        _w = ac.w1;
    if (t == ac.t3)
        _w = ac.w2;
    if (t == ac.t4)
        _w = ac.w3;
    _i.style.width = _w + "px";
    _i.style.visibility = "visible";
    if (_k == 38 || _k == 40) {
        si();
    }
    else {
        if (_k === 13) {

            if (ac.ci === -1) {
                gi();
            }
            else {
                //si();
                return false;
            }
        }
        else {
            gi();
        }
    }
}
function gi() {
    s = _d.value.Trim();
    _i.innerHTML = "<img src=\"" + ac.li + "\" alt=\"loading\"/>Loading...";
    if (t === ac.t1) { r = sp || "[]"; }
    if (t === ac.t2) { r = ep || "[]"; }
    if (t === ac.t3) { r = sb || "[]"; }
    if (t === ac.t4) { r = day; }
    if (t === ac.t6) { r = asp || "[]"; }
    if (t === ac.t5) {
        if (s.length > 0) {
            if (IsZH(s)) {
                tx = AirlistIndex;
            }
            else {
                var air_l = s.split("");
                for (var j = 0; j < 26; j++) {
                    if (AirlistIndex[j] == air_l[0].toUpperCase()) {
                        r = Airportlist[j];
                        eval("tx = " + r);
                        break;
                    }
                }
            }
        }
        else {
            r = Airportlist[0];
            eval("tx = " + r);
        }
    }
    if (t == ac.t1 || t == ac.t2 || t == ac.t3 || t == ac.t4 || t == ac.t6) {
        eval("tx = " + r);
    }
    var l = tx.length;tp = [],ta=[],_m=0,bool = true,tio="",til="";
    //if (t != ac.t4) { if (s.length < 1) { l = 11 } }
    for (q = 0; q < l - 1; q++) {
        if (t == ac.t1 || t == ac.t2 || t == ac.t3 || t == ac.t4) {
            cn = tx[q].c;
            ch = tx[q].z;
        }
        switch (t) {
            case ac.t1:
                if (cn.toLowerCase().indexOf(s.toLowerCase()) == 0 || ch.indexOf(s) == 0){
                	tio="<a href=\"javascript:void(0)\" id=\"" + cn + "\"><span>" + ch + "</span>" + cn + "</a>";
                	if(IsZH(s)){/*中文*/
                		if(ch!==s){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.H_s.length){
	                    	if(s.indexOf(di.H_s[_m].k)==0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.H_s[_m].u+"\" target=\"_blank\">" +
	                    		     di.H_s[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(ch===s){
	                    			if(ch===di.H_s[_m].s)
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                	else{/*EngLish*/
                		if(cn.toUpperCase()!==s.toUpperCase()){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.H_s.length){
	                    	if(s.toLowerCase().indexOf(di.H_s[_m].k.toLowerCase()) == 0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.H_s[_m].u+"\" target=\"_blank\">" +
	                    		     di.H_s[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(cn.toUpperCase() === s.toUpperCase()){
	                    			if(cn.toUpperCase() === di.H_s[_m].s.toUpperCase())
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                }
                break;
            case ac.t2:
                if (cn.indexOf(s.toUpperCase()) == 0 || ch.indexOf(s) == 0) {
                	tio="<a href=\"javascript:void(0)\" title=\"" + tx[q].g + "\" id=\"" + cn + "\"><span>" + ch + "(" + tx[q].h + ")</span>" + cn + "</a>";
                	if(IsZH(s)){/*中文*/
                		if(ch!==s){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.H_e.length){
	                    	if(s.indexOf(di.H_e[_m].k)==0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.H_e[_m].u+"\" target=\"_blank\">" +
	                    		     di.H_e[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(ch===s){
	                    			if(ch===di.H_e[_m].e)
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                	else{/*EngLish*/
                		if(cn!==s.toUpperCase()){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.H_e.length){
	                    	if(s.toLowerCase().indexOf(di.H_e[_m].k.toLowerCase()) == 0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.H_e[_m].u+"\" target=\"_blank\">" +
	                    		     di.H_e[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(cn === s.toUpperCase()){
	                    			if(cn === di.H_e[_m].e.toUpperCase())
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                }
                break;
            case ac.t3:
            	if (cn.indexOf(s.toUpperCase()) == 0 || ch.indexOf(s) == 0){
                	tio="<a href=\"javascript:void(0)\" id=\"" + cn + "\"><span>" + ch + "</span>" + cn + "</a>";
                	if(IsZH(s)){/*中文*/
                		if(ch!==s){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.ship.length){
	                    	if(s.indexOf(di.ship[_m].k)==0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.ship[_m].u+"\" target=\"_blank\">" +
	                    		     di.ship[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(ch===s){
	                    			if(ch===di.ship[_m].p)
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                	else{/*EngLish*/
                		if(cn!==s.toUpperCase()){
	                		tp.push(tio);
	                    }
	                    else {
	                        ta.push(tio);
	                    }
	                    while(_m<di.ship.length){
	                    	if(s.toLowerCase().indexOf(di.ship[_m].k.toLowerCase()) == 0){
	                    		til="<a "+
	                    		    "style=\""+((di.tc==="")?"":"color:"+di.tc+";")+((di.bg==="")?"":"background-color:"+di.bg+";")+"\""+
	                    		    " id=\"ad_"+_m+"\" href=\""+di.ship[_m].u+"\" target=\"_blank\">" +
	                    		     di.ship[_m].c.replace(/@/g, "\"") +"</a>";
	                    		if(cn.toLowerCase() === s.toLowerCase()){
	                    			if(cn.toLowerCase() === di.ship[_m].p.toLowerCase())
	                    				ta.push(til);
	                    		}else{
	                    			ta.push(til);
	                    		}
	                    	}
	                    	_m++;
	                    }
                	}
                }
                break;
            case ac.t4:
                tp.push("<a href=\"javascript:void(0)\" id=\"" + cn + "\" title=\"" + ch + "\">" + cn + "</a>");
                break;
            case ac.t6:
                cn = tx[q].s;
                ch = tx[q].z;
                en = tx[q].e;
                if (cn.indexOf(s.toUpperCase()) == 0 || en.indexOf(s.toUpperCase()) == 0 || ch.indexOf(s) == 0)
                    tp.push("<a href=\"javascript:void(0)\" id=\"" + cn + "\"><span>(" + en + ")" + ch + "</span>" + cn + "</a>");
                break;
            case ac.t5:
                if (!IsZH(s)) {
                    cn = tx[q].s;
                    ch = tx[q].c;
                    en = tx[q].e;
                    cou = tx[q].a;
                    if (cn.indexOf(s.toUpperCase()) == 0 || en.toUpperCase().indexOf(s.toUpperCase()) == 0) {
                        tp.push("<a href=\"javascript:void(0)\" id=\"" + cn + "\" title=\"" + en + "\"><span>" + ch + " (" + cou + ")</span>" + cn + "</a>");
                    }
                }
                else {
                    eval("txt = " + Airportlist[q]);
                    al = txt.length;
                    for (j = 0; j < al - 1; j++) {
                        cn = txt[j].s;
                        ch = txt[j].c;
                        en = txt[j].e;
                        cou = txt[j].a;
                        if (ch.indexOf(s) == 0) {
                            vc = 0, zv = 0, zt = 0;
                            vc = e.length;
                            for (zv = 0; zv < vc; zv++) {
                                if (cn === e[zv]) { zt = 1; break; }
                            }
                            if (zt == 0) {
                                e.push(cn);
                                tp.push("<a href=\"javascript:void(0)\" id=\"" + cn + "\" title=\"" + en + "\"><span>" + ch + " (" + cou + ")</span>" + cn + "</a>");
                            }
                        }
                    }
                }
                break;
            default:
                break;
        }
    }
    
    e = [];
    tx = "";
    tx += "<div id=\"prot_warp\">";
    if (tp.length < 1&&ta.length <1) {
        tx += "<div id=\"prot_message\" style=\"color:#C0C0C0\">对不起,找不到:" + s + "</div>";
    }
    else {
        if (t != ac.t4)
            tx += "<div id=\"prot_message\">输入中文/拼音/缩写或↑↓选择.</div>";
    }
    tx += "<div id=\"prot_list\">";
    if (ta.length > 0)
        tx += ta.join("");
    tx += tp.join("");
    tx += "</div></div>";
    _i.innerHTML = tx;
    ac.ci = -1;
    
    ia = document.getElementById("prot_list").getElementsByTagName("a");
    var len =ia.length;
    for (var i = 0; i <len; i++) {
    	if(ia[i].getAttribute("href")==="javascript:void(0)"){
	        ia[i].onclick=function(){
	        	_d.value = this.id;
	        	rns();
	        };
	    }
    }
}
function si() {
    ia = document.getElementById("prot_list").getElementsByTagName("a");
    q = ia.length;

    if (_k === 38) {
        ac.ci -= 1; if (ac.ci < 0) ac.ci = q - 1;
    }
    if (_k === 40) {
        ac.ci += 1; if (ac.ci == q) ac.ci = 0;
    }
    if (_k === 13) {
    	if(ia[ac.ci].getAttribute("href")!=="javascript:void(0)"){
    		if(document.all){
    		var op=ia[ac.ci].id;
    		document.getElementById(op).click();
    		}else{
    		window.open(ia[ac.ci].getAttribute("href"));
    		}
    	}else{
	        var s = ia[ac.ci].id;
	        _d.value = s;
        }
        cd();
        return false;
    }

    for (var i = 0; i < q; i++) {
        ia[i].className = "";
    }
    ia[ac.ci].className = "hov";
}
function cd() {
    if (!_i) return;
    _i.style.visibility = "hidden";
    ac.ci = -1;
}
function rns() {
    if (ac.ist === true)
        if (_d.value.Trim() === "") { _d.value = isw(_d); _d.style.color = "#ccc"; }
    cd();
    _k = 0;
    if (document.removeEventListener) {
        _d.removeEventListener("keydown", okdh, true);
        _d.removeEventListener("keyup", okuh, true);
    } else {
        _d.detachEvent("onkeydown", okdh);
        _d.detachEvent("onkeyup", okuh);
    }
    _h.onsubmit = rs;
}
/*广告数据初始化*/
function _dInit(d) {
    var _m="\u53c3\u6578\u914d\u7f6e\u932f\u8aa4\uff01";
    var ss="";
    if (d.s === "undefined"||d.i=== "undefined") { alert(_m); return; }
    if(d.s.toLowerCase()==="j")
        if(typeof d.i==="string")ss=eval(d.i);
    if (d.s.toLowerCase() === "t")
        if (document.getElementById(d.i)) ss = document.getElementById(d.i).value;
    if (ss.length < 1) {
        alert(_m); return;
    }
    var tq=[];
    eval("tq= "+ss);
    var t_l=tq.length;
    d.H_s = [];
    d.H_e = [];
    d.ship = [];
    d.A_s = [];
    d.A_e = [];
    for (var i = 0; i < t_l - 1; i++) {
        if (tq[i].k.length < 1 || tq[i].t.length < 1 || tq[i].c.length < 1 || tq[i].u.length < 1) {
            alert(_m);return;
        }
        switch (tq[i].t) {
            case ac.t1:
                d.H_s.push(tq[i]);
                break;
            case ac.t2:
                d.H_e.push(tq[i]);
                break;
            case ac.t3:
                d.ship.push(tq[i]);
                break;
            case ac.t6:
                d.A_e.push(tq[i]);
                break;
            case ac.t5:
                d.A_s.push(tq[i]);
                break;
            default:
                break;
        }
    }
    //alert(di.H_s.length);
}
function IsZH(str) {
    var re = /^[\u4e00-\u9fa5]+$/;
    if (re.test(str))
        return true;
    return false;
}
function gp(p) {
    var _x = 0;
    var _y = 0;
    while (null != p.offsetParent) {
        _x += p.offsetLeft;
        _y += p.offsetTop;
        p = p.offsetParent;
    }
    return { x: _x, y: _y };
}
String.prototype.Trim = function() {
    return this.replace(/(^\s*)|(\s*$)/g, "");
}
String.prototype.rp = function() {
    return this.replace(/&quot;/g, "\"");
}