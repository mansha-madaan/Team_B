console.log("js enabled");
let baseUrl = "https://localhost:44367/api/login";

let internalPageAfterLogin = "./Home.html";

let autoRedirectTime = 2000;

let TempEmail = document.getElementById("logemail");
let TempPassword = document.getElementById("logpass");
function validateEmailAddress(emailString) {
  var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return (
    //not null and checks
    !!emailString &&
    typeof emailString === "string" &&
    emailRegex.test(emailString)
  );
}
//to do:handel null values in password reset
//in login api handel what if user doesnot exists--current return error 500

function LoginUser() {
  let emp = {
    EmpEmailId: TempEmail.value.trim(),
    EmpPassword: TempPassword.value.trim(),
  };

  console.log(emp);

  if (!validateEmailAddress(emp.EmpEmailId)) {
    console.log("caught and called alert for email");
    swal({
      title: "WARNING!",
      text: "Invalid Email Id ",
      icon: "warning",
    });
    return;
  } else if (
    emp.EmpPassword === null ||
    emp.EmpPassword === undefined ||
    emp.EmpPassword === ""
  ) {
    console.log("caught and called alert");
    swal({
      title: "WARNING!",
      text: "Password cannot be Blank",
      icon: "warning",
    });
    return;
  }

  fetch(baseUrl, {
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
      if (res.status === 401) {
        console.log("called alert for wrong");
        swal({
          title: "WRONG!",
          text: "Invalid User Name or Password",
          icon: "error",
        });
        Promise.reject();
      }
      return res.json();
    })
    .then((data) => {
      console.log(data.token);

      localStorage.setItem("token", data.token);
      localStorage.setItem("empId", data.empId);
      swal({
        title: "Success",
        text: "",
        timer: autoRedirectTime,
        icon: "success",
      }).then(() => {
        if (localStorage.getItem("empId") !== 2)
          window.location.replace(internalPageAfterLogin);
        else window.location.replace("Admin/Home.html");
      });
    })
    .catch((err) => {
      console.log(err);
      console.log("oops something went wrong " + err);
    });
}

function forgotPassword() {
  let emp = {
    EmpEmailId: TempEmail.value.trim(),
    EmpPassword: TempPassword.value.trim(),
  };
  swal("Enter Your Email Id", {
    content: "input",
  })
    .then((value) => {
      //       if (!value) throw null;
      console.log("entered ", value);
      swal(`Write Otp sent to ${value}`, {
        content: "input",
      }).then((value) => {
        //  if (!value) throw null;
        console.log("entered ", value);
        swal(`Write new password`, {
          content: "input",
        }).then((value) => {
          console.log("entered ", value);
          swal(`Updated`, "Done!", "success");
          console.log("write ajax call");
        });
      });
    })
    .catch((err) => {
      if (err) {
        swal("oops", "Something Went Wrong!", "error");
      } else {
        swal.stopLoading();
        swal.close();
      }
    });
}
