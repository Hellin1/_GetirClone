import { createContext, useEffect, useState } from 'react';
import { apiService } from 'services/apiService';

const ProductContext = createContext();


async function getProducts() {
    return await apiService.get("Products/ListWithCategories");
}


function ProductContextProvider({ children }) {
    const [products, setProducts] = useState([]);


    return (
        <ProductContext.Provider value={{
            products, getProducts, setProducts,
        }}>
            {children}
        </ProductContext.Provider>
    )
}

export { ProductContext, ProductContextProvider }