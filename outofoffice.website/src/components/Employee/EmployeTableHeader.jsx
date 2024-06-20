import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCaretDown, faCaretUp } from "@fortawesome/free-solid-svg-icons";

function EmployeeTableHeader({ header, sort }) {
  return (
    <>
      {header.map((it, index) => (
        <th key={index}>
          <div className="row">
            <div className="">
              <div className="th-element">
                <a onClick={() => onHeaderClick(it.sortBy)}>{it.name}</a>
              </div>
              {sort.sortBy != "" && sort.sortBy === it.sortBy && sort.asc && (
                <FontAwesomeIcon icon={faCaretUp} />
              )}
              {sort.sortBy != "" && sort.sortBy === it.sortBy && !sort.asc && (
                <FontAwesomeIcon icon={faCaretDown} />
              )}
            </div>
          </div>
        </th>
      ))}
    </>
  );
}

export default EmployeeTableHeader;
