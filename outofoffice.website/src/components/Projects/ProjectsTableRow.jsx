import { faSave } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import { useUpdateProjectMutation } from "../../api/projectsApi";

function ProjectsTableRow({ project, selectData, onProjestClick, onUpdate }) {
  const isAdmin = localStorage.getItem("useRoles") === "Administrator";
  const userRole = localStorage.getItem("useRoles");
  const canEdit = ["ProjectManager", "Administrator"].includes(userRole);

  const [edited, setEdited] = useState({
    ID: project.id,
    projectType: project.projectType,
    startDate: project.startDate.slice(0, 10),
    endDate: project.endDate === null ? "" : project.endDate.slice(0, 10),
    projectManager: project.projectManager,
    status: project.status,
    text: project.text,
  });
  const [updateProject] = useUpdateProjectMutation();

  function handleChange(event) {
    const { name, value } = event.target;

    setEdited((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function handleChangeAndConvert(event) {
    const { name, value } = event.target;
    const newValue = Number(value);
    setEdited((prev) => ({
      ...prev,
      [name]: newValue,
    }));
  }

  function onSaveClick() {
    console.log(edited);
    updateProject(edited).then(() => {
      onUpdate();
    });
  }

  return (
    <>
      <tr onDoubleClick={() => onProjestClick(edited.ID)}>
        <th>{edited.ID}</th>
        <td>
          <select
            className="form-select"
            name="projectType"
            value={edited.projectType}
            aria-label="Default select example"
            onChange={handleChangeAndConvert}
            disabled={!canEdit}
          >
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
            value={edited.startDate}
            name="startDate"
            onChange={handleChange}
            className="form-control"
            disabled={!canEdit}
          />
        </td>
        <td>
          <input
            type="date"
            value={edited.endDate}
            name="endDate"
            onChange={handleChange}
            className="form-control"
            disabled={!canEdit}
          />
        </td>
        <td>
          <select
            className="form-select"
            name="projectManager"
            value={edited.projectManager}
            aria-label="Default select example"
            onChange={handleChangeAndConvert}
            disabled={!isAdmin}
          >
            {selectData.pManagers.map((it) => (
              <option key={it.id} value={it.id}>
                {it.fullName}
              </option>
            ))}
          </select>
        </td>
        <td>
          <select
            className="form-select"
            name="status"
            value={edited.status}
            aria-label="Default select example"
            onChange={handleChangeAndConvert}
            disabled={!canEdit}
          >
            {selectData.status.map((it) => (
              <option key={it.name} value={it.value}>
                {it.name}
              </option>
            ))}
          </select>
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

export default ProjectsTableRow;
