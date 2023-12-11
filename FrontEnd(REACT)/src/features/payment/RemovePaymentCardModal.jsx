import { apiService } from "services/apiService";

function RemovePaymentCardModal({ showRemovePaymentCardModal, setShowRemovePaymentCardModal, selectedPayment, getPaymentCards, setShowChangePaymentCardModal }) {
    async function RemovePaymentCard(customerId = 1) {
        try {
            await apiService.delete(`PaymentCard/RemoveCard?cartId=${selectedPayment.id}`);
            await getPaymentCards();
            setShowRemovePaymentCardModal(false);
            setShowChangePaymentCardModal(false);
        }
        catch (error) {
            console.log("hata: ", error);
        }
    }

    return (
        <>
            <div className={`justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-[60] outline-none focus:outline-none ${showRemovePaymentCardModal ? 'backdrop-blur-[1px]' : ''}  `} onClick={() => setShowRemovePaymentCardModal(false)}>
                <div className="w-[450px] h-min-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
                    <div className="flex justify-center  text-md text-14px   font-base relative py-8 pb-5 mb-2 " >
                        Kart bilgilerinizi silmek istediğinize emin misiniz?
                    </div>
                    <div className='flex   gap-6 font-semibold text-14px'>
                        <div className='flex-1 cursor-pointer' onClick={() => setShowRemovePaymentCardModal(false)}>
                            <div className='border-[2px] border-primary-brand-color h-9 rounded-lg text-center flex items-center justify-center text-primary-brand-color'>Hayır</div>
                        </div>
                        <div className='flex-1 cursor-pointer'>
                            <div className='border-[2px] bg-primary-brand-color h-9 rounded-lg text-center flex items-center justify-center text-white' onClick={() => RemovePaymentCard()}>Evet</div>
                        </div>
                    </div>
                </div>
            </div>
            <div className=" fixed inset-0 z-50   rounded-lg"></div>

        </>
    )
}

export default RemovePaymentCardModal