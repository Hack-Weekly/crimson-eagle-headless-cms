"use client";
import { ThemeContextProvider } from "@/context/themeContext";
import React from "react";

type ProviderProps = {
  children: React.ReactNode;
};

const Provider: React.FC<ProviderProps> = ({ children }) => {
  return <ThemeContextProvider>{children}</ThemeContextProvider>;
};
export default Provider;
