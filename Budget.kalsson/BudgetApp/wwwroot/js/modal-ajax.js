$(document).ready(function () {
    // Open the modal when a button is clicked
    $(document).on('click', '.open-modal', function (e) {
        e.preventDefault();

        var url = $(this).data("url");

        // Load the modal content from the server
        $.get(url, function (response) {
            $("#modalContent").html(response);
            $("#modalContainer").modal("show");
        });
    });

    // Handle AJAX form submission only for forms with data-ajax="true"
    $(document).on('submit', 'form[data-ajax="true"]', function (e) {
        e.preventDefault(); // Prevent default form submission

        var form = $(this);
        var url = form.attr("action");
        var method = form.attr("method");
        var data = form.serialize();

        $.ajax({
            url: url,
            method: method,
            data: data,
            success: function (response) {
                if (response.success) {
                    // Close the modal and reload the page on successful response
                    $("#modalContainer").modal("hide");
                    location.reload(); // Reload the page to reflect changes
                } else {
                    // Reload the modal content with validation errors
                    $("#modalContent").html(response);
                }
            },
            error: function () {
                alert("An error occurred while processing your request. Please try again.");
            }
        });
    });

    // Allow non-AJAX forms (e.g., Search form) to work normally
    // Forms without data-ajax="true" will NOT be intercepted
});