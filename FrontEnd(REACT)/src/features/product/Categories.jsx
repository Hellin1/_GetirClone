import { useState, useContext } from "react"
import { MdKeyboardArrowDown } from "react-icons/md"
import { shadowStyle } from "features/common/Styles"
import { CategoryContext } from "features/category/CategoryContext";


function Categories({ keys, setIndex, setIsTrue, isTrue }) {
  const { categories } = useContext(CategoryContext);

  function fillStates(index) {
    setIsTrue(prev => ({ [keys[index]]: !prev[keys[index]] }))
    setIndex(index)
  }

  return (
    <div className="block p-2 rounded-lg overflow-y-auto"
      style={shadowStyle}>
      <div>
        {categories && categories.map((category, index) => (
          <div className="bg-white pl-2 " key={index}>
            <a href="#" onClick={() => fillStates(index)}
              className="flex flex-row group  items-center  text-center p-1  transition-all hover:bg-purple-100">
              <img src={category.imageUrl} alt={category.description} className="w-8 h-8 rounded border border-gray-200" />
              <div className="text-sm font-semibold  whitespace-nowrap  group-hover:text-brand-color tracking-tight ml-3 font-sans text-gray-700">
                {category.name}
              </div>
              <MdKeyboardArrowDown className="ml-auto" />
            </a>
            <div>
              {isTrue[keys[index]] && category?.subCategories?.map((subCategory, sIndex) => (
                <a href={`#${subCategory.name}`} key={sIndex} className="flex flex-row group  items-center  text-center p-2  transition-all hover:bg-purple-100 bg-white">
                  <div className="text-sm font-semibold  whitespace-nowrap  group-hover:text-brand-color tracking-tight ml-3 font-sans text-gray-700 pl-8" >
                    {subCategory.name}
                  </div>
                  <MdKeyboardArrowDown className="ml-auto" />
                </a>
              ))}
            </div>
          </div>
        ))}
      </div>
    </div>
  )
}

export default Categories
