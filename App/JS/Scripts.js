const API_URL_USER = "https://localhost:7172/api/";
const API_URL_CAR = "https://localhost:7201/api/";

//document.getElementById("loginClick").addEventListener("click", login);
//document.getElementById("registerClick").addEventListener("click", register);
function login() {
  let email = document.forms["LoginForm"]["email"].value;
  let password = document.forms["LoginForm"]["password"].value;
  if (email === "" || password === "") return;
  const data = { email, password };
  fetch(API_URL_USER + "User/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      if (x.ok) return x.json();
      return Promise.reject(x);
    })
    .then((x) => {
      localStorage.setItem("token", x.token);

      redirect("login.html", "home.html");
    })
    .catch((err) => {
      let msg1 = document.getElementById("msg1");
      msg1.style.display = "block";
    });
}
function register() {
  const email = document.forms["registerForm"]["email"].value;
  const password = document.forms["registerForm"]["password"].value;
  const name = document.forms["registerForm"]["name"].value;
  const surname = document.forms["registerForm"]["surname"].value;
  const verifyPassword = document.forms["registerForm"]["verifyPassword"].value;
  if (password !== verifyPassword) {
    let msg = document.getElementById("msg");
    msg.style.display = "block";
    return;
  }
  const data = {
    email,
    password,
    name,
    surname,
  };
  fetch(API_URL_USER + "User/register", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      if (x.ok) return x.json();
      return Promise.reject(x);
    })
    .then((x) => {
      if (x) {
        alert("Register Succeed!");
        redirect("register.html", "login.html");
      } else {
        let msg = document.getElementById("message");
        msg.style.display = "block";
      }
    })
    .catch((err) => {});
}

function logOut() {
  localStorage.clear();
  redirectOnLogOut();
}

function loadCars(carType) {
  localStorage.setItem("carType", carType);
  redirect("home.html", "cars.html");
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}

function redirectOnLogOut() {
  let url = window.location.href;
  const oldUrl = url.split("/").at(-1);
  redirect(oldUrl, "login.html");
}

function backHome() {
  redirect("adminPanel.html", "home.html");
}

function createCar() {
  redirect("adminPanel.html", "adminCarsAdd.html");
}
