import { useEffect } from 'react';
import { useAuth } from './AuthContext';
import { useNavigate } from 'react-router-dom';

const UseAuthProtection = () => {
  const { isAuthenticated } = useAuth();
  let navigate = useNavigate();

  useEffect(() => {
    if (!isAuthenticated) {
        navigate('/');
    }
  }, [isAuthenticated]);

  return isAuthenticated;
};

export default UseAuthProtection;