import { faX } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import {
  useCancelLeaveRequesMutation,
  useGetForLeaveRequestDetailsQuery,
  useGetForLeaveRequestQuery,
  useSubmitLeaveRequesMutation,
} from "../../api/leaveRequestApi";

const StatusForNewRequest = 0;
const StatusForCanceled = 2;
const EmployeeRole = "Employee";

function UpdateLeaveRequest({ leaveRequestId, onClose }) {
  const isEmployee = localStorage.getItem("useRoles") === EmployeeRole;
  const [leaveRequest, setLeaveRequest] = useState({
    employeeName: "",
    startDate: "",
    endDate: "",
    comment: "",
  });

  const [submitLeaveReques, res] = useSubmitLeaveRequesMutation();
  const [cancelLeaveReques] = useCancelLeaveRequesMutation();
  const { data, error, isLoading } = useGetForLeaveRequestQuery();
  const {
    data: lRequest,
    error: lErro,
    isLoading: LLoading,
  } = useGetForLeaveRequestDetailsQuery(leaveRequestId);

  useEffect(() => {
    setLeaveRequest(lRequest);
  }, [lRequest]);

  const handleChange = (e) => {
    let { name, value } = e.target;
    if (name === "absenceReason") {
      value = Number(value);
    }
    setLeaveRequest({
      ...leaveRequest,
      [name]: value,
    });
  };

  function handleSubmit(event) {
    event.preventDefault();
    console.log(leaveRequest);
  }

  function handleCancel() {
    cancelLeaveReques(leaveRequest.id).then(() => {
      onClose();
    });
  }

  function handleCreateApprowalRequest() {
    submitLeaveReques(leaveRequest.id).then(() => {
      onClose();
    });
  }

  if (isLoading || LLoading || leaveRequest === undefined) {
    return <></>;
  }

  return (
    <>
      <div className="container">
        <div className="row mt-5">
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
              <form onSubmit={handleSubmit}>
                <div className="row">
                  <div className="col">
                    <div className="row">
                      <div className="col-auto mb-3">
                        <label className="form-label">Requester</label>
                        <input
                          className="form-control"
                          value={leaveRequest.employeeName}
                          onChange={() => {}}
                          disabled
                        />
                      </div>
                      <div className="col-auto mb-3">
                        <label className="form-label">Absence Reason</label>
                        <select
                          className="form-select"
                          name="absenceReason"
                          value={leaveRequest.absenceReason}
                          onChange={handleChange}
                        >
                          {data.absenceReason.map((it) => (
                            <option key={it.value} value={it.value}>
                              {it.name}
                            </option>
                          ))}
                        </select>
                      </div>
                      <div className="col mb-3">
                        <label htmlFor="startDate" className="form-label">
                          Start Date
                        </label>
                        <input
                          type="date"
                          className="form-control"
                          name="startDate"
                          value={leaveRequest.startDate}
                          onChange={handleChange}
                        />
                      </div>
                      <div className="col mb-3">
                        <label htmlFor="startDate" className="form-label">
                          Start Date
                        </label>
                        <input
                          type="date"
                          className="form-control"
                          name="endDate"
                          value={leaveRequest.endDate}
                          onChange={handleChange}
                        />
                      </div>
                    </div>
                  </div>
                </div>

                <div className="row d-flex justify-content-end">
                  <div className="col-auto">
                    <label htmlFor="text" className="form-label mt-1">
                      Status
                    </label>
                  </div>
                  <div className="col-auto">
                    <select
                      disabled
                      className="form-select"
                      name="absenceReason"
                      value={leaveRequest.status}
                      onChange={handleChange}
                    >
                      {data.status.map((it) => (
                        <option key={it.value} value={it.value}>
                          {it.name}
                        </option>
                      ))}
                    </select>
                  </div>
                </div>

                <div className="row">
                  <div className="mb-3">
                    <label htmlFor="text" className="form-label">
                      Comment
                    </label>
                    <textarea
                      className="form-control"
                      id="text"
                      name="comment"
                      value={leaveRequest.comment}
                      onChange={handleChange}
                    />
                  </div>
                </div>

                {isEmployee && (
                  <div className="row">
                    <div className="col">
                      {leaveRequest.status == StatusForNewRequest && (
                        <button type="submit" className="btn btn-primary">
                          Update
                        </button>
                      )}
                    </div>
                    <div className="col-auto">
                      <button
                        type="button"
                        onClick={handleCreateApprowalRequest}
                        className="btn btn-success"
                        disabled={leaveRequest.status != StatusForNewRequest}
                      >
                        Create approval request
                      </button>
                    </div>
                    <div className="col-auto">
                      <button
                        type="button"
                        onClick={handleCancel}
                        className="btn btn-danger"
                        disabled={leaveRequest.status == StatusForCanceled}
                      >
                        Cancel
                      </button>
                    </div>
                  </div>
                )}
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default UpdateLeaveRequest;
