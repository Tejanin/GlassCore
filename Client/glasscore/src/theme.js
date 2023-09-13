import {createContext, Usestate, useMemo }from "react";
import { createTheme } from "@mui/material/styles";
import { create } from "@mui/material/styles/createTransitions";

//tokens de colores
export const tokens = (mode) => ({
    ...Usestate(mode === 'dark'
    ?{
        Azul_Claro: {
            100: "#cee5e8",
            200: "#9ccbd1",
            300: "#6bb2b9",
            400: "#3998a2",
            500: "#087e8b",
            600: "#06656f",
            700: "#054c53",
            800: "#033238",
            900: "#02191c"
        },
        Gris: {
            100: "#f9fafc",
            200: "#f3f6f9",
            300: "#eef1f6",
            400: "#e8edf3",
            500: "#e2e8f0",
            600: "#b5bac0",
            700: "#888b90",
            800: "#5a5d60",
            900: "#2d2e30"
        },
        white: {
            100: "#fbfbfb",
            200: "#f7f7f7",
            300: "#f4f4f4",
            400: "#f0f0f0",
            500: "#ececec",
            600: "#bdbdbd",
            700: "#8e8e8e",
            800: "#5e5e5e",
            900: "#2f2f2f"
        },
        Azul_Oscuro: {
            100: "#ced7dd",
            200: "#9db0bb",
            300: "#6d8898",
            400: "#3c6176",
            500: "#0b3954",
            600: "#092e43",
            700: "#072232",
            800: "#041722",
            900: "#020b11"
        },
        Azul_Mas_Claro: {
            100: "#f2f7fb",
            200: "#e5eff7",
            300: "#d9e7f2",
            400: "#ccdfee",
            500: "#bfd7ea",
            600: "#99acbb",
            700: "#73818c",
            800: "#4c565e",
            900: "#262b2f"
        }
    } : {
        
        Azul_Claro: {
        100: "#02191c",
        200: "#033238",
        300: "#054c53",
        400: "#06656f",
        500: "#087e8b",
        600: "#3998a2",
        700: "#6bb2b9",
        800: "#9ccbd1",
        900: "#cee5e8",
    },
    Gris: {
        100: "#2d2e30",
        200: "#5a5d60",
        300: "#888b90",
        400: "#b5bac0",
        500: "#e2e8f0",
        600: "#e8edf3",
        700: "#eef1f6",
        800: "#f3f6f9",
        900: "#f9fafc",
    },
    white: {
        100: "#2f2f2f",
        200: "#5e5e5e",
        300: "#8e8e8e",
        400: "#bdbdbd",
        500: "#ececec",
        600: "#f0f0f0",
        700: "#f4f4f4",
        800: "#f7f7f7",
        900: "#fbfbfb",
    },
    Azul_Oscuro: {
        100: "#020b11",
        200: "#041722",
        300: "#072232",
        400: "#092e43",
        500: "#0b3954",
        600: "#3c6176",
        700: "#6d8898",
        800: "#9db0bb",
        900: "#ced7dd",
    },
    Azul_Mas_Claro: {
        100: "#262b2f",
        200: "#4c565e",
        300: "#73818c",
        400: "#99acbb",
        500: "#bfd7ea",
        600: "#ccdfee",
        700: "#d9e7f2",
        800: "#e5eff7",
        900: "#f2f7fb",
    }})
})

//configuracion del tema mui

export const themeSettings = (mode) => {
    const colors = tokens(mode);
}

return{
    palette: {
        mode:mode,
        ...Usestate(mode === 'dark'
        ?{
            primary: {
                main: colors.Azul_Oscuro[500],
            },
            secondary:{
                main: colors.Azul_Claro[500],
            },
            neutral: {
                dark: colors.Gris[700],
                main: colors.Gris[500],
                light: colors.Gris[100]
            },
            background:{
                default: colors.white[500],
            }
          }  :{
            primary: {
                main: colors.Azul_Oscuro[100],
            },
            secondary:{
                main: colors.Azul_Claro[500],
            },
            neutral: {
                dark: colors.Gris[700],
                main: colors.Gris[500],
                light: colors.Gris[100]
            },
            background:{
                default: "#fcfcfc",
            }
           })
    },
    typography: {
        fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 12,
        h1: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 40,
        },
        h2: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 32,
        },
        h3: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 24,
        },
        h4: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 20,
        },
        h5: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 16,
        },
        h6: {
            fontFamily:["Source sans Pro", "sans-serif"].join(","),
        fontSize: 14,
        },
    },
};

export const ColorModeContext = createContext(
    {toggleColorMode: () => {}}
);
export const useMode = () =>{
    const [mode,setMode] = useState("dark");

    const colorMode = useMemo(
        () => ({
    toggleColorMode: () =>
    setMode((prev) => (prev === "light" ? "dark" : "light")),
}),
[] );
const theme = useMemo(() => createTheme(themeSettings(mode)), [mode])
}