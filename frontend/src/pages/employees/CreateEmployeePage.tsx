import { useState } from "react";
import api from "../../shared/api";

export default function CreateEmployeePage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState(0);
  const [phones, setPhones] = useState(["", ""]);
  const [error, setError] = useState("");
  const [success, setSuccess] = useState("");

  async function handleSubmit(e: React.FormEvent) {
    e.preventDefault();
    setError("");
    setSuccess("");

    try {
      await api.post("/employees", {
        firstName,
        lastName,
        email,
        password,
        role,
        phones,
        document: "12345678900",
        birthDate: "1995-01-01",
        managerId: null,
      });

      setSuccess("Employee created successfully!");
      setFirstName("");
      setLastName("");
      setEmail("");
      setPassword("");
      setPhones(["", ""]);
    } catch (err) {
      console.error(err);
      setError("Failed to create employee");
    }
  }

  function updatePhone(index: number, value: string) {
    const updated = [...phones];
    updated[index] = value;
    setPhones(updated);
  }

  return (
    <div>
      <h2>Create Employee</h2>

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
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
          required
        />

        <select value={role} onChange={(e) => setRole(e.target.value)}>
          <option value={1}>Employee</option>
          <option value={2}>Leader</option>
          <option value={3}>Director</option>
        </select>

        <input
          placeholder="Phone 1"
          value={phones[0]}
          onChange={(e) => updatePhone(0, e.target.value)}
          required
        />

        <input
          placeholder="Phone 2"
          value={phones[1]}
          onChange={(e) => updatePhone(1, e.target.value)}
          required
        />

        <button type="submit">Create</button>

        {error && <p style={{ color: "red" }}>{error}</p>}
        {success && <p style={{ color: "green" }}>{success}</p>}
      </form>
    </div>
  );
}
