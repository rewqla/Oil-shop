$(function () {
    var userImage = $("#oilImage");
    var uploader;
    var cropper = null;
    userImage.on("click", function () {
        if (cropper == null) {
            //Запуск пропера
            const imageEdited = document.getElementById("imageEdited");
            cropper = new Cropper(imageEdited, {
                aspectRatio: 1 / 1,
                viewMode: 1,
                autoCropArea: 1,
                rotatable: true
            });
            //обрізаємо фото
            $("#cropedImage").on("click", function (e) {
                e.preventDefault();
                var imgContent = cropper.getCroppedCanvas().toDataURL();
                userImage.attr("src", imgContent);
                $("#Image").val(imgContent);
                $('#cropperModal').modal('hide');
            });
            //обертаємо фото
            $("#rotateImage").on("click", function (e) {
                e.preventDefault();
                cropper.rotate(90);
            });
        }
        if (uploader) {
            uploader.remove();
        }
        uploader = $('<input type="file" accept="image/*" />');
        uploader.click();
        uploader.on('change', function () {
            var reader = new FileReader();
            reader.onload = function (event) {
                //Фото яке ви обрали
                var imageSelect = event.target.result;
                //$("#imageEdited").attr("src", imageSelect);
                cropper.replace(imageSelect); //Кропер міняє зображення на яке вказує
                $('#cropperModal').modal('show');
            }
            reader.readAsDataURL(uploader[0].files[0]);

        });
    });
});
