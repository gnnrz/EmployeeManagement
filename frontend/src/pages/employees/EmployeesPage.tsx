import { useEffect, useState } from "react";
import api from "../../shared/api";

type Employee = {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  role: string;
};

export default function EmployeesPage() {
  const [employees, setEmployees] = useState<Employee[]>([]);

  useEffect(() => {
    api.get<Employee[]>("/employees").then((res) => {
      setEmployees(res.data);
    });
  }, []);

  return (
    <div>
      <h2>Employees</h2>

      <ul>
        {employees.map((e) => (
          <li key={e.id}>
            {e.firstName} {e.lastName} - {e.email} ({e.role})
          </li>
        ))}
      </ul>
    </div>
  );
}
