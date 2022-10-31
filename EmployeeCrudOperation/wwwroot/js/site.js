function myFunction() {
    var x = document.getElementById("password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
function myRetype() {
    var x = document.getElementById("Retype_Password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}