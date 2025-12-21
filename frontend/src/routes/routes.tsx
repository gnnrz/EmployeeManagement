import { Navigate, useRoutes } from "react-router-dom";
import LoginPage from "../pages/login/LoginPage";
import CreateEmployeePage from "../pages/employees/CreateEmployeePage";
import ProtectedRoute from "./ProtectedRoute";

export default function AppRoutes() {
  return useRoutes([
    {
      path: "/",
      element: <Navigate to="/login" replace />,
    },
    {
      path: "/login",
      element: <LoginPage />,
    },
    {
      path: "/employees/create",
      element: (
        <ProtectedRoute>
          <CreateEmployeePage />
        </ProtectedRoute>
      ),
    },
    {
      path: "*",
      element: <Navigate to="/login" replace />,
    },
  ]);
}
