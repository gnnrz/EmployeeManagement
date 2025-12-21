import { Routes, Route } from "react-router-dom";
import LoginPage from "../pages/login/LoginPage";
import CreateEmployeePage from "../pages/employees/CreateEmployeePage";
import ProtectedRoute from "./ProtectedRoute";

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />

      <Route
        path="/employees/create"
        element={
          <ProtectedRoute>
            <CreateEmployeePage />
          </ProtectedRoute>
        }
      />

      <Route path="*" element={<LoginPage />} />
    </Routes>
  );
}
