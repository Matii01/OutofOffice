import { faX } from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useState } from "react";
import {
  useCreateLeaveRequesMutation,
  useGetForLeaveRequestQuery,
} from "../../api/leaveRequestApi";

function NewLeaveRequest({ onClose }) {
  const { data, error, isLoading } = useGetForLeaveRequestQuery();
  const [leaveRequest, setLeaveRequest] = useState({
    AbsenceReason: "",
    StartDate: "",
    EndDate: "",
    Comment: "",
  });
  const [createLeaveReques, result] = useCreateLeaveRequesMutation();

  function handleSubmit(event) {
    event.preventDefault();
    console.log(leaveRequest);

    createLeaveReques(leaveRequest).then(() => {
      onClose();
    });
  }

  const handleChange = (e) => {
    let { name, value } = e.target;
    if (name === "AbsenceReason") {
      value = Number(value);
    }
    setLeaveRequest({
      ...leaveRequest,
      [name]: value,
    });
  };

  if (isLoading) {
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
              <div className="row">
                <div className="row">
                  <div className="col">
                    <form onSubmit={handleSubmit}>
                      <div className="row">
                        <div className="col-auto mb-3">
                          <label className="form-label">Absence Reason</label>
                          <select
                            className="form-select"
                            name="AbsenceReason"
                            value={leaveRequest.AbsenceReason}
                            onChange={handleChange}
                          >
                            <option></option>
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
                            name="StartDate"
                            value={leaveRequest.StartDate}
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
                            name="EndDate"
                            value={leaveRequest.EndDate}
                            onChange={handleChange}
                          />
                        </div>
                        <div className="mb-3">
                          <label htmlFor="text" className="form-label">
                            Comment
                          </label>
                          <textarea
                            className="form-control"
                            id="text"
                            name="Comment"
                            value={leaveRequest.Comment}
                            onChange={handleChange}
                          />
                        </div>

                        <button type="submit" className="btn btn-primary">
                          Save
                        </button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default NewLeaveRequest;
