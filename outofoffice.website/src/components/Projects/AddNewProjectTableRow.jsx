import { useEffect, useState } from "react";
import { useAddProjectMutation } from "../../api/projectsApi";

function AddNewProjectTableRow({ selectData, onCancel, onAdd }) {
  const [newProject, setNewProject] = useState({
    projectType: 0,
    startDate: "",
    endDate: "",
    projectMnager: 0,
    text: "",
    status: 0,
  });
  const [addProject, result] = useAddProjectMutation();

  function handleChange(event) {
    let { name, value } = event.target;
    if (
      name === "projectType" ||
      name === "projectMnager" ||
      name === "status"
    ) {
      value = Number(value);
    }
    setNewProject((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  useEffect(() => {
    console.log(newProject);
  }, [newProject]);

  function onSaveClick() {
    let postData = { ...newProject };
    if (newProject.endDate === "") {
      postData = { ...newProject, endDate: null };
    }

    addProject(postData).then((data) => {
      onAdd();
      onCancel();
    });
  }
  return (
    <>
      <tr>
        <th>#</th>
        <td>
          <select
            className="form-select"
            name="projectType"
            value={newProject.projectType}
            aria-label="Default select example"
            onChange={handleChange}
          >
            <option></option>
            {selectData.projectType.map((it) => (
              <option key={it.value} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
        </td>
        <td>
          <input
            type="date"
            value={newProject.startDate}
            name="startDate"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td>
          <input
            type="date"
            value={newProject.endDate}
            name="endDate"
            onChange={handleChange}
            className="form-control"
          />
        </td>
        <td></td>
        <td>
          <select
            className="form-select"
            name="status"
            value={newProject.status}
            aria-label="Default select example"
            onChange={handleChange}
          >
            <option></option>
            {selectData.status.map((it) => (
              <option key={it.value} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
        </td>

        <td>
          <button className="btn btn-primary" onClick={onSaveClick}>
            Add
          </button>
        </td>
      </tr>
    </>
  );
}

export default AddNewProjectTableRow;
