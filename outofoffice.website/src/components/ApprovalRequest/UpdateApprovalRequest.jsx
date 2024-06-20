import { faX } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";
import {
  useAcceptApprovalRequesMutation,
  useGetApprovalRequestsDetailsQuery,
  useRejectApprovalRequesMutation,
} from "../../api/approvalRequestApi";

const StatusForNew = 0;
const StatusForCanceled = 3;

function UpdateApprovalRequest({ approvalRequestId, onClose }) {
  const [ar, setAR] = useState({});
  const [accept] = useAcceptApprovalRequesMutation();
  const [reject] = useRejectApprovalRequesMutation();
  const { data, error, isLoading } =
    useGetApprovalRequestsDetailsQuery(approvalRequestId);

  useEffect(() => {
    console.log(data);
    setAR(data);
  }, [data]);

  function handleChange(event) {
    const { name, value } = event.target;
    setAR((prev) => ({
      ...prev,
      [name]: value,
    }));
  }

  function handleSubmit(event) {
    event.preventDefault();
  }

  function onAcceptClick() {
    console.log(approvalRequestId);
    accept({ id: approvalRequestId, comment: ar.comment }).then(() => {
      onClose();
    });
  }
  function onRejectClick() {
    reject({ id: approvalRequestId, comment: ar.comment }).then(() => {
      onClose();
    });
  }

  if (isLoading || ar === undefined || ar.leaveRequest === undefined) {
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
                          value={ar.leaveRequest.employeeName}
                          onChange={() => {}}
                        />
                      </div>
                      <div className="col-auto mb-3">
                        <label className="form-label">Absence Reason</label>
                        <input
                          className="form-control"
                          value={ar.leaveRequest.absenceReason}
                          onChange={() => {}}
                        />
                      </div>
                      <div className="col mb-3">
                        <label htmlFor="startDate" className="form-label">
                          Start Date
                        </label>
                        <input
                          type="date"
                          className="form-control"
                          name="startDate"
                          value={ar.leaveRequest.startDate}
                          onChange={() => {}}
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
                          value={ar.leaveRequest.endDate}
                          onChange={() => {}}
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
                    <input
                      type="text"
                      className="form-control"
                      name="endDate"
                      value={ar.leaveRequest.status}
                      onChange={() => {}}
                    />
                  </div>
                </div>

                <div className="row">
                  <div className="mb-3">
                    <label htmlFor="text" className="form-label">
                      Requester Comment
                    </label>
                    <textarea
                      className="form-control"
                      id="text"
                      name="comment"
                      value={ar.leaveRequest.comment}
                      onChange={() => {}}
                    />
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
                      value={ar.comment}
                      onChange={handleChange}
                    />
                  </div>
                </div>

                <div className="row">
                  <div className="col">
                    {/* <button type="submit" className="btn btn-primary">
                      Save
                    </button> */}
                  </div>
                  <div className="col-auto">
                    <button
                      type="button"
                      className="btn btn-success"
                      onClick={onAcceptClick}
                      disabled={ar.status != StatusForNew}
                    >
                      Accept
                    </button>
                  </div>
                  <div className="col-auto">
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={onRejectClick}
                      disabled={ar.status != StatusForNew}
                    >
                      Reject
                    </button>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default UpdateApprovalRequest;
