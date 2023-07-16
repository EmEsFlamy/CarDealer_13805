const adminPanelButton = document.querySelector(".admin-panel");
const adminPanelButton1 = document.querySelector(".admin-panel1");


window.addEventListener("load", () => {
    const role = getUserRoleFromToken();
    console.log(role);
    if (role === "1") {
      adminPanelButton.style.display = "block";
      adminPanelButton1.style.display = "block";
    }
  });
  
  function getUserRoleFromToken() {
    const token = localStorage.getItem("token");
    const t = JSON.parse(atob(token.split(".")[1]));
    return t["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  }