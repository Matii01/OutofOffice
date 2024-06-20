import { useGetForNewProjectQuery } from "../../api/projectsApi";

function FiltrsProjects({ params, setParams, reset }) {
  const { data: selectData, error, isLoading } = useGetForNewProjectQuery();

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
              ProjectType
            </button>
            <ul className="dropdown-menu">
              {selectData.projectType.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    value={it.value}
                    name="ProjectType"
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
              {selectData.pManagers.map((it) => (
                <li key={it.id}>
                  <label className="ms-2 me-2">{it.fullName}</label>
                  <input
                    type="checkbox"
                    value={it.id}
                    name="Managers"
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

export default FiltrsProjects;
