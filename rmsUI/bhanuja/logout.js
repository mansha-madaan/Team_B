function logoutuser() {
  this.token = null;
  this.isAuthenticated = false;

  this.clearAuthData();
  clearTimeout(this.tokenTimer);
  Redirect();
}
function clearAuthData() {
  localStorage.removeItem("token");
    localStorage.removeItem("expiration");
    localStorage.removeItem("empId");
}

function Redirect() {
  //console.log("inside redirect");
  window.open("http://127.0.0.1:5501/Login.html", "_blank");
  //mention url of you login page
}
