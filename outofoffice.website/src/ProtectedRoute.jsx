import { useNavigate } from "react-router-dom";

function ProtectedRoute({ children, roles }) {
  const userRole = localStorage.getItem("useRoles");

  const navigate = useNavigate();

  if (!roles.includes(userRole)) {
    return (
      <>
        <div className="container">
          <div className="row mt-5">
            <div className="col">
              <div className="card">
                <div className="card-body">
                  <div className="row">
                    <div className="col">
                      <p>Access denied</p>
                      <button
                        className="btn btn-primary"
                        onClick={() => navigate("/lists")}
                      >
                        Go to menu
                      </button>
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

  return <>{children}</>;
}

export default ProtectedRoute;
