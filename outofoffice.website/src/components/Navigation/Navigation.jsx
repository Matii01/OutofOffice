import { NavLink, useNavigate } from "react-router-dom";

function Navigation() {
  const userRole = localStorage.getItem("useRoles");

  const navigate = useNavigate();

  const canAccesEmployee = [
    "HRManager",
    "ProjectManager",
    "Administrator",
  ].includes(userRole);
  const canAccesProjects = [
    "HRManager",
    "ProjectManager",
    "Administrator",
    "Employee",
  ].includes(userRole);
  const canAccesLeaveRequest = [
    "HRManager",
    "ProjectManager",
    "Administrator",
    "Employee",
  ].includes(userRole);
  const canAccesApprovalRequest = [
    "HRManager",
    "ProjectManager",
    "Administrator",
  ].includes(userRole);

  function onLogoutClick() {
    localStorage.removeItem("authToken");
    localStorage.removeItem("expiration");
    localStorage.removeItem("useRoles");
    navigate("/");
  }

  return (
    <>
      <nav className="navbar navbar-expand-lg bg-body-tertiary">
        <div className="container-fluid">
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarSupportedContent"
            aria-controls="navbarSupportedContent"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarSupportedContent">
            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
              {canAccesEmployee && (
                <li className="nav-item">
                  <NavLink to="/lists/employee" className="nav-link active">
                    <p>Employees</p>
                  </NavLink>
                </li>
              )}
              {canAccesProjects && (
                <li className="nav-item">
                  <NavLink to="/lists/projects" className="nav-link active">
                    <p>Projects</p>
                  </NavLink>
                </li>
              )}
              {canAccesLeaveRequest && (
                <li className="nav-item">
                  <NavLink to="/lists/leaverequest" className="nav-link active">
                    <p>Leave requests</p>
                  </NavLink>
                </li>
              )}
              {canAccesApprovalRequest && (
                <li className="nav-item">
                  <NavLink
                    to="/lists/approvalrequest"
                    className="nav-link active"
                  >
                    <p>Approval requests</p>
                  </NavLink>
                </li>
              )}
            </ul>
            <ul className="navbar-nav me-5 mt-3 mb-lg-0">
              <li className="nav-item">
                <p>{userRole}</p>
              </li>
            </ul>
            <button
              className="btn btn-outline-success"
              type="button"
              onClick={onLogoutClick}
            >
              Logout
            </button>
          </div>
        </div>
      </nav>
    </>
  );
}

export default Navigation;
