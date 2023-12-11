import { useState, useContext, useEffect, memo } from "react"
import { GoPlus } from "react-icons/go"
import { CartContext } from "features/cart/CartContext";
import { ProductContext } from "./ProductContext";
import { apiService } from "services/apiService";

const Items = memo(({ keys, index }) => {

  const { getCart, setCart } = useContext(CartContext)
  const { products, getProducts, setProducts } = useContext(ProductContext);
  const [renderCount, setRenderCount] = useState(0);

  let productData;

  useEffect(() => {
    async function FillStates() {
      productData = await getProducts();
      setProducts(productData)
    }
    FillStates();
    setRenderCount(prevCount => prevCount + 1);
  }, [])




  async function addToCart(productId, customerId = 1, note = "x", quantity = 1) {
    let obj = {
      ProductId: productId,
      Quantity: quantity
    }; 

    try {
      await apiService.post("Cart/AddToCart", obj);

      const updatedSepet = await getCart(customerId);
      setCart(updatedSepet);
    }
    catch (error) {
      console.log("hata: ", error);
    }
  }

  return (
    <>
      {products[keys[index]] && products[keys[index]]?.subCategories?.map((category, index) => (
        category.products.length > 0 &&
        <div key={index}>
          <div className="text-brand-color font-bold text-2xl">
            <span id={`${category.name}`} className="font-semibold text-gray-500 text-[0.9rem] py-2 no-underline scroll-mt-32">
              {category.name === "Su" ? "Su ve İçecek > Su" : category.name}
            </span>
          </div>
          <div className="grid grid-cols-4 gap-2 bg-white   ">
            {category?.products?.map((urun, index) => (
              <div className="relative h-full w-full text-center  mx-auto flex flex-col justify-center items-center select-none cursor-pointer  p-2" key={index}>
                <div className="absolute  right-0 top-0 self-end border rounded-md text-brand-color p-[5px]  mr-2 mt-2 flex justify-center items-center bg-white" onClick={() => addToCart(urun.id)}>
                  <GoPlus size={20} className="self-center " />
                </div>
                <img className="w-[120px] h-[120px] self-center " src={urun.imageUrl} alt="" />
                <div className="text-primary-brand-color font-semibold">
                  ₺{urun.price.toFixed(2)}
                </div>
                {urun.title}
                <br />
                <span className="text-gray-500 text-sm">{urun.dimensionsAndCapacity}</span>
              </div>
            ))}
          </div>
        </div>
      ))}
    </>
  )
});

export default Items
