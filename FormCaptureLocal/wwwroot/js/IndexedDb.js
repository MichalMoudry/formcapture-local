$(document).ready(function () {
    if (!window.indexedDB) {
        console.error("Indexed DB is no supported.");
    }
    indexedDB.open("FormCaptureDB", 1);
});