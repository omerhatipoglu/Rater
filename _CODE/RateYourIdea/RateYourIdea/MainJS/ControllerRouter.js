/// <reference path="../js/jquery.js" />
/// <reference path="createquestioncontroller.js" />
$(document).ready(function () {
    var page = document.location.href.split("/")[4];

    if (page == "CreateQuestion") {
        createQuestionController().Constructor();
    }
});