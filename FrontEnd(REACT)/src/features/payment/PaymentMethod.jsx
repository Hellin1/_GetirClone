import { shadowStyle } from "features/common/Styles"
import { HiPlus } from "react-icons/hi"


function PaymentMethod({selectedPayment,setShowChangePaymentCardModal, setShowPaymentCardModal}) {
    return (
        <div className='bg-white rounded-md  w-full flex flex-col  p-6 ' style={shadowStyle}>
            {selectedPayment ?
                <div className='flex justify-between items-center  w-full h-9'>
                    <div className='flex gap-2 h-full items-center'>
                        <div className='flex w-[22px] h-[22px] rounded-full border-[2px] border-primary-brand-color '>
                            <div className='w-[14px] h-[14px] rounded-full  bg-primary-brand-color m-auto'></div>
                        </div>
                        <div className='w-[34px] ' >
                            <img src={selectedPayment.cardType.cardTypeImageUrl} alt="" />
                        </div>
                        <div className='flex flex-col text-14px text-sm  items-center h-full'>

                            <div className=''>{selectedPayment.cardNickName}</div>
                            <div className='text-gray-500'>{selectedPayment.cardNumber}</div>

                        </div>
                    </div>
                    <div className='border-[2px] flex items-center border-primary-brand-color text-sm h-8  rounded-lg  text-primary-brand-color cursor-pointer' onClick={() => setShowChangePaymentCardModal(true)}>
                        <div className='p-2 font-semibold'>
                            Değiştir
                        </div>
                    </div>
                </div>
                :
                <div className='text-center w-full text-sm font-semibold text-gray-400 py-1 pb-2 '>Kayıtlı Ödeme Yönteminiz Bulunmuyor {selectedPayment?.id}</div>
            }
            <div className='flex flex-col  '>
                <div className='flex flex-row gap-2 py-3 items-center cursor-pointer' onClick={() => setShowPaymentCardModal(true)}>
                    <div className='rounded-lg bg-purple-700 bg-opacity-10 w-8 h-8 flex items-center justify-center '><HiPlus size={17} className='text-primary-brand-color' /></div>
                    <div className='text-primary-brand-color text-14px font-semibold ' >Kredi / Banka Kartı Ekle</div>
                </div>
                <a className='flex flex-row gap-2 py-3 items-center cursor-pointer' href='https://web.bkmexpress.com.tr/new/#/login' >
                    <div className='rounded-lg bg-purple-700 bg-opacity-10 w-8 h-8 flex items-center justify-center '><HiPlus size={17} className='text-primary-brand-color' /></div>
                    <div className='text-primary-brand-color text-14px font-semibold ' >BKM Express Kart Ekle</div>
                </a>
            </div>
        </div>

    )
}

export default PaymentMethod