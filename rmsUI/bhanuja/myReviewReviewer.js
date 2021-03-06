let baseUrl = "https://localhost:44367/api";
let toRedirectPage = "./Login.html";
//backkedn put y is empid nullable?
let beforeAjaxText = "Fetching ...";
let printStringIfEmpty = "Not Filled";
let reviewerNames = { Aditya: "Aditya", Mansha: "Mansha" };
let qaNames = { Himanshu: "Himanshu", Avneet: "Avneet" };

let mytable = document.getElementById("mytable");
let classButton = ["fa", "fa-edit", "toremove"];
let saveButtonClass = ["fa", "fa-save", "toremove"];
let disabledRditButton = "d-none";
let toShow = false;
let tableDiv = document.getElementsByClassName("back-container");
// console.log(tableDiv);
// console.log(mytable.rows[0].cells[1]);

let reviewName = document.getElementById("reviewName");
let targetDate = document.getElementById("targetDate");
let rstatus = document.getElementById("rstatus");
let reviewCycle = document.getElementById("reviewCycle");
let promotionCycle = document.getElementById("promotionCycle");
let rName = document.getElementById("rName");
let qaName = document.getElementById("qaName");
let allToRemove;

let selfEffect3000 = document.getElementById("ta-1");
let selfEffectStatus = document.getElementById("mySelect1");
let selfLeader3000 = document.getElementById("ta-5");
let selfLeaderStatus = document.getElementById("mySelect5");
let selfGrowth3000 = document.getElementById("ta-7");
let selfGrowthStatus = document.getElementById("mySelect7");
let selfFeedback3000 = document.getElementById("ta-9");
let selfFeedbackStatus = document.getElementById("mySelect9");

let rqEffect3000 = document.getElementById("ta-2");
let rqEffectStatus = document.getElementById("mySelect2");
let rqLeader3000 = document.getElementById("ta-6");
let rqLeaderStatus = document.getElementById("mySelect6");
let rqGrowth3000 = document.getElementById("ta-8");
let rqGrowthStatus = document.getElementById("mySelect8");
let rqFeedback3000 = document.getElementById("ta-10");
let rqFeedbackStatus = document.getElementById("mySelect10");

// rqEffect3000.textContent = "1";
// rqEffectStatus.value = "2";
// rqLeader3000.textContent = "3";
// rqLeaderStatus.value = "4";
// rqGrowth3000.textContent = "5";
// rqGrowthStatus.value = "6";
// rqFeedback3000.textContent = "7";
// rqFeedbackStatus.value = "8";

reviewName.textContent = "Fetching... ";
targetDate.textContent = "Fetching... ";
rstatus.textContent = "Fetching... ";
reviewCycle.textContent = "Fetching... ";
promotionCycle.textContent = "Fetching... ";
rName.textContent = "Fetching... ";
qaName.textContent = "Fetching... ";

const params = new URLSearchParams(window.location.search);
// console.log(params.get("rid"));

let fillDataIntoTable = (data) => {
  //   let {
  //     reviewName,
  //     rName,
  //     targetDate,
  //     rstatus,
  //     reviewCycle,
  //     promotionCycle,
  //     qaName,
  //   } = data;
  console.log(data);
  let Totaldate;
  if (data.targetDate !== null) {
    year = data.targetDate.slice(0, 4);
    month = data.targetDate.slice(5, 7);
    date = data.targetDate.slice(8, 10);
    Totaldate = month + "-" + date + "-" + year;
  }
  selfEffect3000.value = data.selfEffect;
  selfEffectStatus.value = data.selfEffectStatus;
  selfLeader3000.value = data.selfLead;
  selfLeaderStatus.value = data.selfLeadStatus;
  selfGrowth3000.value = data.selfGrowth;
  selfGrowthStatus.value = data.selfGrowthStatus;
  selfFeedback3000.value = data.selfFeed;
  selfFeedbackStatus.value = data.selfFeedStatus;
  if (data.rstatus === "Reviewer Level") {
    // console.log("setting up values");
    rqEffect3000.value = data.rqEffect;
    rqEffectStatus.value = data.rqEffectStatus;
    rqLeader3000.value = data.rqLead;
    rqLeaderStatus.value = data.rqLeadStatus;
    rqFeedback3000.value = data.rqFeed;
    rqFeedbackStatus.value = data.rqFeedStatus;
    rqGrowth3000.value = data.rqGrowth;
    rqGrowthStatus.value = data.rqGrowthStatus;
  }
  reviewName.textContent = !data.reviewName.trim()
    ? printStringIfEmpty
    : data.reviewName.trim();
  targetDate.textContent =
    data.targetDate === null ? printStringIfEmpty : Totaldate;
  rstatus.textContent = !data.rstatus.trim()
    ? printStringIfEmpty
    : data.rstatus.trim();
  reviewCycle.textContent = !data.reviewCycle.trim()
    ? printStringIfEmpty
    : data.reviewCycle.trim();
  promotionCycle.textContent = !data.promotionCycle.trim()
    ? printStringIfEmpty
    : data.promotionCycle.trim();
  rName.textContent = !data.rName.trim()
    ? printStringIfEmpty
    : data.rName.trim();
  qaName.textContent = !data.qaName.trim()
    ? printStringIfEmpty
    : data.qaName.trim();
};
//to do add loader before dom content load and make listener after ajax call
let doWorkAfterDom = () => {
  fetch(baseUrl + "/reviewlist/" + params.get("rid"), {
    method: "GET",
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`, //no prob if null handeled later
      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
  })
    .then((res) => {
      console.log(res);

      if (!res.ok) {
        throw new Error(res.status);
      } else return res.json();
    })
    .then((data) => {
      console.log(data);

      toShow = data.rstatus === "Save";
      allToRemove = document.querySelectorAll(".toremove");
      allToRemove.forEach((el) => el.remove());
      fillDataIntoTable(data);
      console.log("here", toShow);
      if (toShow) {
        let saveButton = document.createElement("a");
        saveButton.classList.add(...saveButtonClass);
        saveButton.addEventListener("click", (event) => {
          Promise.resolve(checkAndSave()).then((returned) => {
            if (!returned) {
              Swal.fire({
                title: "Incomplete Form",
                text: "Please Fill All The Fields!",
                icon: "warning",
                confirmButtonText: "ok",
              });
            }
          });
        });
        tableDiv[0].insertBefore(saveButton, mytable);
        // addEditButtons();
      }
    })
    .catch((err) => {
      console.log(err.message);
      if (err.message === "401") {
        console.log("in earror resolve");
        Swal.fire({
          title: "Please LogIn Again",
          text: " ",
          icon: "error",
          confirmButtonText: "ok",
        }).then(() => {
          window.location.replace(toRedirectPage);
        });

        return false;
      }
    });
};
//maintain this oder of both
document.addEventListener("DOMContentLoaded", doWorkAfterDom);
let addEditButtons = () => {
  for (let i = 0; i < mytable.rows.length; i++) {
    let edit = document.createElement("a");
    edit.classList.add(...classButton);
    if (mytable.rows[i].cells[1].id === "rstatus")
      edit.classList.add(disabledRditButton);
    if (mytable.rows[i].cells[1].id !== "rstatus")
      edit.addEventListener("click", (event) => {
        console.log(
          event,
          event.target,
          event.target.parentElement.parentElement
        );
        let rowCurrent = event.target.parentElement.parentElement;
        let fieldCurrent = rowCurrent.cells[0];
        let valueCurrent = rowCurrent.cells[1];
        let options = {
          title: "Error!",
          text: "Somethinng Went Wrong!",
          icon: "error",
          confirmButtonText: "ok",
          showCancelButton: true,
        };
        //   console.log("see ->", fieldCurrent, "-here-", reviewName);
        if (valueCurrent.id === "reviewName") {
          delete options.text;
          options.title = `Editing ${fieldCurrent.textContent}`;
          options.input = "text";
          options.icon = "info";
          options.inputValue = valueCurrent.textContent;
          options.inputValidator = (value) => {
            if (!value.trim()) {
              return "You need to write something!";
            }
          };
        } else if (valueCurrent.id === "targetDate") {
          delete options.text;
          options.title = `Editing ${fieldCurrent.textContent}`;
          options.html = "<input type='date'id='date'>";
          options.icon = "info";
          options.didOpen = () => {
            function dateToYMD(date) {
              var d = date.getDate();
              var m = date.getMonth() + 1; //Month from 0 to 11
              var y = date.getFullYear();
              return (
                "" +
                y +
                "-" +
                (m <= 9 ? "0" + m : m) +
                "-" +
                (d <= 9 ? "0" + d : d)
              );
            }
            Swal.getPopup().querySelector("#date").value = dateToYMD(
              new Date()
            );
          };
          options.preConfirm = () => {
            const dateValue = Swal.getPopup().querySelector("#date").value;

            return dateValue.split("-").reverse().join("-");
          };
        } else if (valueCurrent.id === "reviewCycle") {
          delete options.text;
          options.title = `Editing ${fieldCurrent.textContent}`;
          options.input = "text";
          options.icon = "info";
          options.inputValue = valueCurrent.textContent;
          options.inputValidator = (value) => {
            if (!value.trim()) {
              return "You need to write something!";
            }
          };
        } else if (valueCurrent.id === "promotionCycle") {
          delete options.text;
          options.title = `Editing ${fieldCurrent.textContent}`;
          options.input = "text";
          options.icon = "info";
          options.inputValue = valueCurrent.textContent;
          options.inputValidator = (value) => {
            if (!value.trim()) {
              return "You need to write something!";
            }
          };
        } else if (valueCurrent.id === "rName") {
          delete options.text;
          options.title = `Select a ${fieldCurrent.textContent}`;
          options.input = "select";
          options.icon = "info";
          options.inputOptions = reviewerNames;
        } else if (valueCurrent.id === "qaName") {
          delete options.text;
          options.title = `Select a ${fieldCurrent.textContent}`;
          options.input = "select";
          options.icon = "info";
          options.inputOptions = qaNames;
        }
        Swal.fire(options).then((returned) => {
          console.log(returned.value);
          if (returned.isConfirmed) {
            valueCurrent.textContent = returned.value;
          }
        });
      });

    mytable.rows[i].insertCell(2).appendChild(edit);
  }
};
//api breaking, returning ok always
let checkAndSave = () => {
  console.log(
    !reviewName.textContent,
    !targetDate.textContent,
    !reviewCycle.textContent,
    !promotionCycle.textContent,
    !rName.textContent,
    !qaName.textContent,
    !rqEffect3000.value,
    !rqEffectStatus.value,
    !rqGrowth3000.value,
    !rqGrowthStatus.value,
    !rqFeedback3000.value,
    !rqFeedbackStatus.value,
    !rqLeader3000.value,
    !rqLeaderStatus.value
  );
  if (
    !reviewName.textContent ||
    !targetDate.textContent ||
    !reviewCycle.textContent ||
    !promotionCycle.textContent ||
    !rName.textContent ||
    !qaName.textContent ||
    !rqEffect3000.value ||
    rqEffectStatus.value === "" ||
    !rqGrowth3000.value ||
    rqGrowthStatus.value === "" ||
    !rqFeedback3000.value ||
    rqFeedbackStatus.value === "" ||
    !rqLeader3000.value ||
    rqLeaderStatus.value === ""
  )
    return false;

  targetDate.textContent = targetDate.textContent
    .split("-")
    .reverse()
    .join("-");
  let record = {
    RqEffect: rqEffect3000.value,
    RqEffectStatus: rqEffectStatus.value,
    RqLead: rqLeader3000.value,
    RqLeadStatus: rqLeaderStatus.value,
    RqFeed: rqFeedback3000.value,
    RqFeedStatus: rqFeedbackStatus.value,
    RqGrowth: rqGrowth3000.value,
    RqGrowthStatus: rqGrowthStatus.value,
    // SelfEffect:  //these fields are just adjacent reviewer fields
    // rqEffectStatus
    // SelfLead:
    // SelfLeadStatus
    // SelfGrowth
    // rqGrowthStatus
    // selfFeed
    // selfFeedStatus
  };
  console.log(JSON.stringify(record));
  fetch(baseUrl + "/Reviewer/" + params.get("rid"), {
    method: "PUT",
    mode: "cors", // no-cors, *cors, same-origin
    cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials: "same-origin", // include, *same-origin, omit
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${localStorage.getItem("token")}`, //no prob if null handeled later

      // 'Content-Type': 'application/x-www-form-urlencoded',
    },
    body: JSON.stringify(record),
    redirect: "follow", // manual, *follow, error
    referrerPolicy: "no-referrer",
  })
    // .then((res) => {
    //   // console.log(res);
    //   // if (!res.ok) {
    //   //   throw new Error(res.status);
    //   // }
    //   // // if (res.status !== 200) {
    //   //   Swal.fire({
    //   //     title: "Error!",
    //   //     text: "Somethinng Went Wrong While Saving!",
    //   //     icon: "error",
    //   //     confirmButtonText: "ok",
    //   //   });
    //   //   Promise.reject();
    //   // }
    //   // else
    //    return res.json();
    // })
    .then((data) => {
      if (!data.ok) {
        throw new Error(data.status);
      }
      Swal.fire({
        title: "Saved",
        text: "",
        icon: "success",
        confirmButtonText: "ok",
      });
      doWorkAfterDom();
    })
    .catch((err) => {
      console.log(err);
      if (err.message === "401") {
        Swal.fire({
          title: "Please LogIn Again",
          text: " ",
          icon: "error",
          confirmButtonText: "ok",
        }).then(() => {
          window.location.replace(toRedirectPage);
        });

        return false;
      }

      // if(localStorage.getItem("token"))

      Swal.fire({
        title: "Could not Save!",
        text: "Somethinng Went Wrong!",
        icon: "error",
        confirmButtonText: "ok",
      });
    });
  return true;
};

////////////////////////////////////////////////////
function showhide1() {
  var div = document.getElementById("effectiveness");
  if (div.style.display !== "none") {
    div.style.display = "none";
  } else {
    div.style.display = "block";
  }
}

function showhide2() {
  var div = document.getElementById("delivery");
  if (div.style.display !== "none") {
    div.style.display = "none";
  } else {
    div.style.display = "block";
  }
}

function showhide3() {
  var div = document.getElementById("leadership");
  if (div.style.display !== "none") {
    div.style.display = "none";
  } else {
    div.style.display = "block";
  }
}

function showhide4() {
  var div = document.getElementById("growth");
  if (div.style.display !== "none") {
    div.style.display = "none";
  } else {
    div.style.display = "block";
  }
}

function showhide5() {
  var div = document.getElementById("feedback");
  if (div.style.display !== "none") {
    div.style.display = "none";
  } else {
    div.style.display = "block";
  }
}
