var getMenuUrl = "/Home/GetAuthorizedMenus";
//侧边菜单的点击事件
var vm = new Vue({
    el: "#sidebar",
    data: {
        selectedMenu: {},
        selectedSecondMenu: {},
        selectedThirdMenu: {},
        autoOpen: false,
    },
    created: function () {
        var _this = this;
        _this.selectedSecondMenu = {
            Id: -1
        };
        _this.selectedThirdMenu = {
            Id: -1
        };
        if (!sessionStorage.getItem("selectedMenu")) {
            $.get(getMenuUrl, {userId:userId}, function (res) {
                _this.selectedMenu = res[0];
                sessionStorage.setItem("selectedMenu", JSON.stringify(res[0]));
            });
        } else {
            if (sessionStorage.getItem("currentMenu")) {
                _this.selectedMenu = JSON.parse(sessionStorage.getItem("currentMenu"));
            } else {
                _this.selectedMenu = JSON.parse(sessionStorage.getItem("selectedMenu"));
            }
        }
        if (sessionStorage.getItem("selectedThirdMenu")) {
            _this.selectedSecondMenu = JSON.parse(sessionStorage.getItem("selectedSecondMenu"));
            _this.selectedThirdMenu = JSON.parse(sessionStorage.getItem("selectedThirdMenu"));
            _this.autoOpen = true;
        }
    },
    methods: {
        chooseThirdLevel: function (item, parentItem, topLevelMenu) {
            this.selectedSecondMenu = parentItem;
            this.selectedThirdMenu = item;

            sessionStorage.setItem("currentMenu", JSON.stringify(topLevelMenu));
            sessionStorage.setItem("selectedSecondMenu", JSON.stringify(parentItem));
            sessionStorage.setItem("selectedThirdMenu", JSON.stringify(item));
            window.location.href = item.Url;
        }
    }
});
//顶部菜单点击事件
var vm1 = new Vue({
    el: "#navbarMenu",
    data: {
        totalMenu: {},
        selectedMenu: {},
        currentMenu: {}
    },
    created: function () {
        var _this = this;
        if (!sessionStorage.getItem("selectedMenu")) {
            $.get(getMenuUrl, { userId: userId },function (res) {
                _this.totalMenu = res;
                _this.selectedMenu = res[0];

                sessionStorage.setItem("totalMenu", JSON.stringify(res));
                sessionStorage.setItem("selectedMenu", JSON.stringify(res[0]));
            });
        } else {
            _this.totalMenu = JSON.parse(sessionStorage.getItem("totalMenu"));
            if (sessionStorage.getItem("currentMenu")) {
                _this.selectedMenu = JSON.parse(sessionStorage.getItem("currentMenu"));
            } else {
                _this.selectedMenu = JSON.parse(sessionStorage.getItem("selectedMenu"));
            }
        }
    },
    methods: {
        changeMenu: function (item) {
            if (this.selectedMenu.Id && item.Id == this.selectedMenu.Id) {
                return;
            }
            this.selectedMenu = item;
            vm.selectedMenu = item;
            sessionStorage.setItem("selectedMenu", JSON.stringify(item));
        }
    }
});

//回到首页
$("#navbarBrand").click(function () {
    sessionStorage.clear();
    window.location.href = "/Home/Index";
});
$(document).ready(function () {
    $("#logOut").click(function () {
        sessionStorage.clear();
        window.location.href = "/Account/Logout";
    });
});
