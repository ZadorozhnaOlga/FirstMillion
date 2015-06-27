var SendMail = function () {
    var email = document.getElementById('TxtMail').value;
    var myemail = document.getElementById('TxtMymail').value;
    var pass = document.getElementById('TxtPass').value;
    if ((email != "") && (myemail != "") && (pass != ""))
    {
        alert('Невдовзі ваш друг отримає запит про допомогу на свою пошту ' + '"' + email + '"');
    }
    };