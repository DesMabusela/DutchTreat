$(document).ready(function () {

    var TheForm = $("#Form");
    TheForm.hide();

    var button = $("buyButton");
    button.on("click", function () {
        console.log("Buying Item");
    });

    var ProductInfo = $(".ProductProps li");
    ProductInfo.on("click", function () {
        console.log("you clicked on" + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $PopupForm = $(".PopUpForm");

    $loginToggle.on("click", function () {
        $PopupForm.slideToggle(1000);

    });
});