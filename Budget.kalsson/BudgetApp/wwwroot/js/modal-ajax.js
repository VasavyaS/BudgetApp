$(document).ready(function () {
    // Open the modal when a button is clicked
    $(document).on('click', '.open-modal', function (e) {
        e.preventDefault();

        var url = $(this).data("url");

        $.get(url, function (response) {
            $("#modalContent").html(response);
            $("#modalContainer").modal("show");
        });
    });

    // Handle form submission
    $(document).on('submit', 'form', function (e) {
        e.preventDefault();

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
                    $("#modalContainer").modal("hide");
                    location.reload(); // Refresh page or table contents
                } else {
                    $("#modalContent").html(response); // Reload modal with validation errors
                }
            }
        });
    });
});