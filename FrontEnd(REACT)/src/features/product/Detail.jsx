import GetirHeader from './landingPage/GetirHeader'

function Detail() {
  return (
    <div>
    <GetirHeader />
    <div className="flex mt-5">
      <div className=" md:w-[1232px]  p-8  mx-auto flex flex-row gap-7">
        <div className='w-[33%] h-[396px]  flex justify-center border-2 border-indigo-950'> 

          <div className="w-[300px] h-[396px] flex justify-center items-center    top-32 z-40  overflow-auto scrollbar-hide ">
            <img src="https://market-product-images-cdn.getirapi.com/product/83cebb45-cf5f-441f-9c78-92fb7c89dc11.jpg" alt="" className='h-full w-full object-contain' />
          </div>
        </div>
        <div className="w-[67%] h-[90vh]   ">
          <h2 className='text-2xl '>
            Carte d'Or Classic Extra Barista

          </h2>
        </div>
      </div>
    </div>
  </div>
  )
}

export default Detail