function Commander(message) {

    if (message[0] === "{") {
        message = message.split(";").join(",");
        GameTurn(message);
        return;
    }

    var modifier = message.substring(0, message.indexOf(":"));
    message = message.replace("\r\n", "");
    message = message.replace(modifier, "");
    message = message.replace(":", "");
    var args = message.split(',');

    switch (modifier) {
        case "broadcast":
            {
                AddToPlayerList(args);
                break;
            }
        case "invite":
            {
                var res = MessageBox("Player " + args[0] + " wants to play with you!");

                var msg = "";
                if (res === true)
                {
                    msg = "inviteYes:";
                }
                else
                {
                    msg = "inviteNo:";
                }
                msg += userName.value + "," + args[0];
                Send(msg);

                break;
            }
        case "success":
            {
                if (args[0] === "yes") {
                    sessionKey = args[1];
                    ShowGamePage();
                }
                else {
                    MessageBox("Connection denied.");
                }
                break;
            }
        case "auth":
            {
                if (args[0] === "yes") {
                    Authentification(true);
                }
                else {
                    Authentification(false);
                }
                break;
            }
        case "reg":
            {
                if (args[0] === "yes") {
                    Registration(true);
                }
                else {
                    Registration(false);
                }
                break;
            }
        case "game":
            {
                if (args[0] === "quit"){
                    MessageBox("Player left the game. You win!");
                    win = true;
                    init = false;
                    ShowMainPage();
                    ClearGameField();
                }
                break;
            }
        case "changepass":
            {
                var message;
                if (args[0] === "yes") {
                    message = "Password successfully changed!";
                }
                else {
                    message = "Invalid login or/and password";
                }
                alert(message);
                userName.value = "";
                break;
            }
    }

}
