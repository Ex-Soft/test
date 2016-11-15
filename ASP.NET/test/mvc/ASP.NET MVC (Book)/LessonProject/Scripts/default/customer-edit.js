function CustomerEdit() {
    _this = this;

    this.ajaxAddOwnership = "/Customer/AddOwnership";

    this.init = function () {
        $("#AddOwnership").click(function () {
            $.ajax({
                type: "GET",
                url: _this.ajaxAddOwnership,
                success: function (data) {
                    $("#OwnershipListWrapper").append(data);
                }
            })
        });

        $(document).on("click", ".remove-line", function () {
            $(this).closest(".OwnershipWrapper").remove();
        });
    }
}

var customerEdit = null;
$().ready(function () {
    customerEdit = new CustomerEdit();
    customerEdit.init();
});