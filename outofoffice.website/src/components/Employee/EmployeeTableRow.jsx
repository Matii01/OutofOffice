import { faSave } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import { useUpdateEmployeeMutation } from "../../api/employeeApi";

function EmployeeTableRow({ employee, selectData, showPasswordAndEmail }) {
  const isAdmin = localStorage.getItem("useRoles") === "Administrator";
  const userRole = localStorage.getItem("useRoles");
  const canEdit = ["HRManager", "Administrator"].includes(userRole);

  const [edited, setEdited] = useState({
    ID: employee.id,
    fullName: employee.fullName,
    subdivision: employee.subdivision,
    position: employee.position,
    status: employee.status,
    peopleParthner: employee.peopleParthner,
    outOfOfficeBalance: employee.outOfOfficeBalance,
    photo: "",
  });

  const [updateEmployee, result] = useUpdateEmployeeMutation();

  function handleChange(event) {
    const { name, value } = event.target;
    setEdited((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function onSaveClick() {
    console.log("updatea");
    console.log(edited);

    updateEmployee(edited).then((data) => {
      console.log(data);
    });
  }

  return (
    <>
      <tr>
        <th>{employee.id}</th>
        {showPasswordAndEmail && <td></td>}
        {showPasswordAndEmail && <td></td>}
        <td>
          <input
            type="text"
            value={edited.fullName}
            name="fullName"
            onChange={handleChange}
            className="form-control"
            disabled={!canEdit}
          />
        </td>
        <td>
          <select
            className="form-select"
            name="subdivision"
            value={edited.subdivision}
            aria-label="Default select example"
            onChange={handleChange}
            disabled={!canEdit}
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
            disabled={!canEdit}
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
            disabled={!isAdmin}
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
            disabled={!canEdit}
          />
        </td>
        <td>
          {canEdit && (
            <FontAwesomeIcon
              icon={faSave}
              style={{ cursor: "pointer" }}
              onClick={onSaveClick}
            />
          )}
        </td>
      </tr>
    </>
  );
}

export default EmployeeTableRow;
