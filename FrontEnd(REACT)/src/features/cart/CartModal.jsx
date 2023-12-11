import { GoPlus } from "react-icons/go"
import { CgTrash } from "react-icons/cg";
import { BiMinus } from "react-icons/bi"
import { useContext, useEffect } from "react";
import { Link } from "react-router-dom";
import { CartContext } from "./CartContext";
import { shadowStyle } from "features/common/Styles"
import { apiService } from "services/apiService";
import { ToastContainer, toast } from 'react-toastify';

function CartModal() {
  const { cart, setCart, getCart, IncreaseCartLineAmount, DecreaseCartLineAmount } = useContext(CartContext);

  useEffect(()=> {
    async function FillStates(){
      setCart(await getCart());
    }
    FillStates();
  },[])


  return (
    <div className='flex  justify-center   w-full rounded-lg   border-[0.185rem] border-yellow-300 ' style={shadowStyle}>
      <>
        {cart?.productCarts?.length > 0 ?
          <div className='flex flex-col  gap-y-2 mt-3   w-full'>
            <div className='w-full h-full max-h-[310px] overflow-auto'>
              {cart?.productCarts?.map((productCart) => (
                <div key={productCart.product.id} className='flex justify-between px-6 flex-wrap py-3'>
                  <div>
                    <div className='text-gray-500 font-semibold text-sm tracking-wide'>
                      {productCart?.product.title?.length > 13 ? productCart?.product?.title?.substring(0, 13) + "..." : productCart?.product?.title}
                    </div>
                    <div className='text-primary-brand-color font-semibold text-start text-sm '>
                      ₺{productCart?.product?.price}
                    </div>
                  </div>
                  <div className="w-24 flex">
                    <div className={`flex-1 h-8 flex justify-center items-center   rounded-lg    border-l-[0.185rem] border-brand-color-300 text-primary-brand-color cursor-pointer`} style={shadowStyle} onClick={() => DecreaseCartLineAmount(productCart.productId)}>
                      {
                        productCart.quantity > 1 ?
                          <BiMinus size={22} className="self-center" /> : <CgTrash size={22} className="self-center " />
                      }
                    </div>
                    <div className="flex-1 h-8  bg-primary-brand-color justify-center items-center flex text-white">{productCart.quantity}</div>
                    <div className="flex-1 h-8 flex justify-center items-center  rounded-lg   border-r-[0.185rem] border-brand-color-300 cursor-pointer" onClick={() => IncreaseCartLineAmount(productCart.productId)}>
                      <GoPlus size={22} className="self-center " />
                    </div>

                  </div>
                </div>
              ))}
            </div>
            <div className="group">

              <div className="  w-[248px] mx-auto mb-5 mt-1    flex border-[0.185rem] border-primary-brand-color rounded-lg group-hover:border-secondary-brand-color">
                <Link to={`/Cart`} className="w-[60%]  h-11   bg-primary-brand-color text-white flex justify-center items-center  text-sm group-hover:bg-secondary-brand-color transition-all" >
                  <div >  Sepete Git</div>
                </Link>
                <div className="w-[40%]  h-11  flex justify-center items-center text-primary-brand-color  text-sm">₺{cart.totalPrice}</div>
              </div>
            </div>
          </div>
          :
          <div className='flex flex-col  justify-center  items-center gap-y-2 text-center  w-full h-[350px]'>
            <img className="w-[86px] object-fill  mb-10" src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNzIiIGhlaWdodD0iODYiIHZpZXdCb3g9IjAgMCA3MiA4NiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwKSI+CjxwYXRoIGQ9Ik0wLjUgMjVINzAuNzc1NlY4NS4yMzQ3SDAuNVYyNVoiIGZpbGw9IiNEQkRCRkYiLz4KPHBhdGggZD0iTTIzLjA4MzggMC4zMzMwMDhINDcuOTg3TDUyLjk3NTQgNS4zODlWMjUuNDMxNkw0Ny41NzgxIDI1LjQxNzRWNS4zNzgzNEgyMy41MjQ3VjI1LjQxNzRMMTguMDI3OCAyNS40MzE2VjUuMzc4MzRMMjMuMDgzOCAwLjMzMzAwOFoiIGZpbGw9IiNEQkRCRkYiLz4KPC9nPgo8ZGVmcz4KPGNsaXBQYXRoIGlkPSJjbGlwMCI+CjxyZWN0IHdpZHRoPSI3MSIgaGVpZ2h0PSI4NiIgZmlsbD0id2hpdGUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAuNSkiLz4KPC9jbGlwUGF0aD4KPC9kZWZzPgo8L3N2Zz4K" alt="" />
            <div className='text-primary-brand-color font-sans  text-base font-semibold leading-4 font-size: 16px; line-height: 16px; '>
              Sepetiniz şu an boş
            </div>
            <span className='text-sm px-6 mt-1 font-sans font-semibold text-gray-500'>
              Sipariş vermek için sepetinize ürün ekleyin
            </span>
          </div>
        }
      </>
    </div>
  )
}

export default CartModal