import React, { useState } from 'react'
import { IoMdClose } from "react-icons/io"
import ReactFlagsSelect from "react-flags-select"
import { AuthContext } from './AuthContext'
import { useContext } from 'react'
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext'
import * as Yup from "yup";
import { Field, Formik, Form, ErrorMessage } from "formik"


function LoginModal() {
  const [selected, setSelected] = useState("TR");
  const { HandleLogin, isAuthenticated, ApproveLogin } = useContext(AuthContext);
  const { commonElementsVisibility, setCommonElementsVisibility } = useContext(CommonElementsVisibilityContext);

  const phoneNmbrCountryCodes = {
    US: "+1",
    DE: "+50",
    TR: "+90",
    IT: "+7",
    IN: "+15",
  }


  const initialValues = {
    phoneNumber: ""
  };

  const validationSchema = Yup.object().shape({
    phoneNumber: Yup.string()
      .matches(/^\d{10}$/, 'Lütfen geçerli bir telefon numarası giriniz.')
      .required('Lütfen telefon numaranızı giriniz.'),

  });

  const handleSubmit = async (values, actions) => {
    await HanldeLogin(values.phoneNumber)
  };

  async function HanldeLogin(phoneNumber) {
    let isFailed = await HandleLogin(phoneNumber)
    if (isFailed) {
      setCommonElementsVisibility({ ...commonElementsVisibility, loginModal: false, registerModal: true })
    }
    else{
      setCommonElementsVisibility({ ...commonElementsVisibility, approveLoginWithCodeModal: true })
    }
  }


  return (
    <>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}>
        {({ values, errors, touched, handleSubmit }) => (
          <Form>
            <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none " onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, loginModal: false })}>
              <div className="w-[450px] h-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
                <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-6 mb-4">
                  Giriş yap veya kayıt ol
                  <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, loginModal: false })}>
                    <IoMdClose size={18} className="transform scale-[0.]" />
                  </div>
                </div>
                <div className="grid gap-y-3">
                  <div className="flex gap-x-2">
                    <ReactFlagsSelect
                      countries={Object.keys(phoneNmbrCountryCodes)}
                      customLabels={phoneNmbrCountryCodes}
                      onSelect={(code) => setSelected(code)}
                      selected={selected}
                      className="flag-select"
                    />
                    <label className="flex-1 relative group  block cursor-pointer">
                      <Field
                        required id="phoneNumber" name="phoneNumber" maxLength="10"
                        className={`h-14 px-4  border-2 ${!!errors.phoneNumber ? 'border-red-600' : 'border-gray-200  group-hover:border-primary-brand-color focus:border-primary-brand-color'}   rounded w-full transition-colors  outline-none peer text-sm pt-2`}
                      />
                      <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                        Telefon Numarası
                      </span>
                    </label>
                  </div>
                  <ErrorMessage name="phoneNumber" component="div" className='text-red-600 text-xs my-1 w-[63%]  ml-auto' />
                  <button type='submit' className="bg-brand-yellow text-primary-brand-color transition-colors hover:bg-primary-brand-color hover:text-brand-yellow  h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold "
                  >
                    Telefon numarası ile devam et
                  </button>

                </div>
                <div className="text-xs text-gray-400 font-medium  py-3">
                  Kişisel verilerinize dair Aydınlatma Metni için <a href="" className="text-primary-brand-color font-semibold underline">tıklayınız</a>
                </div>
                <div className="bg-gray-100 w-full h-11 absolute bottom-0 left-0 rounded-lg text-center flex items-center justify-center text-sm text-gray-500 font-semibold">Hala kayıt olmadınız mı? &nbsp;<a className="text-primary-brand-color">Kayıt Ol</a></div>
              </div>
            </div>
            <div className="opacity-25 fixed inset-0 z-40 bg-black rounded-lg"></div>
          </Form>)}</Formik>
    </>
  )
}

export default LoginModal;