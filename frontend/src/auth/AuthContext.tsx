import { createContext, useEffect, useState } from "react";
import { loginRequest } from "./auth.service";

type AuthContextType = {
  token: string | null;
  isAuthenticated: boolean;
  login: (email: string, password: string) => Promise<void>;
  logout: () => void;
};

export const AuthContext = createContext<AuthContextType>(
  {} as AuthContextType
);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string | null>(null);

  useEffect(() => {
    const storedToken = localStorage.getItem("token");
    if (storedToken) {
      setToken(storedToken);
    }
  }, []);

  async function login(email: string, password: string) {
    const data = await loginRequest(email, password);
    localStorage.setItem("token", data.accessToken);
    setToken(data.accessToken);
  }

  function logout() {
    localStorage.removeItem("token");
    setToken(null);
    window.location.href = "/login";
  }

  return (
    <AuthContext.Provider
      value={{
        token,
        isAuthenticated: !!token,
        login,
        logout,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}
