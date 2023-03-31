import React from "react";
import { useState, useEffect } from 'react';
import { useLocalStorage } from "./useLocalStorage";


export const AppContext = React.createContext({});

export function AppContextProvider({ children }) {


    const [login, setLogin] = useLocalStorage("loginInfo", {});

    const clearLogin = () =>{
        setLogin({})
    };

    const context = {
        login, setLogin, clearLogin
    }

    return (
        <AppContext.Provider value={context}>
            {children}
        </AppContext.Provider>
    )
}