import { Navigate } from "react-router-dom";
import { useContext } from "react";
import { AuthContext } from "./AuthContext";

const ProtectedRoute = ({ children }) => {
  const {isAuthenticated} = useContext(AuthContext);

  if (!isAuthenticated) {
    return <Navigate to="/" replace />;
  }
  return children;
};
export default ProtectedRoute;