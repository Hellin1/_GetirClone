import { useState, useEffect } from "react"
import Slider from "react-slick"
import Banners from "api/banners.json"
import Title from "../../components/Title"
import { IoIosArrowBack, IoIosArrowForward } from "react-icons/io"

function NextBtn({ className, style, onClick }) {
  return (
    <button
      className={`text-brand-color absolute top-1/2 -right-6 -translate-y-1/2 ${className}`}
      style={style}
      onClick={onClick}
    ><IoIosArrowForward size={22} /></button>
  );
}

function PrevBtn({ className, style, onClick }) {
  return (
    <button
      className={`text-brand-color absolute top-1/2 -left-6 -translate-y-1/2 ${className}`}
      style={style}
      onClick={onClick}
    ><IoIosArrowBack size={22} /></button>
  );
}


function Campaigns() {
  const [banners, setBanners] = useState([])

  useEffect(() => {
    setBanners(Banners)

  }, [])


  const settings = {
    dots: false,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 5000,
    cssEase: "linear",
    nextArrow: <NextBtn />,
    prevArrow: <PrevBtn />,
  }

  return (
    <div className="container mx-auto py-8">
      <Title>Kampyanyalar</Title>
      <Slider className="-mx-2"  {...settings}>
        {banners.length && banners.map((banner) => (
          <div key={banner.id} >
            <picture className="block px-2">
              <img src={banner.image} alt="banner" className="rounded-lg" />
            </picture>
          </div>
        ))}
      </Slider>
    </div>
  )
}

export default Campaigns