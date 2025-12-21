import { useState } from "react";
import api from "../../shared/api";
import { jwtDecode } from "jwt-decode";
import axios from "axios";

type JwtPayload = {
  email: string;
  name?: string;
};

export default function CreateEmployeePage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [document, setDocument] = useState("");
  const [birthDate, setBirthDate] = useState("");
  const [role, setRole] = useState<number>(1);
  const [password, setPassword] = useState("");
  const [phone1, setPhone1] = useState("");
  const [phone2, setPhone2] = useState("");

  const [error, setError] = useState("");
  const [showSuccessModal, setShowSuccessModal] = useState(false);

  const token = localStorage.getItem("token");

  let welcomeName = "User";

  if (token) {
    try {
      const decoded = jwtDecode<JwtPayload>(token);
      welcomeName = decoded.name ?? decoded.email;
    } catch {
      welcomeName = "User";
    }
  }

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setError("");

    try {
      await api.post("/employees", {
        firstName,
        lastName,
        email,
        document,
        birthDate,
        role,
        managerId: null,
        phones: [phone1, phone2],
        password,
      });

      setShowSuccessModal(true);
    } catch (err) {
      if (axios.isAxiosError(err)) {
        const message =
          err.response?.data?.detail ||
          err.response?.data?.title ||
          "Failed to create employee";

        setError(message);
      }
    }
  }

  return (
    <div className="container">
      <div className="card">
        <h2>Welcome, {welcomeName}</h2>
        <p style={{ textAlign: "center", marginBottom: 12 }}>
          Create a new employee
        </p>

        {error && <p className="error">{error}</p>}

        <form onSubmit={handleSubmit}>
          <input
            placeholder="First name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />

          <input
            placeholder="Last name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />

          <input
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />

          <input
            placeholder="Document"
            value={document}
            onChange={(e) => setDocument(e.target.value)}
            required
          />

          <input
            type="date"
            value={birthDate}
            onChange={(e) => setBirthDate(e.target.value)}
            required
          />

          <select
            value={role}
            onChange={(e) => setRole(Number(e.target.value))}
            required
          >
            <option value={1}>Employee</option>
            <option value={2}>Leader</option>
            <option value={3}>Director</option>
          </select>

          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />

          <input
            placeholder="Phone 1"
            value={phone1}
            onChange={(e) => setPhone1(e.target.value)}
            required
          />

          <input
            placeholder="Phone 2"
            value={phone2}
            onChange={(e) => setPhone2(e.target.value)}
            required
          />

          <button type="submit">Create</button>
        </form>
      </div>

      {showSuccessModal && (
        <div className="modal-overlay">
          <div className="modal">
            <h3>Employee created successfully</h3>
            <p>The new employee has been registered.</p>

            <button
              onClick={() => {
                localStorage.removeItem("token");
                window.location.href = "/login";
              }}
            >
              Go to login
            </button>
          </div>
        </div>
      )}
    </div>
  );
}
