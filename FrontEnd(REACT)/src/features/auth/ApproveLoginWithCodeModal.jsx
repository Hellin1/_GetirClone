import React, { useState } from 'react'
import { useContext } from 'react'
import * as Yup from "yup";
import { Field, Formik, Form, ErrorMessage } from "formik"
import { AuthContext } from './AuthContext';
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext';
import { IoMdClose } from 'react-icons/io';

function ApproveLoginWithCodeModal() {
    const { HandleLogin, isAuthenticated, ApproveLogin } = useContext(AuthContext);
    const { commonElementsVisibility, setCommonElementsVisibility } = useContext(CommonElementsVisibilityContext);
    const [code, setCode] = useState({ value: 0 });
    const [isCodeFailed, setIsCodeFailed] = useState(false);

    const initialValues = {
        code: ""
    };

    const validationSchema = Yup.object().shape({
        code: Yup.string()
            .matches(/^\d{4}$/, 'Lütfen geçerli bir kod giriniz.')
            .required('Tek kullanımlık şifreyi giriniz.'),

    });

    const ReRequestLogin = () => {
        setIsCodeFailed(false);
        RequestLogin();
    }

    const RequestLogin = () => {
        let phoneNumber = document.getElementById("phoneNumber").value;
        HandleLogin(phoneNumber);
    }

    const HandleSubmit = async (values, actions) => {
        await AprroveLogin(values.code)
    };



    async function AprroveLogin(code) {
        let phoneNumber = document.getElementById("phoneNumber").value;
        let result = await ApproveLogin({ code, phoneNumber })
        if (result == -1) {
            setIsCodeFailed(true);
        }
        else if (result) {
            setCommonElementsVisibility({ ...commonElementsVisibility, loginModal: false, approveLoginWithCodeModal: false })
        }
    }


    return (
        <>
            <Formik
                initialValues={initialValues}
                validationSchema={validationSchema}
                onSubmit={HandleSubmit}>
                {({ values, errors, touched, HandleSubmit }) => (
                    <Form>
                        <div className="justify-around items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none " onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, approveLoginWithCodeModal: false })}>
                            <div className="w-[450px] h-[380px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
                                <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-6 mb-4">
                                    Tek kullanımlık şifre
                                    <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, approveLoginWithCodeModal: false })}>
                                        <IoMdClose size={18} className="transform scale-[0.]" />
                                    </div>
                                </div>
                                <div>
                                    Lütfen {document.getElementById("phoneNumber").value} numaralı telefonuna gönderilen tek kullanımlık şifreyi gir
                                </div>
                                <div className="flex flex-col justify-betwen">
                                    <div className="flex">
                                        <label className="flex-1 relative group  block cursor-pointer">
                                            <Field
                                                required id="code" name="code" maxLength="4" type="number" max="9999"
                                                className={`h-14 px-4  border-2 ${!!errors.code ? 'border-red-600' : 'border-gray-200  group-hover:border-primary-brand-color focus:border-primary-brand-color'}   rounded w-full transition-colors  outline-none peer text-sm pt-2`}
                                            />
                                        </label>
                                    </div>
                                    <ErrorMessage name="code" component="div" className='text-red-600 text-xs text-center my-5' />
                                    {(!errors.code && isCodeFailed) && <div className='text-red-600 text-xs text-center my-5'>Lütfen girdiğin aktivasyon kodunu kontrol et.</div>}
                                    <button type='submit' className="mt-2 bg-brand-yellow text-primary-brand-color transition-colors hover:bg-primary-brand-color hover:text-brand-yellow  h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold "
                                    >
                                        Onayla ve giriş yap
                                    </button>

                                </div>
                                <div className="bg-gray-100 w-full h-11 absolute bottom-0 left-0 rounded-lg text-center flex items-center justify-center text-sm text-gray-500 font-semibold">Şifre gelmedi mi?<button onClick={() => ReRequestLogin()} className="text-primary-brand-color">Tek kullanımlık şifreyi tekrar gönder</button></div>
                            </div>
                        </div>
                        <div className="opacity-25 fixed inset-0 z-40 bg-black rounded-lg"></div>
                    </Form>)}</Formik>
        </>
    )
}

export default ApproveLoginWithCodeModal