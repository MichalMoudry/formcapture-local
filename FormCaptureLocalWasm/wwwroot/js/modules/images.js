function getImageProperties(imageID) {
    var img = document.getElementById(imageID);
    return img.naturalWidth + "|" + img.naturalHeight;
}

async function convertImageToGreyScale(imageData) {
    var res = await convertImagePromise(imageData);
    return res;
}

function convertImagePromise(imageData) {
    return new Promise(function (resolve) {
        const image = new Image();
        image.onload = function () {
            var canvas = document.createElement("canvas");
            var context = canvas.getContext("2d");
            canvas.width = image.width;
            canvas.height = image.height;
            context.filter = "grayscale(100%)";
            context.drawImage(image, 0, 0);
            return resolve(canvas.toDataURL());
        }
        image.src = imageData;
    });
}