import { createContext, useState } from 'react';
import { apiService } from 'services/apiService';
import { ToastContainer, toast } from 'react-toastify';
const CategoryContext = createContext();


async function getCategories() {
    let response = await apiService.get("Categories/List"); 
    return response;
}

function CategoryContextProvider({ children }) {
    const [categories, setCategories] = useState([]);

    return (
        <CategoryContext.Provider value={{
            categories, getCategories, setCategories,
        }}>
            {children}
        </CategoryContext.Provider>
    )
}

export { CategoryContext, CategoryContextProvider }