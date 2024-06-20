import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import {
  sortByFieldAsc,
  sortByFieldDesc,
  filterBySearchParam,
} from "../../helper/arraySort";

const EmployeeRole = "Employee";

function LeaveRequestTable({ leaveRequest, searchParam, onDoubleClick }) {
  const isEmployee = localStorage.getItem("useRoles") === EmployeeRole;
  const [sort, setSort] = useState({ sortBy: "", asc: true });
  const [sorted, setSorted] = useState(leaveRequest);

  useEffect(() => {
    setSorted(leaveRequest);
  }, [leaveRequest]);

  useEffect(() => {
    const newArr = filterBySearchParam([...leaveRequest], searchParam);
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

  return (
    <>
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
                <tr key={it.id} onDoubleClick={() => onDoubleClick(it.id)}>
                  <td>{it.id}</td>
                  <td>{it.employeeName}</td>
                  <td>{it.absenceReason}</td>
                  <td>{it.startDate}</td>
                  <td>{it.endDate}</td>
                  <td>{it.status}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </>
    </>
  );
}

export default LeaveRequestTable;

const header = [
  { name: "ID", sortBy: "id" },
  { name: "Employee", sortBy: "employee" },
  { name: "AbsenceReason", sortBy: "absenceReason" },
  { name: "StartDate", sortBy: "startDate" },
  { name: "EndDate", sortBy: "endDate" },
  { name: "Status", sortBy: "status" },
];
