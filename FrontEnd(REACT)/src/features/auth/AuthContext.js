import { createContext, useEffect, useState } from 'react';
import { apiService } from 'services/apiService';
import { API_ENDPOINT } from 'utils/constants';
import axios from 'axios';
import { useContext } from 'react';

const AuthContext = createContext();

function AuthContextProvider({ children }) {
    const [isAuthenticated, setAuthenticated] = useState(false);

    useEffect(() => {
        const token = localStorage.getItem('token');
        if (token) {
            setAuthenticated(true);
        }
        else {
            setAuthenticated(false);
        }
    }, [])

    const HandleLogin = async (phoneNumber) => {
        try {
            const response = await axios.post(`${API_ENDPOINT}/Auth/RequestLogin`, {
                phoneNumber,
            });

            if (response.status >= 200 && response.status < 300) {


                return false;
            }

        } catch (error) {
            if (error.response.status === 401)
                return true;

            console.error('Login failed:', error.message);
            throw error;
        }
    };


    const ApproveLogin = async ({ phoneNumber, code }) => {
        try {
            const response = await axios.post(`${API_ENDPOINT}/Auth/ApproveLogin`, {
                phoneNumber,
                code
            });

            if (response.status >= 200 && response.status < 300) {
                if (response?.data?.isCodeFailed) {
                    return -1;
                }

                const currentToken = response.data;
                localStorage.setItem('token', currentToken.accessToken);
                setAuthenticated(true);
                return true;
            }

        } catch (error) {

            console.error('Login failed:', error.message);
            return false;
        }
    }

    const HandleRegister = async (user) => {
        try {
            user.name = user.fullName;
            const response = await axios.post(`${API_ENDPOINT}/Auth/Register`, user);

            if (response.status >= 200 && response.status < 300) {
                const currentToken = response.data;
                setAuthenticated(true);
                localStorage.setItem('token', currentToken.accessToken);
            }

        } catch (error) {
            console.error('Login failed:', error.message);
            return true;
        }
    }

    const Logout = () => {
        localStorage.removeItem("token");
        setAuthenticated(false);
    }



    return (
        <AuthContext.Provider value={{
            HandleLogin, ApproveLogin, HandleRegister, Logout, isAuthenticated
        }}>

            {children}
        </AuthContext.Provider>
    )
}

export { AuthContext, AuthContextProvider, useAuth }

const useAuth = () => {
    return useContext(AuthContext);
};