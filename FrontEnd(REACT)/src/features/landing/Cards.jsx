function Cards() {
  return (
    <div className="flex flex-row items-center gap-5 mt-12     w-[1232px] mx-auto">
      <div className="w-1/3 h-[350px]  shadow-lg flex flex-col items-center justify-center gap-6">
        <img src="https://getir.com/_next/static/images/intro-in-minutes-a7a9238a73013642a6597c4db06653c1.svg" alt="" />
        <div  className="mx-16 text-center ">
          <span className="text-xl font-semibold  text-brand-color block mb-3">Her siparişinize bir kampanya</span>
          <span >Getir'de vereceğiniz her siparişe uygun bir kampyanya bulabilirsiniz.</span>
        </div>
      </div>
      <div className="w-1/3 h-[350px]  shadow-lg flex flex-col items-center justify-center gap-6">
        <img src="https://getir.com/_next/static/images/intro-market-courier-34cd8b0ca1d547580d506566edfacf8d.svg" alt="" />
        <div  className="mx-16 text-center ">
          <span className="text-xl font-semibold  text-brand-color block mb-3">Dakikalar içinde kapında</span>
          <span >Getir'le siparişiniz dakikalar içinde kapınıza gelecektir.</span>
        </div>
      </div>
      <div className="w-1/3 h-[350px]  shadow-lg flex flex-col items-center justify-center gap-6">
        <img src="https://getir.com/_next/static/images/intro-discount-6248544cb695830a2e25debd3c0f3d29.svg" alt="" />
        <div  className="mx-16 text-center ">
          <span className="text-xl font-semibold  text-brand-color block mb-3">Binlerce çeşit mutluluk</span>
          <span >Getir'de binlerce çeşit arasından seçiminizi yapabilirsiniz.</span>
        </div>
      </div>



    </div>
  )
}

export default Cards