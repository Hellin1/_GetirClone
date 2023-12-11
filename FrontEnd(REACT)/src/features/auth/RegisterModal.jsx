import { IoMdClose } from 'react-icons/io'
import React, { useContext, useState } from 'react'
import ReactFlagsSelect from "react-flags-select"
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext'
import * as Yup from "yup";
import { Field, Formik, Form, ErrorMessage } from "formik"
import { AuthContext } from './AuthContext';

function RegisterModal() {
  const [selected, setSelected] = useState("TR")
  const { commonElementsVisibility, setCommonElementsVisibility } = useContext(CommonElementsVisibilityContext);
  const { HandleRegister } = useContext(AuthContext)


  const phoneNmbrCountryCodes = {
    US: "+1",
    DE: "+50",
    TR: "+90",
    IT: "+7",
    IN: "+15",
  }

  const initialValues = {
    phoneNumber: "",
    fullName: "",
    email: ""
  };

  const validationSchema = Yup.object().shape({
    phoneNumber: Yup.string().matches(/^\d{10}$/, 'Lütfen geçerli bir telefon numarası giriniz.').required('Lütfen telefon numaranızı giriniz.'),
    email: Yup.string().email('Lütfen geçerli bir email adresi giriniz.').required('Lütfen email adresinizi giriniz.'),
    fullName: Yup.string().required("Lütfen ad ve soyadınızı giriniz.")
  });

  const handleSubmit = async (values, actions) => {
    let isFailed = await HandleRegister(values);
    if (!isFailed) {
      setCommonElementsVisibility({ ...commonElementsVisibility, registerModal: false })
    }
  };

  return (
    <>
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}>
        {({ values, errors, touched, handleSubmit }) => (
          <Form>
            <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none " onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, registerModal: false })}>
              <div className="w-[450px] h-min-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
                <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-6 pb-3 mb-2">
                  Kayıt Ol
                  <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, registerModal: false })}>
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
                        className={`h-14 px-4  border-2 ${!!errors.phoneNumber ? 'border-red-600' : 'border-gray-200  group-hover:border-primary-brand-color focus:border-primary-brand-color'}  rounded w-full transition-colors  outline-none peer text-sm pt-2`}
                      />
                      <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                        Telefon Numarası
                      </span>
                    </label>

                  </div>
                  <ErrorMessage name="phoneNumber" component="div" className='text-red-600 text-xs my-1 w-full text-center   ml-auto' />
                  <div className='flex gap-x-2'>

                    <label className="flex-1 relative group  block cursor-pointer">
                      <Field
                        required id="fullName" name="fullName"
                        className={`h-14 px-4  border-2 ${!!errors.fullName ? 'border-red-600' : 'border-gray-200  group-hover:border-primary-brand-color focus:border-primary-brand-color'}  rounded w-full transition-colors outline-none peer text-sm pt-2`}
                      />
                      <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                        Ad Soyad
                      </span>
                    </label>
                  </div>
                  <ErrorMessage name="fullName" component="div" className='text-red-600 text-xs my-1 w-full text-center  ml-auto' />
                  <div className='flex gap-x-2'>

                    <label className="flex-1 relative group  block cursor-pointer">
                      <Field
                        required id="email" name="email"
                        className={`h-14 px-4  border-2 ${!!errors.email ? 'border-red-600' : 'border-gray-200  group-hover:border-primary-brand-color focus:border-primary-brand-color'}  rounded w-full transition-colors outline-none peer text-sm pt-2`}
                      />
                      <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                        E-Posta
                      </span>
                    </label>

                  </div>
                  <ErrorMessage name="email" component="div" className='text-red-600 text-xs my-1 w-full text-center  ml-auto' />

                  <button type='submit' className="bg-primary-brand-color text-white transition-colors hover:bg-secondary-brand-color   h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold "
                  >
                    Kayıt Ol
                  </button>

                </div>
                <div className="text-xs text-gray-400 font-medium  py-3">
                  Kişisel verilerinize dair Aydınlatma Metni için <a href="" className="text-primary-brand-color font-semibold underline">tıklayınız</a>
                </div>
                <div className="bg-gray-100 w-full h-11 absolute bottom-0 left-0 rounded-lg text-center flex items-center justify-center text-sm text-gray-400 font-semibold">Getir'e üyeyseniz &nbsp;<a className="text-primary-brand-color">Giriş Yap</a></div>
              </div>
            </div>
            <div className="opacity-25 fixed inset-0 z-40 bg-black rounded-lg"></div>
          </Form>)}</Formik>
    </>
  )
}

export default RegisterModal;