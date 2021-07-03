let db;
let transaction;
let objStore;

$(document).ready(function () {
    if (!window.indexedDB) {
        console.error("Indexed DB is no supported.");
        return;
    }
    let openRequest = indexedDB.open("FormCaptureDB", 1);
    //db = openRequest.result;
    openRequest.onupgradeneeded = function () {
        db = openRequest.result;
        if (!db.objectStoreNames.contains("Queues")) {
            db.createObjectStore("Queues", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("Templates")) {
            db.createObjectStore("Templates", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("Fields")) {
            db.createObjectStore("Fields", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("FieldValues")) {
            db.createObjectStore("FieldValues", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("ProcessedFiles")) {
            db.createObjectStore("ProcessedFiles", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("Workflows")) {
            db.createObjectStore("Workflows", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("WorkflowTasks")) {
            db.createObjectStore("WorkflowTasks", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("WorkflowTaskGroupings")) {
            db.createObjectStore("WorkflowTaskGroupings", { keyPath: "id", autoIncrement: false });
        }
        if (!db.objectStoreNames.contains("Users")) {
            db.createObjectStore("Users", { keyPath: "email", autoIncrement: false });
        }
    }
    openRequest.onsuccess = function () {
        if (db == null) {
            db = openRequest.result;
        }
    }
});

function addItem(objectStore, transactionType, item) {
    transaction = db.transaction(objectStore, transactionType);
    objStore = transaction.objectStore(objectStore);
    let request = objStore.add(item);
    let res;
    request.onsuccess = function () {
        res = true;
    }
    request.onerror = function () {
        res = false;
    }
}