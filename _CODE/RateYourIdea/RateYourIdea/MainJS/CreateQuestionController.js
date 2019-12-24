/// <reference path="core.js" />
/// <reference path="../js/jquery.js" />

var createQuestionController = function () {

    const instance = {};

    var questionLimit = 3;

    var dynamicContent = $("#dynamic-content");

    var answerTypeList = [];

    var questionHtml = [`<div class="content col-lg-12 question">
                            <div class="form-group row">
                                <label for="example-text-input" class="col-2 col-form-label">Sorunuz</label>
                                <div class="col-10">
                                    <input class="form-control" type="text" value="" placeholder="Sorunuz" id="questionHeader">
                                </div>
                            </div>
                         </div>
                         <div class="content col-lg-12 answeroptions">
                            <div class="form-group row">
                                <label for="example-text-input" class="col-2 col-form-label">Cevap Seçenekleri</label>
                                <div class="col-8">
                                    <select class="form-control" id="answerTypeSelect">
                                    </select>
                                </div>
                                <div class="col-2">
                                    <button id="addAnswerTypeButton" class="btn">Ekle</button>
                                </div>
                            </div>
                         <div>`].join();

    instance.Constructor = function () {
        InitializeComponent();
    }

    var InitializeComponent = function () {
        addQuestionDefiner();
        GetAnswerTypes();
    }

    var addQuestionDefiner = function () {
        $("#addQuestion").off("click").on("click", function () {
            ToggleShowAddQuestion();
            if (dynamicContent.find(".question").length < questionLimit) {
                dynamicContent.append(questionHtml);
                dynamicContent.find(".answeroptions select").append(AnswerTypeOptions());
            }
            else {
                coreProcess.Toast("Soru Limitini Aştınız.", 2);
            }
        });
    }

    var GetAnswerTypes = function () {
        ToggleShowAddQuestion();
        coreProcess.Request("/Home/GetAnswerTypes", "GET", null, function (response) {
            ToggleShowAddQuestion();
            answerTypeList = response.Data;
        });
    }

    var AnswerTypeOptions = function () {
        var optionString = "";
        $.each(answerTypeList, function (i, e) {
            optionString += "<option value='" + e.Type + "'>" + e.Name + "</option>";
        });

        return optionString;
    }

    var ToggleShowAddQuestion = function () {
        if ($("#addQuestion").css("display") == "none") {
            $("#addQuestion").css("display", "block");
        }
        else {
            $("#addQuestion").css("display", "none");
        }
    }

    return instance;
}
