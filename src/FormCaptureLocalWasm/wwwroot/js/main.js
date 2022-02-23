$(document).ready(function () {
    var theme = localStorage.getItem("ApplicationTheme");
    if (theme === '"HighContrastDark"') {
        $('head').append('<link rel="stylesheet" href="css/app-high-contrast-dark.css">');
    }
    else if (theme === '"HighContrastLight"') {
        $('head').append('<link rel="stylesheet" href="css/app-high-contrast-light.css">');
    }
});

async function hashString(string, salt) {
    const encoder = new TextEncoder();
    string = string + salt;
    const hash = await crypto.subtle.digest("SHA-256", encoder.encode(string));
    return Array.from(new Uint8Array(hash)).map(b => b.toString(16).padStart(2, "0")).join("");
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