import Header from "components/Header"
import HeroSection from "features/landing/HeroSection"
import Categories from "features/product/Categories"
import MobileApp from "features/landing/MobileApp"
import Cards from "features/landing/Cards"
import Footer from "components/Footer"
import GetirHeader from "components/GetirHeader"

function StartPage() {
  

  return (
    <>
      <GetirHeader height={11}/>
      <HeroSection />
      <Categories />
      {/* <Campaigns /> */}
      <div className="  w-[1232px]   mx-auto">
        {/* <Favorites /> */}
        <MobileApp />
        <Cards />
      </div>

    </>
  )
}

export default StartPage