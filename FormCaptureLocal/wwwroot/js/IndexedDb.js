let db;

$(document).ready(function () {
    if (!window.indexedDB) {
        console.error("Indexed DB is no supported.");
        return;
    }
    let openRequest = indexedDB.open("FormCaptureDB", 1);
    openRequest.onupgradeneeded = function () {
        db = openRequest.result;
        if (!db.objectStoreNames.contains("Queues")) {
            db.createObjectStore("Queues", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("Templates")) {
            db.createObjectStore("Templates", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("Fields")) {
            db.createObjectStore("Fields", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("FieldValues")) {
            db.createObjectStore("FieldValues", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("ProcessedFiles")) {
            db.createObjectStore("ProcessedFiles", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("Workflows")) {
            db.createObjectStore("Workflows", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("WorkflowTasks")) {
            db.createObjectStore("WorkflowTasks", { keyPath: "id" });
        }
        if (!db.objectStoreNames.contains("WorkflowTaskGroupings")) {
            db.createObjectStore("WorkflowTaskGroupings", { keyPath: "id" });
        }
    }
});