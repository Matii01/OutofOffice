import { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";
import ProjectsTableRow from "./ProjectsTableRow";
import {
  useGetForNewProjectQuery,
  useGetProjectsQuery,
} from "../../api/projectsApi";
import AddNewProjectTableRow from "./AddNewProjectTableRow";
import {
  sortByFieldAsc,
  sortByFieldDesc,
  filterBySearchParam,
} from "../../helper/arraySort";

const PMRole = "ProjectManager";

function ProjectTable({
  projects,
  searchParam,
  onProjestClick,
  showAddNew,
  onAdd,
  onCancel,
}) {
  const isPM = localStorage.getItem("useRoles") === PMRole;
  const [sort, setSort] = useState({ sortBy: "", asc: true });
  const [sorted, setSorted] = useState(projects);

  const { data: forNewProjects, error, isLoading } = useGetForNewProjectQuery();

  useEffect(() => {
    setSorted(projects);
  }, [projects]);

  useEffect(() => {
    const newArr = filterBySearchParam([...projects], searchParam);
    setSorted(newArr);
  }, [searchParam]);

  function onHeaderClick(sortBy) {
    if (sort.sortBy === sortBy) {
      setSort({ sortBy, asc: !sort.asc });
    } else {
      setSort({ sortBy, asc: true });
    }
  }

  useEffect(() => {
    if (sort.sortBy === "") {
      return;
    }

    if (sort.asc) {
      const newArr = sortByFieldAsc([...sorted], sort.sortBy);
      setSorted(newArr);
    } else {
      const newArr = sortByFieldDesc([...sorted], sort.sortBy);
      setSorted(newArr);
    }
  }, [sort]);

  if (isLoading) {
    return <></>;
  }

  return (
    <>
      <div className="table-container">
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              {header.map((it, index) => (
                <th key={index}>
                  <div className="row">
                    <div className="">
                      <div className="th-element">
                        <a onClick={() => onHeaderClick(it.sortBy)}>
                          {it.name}
                        </a>
                      </div>
                      {sort.sortBy != "" &&
                        sort.sortBy === it.sortBy &&
                        sort.asc && <FontAwesomeIcon icon={faCaretUp} />}
                      {sort.sortBy != "" &&
                        sort.sortBy === it.sortBy &&
                        !sort.asc && <FontAwesomeIcon icon={faCaretDown} />}
                    </div>
                  </div>
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {sorted.map((it) => (
              <ProjectsTableRow
                onProjestClick={onProjestClick}
                key={it.id}
                project={it}
                selectData={forNewProjects}
              />
            ))}
            {showAddNew && (
              <AddNewProjectTableRow
                onAdd={onAdd}
                selectData={forNewProjects}
                onCancel={onCancel}
              />
            )}
          </tbody>
        </table>
      </div>
    </>
  );
}

export default ProjectTable;
const header = [
  { name: "ID", sortBy: "id" },
  { name: "Project Type", sortBy: "projectType" },
  { name: "Start Date", sortBy: "startDate" },
  { name: "End Date", sortBy: "endDate" },
  { name: "Project Manager", sortBy: "projectManager" },
  { name: "Status", sortBy: "status" },
  { name: "Action", sortBy: "" },
];
