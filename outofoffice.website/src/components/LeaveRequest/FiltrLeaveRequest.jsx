import { useGetForLeaveRequestQuery } from "../../api/leaveRequestApi";

function FiltrsLeaveRequest({ params, setParams, reset }) {
  const { data: selectData, error, isLoading } = useGetForLeaveRequestQuery();

  if (isLoading) {
    return <></>;
  }

  function handleCheckboxChange(event) {
    const { name, value } = event.target;
    let selected = [];
    if (event.target.checked) {
      selected = [...params[name], value];
    } else {
      selected = params[name].filter((item) => item !== value);
    }
    setParams((prevState) => ({
      ...prevState,
      [name]: selected,
    }));
  }

  function handleChange(event) {
    const { name, value } = event.target;
    setParams((prevState) => ({
      ...prevState,
      [name]: value,
    }));
  }

  return (
    <>
      <div className="row">
        <div className="col-auto">
          <div className="dropdown">
            <button
              className="btn btn-secondary dropdown-toggle"
              type="button"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              AbsenceReasons
            </button>
            <ul className="dropdown-menu">
              {selectData.absenceReason.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="AbsenceReasons"
                    onChange={handleCheckboxChange}
                  />
                </li>
              ))}
            </ul>
          </div>
        </div>

        <div className="col-auto">
          <div className="dropdown">
            <button
              className="btn btn-secondary dropdown-toggle"
              type="button"
              data-bs-toggle="dropdown"
              aria-expanded="false"
            >
              Statuses
            </button>
            <ul className="dropdown-menu">
              {selectData.status.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="Statuses"
                    onChange={handleCheckboxChange}
                  />
                </li>
              ))}
            </ul>
          </div>
        </div>

        <div className="col-auto">
          <input
            type="date"
            className="form-control"
            name="StartDate"
            value={params.StartDate}
            onChange={handleChange}
          />
        </div>

        <div className="col-auto">
          <input
            className="form-control"
            type="date"
            name="EndDate"
            value={params.EndDate}
            onChange={handleChange}
          />
        </div>

        <div className="col-auto">
          <button type="button" className="btn btn-primary" onClick={reset}>
            Reset
          </button>
        </div>
      </div>
    </>
  );
}

export default FiltrsLeaveRequest;
