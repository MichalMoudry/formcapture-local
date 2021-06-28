$(document).ready(function () {
    if (!window.indexedDB) {
        console.error("Indexed DB is no supported.");
        return;
    }
    indexedDB.open("FormCaptureDB", 1);
});