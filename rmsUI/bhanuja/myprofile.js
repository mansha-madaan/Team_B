
    

function getById() {​​​​​​​​
    myFunction();
    var saveid = localStorage.getItem("empId");
     
    // const url = 'https://localhost:44339/api/user/'+id;
    // console.log(url)
    fetch("https://localhost:44367/api/profile/" + saveid, {​​​​​​​​
    mode:"cors", // no-cors, *cors, same-origin
    cache:"no-cache", // *default, no-cache, reload, force-cache, only-if-cached
    credentials:"same-origin", // include, *same-origin, omit
    headers: {​​​​​​​​
    "Content-Type":"application/json",
    // 'Content-Type': 'application/x-www-form-urlencoded',
        }​​​​​​​​,
    redirect:"follow", // manual, *follow, error
    referrerPolicy:"no-referrer",
      }​​​​​​​​)
        .then((res) =>res.json())
        .then((data) => {​​​​​​​​
    // let li = '';
    // data=JSON.parse(data)
    console.log(data);
     
    // console.log(user);
    document.getElementById("fname").value = data[0].firstName;
    document.getElementById("lname").value = data[0].lastName;
    document.getElementById("email").value = data[0].emailId;
    document.getElementById("lc").value = data[0].plocation;
    document.getElementById("designation").value = data[0].prole;
    document.getElementById("Total").value = data[0].totalExp;
    document.getElementById("doj").value = data[0].dateJoin;
    document.getElementById("subject").value = data[0].skills;
     
    // do something with data
    console.log(data);
        }​​​​​​​​)
        .catch(function (error) {​​​​​​​​
    console.log("Looks like there was a problem: \n", error);
        }​​​​​​​​);
    
    empSelfReview();
    }​​​​​​​​
     
    function myFunction() {​​​​​​​​
    myVar = setTimeout(showPage, 3000);
    }​​​​​​​​
     
    function showPage() {​​​​​​​​
    document.getElementById("loader").style.display = "none";
    document.getElementById("myDiv").style.display = "block";
    }​​​​​​​​
    
    