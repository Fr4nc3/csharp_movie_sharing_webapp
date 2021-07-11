// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    function getSearchParams(k) {
        var p = {};
        location.search.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (s, k, v) { p[k] = v })
        return k ? p[k] : p;
    }

    // simply toast message pop up
    var t = getSearchParams('t');
    if (t === "1") {
        $('.toast').toast({ delay: 2000 });
        $('.toast').toast('show');
    }
    //Modal for Movie Actions
    $(".openModal").click(function () {
        var id = $(this).data("id");
        var action = $(this).data("action");
        var isSharable = $(this).data("shared");
        if (isSharable == "False") {
            $(".spSharable").text("no");
        } else {
            $(".spSharable").text("yes");
        }

        $("#Movie_ID").val(id);
        $("#Movie_ACTION").val(action);

        $(".spTitle").text($(this).parents("tr").find(".movieTitle").text());
        $(".spCategory").text($(this).parents("tr").find(".movieCategory").text());
        $(".spCategory").text($(this).parents("tr").find(".movieCategory").text());
        var sharedUser = $(this).parents("tr").find(".movieSharedUser").text().trim();
        var sharedEmail = $(this).parents("tr").find(".movieSharedEmail").text().trim();
        var sharedDate = $(this).parents("tr").find(".movieSharedDate").text().trim();
        if (sharedUser == "") {
            $(".displaySharedUser").hide();
        } else {
            $(".displaySharedUser").show();
        }
        if (sharedEmail == "") {
            $(".displaySharedEmail").hide();
        } else {
            $(".displaySharedEmail").show();
        }
        if (sharedDate == "") {
            $(".displaySharedDate").hide();
        } else {
            $(".displaySharedDate").show();
        }

        $(".spSharedUser").text(sharedUser);
        $(".spSharedEmail").text(sharedEmail);
        $(".spSharedDate").text(sharedDate);
        var movieStatus = $(this).parents("tr").find(".movieStatus").text().trim();
        movieStatus = movieStatus == "" ? "Available" : movieStatus;
        // modal dynamic variables 

        var movieMessage = "";
        var movieActionTitle = "";
        var actionBtnClass = "";
        var actionBtnVal = "";

        switch (action) {
            // movie owner actions
            case 'delete':
                movieMessage = "Are you sure you want to delete this?";
                movieActionTitle = "Delete Movie";
                actionBtnClass = "btn btn-danger";
                actionBtnVal = "Delete Movie";
                break;
            case 'requestReturn':
                movieMessage = "Do you want your movie back?";
                movieActionTitle = "Request Movie Back";
                actionBtnClass = "btn btn-warning";
                actionBtnVal = "Get Movie Back";
                break;
            case 'acceptBorrow':
                movieMessage = "Do you want share your movie back?";
                movieActionTitle = "Accept Share Movie";
                actionBtnClass = "btn btn-success";
                actionBtnVal = "Accept Borrow";
                break;
            case 'rejectBorrow':
                movieMessage = "Do you reject share your  movie?";
                movieActionTitle = "Reject Share Movie";
                actionBtnClass = "btn btn-warning";
                actionBtnVal = "Reject Borrow";
                break;
            case 'acceptReturn':
                movieMessage = "Do you accept your movie back?";
                movieActionTitle = "Accept Return Movie";
                actionBtnClass = "btn btn-success";
                actionBtnVal = "Accept Return";
                break;
            case 'cancelRequest':
                movieMessage = "Do you cancel request back?";
                movieActionTitle = "Cancel Request Return Movie";
                actionBtnClass = "btn btn-dark";
                actionBtnVal = "Cancel Request";
                break;
            // movie user share actions
            case 'returnMovie':
                movieMessage = "Do you want return this  movie?";
                movieActionTitle = "Return Movie Back";
                actionBtnClass = "btn btn-primary";
                actionBtnVal = "Return Movie";
                break;
            case 'cancelBorrow':
                movieMessage = "Do you cancel borrow request back?";
                movieActionTitle = "Cancel Borrow Movie";
                actionBtnClass = "btn btn-dark";
                actionBtnVal = "Cancel Borrow";
                break;
            case 'forceReturn':
                movieMessage = "";
                movieActionTitle = "Return Movie";
                actionBtnClass = "btn btn-warning";
                actionBtnVal = "Return Movie";
                break;
            case 'cancelReturn':
                movieMessage = "Do you want keep this movie";
                movieActionTitle = "Cancel Return Movie";
                actionBtnClass = "btn btn-warning";
                actionBtnVal = "Cancel Return";
                break;
            case 'borrowMovie':
                movieMessage = "Do you want Borrow this movie";
                movieActionTitle = "Borrow Movie";
                actionBtnClass = "btn btn-success";
                actionBtnVal = "Borrow Movie";
                break;
            default: // details
                movieActionTitle = "Details";
        }
        // set all buttons

        $("#action_btn").show();
        $("#action_btn").removeClass("").addClass(actionBtnClass);
        $("#action_btn").val(actionBtnVal);
        $(".movieMessage").text(movieMessage);
        $(".movieActionTitle").text(movieActionTitle);
        if (actionBtnVal == "") {
            $("#action_btn").hide();
        }


        $(".spStatus").text(movieStatus);

    });
});