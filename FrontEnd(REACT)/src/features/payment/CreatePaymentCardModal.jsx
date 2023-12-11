import { IoMdClose } from 'react-icons/io'
import React, { useState } from 'react'
import "./selectOption.css"
import { apiService } from 'services/apiService';
import axios from 'axios';
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import MonthsList from 'components/MonthList';
import YearsList from 'components/YearsList';

function CreatePaymentCardModal({ showPaymentCardModal, setShowPaymentCardModal, getPaymentCards, setSelectedPayment, setPaymentCards }) {
    const [month, setMonth] = useState(0);
    const [year, setYear] = useState(0);

    async function createPaymentCard(values) {
        let obj = {
            cardNickName: values.cardNickName,
            cardHolderName: values.cardHolderName || "",
            cardNumber: values.cardNumber,
            expiryDate: month + "/" + year,
            paymentMethodId: 1
        }


        try {
            await apiService.post("PaymentCard/CreatePaymentCard", obj);
        }
        catch (error) {
            console.log("hata: ", error);
        }
        finally {
            setShowPaymentCardModal(false)
        }
    }

    const initialValues = {
        cardNickName: '',
        cardNumber: '',
        IReadIApprovePaymentCard: false
    };

    const validationSchema = Yup.object().shape({
        cardNickName: Yup.string().required('Lütfen kart ismi giriniz.'),
        cardNumber: Yup.string().required('Lütfen kart numaranızı giriniz'),
        IReadIApprovePaymentCard: Yup.boolean().required('Kullanım Koşullarını onaylamalısınız.').oneOf([true], 'Kullanım Koşullarını onaylamalısınız.')

    });

    const handleSubmit = async (values, actions) => {
        await createPaymentCard(values);
        await getPaymentCards();
    };

    return (
        <>
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={handleSubmit}>
                {({ values, errors, touched, handleSubmit }) => (
                    <Form>

                        <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-[60] outline-none focus:outline-none " onClick={() => setShowPaymentCardModal(false)}>
                            <div className="w-[450px] h-min-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
                                <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-8 pb-5 mb-2">
                                    Kart Ekle
                                    <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setShowPaymentCardModal(false)}>
                                        <IoMdClose size={18} className="transform scale-[0.]" />
                                    </div>
                                </div>
                                <div className='flex flex-row gap-3 mb-6 mt-3 w-full' >
                                    <div className='px-4 py-6 w-[80px] min-w-20 shrink-0' style={{ "boxShadow": "0px 1px 3px  rgba(105,116,136,0.15)" }}><img src="https://getir.com/_next/static/images/security-5b5d39fe0c41b082a6a16f8fb3f83330.svg" alt="" srcSet="" /></div>
                                    <div className=''>
                                        <div className='text-brand-color font-semibold text-14px'>Güvenlik</div>
                                        <div className='text-xs font-semibold text-gray-400 '>Ödeme altyapımız MasterCard uygulaması olan MasterPass tarafından sağlanmaktadır ve işlem güvenliğin Mastercard güvencesi altındadır.</div>
                                    </div>
                                </div>

                                <div className="grid gap-y-3">
                                    <div className="flex gap-x-2">
                                        <label className="flex-1 relative group  block cursor-pointer">
                                            <Field

                                                className={`${!!errors.cardNickName ? 'border-red-600' : 'border-gray-200'}  h-14 px-4  border-2  rounded w-full transition-colors ${!errors.cardNickName && 'group-hover:border-primary-brand-color focus:border-primary-brand-color'}  outline-none peer text-sm pt-2`}
                                                id="cardNickName" name="cardNickName" />
                                            <span className={`absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7  ${!errors.cardNickName && 'peer-valid:text-primary-brand-color peer-valid:h-7'}  peer-focus:text-primary-brand-color peer-focus:text-xs   peer-valid:text-xs`}>
                                                Karta İsim Ver (Kişisel, iş vb.)

                                            </span>
                                        </label>
                                    </div>
                                    <ErrorMessage name="cardNickName" component="div" className='text-red-600 text-xs my-2 w-full' />
                                    <div className='flex gap-x-2'>

                                        <label className="flex-1 relative group  block cursor-pointer">
                                            <Field

                                                className={`${!!errors.cardNumber ? 'border-red-600' : 'border-gray-200'}   h-14 px-4  border-2  rounded w-full transition-colors ${!errors.cardNumber && 'group-hover:border-primary-brand-color focus:border-primary-brand-color'} outline-none peer text-sm pt-2`}
                                                id="cardNumber" name="cardNumber"
                                            />
                                            <span className={`absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7  ${!errors.cardNumber && 'peer-valid:text-primary-brand-color peer-valid:h-7'}  peer-focus:text-primary-brand-color peer-focus:text-xs  peer-valid:text-xs`} >
                                                Kart Numarası
                                            </span>
                                        </label>
                                    </div>
                                    <ErrorMessage name="cardNumber" component="div" className='text-red-600 text-xs my-2 w-full' />

                                    <div className='font-semibold text-14px text-gray-400'>

                                        Kartın Son Kullanma Tarihi:
                                    </div>
                                    <div className='flex gap-x-4'>

                                        <div className='flex gap-x-2 flex-1'>

                                            <label className="flex-1 relative group  block cursor-pointer">
                                                <select name="" id="" placeholder='Ay' className=' h-14 px-4  border-2 border-gray-200 rounded w-full transition-colors group-hover:border-primary-brand-color focus:border-primary-brand-color outline-none peer text-sm py-2' onChange={(e) => setMonth(e.target.value)}>
                                                    <MonthsList />
                                                </select>
                                            </label>
                                        </div>

                                        <div className='flex gap-x-2 flex-1'>

                                            <label className="flex-1 relative group  block cursor-pointer">
                                                <select name="" id="" placeholder='Ay' className=' h-14 px-4  border-2 border-gray-200 rounded w-full transition-colors group-hover:border-primary-brand-color focus:border-primary-brand-color outline-none peer text-sm py-2 max-h-52' onChange={e => setYear(e.target.value)}>
                                                    <YearsList />
                                                </select>
                                            </label>
                                        </div>
                                    </div>
                                    <div className='pl-1 flex  gap-3 mb-2 mt-2'>
                                        <label htmlFor="IReadIApprovePaymentCard" className='flex flex-row gap-2'>
                                            <div className='group relative'>
                                                <Field type="checkbox" name="IReadIApprovePaymentCard" id="IReadIApprovePaymentCard" className='absolute  w-full h-full' />
                                                <svg data-testid="icon" name="check" color="#fff" size="14" version="1.1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 32 32" className="relative border-[1px] border-gray-500 w-[22px] h-[22px] "><path d="M31.26 4.951c0.987 0.987 0.987 2.586 0 3.573l-18.526 18.526c-0.987 0.987-2.586 0.987-3.573 0l-8.421-8.421c-0.987-0.987-0.987-2.586 0-3.573s2.586-0.987 3.573 0l6.635 6.635 16.74-16.74c0.987-0.987 2.586-0.987 3.573 0z" className="hidden group-checked:block "></path></svg>
                                            </div>
                                        </label>
                                        <div className='font-semibold text-gray-400 text-14px '><span className='text-primary-brand-color'>Kullanım Koşulları</span>'nı okudum, kabul ediyorum.</div>
                                    </div>
                                    <ErrorMessage name="IReadIApprovePaymentCard" component="div" className='text-red-600 text-xs my-2 w-full mb-2' />


                                    <button type='submit' className="bg-primary-brand-color mb-12  text-white transition-colors hover:bg-secondary-brand-color   h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold "  >
                                        Devam
                                    </button>

                                </div>
                                <div className="bg-white w-full h-14 absolute bottom-0 left-0 rounded-lg text-center flex items-center justify-between text-sm text-gray-400 font-semibold px-8 py-8">
                                    <div><img src="https://getir.com/_next/static/images/masterpass-logo-090c084512a1f97fd3c69cac108359c8.svg" alt="" /></div>
                                    <div className='flex gap-2'>
                                        <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjIiIGhlaWdodD0iMjIiIHZpZXdCb3g9IjAgMCAyMiAyMiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0wIDBIMjJWMTEuODc2MlYxNS4wOTJWMjJIMFYxMC44MDQzVjkuMjczVjBaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNNC4yNzA3NSAxNS4zMzAzVjExLjg3NjVINy45Mjc4OEw4LjMyMDM0IDEyLjM4OEw4LjcyNTYzIDExLjg3NjVIMjIuMDAwMVYxNS4wOTIzQzIyLjAwMDEgMTUuMDkyMyAyMS42NTMgMTUuMzI3IDIxLjI1MTUgMTUuMzMwNUgxMy45MDExTDEzLjQ1ODcgMTQuNzg2VjE1LjMzMDVIMTIuMDA5VjE0LjQwMTFDMTIuMDA5IDE0LjQwMTEgMTEuODExIDE0LjUzMDggMTEuMzgyOSAxNC41MzA4SDEwLjg4OTVWMTUuMzMwNUg4LjY5NDU5TDguMzAyNzQgMTQuODA4TDcuOTA0OTEgMTUuMzMwNUw0LjI3MDc1IDE1LjMzMDNaIiBmaWxsPSJ3aGl0ZSIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTAgOS4yNzMwMkwwLjgyNDc1NiA3LjM1MDM0SDIuMjUwOTdMMi43MTg5NiA4LjQyNzM2VjcuMzUwMzRINC40OTE5MUw0Ljc3MDU4IDguMTI4NzhMNS4wNDA2OSA3LjM1MDM0SDEyLjk5OTNWNy43NDE3QzEyLjk5OTMgNy43NDE3IDEzLjQxNzcgNy4zNTAzNCAxNC4xMDUzIDcuMzUwMzRMMTYuNjg3NiA3LjM1OTM5TDE3LjE0NzUgOC40MjIyM1Y3LjM1MDM0SDE4LjYzMTJMMTkuMDM5NSA3Ljk2MDg0VjcuMzUwMzRIMjAuNTM2OVYxMC44MDQzSDE5LjAzOTVMMTguNjQ4MiAxMC4xOTE5VjEwLjgwNDNIMTYuNDY4MkwxNi4yNDkgMTAuMjU5OEgxNS42NjI5TDE1LjQ0NzMgMTAuODA0M0gxMy45NjlDMTMuMzc3MyAxMC44MDQzIDEyLjk5OTIgMTAuNDIwOSAxMi45OTkyIDEwLjQyMDlWMTAuODA0M0gxMC43NzAzTDEwLjMyNzkgMTAuMjU5OFYxMC44MDQzSDIuMDM5NjRMMS44MjA2MiAxMC4yNTk4SDEuMjM2NTJMMS4wMTkwOSAxMC44MDQzSDBWOS4yNzMwMloiIGZpbGw9IndoaXRlIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMS4xMTY2MiA3Ljc3NjEyTDAuMDA0MjcyNDYgMTAuMzYyM0gwLjcyODQzOUwwLjkzMzY1IDkuODQ0NDlIMi4xMjY3OEwyLjMzMTAyIDEwLjM2MjNIMy4wNzExOUwxLjk1OTk1IDcuNzc2MTJIMS4xMTY2MlpNMS41MjgxNCA4LjM3ODA3TDEuODkxODcgOS4yODNIMS4xNjM0M0wxLjUyODE0IDguMzc4MDdaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMy4xNDc3MSAxMC4zNjE3VjcuNzc1NjNMNC4xNzY4MiA3Ljc3OTQyTDQuNzc1NDYgOS40NDY5TDUuMzU5NjggNy43NzU2M0g2LjM4MDQ4VjEwLjM2MTlINS43MzM5M1Y4LjQ1NjE3TDUuMDQ4NjMgMTAuMzYxOUg0LjQ4MTY0TDMuNzk0MjYgOC40NTYxN1YxMC4zNjE5TDMuMTQ3NzEgMTAuMzYxN1oiIGZpbGw9IiMwMTZGRDAiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik02LjgyMyAxMC4zNjE3VjcuNzc1NjNIOC45MzI4VjguMzU0MTFINy40NzYyN1Y4Ljc5NjQzSDguODk4ODJWOS4zNDA5M0g3LjQ3NjI3VjkuODAwMzZIOC45MzI4VjEwLjM2MTdINi44MjNaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNOS4zMDcxMyA3Ljc3NjEyVjEwLjM2MjNIOS45NTM2OFY5LjQ0MzZIMTAuMjI2TDExLjAwMTEgMTAuMzYyM0gxMS43OTEzTDEwLjk0MDUgOS40MDk1QzExLjI4OTYgOS4zODAwNSAxMS42NDk4IDkuMDgwMzYgMTEuNjQ5OCA4LjYxNTE4QzExLjY0OTggOC4wNzA5MiAxMS4yMjI2IDcuNzc2MTIgMTAuNzQ1OCA3Ljc3NjEySDkuMzA3MTNaTTkuOTUzNjggOC4zNTQ2SDEwLjY5MjhDMTAuODcwMSA4LjM1NDYgMTAuOTk5MSA4LjQ5MzMyIDEwLjk5OTEgOC42MjY3OUMxMC45OTkxIDguNzk4NjQgMTAuODMyIDguODk4OTggMTAuNzAyNCA4Ljg5ODk4SDkuOTUzNjhWOC4zNTQ2WiIgZmlsbD0iIzAxNkZEMCIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTEyLjU3MzkgMTAuMzYxN0gxMS45MTM4VjcuNzc1NjNIMTIuNTczOVYxMC4zNjE3WiIgZmlsbD0iIzAxNkZEMCIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTE0LjEzOTIgMTAuMzYxOUgxMy45OTY3QzEzLjMwNzMgMTAuMzYxOSAxMi44ODg3IDkuODE4NyAxMi44ODg3IDkuMDc5MzhDMTIuODg4NyA4LjMyMTg1IDEzLjMwMjYgNy43NzU2MyAxNC4xNzMyIDcuNzc1NjNIMTQuODg3OVY4LjM4ODA5SDE0LjE0NzJDMTMuNzkzNyA4LjM4ODA5IDEzLjU0MzggOC42NjM5NCAxMy41NDM4IDkuMDg1NzNDMTMuNTQzOCA5LjU4NjYgMTMuODI5NyA5Ljc5Njk0IDE0LjI0MTQgOS43OTY5NEgxNC40MTE2TDE0LjEzOTIgMTAuMzYxOVoiIGZpbGw9IiMwMTZGRDAiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xNS41NDYyIDcuNzc2MTJMMTQuNDMzOCAxMC4zNjIzSDE1LjE1OEwxNS4zNjMzIDkuODQ0NDlIMTYuNTU2NUwxNi43NjA3IDEwLjM2MjNIMTcuNTAwOUwxNi4zODk2IDcuNzc2MTJIMTUuNTQ2MlpNMTUuOTU3NyA4LjM3ODA3TDE2LjMyMTQgOS4yODNIMTUuNTkzTDE1Ljk1NzcgOC4zNzgwN1oiIGZpbGw9IiMwMTZGRDAiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xNy41NzYyIDEwLjM2MTdWNy43NzU2M0gxOC4zOTgyTDE5LjQ0NzkgOS40MDA0NVY3Ljc3NTYzSDIwLjA5NDRWMTAuMzYxN0gxOS4yOTg5TDE4LjIyMjcgOC42OTQzOFYxMC4zNjE3SDE3LjU3NjJaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNNC43MTMxMyAxNC44ODgxVjEyLjMwMThINi44MjI5M1YxMi44ODA0SDUuMzY2NDFWMTMuMzIyN0g2Ljc4ODgzVjEzLjg2NzJINS4zNjY0MVYxNC4zMjY2SDYuODIyOTNWMTQuODg4MUg0LjcxMzEzWiIgZmlsbD0iIzAxNkZEMCIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTE1LjA1MTEgMTQuODg4MVYxMi4zMDE4SDE3LjE2MTFWMTIuODgwNEgxNS43MDQ1VjEzLjMyMjdIMTcuMTIwM1YxMy44NjcySDE1LjcwNDVWMTQuMzI2NkgxNy4xNjExVjE0Ljg4ODFIMTUuMDUxMVoiIGZpbGw9IiMwMTZGRDAiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik02LjkwNDgyIDE0Ljg4OEw3LjkzMjA5IDEzLjYxMDhMNi44ODAzNyAxMi4zMDE4SDcuNjk0ODZMOC4zMjEyNSAxMy4xMTFMOC45NDk3MiAxMi4zMDE4SDkuNzMyNDNMOC42OTQ1MiAxMy41OTQ5TDkuNzIzNjMgMTQuODg4SDguOTA5MjZMOC4zMDEwOCAxNC4wOTE1TDcuNzA3NjkgMTQuODg4SDYuOTA0ODJaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNOS44MDA1NCAxMi4zMDJWMTQuODg4MkgxMC40NjQxVjE0LjA3MTVIMTEuMTQ0NkMxMS43MjA1IDE0LjA3MTUgMTIuMTU3IDEzLjc2NiAxMi4xNTcgMTMuMTcyQzEyLjE1NyAxMi42Nzk4IDExLjgxNDYgMTIuMzAyMSAxMS4yMjg2IDEyLjMwMjFIOS44MDA1NFYxMi4zMDJaTTEwLjQ2NDEgMTIuODg3SDExLjE4MDhDMTEuMzY2OCAxMi44ODcgMTEuNDk5OCAxMy4wMDEgMTEuNDk5OCAxMy4xODQ3QzExLjQ5OTggMTMuMzU3MyAxMS4zNjc0IDEzLjQ4MjQgMTEuMTc4NiAxMy40ODI0SDEwLjQ2NFYxMi44ODdIMTAuNDY0MVoiIGZpbGw9IiMwMTZGRDAiLz4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0xMi40Mzc3IDEyLjMwMTZWMTQuODg3OUgxMy4wODQzVjEzLjk2OTFIMTMuMzU2NUwxNC4xMzE3IDE0Ljg4NzlIMTQuOTIxOUwxNC4wNzEyIDEzLjkzNUMxNC40MjA0IDEzLjkwNTYgMTQuNzgwNSAxMy42MDU5IDE0Ljc4MDUgMTMuMTQwNkMxNC43ODA1IDEyLjU5NjMgMTQuMzUzMyAxMi4zMDE1IDEzLjg3NjUgMTIuMzAxNUwxMi40Mzc3IDEyLjMwMTZaTTEzLjA4NDMgMTIuODgwMkgxMy44MjM0QzE0LjAwMDcgMTIuODgwMiAxNC4xMjk3IDEzLjAxOSAxNC4xMjk3IDEzLjE1MjRDMTQuMTI5NyAxMy4zMjQzIDEzLjk2MjYgMTMuNDI0NyAxMy44MzI5IDEzLjQyNDdIMTMuMDg0M1YxMi44ODAyWiIgZmlsbD0iIzAxNkZEMCIvPgo8cGF0aCBmaWxsLXJ1bGU9ImV2ZW5vZGQiIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTE3LjQ2MDQgMTQuODg4VjE0LjMyNjVIMTguNzU0NEMxOC45NDU5IDE0LjMyNjUgMTkuMDI4OCAxNC4yMjMxIDE5LjAyODggMTQuMTA5NUMxOS4wMjg4IDE0LjAwMDggMTguOTQ2MiAxMy44OTA5IDE4Ljc1NDQgMTMuODkwOUgxOC4xNjk3QzE3LjY2MTUgMTMuODkwOSAxNy4zNzgzIDEzLjU4MTIgMTcuMzc4MyAxMy4xMTY0QzE3LjM3ODMgMTIuNzAxNyAxNy42Mzc1IDEyLjMwMTggMTguMzkyNyAxMi4zMDE4SDE5LjY1MTlMMTkuMzc5NyAxMi44ODM3SDE4LjI5MDhDMTguMDgyNyAxMi44ODM3IDE4LjAxODYgMTIuOTkyOSAxOC4wMTg2IDEzLjA5NzJDMTguMDE4NiAxMy4yMDQ0IDE4LjA5NzggMTMuMzIyNiAxOC4yNTY4IDEzLjMyMjZIMTguODY5NEMxOS40MzYgMTMuMzIyNiAxOS42ODE4IDEzLjY0NCAxOS42ODE4IDE0LjA2NDhDMTkuNjgxOCAxNC41MTczIDE5LjQwNzkgMTQuODg3OSAxOC44Mzg1IDE0Ljg4NzlMMTcuNDYwNCAxNC44ODhaIiBmaWxsPSIjMDE2RkQwIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMTkuODMzNSAxNC44ODhWMTQuMzI2NUgyMS4wNzI3QzIxLjI2NDIgMTQuMzI2NSAyMS4zNDcxIDE0LjIyMzEgMjEuMzQ3MSAxNC4xMDk1QzIxLjM0NzEgMTQuMDAwOCAyMS4yNjQ1IDEzLjg5MDkgMjEuMDcyNyAxMy44OTA5SDIwLjU0MjdDMjAuMDM0NSAxMy44OTA5IDE5Ljc1MTMgMTMuNTgxMiAxOS43NTEzIDEzLjExNjRDMTkuNzUxMyAxMi43MDE3IDIwLjAxMDYgMTIuMzAxOCAyMC43NjU4IDEyLjMwMThIMjJMMjEuNzI3OCAxMi44ODM3SDIwLjY2MzlDMjAuNDU1NyAxMi44ODM3IDIwLjM5MTcgMTIuOTkyOSAyMC4zOTE3IDEzLjA5NzJDMjAuMzkxNyAxMy4yMDQ0IDIwLjQ3MDkgMTMuMzIyNiAyMC42Mjk5IDEzLjMyMjZIMjEuMTg3NkMyMS43NTQyIDEzLjMyMjYgMjIuMDAwMSAxMy42NDQgMjIuMDAwMSAxNC4wNjQ4QzIyLjAwMDEgMTQuNTE3MyAyMS43MjYxIDE0Ljg4NzkgMjEuMTU2OCAxNC44ODc5TDE5LjgzMzUgMTQuODg4WiIgZmlsbD0iIzAxNkZEMCIvPgo8L3N2Zz4K" alt="" />
                                        <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjgiIGhlaWdodD0iMTgiIHZpZXdCb3g9IjAgMCAyOCAxOCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTE1LjQ1NTMgMy4zMDIzM0MxNS4wMjg1IDIuNzYxMzggMTQuNTM5NiAyLjI3MjQ4IDEzLjk5ODcgMS44NDU3QzEyLjk2ODggMi42NTU0MyAxMi4xMzYzIDMuNjg4NDEgMTEuNTYzOCA0Ljg2Njc2QzEwLjk5MTMgNi4wNDUxMSAxMC42OTM4IDcuMzM4MDcgMTAuNjkzOCA4LjY0ODEyQzEwLjY5MzggOS45NTgxNyAxMC45OTEzIDExLjI1MTEgMTEuNTYzOCAxMi40Mjk1QzEyLjEzNjMgMTMuNjA3OCAxMi45Njg4IDE0LjY0MDggMTMuOTk4NyAxNS40NTA1QzE1LjgwMjQgMTQuMDMyNSAxNi45NjkxIDExLjk1NjEgMTcuMjQyMyA5LjY3ODAzQzE3LjUxNTQgNy4zOTk5MyAxNi44NzI2IDUuMTA2NjEgMTUuNDU1MyAzLjMwMjMzWiIgZmlsbD0iI0ZGNUYwMSIvPgo8cGF0aCBkPSJNMTAuNjkzNiA4LjY0ODQ1QzEwLjY5MjkgNy4zMzg2IDEwLjk5MDEgNi4wNDU3NCAxMS41NjI3IDQuODY3NjdDMTIuMTM1MyAzLjY4OTYgMTIuOTY4MyAyLjY1NzE2IDEzLjk5ODYgMS44NDg0M0MxMi43MjIgMC44NDU1OCAxMS4xODg5IDAuMjIyMDkgOS41NzQ3MyAwLjA0OTIwODlDNy45NjA1MiAtMC4xMjM2NzIgNi4zMzAyMiAwLjE2MTAzMSA0Ljg3MDE0IDAuODcwNzg0QzMuNDEwMDcgMS41ODA1NCAyLjE3OTEgMi42ODY3MSAxLjMxNzg5IDQuMDYyOTFDMC40NTY2OTMgNS40MzkxIDAgNy4wMjk4MSAwIDguNjUzMjVDMCAxMC4yNzY3IDAuNDU2NjkzIDExLjg2NzQgMS4zMTc4OSAxMy4yNDM2QzIuMTc5MSAxNC42MTk4IDMuNDEwMDcgMTUuNzI2IDQuODcwMTQgMTYuNDM1N0M2LjMzMDIyIDE3LjE0NTUgNy45NjA1MiAxNy40MzAyIDkuNTc0NzMgMTcuMjU3M0MxMS4xODg5IDE3LjA4NDQgMTIuNzIyIDE2LjQ2MDkgMTMuOTk4NiAxNS40NTgxQzEyLjk2NjcgMTQuNjQ4NiAxMi4xMzI4IDEzLjYxNDcgMTEuNTYwMSAxMi40MzQ3QzEwLjk4NzQgMTEuMjU0OCAxMC42OTExIDkuOTU5OTggMTAuNjkzNiA4LjY0ODQ1WiIgZmlsbD0iI0VBMDAxQiIvPgo8cGF0aCBkPSJNMjYuMTQ5MiAzLjMwMDM4QzI0LjcyOSAxLjQ5ODEyIDIyLjY1MTEgMC4zMzM3MzUgMjAuMzcyNSAwLjA2MzI3OTZDMTguMDkzOSAtMC4yMDcxNzYgMTUuODAxMiAwLjQzODQ0OSAxMy45OTg2IDEuODU4MTdDMTQuNTM5NSAyLjI4NDk0IDE1LjAyODQgMi43NzM4NCAxNS40NTUyIDMuMzE0OEMxNi4xNTc0IDQuMjA4MjYgMTYuNjc2NyA1LjIzMTI4IDE2Ljk4MzUgNi4zMjU0NEMxNy4yOTAzIDcuNDE5NjEgMTcuMzc4NiA4LjU2MzQ5IDE3LjI0MzQgOS42OTE3OEMxNy4xMDgxIDEwLjgyMDEgMTYuNzUxOSAxMS45MTA3IDE2LjE5NTIgMTIuOTAxM0MxNS42Mzg0IDEzLjg5MTkgMTQuODkyIDE0Ljc2MzIgMTMuOTk4NiAxNS40NjU0QzE1LjI3NiAxNi40Njk3IDE2LjgxMDQgMTcuMDk0MSAxOC40MjYyIDE3LjI2NjlDMjAuMDQxOSAxNy40Mzk4IDIxLjY3MzcgMTcuMTU0MiAyMy4xMzQ3IDE2LjQ0MjlDMjQuNTk1NyAxNS43MzE2IDI1LjgyNjkgMTQuNjIzMyAyNi42ODczIDEzLjI0NDlDMjcuNTQ3NyAxMS44NjY0IDI4LjAwMjcgMTAuMjczNSAyOCA4LjY0ODU3QzI3Ljk5ODggNi43MDg5NyAyNy4zNDcxIDQuODI1ODEgMjYuMTQ5MiAzLjMwMDM4WiIgZmlsbD0iI0Y3OUUxQyIvPgo8L3N2Zz4K" alt="" />
                                        <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzQiIGhlaWdodD0iMTEiIHZpZXdCb3g9IjAgMCAzNCAxMSIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTEyLjkwNzQgMC4xOTM2MTFMOC40NTc1MyAxMC44MTM5SDUuNTUzMzZMMy4zNjIyNSAyLjMzOTA3QzMuMjMwMDMgMS44MTY0OCAzLjExNTEyIDEuNjI2MDIgMi43MTA1OSAxLjQwNTY1QzIuMDQ2MzMgMS4wNDY3NiAwLjk1ODY0MiAwLjcxMTQ4MSAzLjA1MTc2ZS0wNSAwLjUwMjEzTDAuMDY0NTY3NiAwLjE4NzMxNUg0LjczOTU3QzUuMDQzODggMC4xODg4ODIgNS4zMzc3IDAuMjk4NzA4IDUuNTY4NDMgMC40OTcxMzRDNS43OTkxNSAwLjY5NTU2IDUuOTUxNzMgMC45Njk2MjkgNS45OTg4MyAxLjI3MDI4TDcuMTU1NzcgNy40MTcwNEwxMC4wMjM3IDAuMTkzNjExSDEyLjkwNzRaTTI0LjI4OCA3LjM0NjJDMjQuMzAwNiA0LjU0NDM1IDIwLjQxMjYgNC4zOTAwOSAyMC40Mzk0IDMuMTM3MTNDMjAuNDQ3MyAyLjc1NjIgMjAuODEwOSAyLjM1MDA5IDIxLjYwNDIgMi4yNDc3OEMyMi41MzMzIDIuMTU4MDMgMjMuNDY5MyAyLjMyMTIgMjQuMzEzMiAyLjcyTDI0Ljc5NjQgMC40NzIyMjJDMjMuOTc0MyAwLjE2MzgxMyAyMy4xMDQgMC4wMDM5MjExNyAyMi4yMjYgMEMxOS41MTg1IDAgMTcuNTk4MiAxLjQ0MzQzIDE3LjU4MjQgMy41MTAxOUMxNy41NjUxIDUuMDM3MDQgMTguOTQ3MiA1Ljg5MTc2IDE5Ljk5MDggNi40MDE3NkMyMS4wNTk2IDYuOTIxMiAyMS40MTg1IDcuMjU0OTEgMjEuNDA3NCA3LjcyMDgzQzIxLjQwNzQgOC40MzM4OSAyMC41NTI3IDguNzQ3MTMgMTkuNzYyNSA4Ljc1OTcyQzE4LjM4MjEgOC43ODE3NiAxNy41NzkzIDguMzg2NjcgMTYuOTQwMiA4LjA4OTE3TDE2LjQ0OTEgMTAuNDE1NkMxNy4wOTEzIDEwLjcxMTYgMTguMjc2NiAxMC45NjgxIDE5LjUwNDQgMTAuOTgwN0MyMi4zOTEyIDEwLjk4MDcgMjQuMjc4NSA5LjU1NDYzIDI0LjI4OCA3LjM0NjJaTTMxLjQ1OTUgMTAuODA5MkgzNEwzMS43ODIyIDAuMTkzNjExSDI5LjQzNTJDMjkuMTg0OSAwLjE5MjU0MSAyOC45NCAwLjI2NjA5MyAyOC43MzE2IDAuNDA0ODc1QzI4LjUyMzMgMC41NDM2NTcgMjguMzYxMSAwLjc0MTM3MiAyOC4yNjU3IDAuOTcyNzc4TDI0LjE0NDggMTAuODEzOUgyNy4wM0wyNy42MDMgOS4yMjcyMkgzMS4xMjczTDMxLjQ1OTUgMTAuODA5MlpNMjguMzkzMiA3LjA1MTg1TDI5LjgzOTggMy4wNjMxNUwzMC42NzI0IDcuMDUxODVIMjguMzkzMlpNMTYuODQyNiAwLjE5MzYxMUwxNC41NjM0IDEwLjgxMzlIMTEuODE1TDE0LjA4OCAwLjE5MzYxMUgxNi44NDI2WiIgZmlsbD0idXJsKCNwYWludDBfbGluZWFyKSIvPgo8ZGVmcz4KPGxpbmVhckdyYWRpZW50IGlkPSJwYWludDBfbGluZWFyIiB4MT0iMy4wNTE3NmUtMDUiIHkxPSI1LjQ5MDM3IiB4Mj0iMzQiIHkyPSI1LjQ5MDM3IiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSI+CjxzdG9wIHN0b3AtY29sb3I9IiMyMzFGNUMiLz4KPHN0b3Agb2Zmc2V0PSIxIiBzdG9wLWNvbG9yPSIjMDM0RUEyIi8+CjwvbGluZWFyR3JhZGllbnQ+CjwvZGVmcz4KPC9zdmc+Cg==" alt="" />
                                        <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzQiIGhlaWdodD0iMTYiIHZpZXdCb3g9IjAgMCAzNCAxNiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZmlsbC1ydWxlPSJldmVub2RkIiBjbGlwLXJ1bGU9ImV2ZW5vZGQiIGQ9Ik0zMS4xNjI5IDIuNTAzNDJDMzAuNjg4OCAyLjUwMzQyIDMwLjE2NTkgMi43NjYyMyAyOS45NTc0IDMuMjM4NDFMMjcuNzQxMyA4LjI4ODgxTDI2Ljk0MzEgMy4yMzg0MUMyNi44NDkyIDIuNzY2MjMgMjYuNTI2NiAyLjUwMzQyIDI2LjAxNTggMi41MDM0MkgyMy4yMDg0TDI1LjYwOTYgMTAuODkxQzI1LjY1MzggMTEuMDUxOCAyNS42NjIyIDExLjIzMDIgMjUuNjI5OCAxMS40MTc4QzI1LjUwNDIgMTIuMTE3NyAyNC44MzE3IDEyLjY4NTUgMjQuMTI3NCAxMi42ODU1SDIyLjU1NTJDMjIuMTU2IDEyLjY4NTUgMjEuODkzMSAxMi45MzE0IDIxLjc2NDUgMTMuNDg4TDIxLjQxNTMgMTUuNTY2NkgyNC4xODRDMjUuNjI4NCAxNS41NjY2IDI3LjMyNDcgMTQuODQ1MSAyOC40NTYzIDEyLjg1MDFMMzQuMDAwMSAyLjUwMzQySDMxLjE2MjlaIiBmaWxsPSIjMzIzRTQ4Ii8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMy45MDk1MSAwQzQuNzM4NjEgMCA1LjEzOTI5IDAuMzI4ODY3IDQuOTkzNCAxLjE1NTE5TDQuNzU0NSAyLjUwMTM4SDYuNjU5NDFMNi4yMzk2NiA0Ljg2NjMySDQuMzMzODhMMy44MTQ3NSA3Ljc5NDQ3QzMuNjM1MzQgOC44MTQ2NyA0LjY1MTA3IDguOTUwNTMgNS4yMzM3NiA4Ljk1MDUzQzUuMzQ5ODggOC45NTA1MyA1LjQ0NjM3IDguOTQ3OTQgNS41MTU0MiA4Ljk0MzkyTDUuMDQ5NDUgMTEuNTgxMUM0LjkwNTU5IDExLjU5NjQgNC43NTczOSAxMS42MTYyIDQuNDQzNjYgMTEuNjE2MkMyLjk5NzQ4IDExLjYxNjIgMC4yNjE3MzQgMTEuMjMxIDAuNzk5NjM5IDguMTk2ODdMMS4zODg2OCA0Ljg2NjMySDBMMC40MTgwMDggMi41MDEzOEgxLjc5MzExTDIuMjM1NyAwSDMuOTA5NTFaIiBmaWxsPSIjMzIzRTQ4Ii8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMTkuOTE2OCAyLjYwOTM4TDE5LjQyNzQgNS4zNjY2NUMyMC4wMzA5IDUuNjczMTIgMjAuNDQ0MyA2LjI5NTUxIDIwLjQ0NDMgNy4wMTQ0MUMyMC40NDQzIDcuOTYyMjMgMTkuNzI5NiA4LjczODg2IDE4LjgwOTUgOC44NTA1OUwxOC4zMjA0IDExLjYwNzNDMTguNDA2OCAxMS42MTI3IDE4LjQ5NDYgMTEuNjE1NiAxOC41ODIxIDExLjYxNTZDMjEuMTM5NyAxMS42MTU2IDIzLjIxMSA5LjU1NDg0IDIzLjIxMSA3LjAxNDQxQzIzLjIxMSA0LjkzNzI3IDIxLjgyMzggMy4xNzk3OSAxOS45MTY4IDIuNjA5MzhaIiBmaWxsPSIjMDBBREJCIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNMTcuNzM4NCA4LjY2MzIyQzE3LjEzNTUgOC4zNTg0OSAxNi43MjEyIDcuNzMzMjIgMTYuNzIxMiA3LjAxNTE4QzE2LjcyMTIgNi4wNzMzOSAxNy40Mzc0IDUuMjkwNzQgMTguMzU3MiA1LjE4MTAyTDE4Ljg0NTcgMi40MjQwM0MxOC43NTg4IDIuNDE4NTggMTguNjcwMyAyLjQxNDU1IDE4LjU4MzQgMi40MTQ1NUMxNi4wMjc5IDIuNDE0NTUgMTMuOTU1NCA0LjQ3Njc2IDEzLjk1NTQgNy4wMTUxOEMxMy45NTU0IDkuMDkzMTkgMTUuMzQzMyAxMC44NTE4IDE3LjI1MDIgMTEuNDIyMkwxNy43Mzg0IDguNjYzMjJaIiBmaWxsPSIjMDBBREJCIi8+CjxwYXRoIGZpbGwtcnVsZT0iZXZlbm9kZCIgY2xpcC1ydWxlPSJldmVub2RkIiBkPSJNNy43NjIzMyAyLjUwMzQ3SDkuMzk5MTVDMTAuMjI4NiAyLjUwMzQ3IDEwLjYyNzUgMi44MzI5MiAxMC40ODEzIDMuNjU5NTJMMTAuMzAyMiA0LjY1OTYxQzEwLjkxMjEgMy40Mjg4OSAxMi4yMzQ5IDIuNDEzNTcgMTMuNTkxOCAyLjQxMzU3QzEzLjc2OTcgMi40MTM1NyAxMy45NDEgMi40NDg2MiAxMy45NDEgMi40NDg2MkwxMy40MTIxIDUuNDMwNDlDMTMuNDEyMSA1LjQzMDQ5IDEzLjE3NDYgNS4zNzU2MyAxMi44MDQgNS4zNzU2M0MxMi4wODA5IDUuMzc1NjMgMTAuODU4IDUuNjAzNjggMTAuMTc3NCA2Ljk1NDQ2QzEwLjAxNTEgNy4yODczNCA5Ljg5MDI2IDcuNjkyMzIgOS44MDM4OCA4LjE4MDNMOS4yMTE2NyAxMS41MzA0SDYuMTYyNDhMNy43NjIzMyAyLjUwMzQ3WiIgZmlsbD0iIzMyM0U0OCIvPgo8L3N2Zz4K" alt="" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="opacity-70 fixed inset-0 z-50 bg-[#160E31]  rounded-lg"></div>
                    </Form>
                )}
            </Formik>

        </>
    )
}

export default CreatePaymentCardModal