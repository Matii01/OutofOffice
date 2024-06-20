import { useState } from "react";
import { useNavigate } from "react-router-dom";

import axios from "axios";
import "./index.css";

function App() {
  const navigation = useNavigate();
  const url = "https://localhost:7170";
  const [isLogin, setIsLogin] = useState(false);
  const [form, setForm] = useState({
    email: "",
    password: "",
  });

  function handleChange(event) {
    const { name, value } = event.target;

    setForm((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function onSubmit(event) {
    event.preventDefault();
    axios
      .post(`${url}/login`, JSON.stringify(form), {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((data) => {
        if (data.status === 200) {
          setIsLogin(true);
          localStorage.setItem("authToken", data.data.token);
          localStorage.setItem("expiration", data.data.expiration);
          localStorage.setItem("useRoles", data.data.useRoles);
          navigation("/lists");
          //navigateToPage(data.data.useRoles);
        }
        console.log(data);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function navigateToPage(role) {
    console.log(role[0]);

    switch (role[0]) {
      case "Employee":
        navigation("/employee");
        break;
      case "HRManager":
        navigation("/hrmanager");
        break;
      case "ProjectManager":
        navigation("/projectmanager");
        break;
      case "Administrator":
        navigation("/admin");
        break;
      default:
        break;
    }
  }

  //  UserName = "admin@admin.com",
  //  Email = "admin@admin.com"
  //  Password = "Admin@123";

  return (
    <div className="container-fluid">
      <div className="row">
        <div className="col">
          <div className="card mt-5 m-auto" style={{ width: "50%" }}>
            <div className="card-body">
              <form onSubmit={onSubmit}>
                <div className="mb-3">
                  <label className="form-label">Email address</label>
                  <input
                    type="email"
                    name="email"
                    onChange={handleChange}
                    className="form-control"
                    aria-describedby="emailHelp"
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Password</label>
                  <input
                    type="password"
                    onChange={handleChange}
                    name="password"
                    className="form-control"
                  />
                </div>
                <button type="submit" className="btn btn-primary">
                  Login
                </button>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;

/* 
import { useState } from "react";
import "./index.css";
import axios from "axios";
import api from "./axiosInterceptor";

function App() {
  const url = "https://localhost:7170";
  const [isLogin, setIsLogin] = useState(false);
  const [form, setForm] = useState({
    email: "admin@admin.com",
    password: "Admin@123",
  });

  function handleChange(event) {
    const { name, value } = event.target;

    setForm((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function onSubmit(event) {
    event.preventDefault();
    console.log(form);

    axios
      .post(`${url}/login`, JSON.stringify(form), {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((data) => {
        if (data.status === 200) {
          setIsLogin(true);
          localStorage.setItem("authToken", data.data.token);
          localStorage.setItem("expiration", data.data.expiration);
          localStorage.setItem("useRoles", data.data.useRoles);
        }
        console.log(data);
      })
      .catch((error) => {
        console.log(error);
      });
  }

  function arr() {
    api
      .get("/WeatherForecast/arr")
      .then((data) => {
        console.log(data.data);
      })
      .catch((error) => {});
  }
  function roles() {
    api
      .get(`/WeatherForecast/Roles`)
      .then((data) => {
        console.log(data);
      })
      .catch((error) => {});
  }
  function admin() {
    api
      .get(`/WeatherForecast/admin`)
      .then((data) => {
        console.log(data);
      })
      .catch((error) => {});
  }
  function user() {
    api
      .get(`/WeatherForecast/user`)
      .then((data) => {
        console.log(data);
      })
      .catch((error) => {});
  }

  //  UserName = "admin@admin.com",
  //  Email = "admin@admin.com"
  //  Password = "Admin@123";

  return (
    <div className="container" style={{ color: "white" }}>
      <div className="row">
        <div className="col">
          <div className="card mt-5">
            <div className="card-body">
              <form onSubmit={onSubmit}>
                <div className="mb-3">
                  <label className="form-label">Email address</label>
                  <input
                    type="email"
                    name="email"
                    onChange={handleChange}
                    className="form-control"
                    aria-describedby="emailHelp"
                  />
                </div>
                <div className="mb-3">
                  <label className="form-label">Password</label>
                  <input
                    type="password"
                    onChange={handleChange}
                    name="password"
                    className="form-control"
                  />
                </div>
                <button type="submit" className="btn btn-primary">
                  Submit
                </button>
              </form>
            </div>
          </div>

          <div className="card mt-2">
            <div className="card-body">
              <button
                type="button"
                className="btn btn-primary m-2"
                onClick={arr}
              >
                Arr
              </button>
              <button
                type="button"
                className="btn btn-primary m-2"
                onClick={roles}
              >
                Roles
              </button>
              <button
                type="button"
                className="btn btn-primary m-2"
                onClick={admin}
              >
                admin
              </button>
              <button
                type="button"
                className="btn btn-primary m-2"
                onClick={user}
              >
                user
              </button>
            </div>
          </div>
        </div>
        <div className="col">2 of 2</div>
      </div>
    </div>
  );
}

export default App;
*/
