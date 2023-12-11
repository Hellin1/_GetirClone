import { Route, Routes, BrowserRouter as Router } from "react-router-dom";
import Container from "pages/Container"
import Catalog from "pages/Catalog"
import ZincirRestoranlar from "pages/ZincirRestoranlar";
import Cart from "pages/Cart";
import Payment from "features/payment/Payment";
import { ProductContextProvider } from "features/product/ProductContext";
import { CategoryContextProvider } from "features/category/CategoryContext";
import { CartContextProvider } from "features/cart/CartContext";
import { LanguageContextProvider } from "features/language/LanguageContext";
import { AuthContextProvider } from "features/auth/AuthContext";
import { ToastContainer } from 'react-toastify';
import { AddressContextProvider } from "features/address/AddressContext";
import StartPage from "pages/StartPage";
import ProtectedRoute from "features/auth/ProtectedRoute";
import NonProtectedRoute from "features/auth/NonProtectedRoute";
import { CommonElementsVisibilityProvider } from "features/common/CommonElementsVisibilityContext";

function App() {
  return (
    <AuthContextProvider>
      <AddressContextProvider>
        <CartContextProvider>
          <CategoryContextProvider>
            <ProductContextProvider>
              <LanguageContextProvider>
                <CommonElementsVisibilityProvider>

                  <Router>
                    <Routes>
                      <Route path="/" element={<Container />}>
                        <Route path="/kategoriler" index element={<ProtectedRoute> <Catalog /> </ProtectedRoute>} />
                        <Route path="Cart" element={<ProtectedRoute> <Cart /> </ProtectedRoute>} />
                        <Route path="ZincirRestoranlar" element={<ProtectedRoute> <ZincirRestoranlar /></ProtectedRoute>} />
                        <Route path="Payment" element={<ProtectedRoute> <Payment /> </ProtectedRoute>} />

                        <Route path="/" element={<NonProtectedRoute><StartPage /></NonProtectedRoute>} />
                      </Route>
                    </Routes>
                  </Router>

                  <ToastContainer />
                </CommonElementsVisibilityProvider>
              </LanguageContextProvider>
            </ProductContextProvider>
          </CategoryContextProvider>
        </CartContextProvider>
      </AddressContextProvider>
    </AuthContextProvider>
  )
}

export default App;