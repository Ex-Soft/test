function FileIndex() {
    _this = this;

    this.ajaxFileUpload = "/File/Upload";

    this.init = function () {
        $('#UploadImage').fineUploader({
            request: {
                endpoint: _this.ajaxFileUpload
            },
        })
        .on('error', function (event, id, name, reason) {
            //do something
        })
        .on('complete', function (event, id, name, responseJSON) {
          $("#ImagePreview").attr("src", responseJSON.data.filePreviewPath)
        });
    }
}

var fileIndex = null;

$().ready(function () {
    fileIndex = new FileIndex();
    fileIndex.init();
});