$(document).ready(function () {
  $("#sidebar").mCustomScrollbar({
    theme: "minimal",
  });

  $("#dismiss, .overlay").on("click", function () {
    $("#sidebar").removeClass("active");
    $(".overlay").removeClass("active");
  });

  $("#sidebarCollapse").on("click", function () {
    $("#sidebar").addClass("active");
    $(".overlay").addClass("active");
    $(".collapse.in").toggleClass("in");
    $("a[aria-expanded=true]").attr("aria-expanded", "false");
  });
});

function allEmp() {
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
        // getById(empRequest.empId);
          sendEmail(empRequest.empEmailId);
      });

      // do something with data
      console.log(data);
    })
    // .then((data) => {
    //   Swal.fire({
    //     title: "Confirm to initiate a review?",
    //     showDenyButton: true,
    //     //showCancelButton: true,
    //     confirmButtonText: `  Confirm`,
    //     denyButtonText: `Cancel`,
    //   }).then((result) => {
    //     /* Read more about isConfirmed, isDenied below */
    //     if (result.isConfirmed) {
    //       data.forEach((empRequest) => {
    //         // console.log(user);
    //         sendEmail(empRequest.empEmailId);
    //       });
    //       Swal.fire("Review Initiated", "", "success");
    //     } else if (result.isDenied) {
    //       Swal.fire("Review not Initiated", "", "info");
    //     }
    //   });
    // })
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
    //ReviewName: "Not Filled",
    ReviewName: "Review 2021",
    TargetDate: "2018-12-28",
    ReviewCycle: "Oct 2021",
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
    .then((data) => {
      Swal.fire({
        title: "Confirm to initiate a review?",
        showDenyButton: true,
        //showCancelButton: true,
        confirmButtonText: `  Confirm`,
        denyButtonText: `Cancel`,
      }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
          //data.forEach((empRequest) => {
          // console.log(user);
          //sendEmail(empRequest.empEmailId);
          allReview();

          // });
          Swal.fire("Review Initiated", "", "success");
        } else if (result.isDenied) {
          Swal.fire("Review not Initiated", "", "info");
        }
      });
    })
    .catch((error) => console.log("error", error));
}

// function initiateReview() {
//   allEmp();
//   var myHeaders = new Headers();
//   myHeaders.append("Content-Type", "application/json");

//   var raw = JSON.stringify({
//     ReviewName: "Not Filled",
//     TargetDate: "2018-12-28",
//     ReviewCycle: "Not Filled",
//     PromotionCycle: "Not Filled",
//     RName: "Not Filled",
//     QaName: "Not Filled",
//   });

//   var requestOptions = {
//     method: "POST",
//     headers: myHeaders,
//     body: raw,
//     redirect: "follow",
//   };

//   fetch("https://localhost:44367/api/admin", requestOptions)
//     .then((response) => response.text())
//     .then((result) => {
//       allReview();
//       console.log(result);
//     })
//     .catch((error) => console.log("error", error));
// }

function allReview() {
  myFunction();
  var url = "https://localhost:44367/api/admin";

  fetch(url, {
    mode: "cors",

    cache: "no-cache",

    credentials: "same-origin",

    headers: {
      "Content-Type": "application/json",

      //Authorization: `Bearer ${localStorage.getItem("token")}`,
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
             <td data-heading="Form Name">${reviewInfo.reviewName}</td>
              
              
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
      console.log("Looks like there was a problem: \n", error);
    });
}
function myFunction() {
  myVar = setTimeout(showPage, 500);
}

function showPage() {
  document.getElementById("loader").style.display = "none";
  document.getElementById("myDiv").style.display = "block";
}
{
  /* <td data-heading="Form Name">${reviewInfo.reviewName}</td>
              
             <td data-heading="Cycle">${reviewInfo.reviewCycle}</td>
             <td data-heading="TargetData">${Totaldate}</td>
             <td data-heading="Status">${reviewInfo.rstatus}</td>
             <td ><button class="btn btn-warning" type="submit" onclick="location.href='./recordView.html?rid=${reviewInfo.rid}'">View</button></td> */
}

// onclick="location.href='./recordView.html?rid=${reviewInfo.rid}'"s
function mySearch() {
  var input, filter, table, tr, td, i, txtValue;
  input = document.getElementById("myInput");
  filter = input.value.toUpperCase();
  table = document.getElementById("myTable");
  tr = table.getElementsByTagName("tr");
  for (i = 0; i < tr.length; i++) {
    td = tr[i].getElementsByTagName("td")[0];
    if (td) {
      txtValue = td.textContent || td.innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        tr[i].style.display = "";
      } else {
        tr[i].style.display = "none";
      }
    }
  }
}

////////////////////
// function getById(saveid) {
//   // const url = 'https://localhost:44339/api/user/'+id;
//   // console.log(url)
//   fetch("https://localhost:44367/api/profile/" + saveid, {
//     mode: "cors", // no-cors, *cors, same-origin
//     cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
//     credentials: "same-origin", // include, *same-origin, omit
//     headers: {
//       "Content-Type": "application/json",
//       // 'Content-Type': 'application/x-www-form-urlencoded',
//       Authorization: `Bearer ${localStorage.getItem("token")}`,
//     },
//     redirect: "follow", // manual, *follow, error
//     referrerPolicy: "no-referrer",
//   })
//     .then((res) => res.json())
//     .then((data) => {
//       // let li = '';
//       // data=JSON.parse(data)
//       console.log(data);

//       // console.log(user);

//       // document.getElementById("doj").value = data[0].dateJoin;
//       data[0].r_Name;
//       data[0].qA_Name;
//       console.log(data[0].qA_Name);
//       console.log(data[0].r_Name);
//       return [data[0].r_Name, data[0].qA_Name];

//       // do something with data
//       // console.log(data);
//     })
//     .catch(function (error) {
//       console.log("Looks like there was a problem: \n", error);
//     });
// }
