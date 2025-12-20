import { Routes, Route, Navigate } from "react-router-dom";
import LoginPage from "../pages/login/LoginPage";
import CreateEmployeePage from "../pages/employees/CreateEmployeePage";

export default function AppRoutes() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route path="/employees/create" element={<CreateEmployeePage />} />
      <Route path="*" element={<Navigate to="/login" replace />} />
    </Routes>
  );
}
