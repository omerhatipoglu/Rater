var coreInitOptions = {
    toaster: {
        toasterTemp: `<div id="modalStripTop" class="modal-strip modal-bottom modal-active">
                        <div class="container">
                            <div id="toasterMessage" class="text-center p-10">
                            </div>
                        </div>
                        <div class="completion-bar" style="height:4px; border-radius:14px; margin-top:10px; width:0%; background-color:#32ff7e;"></div>
                      </div>`,
        toasterid: "modalStripTop",
        toasterMessageid: "toasterMessage",
        type: [
            {
                id: 1,
                property: "background-success"
            },
            {
                id: 2,
                property: "background-warning"
            },
            {
                id: 3,
                property: "background-danger"
            }
        ],
        typeFunction: function (toastHtml, typeArray, type) {
            $.each(typeArray, function (i, e) {
                if (type == e.id) {
                    toastHtml.addClass(e.property);
                }
            });
        },
        automaticClose: true
    }
};