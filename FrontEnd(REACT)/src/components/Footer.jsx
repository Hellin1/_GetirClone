import { BsFacebook, BsTwitter, BsInstagram } from "react-icons/bs"
import { BiGlobe } from "react-icons/bi"
import { Link } from "react-router-dom"
import { CommonElementsVisibilityContext } from "features/common/CommonElementsVisibilityContext"
import { useContext } from "react"

function Footer() {
  const { commonElementsVisibility } = useContext(CommonElementsVisibilityContext);

  return (
    <div className={`bg-white w-full h-[359px] mt-10  p-8  ${!commonElementsVisibility.footer && 'hidden'} `}>
      <div className="w-[1232px] mx-auto flex flex-row gap-14 h-[83%] justify-between">
        <div>
          <h3 className="text-xl mb-3  text-primary-brand-color">
            Getir'i indirin!
          </h3>
          <a href="https://itunes.apple.com/app/id995280265" target="_blank">

            <img
              className="py-2"
              src="https://getir.com/_next/static/images/appstore-tr-141ed939fceebdcee96af608fa293b31.svg"
              alt=""
            />
          </a>
          <a href="https://play.google.com/store/apps/details?id=com.getir" target="_blank">

            <img
              className="py-2"
              src="https://getir.com/_next/static/images/googleplay-tr-6b0c941b7d1a65d781fb4b644498be75.svg"
              alt=""
            />
          </a>
          <a href="https://appgallery7.huawei.com/#/app/C100954039" target="_blank">

            <img
              className="py-2"
              src="https://getir.com/_next/static/images/huawei-appgallery-tr-4b890fa3167bc62f9069edaf45aa7f30.svg"
              alt=""
            />
          </a>
        </div>
        <div>
          <h3 className="text-xl mb-3  text-primary-brand-color">
            Getir'i indirin!
          </h3>
          <div className="p-1 font-light text-sm">Hakkımızda</div>
          <div className="p-1 font-light text-sm">Kariyer</div>
          <div className="p-1 font-light text-sm">Teknoloji Kariyerleri</div>
          <div className="p-1 font-light text-sm">İletişim</div>
          <div className="p-1 font-light text-sm">
            Sosyal Sorumluluk Projeleri
          </div>
        </div>

        <div>
          <h3 className="text-xl mb-3  text-primary-brand-color break-keep w-64">
            Yardıma mı ihtiyacınız var?
          </h3>
          <div className="p-1 font-light text-sm">Sıkça Sorulan Sorular</div>
          <div className="p-1 font-light text-sm">
            Kişisel Verilerin Korunması
          </div>
          <div className="p-1 font-light text-sm">Gizlilik Politikası</div>
          <div className="p-1 font-light text-sm">Kullanım Koşulları</div>
          <div className="p-1 font-light text-sm">Çerez Politikası</div>
        </div>
        <div>
          <h3 className="text-xl mb-3  text-primary-brand-color">
            İş Ortağımız Olun
          </h3>
          <div className="p-1 font-light text-sm">Bayimiz Olun</div>
          <div className="p-1 font-light text-sm">Deponuzu Kiralayın</div>
          <div className="p-1 font-light text-sm">
            GetirYemek Restoranı Olun
          </div>
          <div className="p-1 font-light text-sm">
            GetirÇarşı İşletmesi Olun
          </div>
          <Link className="p-1 font-light text-sm" to={`ZincirRestoranlar`}>
            Zincir Restoranlar
          </Link>
        </div>
        <div className="mt-5 ">
          <img className="ml-auto "
            width={"72px"}
            height={"84px"}
            src="https://cdn.getir.com/getirweb-images/common/etbis.png"
            alt=""
          />
        </div>
      </div>
      <div className="w-[1232px] mx-auto ">
        <hr />
        <div className="flex justify-between py-7">
          <div className=" flex text-xs items-center">
            &#169; 2023 Getir
            {/* &middot; */}
            <span className="bg-secondary-brand-color rounded-full inline-block  w-[3px] h-[3px]  self-center mx-2"></span>
            <span className="text-primary-brand-color">
              Bilgi Toplumu Hizmetleri
            </span>
          </div>
          <div className="flex gap-5 text-gray-500 items-center">
            <BsFacebook size={20} />
            <BsTwitter size={20} />
            <BsInstagram size={20} />
            <button className="flex text-[0.8rem]  gap-2 items-center border border-slate-200  border-1 rounded-md  p-[6px]">
              <BiGlobe size={20} />
              <span className="self-center">
                Türkçe (TR)

              </span>
            </button>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Footer
