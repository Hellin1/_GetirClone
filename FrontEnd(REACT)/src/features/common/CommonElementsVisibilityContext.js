import { createContext, useState } from 'react';

const CommonElementsVisibilityContext = createContext();

function CommonElementsVisibilityProvider({ children }) {
    const [commonElementsVisibility, setCommonElementsVisibility] = useState({
        header: true,
        footer: true,
        loginModal: false,
        registerModal: false,
        languageModal: false,
        approveLoginWithCodeModal: false
    });

    return (
        <CommonElementsVisibilityContext.Provider value={{
            commonElementsVisibility, setCommonElementsVisibility
        }}>
            {children}
        </CommonElementsVisibilityContext.Provider>
    )
}

export { CommonElementsVisibilityContext, CommonElementsVisibilityProvider }