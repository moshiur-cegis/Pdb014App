
if ($.ui.autocomplete.prototype) {

    if ($.ui.autocomplete.prototype._renderMenu) {
        $.ui.autocomplete.prototype._renderMenu = function (ul, items) {
            var that = this;
            if (that.term && that.term.length > 0 && items.length > 1) {
                var term = that.term.toLowerCase();
                items = items.sort(function (ia, ib) {
                    return ia.label.toLowerCase().indexOf(term) - ib.label.toLowerCase().indexOf(term);
                });
            }

            $.each(items,
                function (index, item) {
                    that._renderItemData(ul, item);
                });

            $(ul).find("li:odd").addClass("odd");
        };
    }

    if ($.ui.autocomplete.prototype._renderItem) {
        $.ui.autocomplete.prototype._renderItem = function (ul, item) {
            var hCls = (this.options.highlight && typeof this.options.highlight == "string") ? this.options.highlight : "ui-autocomplete-highlight",
                hTxt = String(item.value).replace(new RegExp(this.term, "gi"), "<span class='" + hCls + "'>$&</span>");

            return $("<li></li>")
                .data("item.autocomplete", item)
                .append("<div>" + hTxt + "</div>")
                .appendTo(ul);
        };
    }

}



function setAutocomplete($obj) {
    var fieldInfo = $obj.val(),
        $fieldValue = $obj.closest("tr").find("input[type='text'].field-value"),
        apiUrl = apiBase + "/AutoComplete/search/";

    addAutocomplete($fieldValue, fieldInfo, apiUrl);
    return false;
}

function addAutocomplete($fieldValue, fieldInfo, apiUrl) {

    $fieldValue.empty();
    //.hasClass("ui-autocomplete-input")
    if ($fieldValue.data('ui-autocomplete') != undefined) {
        $fieldValue.autocomplete("destroy");
    }

    if (!fieldInfo)
        return false;

    var dataSrcUrl = apiUrl + fieldInfo;

    $.ajax({
        type: "GET",
        url: dataSrcUrl,
        data: JSON.stringify({ fieldInfo: fieldInfo }),
        dataType: "json",
        contentType: "application/json",
        //before: $("#busy-indicator").fadeIn(150),
        success: function (options) {
            if (!options)
                return;

            var ml = options.length < 500 ? 0 : options.length < 2500 ? 1 : options.length < 5000 ? 2 : 3;
            $fieldValue.autocomplete({
                source: options.length < 2500
                    ? options
                    : function (request, response) {
                        $.getJSON(dataSrcUrl + "/" + request.term,
                            request,
                            function (opts) {
                                opts = opts && opts.length > 500 ? opts.slice(0, 500) : opts;
                                response($.map(opts, function (opt) { return { label: opt, value: opt } }));
                            });
                    },
                highlight: "highlight-text",
                minLength: ml
            }).on("focus", function () { $(this).trigger("keydown"); });
        },
        error: function (ex) {
            $fieldValue.autocomplete({
                source: function(request, response) {
                    $.getJSON(dataSrcUrl + "/" + request.term,
                        request,
                        function(opts) {
                            opts = opts && opts.length > 500 ? opts.slice(0, 500) : opts;
                            response($.map(opts, function(opt) { return { label: opt, value: opt } }));
                        });
                },
                highlight: "highlight-text",
                minLength: 1
            }).on("focus", function() { $(this).trigger("keydown"); });

            //window.msg.init("error", "Error... . . !", "Failed to load option list. " + ex.error);
        },
        //complete: $("#busy-indicator").fadeOut(150)
    });
    return false;
}
