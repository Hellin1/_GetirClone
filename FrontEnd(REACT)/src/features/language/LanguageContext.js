import { createContext, useEffect, useState } from 'react';
import { useTranslation } from 'react-i18next';

const LanguageContext = createContext();

function LanguageContextProvider({ children }) {
    const { t, i18n } = useTranslation();

    useEffect(() => {
        const lng = navigator.language;
        i18n.changeLanguage(lng);
    }, [])


    return (
        <LanguageContext.Provider value={{
            t, i18n
        }}>
            {children}
        </LanguageContext.Provider>
    )
}

export { LanguageContext, LanguageContextProvider }