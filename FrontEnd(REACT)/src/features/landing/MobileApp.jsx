import Title from "../../components/Title"

function MobileApp() {
  return (
    <div className="bg-white py-8 ">
      <Title >Kampanyalar</Title>
      <div className="flex flex-row justify-center mt-8  bg-brand-color h-80 rounded-lg   bg-[url(https://cdn.getir.com/getirweb-images/common/illustration/doodle.png)]">
        <div className="w-1/2 flex flex-col gap-10  justify-center   ml-9">
          <div>
            <h2 className="text-3xl text-white mb-4   font-semibold">Getir'i indirin!</h2>
            <p className="text-white font-sans font-semibold ">İstediğiniz ürünleri dakikalar içinde  kapınıza <br />getirelim</p>
          </div>
          <div className="flex gap-2">
            <a href="https://itunes.apple.com/app/id995280265" target="_blank">

              <img src="https://getir.com/_next/static/images/appstore-tr-141ed939fceebdcee96af608fa293b31.svg" alt="" />
            </a>
            <a href="https://play.google.com/store/apps/details?id=com.getir" target="_blank">

              <img src="https://getir.com/_next/static/images/googleplay-tr-6b0c941b7d1a65d781fb4b644498be75.svg" alt="" />
            </a>
            <a href="https://appgallery7.huawei.com/#/app/C100954039" target="_blank">
              <img src="https://getir.com/_next/static/images/huawei-appgallery-tr-4b890fa3167bc62f9069edaf45aa7f30.svg" alt="" />
            </a>
          </div>
        </div>
        <div className="w-1/2 flex justify-end items-end">
          <img className=" " src="https://cdn.getir.com/getirweb-images/common/landing/phoneLanding.png" alt="" />
        </div>
      </div>
    </div>
  )
}

export default MobileApp
