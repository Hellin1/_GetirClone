import { shadowStyle } from 'features/common/Styles'
import { HiPlus } from 'react-icons/hi'

import GiftIcon from "./GiftIcon"

function PaymentSummary({cart}) {
    return (
        <div className='bg-white rounded-md p-6' style={shadowStyle}>
            <div className='flex flex-row gap-4 items-center border-b-[1px] border-gray-100 pb-4 mb-[1px]'>
                <div><GiftIcon size={32} className='text-primary-brand-color fill-primary-brand-color w-8 h-8' /></div>
                <span className='text-primary-brand-color font-semibold text-14px'> Kampanya Seçin </span>

            </div>
            <div className='flex flex-row gap-4 items-center border-b-[1px] border-gray-100 py-4 '>
                <div className='rounded-lg bg-purple-700 bg-opacity-10 w-8 h-8 flex items-center justify-center '><HiPlus size={17} className='text-primary-brand-color' /></div>
                <div className='text-primary-brand-color font-semibold text-14px'>Fatura Bilgisi Ekle</div>

            </div>
            <div className='flex justify-between items-center border-b-[1px] border-gray-100 py-4 text-gray-500'>
                <div className='font-semibold text-14px '>Sepet Tutarı</div>
                <span className=' font-semibold text-14px'> ₺{cart.totalPrice} </span>

            </div>
            <div className='flex flex-col gap-y-3  border-b-[1px] border-gray-100 py-4 text-gray-500'>
                <div className='flex justify-between'>

                    <div className='font-semibold text-14px '>Getirmesi </div>
                    <span className=' font-semibold text-14px'> {cart.deliveryFee == 0 ? 'Ücretsiz' : `₺${cart.deliveryFee}`} </span>
                </div>
                {cart.neededPriceForFreeDelivery != 0 &&
                    <div className='flex flex-row gap-2 items-center border-b-[1px] border-gray-100 py-4 bg-primary-brand-color bg-opacity-10 rounded-md'>
                        <div className='w-full flex flex-row gap-4 px-3 '>
                            <img src="https://cdn.getir.com/ldf/LDF-checkout.png" alt="getir" srcSet="" className='w-4 h-4' />
                            <div className='text-sm font-14px text-primary-brand-color'><span className='font-semibold'>₺{cart.neededPriceForFreeDelivery}</span> sonra <span className='font-semibold'>getirmesi ücretsiz!</span> Birkaç ürün daha ekleyin.</div>
                        </div>
                    </div>
                }
            </div>
            <div className='flex justify-between items-center border-b-[1px] border-gray-100 py-4 text-gray-500'>
                <div className='font-semibold text-14px '>Poşet Ücreti </div>
                <span className=' font-semibold text-14px'> ₺0,25 </span>

            </div>
            <div className='flex justify-between items-center  pt-4 text-primary-brand-color '>
                <div className='font-semibold text-14px '>Ödenecek Tutar </div>
                <span className=' font-semibold text-14px'> ₺{(cart.totalPrice + cart.deliveryFee + cart.bagPrice).toFixed(2)}</span>

            </div>
        </div>
    )
}

export default PaymentSummary