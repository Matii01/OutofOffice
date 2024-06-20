import { useGetForApprovalRequestQuery } from "../../api/approvalRequestApi";

function FiltrApprovalRequest({ params, setParams, reset }) {
  const {
    data: selectData,
    error,
    isLoading,
  } = useGetForApprovalRequestQuery();

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
              Statuses
            </button>
            <ul className="dropdown-menu">
              {selectData.status.map((it) => (
                <li key={it.value}>
                  <label className="ms-2 me-2">{it.name}</label>
                  <input
                    type="checkbox"
                    checked={params.Statuses.includes(`${it.value}`)}
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
          <button type="button" className="btn btn-primary" onClick={reset}>
            Reset
          </button>
        </div>
      </div>
    </>
  );
}

export default FiltrApprovalRequest;
