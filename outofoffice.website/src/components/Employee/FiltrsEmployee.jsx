import { useGetForNewEmployeeQuery } from "../../api/employeeApi";

function FiltrsEmployee({ params, setParams, reset }) {
  const { data: selectData, error, isLoading } = useGetForNewEmployeeQuery();

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
              Subdivision
            </button>
            <ul className="dropdown-menu">
              {selectData.subdivision.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="SubdivisionId"
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
              Position
            </button>
            <ul className="dropdown-menu">
              {selectData.position.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="PositionId"
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
              Status
            </button>
            <ul className="dropdown-menu">
              {selectData.status.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="StatusId"
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
              Managers
            </button>
            <ul className="dropdown-menu">
              {selectData.hrManagers.map((it) => (
                <li key={it.id}>
                  <label className="ms-2 me-2">{it.fullName}</label>
                  <input
                    type="checkbox"
                    value={it.id}
                    name="PeopleParthner"
                    onChange={handleCheckboxChange}
                  />
                </li>
              ))}
            </ul>
          </div>
        </div>
        <div className="col-auto">
          <input
            className="form-control"
            type="number"
            name="OutOfOfficeBalanceMin"
            onChange={handleChange}
            value={params.OutOfOfficeBalanceMin}
            min={0}
            placeholder="Out of office min"
          />
        </div>
        <div className="col-auto">
          <input
            className="form-control"
            type="number"
            name="OutOfOfficeBalanceMax"
            value={params.OutOfOfficeBalanceMax}
            onChange={handleChange}
            min={0}
            placeholder="Out of office max"
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

export default FiltrsEmployee;
