import { RootState } from "@/redux/store/store";
import { Inter } from "next/font/google";
import React, { useContext } from "react";
import { useDispatch, useSelector } from "react-redux";
import Navbar from "../Navbar/Navbar";

type LayoutProps = { children: React.ReactNode };
const inter = Inter({ subsets: ["latin"] });

const Layout: React.FC<LayoutProps> = ({ children }) => {
  const theme = useSelector((state: RootState) => state.Theme.theme);
  const dispatch = useDispatch();
  return (
    <html lang="eng" className={`${theme}`}>
      <body className={` ${inter.className}`}>
        <main>
          <Navbar />
          {children}
        </main>
      </body>
    </html>
  );
};
export default Layout;
