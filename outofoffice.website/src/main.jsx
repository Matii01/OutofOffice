import React from "react";
import ReactDOM from "react-dom/client";
import "bootstrap/dist/css/bootstrap.min.css";
import "bootstrap/dist/js/bootstrap.js";

import App from "./App.jsx";
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import ProtectedRoute from "./ProtectedRoute.jsx";
import { Provider } from "react-redux";
import { configureStore } from "@reduxjs/toolkit";
import { api } from "./api/api.js";
import ProjectsList from "./components/Projects/ProjectsList.jsx";
import LeaveRequests from "./components/LeaveRequest/LeaveReuquests.jsx";
import Layout from "./Page/Layout.jsx";
import ApprovalRequests from "./components/ApprovalRequest/ApprovalRequest.jsx";
import EmployeeList from "./components/Employee/EmployeeList.jsx";

const root = ReactDOM.createRoot(document.getElementById("root"));

const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [{}],
  },

  {
    path: "/lists",
    async lazy() {
      return {
        element: (
          <>
            <Layout />
          </>
        ),
      };
    },
    children: [
      {
        path: "employee",
        async lazy() {
          return {
            element: (
              <>
                <ProtectedRoute
                  roles={["HRManager", "ProjectManager", "Administrator"]}
                >
                  <EmployeeList />
                </ProtectedRoute>
              </>
            ),
          };
        },
      },
      {
        path: "projects",
        async lazy() {
          return {
            element: (
              <>
                <ProtectedRoute
                  roles={[
                    "HRManager",
                    "ProjectManager",
                    "Administrator",
                    "Employee",
                  ]}
                >
                  <ProjectsList />
                </ProtectedRoute>
              </>
            ),
          };
        },
      },
      {
        path: "leaverequest",
        async lazy() {
          return {
            element: (
              <>
                <ProtectedRoute
                  roles={[
                    "HRManager",
                    "ProjectManager",
                    "Administrator",
                    "Employee",
                  ]}
                >
                  <LeaveRequests />
                </ProtectedRoute>
              </>
            ),
          };
        },
      },
      {
        path: "approvalrequest",
        async lazy() {
          return {
            element: (
              <>
                <ProtectedRoute
                  roles={["HRManager", "ProjectManager", "Administrator"]}
                >
                  <ApprovalRequests />,
                </ProtectedRoute>
              </>
            ),
          };
        },
      },
    ],
  },
]);

const store = configureStore({
  reducer: {
    [api.reducerPath]: api.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(api.middleware),
});

root.render(
  <React.StrictMode>
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  </React.StrictMode>
);
