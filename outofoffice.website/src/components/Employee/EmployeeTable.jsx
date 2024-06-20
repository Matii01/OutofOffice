import EmployeeTableRow from "./EmployeeTableRow";
import AddEmployeeTableRow from "./AddEmployeeRow";
import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import { useGetForNewEmployeeQuery } from "../../api/employeeApi";
import { header, headerwithemail } from "./EmployeeTableHeaders";
import {
  sortByFieldAsc,
  sortByFieldDesc,
  filterBySearchParam,
} from "../../helper/arraySort";

function EmployeeTable({ employee, searchParam, showAddNew, onCancel, onAdd }) {
  const [sort, setSort] = useState({ sortBy: "", asc: true });
  const [sorted, setSorted] = useState(employee);
  const { data: selectData, error, isLoading } = useGetForNewEmployeeQuery();

  useEffect(() => {
    setSorted(employee);
  }, [employee]);

  useEffect(() => {
    const newArr = filterBySearchParam([...employee], searchParam);
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
    <div className="table-container">
      <table className="table table-striped table-hover">
        <thead>
          <tr>
            {!showAddNew &&
              header.map((it, index) => (
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
            {showAddNew &&
              headerwithemail.map((it, index) => (
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
            <EmployeeTableRow
              key={it.id}
              selectData={selectData}
              employee={it}
              showPasswordAndEmail={showAddNew}
            />
          ))}
          {showAddNew && (
            <AddEmployeeTableRow
              selectData={selectData}
              onCancel={onCancel}
              onAdd={onAdd}
            />
          )}
        </tbody>
      </table>
    </div>
  );
}

export default EmployeeTable;
