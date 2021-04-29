function LoginUser() {
    var TempEmail = document.getElementById("logemail");
    var TempPassword = document.getElementById("logpass");
    //var encrpPassword = crypt.encrypt(TempPassword.value);

     var emp = {
       EmpEmailId: TempEmail.value,
       EmpPassword: TempPassword.value
       
     };
    
     console.log(emp);


   
     fetch("https://localhost:44328/api/login", {
       method: "POST",
       mode: "cors", // no-cors, *cors, same-origin
       cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
       credentials: "same-origin", // include, *same-origin, omit
       headers: {
         "Content-Type": "application/json",
         // 'Content-Type': 'application/x-www-form-urlencoded',
       },
       redirect: "follow", // manual, *follow, error
       referrerPolicy: "no-referrer",
       body: JSON.stringify(emp),
     })
       .then((res) => {
         console.log(res);
         return res.json();
       })
       .then((data) => {
         console.log(data.token);
         localStorage.setItem("token", data.token);
         
       });
}
// // (B) ENCRYPT & DECRYPT FUNCTIONS
// var crypt = {
//   // (B1) THE SECRET KEY
//   secret : "CIPHERKEY",
 
//   // (B2) ENCRYPT
//   encrypt : function (clear) {
//     var cipher = CryptoJS.AES.encrypt(clear, crypt.secret);
//     cipher = cipher.toString();
//     return cipher;
//   },
 
//   // (B3) DECRYPT
//   decrypt : function (cipher) {
//     var decipher = CryptoJS.AES.decrypt(cipher, crypt.secret);
//     decipher = decipher.toString(CryptoJS.enc.Utf8);
//     return decipher;
//   }
// };
 
// // (C) TEST
// // (C1) ENCRYPT CLEAR TEXT
// var cipher = crypt.encrypt("Mansha@123");
// console.log(cipher);
 
// // (C2) DECRYPT CIPHER TEXT
// var decipher = crypt.decrypt(cipher);
// console.log(decipher);
