import { useState } from "react";
import { useGetEmployeeQuery } from "../../api/employeeApi";
import EmployeeTable from "./EmployeeTable";
import FiltrsEmployee from "./FiltrsEmployee";

const initialParamState = {
  FullName: "",
  SubdivisionId: [],
  PositionId: [],
  StatusId: [],
  PeopleParthner: [],
  OutOfOfficeBalanceMin: "",
  OutOfOfficeBalanceMax: "",
};

function EmployeeList() {
  const userRole = localStorage.getItem("useRoles");
  const canEdit = ["HRManager", "Administrator"].includes(userRole);

  const [params, setParams] = useState(initialParamState);
  const [showAddNew, setShowAddNew] = useState(false);
  const [searchParam, setSearchParam] = useState("");
  const {
    data: employee,
    error,
    isLoading,
    refetch,
  } = useGetEmployeeQuery(params);

  function onAddNew() {
    refetch();
  }

  function onAddNewClick() {
    setShowAddNew(true);
  }

  function resetParams() {
    setParams(initialParamState);
  }

  return (
    <>
      <div className="container">
        <div className="row mt-5">
          <div className="col mb-4">
            <div className="card">
              <div className="card-body">
                <div className="row mb-3">
                  <FiltrsEmployee
                    params={params}
                    setParams={setParams}
                    reset={resetParams}
                  />
                </div>
                <div className="row mb-1">
                  <div className="col">
                    <input
                      type="text"
                      className="form-control"
                      placeholder="search"
                      onChange={(event) => setSearchParam(event.target.value)}
                    />
                  </div>
                  {canEdit && (
                    <div className="col-auto">
                      <button
                        className="btn btn-primary"
                        onClick={onAddNewClick}
                      >
                        Add New
                      </button>
                    </div>
                  )}
                </div>
                <div className="row">
                  {!isLoading && !error && (
                    <EmployeeTable
                      onAdd={onAddNew}
                      employee={employee}
                      searchParam={searchParam}
                      showAddNew={showAddNew}
                      onCancel={() => setShowAddNew(false)}
                    />
                  )}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default EmployeeList;
