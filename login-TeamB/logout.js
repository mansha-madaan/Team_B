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
}

function Redirect() {
  //console.log("inside redirect");
    window.open("http://127.0.0.1:5500/index.html", "_blank");
    //mention url of you login page
}
