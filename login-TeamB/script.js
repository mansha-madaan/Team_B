function LoginUser() {
    

    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");

    var inemmail = document.getElementById("logemail");
    var inpassword = document.getElementById("logpass");
    var hash = calcMD5("input string");
    console.log(hash);

    var raw = JSON.stringify({
        "InternId": form1.email.value,
        "Password": form1.password.value
    });



    // "firstName": form1.fname.value,
    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };

    fetch(Baseurl + "/api/Login", requestOptions)
        .then(response => response.json())
        .then(result => {
            if (result.token == '') {
                alert("Wrong Username And Password!")
            }
            else {
                localStorage.setItem("student-management-token", result.token);
                location.replace("./Home.html")

            }
        })
        .catch(error => alert("Some Error Occured!"));
}