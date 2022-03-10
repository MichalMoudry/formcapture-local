let db;
let transaction;
let objStore;
let request;
let res;

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
            db.createObjectStore("Queues", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("Templates")) {
            db.createObjectStore("Templates", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("Fields")) {
            db.createObjectStore("Fields", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("FieldValues")) {
            db.createObjectStore("FieldValues", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("ProcessedFiles")) {
            db.createObjectStore("ProcessedFiles", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("Workflows")) {
            db.createObjectStore("Workflows", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("WorkflowTasks")) {
            db.createObjectStore("WorkflowTasks", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("WorkflowTaskGroupings")) {
            db.createObjectStore("WorkflowTaskGroupings", { keyPath: "id", autoIncrement: true });
        }
        if (!db.objectStoreNames.contains("Users")) {
            var users = db.createObjectStore("Users", { keyPath: "id", autoIncrement: true });
            //users.createIndex("email", "email", { unique: true });
        }
    }
    openRequest.onsuccess = function () {
        if (db == null) {
            db = openRequest.result;
        }
    }
});

async function addItem(item, objectstore) {
    res = await addItemPromise(item, objectstore);
    return res;
}

async function getItem(id, objectstore) {
    id = 1;
    res = await getItemPromise(id, objectstore);
    console.log("Res: ", res, id);
    return res;
}

async function getAllItems(objectstore) {
    res = await getAllItemsPromise(objectstore);
    return res;
}

async function putItem(object, objectstore) {
    res = await putItemPromise(object, objectstore);
    return res;
}

async function deleteItem(object, objectstore) {
    res = await deleteItemPromise(object, objectstore);
    return res;
}

//------------------------Promises------------------------
function addItemPromise(item, objectstore) {
    return new Promise(function (resolve) {
        delete item.id;
        transaction = db.transaction(objectstore, "readwrite");
        objStore = transaction.objectStore(objectstore);
        request = objStore.add(item);
        request.onsuccess = function () {
            return resolve(true);
        }
        request.onerror = function (e) {
            return resolve(false);
        }
    });
}

function getItemPromise(id, objectstore) {
    return new Promise(function (resolve) {
        transaction = db.transaction(objectstore, "readonly");
        objStore = transaction.objectStore(objectstore);
        request = objStore.get(id);
        request.onsuccess = function (e) {
            if (e.target.result === undefined) {
                return resolve(null);
            }
            else {
                return resolve(e.target.result);
            }
        }
        request.onerror = function () {
            return resolve(null);
        }
    });
}

function getAllItemsPromise(objectstore) {
    return new Promise(function (resolve) {
        transaction = db.transaction(objectstore, "readonly");
        objStore = transaction.objectStore(objectstore);
        request = objStore.getAll();
        request.onsuccess = function (e) {
            if (e.target.result === undefined) {
                return resolve(null);
            }
            else {
                return resolve(e.target.result);
            }
        }
        request.onerror = function () {
            return resolve(null);
        }
    });
}

function putItemPromise(object, objectstore) {
    return new Promise(function (resolve) {
        transaction = db.transaction(objectstore, "readwrite");
        objStore = transaction.objectStore(objectstore);
        request = objStore.put(object);
        request.onsuccess = function () {
            return resolve(true);
        }
        request.onerror = function () {
            return resolve(false);
        }
    });
}

function deleteItemPromise(object, objectstore) {
    return new Promise(function (resolve) {
        transaction = db.transaction(objectstore, "readwrite");
        objStore = transaction.objectStore(objectstore);
        request = objStore.delete(object);
        request.onsuccess = function () {
            return resolve(true);
        }
        request.onerror = function () {
            return resolve(false);
        }
    });
}