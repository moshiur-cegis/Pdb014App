/*!
 * multi.checkbox.tree, The jQuery Multi Checkbox with Tree style plugin
 *
 * Copyright (c) 2018 Md. Abdul Hadi
 * CEGIS
 * http://www.cegisbd.com/
 *
 * Licensed under MIT
 * http://www.opensource.org/licenses/mit-license.php
 *
 * http://docs.jquery.com/Plugins/Authoring
 * jQuery authoring guidelines
 *
 * Launch  : October 2017
 * Version : 1.3
 * Released: May 13th, 2018
 *
 */

$('span.multi-item').on('click',
    function (e) {
        e.preventDefault();
        e.stopPropagation();

        if ($(this).hasClass('active')) {
            $(this).closest("li").find("ul").slideUp(250);
            $(this).removeClass('active');
        } else {
            $(this).closest("li").find("ul").slideDown(250);
            $(this).addClass('active');
        }
        return false;
    });


function OpenCloseAll(obj, opt) {
    if ($(obj).closest("fieldset").find("ul ul[id^='field_list_']")) {
        if (opt) {
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']").slideDown(250);
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']")
                .closest("li").find("span.multi-item").addClass('active');
        } else {
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']").slideUp(250);
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']")
                .closest("li").find("span.multi-item").removeClass('active');
        }
    }
    return false;
}

function CheckAllMultiCheckBox(obj) {
    $(obj).closest("fieldset").find("input[type='checkbox'].multi-checkbox")
        .prop("indeterminate", false)
        .prop("checked", $(obj).prop("checked"));

    if ($(obj).closest("fieldset").find("ul ul[id^='field_list_']")) {
        if ($(obj).prop("checked")) {
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']").slideDown(250);
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']")
                .closest("li").find("span.multi-item").addClass('active');
        } else {
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']").slideUp(250);
            $(obj).closest("fieldset").find("ul ul[id^='field_list_']")
                .closest("li").find("span.multi-item").removeClass('active');
        }
    }
}

function CheckMultiCheckBox(obj) {
    var optChecked = null,
        objChecked = $(obj).prop("checked"),
        $chkbParent = $(obj).closest("fieldset"),
        noOfCheckBoxes = $chkbParent.find("input[type='checkbox'].multi-checkbox").length;

    //// for Sub-CheckBoxes ///////
    var chkbName = $(obj).attr("data-field-name"),
        chkbGroup = $(obj).attr("data-field-group");

    if (chkbName.indexOf("group") == 0 && chkbGroup == "" && $chkbParent.find("ul[id$='" + chkbName + "']")) {
        var $chkbGropuParentUl = $chkbParent.find("ul[id$='" + chkbName + "']");

        if (objChecked) {
            $chkbGropuParentUl.slideDown(250);
            $chkbGropuParentUl.closest("li").find("span.multi-item").addClass('active');

            $chkbGropuParentUl.find("input[type='checkbox'].multi-checkbox").prop("checked", true);
        } else {
            $chkbGropuParentUl.slideUp(250);
            $chkbGropuParentUl.closest("li").find("span.multi-item").removeClass('active');

            $chkbGropuParentUl.find("input[type='checkbox'].multi-checkbox").prop("checked", false);
        }
    } else if (chkbGroup && chkbGroup != "" && $(obj).closest("ul[id$='" + chkbGroup + "']")) {

        var $chkbGropuUl = $(obj).closest("ul[id$='" + chkbGroup + "']"),
            noOfCheckBoxesUl = $chkbGropuUl.find("input[type='checkbox'].multi-checkbox").length;

        optChecked = null;
        if (objChecked) {
            var noOfCheckedBoxesUl = $chkbGropuUl.find("input[type='checkbox']:checked.multi-checkbox").length;
            if (noOfCheckedBoxesUl === 0) {
                optChecked = false;
            }
            if (noOfCheckedBoxesUl === noOfCheckBoxesUl) {
                optChecked = true;
            }
        } else {
            var noOfUnCheckedBoxesUl =
                $chkbGropuUl.find("input[type='checkbox'].multi-checkbox:not(:checked)").length;

            if (noOfUnCheckedBoxesUl === 0) {
                optChecked = true;
            }
            if (noOfUnCheckedBoxesUl === noOfCheckBoxesUl) {
                optChecked = false;
            }
        }

        $chkbParent.find("input[type='checkbox'][data-field-name='" + chkbGroup + "']")
            .prop("indeterminate", optChecked === null)
            .prop("checked", optChecked);

        if (optChecked === false) {
            $chkbGropuUl.slideUp(250);
            $chkbGropuUl.closest("li").find("span.multi-item").removeClass('active');
        } else {
            $chkbGropuUl.slideDown(250);
            $chkbGropuUl.closest("li").find("span.multi-item").addClass('active');
        }
    }
    //// end Sub-CheckBoxes ///////


    optChecked = null;
    if (objChecked) {
        var noOfCheckedBoxes = $chkbParent
            .find("input[type='checkbox']:checked.multi-checkbox").length;
        if (noOfCheckedBoxes === 0) {
            optChecked = false;
        }
        if (noOfCheckedBoxes === noOfCheckBoxes) {
            optChecked = true;
        }
    } else {
        var noOfUnCheckedBoxes = $chkbParent
            .find("input[type='checkbox'].multi-checkbox:not(:checked)").length;
        if (noOfUnCheckedBoxes === 0) {
            optChecked = true;
        }
        if (noOfUnCheckedBoxes === noOfCheckBoxes) {
            optChecked = false;
        }
    }

    $chkbParent.find("input[type='checkbox'].all-checked")
        .prop("indeterminate", optChecked === null)
        .prop("checked", optChecked);

    return false;
}

