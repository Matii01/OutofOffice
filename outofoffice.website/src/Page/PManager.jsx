import { Outlet } from "react-router-dom";
import PMNavigation from "../components/Navigation/PMNavigation";

function PManager() {
  return (
    <>
      <PMNavigation />
      <div className="content">
        <Outlet />
      </div>
    </>
  );
}

export default PManager;
