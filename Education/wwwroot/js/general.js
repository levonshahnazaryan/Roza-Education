function getFormDataObj(form) {
    var arr = $(form).serializeArray();
    var obj = {};
    for (var i = 0; i < arr.length; i++) {
        if (arr[i].name != "__RequestVerificationToken") {
            obj[arr[i].name] = arr[i].value;
        }
    }
    return obj;
}

jQuery(document).ready(function () {
    $(document).on('click', 'body', function () {
        $('.login_box').removeClass('activeLogin').fadeOut(300);
    })

    $(document).on('click', '.btnLogin', function (e) {
        e.stopPropagation();
        if (!$('.login_box').hasClass('activeLogin')) {
            $('.login_box').addClass('activeLogin').fadeIn(300);

        } else {
            $('.login_box').removeClass('activeLogin').fadeOut(300);
        }
    });

    $(document).on('click', '.login_box', function (e) {
        e.stopPropagation();
    });

    $('.owl-carousel').owlCarousel({
        //center: true,
        items: 1,
        loop: true,
        margin: 0,
        nav: true,
        autoplay: false,
        //autoplayTimeout:3000,
        //autoplayHoverPause:true
    });

    $("#form-login").on("submit", function (e) {
        e.preventDefault();
        let isError = false;
        const form = $(this);
        const token = form.find("[name=__RequestVerificationToken]").val();
        const data = getFormDataObj(this);

        if (!data.UserName || data.UserName == "") {
            isError = true;
            $("#UserName").css("border-color", "red");
            $("#UserName").css("color", "red");
        }
        else {
            $("#UserName").css("border-color", "transparent");
            $("#UserName").css("color", "#5a5a5a");
        }

        if (!data.PassWord || data.PassWord == "") {
            isError = true;
            $("#PassWord").css("border-color", "red");
            $("#PassWord").css("color", "red");
        }
        else {
            $("#PassWord").css("border-color", "transparent");
            $("#PassWord").css("color", "#5a5a5a");
        }
        if (!isError) {
            $.ajax({
                type: 'POST',
                url: '/Account/Login',
                data: JSON.stringify(data),
                contentType: 'application/json',
                headers: { "RequestVerificationToken": token },
                success: function (resp) {
                    if (!resp.isAuthorized) {
                        $(".login_error").show();
                        $(".login_error").text(resp.errorText);
                    }
                    else {
                        window.location.href = "/Account/AboutUs";
                    }
                }
            });
        }
    });
});



var generalFunctions = {
    events: function () {
        var self = this;
    },
    cellPrepared: function (e) {
        var self = this;

        if (e.rowType === "data" && e.column.command === "edit") {
            var isEditing = e.row.isEditing,
                $links = e.cellElement.find(".dx-link");

            $links.text("");

            if (isEditing) {
                $links.filter(".dx-link-save").addClass("dx-icon-save");
                $links.filter(".dx-link-cancel").addClass("dx-icon-revert");
            } else {
                $links.filter(".dx-link-edit").addClass("dx-icon-edit");
                $links.filter(".dx-link-delete").addClass("dx-icon-trash");
            }
        }
    },
    getPartial: function (url, params) {
        var self = this;
        var actionName = url.substring(url.lastIndexOf('/') + 1);
        var action = url;
        if (params) {
            action = url + "/" + params;
        }
        $.get(action, function (content) {
            $("[data-partial=" + actionName + "]").html(content);
        });
    },
    loadingPanelShow: function () {
        var self = this;
        $("#loadPanel").dxLoadPanel("instance").show();
    },
    loadingPanelHide: function () {
        var self = this;
        $("#loadPanel").dxLoadPanel("instance").hide();
    },
    dxToastShow: function (isSuccess, text) {
        var self = this;
        var toest = $("#ToastExeption").dxToast('instance');
        if (isSuccess) {
            toest.option("contentTemplate", text);
            toest.option("type", "success");
        }
        else {
            toest.option("contentTemplate", text);
            toest.option("type", "error");
        }
        toest.show();
    }
}


var accountIndexFunctions = {
    events: function () {
        var self = this;
    },
    onContentReady: function (e, refresh, imgup) {
        var self = this;

        if ($("#imgupxBtn").length == 0) {
            var $customButton1 = $('<div class="icon-margin">').attr("id", "imgupxBtn").dxButton({
                hint: imgup,
                icon: 'image',
                disabled: true,
                onClick: function () {
                    var row = $('#UsefulLinks').dxDataGrid('instance').getSelectedRowsData(0);
                    if (row[0].UsefulLinksId) {
                        generalFunctions.getPartial("/Account/UsefulLinksImage", row[0].UsefulLinksId);
                        $("#pp_ImageUpload").dxPopup("instance").show();
                    }
                }
            });
            var toolbar = e.element.find('.dx-toolbar-after');
            $(toolbar.get(0)).prepend($customButton1);
        }

        if ($("#refxBtn").length == 0) {
            var $customButton1 = $('<div class="icon-margin">').attr("id", "refxBtn").dxButton({
                hint: refresh,
                icon: 'refresh',
                onClick: function () {
                    $("#UsefulLinks").dxDataGrid("instance").refresh();
                }
            });
            var toolbar = e.element.find('.dx-toolbar-after');
            $(toolbar.get(0)).prepend($customButton1);
        }
    },
    onReorder: function (e) {
        var self = this;
        var dataGrid = e.component,
            store = dataGrid.getDataSource().store(),
            visibleRows = dataGrid.getVisibleRows(),
            newOrderIndex = visibleRows[e.toIndex].data.Sorting,
            d = $.Deferred();
        store.update(e.itemData.UsefulLinksId, { Sorting: newOrderIndex }).then(function () {
            dataGrid.refresh().then(d.resolve, d.reject);
        }, d.reject);

        e.promise = d.promise();
    },
    onSelectionChanged: function (e) {
        var self = this;
        $("#imgupxBtn").dxButton("instance").option("disabled", false);
    },
    onRowInserted: function (e) {
        var self = this;
        $("#UsefulLinks").dxDataGrid("instance").refresh();
    },
    setUploadImage: function (e, url) {
        var self = this;
        $(".usefullinksimg").attr("src", url + e.file.name);
    }
}

var aboutUsFunctions = {
    events: function () {
        var self = this;
    },
    updateContent: function (event, form) {
        var self = this;
        event.preventDefault();
        var aboutUsId = $(form).attr("data-aboutusid");
        var description = $(form).find("#description-content").dxHtmlEditor('instance').option("value");

        var data = {
            AboutUsId: aboutUsId,
            UContent: description
        }

        var token = $("[name=__RequestVerificationToken]").val();
        $.ajax({
            type: 'POST',
            url: '/Account/UpdateAboutUsContent',
            data: JSON.stringify(data),
            contentType: 'application/json',
            headers: { "RequestVerificationToken": token },
            success: function (resp) {
                if (resp) {
                    generalFunctions.dxToastShow(true, "Փոփոխությունը կատարված է");
                }
                else {
                    generalFunctions.dxToastShow(false, "Փոփոխությունը կատարված չէ");
                }
            }
        });
        return false;
    }
}

var aboutCollageFunctions = {
    events: function () {
        var self = this;
    },
    updateContent: function (event, form) {
        var self = this;
        event.preventDefault();
        var aboutCollageId = $(form).attr("data-aboutcollageid");
        var description = $(form).find("#description-content").dxHtmlEditor('instance').option("value");

        var data = {
            AboutCollageId: aboutCollageId,
            UContent: description
        }

        var token = $("[name=__RequestVerificationToken]").val();
        $.ajax({
            type: 'POST',
            url: '/Account/UpdateAboutCollageContent',
            data: JSON.stringify(data),
            contentType: 'application/json',
            headers: { "RequestVerificationToken": token },
            success: function (resp) {
                if (resp) {
                    generalFunctions.dxToastShow(true, "Փոփոխությունը կատարված է");
                }
                else {
                    generalFunctions.dxToastShow(false, "Փոփոխությունը կատարված չէ");
                }
            }
        });
        return false;
    }
}


var accountEducationFunctions = {
    events: function () {
        var self = this;
    },
    onContentReady: function (e, refresh, desc) {
        var self = this;

        if ($("#descxBtn").length == 0) {
            var $customButton1 = $('<div class="icon-margin">').attr("id", "descxBtn").dxButton({
                hint: desc,
                icon: 'globe',
                disabled: true,
                onClick: function () {
                    var row = $('#EducationGrid').dxTreeList('instance').getSelectedRowsData(0);
                    if (row[0].EducationsId) {
                        generalFunctions.getPartial("/Account/EducationContent", row[0].EducationsId);
                        $("#pp_EduContent").dxPopup("instance").show();
                    }
                }
            });
            var toolbar = e.element.find('.dx-toolbar-after');
            $(toolbar.get(0)).prepend($customButton1);
        }

        if ($("#refxBtn").length == 0) {
            var $customButton1 = $('<div class="icon-margin">').attr("id", "refxBtn").dxButton({
                hint: refresh,
                icon: 'refresh',
                onClick: function () {
                    $("#EducationGrid").dxTreeList("instance").refresh();
                }
            });
            var toolbar = e.element.find('.dx-toolbar-after');
            $(toolbar.get(0)).prepend($customButton1);
        }
    },
    onSelectionChanged: function (e) {
        var self = this;
        $("#descxBtn").dxButton("instance").option("disabled", false);
    },
    updateContent: function (event, form) {
        var self = this;
        event.preventDefault();
        var educationsId = $(form).attr("data-educationsid");
        var description = $(form).find("#description-content").dxHtmlEditor('instance').option("value");

        var data = {
            EducationsId: educationsId,
            UContent: description
        }

        var token = $("[name=__RequestVerificationToken]").val();
        $.ajax({
            type: 'POST',
            url: '/Account/UpdateEducationsContent',
            data: JSON.stringify(data),
            contentType: 'application/json',
            headers: { "RequestVerificationToken": token },
            success: function (resp) {
                if (resp) {
                    generalFunctions.dxToastShow(true, "Փոփոխությունը կատարված է");
                }
                else {
                    generalFunctions.dxToastShow(false, "Փոփոխությունը կատարված չէ");
                }
            }
        });
        return false;
    }
}

var homeFeedbackFunctions = {
    events: function () {
        var self = this;
    },
    sendFeedback: function (event, form) {
        var self = this;
        event.preventDefault();

        var formData = new FormData();
        formData.append("fullName", $("#FullName").val());
        formData.append("email", $("#Email").val());
        formData.append("iFile", $("#IFile")[0].files[0]);
        formData.append("content", $("#Content").val());

        var token = $("[name=__RequestVerificationToken]").val();
        $.ajax({
            type: 'POST',
            url: '/Home/SendFeedback',
            data: formData,
            dataType: 'json',
            processData: false,
            contentType: false,
            headers: { "RequestVerificationToken": token },
            success: function (resp) {
                if (resp) {
                    window.location.href = "/";
                }
                else {
                    $('.feadback_box').addClass('errore_style')
                }
            }
        });
        return false;
    }
}