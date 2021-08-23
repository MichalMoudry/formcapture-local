$.getScript("js/modules/toasts.js");
$.getScript("js/modules/fields.js");
$.getScript("js/modules/recognition.js");
$.getScript("js/modules/images.js");
$.getScript("js/modules/dialogs.js");

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();
    var theme = localStorage.getItem("ApplicationTheme");
    if (theme === '"Light"') {
        $('head').append('<link rel="stylesheet" href="css/app-light.css">');
    }
    else if (theme === '"Dark"') {
        $('head').append('<link rel="stylesheet" href="css/app-dark.css">');
    }
    else {
        $('head').append('<link rel="stylesheet" href="css/app-light.css">');
    }
});

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

function executeJS(code) {
    try {
        eval(code);
        return true;
    } catch (e) {
        console.error("Execution of code failed.");
        return false;
    }
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