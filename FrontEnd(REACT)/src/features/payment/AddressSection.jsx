import AddressIcon from "features/address/AddressIcon"
import { shadowStyle } from "features/common/Styles"

function AddressSection({address}) {
    return (
        <div className='bg-white p-4 rounded-lg  mb-5 ' style={shadowStyle}>
            <div className='w-full h-full flex  items-center '>
                <AddressIcon pathClass="stroke-primary-brand-color" className={`mr-3 mb-2`} size={22} />
                <div className='flex flex-col gap-1'>

                    <div className='text-sm  text-gray-600 font-semibold'>{address?.title}</div>
                    <span className='text-sm text-gray-500'>{address?.addressString}</span>
                </div>
            </div>
        </div>

    )
}

export default AddressSection