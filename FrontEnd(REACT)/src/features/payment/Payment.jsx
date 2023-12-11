import { useEffect, useState } from 'react'
import GetirHeader from '../../components/GetirHeader'
import AddressIcon from 'features/address/AddressIcon'
import { shadowStyle } from 'features/common/Styles'
import { useContext } from 'react'
import { HiPlus } from "react-icons/hi"
import GiftIcon from 'features/payment/GiftIcon'
import { Link, Navigate } from 'react-router-dom'
import CreatePaymentCardModal from 'features/payment/CreatePaymentCardModal'
import ChangePaymentCardModal from 'features/payment/ChangePaymentCardModal'
import { useNavigate } from 'react-router-dom';
import { CartContext } from 'features/cart/CartContext'
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext'
import { AddressContext } from 'features/address/AddressContext'
import { apiService } from 'services/apiService'
import AddressSection from './AddressSection'
import PaymentMethod from './PaymentMethod'
import PaymentSummary from './PaymentSummary'


function Payment() {
    let navigate = useNavigate();

    const { cart, setCart } = useContext(CartContext);
    const { setCommonElementsVisibility, commonElementsVisibility } = useContext(CommonElementsVisibilityContext);
    const { addresses, setAddresses, getCurrentAddress } = useContext(AddressContext);

    const [currentAddress, setCurrentAddress] = useState();
    const [showPaymentCardModal, setShowPaymentCardModal] = useState(false);
    const [showChangePaymentCardModal, setShowChangePaymentCardModal] = useState(false);
    const [selectedPayment, setSelectedPayment] = useState();
    const [paymentCards, setPaymentCards] = useState();

    const [note, setNote] = useState("");
    const [dontRingBell, setDontRingBell] = useState(false);
    const [isIReadIApproved, setIsIReadIApproved] = useState(false);
    const [isHovered, setIsHovered] = useState(false);

    const handleIsIReadIApproved = () => {
        setIsIReadIApproved(!isIReadIApproved);
    }

    const handleMouseEnter = () => {
        setIsHovered(true);
    };

    const handleMouseLeave = () => {
        setIsHovered(false);
    };


    useEffect(() => {
        setCommonElementsVisibility({ ...commonElementsVisibility, header: false, footer: false });
        getPaymentCards()
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


    async function getPaymentCards(customerId = 1) {
        let cards = await apiService.get(`PaymentCard/GetList?customerId=${customerId}`)
        setPaymentCards(cards);
        let activeCard = cards.find(card => card.isPrimary)
        setSelectedPayment(activeCard)
    }

    async function CreateOrder() {



        let obj = {
            DontRingBell: dontRingBell,
            Note: note,
        };

        await apiService.post("Order/CreateOrder", obj)

        setCart([]);
        Navigate("/");
    }

    return (
        <div>
            <GetirHeader widthOfLogo={1024} />
            <div className="flex mt-5 z-10">
                <div className=" md:w-[1024px]   mx-auto flex flex-row gap-x-6">
                    <div className='w-[70%]'>
                        <div className='mb-2'>
                            <span className='text-sm font-semibold text-stone-600'>Adres</span>
                        </div>
                        <AddressSection address={currentAddress} />
                        <div className="text-sm font-semibold text-gray-600 mb-5">
                            Not Ekle
                        </div>
                        <div className='bg-white rounded-md flex flex-row gap-5 p-6' style={shadowStyle}>

                            <textarea name="" id="" className='w-[60%] h-20  border-[2px] rounded-sm resize-none  border-gray-300 p-3 ' placeholder='Sipariş notunu buraya yazabilirsin' value={note} onChange={(e) => setNote(e.target.value)}></textarea>
                            <div className='border-l-[1px] border-gray-200 w-[40%] '>
                                <div className='flex items-center ml-5 '>
                                    <label htmlFor="dontRingBell" className='flex flex-row gap-2'>
                                        <div className='group relative'>
                                            <input type="checkbox" name="dontRingBell" id="dontRingBell" className='absolute  w-full h-full' checked={dontRingBell} onChange={(e) => setDontRingBell(e.target.checked)} />
                                            <svg data-testid="icon" name="check" color="#fff" size="14" version="1.1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" className="relative w-[22px] h-[22px] "><path d="M31.26 4.951c0.987 0.987 0.987 2.586 0 3.573l-18.526 18.526c-0.987 0.987-2.586 0.987-3.573 0l-8.421-8.421c-0.987-0.987-0.987-2.586 0-3.573s2.586-0.987 3.573 0l6.635 6.635 16.74-16.74c0.987-0.987 2.586-0.987 3.573 0z" className="hidden group-checked:block "></path></svg>
                                            <div className=''>
                                            </div>
                                        </div>
                                        <div className='inline-flex'>Zili Çalma</div>
                                    </label>
                                </div>
                            </div>
                        </div>

                        <div className="text-sm font-semibold text-gray-600 my-5">
                            Ödeme Yöntemi
                        </div>
                        <PaymentMethod
                            selectedPayment={selectedPayment}
                            setShowChangePaymentCardModal={setShowChangePaymentCardModal}
                            setShowPaymentCardModal={setShowPaymentCardModal}
                        />

                    </div>
                    <div className='w-[30%]'>
                        <div className='mb-2'>
                            <span className='text-sm font-semibold text-stone-600 text-14px '>Ödeme Özeti</span>
                        </div>
                        <PaymentSummary cart={cart} />

                        <div className='flex flex-row gap-2 py-4 px-5 bg-white mt-6 font-semibold text-14px text-sm text-gray-400 rounded-md' style={shadowStyle}>
                            <div>
                                <label htmlFor="IReadIApprove" className='flex flex-row gap-2'>
                                    <div className='group relative'>
                                        <input type="checkbox" name="IReadIApprove" id="IReadIApprove" className='absolute  w-full h-full' checked={isIReadIApproved}
                                            onChange={handleIsIReadIApproved} />
                                        <svg data-testid="icon" name="check" color="#fff" size="14" version="1.1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" className="relative border-[1px] border-gray-500 w-[22px] h-[22px] "><path d="M31.26 4.951c0.987 0.987 0.987 2.586 0 3.573l-18.526 18.526c-0.987 0.987-2.586 0.987-3.573 0l-8.421-8.421c-0.987-0.987-0.987-2.586 0-3.573s2.586-0.987 3.573 0l6.635 6.635 16.74-16.74c0.987-0.987 2.586-0.987 3.573 0z" className="hidden group-checked:block "></path></svg>
                                    </div>
                                </label>
                            </div>
                            <div><span className='text-primary-brand-color'>Ön Bilgilendirme Formu ve Mesafeli Satış Sözleşmesi</span> ’ni okudum, kabul ediyorum.</div>
                        </div>

                        <div className='mt-6 group'>
                            <div className={`w-full h-[50px] mx-auto mb-2 mt-1    flex border-[0.185rem]  border-primary-brand-color rounded-lg  ${isIReadIApproved && 'group-hover:border-secondary-brand-color'}  `} onMouseEnter={handleMouseEnter}
                                onMouseLeave={handleMouseLeave}>
                                <button onClick={() => CreateOrder()} disabled={!isIReadIApproved || !selectedPayment} className={`w-[70%]  h-full   bg-primary-brand-color text-white flex justify-center items-center  text-sm ${isIReadIApproved && 'group-hover:bg-secondary-brand-color '} transition-all cursor-pointer`} >
                                    <div className='text-14px font-semibold'>Sipariş Ver</div>
                                </button>
                                <div className="w-[30%]  h-full  flex justify-center items-center text-primary-brand-color  text-sm text-14px font-semibold">₺{(cart.totalPrice + cart.deliveryFee + cart.bagPrice).toFixed(2)}</div>
                            </div>
                            <div className={`w-full  bg-slate-600 rounded-sm text-white p-4 text-xs bg-opacity-50  ${(isHovered && !isIReadIApproved) ? 'block' : 'hidden'} `}>
                                <span>
                                    Ön Bilgilendirme Formu ve Mesafeli Satış Sözleşmesi’ni kabul etmelisiniz.
                                </span>
                            </div>
                            <div className={`w-full  bg-slate-600 rounded-sm text-white p-4 text-xs bg-opacity-50  ${(isHovered && (isIReadIApproved && !selectedPayment)) ? 'block' : 'hidden'} `}>
                                <span>
                                    Sipariş vermek için ödeme yöntemi seçmelisiniz.
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            {showPaymentCardModal && <CreatePaymentCardModal showPaymentCardModal={showPaymentCardModal} setShowPaymentCardModal={setShowPaymentCardModal} getPaymentCards={getPaymentCards} setSelectedPayment={setSelectedPayment} setPaymentCards={setPaymentCards} />}
            {showChangePaymentCardModal && <ChangePaymentCardModal showChangePaymentCardModal={showChangePaymentCardModal} setShowChangePaymentCardModal={setShowChangePaymentCardModal}
                showPaymentCardModal={showPaymentCardModal} setShowPaymentCardModal={setShowPaymentCardModal} setSelectedPayment={setSelectedPayment} selectedPayment={selectedPayment} paymentCards={paymentCards}
                getPaymentCards={getPaymentCards}
            />}
        </div>
    )
}

export default Payment;