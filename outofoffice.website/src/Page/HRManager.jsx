import { Outlet } from "react-router-dom";
import HRNavigation from "../components/Navigation/HrNavigation";

function HRManager() {
  return (
    <>
      <HRNavigation />
      <div className="content">
        <Outlet />
      </div>
    </>
  );
}

export default HRManager;
