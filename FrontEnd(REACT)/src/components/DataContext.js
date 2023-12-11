import { createContext, useEffect, useState } from 'react';
import { apiService } from 'services/apiService';
import { API_ENDPOINT } from 'utils/constants';
import axios from 'axios';
import { useContext } from 'react';

const ApiDataContext = createContext();

function ApiDataContextProvider({ children }) {

    useEffect(() => {


    }, [])

    return (
        <ApiDataContext.Provider value={{
        }}>

            {children}
        </ApiDataContext.Provider>
    )
}

export { ApiDataContext, ApiDataContextProvider }