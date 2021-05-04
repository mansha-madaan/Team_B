function allEmp() {
  myFunction();
  var myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");
  var requestOptions = {
    method: "GET",
    headers: myHeaders,
    
    redirect: "follow",
  };

  fetch("https://localhost:44367/api/login", requestOptions)
    .then((res) => res.json())
    .then((data) => {
      
      data.forEach((empRequest) => {
        // console.log(user);
          sendEmail(empRequest.empEmailId);
      });
      

      // do something with data
      console.log(data);
    }).then(( 
      Swal.fire({
      title: "Review initiated",
      text: "",
      timer: 3000,
      icon: "success",
    })))
    .catch((error) => console.log("error", error));
}

function sendEmail(emailID) {

    var formdata = new FormData();
    formdata.append("ToEmail", emailID.toString());
    formdata.append("Subject", "Review Initiated");
    formdata.append("Body", "Greeting, Kindly fill your reviews asap!");
    formdata.append(" Attachments", "");

    var requestOptions = {
      method: "POST",
      body: formdata,
      redirect: "follow",
    };

    fetch("https://localhost:44367/api/mail/send", requestOptions)
      .then((response) => response.text())
      .then((result) => console.log(result))
      .catch((error) => console.log("error", error));
}


function initiateReview() {
  allEmp();
  var myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

  var raw = JSON.stringify({
    ReviewName: "Not Filled",
    TargetDate: "2018-12-28",
    ReviewCycle: "Not Filled",
    PromotionCycle: "Not Filled",
    RName: "Not Filled",
    QaName: "Not Filled",
  });

  var requestOptions = {
    method: "POST",
    headers: myHeaders,
    body: raw,
    redirect: "follow",
  };

  fetch("https://localhost:44367/api/admin", requestOptions)
    .then((response) => response.text())
    .then((result) => console.log(result))
    .catch((error) => console.log("error", error));
  allReview()
}


function allReview() {
  

  var url = "https://localhost:44367/api/admin";

  fetch(url, {
    mode: "cors",

    cache: "no-cache",

    credentials: "same-origin",

    headers: {
      "Content-Type": "application/json",

      //Authorization: `Bearer ${localStorage.getItem("token")}`,
    },

    redirect: "follow",

    referrerPolicy: "no-referrer",
  })
    .then((res) => res.json())

    .then((data) => {
      let li = "";

      let Totaldate = "";

      let month = "";

      let year = "";

      let date = "";

      data.forEach((reviewInfo) => {
        console.log(reviewInfo);

        if (reviewInfo.targetDate != null) {
          year = reviewInfo.targetDate.slice(0, 4);

          month = reviewInfo.targetDate.slice(5, 7);

          date = reviewInfo.targetDate.slice(8, 10);

          Totaldate = month + "/" + date + "/" + year;
        } else {
          Totaldate = "-----";
        }

        li += `<tr>

             <td data-heading="Form Name">${reviewInfo.reviewName}</td>
              
             <td data-heading="Cycle">${reviewInfo.reviewCycle}</td>

             <td data-heading="TargetData">${Totaldate}</td>

             <td data-heading="Status">${reviewInfo.rstatus}</td>

             <td><button type="button" class="btn btn-warning" onclick="location.href='/admin/recordViewAdmin.html?rid=${reviewInfo.rid}'">View</button></td>

             

           </tr>`;
      });

      document.getElementById("allTableContent").innerHTML = li;

      console.log(data);
    })

    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}
function myFunction() {
  myVar = setTimeout(showPage, 3000);
}

function showPage() {
  document.getElementById("loader").style.display = "none";
  document.getElementById("myDiv").style.display = "block";
}
{/* <td data-heading="Form Name">${reviewInfo.reviewName}</td>
              
             <td data-heading="Cycle">${reviewInfo.reviewCycle}</td>

             <td data-heading="TargetData">${Totaldate}</td>

             <td data-heading="Status">${reviewInfo.rstatus}</td>

             <td ><button class="btn btn-warning" type="submit" onclick="location.href='./recordView.html?rid=${reviewInfo.rid}'">View</button></td> */}

// onclick="location.href='./recordView.html?rid=${reviewInfo.rid}'"s
