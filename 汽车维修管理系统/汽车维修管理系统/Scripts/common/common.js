var getMenuUrl = "/Home/GetAllMenu";
//顶部菜单的点击事件
var vm = new Vue({
    el: "#sidebar",
    data: {
        selectedMenu:[]
    },
    created: function () {
        var _this = this;
        $.get(getMenuUrl, function(res) {
            _this.selectedMenu = res[0];
        });
    }
});
var vm1 = new Vue({
    el: "#navbarMenu",
    data: {
        totalMenu: [],
        selectedMenu:[]
    },
    created: function () {
        var _this = this;
        $.get(getMenuUrl, function(res) {
            _this.totalMenu = res;
            _this.selectedMenu = res[0];
        });
    },
    methods: {
        changeMenu: function(item) {
            if (item.Id == this.selectedMenu.Id) {
                return;
            }
            this.selectedMenu = item;
            vm.selectedMenu = item;
        }
    }
});