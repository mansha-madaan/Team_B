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

let baseUrl = "https://localhost:44367/api";
var id1 = localStorage.getItem("empId");

////////////////////////////////////////////////////////////////////////////////////////

function empSelfReview() {
  myFunction();
  var url = baseUrl + "/self/" + id1.toString();
  fetch(url, {
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
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
             <td ><button class="btn btn-warning" type="submit" onclick="location.href='./recordView.html?rid=${reviewInfo.rid}'">View</button></td>
             
           </tr>`;
      });
      document.getElementById("selfTableContent").innerHTML = li;
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}

/////////////////////////////////////////////////////////////////////////////////////////

function empReviewerReview() {
  myFunction();
  var url = baseUrl + "/reviewer/" + id1.toString();
  fetch(url, {
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
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
        //  console.log(reviewInfo.targetDate);
        if (reviewInfo.targetDate != null) {
          year = reviewInfo.targetDate.slice(0, 4);
          month = reviewInfo.targetDate.slice(5, 7);
          date = reviewInfo.targetDate.slice(8, 10);
          Totaldate = month + "/" + date + "/" + year;
        } else {
          Totaldate = "---";
        }
        li += `<tr>
             <td data-heading="Form Name">${reviewInfo.reviewName}</td>
             <td data-heading="Cycle">${reviewInfo.reviewCycle}</td>
             <td data-heading="TargetData">${Totaldate}</td>
             <td data-heading="Status">${reviewInfo.rstatus}</td>
             <td ><button class="btn btn-warning" type="submit"  onclick="location.href='./recordViewReviewer.html?rid=${reviewInfo.rid}'">View</button></td>
           </tr>`;
      });
      document.getElementById("reviewerTableContent").innerHTML = li;
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}

///////////////////////////////////////////////////////////////////////////////////////

function empQaReview() {
  myFunction();
  var url = baseUrl + "/Qa/" + id1.toString();
  fetch(url, {
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
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
        //  console.log(reviewInfo.targetDate);
        if (reviewInfo.targetDate != null) {
          year = reviewInfo.targetDate.slice(0, 4);
          month = reviewInfo.targetDate.slice(5, 7);
          date = reviewInfo.targetDate.slice(8, 10);
          Totaldate = month + "/" + date + "/" + year;
        } else {
          Totaldate = "---";
        }
        li += `<tr>
             <td data-heading="Form Name">${reviewInfo.reviewName}</td>
             <td data-heading="Cycle">${reviewInfo.reviewCycle}</td>
             <td data-heading="TargetData">${Totaldate}</td>
             <td data-heading="Status">${reviewInfo.rstatus}</td>
             <td ><button class="btn btn-warning" type="submit"  onclick="location.href='./recordViewQaer.html?rid=${reviewInfo.rid}'">View</button></td>
           </tr>`;
      });
      document.getElementById("qaTableContent").innerHTML = li;
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}

/////////////////////////////////////////////////////////////////////////////////////////////

function empCloseReview() {
  myFunction();
  var url = baseUrl + "/self/" + id1.toString();
  fetch(url, {
    mode: "cors",
    cache: "no-cache",
    credentials: "same-origin",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`,
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
        if (reviewInfo.rstatus == "Closed") {
          //  console.log(reviewInfo.targetDate);
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
             <td ><button class="btn btn-warning" type="submit" onclick="location.href='./recordViewClosed.html?rid=${reviewInfo.rid}'">View</button></td>
           </tr>`;
        }
      });

      document.getElementById("closedTableContent").innerHTML = li;
      console.log(data);
    })
    .catch(function (error) {
      console.log("Looks like there was a problem: \n", error);
    });
}

/////////////////////////////////////////////////////////////////////////////////////////////////

function extra(id, st) {
  window.open(closed.html);

  if (st == "Initiate") {
    var id1 = 1;
    var url = baseUrl + "/self/" + id1.toString();
    fetch(url, {
      mode: "cors",
      cache: "no-cache",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
      redirect: "follow",
      referrerPolicy: "no-referrer",
    })
      .then((res) => res.json())
      .then((data) => {
        console.log("inside if");
        console.log(data);
      })
      .catch(function (error) {
        console.log("Looks like there was a problem: \n", error);
      });
  } else {
    var id1 = 1;
    var url = baseUrl + "/reviewer/" + id1.toString();
    fetch(url, {
      mode: "cors",
      cache: "no-cache",
      credentials: "same-origin",
      headers: {
        "Content-Type": "application/json",
      },
      redirect: "follow",
      referrerPolicy: "no-referrer",
    })
      .then((res) => res.json())
      .then((data) => {
        console.log("inside else");
        console.log(data);
      })
      .catch(function (error) {
        console.log("Looks like there was a problem: \n", error);
      });
  }
}

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

//////////////
function myFunction() {
  myVar = setTimeout(showPage, 500);
}

function showPage() {
  document.getElementById("loader").style.display = "none";
  document.getElementById("myDiv").style.display = "block";
}


