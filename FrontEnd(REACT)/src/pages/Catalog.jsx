import Categories from "../features/product/Categories"
import Items from "../features/product/Items"
import CartModal from "../features/cart/CartModal"
import "../features/product/main.css"
import { useState, useEffect, useContext } from "react"
import CategoryList from "../data/categoryList"
import GetirHeader from "../components/GetirHeader"
import { CategoryContext } from "features/category/CategoryContext"
import { CartContext } from "features/cart/CartContext"
import { CommonElementsVisibilityContext } from "features/common/CommonElementsVisibilityContext"
import { ProductContext } from "features/product/ProductContext"

function Catalog() {
  const [keys, setKeys] = useState([])
  const [index, setIndex] = useState(0)
  const [isTrue, setIsTrue] = useState({ "Su & İçecek": true }) 
  const { categories, getCategories, setCategories } = useContext(CategoryContext);
  const { setCommonElementsVisibility, commonElementsVisibility } = useContext(CommonElementsVisibilityContext);


  useEffect(() => {   
    let categories;

    async function fillStates() {
      categories = await getCategories();
      setCategories(categories);
    }

    fillStates()
    setKeys(Object.keys(CategoryList))
    setCommonElementsVisibility({ ...commonElementsVisibility, header: true });
  }, [])

  return (
    <>
      <GetirHeader />
      <div className="flex mt-5">
        <div className=" md:w-[1232px] mx-auto flex flex-row gap-5">
          <div className="w-[20%] h-[90vh] min-h-[90vh] sticky top-32 z-40  overflow-auto scrollbar-hide">
            <div className="">
              <span className="font-semibold text-gray-500 text-[0.9rem]" >
                Kategoriler
              </span>
              <Categories keys={keys} setKeys={setKeys} index={index} setIndex={setIndex} isTrue={isTrue} setIsTrue={setIsTrue} />
            </div>
          </div>
          <div className="w-[55%] h-full">
            <Items  keys={keys} index={index}/>
          </div>
          <div className="w-[25%] h-[90vh] sticky top-32 z-10 ">
            <span className="font-semibold text-gray-500 text-[0.9rem]">
              Sepetim
            </span>
            <CartModal />
          </div>
        </div>
      </div>
    </>
  )
}

export default Catalog
