App = {};

App.Common = (function () {
    function getSortedColumn(data_tbl_id) {
        var columnIndex = $('#' + data_tbl_id).dataTable().fnSettings().aaSorting[0][0];
        return $('#' + data_tbl_id).dataTable().fnSettings().aoColumns[columnIndex].data;
    }

    function getValueFromArray(aoData, Key) {
        for (i = 0; i < aoData.length; i++) {
            if (aoData[i].name == Key) {
                if (Key == 'sSearch') {
                    if ($('.dataTables_filter_custom').length > 0)
                        return $('.dataTables_filter_custom').val() + ':' + aoData[i].value;
                    else
                        return '' + ':' + aoData[i].value;
                }
                else {
                    return aoData[i].value;
                }
            }
        }
    }

    function addRemoveSearch(searchExp, elementId, elementValue, bIgnore) {
        if (searchExp == null || searchExp == '') {
            if (bIgnore || elementValue.length > 2)
                return elementId + ':' + elementValue;
            else
                return null;
        }

        var sSearch = null;
        var aSearchExps = searchExp.split('|');
        var aNewSearchExps = $.grep(aSearchExps, function (arrE, idx) {
            return (arrE != '' && arrE.substring(0, elementId.length) != elementId);
        });

        if (bIgnore || elementValue.length > 2) {
            aNewSearchExps.push(elementId + ':' + elementValue)
        }

        sSearch = aNewSearchExps.join('|');

        return (typeof sSearch == 'undefined' || sSearch == '') ? null : sSearch;
    }

    return {
        Init: function () {
        },

        LoadDatatableFromAjax: function (data_tbl_id, ajaxSrc, cols) {
            var dtSearchValue = null;
            var tbl_ach_details = $('#' + data_tbl_id).DataTable({
                'paging': true,
                'orderCellsTop': true,
                'bProcessing': true,
                'bInfo': false,
                'bLengthChange': false,
                'sPaginationType': 'full_numbers',
                'bServerSide': true,
                'searching': true,
                'sAjaxSource': ajaxSrc,
                'dom': 'lrtip', //hiding global search box
                'fnServerData': function (sSource, aoData, fnCallback) {
                    var inputData = {
                        'sEcho': getValueFromArray(aoData, 'sEcho'),
                        'sSearch': dtSearchValue,
                        'iDisplayLength': getValueFromArray(aoData, 'iDisplayLength'),
                        'iDisplayStart': getValueFromArray(aoData, 'iDisplayStart'),
                        'iColumns': getValueFromArray(aoData, 'iColumns'),
                        'iSortingCols': getValueFromArray(aoData, 'iSortingCols'),
                        'sColumns': getValueFromArray(aoData, 'sColumns'),
                        'sColSort': getSortedColumn(data_tbl_id),
                        'sSortOrder': getValueFromArray(aoData, 'sSortDir_0'),
                    }
                    logsRequest = $.ajax({
                        type: 'GET',
                        url: sSource,
                        data: inputData,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        success: function (data) {
                            fnCallback(data);
                        },
                        error: function (xhr, error, thrown) {
                            alert('You are not logged in');
                        }
                    });
                },
                'aoColumns': cols,
                'lengthMenu': [[10, 25, 50, -1], [10, 25, 50, 'All']]
            });

            $('#' + data_tbl_id + ' thead tr#dt_search input').on('keyup change', function () {
                var all = (dtSearchValue == null);
                var element = $(this);
                var value = element.val();
                if (typeof value != 'undefined') {
                    dtSearchValue = addRemoveSearch(dtSearchValue, $(this).attr('id'), value, false);
                }
                else {
                    dtSearchValue = null;
                }

                if (dtSearchValue == null && all) {
                    return;
                }

                tbl_ach_details.column($(this).parent().index() + ':visible').search(this.value).draw();
            });

            $('#' + data_tbl_id + ' thead tr#dt_search select').on('change', function () {
                var all = (dtSearchValue == null);
                var element = $(this);
                var value = element.val();
                if (typeof value != 'undefined') {
                    dtSearchValue = addRemoveSearch(dtSearchValue, $(this).attr('id'), value, true);
                }
                else {
                    dtSearchValue = null;
                }

                if (dtSearchValue == null && all) {
                    return;
                }
                tbl_ach_details.column($(this).parent().index() + ':visible').search(this.value).draw();
            });
        }
    }
})();