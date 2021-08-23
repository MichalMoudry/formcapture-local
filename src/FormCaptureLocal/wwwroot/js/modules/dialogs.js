function confirmDialog(message) {
    var res = confirm(message);
    return res;
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