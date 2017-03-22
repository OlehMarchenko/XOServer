
var clientSocket, ws;
var bLogin, bLogout, bInvite, bAuthorization, bRegistration,
    buttons, playerList, buttonClose, win, sessionKey,
    userName, playerTurn, unit, init = false, leftGame = false,
    inGame = false, bChangePassword, bForgotPassword, customModal,
    spanClose, mCancel, mConfirm;
var fblogin = "";
var fbid = 0;

window.onload = function () {

    bLogin = document.getElementById("bLogIn");
    bLogout = document.getElementById("bLogOut");
    bInvite = document.getElementById("bInvite");
    bAuthorization = document.getElementById("bAuthorization");
    bRegistration = document.getElementById("bRegistration");
    bChangePassword = document.getElementById("bChangePassword");
    bForgotPassword = document.getElementById("bForgotPassword");
    buttons = Array(
        document.getElementById("b1"),
        document.getElementById("b2"),
        document.getElementById("b3"),
        document.getElementById("b4"),
        document.getElementById("b5"),
        document.getElementById("b6"),
        document.getElementById("b7"),
        document.getElementById("b8"),
        document.getElementById("b9")
    );
   
    buttonClose = document.getElementById("buttonClose");
    playerList = document.getElementById("playerList");
    userName = document.getElementById("textLogin");

    bLogin.onclick = OnLogIn;
    bLogout.onclick = OnLogOut;
    bInvite.onclick = OnInvite;
    bRegistration.onclick = OnRegistration;
    bAuthorization.onclick = OnAuthorization;
    buttonClose.onclick = OnGameClose;
    bChangePassword.onclick = OnChangePassword;
    bForgotPassword.onclick = OnForgotPassword;

    /* Custom modal change pass */
    customModal = document.getElementById('mChangePass');
    spanClose = document.getElementsByClassName("close")[0];
    mCancel = document.getElementById("mCancel");
    mConfirm = document.getElementById("mConfirm");
    spanClose.onclick = OnCloseModalClick;
    mCancel.onclick = OnCloseModalClick;
    mConfirm.onclick = OnConfirmClick;
}

window.onbeforeunload = function () {
    if (!win) {
        if (inGame) {
            SendQuit();
            ws.close();
        }
        else {
            OnLogOut();
        }
    }
}

function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    if (response.status === 'connected') {
        success(response);
        regfb();
    }
}

function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

window.fbAsyncInit = function () {
    FB.init({
        appId: '{1859909034291396}',
        xfbml: true,
        version: 'v2.8'
    });

    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
};

function success(response) {
    console.log(response.authResponse.accessToken);
    console.log(response.authResponse.name);
    console.log(response.authResponse.first_name);
    console.log(response.authResponse.last_name);
    console.log(response.authResponse.email);
    console.log(response.authResponse.userID.first_name);
    console.log(response.authResponse.userID.email);
    console.log(response.authResponse.userID.last_name);
    var userid1 = response.authResponse.accessToken.id;
    var useremail1 = response.authResponse.accessToken.email;
    var userid = response.id;
    var useremail = response.email;
}

function ShowAuthorizationPage() {
    document.getElementById("authPage").style.display = 'block';
    document.getElementById("statusMenu").style.display = 'none';
    document.getElementById("popupMenu").style.display = 'none';
    document.getElementById("playerList").style.display = 'none';
}

function ShowMainPage() {
    document.getElementById("textPass").value = "";

    document.getElementById("authPage").style.display = 'none';
    document.getElementById("statusMenu").style.display = 'flex';
    document.getElementById("popupMenu").style.display = 'flex';
    document.getElementById("playerList").style.display = 'block';
    document.getElementById("gameMenu").style.display = 'none';
}

function ShowGamePage() {
    inGame = true;
    document.getElementById("authPage").style.display = 'none';
    document.getElementById("statusMenu").style.display = 'none';
    document.getElementById("popupMenu").style.display = 'none';
    document.getElementById("playerList").style.display = 'none';
    document.getElementById("gameMenu").style.display = 'block';
}

function ClearGameField() {
    for (var i = 0; i < buttons.length; i += 1) {
        buttons[i].value = " ";
    }
}

function MessageBox(message) {
    return confirm(message);
}

function OnLogIn() {
    if (userName.value == "") {
        ws = new WebSocket("ws://localhost:8080");

        ws.onopen = function () {
        };
        ws.onclose = function () {
            alert("Connection is closed...");
        };
        ws.onmessage = OnMessageReceive;

        ShowAuthorizationPage();
    }
}

function OnLogOut() {
    if (userName.value != "") {
        Send("logout:");
        playerList.innerHTML = "";
        userName.value = "";
        document.getElementById("statusLabel1").textContent = "Waiting for connection to server...";
        document.getElementById("statusLabel2").textContent = "Your name: ";
        ws.close();
    }
    else {
        alert("You are not connected to the server!");
    }
}

function OnInvite() {
    Send("invite:" + GetSelectedPlayer());
}

function OnButtonClicked(i) {

    if (unit != String.Empty) {
        if ("Turn" === playerTurn) {
            var str = JSON.stringify(new TTTPacket(playerTurn, unit, i, null, null));
            str = str.split(",").join(";");
            ws.send("game:" + sessionKey + "," + str);
        }
    }
}

function OnGameClose() {
    ClearGameField();
    leftGame = true;
    init = false;
    inGame = false;
    userName.value = "";
    SendQuit();
    ShowMainPage();
}

function OnUserLogin() {
    document.getElementById("statusLabel1").textContent = "Connected to the server";
    document.getElementById("statusLabel2").textContent = "Your name: " + userName.value;
}

function OnMessageReceive (evt) {
    var received_msg = evt.data;
    if (!leftGame) {
        Commander(received_msg);
    }
    leftGame = false;
}

function AddToPlayerList(names) {
    playerList.innerHTML = "";

    for (var i = 0; i < names.length; i++) {
        if (names[i] === userName.value){
            continue;
        }
        playerList.innerHTML += "<input type='radio' name='players' id='" + names[i] + "' />" + names[i] + "<br />";
    }
}

function GetSelectedPlayer() {
    for (var i = 0; i < playerList.childNodes.length; i++) {
        if (playerList.childNodes[i].checked) {
            return playerList.childNodes[i + 1].nodeValue;
        }
    }
}

function Send(message) {
    ws.send(message);
}

function SendAuth(name, password) {
    Send("auth:" + name + "," + password);
}

function SendReg(name, password) {
    Send("reg:" + name + "," + password);
}

function SendQuit() {
    Send("game:" + sessionKey + ",quit");
}

function GameTurn(packet) {
    obj = JSON.parse(packet);
    if (!init) {
        Init(obj);
        init = true;
    }
    else {
        if (obj.GameResult != null) {
            win = true;
            init = false;
            RefreshGameField(obj);
            MessageBox(obj.GameResult);
            ShowMainPage();
            ClearGameField();
        }
        else {
            RefreshGameField(obj);
        }
    }
}

function Init(packet) {
    playerTurn = packet.PlayerTurn;
    unit = packet.Unit;

    document.getElementById("lGameTurn").textContent = unit + " | " + playerTurn;
}

function RefreshGameField(packet) {
    var matrix = packet.Matrix;
    for (var i = 0; i < matrix.length; i += 1) {
        buttons[i].value = (matrix[i] == "") ? " " : matrix[i];
    }
    playerTurn = packet.PlayerTurn;
    document.getElementById("lGameTurn").textContent = unit + " | " + playerTurn;
}

function OnConfirmClick() {
    var login = document.getElementById("mLogin").value;
    var pass = document.getElementById("mPass").value;
    var newPass = document.getElementById("mNewPass").value;
    Send("changepass:" + login + "," + pass + "," + newPass);
    CloseModal();
    ShowMainPage();
}

function OnCloseModalClick() {
    CloseModal();
}

window.onclick = function (event) {
    if (event.target == customModal) {
        CloseModal();
    }
}

function CloseModal() {
    document.getElementById("mLogin").value = "";
    document.getElementById("mPass").value = "";
    document.getElementById("mNewPass").value = "";
    customModal.style.display = "none";
}