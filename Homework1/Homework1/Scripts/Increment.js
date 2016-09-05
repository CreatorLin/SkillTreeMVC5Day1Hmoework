$(document).ready(function () {
    $('[data-increment]').each(function () {
        increment($(this), $(this).data("increment"), $(this).data("increment-num"));
    });
});
function increment(e, targetId, number) {
    e.click(function () {
        var value = parseInt($("#" + targetId).val()) || 0;
        $("#" + targetId).val(value + parseInt(number));
    });
}
//# sourceMappingURL=Increment.js.map