function regfb() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', { fields: 'name, email, first_name, last_name' }, function (response) {
        fblogin = response.first_name;
        fbid = response.id;
        userName.value = fblogin + fbid;
        Send("auth:" + userName.value + ",social");
        setTimeout(function () { }, 5000);
        ShowMainPage();
    });
}

function handleClientLoad() {
    gapi.load('client:auth2', initClient);
}

function initClient() {
    gapi.client.init({
        apiKey: 'AIzaSyB5zJZP-L8e59RnsgcengXP7ayT2rOhCmo',
        discoveryDocs: ["https://people.googleapis.com/$discovery/rest?version=v1"],
        clientId: '854276310419-fsbu8sh0o79r9i8756tuk2o4k8m86tpj.apps.googleusercontent.com',
        scope: 'profile'
    }).then(function () {
        gapi.auth2.getAuthInstance().isSignedIn.listen(updateSigninStatus);
        updateSigninStatus(gapi.auth2.getAuthInstance().isSignedIn.get());
    });
}

function updateSigninStatus(isSignedIn) {
    if (isSignedIn) {
        makeApiCall();
    }
}

function handleSignInClick(event) {
    gapi.auth2.getAuthInstance().signIn();
}

function makeApiCall() {
    gapi.client.people.people.get({
        resourceName: 'people/me'
    }).then(function (response) {
        fblogin = response.result.emailAddresses[0].value;
        userName.value = fblogin;
        Send("auth:" + userName.value + ",social");
        ShowMainPage();
        console.log('Hello, ' + response.result.names[0].givenName);
    }, function (reason) {
        console.log('Error: ' + reason.result.error.message);
    });
}
