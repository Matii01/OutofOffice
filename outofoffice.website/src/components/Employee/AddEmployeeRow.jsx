import { faX } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import axios from "axios";
import { useAddEmployeeMutation } from "../../api/employeeApi";

function AddEmployeeTableRow({ selectData, onCancel, onAdd }) {
  const isAdmin = localStorage.getItem("useRoles") === "Administrator";
  const [addEmployee] = useAddEmployeeMutation();
  const [edited, setEdited] = useState({
    email: "",
    password: "",
    fullName: "",
    subdivision: 0,
    position: 0,
    status: 0,
    peopleParthner: 0,
    outOfOfficeBalance: 0,
    photo: "",
  });

  function handleChange(event) {
    const { name, value } = event.target;

    setEdited((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function onSaveClick() {
    if (!addedRequiredField(edited)) {
      alert("fill in the missing fields");
      return;
    }

    addEmployee(edited).then(() => {
      onAdd();
      onCancel();
    });
  }

  function addedRequiredField(obj) {
    if (obj.email.trim() === "") {
      return false;
    }
    if (obj.password.trim() === "") {
      return false;
    }
    if (obj.fullName.trim() === "") {
      return false;
    }
    return true;
  }

  return (
    <>
      <tr>
        <td>
          <FontAwesomeIcon
            icon={faX}
            style={{ cursor: "pointer" }}
            onClick={onCancel}
          />
        </td>
        <td>
          <input
            type="emil"
            value={edited.email}
            name="email"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td>
          <input
            type="password"
            value={edited.password}
            name="password"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td>
          <input
            type="text"
            value={edited.fullName}
            name="fullName"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td>
          <select
            className="form-select"
            name="subdivision"
            value={edited.subdivision}
            aria-label="Default select example"
            onChange={handleChange}
          >
            {selectData.subdivision.map((it) => (
              <option key={it.value} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
        </td>
        <td>
          <select
            name="position"
            value={edited.position}
            onChange={handleChange}
            className="form-select"
            aria-label="Default select example"
            disabled={!isAdmin}
          >
            {selectData.position.map((it) => (
              <option key={it.value} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
        </td>
        <td>
          <select
            name="status"
            value={edited.status}
            onChange={handleChange}
            className="form-select"
            aria-label="Default select example"
          >
            {selectData.status.map((it) => (
              <option key={it.value} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
        </td>
        <td>
          <select
            name="peopleParthner"
            value={edited.peopleParthner}
            onChange={handleChange}
            className="form-select"
            aria-label="Default select example"
          >
            <option></option>
            {selectData.hrManagers.map((it) => (
              <option key={it.id} value={it.id}>
                {it.fullName}
              </option>
            ))}
          </select>
        </td>
        <td>
          <input
            value={edited.outOfOfficeBalance}
            type="number"
            min="0"
            name="outOfOfficeBalance"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td>
          <button className="btn btn-primary" onClick={onSaveClick}>
            Save
          </button>
        </td>
      </tr>
    </>
  );
}

export default AddEmployeeTableRow;
