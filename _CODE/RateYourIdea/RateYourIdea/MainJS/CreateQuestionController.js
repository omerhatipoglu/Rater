/// <reference path="core.js" />
/// <reference path="../js/jquery.js" />

var createQuestionController = function () {

    const instance = {};

    var questionLimit = 3;

    var dynamicContent = $("#dynamic-content");

    var questionHtml = [`<div class="content col-lg-12 question">
                            <div class="form-group row">
                                <label for="example-text-input" class="col-2 col-form-label">Sorunuz</label>
                                <div class="col-10">
                                    <input class="form-control" type="text" value="" placeholder="Sorunuz" id="questionHeader">
                                </div>
                            </div>
                         <div>`].join();

    instance.Constructor = function () {
        InitializeComponent();
    }

    var InitializeComponent = function () {
        addQuestionDefiner();
    }

    var addQuestionDefiner = function () {
        $("#addQuestion").off("click").on("click", function () {
            coreProcess.loadingPanel.Show();
            if (dynamicContent.find(".question").length < questionLimit) {
                dynamicContent.append(questionHtml);
            }
            else {
                coreProcess.Toaster2("Soru Limitini Aştınız.", 2);
            }
        });
    }

    return instance;
}
