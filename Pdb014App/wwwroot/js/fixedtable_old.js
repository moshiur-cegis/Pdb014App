/*!
 * jquery.fixedHeaderTable. The jQuery fixedHeaderTable plugin
 *
 * Copyright (c) 2013 Mark Malek
 * http://fixedheadertable.com
 *
 * Licensed under MIT
 * http://www.opensource.org/licenses/mit-license.php
 *
 * http://docs.jquery.com/Plugins/Authoring
 * jQuery authoring guidelines
 *
 * Launch  : October 2009
 * Version : 1.3
 * Released: May 9th, 2011
 * 
 * all CSS sizing (width,height) is done in pixels (px)
 * 
 * for Multi/Complex Header
 * Edit by: Md. Abdul Hadi 
 * CEGIS
 * http://www.cegisbd.com/
 * Last Update: 23.12.2018
 */

(function ($) {

    $.fn.fixedHeaderTable = function (method) {
        var defaults = {
            width: '100%',
            height: '100%',
            themeClass: 'fht-default',
            borderCollapse: true,
            fixedColumns: 0,
            fixedColumn: false,
            altClass: 'alt',
            sortable: false,
            autoShow: true,
            footer: false,
            cloneHeadToFoot: false,
            removableTags: 'form, input, textarea, select, button, optgroup, option, datalist, *[id], *[type="hidden"], .input',
            autoResize: false,
            create: null
        };

        var settings = {};

        var methods = {
            init: function (options) {
                if ($(this).width() <= $(this).closest('div').width() && $(this).height() <= $(this).closest('div').height()) {
                    $(this).css('margin', 'auto');

                    $(this).find('tbody tr:even:not(:hidden)').addClass(defaults.altClass);
                    return;
                }

                settings = $.extend({}, defaults, options);

                return this.each(function () {
                    var $self = $(this);

                    if (helpers._isTable($self)) {
                        methods.setup.apply(this, Array.prototype.slice.call(arguments, 1));
                        $.isFunction(settings.create) && settings.create.call(this);
                    } else {
                        $.error('Invalid table mark-up');
                    }
                });
            },
            setup: function () {
                if ($(this).width() <= $(this).closest('div').width() && $(this).height() <= $(this).closest('div').height()) {
                    $(this).css('margin', 'auto');
                    return;
                }

                var $self = $(this),
                        self = this,
                        $thead = $self.find('thead'),
                        $tfoot = $self.find('tfoot'),
                        $wrapper,
                        $divHead,
                        $divBody,
                        $fixedBody,
                        selfWidth = 0,
                        tbodyHeight = 0,
                        tbodyWrapHeight = 0,
                        tfootHeight = 0;

                var $orgTable = $self.clone();
                $orgTable.find(settings.removableTags).remove();

                settings.originalTable = $orgTable;
                settings.includePadding = helpers._isPaddingIncludedWithWidth();
                settings.scrollbarOffset = helpers._hasScrollBar($self.parent()) ? helpers._getScrollbarWidth() : 0;
                settings.themeClassName = settings.themeClass;

                if (!$self.closest('.fht-table-wrapper').length) {
                    $self.addClass('fht-table');
                    $self.wrap('<div class="fht-table-wrapper"></div>');
                }

                $wrapper = $self.closest('.fht-table-wrapper');

                if (settings.fixedColumn == true && settings.fixedColumns < 1) {
                    settings.fixedColumns = 1;
                }
                if (settings.fixedColumns > 0 && $wrapper.find('.fht-fixed-column').length == 0) {
                    $self.wrap('<div class="fht-fixed-body"></div>');
                    $('<div class="fht-fixed-column"></div>').prependTo($wrapper);
                    $fixedBody = $wrapper.find('.fht-fixed-body');
                }
                $wrapper.css({width: settings.width, height: settings.height}).addClass(settings.themeClassName);

                if (settings.width.search && settings.width.search('%') > -1) {
                    selfWidth = $self.parent().width() - settings.scrollbarOffset;
                } else {
                    selfWidth = settings.width - settings.scrollbarOffset;
                }
                if (selfWidth > 0)
                    $self.css({width: selfWidth});

                if (!$self.hasClass('fht-table-init')) {
                    $self.wrap('<div class="fht-tbody"></div>');
                }

                $divBody = $self.closest('.fht-tbody');
                var tableProps = helpers._getTableProps($self);
                helpers._setupClone($divBody, tableProps.thead);

                if (!$self.hasClass('fht-table-init')) {
                    if (settings.fixedColumns > 0) {
                        $divHead = $('<div class="fht-thead"><table class="fht-table"></table></div>').prependTo($fixedBody);
                    } else {
                        $divHead = $('<div class="fht-thead"><table class="fht-table"></table></div>').prependTo($wrapper);
                    }
                    $divHead.find('table.fht-table')
                            .addClass(settings.originalTable.attr('class'))
                            .attr('style', settings.originalTable.attr('style'));
                    $thead.clone().appendTo($divHead.find('table'));
                } else {
                    $divHead = $wrapper.find('div.fht-thead');
                }

                helpers._setupClone($divHead, tableProps.thead);
                //$self.css({marginTop: -$divHead.outerHeight(true) - (($divHead.find('tr').length + 1) * tableProps.border)});
                $self.css({marginTop: -$divHead.outerHeight(true)});

                $divHead.find('.fht-table').css({height: $divHead.outerHeight(true), marginRight: settings.scrollbarOffset});
                if (settings.footer == true) {
                    helpers._setupTableFooter($self, self, tableProps);
                    if (!$tfoot.length) {
                        $tfoot = $wrapper.find('div.fht-tfoot table');
                    }
                    tfootHeight = $tfoot.outerHeight(true);
                }

                tbodyHeight = $divBody.find('.fht-table tbody').outerHeight(true) + settings.scrollbarOffset;
                tbodyWrapHeight = $wrapper.height() - $thead.outerHeight(true) - tfootHeight - tableProps.border;
                if (tbodyWrapHeight > tbodyHeight - 10) {
                    tbodyWrapHeight = tbodyHeight + 3;
                }
                $divBody.css({height: tbodyWrapHeight});

                $self.addClass('fht-table-init');

                if (typeof (settings.altClass) !== 'undefined') {
                    methods.altRows.apply(self);
                }
                if (typeof (settings.selectClass) !== 'undefined') {
                    methods.selectRow.apply(self);
                }
                if (settings.fixedColumns > 0) {
                    helpers._setupFixedColumn($self, self, tableProps);
                }
                if (!settings.autoShow) {
                    $wrapper.hide();
                }
                helpers._bindScroll($divBody);

                return self;
            },
            resize: function () {
                var self = this;
                return self;
            },
            altRows: function (arg1) {
                var $self = $(this),
                        altClass = (typeof (arg1) !== 'undefined') ? arg1 : settings.altClass;

                $self.closest('.fht-table-wrapper').find('tbody tr:even:not(:hidden)').addClass(altClass);
            },
            selectRow: function (arg1) {
                var $self = $(this),
                        selectClass = (typeof (arg1) !== 'undefined') ? arg1 : settings.selectClass;

                $self.closest('.fht-table-wrapper').find('tbody tr').on('click', function () {
                    $self.closest('.fht-table-wrapper').find('tbody tr').removeClass(selectClass);
                    $(this).addClass(selectClass);
                });
            },
            show: function (arg1, arg2, arg3) {
                var $self = $(this),
                        self = this,
                        $wrapper = $self.closest('.fht-table-wrapper');

                if (typeof (arg1) !== 'undefined' && typeof (arg1) === 'number') {
                    $wrapper.show(arg1, function () {
                        $.isFunction(arg2) && arg2.call(this);
                    });
                    return self;
                } else if (typeof (arg1) !== 'undefined' && typeof (arg1) === 'string' &&
                        typeof (arg2) !== 'undefined' && typeof (arg2) === 'number') {
                    $wrapper.show(arg1, arg2, function () {
                        $.isFunction(arg3) && arg3.call(this);
                    });
                    return self;
                }

                $self.closest('.fht-table-wrapper').show();
                $.isFunction(arg1) && arg1.call(this);

                return self;
            },
            hide: function (arg1, arg2, arg3) {
                var $self = $(this),
                        self = this,
                        $wrapper = $self.closest('.fht-table-wrapper');

                if (typeof (arg1) !== 'undefined' && typeof (arg1) === 'number') {
                    $wrapper.hide(arg1, function () {
                        $.isFunction(arg3) && arg3.call(this);
                    });

                    return self;
                } else if (typeof (arg1) !== 'undefined' && typeof (arg1) === 'string' &&
                        typeof (arg2) !== 'undefined' && typeof (arg2) === 'number') {

                    $wrapper.hide(arg1, arg2, function () {
                        $.isFunction(arg3) && arg3.call(this);
                    });

                    return self;
                }

                $self.closest('.fht-table-wrapper').hide();
                $.isFunction(arg3) && arg3.call(this);

                return self;
            },
            destroy: function () {
                var $self = $(this),
                        self = this,
                        $wrapper = $self.closest('.fht-table-wrapper');

                $self.insertBefore($wrapper)
                        .removeAttr('style')
                        .append($wrapper.find('tfoot'))
                        .removeClass('fht-table fht-table-init')
                        .find('.fht-cell')
                        .remove();

                $wrapper.remove();
                return self;
            }
        };

        var helpers = {
            _isTable: function ($obj) {
                var $self = $obj,
                        hasTable = $self.is('table'),
                        hasThead = $self.find('thead').length > 0,
                        hasTbody = $self.find('tbody').length > 0;

                if (hasTable && hasThead && hasTbody) {
                    return true;
                }
                return false;
            },
            _bindScroll: function ($obj) {
                var $self = $obj,
                        $wrapper = $self.closest('.fht-table-wrapper'),
                        $thead = $self.siblings('.fht-thead'),
                        $tfoot = $self.siblings('.fht-tfoot');

                $self.on('scroll', function () {
                    if (settings.fixedColumns > 0) {
                        $wrapper.find('.fht-fixed-column').find('.fht-tbody table').css({marginTop: -$self.scrollTop()});
                    }
                    $thead.find('table').css({marginLeft: -this.scrollLeft});

                    if (settings.footer || settings.cloneHeadToFoot) {
                        $tfoot.find('table').css({marginLeft: -this.scrollLeft});
                    }
                });
            },
            _fixMultiHeightWithCss: function ($obj, border) {
                var tdHeights = [];
                $obj.each(function (tdIndex) {
                    tdHeights[tdIndex] = (settings.includePadding)
                            ? (Math.round($(this).height() * 100) / 100) + border
                            : (Math.round($(this).outerHeight() * 100) / 100) + border;
                });
                $obj.each(function (tdIndex) {
                    $(this).css('height', tdHeights[tdIndex]);
                });
            },
            _fixMultiWidthWithCss: function ($obj, border, fix_widths) {
                var tdWidths = [];
                if (!fix_widths || !$.isArray(fix_widths)) {
                    $obj.each(function (tdIndex) {
                        tdWidths[tdIndex] = (settings.includePadding)
                                ? (Math.round($(this).width() * 100) / 100) + border
                                : (Math.round($(this).outerWidth() * 100) / 100) + border;
                    });
                } else {
                    $obj.each(function (tdIndex) {
                        tdWidths[tdIndex] = $.isNumeric(fix_widths[tdIndex])
                                ? fix_widths[tdIndex] + border
                                : ((settings.includePadding)
                                        ? (Math.round($(this).width() * 100) / 100) + border
                                        : (Math.round($(this).outerWidth() * 100) / 100) + border);
                    });
                }

                $obj.each(function (tdIndex) {
                    var $cell = ($(this).find('div.fht-cell').length) ? $(this).find('div.fht-cell')
                            : $('<div class="fht-cell"></div>').appendTo($(this));

                    $cell.css('width', tdWidths[tdIndex]);
                });
            },
            _setupFixedColumn: function ($obj, obj, tableProps) {

                var $self = $obj,
                        $wrapper = $self.closest('.fht-table-wrapper'),
                        $fixedBody = $wrapper.find('.fht-fixed-body'),
                        $fixedColumn = $wrapper.find('.fht-fixed-column'),
                        $fixedHeadColumns = null,
                        $thead = $('<div class="fht-thead"><table class="fht-table"><thead></thead></table></div>'),
                        $tbody = $('<div class="fht-tbody"><table class="fht-table"><tbody></tbody></table></div>'),
                        $tfoot = $('<div class="fht-tfoot"><table class="fht-table"><tfoot><tr></tr></tfoot></table></div>'),
                        bodyHeight = $fixedBody.find('.fht-tbody .fht-table tbody').height() + 1,
                        fixedBodyWidth = $wrapper.width(),
                        fixedBodyHeight = $fixedBody.find('.fht-tbody').height() - settings.scrollbarOffset + 1,
                        fixedColumnWidth = 0,
                        fixedHeadHeight = 0,
                        $newRow,
                        $newThs,
                        $newTds;

                $thead.find('table.fht-table').addClass(settings.originalTable.attr('class'));
                $tbody.find('table.fht-table').addClass(settings.originalTable.attr('class'));
                $tfoot.find('table.fht-table').addClass(settings.originalTable.attr('class'));

                var tdWidths = [], rowColumnCount = [], rowColumnOffset = [], currColumns, fixedColumns, maxColumns, trMaxIndex;

                rowColumnOffset[0] = 0;
                fixedColumns = settings.fixedColumns;

                $fixedBody.find('.fht-thead thead > tr').each(function (trIndex) {
                    currColumns = fixedColumns + ($.isNumeric(rowColumnOffset[trIndex]) ? rowColumnOffset[trIndex] : 0);
                    rowColumnCount[trIndex] = currColumns;

                    if (currColumns < 1) {
                        return false;
                    }
                    if (fixedColumns >= currColumns) {
                        maxColumns = fixedColumns;
                        trMaxIndex = trIndex;
                    }
                    fixedColumns = 0;
                    fixedColumnWidth = 0;
                    tdWidths[trIndex] = [];
                    $(this).find('td:lt(' + currColumns + '), th:lt(' + currColumns + ')').each(function (thIndex) {
                        var colSpan = ($(this).attr('colSpan') ? parseInt($(this).attr('colSpan')) : 1);
                        var rowSpan = ($(this).attr('rowSpan') ? parseInt($(this).attr('rowSpan')) : 1);
                        if (rowSpan > 1) {
                            for (var ri = 1; ri < rowSpan; ri++) {
                                rowColumnOffset[trIndex + ri] = $.isNumeric(rowColumnOffset[trIndex + ri])
                                        ? rowColumnOffset[trIndex + ri] - colSpan : -colSpan;
                            }
                        }

                        fixedColumns += colSpan;
                        fixedColumnWidth += $(this).outerWidth(true);
                        tdWidths[trIndex][thIndex] = $(this).width();
                    });
                });

                if (maxColumns > 0) {
                    fixedColumnWidth += 1;
                    //fixedColumnWidth += (tableProps.border > 0) ? (maxColumns * tableProps.border) : 1;
                }

                $fixedBody.find('.fht-thead thead > tr').each(function (trIndex) {
                    $fixedHeadColumns = $(this).find('td:lt(' + rowColumnCount[trIndex] + '), th:lt(' + rowColumnCount[trIndex] + ')');

                    if ($fixedHeadColumns.length > 0) {
                        helpers._fixMultiWidthWithCss($fixedHeadColumns, tableProps.border);
                        helpers._fixMultiHeightWithCss($fixedHeadColumns, tableProps.border);
                    }

                    $newRow = $('<tr></tr>').appendTo($thead.find('thead'));
                    $newThs = $fixedHeadColumns.clone();
                    $newThs.find(settings.removableTags).remove();
                    $newThs.appendTo($newRow);
                });

                fixedHeadHeight = $fixedBody.find('.fht-thead .fht-table').height() + 1;
                //$fixedColumn.find('.fht-thead .fht-table').css({width: fixedColumnWidth, height: fixedHeadHeight});

                $fixedColumn.css({width: fixedColumnWidth});
                $thead.find('.fht-table').css({width: fixedColumnWidth, height: fixedHeadHeight});
                $thead.appendTo($fixedColumn);

                $fixedHeadColumns = $fixedBody.find('.fht-tbody tbody > tr:first > td:lt(' + rowColumnCount[trMaxIndex] + ')');
                if ($fixedHeadColumns.length > 0) {
                    helpers._fixMultiWidthWithCss($fixedHeadColumns, tableProps.border, tdWidths[trMaxIndex]);
                }

                $fixedHeadColumns = $fixedBody.find('.fht-tbody tbody > tr > td:nth-child(' + rowColumnCount[trMaxIndex] + ')');
                if ($fixedHeadColumns.length > 0) {
                    helpers._fixMultiHeightWithCss($fixedHeadColumns, tableProps.border);
                }

                $fixedBody.find('.fht-tbody tbody > tr').each(function (trIndex) {
                    $fixedHeadColumns = $(this).find('td:lt(' + rowColumnCount[trMaxIndex] + ')');

                    $newRow = $('<tr></tr>').appendTo($tbody.find('tbody'));
                    if (settings.altClass && $(this).hasClass(settings.altClass)) {
                        $newRow.addClass(settings.altClass);
                    }

                    $newTds = $fixedHeadColumns.clone();
                    $newTds.find(settings.removableTags).remove();
                    $newTds.appendTo($newRow);
                });

                $tbody.appendTo($fixedColumn).css({marginTop: -1, width: fixedColumnWidth, height: fixedBodyHeight});
                // set width of fixed column wrapper
                $fixedColumn.css({width: fixedColumnWidth, height: 'auto'});

                if (bodyHeight > $fixedColumn.find('.fht-tbody .fht-table').height()) {
                    $fixedColumn.find('.fht-tbody .fht-table').css({width: fixedColumnWidth, height: bodyHeight});
                }
                var maxTop = $fixedColumn.find('.fht-tbody .fht-table').height() - $fixedColumn.find('.fht-tbody').height();
                $fixedColumn.find('.fht-tbody .fht-table').on('mousewheel DOMMouseScroll', function (evt) {
                    evt.preventDefault();
                    evt = evt.originalEvent;
                    var scrollOffset = parseInt($(this).css('margin-top'), 10);
                    scrollOffset += $.isNumeric(evt.wheelDelta) ? evt.wheelDelta
                            : ($.isNumeric(evt.detail) ? (evt.detail * -40) : 0);
                    scrollOffset = (scrollOffset > 0) ? 0 : ((scrollOffset < -maxTop) ? -maxTop : scrollOffset);

                    $(this).css('margin-top', scrollOffset);
                    $fixedBody.find('.fht-tbody').scrollTop(-scrollOffset).scroll();
                    return false;
                });

                // set width of body table wrapper
                $fixedBody.css({width: fixedBodyWidth});
                // setup clone footer with fixed column
                if (settings.footer == true || settings.cloneHeadToFoot == true) {
                    var $firstTdFootChild = $fixedBody.find('.fht-tfoot tr > *:lt(' + settings.fixedColumns + ')'),
                            footwidth;
                    helpers._fixMultiHeightWithCss($firstTdFootChild, tableProps.border);
                    $tfoot.appendTo($fixedColumn).find('tr').append($firstTdFootChild.clone());
                    // Set (view width) of $tfoot div to width of table (this accounts for footers with a colspan)
                    footwidth = $tfoot.find('table').innerWidth();
                    $tfoot.css({top: settings.scrollbarOffset, width: footwidth});
                }
            },
            /*
             * return void
             */
            _setupTableFooter: function ($obj, obj, tableProps) {
                var $self = $obj,
                        $wrapper = $self.closest('.fht-table-wrapper'),
                        $tfoot = $self.find('tfoot'),
                        $divFoot = $wrapper.find('div.fht-tfoot');
                if (!$divFoot.length) {
                    if (settings.fixedColumns > 0) {
                        $divFoot = $('<div class="fht-tfoot"><table class="fht-table"></table></div>')
                                .appendTo($wrapper.find('.fht-fixed-body'));
                    } else {
                        $divFoot = $('<div class="fht-tfoot"><table class="fht-table"></table></div>').appendTo($wrapper);
                    }
                }
                $divFoot.find('table.fht-table').addClass(settings.originalTable.attr('class'));
                switch (true) {
                    case !$tfoot.length && settings.cloneHeadToFoot == true && settings.footer == true:
                        var $divHead = $wrapper.find('div.fht-thead');
                        $divFoot.empty();
                        $divHead.find('table').clone().appendTo($divFoot);
                        break;

                    case $tfoot.length && settings.cloneHeadToFoot == false && settings.footer == true:
                        $divFoot.find('table').append($tfoot).css({marginTop: -tableProps.border});
                        helpers._setupClone($divFoot, tableProps.tfoot);
                        break;
                }
            },
            /*
             * return object
             * Widths of each thead cell and tbody cell for the first rows.
             * Used in fixing widths for the fixed header and optional footer.
             */
            _getTableProps: function ($obj) {
                var tableProp = {
                    thead: {},
                    tbody: {},
                    tfoot: {},
                    border: 0
                }, borderCollapse = 1;

                if (settings.borderCollapse == true) {
                    borderCollapse = 2;
                }

                tableProp.border = parseInt(($obj.find('th:first-child').outerWidth() - $obj.find('th:first-child').innerWidth()) / borderCollapse, 10);

                $obj.find('thead tr').each(function (trIndex) {
                    tableProp.thead[trIndex] = [];
                    $(this).find('td, th').each(function (thIndex) {
                        tableProp.thead[trIndex][thIndex] = (Math.round($(this).width() * 100) / 100) + tableProp.border;
                        //tableProp.thead[trIndex][thIndex] = $(this).width() + tableProp.border;
                    });
                });
                return tableProp;
            },

            /*
             * return void
             * Fix widths of each cell in the first row of obj.
             */
            _setupClone: function ($obj, thWidths) {
                var $cell;
                $obj.find('thead tr').each(function (trIndex) {
                    $(this).find('td, th').each(function (thIndex) {
                        $cell = ($(this).find('div.fht-cell').length) ? $(this).find('div.fht-cell')
                                : $('<div class="fht-cell"></div>').appendTo($(this));
                        $cell.css('width', thWidths[trIndex][thIndex]);
                    });
                });
            },

            /*
             * return boolean
             * Determine how the browser calculates fixed widths with padding for tables
             * true if width = padding + width
             * false if width = width
             */
            _isPaddingIncludedWithWidth: function () {
                var $obj = $('<table class="fht-table"><tr><td style="padding:10px; font-size:10px;">test</td></tr></table>'),
                        defaultHeight,
                        newHeight;

                $obj.addClass(settings.originalTable.attr('class'));
                $obj.appendTo('body');

                defaultHeight = $obj.find('td').height();

                $obj.find('td').css({height: $obj.find('tr').height()});

                newHeight = $obj.find('td').height();
                $obj.remove();

                return (defaultHeight != newHeight);
            },
            /*
             * return bool
             * get the element scroll bar exist or not
             */
            _hasScrollBar: function (el, direction) {
                if (el.get(0))
                    el = el.get(0);
                if (direction && direction === 'vertical')
                    return (el.scrollHeight > el.clientHeight);
                else
                    return (el.scrollWidth > el.clientWidth);
            },
            /*
             * return int
             * get the width of the browsers scroll bar
             */
            _getScrollbarWidth: function () {
                var scrollbarWidth = 0;
                if (!scrollbarWidth) {
                    if (/msie/.test(navigator.userAgent.toLowerCase())) {
                        var $textarea1 = $('<textarea cols="10" rows="2"></textarea>')
                                .css({position: 'absolute', top: -1000, left: -1000}).appendTo('body'),
                                $textarea2 = $('<textarea cols="10" rows="2" style="overflow: hidden;"></textarea>')
                                .css({position: 'absolute', top: -1000, left: -1000}).appendTo('body');

                        scrollbarWidth = $textarea1.width() - $textarea2.width() + 2; // + 2 for border offset
                        $textarea1.add($textarea2).remove();
                    } else {
                        var $div = $('<div />').css({width: 100, height: 100, overflow: 'auto', position: 'absolute', top: -1000, left: -1000})
                                .prependTo('body').append('<div />').find('div').css({width: '100%', height: 200});

                        scrollbarWidth = 100 - $div.width();
                        $div.parent().remove();
                    }
                }
                return scrollbarWidth;
            }

        };

        // if a method as the given argument exists
        if (methods[method]) {
            // call the respective method
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
            // if an object is given as method OR nothing is given as argument
        } else if (typeof method === 'object' || !method) {
            // call the initialization method
            return methods.init.apply(this, arguments);
            // otherwise
        } else {
            // trigger an error
            $.error('Method "' + method + '" does not exist in fixedHeaderTable plugin!');
        }
    };

})(jQuery);
