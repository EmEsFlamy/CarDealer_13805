const paymentList = document.querySelector("#paymentList");
const template = document.querySelector("#payment-template");

let payments = undefined;
var paymentId

window.addEventListener("load", () => {
  const API_URL_CAR = "https://localhost:7201/api/";
  const token = localStorage.getItem("token");
  fetch(API_URL_CAR + "Payment/GetAllUnpaid", {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
  })
    .then((x) => (x = x.json()))
    .then((res) => {
      payments = res;
      paymentList.innerHTML = "";
      res.forEach((payment, index) => {
        createPaymentDiv(payment, index);
      });
      createPaymentsEventListener();
    });
});

function createPaymentDiv(payment, index) {
  const clone = template.content.cloneNode(true);
  const name = clone.querySelector(".userName");
  const surname = clone.querySelector(".userSurname");
  const mark = clone.querySelector(".carMark");
  const model = clone.querySelector(".carModel");
  const startDate = clone.querySelector(".startDate");
  const endDate = clone.querySelector(".endDate");
  const price = clone.querySelector(".carPrice");
  // const radioValue = clone.getElementById("payment-value");
  // radioValue.value = index;
  name.innerHTML = payment.name;
  surname.innerHTML = payment.surname;
  mark.innerHTML = payment.mark;
  model.innerHTML = payment.model;
  startDate.innerHTML = payment.startDate;
  endDate.innerHTML = payment.endDate;
  price.innerHTML = payment.totalPrice;
  paymentList.appendChild(clone);
}

function createPaymentsEventListener() {
  const cc = paymentList.querySelectorAll(".payment-container");
  cc.forEach((payment) => {
    payment.addEventListener("click", (e) => {
      if (e.target.matches("input")) {
        const index = e.target.value;
        selectedPaymentId = payments.at(index).paymentId;
      }
    });
  });
}

function pay() {
  const data = {
    id: selectedPaymentId
  };
  const token = localStorage.getItem("token")
  fetch(API_URL_CAR + "Payment/MarkAsPaid", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`
    },
    body: JSON.stringify(data),
  });
}


function addCar() {
  const API_URL_CAR = "https://localhost:7201/api/";
  const carType = Number(document.forms["CarsAddForm"]["CarType"].value);
  const mark = document.forms["CarsAddForm"]["Mark"].value;
  const model = document.forms["CarsAddForm"]["Model"].value;
  const price = document.forms["CarsAddForm"]["Price"].value;
  const data = {
    carType,
    mark,
    model,
    price,
  };
  
  const token = localStorage.getItem("token");
  fetch(API_URL_CAR + "car", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Authorization: `Bearer ${token}`,
    },
    body: JSON.stringify(data),
  })
    .then((x) => {
      alert("Car created!");
      redirect("adminCarsAdd.html", "home.html");
    })
    .catch((err) => {});
}

function redirect(oldUrl, newUrl) {
  let url = window.location.href;
  url = url.replace(oldUrl, newUrl);
  window.location.href = url;
}
function backAdm() {
    redirect("adminCarsAdd.html", "adminPanel.html");
}