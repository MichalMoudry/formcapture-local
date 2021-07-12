async function hashString(string, salt) {
    const encoder = new TextEncoder();
    string = string + salt;
    const hash = await crypto.subtle.digest("SHA-256", encoder.encode(string));
    return Array.from(new Uint8Array(hash)).map(b => b.toString(16).padStart(2, "0")).join("");
}

function confirmDialog(message) {
    var res = confirm(message);
    return res;
}

function closeAlert(alertID) {
    $("#" + alertID).hide();
}

function displayToast(toastID) {
    document.getElementById(toastID).classList.remove("d-none");
    $("#" + toastID).show();
}

function getImageProperties(imageID) {
    var img = document.getElementById(imageID);
    return img.naturalWidth + "|" + img.naturalHeight;
}

//Method for obtaining properies of a specific template field.
function getFieldProperties(fieldID) {
    var field = document.getElementById(fieldID);
    if (field != null) {
        return field.style.width.substring(0, field.style.width.length - 2) + "," +
            field.style.height.substring(0, field.style.height.length - 2) + "," +
            field.style.top.substring(0, field.style.top.length - 2) + "," +
            field.style.left.substring(0, field.style.left.length - 2);
    }
    else {
        return null;
    }
}

function executeJS(code) {
    try {
        eval(code);
        return true;
    } catch (e) {
        console.error("Execution of code failed.");
        return false;
    }
}

function drawFields(fields, targetID) {
    var xposition;
    var yposition;
    var width;
    var height;
    var fieldRectangle;
    var canvas = document.getElementById(targetID);
    if (canvas != null) {
        for (var i = 0; i < fields.length; i++) {
            fieldRectangle = document.createElement("div");
            fieldRectangle.classList.add("template-field");
            fieldRectangle.id = fields[i]["id"];
            xposition = fields[i]["xposition"] + "px";
            yposition = fields[i]["yposition"] + "px";
            width = fields[i]["width"] + "px";
            height = fields[i]["height"] + "px";

            fieldRectangle.style.top = xposition;
            fieldRectangle.style.left = yposition;
            fieldRectangle.style.width = width;
            fieldRectangle.style.height = height;

            canvas.appendChild(fieldRectangle);
        }
    }
}

function drawField(fieldID) {
    var existingField = document.getElementById(fieldID);
    if (existingField != null) {
        existingField.remove();
    }
    var canvas = document.getElementById("template-canvas");
    if (canvas != null) {
        var fieldRectangle;
        var startX = 0;
        var startY = 0;
        var x = 0;
        var y = 0;
        if (canvas.onclick == null) {
            canvas.onclick = function (e) {
                if (fieldRectangle == null) {
                    fieldRectangle = document.createElement("div");
                    fieldRectangle.classList.add("template-field");
                    fieldRectangle.id = fieldID;
                    canvas.style.cursor = "crosshair";

                    startX = e.offsetX;
                    startY = e.offsetY;

                    fieldRectangle.style.top = startX + "px";
                    fieldRectangle.style.left = startY + "px";

                    canvas.appendChild(fieldRectangle);
                }
                else {
                    fieldRectangle = null;
                    canvas.style.cursor = "pointer";
                    canvas.onclick = null;
                    canvas.onmousemove = null;
                }
            }
        }

        if (canvas.onmousemove == null) {
            canvas.onmousemove = function (e) {
                if (fieldRectangle != null) {
                    x = e.offsetX;
                    y = e.offsetY;
                    fieldRectangle.style.width = (x - startX) + "px";
                    fieldRectangle.style.height = (y - startY) + "px";
                    fieldRectangle.style.left = ((x - startX) < 0) ? x + "px" : startX + "px";
                    fieldRectangle.style.top = ((y - startY) < 0) ? y + "px" : startY + "px";
                }
            }
        }
    }
}