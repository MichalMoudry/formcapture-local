function hideToast(alertID) {
    $("#" + alertID).hide();
}

function displayToast(toastID) {
    document.getElementById(toastID).classList.remove("d-none");
    $("#" + toastID).show();
    var alerts = document.getElementsByClassName("alert");
    alerts = Array.from(alerts);
    alerts.forEach((element) => {
        if (element["id"] != toastID) {
            closeAlert(element["id"]);
        }
    });
}