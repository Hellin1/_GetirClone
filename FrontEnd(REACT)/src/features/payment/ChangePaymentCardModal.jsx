import { useState } from 'react'
import { IoMdClose } from "react-icons/io"
import { HiPlus } from 'react-icons/hi'
import RemovePaymentCardModal from './RemovePaymentCardModal';
import { apiService } from 'services/apiService';

function ChangePaymentCardModal({ showChangePaymentCardModal, setShowChangePaymentCardModal, showPaymentCardModal, setShowPaymentCardModal,
    getCurrentCard, getPaymentCards, paymentCards, selectedPayment }) {
    const [showRemovePaymentCardModal, setShowRemovePaymentCardModal] = useState(false);

    function openPaymentCardModalAndCloseThisModal() {
        setShowPaymentCardModal(true)
        setShowChangePaymentCardModal(false)
    }


    async function changePrimaryCard(cardId, customerId = 1) {
        let obj = {  CardId: cardId }

        try {
            await apiService.post(`PaymentCard/ChangeActiveCard`, obj);

            await getPaymentCards(1)
        }
        catch (error) {
            console.log("hata: ", error);
        }
    }

    return (
        <>
            <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-[60] outline-none focus:outline-none " onClick={() => setShowChangePaymentCardModal(false)}>
                <div className="w-[450px] h-min-[340px]  rounded-lg bg-gray-50 px-8   py-6 relative flex flex-col justify-stretch  gap-y-10" onClick={(e) => e.stopPropagation()} >
                    <div className="flex justify-center  text-md text-14px font-semibold text-primary-brand-color font-base relative  " >
                        Online Ödeme Yöntemi Seçin
                        <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setShowChangePaymentCardModal(false)}>
                            <IoMdClose size={18} className="transform scale-[0.]" />
                        </div>
                    </div>
                    <div className='flex flex-col gap-6 h-min-[300px]'>
                        {paymentCards.map((paymentCard,index) =>
                            <div className='flex justify-between items-center  w-full h-9 cursor-pointer' key={index} onClick={() => changePrimaryCard(paymentCard.id)}>
                                <div className='flex gap-2 h-full items-center'>
                                    <div className='flex w-[22px] h-[22px] rounded-full border-[2px] border-primary-brand-color ' >
                                        <div className={`w-[14px] h-[14px] rounded-full  ${paymentCard.isPrimary && 'bg-primary-brand-color'} m-auto`} ></div>
                                    </div>
                                    <div className='w-[34px] ' >
                                        <img src={paymentCard.cardType.cardTypeImageUrl} alt="" />
                                    </div>
                                    <div className='flex flex-col text-14px text-sm  items-center h-full'>
                                        <div className=''>{paymentCard.cardNickName}</div>
                                        <div className='text-gray-500'>{paymentCard.cardNumber}</div>
                                    </div>
                                </div>
                                {paymentCard.isPrimary &&
                                    <div className={`border-[2px] flex items-center border-primary-brand-color text-sm h-8  rounded-lg  text-primary-brand-color cursor-pointer `} onClick={() => setShowRemovePaymentCardModal(prev => !prev)}>
                                        <div className='p-2 font-semibold'>
                                            Kartı Sil
                                        </div>
                                    </div>
                                }
                            </div>
                        )}
                    </div>

                    <div className='flex flex-col gap-4  '>
                        <div className='flex flex-row gap-2  items-center cursor-pointer' >
                            <div className='rounded-lg bg-purple-700 bg-opacity-10 w-8 h-8 flex items-center justify-center '><HiPlus size={17} className='text-primary-brand-color' /></div>
                            <div className='text-primary-brand-color text-14px font-semibold ' onClick={() => openPaymentCardModalAndCloseThisModal()} >Kredi / Banka Kartı Ekle</div>
                        </div>
                        <a className='flex flex-row gap-2  items-center cursor-pointer' href='https://web.bkmexpress.com.tr/new/#/login' >
                            <div className='rounded-lg bg-purple-700 bg-opacity-10 w-8 h-8 flex items-center justify-center '><HiPlus size={17} className='text-primary-brand-color' /></div>
                            <div className='text-primary-brand-color text-14px font-semibold ' >BKM Express Kart Ekle</div>
                        </a>
                    </div>
                    <button className='w-full rounded-lg text-white bg-primary-brand-color flex justify-center items-center h-12 hover:bg-secondary-brand-color' onClick={() => setShowChangePaymentCardModal(false)} >
                        Seç
                    </button>
                </div>
            </div>
            <div className="opacity-70 fixed inset-0 z-50 bg-[#160E31]  rounded-lg"></div>

            {showRemovePaymentCardModal && <RemovePaymentCardModal showRemovePaymentCardModal={showRemovePaymentCardModal}
                setShowRemovePaymentCardModal={setShowRemovePaymentCardModal} selectedPayment={selectedPayment}
                getPaymentCards={getPaymentCards} setShowChangePaymentCardModal={setShowChangePaymentCardModal} />}
        </>
    )
}

export default ChangePaymentCardModal