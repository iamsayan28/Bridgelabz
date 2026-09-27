$(document).ready(function () {

    // Confirm before deleting an employee
    $(".delete-form").on("submit", function (e) {
        var confirmed = confirm("Are you sure you want to delete this employee?");
        if (!confirmed) {
            e.preventDefault();
        }
    });

    // Auto-hide the one-time TempData success message after a few seconds
    if ($("#tempMessage").length) {
        setTimeout(function () {
            $("#tempMessage").fadeOut();
        }, 3000);
    }

});
