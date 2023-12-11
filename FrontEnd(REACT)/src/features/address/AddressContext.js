import { createContext, useState } from 'react';
import { apiService } from 'services/apiService';

const AddressContext = createContext();

async function getAddresses(customerId) {
    return await apiService.get(`Address/List`);
}

async function getCurrentAddress(customerId){
    return await apiService.get(`Address/GetActiveAddress`)
}


function AddressContextProvider({ children }) {
    const [addresses, setAddresses] = useState([]);


    return (
        <AddressContext.Provider value={{
            addresses, setAddresses, getAddresses, getCurrentAddress
        }}>
            {children}
        </AddressContext.Provider>
    )
}

export { AddressContext, AddressContextProvider }