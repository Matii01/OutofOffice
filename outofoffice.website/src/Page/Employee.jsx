import Navigation from "../components/Navigation/Navigation";
import { Outlet } from "react-router-dom";

function Employee() {
  return (
    <>
      <Navigation />
      <div className="content">
        <Outlet />
      </div>
    </>
  );
}

export default Employee;
