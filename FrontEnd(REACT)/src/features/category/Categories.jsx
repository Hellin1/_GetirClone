import { useEffect, useState } from "react"
import categoryData from "api/categories.json"
import Category from "./Category"
import Title from "../../components/Title"
import { shadowStyle } from "./Styles"

function Categories() {
  const [categories, setCategories] = useState([])
  useEffect(() => {
    setCategories(categoryData)
  }, [])

  return ( 
    <div className="bg-white py-6 relative z-10" style={shadowStyle}>
      <div className="container w-[1232px] mx-auto">
        <Title>Kategoriler</Title>
        <div className="grid grid-cols-10 pb-8">
          {categories && categories.map((category, index) =>
            <Category key={index} category={category} />)
          }
        </div>
      </div>
    </div>
  )
}

export default Categories