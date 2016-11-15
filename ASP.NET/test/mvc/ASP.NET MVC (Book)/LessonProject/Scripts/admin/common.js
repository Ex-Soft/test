function AdminCommon()
{
    _this = this;

    this.init = function ()
    {
        $("#SelectedLang").change(function () {
            $("#SelectLangForm").submit();
        });
    }
}

var adminCommon = null;
$().ready(function () {
    adminCommon = new AdminCommon();
    adminCommon.init();
});