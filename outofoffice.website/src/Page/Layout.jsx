import Navigation from "../components/Navigation/Navigation";
import { Outlet } from "react-router-dom";

function Layout() {
  return (
    <>
      <Navigation />
      <div className="content">
        <Outlet />
      </div>
    </>
  );
}

export default Layout;
