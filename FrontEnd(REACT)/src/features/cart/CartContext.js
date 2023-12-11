import { createContext, useEffect, useState } from 'react';
import { apiService } from 'services/apiService';

const CartContext = createContext();

async function getCart() {
    let response = await apiService.get(`Cart/GetById`);
    return response;
}



function CartContextProvider({ children }) {
    const [cart, setCart] = useState([]);


    async function IncreaseCartLineAmount(productId, customerId = 1, note = "y") {
        let obj = {
          ProductId: productId,
          Quantity: 1
        };
    
        try {
          await apiService.post("Cart/AddToCart", obj);
    
          const updatedCart = await getCart(customerId);
          setCart(updatedCart);
        }
        catch (error) {
          console.log("hata: ", error);
        }
    
      }
    
      async function DecreaseCartLineAmount(productId, customerId = 1, note = "y") {
        let obj = {
          ProductId: productId,
        };
    
        try {
          await apiService.delete("Cart/RemoveFromCart", obj);
    
          const updatedCart = await getCart(customerId);
          setCart(updatedCart);
        }
        catch (error) {
          console.log("hata: ", error);
        }
    
      }
    


    useEffect(() => {
        async function fillStates() {
            setCart(await getCart(1));
        }

        fillStates()

    }, [])


    return (
        <CartContext.Provider value={{
            cart, setCart, getCart, IncreaseCartLineAmount, DecreaseCartLineAmount
        }}>
            {children}
        </CartContext.Provider>
    )
}

export { CartContext, CartContextProvider }
