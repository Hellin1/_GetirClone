import { useState } from "react"
import { FaFacebook } from "react-icons/fa"
import Slider from "react-slick"
import "slick-carousel/slick/slick.css"
import "slick-carousel/slick/slick-theme.css"
import ReactFlagsSelect from "react-flags-select"
import { AuthContext } from "features/auth/AuthContext"
import { useContext } from "react"
import { CommonElementsVisibilityContext } from "features/common/CommonElementsVisibilityContext"
import * as Yup from "yup";
import { Field, Formik, Form, ErrorMessage } from "formik"

function HeroSection() {
  const [selected, setSelected] = useState("TR")
  const { HandleLogin, isAuthenticated } = useContext(AuthContext);
  const { commonElementsVisibility, setCommonElementsVisibility } = useContext(CommonElementsVisibilityContext);

  const phoneNumberCountryCodes = {
    US: "+1",
    DE: "+50",
    TR: "+90",
    IT: "+7",
    IN: "+15"
  }

  const settings = {
    dots: false,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    cssEase: "linear",
    arrows: false
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
    else {
      setCommonElementsVisibility({ ...commonElementsVisibility, approveLoginWithCodeModal: true })
    }
  }



  return (
    <div className="relative h-[500px]  mx-auto before:bg-gradient-to-r before:from-primary-brand-color before:to-transparent before:absolute before:inset-0 before:w-full before:h-full before:z-10">
      <Formik
        initialValues={initialValues}
        validationSchema={validationSchema}
        onSubmit={handleSubmit}>
        {({ values, errors, touched, handleSubmit }) => (
          <Form>
            <Slider {...settings}>
              <div>
                <img
                  className="w-full h-[500px] object-cover"
                  src="https://cdn.getir.com/getirweb-images/common/hero-posters/getir-mainpage-4.jpg"
                />
              </div>
              <div>
                <img
                  className="w-full h-[500px]  object-cover"
                  src="https://cdn.getir.com/getirweb-images/common/hero-posters/getir-mainpage-1.jpg"
                />
              </div>
            </Slider>
            <div className="container flex justify-between items-center absolute top-0 left-1/2 -translate-x-1/2 h-full w-[1232px] z-20">
              <div>
                <img
                  src="https://getir.com/_next/static/images/bimutluluk-b3a7fcb14fc9a9c09b60d7dc9b1b8fd6.svg"
                  alt=""
                />
                <h3 className="mt-8 text-4xl font-semibold text-white">
                  Dakikalar içinde <br /> kapınızda
                </h3>
              </div>
              <div className="w-[400px] rounded-lg bg-gray-50 p-6">
                <h4 className="text-primary-brand-color text-center font-semibold mb-4">
                  Giriş yap veya kayıt ol
                </h4>

                <div className="grid gap-y-3">
                  <div className="flex gap-x-2">
                    <ReactFlagsSelect
                      countries={Object.keys(phoneNumberCountryCodes)}
                      customLabels={phoneNumberCountryCodes}
                      onSelect={code => setSelected(code)}
                      selected={selected}
                      className="flag-select"
                    />
                    <label className="flex-1 relative group  block cursor-pointer">
                      <Field required className={`${!!errors.phoneNumber ? 'border-red-600' : 'border-gray-200 group-hover:border-primary-brand-color focus:border-primary-brand-color'} h-14 px-4  border-2 rounded w-full transition-colors  outline-none peer text-sm pt-2`} maxLength="10" id="phoneNumber" name="phoneNumber" />
                      <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">Telefon Numarası</span>
                    </label>
                  </div>
                  <div className="w-full">

                    <ErrorMessage name="phoneNumber" component="div" className='text-red-600 text-xs my-1 w-[63%]  ml-auto' />
                  </div>
                  <button type='submit' className="bg-brand-yellow text-primary-brand-color transition-colors hover:bg-primary-brand-color hover:text-brand-yellow  h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold ">
                    Telefon numarası ile devam et
                  </button>
                  <hr className="h-[1px] bg-gray-300 my-2" />
                  <button className="bg-blue-700 bg-opacity-10 text-blue-700 px-4 text-opacity-90 transition-colors hover:bg-blue-700 hover:text-white  h-12 flex items-center rounded-md w-full text-sm font-semibold ">
                    <FaFacebook size={24} />
                    <span className="mx-auto">
                      Facebook ile devam et
                    </span>
                  </button>
                </div>
              </div>
            </div>
          </Form>)}</Formik>
    </div>
  )
}

export default HeroSection
