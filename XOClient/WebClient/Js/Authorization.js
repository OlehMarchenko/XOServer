function Authentification(isAuth) {
    if (isAuth) {
        OnUserLogin();
    }
    else {
        userName.value = null;
        MessageBox("Invalid login or/and password");
    }
}

function Registration(isReg) {
    if (isReg) {
        OnUserLogin();
    }
    else {
        userName.value = null;
        MessageBox("Login already exists!");
    }
}

function OnForgotPassword() {
    if (userName.value !== "") {
        var email = prompt("Enter email to retrieve your password:", "");
        if (email != null) {
            var res = validateEmail(email);
            if (res) {
                Send("forgotpass:" + userName.value + "," + email);
                userName.value = "";
                ShowMainPage();
            }
            else {
                alert("Incorrect e-mail address!");
                OnForgotPassword();
            }
        }
    }
    else {
        alert("You should insert your login first!");
    }
}

function validateEmail(email) {
    var re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
}

/* Custom modal change pass */
function OnChangePassword() {
    customModal.style.display = "block";
}

function OnRegistration() {
    SendReg(userName.value, document.getElementById("textPass").value);
    ShowMainPage();
}

function OnAuthorization() {
    SendAuth(userName.value, document.getElementById("textPass").value);
    ShowMainPage();
}
