import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import {
  sortByFieldAsc,
  sortByFieldDesc,
  filterBySearchParam,
} from "../../helper/arraySort";

const EmployeeRole = "Employee";

function ApprovalRequestTable({ approvalRequest, searchParam, onDoubleClick }) {
  const [sort, setSort] = useState({ sortBy: "", asc: true });
  const [sorted, setSorted] = useState(approvalRequest);

  useEffect(() => {
    setSorted(approvalRequest);
  }, [approvalRequest]);

  useEffect(() => {
    const newArr = filterBySearchParam([...approvalRequest], searchParam);
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
                  <td>{it.requester}</td>
                  <td>{it.approver == "" ? "----------" : it.approver}</td>
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

export default ApprovalRequestTable;

const header = [
  { name: "ID", sortBy: "id" },
  { name: "Requester", sortBy: "requester" },
  { name: "Approver", sortBy: "approver" },
  { name: "Status", sortBy: "status" },
];
