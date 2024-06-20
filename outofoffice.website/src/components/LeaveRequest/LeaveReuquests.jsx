import { useEffect, useState } from "react";
import LeaveRequestTable from "./LeaveRequestsTable";
import NewLeaveRequest from "./NewLeaveRequest";
import { useGetLeaveRequestsQuery } from "../../api/leaveRequestApi";
import UpdateLeaveRequest from "./UpdateLeaveRequest";
import FiltrsLeaveRequest from "./FiltrLeaveRequest";

const EmployeeRole = "Employee";

const initialParamState = {
  AbsenceReasons: [],
  Statuses: [],
  StartDate: "",
  EndDate: "",
};

function LeaveRequests() {
  const [params, setParams] = useState(initialParamState);
  const [showAddNew, setShowAddNew] = useState(false);
  const [showDetails, setShowDetails] = useState(false);
  const [selectedId, setSelectedId] = useState(0);
  const [searchParam, setSearchParam] = useState("");
  const isEmployee = localStorage.getItem("useRoles") === EmployeeRole;
  const { data, error, isLoading, refetch } = useGetLeaveRequestsQuery(params);

  useEffect(() => {
    console.log(params);
  }, [params]);

  function onLeaveRequestSelected(id) {
    setSelectedId(id);
    setShowDetails(true);
  }

  function onClose() {
    refetch();
    setShowDetails(false);
    setShowAddNew(false);
  }

  if (isLoading) {
    return <></>;
  }

  if (showDetails) {
    return <UpdateLeaveRequest leaveRequestId={selectedId} onClose={onClose} />;
  }

  if (showAddNew) {
    return <NewLeaveRequest onClose={onClose} />;
  }

  return (
    <>
      <div className="container">
        <div className="row mt-5">
          <div className="col mb-4">
            <div className="card">
              <div className="card-body">
                <div className="row mb-3">
                  <FiltrsLeaveRequest
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
                      onChange={(event) => setSearchParam(event.target.value)}
                    />
                  </div>
                  {isEmployee && (
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
                  <LeaveRequestTable
                    searchParam={searchParam}
                    leaveRequest={data}
                    onDoubleClick={onLeaveRequestSelected}
                  />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default LeaveRequests;
