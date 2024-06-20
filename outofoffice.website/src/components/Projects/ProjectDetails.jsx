import { useEffect, useState } from "react";
import EmployeeInProject from "./EmployeeInProject";
import {
  useGetForNewProjectQuery,
  useGetProjectsDetailsQuery,
  useUpdateProjectMutation,
} from "../../api/projectsApi";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faX } from "@fortawesome/free-solid-svg-icons";

function ProjectDetails({ projectId, onClose }) {
  const isAdmin = localStorage.getItem("useRoles") === "Administrator";
  const userRole = localStorage.getItem("useRoles");
  const canEdit = ["ProjectManager", "Administrator"].includes(userRole);

  const [edited, setFormData] = useState({
    projectType: 0,
    startDate: "",
    endDate: "",
    projectManager: 0,
    status: 0,
    comment: "",
  });

  const [update, result] = useUpdateProjectMutation();
  const { data, error, isLoading } = useGetProjectsDetailsQuery(projectId);
  const {
    data: selectData,
    err,
    loadingSelectData,
  } = useGetForNewProjectQuery();

  useEffect(() => {
    if (!isLoading) {
      setFormData(data.project);
    }
  }, [data]);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...edited,
      [name]: value,
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    update(edited).then((data) => {
      console.log(data);
    });
  };

  if (isLoading || loadingSelectData) {
    return <></>;
  }

  return (
    <>
      <>
        <div className="container">
          <div className="row mt-5">
            <div className="col mb-4">
              <div className="card">
                <div className="card-body">
                  <div className="row mb-3">
                    <div className="col d-flex justify-content-end">
                      <FontAwesomeIcon
                        icon={faX}
                        onClick={onClose}
                        style={{ cursor: "pointer" }}
                      />
                    </div>
                  </div>
                  <div className="row">
                    <div className="col">
                      <form onSubmit={handleSubmit}>
                        <div className="col-auto mb-3">
                          <label htmlFor="projectType" className="form-label">
                            Project Type
                          </label>
                          <select
                            className="form-select"
                            name="projectType"
                            value={edited.projectType}
                            aria-label="Default select example"
                            onChange={handleChange}
                            disabled={!canEdit}
                          >
                            {selectData.projectType.map((it) => (
                              <option key={it.value} value={it.value}>
                                {it.name}
                              </option>
                            ))}
                          </select>
                        </div>
                        <div className="row">
                          <div className="col mb-3">
                            <label htmlFor="startDate" className="form-label">
                              Start Date
                            </label>
                            <input
                              type="date"
                              className="form-control"
                              id="startDate"
                              name="startDate"
                              value={edited.startDate}
                              onChange={handleChange}
                              disabled={!canEdit}
                            />
                          </div>

                          <div className="col mb-3">
                            <label htmlFor="endDate" className="form-label">
                              End Date
                            </label>
                            <input
                              type="date"
                              className="form-control"
                              id="endDate"
                              name="endDate"
                              value={edited.endDate}
                              onChange={handleChange}
                              disabled={!canEdit}
                            />
                          </div>
                        </div>

                        <div className="row">
                          <div className="col mb-3">
                            <label
                              htmlFor="projectManager"
                              className="form-label"
                            >
                              Project Manager
                            </label>
                            <select
                              className="form-select"
                              name="projectManager"
                              value={edited.projectManager}
                              aria-label="Default select example"
                              onChange={handleChange}
                              disabled={!isAdmin}
                            >
                              {selectData.pManagers.map((it) => (
                                <option key={it.id} value={it.id}>
                                  {it.fullName}
                                </option>
                              ))}
                            </select>
                          </div>

                          <div className="col mb-3">
                            <label htmlFor="status" className="form-label">
                              Status
                            </label>
                            <select
                              className="form-select"
                              name="status"
                              value={edited.status}
                              aria-label="Default select example"
                              onChange={handleChange}
                              disabled={!canEdit}
                            >
                              {selectData.status.map((it) => (
                                <option key={it.value} value={it.value}>
                                  {it.name}
                                </option>
                              ))}
                            </select>
                          </div>
                        </div>

                        <div className="mb-3">
                          <label htmlFor="text" className="form-label">
                            Comment
                          </label>
                          <textarea
                            className="form-control"
                            id="text"
                            name="comment"
                            value={edited.comment}
                            onChange={handleChange}
                            disabled={!canEdit}
                          />
                        </div>

                        {canEdit && (
                          <button type="submit" className="btn btn-primary">
                            Update
                          </button>
                        )}
                      </form>
                    </div>
                    <div className="col">
                      <EmployeeInProject
                        projectId={projectId}
                        employee={data.employee}
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </>
    </>
  );
}

export default ProjectDetails;
