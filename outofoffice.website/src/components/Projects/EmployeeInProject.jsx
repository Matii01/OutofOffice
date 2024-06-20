import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  useGetEmployeePositionQuery,
  useGetNotInProjectEmployeeQuery,
} from "../../api/employeeApi";
import { faAdd, faMinus } from "@fortawesome/free-solid-svg-icons";
import { useEffect, useState } from "react";
import {
  useAssignEmployeetoProjectMutation,
  useRemoveEmployeeFromProjectMutation,
} from "../../api/projectsApi";

function EmployeeInProject({ projectId, employee }) {
  const userRole = localStorage.getItem("useRoles");
  const canEdit = ["ProjectManager", "Administrator"].includes(userRole);
  const [emplpoyeeInProject, setEmployeeInProject] = useState(employee);
  const [employeeList, setEmployeeList] = useState([]);
  const [showAddNewEmployee, setShowAddNewEmployee] = useState(false);
  const {
    data: list,
    error,
    isLoading,
  } = useGetNotInProjectEmployeeQuery(projectId);

  const [assignEmployee, assignResult] = useAssignEmployeetoProjectMutation();
  const [removeEmployeFromProject, removeResult] =
    useRemoveEmployeeFromProjectMutation();

  useEffect(() => {
    setEmployeeList(list);
  }, [list]);

  function onAdd(id) {
    assignEmployee({ employeeID: id, projectID: projectId }).then((data) => {
      const selectedEmployee = employeeList.find((x) => x.id == id);
      const filtered = employeeList.filter((x) => x.id != id);

      setEmployeeInProject((prev) => [...prev, selectedEmployee]);
      setEmployeeList(filtered);
    });
  }

  function onRemove(id) {
    removeEmployeFromProject({ projectId: projectId, employeeId: id }).then(
      (data) => {
        const selectedEmployee = emplpoyeeInProject.find((x) => x.id == id);
        const filtered = emplpoyeeInProject.filter((x) => x.id != id);

        setEmployeeList((prev) => [...prev, selectedEmployee]);
        setEmployeeInProject(filtered);
      }
    );
  }

  if (isLoading) {
    return <></>;
  }

  return (
    <>
      <div className="container">
        <div className="row">
          <div className="col ">In Project:</div>
        </div>
        <div className="row">
          <table className="table">
            <thead>
              <tr>
                <th>ID</th>
                <th>Name</th>
                <th>#</th>
              </tr>
            </thead>
            <tbody>
              {emplpoyeeInProject &&
                emplpoyeeInProject.map((it) => (
                  <tr key={it.id}>
                    <th>{it.id}</th>
                    <th>{it.fullName}</th>
                    {canEdit && (
                      <td>
                        <FontAwesomeIcon
                          icon={faMinus}
                          onClick={() => onRemove(it.id)}
                          style={{ cursor: "pointer" }}
                        />
                      </td>
                    )}
                  </tr>
                ))}
            </tbody>
          </table>
        </div>
        <div className="row">
          {canEdit && (
            <div className="row">
              <div className="col d-flex justify-content-end">
                <button
                  className="btn btn-primary"
                  onClick={() => setShowAddNewEmployee(!showAddNewEmployee)}
                >
                  Add new empoyee to project
                </button>
              </div>
            </div>
          )}
          {showAddNewEmployee && (
            <div className="row">
              <table className="table">
                <thead>
                  <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>#</th>
                  </tr>
                </thead>
                <tbody>
                  {employeeList.map((it) => (
                    <tr key={it.id}>
                      <th>{it.id}</th>
                      <th>{it.fullName}</th>
                      <td>
                        <FontAwesomeIcon
                          icon={faAdd}
                          onClick={() => onAdd(it.id)}
                          style={{ cursor: "pointer" }}
                        />
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          )}
        </div>
      </div>
    </>
  );
}

export default EmployeeInProject;
