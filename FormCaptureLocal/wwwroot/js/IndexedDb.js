let db;
let transaction;
let objStore;
let request;

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

function addUser(item) {
    transaction = db.transaction("Users", "readwrite");
    objStore = transaction.objectStore("Users");
    request = objStore.add(item);
    request.onsuccess = function () {
        window.location.href = "./login";
    }
    request.onerror = function () {
        //$("#registration-error-display").classList.remove("d-none");
        document.getElementById("registration-error-display").classList.remove("d-none");
    }
}

async function getItem(id, objectstore) {
    let res;
    res = await getItemPromise(id, objectstore);
    return res;
}

function getItemPromise(id, objectstore) {
    return new Promise(function (resolve) {
        transaction = db.transaction(objectstore, "readonly");
        objStore = transaction.objectStore(objectstore);
        request = objStore.get(id);
        request.onsuccess = function (e) {
            return resolve(e.target.result);
        }
    });
}