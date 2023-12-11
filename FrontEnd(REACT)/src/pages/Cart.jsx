import { useContext, useEffect, useState } from 'react'
import GetirHeader from '../components/GetirHeader'
import { CgTrash } from 'react-icons/cg'
import { GoPlus } from "react-icons/go"
import { BiMinus } from "react-icons/bi"
import { Link, redirect } from "react-router-dom";
import { GrLocation } from "react-icons/gr"
import { useNavigate } from 'react-router-dom';
import AddressIcon from 'features/address/AddressIcon'
import { PiTrashBold } from "react-icons/pi"
import { shadowStyle } from "features/common/Styles"
import { CartContext } from 'features/cart/CartContext'
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext'
import { apiService } from 'services/apiService'
import { AddressContext } from 'features/address/AddressContext'

function calculatePaddingAndBorderValue(index, productCartLength) {
  let padding = ""
  let border = ""

  if (productCartLength !== 1) {
    if (index === 0)
      padding = "pb-6";
    else if (index === productCartLength - 1)
      padding = "pt-6";
    else
      padding = "py-6";
  }

  border = `${index === productCartLength - 1 ? '' : 'border-b-[1px] border-gray-100'}`

  return `${padding} ${border}`
}


function Cart() {
  let navigate = useNavigate();
  const { cart, getCart, setCart, IncreaseCartLineAmount, DecreaseCartLineAmount } = useContext(CartContext);
  const { setCommonElementsVisibility, commonElementsVisibility } = useContext(CommonElementsVisibilityContext);
  const { addresses, setAddresses, getCurrentAddress } = useContext(AddressContext);

  const [currentAddress, setCurrentAddress] = useState();
  

  useEffect(() => {
    setCommonElementsVisibility({ ...commonElementsVisibility, header: false, footer:false });
    getActiveAddress();

    if (!cart?.productCarts?.length > 0)
      navigate("/")
  }, [cart])

  
  async function getActiveAddress() {
    let currentAddress = await getCurrentAddress(1)
    if (!currentAddress)
        navigate("/")
    setCurrentAddress(currentAddress);
}



  async function EmptyCart(customerId = 1) {
    let obj = {}
    await apiService.post("Cart/EmptyCart", obj);
    await setCart([])
  }

  return (
    <div>
      <GetirHeader widthOfLogo={1024} />
      <div className="flex mt-5">
        <div className=" md:w-[1024px]   mx-auto flex flex-row gap-x-6">
          <div className='w-[70%]'>
            <div className='w-full flex justify-between mb-4'>
              <span className='text-sm font-semibold text-gray-700'>Sepetim</span>
              <div className='whitespace-nowrap text-primary-brand-color cursor-pointer' onClick={() => EmptyCart(1)}>
                <PiTrashBold size={22} className='inline-block ' />&nbsp;<span className='text-sm'>Sepeti Temizle</span>
              </div>
            </div>
            <div className='bg-white p-6 rounded-lg min-h-[118px] '>
              {cart?.productCarts?.map((productCart, index) => (
                <div key={index} className={`w-full h-full flex justify-between items-center ${calculatePaddingAndBorderValue(index, cart?.productCarts?.length)}`}>
                  <div className='flex items-center'>
                    <img className='w-[70px] h-[70px] inline-flex border-[1px] border-gray-100  rounded-lg' src={`${productCart.product.imageUrl}`} />
                    <div className='inline-flex flex-col ml-3'>

                      <span className='text-primary-brand-color font-semibold text-sm'>₺{productCart.product.price}</span>
                      <span className='text-gray-600 font-semibold text-sm '>{productCart.product.title}</span>
                      <span className='text-gray-500 text-sm'>6'lı</span>
                    </div>
                  </div>
                  <div className='flex w-[100px]'>
                    <div className={`flex-1 h-8 flex justify-center items-center   rounded-lg    border-l-[0.185rem] border-brand-color-300 text-primary-brand-color cursor-pointer`} style={shadowStyle} onClick={() => DecreaseCartLineAmount(productCart.productId)}>
                      {
                        productCart.quantity > 1 ?
                          <BiMinus size={22} className="self-center" /> : <PiTrashBold size={20} className="self-center " />
                      }
                    </div>
                    <div className="flex-1 h-8  bg-primary-brand-color justify-center items-center flex text-white">{productCart.quantity}</div>
                    <div className="flex-1 h-8 flex justify-center items-center  rounded-lg   border-r-[0.185rem] border-brand-color-300 cursor-pointer" onClick={() => IncreaseCartLineAmount(productCart.productId)}>
                      <GoPlus size={15} className="self-center text-primary-brand-color" />
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </div>
          <div className="w-[30%] flex flex-col gap-y-5  ">
            <div className='text-sm'>
              <div className='mb-4 w-[24px]'>
                Adres
              </div>
              <div className='flex bg-white rounded-lg p-6 flex-row '>
                <div className='text-primary-brand-color'><AddressIcon pathClass="stroke-primary-brand-color " size={22} /></div>
                <div className='ml-4 text-gray-500'>
                  {currentAddress?.addressString}
                </div>
              </div>
            </div>
            <div className='w-full'>
              Sepet Toplamı
              <div className='bg-white w-full p-6 mt-3 flex flex-row justify-between rounded-lg' style={shadowStyle}>
                <div>Sepet Tutarı</div>
                <div>₺{cart.totalPrice}</div>
              </div>
            </div>
            <Link to={`/Payment`} className='w-full rounded-lg text-white bg-primary-brand-color flex justify-center items-center h-12 hover:bg-secondary-brand-color'>
              Ödemeye Geç
            </Link>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Cart