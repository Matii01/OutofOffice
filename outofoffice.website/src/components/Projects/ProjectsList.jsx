import { useEffect, useState } from "react";
import ProjectTable from "./ProjectsTable";
import { useGetProjectsQuery } from "../../api/projectsApi";
import ProjectDetails from "./ProjectDetails";
import FiltrsProjects from "./FiltrsProjects";

const PMRole = "ProjectManager";

const initialParamState = {
  ProjectType: [],
  Managers: [],
  Statuses: [],
  StartDate: "",
  EndDate: "",
};

function ProjectsList() {
  const [params, setParams] = useState(initialParamState);
  const [showAddNew, setShowAddNew] = useState(false);
  const [showDetails, setShowDetails] = useState(false);
  const [projectId, setProjectId] = useState(0);
  const [searchParam, setSearchParam] = useState("");
  const isPM = localStorage.getItem("useRoles") === PMRole;

  const { data, error, isLoading, refetch } = useGetProjectsQuery(params);

  function onProjestClick(id) {
    setProjectId(id);
    setShowDetails(true);
  }

  function handleChange(event) {
    setSearchParam(event.target.value);
  }

  if (isLoading) {
    return <></>;
  }

  return (
    <>
      {showDetails && (
        <ProjectDetails
          projectId={projectId}
          onClose={() => setShowDetails(false)}
        />
      )}
      {!showDetails && (
        <>
          <div className="container">
            <div className="row mt-5">
              <div className="col mb-4">
                <div className="card">
                  <div className="card-body">
                    <div className="row mb-3">
                      <FiltrsProjects
                        params={params}
                        setParams={setParams}
                        reset={() => {
                          setParams(initialParamState);
                        }}
                      />
                    </div>
                    <div className="row mb-1">
                      <div className="col">
                        <input
                          type="text"
                          className="form-control"
                          placeholder="search"
                          value={searchParam}
                          onChange={handleChange}
                        />
                      </div>
                      {isPM && (
                        <div className="col-auto">
                          <button
                            className="btn btn-primary"
                            onClick={() => setShowAddNew(true)}
                          >
                            Add New
                          </button>
                        </div>
                      )}
                    </div>
                    <div className="row">
                      <ProjectTable
                        onProjestClick={onProjestClick}
                        onAdd={refetch}
                        projects={data}
                        searchParam={searchParam}
                        showAddNew={showAddNew}
                        onCancel={() => setShowAddNew(false)}
                      />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </>
      )}
    </>
  );
}

export default ProjectsList;
