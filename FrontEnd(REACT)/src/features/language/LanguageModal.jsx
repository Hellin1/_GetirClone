import { LanguageContext } from './LanguageContext'
import React, { useContext } from 'react'
import { IoMdClose } from 'react-icons/io'
import { CommonElementsVisibilityContext } from 'features/common/CommonElementsVisibilityContext';

function LanguageModal() {
  const { t, i18n } = useContext(LanguageContext);
  const { commonElementsVisibility, setCommonElementsVisibility } = useContext(CommonElementsVisibilityContext);

  return (
    <>
      <div className="justify-center items-center flex overflow-x-hidden overflow-y-auto fixed inset-0 z-50 outline-none focus:outline-none " onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, languageModal: false })}>
        <div className="w-[450px] h-[340px]  rounded-lg bg-gray-50 px-8  py-4 relative" onClick={(e) => e.stopPropagation()}>
          <div className="flex justify-center  text-lg text-primary-brand-color font-base relative py-6 mb-4">
            {t('common:change_language')}
            <div className="absolute right-0  bg-gray-200 text-black p-2 rounded-lg cursor-pointer" onClick={() => setCommonElementsVisibility({ ...commonElementsVisibility, languageModal: false })}>
              <IoMdClose size={18} className="transform scale-[0.]" />
            </div>
          </div>
          <div className="grid gap-y-3">
            <div className="flex gap-x-2">

              <label className="flex-1 relative group  block cursor-pointer w-10">
                <input type="radio"
                  required
                  className=" px-4 h-20    border-2 border-gray-200 rounded  transition-colors group-hover:border-primary-brand-color focus:border-primary-brand-color outline-none peer text-sm pt-2"
                />
                <span className="absolute top-0 left-0 h-full px-4 flex items-center text-sm text-gray-500 transition-all peer-focus:h-7 peer-focus:text-primary-brand-color peer-focus:text-xs peer-valid:h-7  peer-valid:text-primary-brand-color peer-valid:text-xs">
                  Telefon Numarası
                </span>
              </label>
            </div>
            <button className="bg-gray-400 text-white  transition-colors hover:bg-primary-brand-color hover:text-brand-yellow  h-12 flex items-center justify-center rounded-md w-full text-sm font-semibold ">
              Telefon numarası ile devam et
            </button>

          </div>

          <div className="bg-gray-100 w-full h-11 absolute bottom-0 left-0 rounded-lg text-center flex items-center justify-center text-sm text-gray-500 font-semibold">Hala kayıt olmadınız mı? &nbsp;<a className="text-primary-brand-color">Kayıt Ol</a></div>
        </div>
      </div>
      <div className="opacity-25 fixed inset-0 z-40 bg-black rounded-lg"></div>

    </>
  )
}

export default LanguageModal