//var HideMail = function(){
    
//    var email = document.getElementById('TxtMail');
//    var btn = document.getElementById('BntSend');
   
//    email.style.cssClass = "Mail";
//    btn.style.cssClass = "Send";
//    var result = PageMethods.BtnSendd();
//    return result;
//    //email.style.cssClass = "Mail";
//    //btn.style.cssClass = "Send";
//}
var SendMail = function () {
    //HideMail();

    var email = document.getElementById('TxtMail').value;
    var myemail = document.getElementById('TxtMymail').value;
    var pass = document.getElementById('TxtPass').value;
    if ((email != "") && (myemail != "") && (pass != ""))
    {
        alert('Невдовзі ваш друг отримає запит про допомогу на свою пошту ' + '"' + email + '"');
    }
    
    
    
   
    };