import { useEffect, useState } from "react";
import { useGetLeaveRequestsQuery } from "../../api/leaveRequestApi";
import { useGetApprovalRequestsQuery } from "../../api/approvalRequestApi";
import ApprovalRequestTable from "./ApprovalRequestTable";
import UpdateApprovalRequest from "./UpdateApprovalRequest";
import FiltrApprovalRequest from "./FiltrApprovalRequest";
const EmployeeRole = "Employee";

const initialParamState = {
  Statuses: [],
};

function ApprovalRequests() {
  const [params, setParams] = useState(initialParamState);
  const [showDetails, setShowDetails] = useState(false);
  const [selectedId, setSelectedId] = useState(0);
  const [searchParam, setSearchParam] = useState("");
  const isEmployee = localStorage.getItem("useRoles") === EmployeeRole;
  const { data, error, isLoading, refetch } =
    useGetApprovalRequestsQuery(params);

  function onApprovalRequestSelected(id) {
    setSelectedId(id);
    setShowDetails(true);
  }

  function onClose() {
    refetch();
    setShowDetails(false);
  }

  if (isLoading) {
    return <></>;
  }

  if (showDetails) {
    return (
      <UpdateApprovalRequest approvalRequestId={selectedId} onClose={onClose} />
    );
  }

  return (
    <>
      <div className="container">
        <div className="row mt-5">
          <div className="col mb-4">
            <div className="card">
              <div className="card-body">
                <div className="row mb-3">
                  <FiltrApprovalRequest
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
                  <ApprovalRequestTable
                    searchParam={searchParam}
                    approvalRequest={data}
                    onDoubleClick={onApprovalRequestSelected}
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

export default ApprovalRequests;
