/*
 *
 * DropDownTreeView
 * https://github.com/jsExtensions/kendoui-extended-api
 *
 */
var DropDownTreeView = kendo.ui.Widget.extend({
    _uid: null,
    _treeview: null,
    _dropdown: null,
    _v: null,

    init: function (element, options) {
        var that = this;

        kendo.ui.Widget.fn.init.call(that, element, options);

        that._uid = new Date().getTime();

        $(element).append(kendo.format("<input id='extDropDown{0}' class='k-ext-dropdown'/>", that._uid));
        $(element).append(kendo.format("<div id='extTreeView{0}' class='k-ext-treeview' style='z-index:1;'/>", that._uid));

        // Create the dropdown.
        that._dropdown = $(kendo.format("#extDropDown{0}", that._uid)).kendoDropDownList({
            dataSource: [{ text: "", value: "" }],
            dataTextField: "text",
            dataValueField: "value",
            open: function (e) {
                //to prevent the dropdown from opening or closing. A bug was found when clicking on the dropdown to
                //"close" it. The default dropdown was visible after the treeview had closed.
                e.preventDefault();
                // If the treeview is not visible, then make it visible.
                if (!$treeviewRootElem.hasClass("k-custom-visible")) {
                    // Position the treeview so that it is below the dropdown.
                    $treeviewRootElem.css({
                        "top": $dropdownRootElem.position().top + $dropdownRootElem.height(),
                        "left": $dropdownRootElem.position().left
                    });
                    // Display the treeview.
                    $treeviewRootElem.slideToggle('fast', function () {
                        that._dropdown.close();
                        $treeviewRootElem.addClass("k-custom-visible");
                    });
                }
            }
        }).data("kendoDropDownList");

        if (options.dropDownWidth) {
            that._dropdown._inputWrapper.width(options.dropDownWidth);
        }

        var $dropdownRootElem = $(that._dropdown.element).closest("span.k-dropdown");

        // Create the treeview.
        that._treeview = $(kendo.format("#extTreeView{0}", that._uid)).kendoTreeView(options.treeview).data("kendoTreeView");
        that._treeview.bind("select", function (e) {
            // When a node is selected, display the text for the node in the dropdown and hide the treeview.
            $dropdownRootElem.find("span.k-input").text($(e.node).children("div").text());
            $treeviewRootElem.slideToggle('fast', function () {
                $treeviewRootElem.removeClass("k-custom-visible");
                that.trigger("select", e);
            });
            var treeValue = this.dataItem(e.node);
            that._v = treeValue[options.valueField];
        });

        var $treeviewRootElem = $(that._treeview.element).closest("div.k-treeview");

        // Hide the treeview.
        $treeviewRootElem
            .css({
                "border"   : "1px solid #dbdbdb",
                "display"  : "none",
                "position" : "absolute",
                "background-color": that._dropdown.list.css("background-color")
            });

        $(document).click(function (e) {
            // Ignore clicks on the treetriew.
            if ($(e.target).closest("div.k-treeview").length === 0) {
                // If visible, then close the treeview.
                if ($treeviewRootElem.hasClass("k-custom-visible")) {
                    $treeviewRootElem.slideToggle('fast', function () {
                        $treeviewRootElem.removeClass("k-custom-visible");
                    });
                }
            }
        });
    },
    value: function(v){
        var that = this;
        if(v !== undefined){
            var n = that._treeview.dataSource.get(v);
            var selectNode = that._treeview.findByUid(n.uid);
            that._treeview.trigger('select',{node: selectNode});
            var $treeviewRootElem = $(that._treeview.element).closest("div.k-treeview");
            $treeviewRootElem.hide();
        }
        else{
            return that._v;
        }
    },

    dropDownList: function () {
        return this._dropdown;
    },

    treeview: function () {
        return this._treeview;
    },
    refresh: function () {
        return this._treeview.dataSource.read();
    },
    options: {
        name: "DropDownTreeView"
    }
});
kendo.ui.plugin(DropDownTreeView);