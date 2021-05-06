function logoutuser() {
  this.token = null;
  this.isAuthenticated = false;

  this.clearAuthData();
  this.location.replace("/admin/Login.html");

  // clearTimeout(this.tokenTimer);
  
}
function clearAuthData() {
  localStorage.removeItem("token");
    // localStorage.removeItem("expiration");
  localStorage.removeItem("name");
    localStorage.removeItem("empId");
}

