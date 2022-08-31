$(document).ready(() => {
    $(".alert").delay(4000).slideUp(200, function() {
        $(this).alert('close');
    });

    $('#password-addon, #repeat-password-addon').click(function () {
        $('#password-addon, #repeat-password-addon').each(function () {
                $('input[aria-describedby=' + $(this).attr("id") + ']')
                    .attr('type', (_, attr) => attr === "password" ? "text" : "password")
            }
        ).children().children().toggleClass("fa-eye").toggleClass("fa-eye-slash")
    });
})