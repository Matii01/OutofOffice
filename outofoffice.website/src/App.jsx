import { useState } from "react";
import { useNavigate } from "react-router-dom";

import axios from "axios";
import "./index.css";
import { config } from "./config";

function App() {
  const navigation = useNavigate();
  const [error, setError] = useState(false);
  const [form, setForm] = useState({
    email: "",
    password: "",
  });

  function handleChange(event) {
    const { name, value } = event.target;

    error && setError(false);
    setForm((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function onSubmit(event) {
    event.preventDefault();
    axios
      .post(`${config.baseUrl}/login`, JSON.stringify(form), {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((data) => {
        if (data.status === 200) {
          localStorage.setItem("authToken", data.data.token);
          localStorage.setItem("expiration", data.data.expiration);
          localStorage.setItem("useRoles", data.data.useRoles);
          navigation("/lists");
        }
      })
      .catch((data) => {
        console.log(data);
        setError(true);
      });
  }

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
                  {error && (
                    <div className="needs-validation">
                      Invalid e-mail or password
                    </div>
                  )}
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
