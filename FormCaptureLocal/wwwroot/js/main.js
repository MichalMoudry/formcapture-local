const { createWorker } = Tesseract;

async function hashString(string, salt) {
    const encoder = new TextEncoder();
    string = string + salt;
    const hash = await crypto.subtle.digest("SHA-256", encoder.encode(string));
    return Array.from(new Uint8Array(hash)).map(b => b.toString(16).padStart(2, "0")).join("");
}

function uncheckCheckboxes(checkboxIdArray) {
    for (var i = 0; i < checkboxIdArray.length; i++) {
        document.getElementById(checkboxIdArray[i]).checked = false;
    }
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
            fieldRectangle.title = fieldRectangle.id;
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
                    canvas.style.cursor = "auto";
                    canvas.onclick = null;
                    canvas.onmousemove = null;
                }
            }
        }
        else {
            canvas.style.cursor = "pointer";
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

function removeField(fieldID) {
    document.getElementById(fieldID).remove();
}

async function recogSingleField(field, image, lang, contentType) {
    // Initialize variables
    const worker = createWorker();
    await worker.load();
    await worker.loadLanguage(lang);
    await worker.initialize(lang);
    var results = [];

    // Iterate for each input image
    const {
        data: { text }
    } = await worker.recognize("data:" + contentType + ";base64," + image,
        {
            rectangle: {
                top: field["xposition"],
                left: field["yposition"],
                width: field["width"],
                height: field["height"]
            }
        });
    // Push recognition result to array in this format:
    // [result] / [fieldID]
    results.push(text.replace(/\s/g, "") + "/" + field["id"]);

    // Finish recognition and return results
    await worker.terminate();
    return results;
}

function displayTemplateTestResult(recognizedValue, expectedValue) {
    if (expectedValue == null || expectedValue == "") {
        expectedValue = "none";
    }
    var message = "Identifying field test:\n\n" + "Recognized value: " + recognizedValue + "\n" + "Expected value: " + expectedValue + "\n\n" + "Are files going to be identified? ";
    if (expectedValue == recognizedValue) {
        message += "Yes";
    }
    else {
        message += "No";
    }
    alert(message);
}

function switchTheme(newTheme) {
    var main = document.getElementById("main-app-body");
    if (main != null) {
        if (newTheme == "lightTheme") {
            if (main.classList.contains("darkTheme")) {
                main.classList.remove("darkTheme");
            }
            else if (main.classList.contains("highContrastLight")) {
                main.classList.remove("highContrastLight");
            }
            else if (main.classList.contains("highContrastDark")) {
                main.classList.remove("highContrastDark");
            }
        }
        else if (newTheme == "darkTheme") {
            if (main.classList.contains("lightTheme")) {
                main.classList.remove("lightTheme");
            }
            else if (main.classList.contains("highContrastLight")) {
                main.classList.remove("highContrastLight");
            }
            else if (main.classList.contains("highContrastDark")) {
                main.classList.remove("highContrastDark");
            }
        }
        else if (newTheme == "highContrastLight") {
            if (main.classList.contains("darkTheme")) {
                main.classList.remove("darkTheme");
            }
            else if (main.classList.contains("lightTheme")) {
                main.classList.remove("lightTheme");
            }
            else if (main.classList.contains("highContrastDark")) {
                main.classList.remove("highContrastDark");
            }
        }
        else if (newTheme == "highContrastDark") {
            if (main.classList.contains("darkTheme")) {
                main.classList.remove("darkTheme");
            }
            else if (main.classList.contains("lightTheme")) {
                main.classList.remove("lightTheme");
            }
            else if (main.classList.contains("highContrastLight")) {
                main.classList.remove("highContrastLight");
            }
        }
        main.classList.add(newTheme);
    }
}