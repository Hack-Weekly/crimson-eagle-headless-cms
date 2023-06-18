"use client";
import { createContext, useReducer } from "react";

export const ThemeTypes = {
  ToggleTheme: "ToggleTheme",
};

export const themeReducer = (state: any, action: any) => {
  switch (action.type) {
    case ThemeTypes.ToggleTheme:
      return { ...state, theme: state.theme === "dark" ? "light" : "dark" };
    default:
      return state;
  }
};

export const themeContext = createContext<{
  theme: "dark" | "light";
  dispatch: React.Dispatch<any>;
} | null>(null);

export const ThemeContextProvider = ({
  children,
}: {
  children: React.ReactNode;
}) => {
  const [state, dispatch] = useReducer(themeReducer, { theme: "dark" });

  return (
    <themeContext.Provider value={{ ...state, dispatch }}>
      {children}
    </themeContext.Provider>
  );
};
