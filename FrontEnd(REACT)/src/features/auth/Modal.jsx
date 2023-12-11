import React, { useState } from "react"
import { BiGlobe } from "react-icons/bi"
import { IoMdClose } from "react-icons/io"
import { FaFacebook } from "react-icons/fa"
import ReactFlagsSelect from "react-flags-select"

export default function Modal() {
  const [showModal, setShowModal] = React.useState(false)
  const [selected, setSelected] = useState("TR")

  const phoneNmbrCountryCodes = {
    US: "+1",
    DE: "+50",
    TR: "+90",
    IT: "+7",
    IN: "+15",
  }

  return (
    <>
      <button
        className="bg-pink-500 text-white active:bg-pink-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150"
        type="button"
        onClick={() => setShowModal(true)}
      >
        Open regular modal
      </button>

      <button
        onClick={() => setShowModal(true)}
        className="flex items-center gap-x-2 text-white transition  text-opacity-80 hover:text-opacity-100 bg-brand-color"
      >
        <BiGlobe size={20} />
        Türkçe TR
      </button>
      {showModal ? (
        <>
          <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none ">
            <div className="w-[450px] h-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative">
              <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-6 mb-4">
                Giriş yap veya kayıt ol
                <div className="absolute right-0  bg-gray-200 text-black p-2   rounded-lg cursor-pointer" onClick={() => setShowModal(false)}> 
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
                    <input
                      required
                      className="h-14 px-4  border-2 border-gray-200 rounded w-full transition-colors group-hover:border-primary-brand-color focus:border-primary-brand-color outline-none peer text-sm pt-2"
                    />
                    <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                      Telefon Numarası
                    </span>
                  </label>
                </div>
                <button className="bg-brand-yellow text-primary-brand-color transition-colors hover:bg-primary-brand-color hover:text-brand-yellow  h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold ">
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
        </>
      ) : null}
    </>
  )
}