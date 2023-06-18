"use client";
import { store } from "@/redux/store/store";
import React from "react";
import { Provider as ReduxProvider } from "react-redux";

type ProviderProps = {
  children: React.ReactNode;
};

const Provider: React.FC<ProviderProps> = ({ children }) => {
  return <ReduxProvider store={store}>{children}</ReduxProvider>;
};
export default Provider;
