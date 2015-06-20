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
    if (email != "")
    {
        alert('На пошту ' + '"' + email + ' " ' + 'надіслано запит про допомогу.');
    }
    
    
    
   
    };