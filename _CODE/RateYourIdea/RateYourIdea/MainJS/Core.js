/// <reference path="../datatables/datatables.min.js" />

/**
 * jquery.js required
 * For Default Panel MainCSS/DefaultLoadingPanel.css required
 * For DataTable DataTables Folder required
 * 
 * @param {object} options Init model for Core
 * @param {object} options.loadingPanel Init model for Loading Panel
 * @param {string} options.loadingPanel.loadingPanelTemp Optional parameter for modifying the loadingPanel
 * @param {string} options.loadingPanel.loadingPanelid Optional parameter for loadingPanel Selector id, needs to be set if options.loadingPanel.loadingPanelTemp has set (Valuable only if loadingPanelTemp.loadingPanelTemp parameter has set)
 * @param {string} options.loadingPanel.loadingMessage Optional parameter for loadingPanel message (If it needed to be setted in to setted options.loadingPanelTemp, setted options.loadingPanelTemp needs to have "#LOADING" parameter inside template.)
 * @param {object} options.toaster Init model for Toaster
 * @param {string} options.toaster.toasterTemp Optional parameter for modifying the Toaster
 * @param {string} options.toaster.toasterid Optional parameter for Toaster Selector id, needs to be set if options.toaster.toasterTemp has set (Valuable only if toaster.toasterTemp parameter has set)
 * @param {string} options.toaster.toasterMessageid Optional parameter for Toaster Message Selector id, needs to be set if options.toaster.toasterTemp has set (Valuable only if toaster.toasterTemp parameter has set)
 * @param {number} options.toaster.fadeInTime Optional parameter for Toaster fade in time
 * @param {number} options.toaster.fadeOutTime Optional parameter for Toaster fade out time
 * @param {number} options.toaster.showTime Optional parameter for Toaster show time
 * @param {Array} options.toaster.type Optional parameter for Toaster Type
 * @param {function} options.toaster.typeFunction Optional parameter for Toaster Temp Edit Function
 * @param {boolean} options.toaster.automaticClose Optional parameter for Toaster Close Action
 */
var Core = function (options) {

    const core = {};

    var toasterIntervalID = null;

    var opt = {
        loadingPanel: {
            loadingPanelTemp: [`<div id="loading-wrapper">
                                  <div id="loading-text">#LOADING</div>
                                  <div id="loading-content"></div>
                                </div>`].join(),
            loadingPanelid: "loading-wrapper",
            loadingMessage: "Loading.."
        },
        toaster: {
            toasterTemp: [`<div id="toast2" style="position:fixed; top:80px; right:10px; opacity:1; display:none; width: 350px; padding: 18px; background-color: #17c0eb; border-radius: 7px; color: white;">
                                <div class="toast2-header">
                                    <strong class="mr-auto"></strong>
                                    <small class="text-muted"></small>
                                </div>
                                <div id="toast2-body">
                                </div>
                                <div class="completion-bar" style="height:4px; border-radius:14px; margin-top:10px; width:0%"></div>
                           </div>`].join(),
            toasterid: "toast2",
            toasterMessageid: "toast2-body",
            fadeInTime: 500,
            fadeOutTime: 2000,
            showTime: 3000,
            type: [],
            typeFunction: function (toastHtml, typeArray, type) {
                switch (type) {
                    case 0:
                        toastHtml.find(".mr-auto").text("Hata");
                        toastHtml.find(".mr-auto").css("color", "#ff4d4d");
                        toastHtml.find(".completion-bar").css("background-color", "#ff4d4d");
                        break;
                    case 1:
                        toastHtml.find(".mr-auto").text("Bilgi");
                        toastHtml.find(".mr-auto").css("color", "#32ff7e");
                        toastHtml.find(".completion-bar").css("background-color", "#32ff7e");
                        break;
                    case 2:
                        toastHtml.find(".mr-auto").text("Uyarı");
                        toastHtml.find(".mr-auto").css("color", "#fffa65");
                        toastHtml.find(".completion-bar").css("background-color", "#fffa65");
                        break;
                    default:
                        break;
                }
            },
            automaticClose: true
        }
    };

    var Init = function () {
        if (options != null && typeof options == typeof {}) {
            if (options.loadingPanel != null && typeof options.loadingPanel == typeof {}) {
                DefineLoadingPanelOptions();
            }
            if (options.toaster != null && typeof options.toaster == typeof {}) {
                DefineToasterOptions();
            }
        }
        core.loadingPanel = LoadingPanel();
    }

    var DefineLoadingPanelOptions = function () {
        opt.loadingPanelTemp.loadingPanelTemp = core.IsNullOrEmpty(options.loadingPanelTemp.loadingPanelTemp) ? opt.loadingPanelTemp.loadingPanelTemp : options.loadingPanelTemp.loadingPanelTemp;
        opt.loadingPanelTemp.loadingPanelid = core.IsNullOrEmpty(options.loadingPanelTemp.loadingPanelTemp) ? opt.loadingPanelTemp.loadingPanelid : (core.IsNullOrEmpty(options.loadingPanelTemp.loadingPanelid) ? $(opt.loadingPanelTemp.loadingPanelTemp).attr("id") : options.loadingPanelTemp.loadingPanelid);
        opt.loadingPanelTemp.loadingMessage = core.IsNullOrEmpty(options.loadingPanelTemp.loadingMessage) ? opt.loadingPanelTemp.loadingMessage : options.loadingPanelTemp.loadingMessage;
        opt.loadingPanelTemp.loadingPanelTemp.replace("#LOADING", opt.loadingPanelTemp.loadingMessage);
    }

    var DefineToasterOptions = function () {
        opt.toaster.toasterTemp = core.IsNullOrEmpty(options.toaster.toasterTemp) ? opt.toaster.toasterTemp : options.toaster.toasterTemp;
        opt.toaster.toasterid = core.IsNullOrEmpty(options.toaster.toasterTemp) ? opt.toaster.toasterid : (core.IsNullOrEmpty(options.toaster.toasterid) ? $(opt.toaster.toasterTemp).attr("id") : options.toaster.toasterid);
        opt.toaster.toasterMessageid = core.IsNullOrEmpty(options.toaster.toasterTemp) ? opt.toaster.toasterMessageid : (core.IsNullOrEmpty(options.toaster.toasterMessageid) ? opt.toaster.toasterMessageid : options.toaster.toasterMessageid);
        opt.toaster.fadeInTime = !options.toaster.fadeInTime ? opt.toaster.fadeInTime : options.toaster.fadeInTime;
        opt.toaster.fadeOutTime = !options.toaster.fadeOutTime ? opt.toaster.fadeOutTime : options.toaster.fadeOutTime;
        opt.toaster.showTime = !options.toaster.showTime ? opt.toaster.showTime : options.toaster.showTime;
        opt.toaster.type = !options.toaster.type && typeof options.toaster.type != typeof [] ? [] : options.toaster.type;
        opt.toaster.typeFunction = !options.toaster.typeFunction ? opt.toaster.typeFunction : options.toaster.typeFunction;
        opt.toaster.automaticClose = options.toaster.automaticClose == null && typeof options.toaster.automaticClose != typeof true ? opt.toaster.automaticClose : options.toaster.automaticClose;
    }

    var LoadingPanel = function () {

        const panel = {};

        panel.Show = function () {
            panel.Close();
            $("body").append(opt.loadingPanelTemp);
        }

        panel.Close = function () {
            var item = $("#" + opt.loadingPanelid);
            if (item.length > 0) {
                item.remove();
            }
        }

        return panel;
    }

    core.Request = function (url, type, data, successCallback, errorCallback, dataType = null) {
        $.ajax({
            url: url,
            type: type,
            data: data,
            dataType: dataType || "json",
            success: function (data) {
                if (typeof (data) === "string") {
                    data = JSON.parse(data)
                }
                successCallback(data);
            },
            error: function (data) {
                coreProcess.Toaster("Bir hata oluştu", 0);
                errorCallback(data);
            }
        });
    }

    /**
     * @deprecated
     * 
     * @param {string} message Sets Toaster message
     * @param {number} type Sets Type of message (Error: 0, Success&Info: 1, Warning: 2)
     */
    core.Toaster = function (message, type) {

        if (toasterIntervalID != null) {
            clearInterval(toasterIntervalID);
            toasterIntervalID = null;
            $('body .toast2').remove();
        }

        var toastString = `<div class="toast2" style="position:fixed; top:80px; right:10px; opacity:1; display:none; width: 350px; padding: 18px; background-color: #17c0eb; border-radius: 7px; color: white;">
                                <div class="toast2-header">
                                    <strong class="mr-auto"></strong>
                                    <small class="text-muted"></small>
                                </div>
                                <div class="toast2-body">
                                </div>
                                <div class="completion-bar" style="height:4px; border-radius:14px; margin-top:10px; width:0%"></div>
                           </div>`;

        var toastHtml = $(toastString);
        toastHtml.find(".toast2-body").text(message);

        switch (type) {
            case 0:
                toastHtml.find(".mr-auto").text("Hata");
                toastHtml.find(".mr-auto").css("color", "#ff4d4d");
                toastHtml.find(".completion-bar").css("background-color", "#ff4d4d");
                break;
            case 1:
                toastHtml.find(".mr-auto").text("Bilgi");
                toastHtml.find(".mr-auto").css("color", "#32ff7e");
                toastHtml.find(".completion-bar").css("background-color", "#32ff7e");
                break;
            case 2:
                toastHtml.find(".mr-auto").text("Uyarı");
                toastHtml.find(".mr-auto").css("color", "#fffa65");
                toastHtml.find(".completion-bar").css("background-color", "#fffa65");
                break;
            default:
                break;
        }
        $("body").append(toastHtml);
        var counter = 0;
        toasterIntervalID = setInterval(function () {
            counter = counter + 10;
            var width = (counter / 5000) * 100;
            if (width > 100) {
                width = 100;
            }
            $(".completion-bar").css("width", width + "%");
        }, 10);

        $('body .toast2').fadeIn(500, () => {

            setTimeout(() => {
                $('body .toast2').fadeOut(2000, () => {
                    clearInterval(toasterIntervalID);
                    $('body .toast2').remove();
                    toasterIntervalID = null;
                });
            }, 3000);

        });
    }

    /**
     * 
     * @param {string} message Sets Toaster message
     * @param {number} type Sets Type of message (Error: 0, Success&Info: 1, Warning: 2 For Default)
     * @param {function} beforeShowToastHtml Enables functions before Toaster show, returns Toaster Template's Jquery referance
     * @param {function} afterShowToastHtml Enables functions after Toaster close
     */
    core.Toast = function (message, type, beforeShowToastHtml, afterShowToastHtml) {

        const instance = {};

        if (toasterIntervalID != null) {
            closeToast();
        }

        var toastHtml = $(opt.toaster.toasterTemp);
        toastHtml.find("#" + opt.toaster.toasterMessageid).text(message);
        if (beforeShowToastHtml) {
            beforeShowToastHtml(toastHtml);
        }

        opt.toaster.typeFunction(toastHtml, opt.toaster.type, type);

        $("body").append(toastHtml);
        var counter = 0;
        toasterIntervalID = setInterval(function () {
            counter = counter + 10;
            var width = (counter / (opt.toaster.showTime + opt.toaster.fadeOutTime)) * 100;
            if (width > 100) {
                width = 100;
            }
            $(".completion-bar").css("width", width + "%");
        }, 10);

        $('body').find("#" + opt.toaster.toasterid).fadeIn(opt.toaster.fadeInTime, () => {
            if (opt.toaster.automaticClose) {
                setTimeout(() => {
                    $('body').find("#" + opt.toaster.toasterid).fadeOut(opt.toaster.fadeOutTime, () => {
                        closeToast();
                        if (afterShowToastHtml) {
                            afterShowToastHtml();
                        }
                    });
                }, opt.toaster.showTime);
            }
            else {
                if (afterShowToastHtml) {
                    afterShowToastHtml();
                }
            }
        });

        instance.Close = function () {
            closeToast();
        }

        var closeToast = function () {
            clearInterval(toasterIntervalID);
            $('body').find("#" + opt.toaster.toasterid).remove();
            toasterIntervalID = null;
        }

        return instance;
    }

    core.Datatable = function (element, data, colums, columnDefs) {
        var table = element.DataTable({
            data: data,
            columns: colums,
            columnDefs: columnDefs,
            language: {
                emptyTable: "Gösterilecek ver yok.",
                processing: "Veriler yükleniyor",
                sDecimal: ".",
                sInfo: "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                sInfoFiltered: "(_MAX_ kayıt içerisinden bulunan)",
                sInfoPostFix: "",
                sInfoThousands: ".",
                sLengthMenu: "Sayfada _MENU_ kayıt göster",
                sLoadingRecords: "Yükleniyor...",
                sSearch: "Ara:",
                sZeroRecords: "Eşleşen kayıt bulunamadı",
                oPaginate: {
                    sFirst: "İlk",
                    sLast: "Son",
                    sNext: "Sonraki",
                    sPrevious: "Önceki"
                },
                oAria: {
                    sSortAscending: ": artan sütun sıralamasını aktifleştir",
                    sSortDescending: ": azalan sütun sıralamasını aktifleştir"
                },
                select: {
                    rows: {
                        _: "%d kayıt seçildi",
                        0: "",
                        1: "1 kayıt seçildi"
                    }
                }
            }
        });

        return table;
    }

    core.SetContext = function (contextName, contextItem) {
        localStorage.setItem(contextName, JSON.stringify(contextItem));
    }

    core.GetContext = function (contextName) {
        var contextItem = localStorage.getItem(contextName);
        if (contextItem == null) {
            return null;
        }
        return JSON.parse(contextItem);
    }

    core.ClearContext = function (contextName) {
        localStorage.removeItem(contextName);
    }

    core.IsNumber = function (x) {
        return typeof x === "number";
    }

    core.IsString = function (x) {
        return typeof x === "string";
    }

    core.IsNullOrEmpty = function (str) {
        return (!core.IsString(str) || !str || (core.IsString(str) ? !str.trim() : true));
    }

    core.NewGuid = function () {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    Init();

    return core;
}

var coreProcess = Core(coreInitOptions);