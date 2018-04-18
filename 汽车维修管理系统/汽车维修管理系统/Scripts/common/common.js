//顶部菜单的点击事件
var totalMenu = [
    {
        id: 1,
        name: "维修接待",
        menuIconUrl: "../Content/img/common/service.png",
        subMenu: [
            {
                id: 10,
                name: "维修管理",
                menuIconClass: "fa-gavel",
                subMenu: [
                    {
                        id: 100,
                        name: "洗车开单",
                        url: "100"
                    },
                    {
                        id: 101,
                        name: "维修开单",
                        url: "100"
                    }
                ]
            },
            {
                id: 11,
                name: "预约管理",
                menuIconClass: "fa-book",
                subMenu: [
                    {
                        id: 102,
                        name: "新增预约",
                        url: "100"
                    },
                    {
                        id: 103,
                        name: "预约列表",
                        url: "100"
                    }
                ]
            }
        ]
    },
    {
        id: 2,
        name: "客户关系",
        menuIconUrl: "../Content/img/common/customer.png",
        subMenu: [
            {
                id: 20,
                name: "客户管理",
                menuIconClass: "fa-book",
                subMenu: [
                    {
                        id: 200,
                        name: "客户列表",
                        url: "100"
                    },
                    {
                        id: 201,
                        name: "新增客户",
                        url: "100"
                    }
                ]
            },
            {
                id: 21,
                name: "车辆管理",
                menuIconClass: "fa-book",
                subMenu: [
                    {
                        id: 202,
                        name: "新增车辆",
                        url: "100"
                    },
                    {
                        id: 203,
                        name: "车辆列表",
                        url: "100"
                    }
                ]
            }
        ]
    },
    {
        id: 3,
        name: "配件管理",
        menuIconUrl: "../Content/img/common/warehouse.png",
        subMenu: []
    },
    {
        id: 4,
        name: "报表分析",
        menuIconUrl: "../Content/img/common/report.png",
        subMenu: []
    },
    {
        id: 5,
        name: "基础资料",
        menuIconUrl: "../Content/img/common/baseinfo.png",
        subMenu: []
    },
    {
        id: 6,
        name: "系统设置",
        menuIconUrl: "../Content/img/common/system.png",
        subMenu: []
    }
];
var menu = totalMenu[0];
var vm = new Vue({
    el: "#sidebar",
    data: {
        menu: menu
    }
});
var vm1 = new Vue({
    el: "#navbarMenu",
    data: {
        totalMenu: totalMenu,
        menu:menu
    },
    methods: {
        changeMenu: function(item) {
            if (item.id == this.menu.id) {
                return;
            }
            this.menu = item;
            vm.menu = item;
        }
    }
});